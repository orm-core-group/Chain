﻿//This file was generated by Tortuga Shipwright

namespace Tortuga.Chain.SqlServer
{
	partial class SqlServerDataSourceBase: Tortuga.Chain.DataSources.ISupportsDeleteAll, Tortuga.Chain.DataSources.ISupportsTruncate, Tortuga.Chain.DataSources.ISupportsSqlQueries, Tortuga.Chain.DataSources.ISupportsInsertBatch, Tortuga.Chain.DataSources.ISupportsDeleteByKeyList, Tortuga.Chain.DataSources.ISupportsDeleteByKey, Tortuga.Chain.DataSources.ISupportsDelete, Tortuga.Chain.DataSources.ISupportsUpdate, Traits.ICommandHelper<Tortuga.Chain.SqlServer.SqlServerObjectName, System.Data.SqlDbType>, Traits.IInsertBatchHelper<Microsoft.Data.SqlClient.SqlCommand, Microsoft.Data.SqlClient.SqlParameter, Tortuga.Chain.SqlServer.SqlServerObjectName, System.Data.SqlDbType>, Traits.IDeleteByKeyHelper<Microsoft.Data.SqlClient.SqlCommand, Microsoft.Data.SqlClient.SqlParameter, Tortuga.Chain.SqlServer.SqlServerObjectName, System.Data.SqlDbType>, Traits.IUpdateDeleteHelper<Microsoft.Data.SqlClient.SqlCommand, Microsoft.Data.SqlClient.SqlParameter, Tortuga.Chain.SqlServer.SqlServerObjectName, System.Data.SqlDbType>
	{

		private bool __TraitsRegistered;

		// These fields and/or properties hold the traits. They should not be referenced directly.
		private Traits.SupportsDeleteAllTrait<Tortuga.Chain.SqlServer.SqlServerObjectName, System.Data.SqlDbType> ___Trait0 = new();
		private Traits.SupportsDeleteAllTrait<Tortuga.Chain.SqlServer.SqlServerObjectName, System.Data.SqlDbType> __Trait0
		{
			get
			{
				if (!__TraitsRegistered) __RegisterTraits();
				return ___Trait0;
			}
		}
		private Traits.SupportsTruncateTrait<Tortuga.Chain.SqlServer.SqlServerObjectName, System.Data.SqlDbType> ___Trait1 = new();
		private Traits.SupportsTruncateTrait<Tortuga.Chain.SqlServer.SqlServerObjectName, System.Data.SqlDbType> __Trait1
		{
			get
			{
				if (!__TraitsRegistered) __RegisterTraits();
				return ___Trait1;
			}
		}
		private Traits.SupportsSqlQueriesTrait<Microsoft.Data.SqlClient.SqlCommand, Microsoft.Data.SqlClient.SqlParameter> ___Trait2 = new();
		private Traits.SupportsSqlQueriesTrait<Microsoft.Data.SqlClient.SqlCommand, Microsoft.Data.SqlClient.SqlParameter> __Trait2
		{
			get
			{
				if (!__TraitsRegistered) __RegisterTraits();
				return ___Trait2;
			}
		}
		private Traits.SupportsInsertBatchTrait<Microsoft.Data.SqlClient.SqlCommand, Microsoft.Data.SqlClient.SqlParameter, Tortuga.Chain.SqlServer.SqlServerObjectName, System.Data.SqlDbType, Tortuga.Chain.CommandBuilders.MultipleRowDbCommandBuilder<Microsoft.Data.SqlClient.SqlCommand, Microsoft.Data.SqlClient.SqlParameter>> ___Trait3 = new();
		private Traits.SupportsInsertBatchTrait<Microsoft.Data.SqlClient.SqlCommand, Microsoft.Data.SqlClient.SqlParameter, Tortuga.Chain.SqlServer.SqlServerObjectName, System.Data.SqlDbType, Tortuga.Chain.CommandBuilders.MultipleRowDbCommandBuilder<Microsoft.Data.SqlClient.SqlCommand, Microsoft.Data.SqlClient.SqlParameter>> __Trait3
		{
			get
			{
				if (!__TraitsRegistered) __RegisterTraits();
				return ___Trait3;
			}
		}
		private Traits.SupportsDeleteByKeyListTrait<Microsoft.Data.SqlClient.SqlCommand, Microsoft.Data.SqlClient.SqlParameter, Tortuga.Chain.SqlServer.SqlServerObjectName, System.Data.SqlDbType> ___Trait4 = new();
		private Traits.SupportsDeleteByKeyListTrait<Microsoft.Data.SqlClient.SqlCommand, Microsoft.Data.SqlClient.SqlParameter, Tortuga.Chain.SqlServer.SqlServerObjectName, System.Data.SqlDbType> __Trait4
		{
			get
			{
				if (!__TraitsRegistered) __RegisterTraits();
				return ___Trait4;
			}
		}
		private Traits.SupportsDeleteTrait<Microsoft.Data.SqlClient.SqlCommand, Microsoft.Data.SqlClient.SqlParameter, Tortuga.Chain.SqlServer.SqlServerObjectName, System.Data.SqlDbType> ___Trait5 = new();
		private Traits.SupportsDeleteTrait<Microsoft.Data.SqlClient.SqlCommand, Microsoft.Data.SqlClient.SqlParameter, Tortuga.Chain.SqlServer.SqlServerObjectName, System.Data.SqlDbType> __Trait5
		{
			get
			{
				if (!__TraitsRegistered) __RegisterTraits();
				return ___Trait5;
			}
		}
		private Traits.SupportsUpdateTrait<Microsoft.Data.SqlClient.SqlCommand, Microsoft.Data.SqlClient.SqlParameter, Tortuga.Chain.SqlServer.SqlServerObjectName, System.Data.SqlDbType> ___Trait6 = new();
		private Traits.SupportsUpdateTrait<Microsoft.Data.SqlClient.SqlCommand, Microsoft.Data.SqlClient.SqlParameter, Tortuga.Chain.SqlServer.SqlServerObjectName, System.Data.SqlDbType> __Trait6
		{
			get
			{
				if (!__TraitsRegistered) __RegisterTraits();
				return ___Trait6;
			}
		}

