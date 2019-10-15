﻿using Npgsql;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using Tortuga.Chain.AuditRules;
using Tortuga.Chain.Core;
using Tortuga.Chain.DataSources;
using Tortuga.Chain.PostgreSql;

namespace Tortuga.Chain
{
    /// <summary>
    /// Class PostgreSqlDataSource.
    /// </summary>
    /// <seealso cref="PostgreSqlDataSourceBase" />
    public class PostgreSqlDataSource : PostgreSqlDataSourceBase, IRootDataSource
    {
        internal ICacheAdapter m_Cache;
        internal ConcurrentDictionary<Type, object> m_ExtensionCache;
        readonly NpgsqlConnectionStringBuilder m_ConnectionBuilder;
        PostgreSqlMetadataCache m_DatabaseMetadata;

        /// <summary>
        /// Initializes a new instance of the <see cref="PostgreSqlDataSource"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="settings">The settings.</param>
        /// <exception cref="ArgumentException">connectionString is null or empty.;connectionString</exception>
        public PostgreSqlDataSource(string? name, string connectionString, PostgreSqlDataSourceSettings? settings = null)
            : base(settings)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException($"{nameof(connectionString)} is null or empty.", nameof(connectionString));

            m_ConnectionBuilder = new NpgsqlConnectionStringBuilder(connectionString);
            if (string.IsNullOrEmpty(name))
                Name = m_ConnectionBuilder.Database;
            else
                Name = name;

