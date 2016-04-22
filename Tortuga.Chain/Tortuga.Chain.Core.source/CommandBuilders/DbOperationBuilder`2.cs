﻿using System;
using System.ComponentModel;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using Tortuga.Chain.Core;
using Tortuga.Chain.DataSources;
using Tortuga.Chain.Materializers;

namespace Tortuga.Chain.CommandBuilders
{
    /// <summary>
    /// This is the base class from which all other operation builders are created.
    /// </summary>
    /// <typeparam name="TConnection">The type of the t connection.</typeparam>
    /// <typeparam name="TTransaction">The type of the t transaction.</typeparam>
    /// <seealso cref="DbCommandBuilder" />
    public abstract class DbOperationBuilder<TConnection, TTransaction> : DbCommandBuilder
        where TConnection : DbConnection
        where TTransaction : DbTransaction
    {
        private readonly IOperationDataSource<TConnection, TTransaction> m_DataSource;

        /// <summary>
        /// </summary>
        /// <param name="dataSource">The data source.</param>
        protected DbOperationBuilder(IOperationDataSource<TConnection, TTransaction> dataSource)
        {
            if (dataSource == null)
                throw new ArgumentNullException(nameof(dataSource), $"{nameof(dataSource)} is null.");

            m_DataSource = dataSource;
            StrictMode = dataSource.StrictMode;
        }

        /// <summary>
        /// Gets the data source.
        /// </summary>
        /// <value>The data source.</value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IOperationDataSource<TConnection, TTransaction> DataSource
        {
            get { return m_DataSource; }
        }

        /// <summary>
        /// Indicates this operation has no result set.
        /// </summary>
        /// <returns>ILink&lt;System.Nullable&lt;System.Int32&gt;&gt;.</returns>
        public override ILink<int?> AsNonQuery()
        {
            return new Operation<TConnection, TTransaction>(this);
        }

        /// <summary>
        /// Prepares the command for execution by generating any necessary SQL.
        /// </summary>
        /// <returns>ExecutionToken&lt;TCommand&gt;.</returns>
        public abstract OperationExecutionToken<TConnection, TTransaction> Prepare();

        //internal abstract OperationImplementation<TConnection, TTransaction> GetOperationImplementation();
        //internal abstract OperationImplementationAsync<TConnection, TTransaction> GetOperationImplementationAsync();


        protected internal abstract int? Implementation(TConnection connection, TTransaction transaction);

        protected internal abstract Task<int?> ImplementationAsync(TConnection connection, TTransaction transaction, CancellationToken cancellationToken);

  
    }
}
