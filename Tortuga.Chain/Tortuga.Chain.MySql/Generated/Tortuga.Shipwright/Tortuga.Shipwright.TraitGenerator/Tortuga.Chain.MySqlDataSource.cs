﻿//This file was generated by Tortuga Shipwright

namespace Tortuga.Chain
{
	partial class MySqlDataSource: Tortuga.Chain.DataSources.IRootDataSource
	{

		private bool __TraitsRegistered;

		// These fields and/or properties hold the traits. They should not be referenced directly.
		private Traits.RootDataSourceTrait<Tortuga.Chain.MySqlDataSource, Tortuga.Chain.MySql.MySqlTransactionalDataSource, Tortuga.Chain.MySql.MySqlOpenDataSource, MySqlConnector.MySqlConnection, MySqlConnector.MySqlTransaction, MySqlConnector.MySqlCommand, MySqlConnector.MySqlConnectionStringBuilder> ___Trait0 = new();
		private Traits.RootDataSourceTrait<Tortuga.Chain.MySqlDataSource, Tortuga.Chain.MySql.MySqlTransactionalDataSource, Tortuga.Chain.MySql.MySqlOpenDataSource, MySqlConnector.MySqlConnection, MySqlConnector.MySqlTransaction, MySqlConnector.MySqlCommand, MySqlConnector.MySqlConnectionStringBuilder> __Trait0
		{
			get
			{
				if (!__TraitsRegistered) __RegisterTraits();
				return ___Trait0;
			}
		}

		// Explicit interface implementation Tortuga.Chain.DataSources.IRootDataSource
		Tortuga.Chain.DataSources.ITransactionalDataSource Tortuga.Chain.DataSources.IRootDataSource.BeginTransaction()
		{
			return ((Tortuga.Chain.DataSources.IRootDataSource)__Trait0).BeginTransaction();
		}

		System.Threading.Tasks.Task<Tortuga.Chain.DataSources.ITransactionalDataSource> Tortuga.Chain.DataSources.IRootDataSource.BeginTransactionAsync()
		{
			return ((Tortuga.Chain.DataSources.IRootDataSource)__Trait0).BeginTransactionAsync();
		}

		System.Data.Common.DbConnection Tortuga.Chain.DataSources.IRootDataSource.CreateConnection()
		{
			return ((Tortuga.Chain.DataSources.IRootDataSource)__Trait0).CreateConnection();
		}

		System.Threading.Tasks.Task<System.Data.Common.DbConnection> Tortuga.Chain.DataSources.IRootDataSource.CreateConnectionAsync()
		{
			return ((Tortuga.Chain.DataSources.IRootDataSource)__Trait0).CreateConnectionAsync();
		}

		Tortuga.Chain.DataSources.IOpenDataSource Tortuga.Chain.DataSources.IRootDataSource.CreateOpenDataSource()
		{
			return ((Tortuga.Chain.DataSources.IRootDataSource)__Trait0).CreateOpenDataSource();
		}

		Tortuga.Chain.DataSources.IOpenDataSource Tortuga.Chain.DataSources.IRootDataSource.CreateOpenDataSource(System.Data.Common.DbConnection connection, System.Data.Common.DbTransaction? transaction)
		{
			return ((Tortuga.Chain.DataSources.IRootDataSource)__Trait0).CreateOpenDataSource(connection, transaction);
		}

		Tortuga.Chain.DataSources.IOpenDataSource Tortuga.Chain.DataSources.IRootDataSource.CreateOpenDataSource(System.Data.IDbConnection connection, System.Data.IDbTransaction? transaction)
		{
			return ((Tortuga.Chain.DataSources.IRootDataSource)__Trait0).CreateOpenDataSource(connection, transaction);
		}

		// Exposing trait Traits.RootDataSourceTrait<Tortuga.Chain.MySqlDataSource, Tortuga.Chain.MySql.MySqlTransactionalDataSource, Tortuga.Chain.MySql.MySqlOpenDataSource, MySqlConnector.MySqlConnection, MySqlConnector.MySqlTransaction, MySqlConnector.MySqlCommand, MySqlConnector.MySqlConnectionStringBuilder>

		/// <summary>
		/// Creates a new transaction.
		/// </summary>
		/// <returns></returns>
		/// <remarks>The caller of this method is responsible for closing the transaction.</remarks>
		public Tortuga.Chain.MySql.MySqlTransactionalDataSource BeginTransaction()
		{
			return __Trait0.BeginTransaction();
		}