            m_DatabaseMetadata = new PostgreSqlMetadataCache(m_ConnectionBuilder);
            m_ExtensionCache = new ConcurrentDictionary<Type, object>();
            m_Cache = DefaultCache;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PostgreSqlDataSource"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="settings">The settings.</param>
        public PostgreSqlDataSource(string connectionString, PostgreSqlDataSourceSettings? settings = null)
            : this(null, connectionString, settings)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PostgreSqlDataSource" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="connectionBuilder">The connection builder.</param>
        /// <param name="settings">The settings.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public PostgreSqlDataSource(string? name, NpgsqlConnectionStringBuilder connectionBuilder, PostgreSqlDataSourceSettings? settings = null)
            : base(settings)
        {
            m_ConnectionBuilder = connectionBuilder ?? throw new ArgumentNullException(nameof(connectionBuilder), $"{nameof(connectionBuilder)} is null.");
            if (string.IsNullOrEmpty(name))
                Name = m_ConnectionBuilder.Database;
            else
                Name = name;

            m_DatabaseMetadata = new PostgreSqlMetadataCache(m_ConnectionBuilder);
            m_ExtensionCache = new ConcurrentDictionary<Type, object>();
            m_Cache = DefaultCache;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PostgreSqlDataSource" /> class.
        /// </summary>
        /// <param name="connectionBuilder">The connection builder.</param>
        /// <param name="settings">The settings.</param>
        public PostgreSqlDataSource(NpgsqlConnectionStringBuilder connectionBuilder, PostgreSqlDataSourceSettings? settings = null)
            : this(null, connectionBuilder, settings)
        {
        }

        PostgreSqlDataSource(string? name, NpgsqlConnectionStringBuilder connectionBuilder, PostgreSqlDataSourceSettings settings, PostgreSqlMetadataCache databaseMetadata, ICacheAdapter cache, ConcurrentDictionary<Type, object> extensionCache)
                    : base(settings)
        {
            m_ConnectionBuilder = connectionBuilder ?? throw new ArgumentNullException(nameof(connectionBuilder), $"{nameof(connectionBuilder)} is null.");
            if (string.IsNullOrEmpty(name))
                Name = m_ConnectionBuilder.Database;
            else
                Name = name;

            m_DatabaseMetadata = databaseMetadata;
            m_ExtensionCache = extensionCache;
            m_Cache = cache;
        }

        /// <summary>
        /// Gets or sets the cache to be used by this data source. The default is .NET's System.Runtime.Caching.MemoryCache.
        /// </summary>
        public override ICacheAdapter Cache => m_Cache;

        /// <summary>
        /// Gets the database metadata.
        /// </summary>
        /// <value>The database metadata.</value>
        public override PostgreSqlMetadataCache DatabaseMetadata => m_DatabaseMetadata;

        internal string ConnectionString
        {
            get { return m_ConnectionBuilder.ConnectionString; }
        }

        /// <summary>
        /// The extension cache is used by extensions to store data source specific information.
        /// </summary>
        /// <value>
        /// The extension cache.
        /// </value>
        protected override ConcurrentDictionary<Type, object> ExtensionCache => m_ExtensionCache;

        /// <summary>
        /// Begins the transaction.
        /// </summary>
        /// <param name="isolationLevel">The isolation level.</param>
        /// <param name="forwardEvents">if set to <c>true</c> [forward events].</param>
        /// <returns></returns>
        public PostgreSqlTransactionalDataSource BeginTransaction(IsolationLevel? isolationLevel = null, bool forwardEvents = true)
        {
            return new PostgreSqlTransactionalDataSource(this, isolationLevel, forwardEvents);
        }

        ITransactionalDataSource IRootDataSource.BeginTransaction() => BeginTransaction();

        /// <summary>
        /// Begins the transaction.
        /// </summary>
        /// <param name="isolationLevel">The isolation level.</param>
        /// <param name="forwardEvents">if set to <c>true</c> [forward events].</param>
        /// <returns></returns>
        public async Task<PostgreSqlTransactionalDataSource> BeginTransactionAsync(IsolationLevel? isolationLevel = null, bool forwardEvents = true)
        {
            var connection = await CreateConnectionAsync().ConfigureAwait(false);
            NpgsqlTransaction transaction;
            if (isolationLevel.HasValue)
                transaction = connection.BeginTransaction(isolationLevel.Value);
            else
                transaction = connection.BeginTransaction();
            return new PostgreSqlTransactionalDataSource(this, forwardEvents, connection, transaction);
        }

        async Task<ITransactionalDataSource> IRootDataSource.BeginTransactionAsync() => await BeginTransactionAsync().ConfigureAwait(false);

        /// <summary>
        /// Creates the connection.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// The caller of this method is responsible for closing the connection.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public NpgsqlConnection CreateConnection()
        {
            var con = new NpgsqlConnection(ConnectionString);
            con.Open();

            //TODO: Research server settings.

            return con;
        }

        DbConnection IRootDataSource.CreateConnection() => CreateConnection();

        /// <summary>
        /// Creates the connection asynchronous.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        /// <remarks>
        /// The caller of this method is responsible for closing the connection.
        /// </remarks>
        public async Task<NpgsqlConnection> CreateConnectionAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var con = new NpgsqlConnection(ConnectionString);
            await con.OpenAsync(cancellationToken).ConfigureAwait(false);

            //TODO: Research server settings.

            return con;
        }

        async Task<DbConnection> IRootDataSource.CreateConnectionAsync() => await CreateConnectionAsync().ConfigureAwait(false);

        /// <summary>
        /// Creates an open data source using the supplied connection and optional transaction.
        /// </summary>
        /// <param name="connection">The connection to wrap.</param>
        /// <param name="transaction">The transaction to wrap.</param>
        /// <returns>IOpenDataSource.</returns>
        public PostgreSqlOpenDataSource CreateOpenDataSource(NpgsqlConnection connection, NpgsqlTransaction? transaction = null)
        {
            return new PostgreSqlOpenDataSource(this, connection, transaction);
        }

        IOpenDataSource IRootDataSource.CreateOpenDataSource(DbConnection connection, DbTransaction? transaction)
        {
            return new PostgreSqlOpenDataSource(this, (NpgsqlConnection)connection, (NpgsqlTransaction?)transaction);
        }

