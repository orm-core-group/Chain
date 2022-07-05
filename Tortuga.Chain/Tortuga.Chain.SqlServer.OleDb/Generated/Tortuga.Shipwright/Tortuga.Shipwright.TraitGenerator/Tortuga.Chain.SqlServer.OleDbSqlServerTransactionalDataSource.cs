﻿//This file was generated by Tortuga Shipwright

namespace Tortuga.Chain.SqlServer
{
	partial class OleDbSqlServerTransactionalDataSource: Tortuga.Chain.DataSources.ITransactionalDataSource, Tortuga.Chain.DataSources.IOpenDataSource, System.IDisposable
	{

		private bool __TraitsRegistered;

		// These fields and/or properties hold the traits. They should not be referenced directly.
		private Traits.TransactionalDataSourceTrait<Tortuga.Chain.OleDbSqlServerDataSource, System.Data.OleDb.OleDbConnection, System.Data.OleDb.OleDbTransaction, System.Data.OleDb.OleDbCommand, Tortuga.Chain.SqlServer.OleDbSqlServerMetadataCache> ___Trait0 = new();
		private Traits.TransactionalDataSourceTrait<Tortuga.Chain.OleDbSqlServerDataSource, System.Data.OleDb.OleDbConnection, System.Data.OleDb.OleDbTransaction, System.Data.OleDb.OleDbCommand, Tortuga.Chain.SqlServer.OleDbSqlServerMetadataCache> __Trait0
		{
			get
			{
				if (!__TraitsRegistered) __RegisterTraits();
				return ___Trait0;
			}
		}

		// Explicit interface implementation System.IDisposable
		void System.IDisposable.Dispose()
		{
			((System.IDisposable)__Trait0).Dispose();
		}

		// Explicit interface implementation Tortuga.Chain.DataSources.IOpenDataSource
		System.Data.Common.DbConnection Tortuga.Chain.DataSources.IOpenDataSource.AssociatedConnection
		{
			get => ((Tortuga.Chain.DataSources.IOpenDataSource)__Trait0).AssociatedConnection;
		}
		System.Data.Common.DbTransaction? Tortuga.Chain.DataSources.IOpenDataSource.AssociatedTransaction
		{
			get => ((Tortuga.Chain.DataSources.IOpenDataSource)__Trait0).AssociatedTransaction;
		}
		void Tortuga.Chain.DataSources.IOpenDataSource.Close()
		{
			((Tortuga.Chain.DataSources.IOpenDataSource)__Trait0).Close();
		}

		System.Boolean Tortuga.Chain.DataSources.IOpenDataSource.TryCommit()
		{
			return ((Tortuga.Chain.DataSources.IOpenDataSource)__Trait0).TryCommit();
		}

		System.Boolean Tortuga.Chain.DataSources.IOpenDataSource.TryRollback()
		{
			return ((Tortuga.Chain.DataSources.IOpenDataSource)__Trait0).TryRollback();
		}

		// Explicit interface implementation Tortuga.Chain.DataSources.ITransactionalDataSource
		void Tortuga.Chain.DataSources.ITransactionalDataSource.Commit()
		{
			((Tortuga.Chain.DataSources.ITransactionalDataSource)__Trait0).Commit();
		}

		// Exposing trait Traits.TransactionalDataSourceTrait<Tortuga.Chain.OleDbSqlServerDataSource, System.Data.OleDb.OleDbConnection, System.Data.OleDb.OleDbTransaction, System.Data.OleDb.OleDbCommand, Tortuga.Chain.SqlServer.OleDbSqlServerMetadataCache>

		/// <summary>
		/// Returns the associated connection.
		/// </summary>
		/// <value>The associated connection.</value>
		public   System.Data.OleDb.OleDbConnection AssociatedConnection
		{
			get => __Trait0.AssociatedConnection;
		}
		/// <summary>
		/// Returns the associated transaction.
		/// </summary>
		/// <value>The associated transaction.</value>
		public   System.Data.OleDb.OleDbTransaction AssociatedTransaction
		{
			get => __Trait0.AssociatedTransaction;
		}
		/// <summary>
		/// Gets or sets the cache to be used by this data source. The default is .NET's System.Runtime.Caching.MemoryCache.
		/// </summary>
		public  override  Tortuga.Chain.Core.ICacheAdapter Cache
		{
			get => __Trait0.Cache;
		}
		/// <summary>
		/// Commits the transaction and disposes the underlying connection.
		/// </summary>
		public void Commit()
		{
			__Trait0.Commit();
		}