		// Explicit interface implementation Tortuga.Chain.DataSources.ISupportsDelete
		Tortuga.Chain.CommandBuilders.IObjectDbCommandBuilder<TArgument> Tortuga.Chain.DataSources.ISupportsDelete.Delete<TArgument>(System.String tableName, TArgument argumentValue, Tortuga.Chain.DeleteOptions options)
		{
			return ((Tortuga.Chain.DataSources.ISupportsDelete)__Trait5).Delete<TArgument>(tableName, argumentValue, options);
		}

		Tortuga.Chain.CommandBuilders.IObjectDbCommandBuilder<TArgument> Tortuga.Chain.DataSources.ISupportsDelete.Delete<TArgument>(TArgument argumentValue, Tortuga.Chain.DeleteOptions options)
		{
			return ((Tortuga.Chain.DataSources.ISupportsDelete)__Trait5).Delete<TArgument>(argumentValue, options);
		}

		// Explicit interface implementation Tortuga.Chain.DataSources.ISupportsDeleteAll
		Tortuga.Chain.ILink<int?> Tortuga.Chain.DataSources.ISupportsDeleteAll.DeleteAll(System.String tableName)
		{
			return ((Tortuga.Chain.DataSources.ISupportsDeleteAll)__Trait0).DeleteAll(tableName);
		}

		Tortuga.Chain.ILink<int?> Tortuga.Chain.DataSources.ISupportsDeleteAll.DeleteAll<TObject>()
		{
			return ((Tortuga.Chain.DataSources.ISupportsDeleteAll)__Trait0).DeleteAll<TObject>();
		}

		// Explicit interface implementation Tortuga.Chain.DataSources.ISupportsDeleteByKey
		Tortuga.Chain.CommandBuilders.ISingleRowDbCommandBuilder Tortuga.Chain.DataSources.ISupportsDeleteByKey.DeleteByKey<TKey>(System.String tableName, TKey key, Tortuga.Chain.DeleteOptions options)
		{
			return ((Tortuga.Chain.DataSources.ISupportsDeleteByKey)__Trait4).DeleteByKey<TKey>(tableName, key, options);
		}