        IOpenDataSource IRootDataSource.CreateOpenDataSource(IDbConnection connection, IDbTransaction? transaction)
        {
            return new PostgreSqlOpenDataSource(this, (NpgsqlConnection)connection, (NpgsqlTransaction?)transaction);
        }

        /// <summary>
        /// Tests the connection.
        /// </summary>
        public override void TestConnection()
        {
            using (var con = CreateConnection())
            using (var cmd = new NpgsqlCommand("SELECT 1", con))
                cmd.ExecuteScalar();
        }

        /// <summary>
        /// Tests the connection asynchronously.
        /// </summary>
        /// <returns></returns>
        public override async Task TestConnectionAsync()
        {
            using (var con = await CreateConnectionAsync().ConfigureAwait(false))
            using (var cmd = new NpgsqlCommand("SELECT 1", con))
                await cmd.ExecuteScalarAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Craetes a new data source with the provided cache.
        /// </summary>
        /// <param name="cache">The cache.</param>
        /// <returns></returns>
        public PostgreSqlDataSource WithCache(ICacheAdapter cache)
        {
            var result = WithSettings(null);
            result.m_Cache = cache;
            return result;
        }

        /// <summary>
        /// Creates a new data source with additional audit rules.
        /// </summary>
        /// <param name="additionalRules">The additional rules.</param>
        /// <returns></returns>
        public PostgreSqlDataSource WithRules(params AuditRule[] additionalRules)
        {
            var result = WithSettings(null);
            result.AuditRules = new AuditRuleCollection(AuditRules, additionalRules);
            return result;
        }

        /// <summary>
        /// Creates a new data source with additional audit rules.
        /// </summary>
        /// <param name="additionalRules">The additional rules.</param>
        /// <returns></returns>
        public PostgreSqlDataSource WithRules(IEnumerable<AuditRule> additionalRules)
        {
            var result = WithSettings(null);
            result.AuditRules = new AuditRuleCollection(AuditRules, additionalRules);
            return result;
        }

        /// <summary>
        /// Creates a new data source with the indicated changes to the settings.
        /// </summary>
        /// <param name="settings">The new settings to use.</param>
        /// <returns></returns>
        /// <remarks>The new data source will share the same database metadata cache.</remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        public PostgreSqlDataSource WithSettings(PostgreSqlDataSourceSettings? settings)
        {
            var mergedSettings = new PostgreSqlDataSourceSettings()
            {
                DefaultCommandTimeout = settings?.DefaultCommandTimeout ?? DefaultCommandTimeout,
                SuppressGlobalEvents = settings?.SuppressGlobalEvents ?? SuppressGlobalEvents,
                StrictMode = settings?.StrictMode ?? StrictMode
            };
            var result = new PostgreSqlDataSource(Name, m_ConnectionBuilder, mergedSettings, m_DatabaseMetadata, m_Cache, m_ExtensionCache);
            result.m_DatabaseMetadata = m_DatabaseMetadata;
            result.AuditRules = AuditRules;
            result.UserValue = UserValue;

            result.ExecutionStarted += (sender, e) => OnExecutionStarted(e);
            result.ExecutionFinished += (sender, e) => OnExecutionFinished(e);
            result.ExecutionError += (sender, e) => OnExecutionError(e);
            result.ExecutionCanceled += (sender, e) => OnExecutionCanceled(e);

            return result;
        }

        /// <summary>
        /// Creates a new data source with the indicated user.
        /// </summary>
        /// <param name="userValue">The user value.</param>
        /// <returns></returns>
        /// <remarks>
        /// This is used in conjunction with audit rules.
        /// </remarks>
        public PostgreSqlDataSource WithUser(object userValue)
        {
            var result = WithSettings(null);
            result.UserValue = userValue;
            return result;
        }

        /// <summary>
        /// Executes the specified operation.
        /// </summary>
        /// <param name="executionToken">The execution token.</param>
        /// <param name="implementation">The implementation that handles processing the result of the command.</param>
        /// <param name="state">User supplied state.</param>
        /// <returns>System.Nullable&lt;System.Int32&gt;.</returns>
        /// <exception cref="ArgumentNullException">executionToken;executionToken is null.
        /// or
        /// implementation;implementation is null.</exception>
        protected override int? Execute(CommandExecutionToken<NpgsqlCommand, NpgsqlParameter> executionToken, CommandImplementation<NpgsqlCommand> implementation, object? state)
        {
            if (executionToken == null)
                throw new ArgumentNullException(nameof(executionToken), $"{nameof(executionToken)} is null.");
            if (implementation == null)
                throw new ArgumentNullException(nameof(implementation), $"{nameof(implementation)} is null.");

            var startTime = DateTimeOffset.Now;
            OnExecutionStarted(executionToken, startTime, state);

            try
            {
                using (var con = CreateConnection())
                {
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = con;
                        if (DefaultCommandTimeout.HasValue)
                            cmd.CommandTimeout = (int)DefaultCommandTimeout.Value.TotalSeconds;
                        cmd.CommandText = executionToken.CommandText;
                        cmd.CommandType = executionToken.CommandType;
                        foreach (var param in executionToken.Parameters)
                            cmd.Parameters.Add(param);

                        executionToken.ApplyCommandOverrides(cmd);

                        int? rows;

                        if (((PostgreSqlCommandExecutionToken)executionToken).DereferenceCursors)
                            rows = DereferenceCursors(cmd, implementation);
                        else
                            rows = implementation(cmd);

                        executionToken.RaiseCommandExecuted(cmd, rows);
                        OnExecutionFinished(executionToken, startTime, DateTimeOffset.Now, rows, state);
                        return rows;
                    }
                }
            }
            catch (Exception ex)
            {
                OnExecutionError(executionToken, startTime, DateTimeOffset.Now, ex, state);
                throw;
            }
        }

