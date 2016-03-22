using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tortuga.Chain.CommandBuilders;

namespace Tortuga.Chain.Materializers
{
    /// <summary>
    /// Materializes the result set as a TableSet.
    /// </summary>
    /// <typeparam name="TCommand">The type of the t command type.</typeparam>
    /// <typeparam name="TParameter">The type of the t parameter type.</typeparam>
    internal sealed class TableSetMaterializer<TCommand, TParameter> : Materializer<TCommand, TParameter, TableSet> where TCommand : DbCommand
        where TParameter : DbParameter
    {
        readonly string[] m_TableNames;

        /// <summary>
        /// </summary>
        /// <param name="commandBuilder">The command builder.</param>
        /// <param name="tableNames">The table names.</param>
        public TableSetMaterializer(DbCommandBuilder<TCommand, TParameter> commandBuilder, string[] tableNames)
            : base(commandBuilder)
        {
            m_TableNames = tableNames;
        }

        /// <summary>
        /// Execute the operation synchronously.
        /// </summary>
        /// <returns></returns>
        public override TableSet Execute(object state = null)
        {
            TableSet result = null;

            var executionToken = Prepare();
            executionToken.Execute(cmd =>
                        {
                            using (var reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess))
                            {
                                result = new TableSet(reader, m_TableNames);
                                return result.Sum(t => t.Rows.Count);
                            }
                        }, state);

            if (m_TableNames.Length > result.Count)
                throw new DataException($"Expected at least {m_TableNames.Length} tables but received {result.Count} tables");

            return result;
        }

        /// <summary>
        /// Execute the operation asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="state">User defined state, usually used for logging.</param>
        /// <returns></returns>
        public override async Task<TableSet> ExecuteAsync(CancellationToken cancellationToken, object state = null)
        {
            TableSet result = null;

            var executionToken = Prepare();

            await executionToken.ExecuteAsync(async cmd =>
            {
                using (var reader = await cmd.ExecuteReaderAsync(CommandBehavior.SequentialAccess).ConfigureAwait(false))
                {
                    result = new TableSet(reader, m_TableNames);
                    return result.Sum(t => t.Rows.Count);
                }
            }, cancellationToken, state).ConfigureAwait(false);

            if (m_TableNames.Length > result.Count)
                throw new DataException($"Expected at least {m_TableNames.Length} tables but received {result.Count} tables");

            return result;
        }
    }
}