		Tortuga.Chain.CommandBuilders.ISingleRowDbCommandBuilder Tortuga.Chain.DataSources.ISupportsDeleteByKey.DeleteByKey(System.String tableName, System.String key, Tortuga.Chain.DeleteOptions options)
		{
			return ((Tortuga.Chain.DataSources.ISupportsDeleteByKey)__Trait4).DeleteByKey(tableName, key, options);
		}

		// Explicit interface implementation Tortuga.Chain.DataSources.ISupportsDeleteByKeyList
		Tortuga.Chain.CommandBuilders.IMultipleRowDbCommandBuilder Tortuga.Chain.DataSources.ISupportsDeleteByKeyList.DeleteByKeyList<TKey>(System.String tableName, System.Collections.Generic.IEnumerable<TKey> keys, Tortuga.Chain.DeleteOptions options)
		{
			return ((Tortuga.Chain.DataSources.ISupportsDeleteByKeyList)__Trait4).DeleteByKeyList<TKey>(tableName, keys, options);
		}

		// Explicit interface implementation Tortuga.Chain.DataSources.ISupportsInsertBatch
		Tortuga.Chain.CommandBuilders.IDbCommandBuilder Tortuga.Chain.DataSources.ISupportsInsertBatch.InsertBatch<TObject>(System.Collections.Generic.IEnumerable<TObject> objects, Tortuga.Chain.InsertOptions options)
		{
			return ((Tortuga.Chain.DataSources.ISupportsInsertBatch)__Trait3).InsertBatch<TObject>(objects, options);
		}

		Tortuga.Chain.ILink<int> Tortuga.Chain.DataSources.ISupportsInsertBatch.InsertMultipleBatch<TObject>(System.String tableName, System.Collections.Generic.IReadOnlyList<TObject> objects, Tortuga.Chain.InsertOptions options)
		{
			return ((Tortuga.Chain.DataSources.ISupportsInsertBatch)__Trait3).InsertMultipleBatch<TObject>(tableName, objects, options);
		}

		Tortuga.Chain.ILink<int> Tortuga.Chain.DataSources.ISupportsInsertBatch.InsertMultipleBatch<TObject>(System.Collections.Generic.IReadOnlyList<TObject> objects, Tortuga.Chain.InsertOptions options)
		{
			return ((Tortuga.Chain.DataSources.ISupportsInsertBatch)__Trait3).InsertMultipleBatch<TObject>(objects, options);
		}

		// Explicit interface implementation Tortuga.Chain.DataSources.ISupportsSqlQueries
		Tortuga.Chain.CommandBuilders.IMultipleTableDbCommandBuilder Tortuga.Chain.DataSources.ISupportsSqlQueries.Sql(System.String sqlStatement, System.Object argumentValue)
		{
			return ((Tortuga.Chain.DataSources.ISupportsSqlQueries)__Trait2).Sql(sqlStatement, argumentValue);
		}

		// Explicit interface implementation Tortuga.Chain.DataSources.ISupportsTruncate
		Tortuga.Chain.ILink<int?> Tortuga.Chain.DataSources.ISupportsTruncate.Truncate(System.String tableName)
		{
			return ((Tortuga.Chain.DataSources.ISupportsTruncate)__Trait1).Truncate(tableName);
		}

		Tortuga.Chain.ILink<int?> Tortuga.Chain.DataSources.ISupportsTruncate.Truncate<TObject>()
		{
			return ((Tortuga.Chain.DataSources.ISupportsTruncate)__Trait1).Truncate<TObject>();
		}

		// Explicit interface implementation Tortuga.Chain.DataSources.ISupportsUpdate
		Tortuga.Chain.CommandBuilders.IObjectDbCommandBuilder<TArgument> Tortuga.Chain.DataSources.ISupportsUpdate.Update<TArgument>(System.String tableName, TArgument argumentValue, Tortuga.Chain.UpdateOptions options)
		{
			return ((Tortuga.Chain.DataSources.ISupportsUpdate)__Trait6).Update<TArgument>(tableName, argumentValue, options);
		}