        /// <summary>
        /// Executes the specified operation.
        /// </summary>
        /// <param name="executionToken">The execution token.</param>
        /// <param name="implementation">The implementation.</param>
        /// <param name="state">The state.</param>
        /// <returns>System.Nullable&lt;System.Int32&gt;.</returns>
        /// <exception cref="ArgumentNullException">
        /// executionToken;executionToken is null.
        /// or
        /// implementation;implementation is null.
        /// </exception>
        protected override int? Execute(OperationExecutionToken<NpgsqlConnection, NpgsqlTransaction> executionToken, OperationImplementation<NpgsqlConnection, NpgsqlTransaction> implementation, object? state)
        {
            if (executionToken == null)
                throw new ArgumentNullException(nameof(executionToken), $"{nameof(executionToken)} is null.");
            if (implementation == null)
                throw new ArgumentNullException(nameof(implementation), $"{nameof(implementation)} is null.");

            var startTime = DateTimeOffset.Now;
            OnExecutionStarted(executionToken, startTime, state);

            try
            {
                using (var con = CreateConnection())
                {
                    var rows = implementation(con, null);
                    OnExecutionFinished(executionToken, startTime, DateTimeOffset.Now, rows, state);
                    return rows;
                }
            }
            catch (Exception ex)
            {
                OnExecutionError(executionToken, startTime, DateTimeOffset.Now, ex, state);
                throw;
            }
        }