		/// <summary>
		/// Commits the transaction and disposes the underlying connection.
		/// </summary>
		public System.Threading.Tasks.Task CommitAsync(System.Threading.CancellationToken cancellationToken = default)
		{
			return __Trait0.CommitAsync(cancellationToken);
		}

		/// <summary>
		/// Gets the database metadata.
		/// </summary>
		public  override  Tortuga.Chain.SqlServer.OleDbSqlServerMetadataCache DatabaseMetadata
		{
			get => __Trait0.DatabaseMetadata;
		}
		/// <summary>
		/// Closes the current transaction and connection. If not committed, the transaction is rolled back.
		/// </summary>
		public void Dispose()
		{
			__Trait0.Dispose();
		}

		/// <summary>
		/// Closes the current transaction and connection. If not committed, the transaction is rolled back.
		/// </summary>
		/// <param name="disposing"></param>
		protected virtual void Dispose(System.Boolean disposing)
		{
			__Trait0.Dispose(disposing);
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
		
		private   Tortuga.Chain.OleDbSqlServerDataSource m_BaseDataSource
		{
			get => __Trait0.m_BaseDataSource;
			init => __Trait0.m_BaseDataSource = value;
		}
		
		private   System.Data.OleDb.OleDbConnection m_Connection
		{
			get => __Trait0.m_Connection;
			init => __Trait0.m_Connection = value;
		}
		
		private   System.Boolean m_Disposed
		{
			get => __Trait0.m_Disposed;
			set => __Trait0.m_Disposed = value;
		}
		
		private   System.Data.OleDb.OleDbTransaction m_Transaction
		{
			get => __Trait0.m_Transaction;
			init => __Trait0.m_Transaction = value;
		}
		/// <summary>
		/// Rolls back the transaction to the indicated save point.
		/// </summary>
		/// <param name="savepointName">The name of the savepoint to roll back to.</param>
		public void Rollback(System.String savepointName)
		{
			__Trait0.Rollback(savepointName);
		}

		/// <summary>
		/// Rolls back the transaction and disposes the underlying connection.
		/// </summary>
		public void Rollback()
		{
			__Trait0.Rollback();
		}

		/// <summary>
		/// Rolls back the transaction and disposes the underlying connection.
		/// </summary>
		public System.Threading.Tasks.Task RollbackAsync(System.Threading.CancellationToken cancellationToken = default)
		{
			return __Trait0.RollbackAsync(cancellationToken);
		}

		/// <summary>
		/// Rolls back the transaction to the indicated save point.
		/// </summary>
		/// <param name="savepointName">The name of the savepoint to roll back to.</param>
		/// <param name="cancellationToken"></param>
		public System.Threading.Tasks.Task RollbackAsync(System.String savepointName, System.Threading.CancellationToken cancellationToken = default)
		{
			return __Trait0.RollbackAsync(savepointName, cancellationToken);
		}

		/// <summary>
		/// Creates a savepoint in the transaction. This allows all commands that are executed after the savepoint was established to be rolled back, restoring the transaction state to what it was at the time of the savepoint.
		/// </summary>
		/// <param name="savepointName">The name of the savepoint to be created.</param>
		public void Save(System.String savepointName)
		{
			__Trait0.Save(savepointName);
		}

		/// <summary>
		/// Creates a savepoint in the transaction. This allows all commands that are executed after the savepoint was established to be rolled back, restoring the transaction state to what it was at the time of the savepoint.
		/// </summary>
		/// <param name="savepointName">The name of the savepoint to be created.</param>
		/// <param name="cancellationToken"></param>
		public System.Threading.Tasks.Task SaveAsync(System.String savepointName, System.Threading.CancellationToken cancellationToken = default)
		{
			return __Trait0.SaveAsync(savepointName, cancellationToken);
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

		private void __RegisterTraits()
		{
			__TraitsRegistered = true;
			__Trait0.Container = this;
			__Trait0.DisposableContainer = this as Traits.IHasOnDispose;
		}

	}
}