		Tortuga.Chain.CommandBuilders.IObjectDbCommandBuilder<TArgument> Tortuga.Chain.DataSources.ISupportsUpdate.Update<TArgument>(TArgument argumentValue, Tortuga.Chain.UpdateOptions options)
		{
			return ((Tortuga.Chain.DataSources.ISupportsUpdate)__Trait6).Update<TArgument>(argumentValue, options);
		}

		// Exposing trait Traits.SupportsDeleteAllTrait<Tortuga.Chain.SqlServer.SqlServerObjectName, System.Data.SqlDbType>

		/// <summary>Deletes all records in the specified table.</summary>
		/// <param name="tableName">Name of the table to clear.</param>
		/// <returns>The number of rows deleted or null if the database doesn't provide that information.</returns>
		public Tortuga.Chain.ILink<int?> DeleteAll(Tortuga.Chain.SqlServer.SqlServerObjectName tableName)
		{
			return __Trait0.DeleteAll(tableName);
		}

		/// <summary>Deletes all records in the specified table.</summary>
		/// <typeparam name="TObject">This class used to determine which table to clear</typeparam>
		/// <returns>The number of rows deleted or null if the database doesn't provide that information.</returns>
		public Tortuga.Chain.ILink<int?> DeleteAll<TObject>()where TObject : class
		{
			return __Trait0.DeleteAll<TObject>();
		}

		// Exposing trait Traits.SupportsDeleteByKeyListTrait<Microsoft.Data.SqlClient.SqlCommand, Microsoft.Data.SqlClient.SqlParameter, Tortuga.Chain.SqlServer.SqlServerObjectName, System.Data.SqlDbType>

		/// <summary>
		/// Delete a record by its primary key.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="tableName">Name of the table.</param>
		/// <param name="key">The key.</param>
		/// <param name="options">The options.</param>
		/// <returns>MultipleRowDbCommandBuilder&lt;TCommand, TParameter&gt;.</returns>
		public Tortuga.Chain.CommandBuilders.SingleRowDbCommandBuilder<Microsoft.Data.SqlClient.SqlCommand, Microsoft.Data.SqlClient.SqlParameter> DeleteByKey<T>(Tortuga.Chain.SqlServer.SqlServerObjectName tableName, T key, Tortuga.Chain.DeleteOptions options = 0)where T : struct
		{
			return __Trait4.DeleteByKey<T>(tableName, key, options);
		}

		/// <summary>
		/// Delete a record by its primary key.
		/// </summary>
		/// <param name="tableName">Name of the table.</param>
		/// <param name="key">The key.</param>
		/// <param name="options">The options.</param>
		public Tortuga.Chain.CommandBuilders.SingleRowDbCommandBuilder<Microsoft.Data.SqlClient.SqlCommand, Microsoft.Data.SqlClient.SqlParameter> DeleteByKey(Tortuga.Chain.SqlServer.SqlServerObjectName tableName, System.String key, Tortuga.Chain.DeleteOptions options = 0)
		{
			return __Trait4.DeleteByKey(tableName, key, options);
		}

		/// <summary>
		/// Delete a record by its primary key.
		/// </summary>
		/// <typeparam name="TObject">Used to determine the table name</typeparam>
		/// <param name="key">The key.</param>
		/// <param name="options">The options.</param>
		public Tortuga.Chain.CommandBuilders.SingleRowDbCommandBuilder<Microsoft.Data.SqlClient.SqlCommand, Microsoft.Data.SqlClient.SqlParameter> DeleteByKey<TObject>(System.Guid key, Tortuga.Chain.DeleteOptions options = 0)where TObject : class
		{
			return __Trait4.DeleteByKey<TObject>(key, options);
		}

		/// <summary>
		/// Delete a record by its primary key.
		/// </summary>
		/// <typeparam name="TObject">Used to determine the table name</typeparam>
		/// <param name="key">The key.</param>
		/// <param name="options">The options.</param>
		public Tortuga.Chain.CommandBuilders.SingleRowDbCommandBuilder<Microsoft.Data.SqlClient.SqlCommand, Microsoft.Data.SqlClient.SqlParameter> DeleteByKey<TObject>(System.Int64 key, Tortuga.Chain.DeleteOptions options = 0)where TObject : class
		{
			return __Trait4.DeleteByKey<TObject>(key, options);
		}