		/// <summary>
		/// Creates a new transaction.
		/// </summary>
		/// <param name="isolationLevel"></param>
		/// <param name="forwardEvents"></param>
		/// <returns></returns>
		/// <remarks>The caller of this method is responsible for closing the transaction.</remarks>
		public Tortuga.Chain.MySql.MySqlTransactionalDataSource BeginTransaction(System.Nullable<System.Data.IsolationLevel> isolationLevel = default, System.Boolean forwardEvents = true)
		{
			return __Trait0.BeginTransaction(isolationLevel, forwardEvents);
		}

		/// <summary>
		/// Creates a new transaction.
		/// </summary>
		/// <param name="isolationLevel"></param>
		/// <param name="forwardEvents"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		/// <remarks>The caller of this method is responsible for closing the transaction.</remarks>
		public System.Threading.Tasks.Task<Tortuga.Chain.MySql.MySqlTransactionalDataSource> BeginTransactionAsync(System.Nullable<System.Data.IsolationLevel> isolationLevel = default, System.Boolean forwardEvents = true, System.Threading.CancellationToken cancellationToken = default)
		{
			return __Trait0.BeginTransactionAsync(isolationLevel, forwardEvents, cancellationToken);
		}

		/// <summary>
		/// Creates a new transaction.
		/// </summary>
		/// <returns></returns>
		/// <remarks>The caller of this method is responsible for closing the transaction.</remarks>
		public System.Threading.Tasks.Task<Tortuga.Chain.MySql.MySqlTransactionalDataSource> BeginTransactionAsync()
		{
			return __Trait0.BeginTransactionAsync();
		}

		/// <summary>
		/// Gets or sets the cache to be used by this data source. The default is .NET's System.Runtime.Caching.MemoryCache.
		/// </summary>
		public  override  Tortuga.Chain.Core.ICacheAdapter Cache
		{
			get => __Trait0.Cache;
		}
		/// <summary>
		/// The composed connection string.
		/// </summary>
		/// <remarks>This is created and cached by a ConnectionStringBuilder.</remarks>
		internal   System.String ConnectionString
		{
			get => __Trait0.ConnectionString;
		}
		/// <summary>
		/// Creates and opens a new Access connection
		/// </summary>
		/// <returns></returns>
		/// <remarks>The caller of this method is responsible for closing the connection.</remarks>
		public MySqlConnector.MySqlConnection CreateConnection()
		{
			return __Trait0.CreateConnection();
		}

		/// <summary>
		/// Creates the connection asynchronous.
		/// </summary>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <returns></returns>
		/// <remarks>
		/// The caller of this method is responsible for closing the connection.
		/// </remarks>
		public System.Threading.Tasks.Task<MySqlConnector.MySqlConnection> CreateConnectionAsync(System.Threading.CancellationToken cancellationToken = default)
		{
			return __Trait0.CreateConnectionAsync(cancellationToken);
		}

		/// <summary>
		/// Creates an open data source using the supplied connection and optional transaction.
		/// </summary>
		/// <param name="connection">The connection to wrap.</param>
		/// <param name="transaction">The transaction to wrap.</param>
		/// <returns>IOpenDataSource.</returns>
		/// <remarks>WARNING: The caller of this method is responsible for closing the connection.</remarks>
		public Tortuga.Chain.MySql.MySqlOpenDataSource CreateOpenDataSource(MySqlConnector.MySqlConnection connection, MySqlConnector.MySqlTransaction? transaction = default)
		{
			return __Trait0.CreateOpenDataSource(connection, transaction);
		}

		/// <summary>
		/// Creates an open data source with a new connection.
		/// </summary>
		/// <remarks>WARNING: The caller of this method is responsible for closing the connection.</remarks>
		public Tortuga.Chain.MySql.MySqlOpenDataSource CreateOpenDataSource()
		{
			return __Trait0.CreateOpenDataSource();
		}

		/// <summary>
		/// The extension cache is used by extensions to store data source specific information.
		/// </summary>
		/// <value>
		/// The extension cache.
		/// </value>
		protected  override  System.Collections.Concurrent.ConcurrentDictionary<System.Type, object> ExtensionCache
		{
			get => __Trait0.ExtensionCache;
		}
		