        /// <summary>
        /// execute as an asynchronous operation.
        /// </summary>
        /// <param name="executionToken">The execution token.</param>
        /// <param name="implementation">The implementation that handles processing the result of the command.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="state">User supplied state.</param>
        /// <returns>Task.</returns>
        /// <exception cref="ArgumentNullException">
        /// executionToken;executionToken is null.
        /// or
        /// implementation;implementation is null.
        /// </exception>
        protected override async Task<int?> ExecuteAsync(CommandExecutionToken<NpgsqlCommand, NpgsqlParameter> executionToken, CommandImplementationAsync<NpgsqlCommand> implementation, CancellationToken cancellationToken, object? state)
        {
            if (executionToken == null)
                throw new ArgumentNullException(nameof(executionToken), $"{nameof(executionToken)} is null.");
            if (implementation == null)
                throw new ArgumentNullException(nameof(implementation), $"{nameof(implementation)} is null.");

            var startTime = DateTimeOffset.Now;
            OnExecutionStarted(executionToken, startTime, state);

            try
            {
                using (var con = await CreateConnectionAsync(cancellationToken).ConfigureAwait(false))
                {
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = con;
                        if (DefaultCommandTimeout.HasValue)
                            cmd.CommandTimeout = (int)DefaultCommandTimeout.Value.TotalSeconds;
                        cmd.CommandText = executionToken.CommandText;
                        cmd.CommandType = executionToken.CommandType;
                        foreach (var param in executionToken.Parameters)
                            cmd.Parameters.Add(param);

                        executionToken.ApplyCommandOverrides(cmd);

                        int? rows;
                        if (((PostgreSqlCommandExecutionToken)executionToken).DereferenceCursors)
                            rows = await DereferenceCursorsAsync(cmd, implementation).ConfigureAwait(false);
                        else
                            rows = await implementation(cmd).ConfigureAwait(false);

                        executionToken.RaiseCommandExecuted(cmd, rows);
                        OnExecutionFinished(executionToken, startTime, DateTimeOffset.Now, rows, state);
                        return rows;
                    }
                }
            }
            catch (Exception ex)
            {
                if (cancellationToken.IsCancellationRequested) //convert Exception into a OperationCanceledException
                {
                    var ex2 = new OperationCanceledException("Operation was canceled.", ex, cancellationToken);
                    OnExecutionCanceled(executionToken, startTime, DateTimeOffset.Now, state);
                    throw ex2;
                }
                else
                {
                    OnExecutionError(executionToken, startTime, DateTimeOffset.Now, ex, state);
                    throw;
                }
            }
        }

        /// <summary>
        /// execute as an asynchronous operation.
        /// </summary>
        /// <param name="executionToken">The execution token.</param>
        /// <param name="implementation">The implementation.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="state">The state.</param>
        /// <returns>Task.</returns>
        /// <exception cref="ArgumentNullException">
        /// executionToken;executionToken is null.
        /// or
        /// implementation;implementation is null.
        /// </exception>
        protected override async Task<int?> ExecuteAsync(OperationExecutionToken<NpgsqlConnection, NpgsqlTransaction> executionToken, OperationImplementationAsync<NpgsqlConnection, NpgsqlTransaction> implementation, CancellationToken cancellationToken, object? state)
        {
            if (executionToken == null)
                throw new ArgumentNullException(nameof(executionToken), $"{nameof(executionToken)} is null.");
            if (implementation == null)
                throw new ArgumentNullException(nameof(implementation), $"{nameof(implementation)} is null.");

            var startTime = DateTimeOffset.Now;
            OnExecutionStarted(executionToken, startTime, state);

            try
            {
                using (var con = CreateConnection())
                {
                    var rows = await implementation(con, null, cancellationToken).ConfigureAwait(false);
                    OnExecutionFinished(executionToken, startTime, DateTimeOffset.Now, rows, state);
                    return rows;
                }
            }
            catch (Exception ex)
            {
                if (cancellationToken.IsCancellationRequested) //convert Exception into a OperationCanceledException
                {
                    var ex2 = new OperationCanceledException("Operation was canceled.", ex, cancellationToken);
                    OnExecutionCanceled(executionToken, startTime, DateTimeOffset.Now, state);
                    throw ex2;
                }
                else
                {
                    OnExecutionError(executionToken, startTime, DateTimeOffset.Now, ex, state);
                    throw;
                }
            }
        }
    }
}