		/// <summary>
		/// Delete a record by its primary key.
		/// </summary>
		/// <typeparam name="TObject">Used to determine the table name</typeparam>
		/// <param name="key">The key.</param>
		/// <param name="options">The options.</param>
		public Tortuga.Chain.CommandBuilders.SingleRowDbCommandBuilder<Microsoft.Data.SqlClient.SqlCommand, Microsoft.Data.SqlClient.SqlParameter> DeleteByKey<TObject>(System.Int32 key, Tortuga.Chain.DeleteOptions options = 0)where TObject : class
		{
			return __Trait4.DeleteByKey<TObject>(key, options);
		}

		/// <summary>
		/// Delete a record by its primary key.
		/// </summary>
		/// <typeparam name="TObject">Used to determine the table name</typeparam>
		/// <param name="key">The key.</param>
		/// <param name="options">The options.</param>
		public Tortuga.Chain.CommandBuilders.SingleRowDbCommandBuilder<Microsoft.Data.SqlClient.SqlCommand, Microsoft.Data.SqlClient.SqlParameter> DeleteByKey<TObject>(System.String key, Tortuga.Chain.DeleteOptions options = 0)where TObject : class
		{
			return __Trait4.DeleteByKey<TObject>(key, options);
		}

		/// <summary>
		/// Delete multiple rows by key.
		/// </summary>
		/// <typeparam name="TKey">The type of the t key.</typeparam>
		/// <param name="tableName">Name of the table.</param>
		/// <param name="keys">The keys.</param>
		/// <param name="options">Delete options.</param>
		/// <exception cref="T:Tortuga.Chain.MappingException"></exception>
		public Tortuga.Chain.CommandBuilders.MultipleRowDbCommandBuilder<Microsoft.Data.SqlClient.SqlCommand, Microsoft.Data.SqlClient.SqlParameter> DeleteByKeyList<TKey>(Tortuga.Chain.SqlServer.SqlServerObjectName tableName, System.Collections.Generic.IEnumerable<TKey> keys, Tortuga.Chain.DeleteOptions options = 0)
		{
			return __Trait4.DeleteByKeyList<TKey>(tableName, keys, options);
		}

		// Exposing trait Traits.SupportsDeleteTrait<Microsoft.Data.SqlClient.SqlCommand, Microsoft.Data.SqlClient.SqlParameter, Tortuga.Chain.SqlServer.SqlServerObjectName, System.Data.SqlDbType>

		/// <summary>
		/// Creates a command to perform a delete operation.
		/// </summary>
		/// <param name="tableName"></param>
		/// <param name="argumentValue"></param>
		/// <param name="options"></param>
		/// <returns></returns>
		public Tortuga.Chain.CommandBuilders.ObjectDbCommandBuilder<Microsoft.Data.SqlClient.SqlCommand, Microsoft.Data.SqlClient.SqlParameter, TArgument> Delete<TArgument>(Tortuga.Chain.SqlServer.SqlServerObjectName tableName, TArgument argumentValue, Tortuga.Chain.DeleteOptions options = 0)where TArgument : class
		{
			return __Trait5.Delete<TArgument>(tableName, argumentValue, options);
		}

		/// <summary>
		/// Delete an object model from the table indicated by the class's Table attribute.
		/// </summary>
		/// <typeparam name="TArgument"></typeparam>
		/// <param name="argumentValue">The argument value.</param>
		/// <param name="options">The delete options.</param>
		/// <returns></returns>
		public Tortuga.Chain.CommandBuilders.ObjectDbCommandBuilder<Microsoft.Data.SqlClient.SqlCommand, Microsoft.Data.SqlClient.SqlParameter, TArgument> Delete<TArgument>(TArgument argumentValue, Tortuga.Chain.DeleteOptions options = 0)where TArgument : class
		{
			return __Trait5.Delete<TArgument>(argumentValue, options);
		}

		// Exposing trait Traits.SupportsInsertBatchTrait<Microsoft.Data.SqlClient.SqlCommand, Microsoft.Data.SqlClient.SqlParameter, Tortuga.Chain.SqlServer.SqlServerObjectName, System.Data.SqlDbType, Tortuga.Chain.CommandBuilders.MultipleRowDbCommandBuilder<Microsoft.Data.SqlClient.SqlCommand, Microsoft.Data.SqlClient.SqlParameter>>