		internal   Tortuga.Chain.Core.ICacheAdapter m_Cache
		{
			get => __Trait0.m_Cache;
			set => __Trait0.m_Cache = value;
		}
		/// <summary>
		/// This object can be used to access the database connection string.
		/// </summary>
		private   MySqlConnector.MySqlConnectionStringBuilder m_ConnectionBuilder
		{
			get => __Trait0.m_ConnectionBuilder;
			init => __Trait0.m_ConnectionBuilder = value;
		}
		
		internal   System.Collections.Concurrent.ConcurrentDictionary<System.Type, object> m_ExtensionCache
		{
			get => __Trait0.m_ExtensionCache;
			set => __Trait0.m_ExtensionCache = value;
		}
		/// <summary>
		/// Tests the connection.
		/// </summary>
		public override void TestConnection()
		{
			__Trait0.TestConnection();
		}

		/// <summary>
		/// Tests the connection asynchronously.
		/// </summary>
		/// <returns></returns>
		public override System.Threading.Tasks.Task TestConnectionAsync()
		{
			return __Trait0.TestConnectionAsync();
		}

		/// <summary>
		/// Creates a new data source with the provided cache.
		/// </summary>
		/// <param name="cache">The cache.</param>
		/// <returns></returns>
		public Tortuga.Chain.MySqlDataSource WithCache(Tortuga.Chain.Core.ICacheAdapter cache)
		{
			return __Trait0.WithCache(cache);
		}

		/// <summary>
		/// Creates a new data source with additional audit rules.
		/// </summary>
		/// <param name="additionalRules">The additional rules.</param>
		/// <returns></returns>
		public Tortuga.Chain.MySqlDataSource WithRules(params Tortuga.Chain.AuditRules.AuditRule[] additionalRules)
		{
			return __Trait0.WithRules(additionalRules);
		}

		/// <summary>
		/// Creates a new data source with additional audit rules.
		/// </summary>
		/// <param name="additionalRules">The additional rules.</param>
		/// <returns></returns>
		public Tortuga.Chain.MySqlDataSource WithRules(System.Collections.Generic.IEnumerable<Tortuga.Chain.AuditRules.AuditRule> additionalRules)
		{
			return __Trait0.WithRules(additionalRules);
		}

		/// <summary>
		/// Creates a new data source with the indicated user.
		/// </summary>
		/// <param name="userValue">The user value.</param>
		/// <returns></returns>
		/// <remarks>
		/// This is used in conjunction with audit rules.
		/// </remarks>
		public Tortuga.Chain.MySqlDataSource WithUser(System.Object? userValue)
		{
			return __Trait0.WithUser(userValue);
		}

		private partial Tortuga.Chain.MySql.MySqlTransactionalDataSource OnBeginTransaction(System.Nullable<System.Data.IsolationLevel> isolationLevel, System.Boolean forwardEvents );

		private partial System.Threading.Tasks.Task<Tortuga.Chain.MySql.MySqlTransactionalDataSource> OnBeginTransactionAsync(System.Nullable<System.Data.IsolationLevel> isolationLevel, System.Boolean forwardEvents, System.Threading.CancellationToken cancellationToken );

		private partial Tortuga.Chain.MySqlDataSource OnCloneWithOverrides(Tortuga.Chain.Core.ICacheAdapter? cache, System.Collections.Generic.IEnumerable<Tortuga.Chain.AuditRules.AuditRule>? additionalRules, System.Object? userValue );

		private partial MySqlConnector.MySqlConnection OnCreateConnection( );

		private partial System.Threading.Tasks.Task<MySqlConnector.MySqlConnection> OnCreateConnectionAsync(System.Threading.CancellationToken cancellationToken );

		private partial Tortuga.Chain.MySql.MySqlOpenDataSource OnCreateOpenDataSource(MySqlConnector.MySqlConnection connection, MySqlConnector.MySqlTransaction? transaction );

		private void __RegisterTraits()
		{
			__TraitsRegistered = true;
			__Trait0.OnBeginTransaction = OnBeginTransaction;
			__Trait0.OnBeginTransactionAsync = OnBeginTransactionAsync;
			__Trait0.OnCreateConnection = OnCreateConnection;
			__Trait0.OnCreateConnectionAsync = OnCreateConnectionAsync;
			__Trait0.OnCreateOpenDataSource = OnCreateOpenDataSource;
			__Trait0.OnCloneWithOverrides = OnCloneWithOverrides;
		}

	}
}