		/// <summary>
		/// Inserts the batch of records as one operation.
		/// </summary>
		/// <typeparam name="TObject"></typeparam>
		/// <param name="tableName">Name of the table.</param>
		/// <param name="objects">The objects to insert.</param>
		/// <param name="options">The options.</param>
		/// <returns>MultipleRowDbCommandBuilder&lt;SqlCommand, SqlParameter&gt;.</returns>
		public Tortuga.Chain.CommandBuilders.MultipleRowDbCommandBuilder<Microsoft.Data.SqlClient.SqlCommand, Microsoft.Data.SqlClient.SqlParameter> InsertBatch<TObject>(Tortuga.Chain.SqlServer.SqlServerObjectName tableName, System.Collections.Generic.IEnumerable<TObject> objects, Tortuga.Chain.InsertOptions options = 0)where TObject : class
		{
			return __Trait3.InsertBatch<TObject>(tableName, objects, options);
		}

		/// <summary>
		/// Inserts the batch of records as one operation.
		/// </summary>
		/// <typeparam name="TObject"></typeparam>
		/// <param name="objects">The objects to insert.</param>
		/// <param name="options">The options.</param>
		/// <returns>MultipleRowDbCommandBuilder&lt;SqlCommand, SqlParameter&gt;.</returns>
		public Tortuga.Chain.CommandBuilders.MultipleRowDbCommandBuilder<Microsoft.Data.SqlClient.SqlCommand, Microsoft.Data.SqlClient.SqlParameter> InsertBatch<TObject>(System.Collections.Generic.IEnumerable<TObject> objects, Tortuga.Chain.InsertOptions options = 0)where TObject : class
		{
			return __Trait3.InsertBatch<TObject>(objects, options);
		}

		/// <summary>
		/// Performs a series of batch inserts.
		/// </summary>
		/// <typeparam name="TObject">The type of the t object.</typeparam>
		/// <param name="tableName">Name of the table.</param>
		/// <param name="objects">The objects.</param>
		/// <param name="options">The options.</param>
		/// <returns>Tortuga.Chain.ILink&lt;System.Int32&gt;.</returns>
		/// <remarks>This operation is not atomic. It should be wrapped in a transaction.</remarks>
		public Tortuga.Chain.ILink<int> InsertMultipleBatch<TObject>(Tortuga.Chain.SqlServer.SqlServerObjectName tableName, System.Collections.Generic.IEnumerable<TObject> objects, Tortuga.Chain.InsertOptions options = 0)where TObject : class
		{
			return __Trait3.InsertMultipleBatch<TObject>(tableName, objects, options);
		}

		/// <summary>
		/// Inserts the batch of records as one operation.
		/// </summary>
		/// <typeparam name="TObject"></typeparam>
		/// <param name="objects">The objects to insert.</param>
		/// <param name="options">The options.</param>
		/// <returns>MultipleRowDbCommandBuilder&lt;SqlCommand, SqlParameter&gt;.</returns>
		public Tortuga.Chain.ILink<int> InsertMultipleBatch<TObject>(System.Collections.Generic.IReadOnlyList<TObject> objects, Tortuga.Chain.InsertOptions options = 0)where TObject : class
		{
			return __Trait3.InsertMultipleBatch<TObject>(objects, options);
		}

		// Exposing trait Traits.SupportsSqlQueriesTrait<Microsoft.Data.SqlClient.SqlCommand, Microsoft.Data.SqlClient.SqlParameter>

		/// <summary>
		/// Creates a operation based on a raw SQL statement.
		/// </summary>
		/// <param name="sqlStatement">The SQL statement.</param>
		/// <returns></returns>
		public Tortuga.Chain.CommandBuilders.MultipleTableDbCommandBuilder<Microsoft.Data.SqlClient.SqlCommand, Microsoft.Data.SqlClient.SqlParameter> Sql(System.String sqlStatement)
		{
			return __Trait2.Sql(sqlStatement);
		}

		/// <summary>
		/// Creates a operation based on a raw SQL statement.
		/// </summary>
		/// <param name="sqlStatement">The SQL statement.</param>
		/// <param name="argumentValue">The argument value.</param>
		/// <returns>SqlServerSqlCall.</returns>
		public Tortuga.Chain.CommandBuilders.MultipleTableDbCommandBuilder<Microsoft.Data.SqlClient.SqlCommand, Microsoft.Data.SqlClient.SqlParameter> Sql(System.String sqlStatement, System.Object argumentValue)
		{
			return __Trait2.Sql(sqlStatement, argumentValue);
		}

		// Exposing trait Traits.SupportsTruncateTrait<Tortuga.Chain.SqlServer.SqlServerObjectName, System.Data.SqlDbType>

		/// <summary>Truncates the specified table.</summary>
		/// <param name="tableName">Name of the table to Truncate.</param>
		/// <returns>The number of rows deleted or null if the database doesn't provide that information.</returns>
		public Tortuga.Chain.ILink<int?> Truncate(Tortuga.Chain.SqlServer.SqlServerObjectName tableName)
		{
			return __Trait1.Truncate(tableName);
		}

		/// <summary>Truncates the specified table.</summary>
		/// <typeparam name="TObject">This class used to determine which table to Truncate</typeparam>
		/// <returns>The number of rows deleted or null if the database doesn't provide that information.</returns>
		public Tortuga.Chain.ILink<int?> Truncate<TObject>()where TObject : class
		{
			return __Trait1.Truncate<TObject>();
		}

		// Exposing trait Traits.SupportsUpdateTrait<Microsoft.Data.SqlClient.SqlCommand, Microsoft.Data.SqlClient.SqlParameter, Tortuga.Chain.SqlServer.SqlServerObjectName, System.Data.SqlDbType>

		/// <summary>
		/// Update an object in the specified table.
		/// </summary>
		/// <typeparam name="TArgument"></typeparam>
		/// <param name="argumentValue">The argument value.</param>
		/// <param name="options">The update options.</param>
		/// <returns></returns>
		public Tortuga.Chain.CommandBuilders.ObjectDbCommandBuilder<Microsoft.Data.SqlClient.SqlCommand, Microsoft.Data.SqlClient.SqlParameter, TArgument> Update<TArgument>(TArgument argumentValue, Tortuga.Chain.UpdateOptions options = 0)where TArgument : class
		{
			return __Trait6.Update<TArgument>(argumentValue, options);
		}

		/// <summary>
		/// Update an object in the specified table.
		/// </summary>
		/// <param name="tableName"></param>
		/// <param name="argumentValue"></param>
		/// <param name="options"></param>
		/// <returns></returns>
		public Tortuga.Chain.CommandBuilders.ObjectDbCommandBuilder<Microsoft.Data.SqlClient.SqlCommand, Microsoft.Data.SqlClient.SqlParameter, TArgument> Update<TArgument>(Tortuga.Chain.SqlServer.SqlServerObjectName tableName, TArgument argumentValue, Tortuga.Chain.UpdateOptions options = 0)where TArgument : class
		{
			return __Trait6.Update<TArgument>(tableName, argumentValue, options);
		}

		private partial Tortuga.Chain.ILink<int?> OnDeleteAll(Tortuga.Chain.SqlServer.SqlServerObjectName tableName );

		private partial Tortuga.Chain.CommandBuilders.MultipleTableDbCommandBuilder<Microsoft.Data.SqlClient.SqlCommand, Microsoft.Data.SqlClient.SqlParameter> OnSql(System.String sqlStatement, System.Object? argumentValue );

		private partial Tortuga.Chain.ILink<int?> OnTruncate(Tortuga.Chain.SqlServer.SqlServerObjectName tableName );


		private void __RegisterTraits()
		{
			__TraitsRegistered = true;
			__Trait0.OnDeleteAll = OnDeleteAll;
			__Trait0.DataSource = this;
			__Trait1.OnTruncate = OnTruncate;
			__Trait1.DataSource = this;
			__Trait2.OnSql = OnSql;
			__Trait3.DataSource = this;
			__Trait4.DataSource = this;
			__Trait5.DataSource = this;
			__Trait6.DataSource = this;
		}
	}
}
