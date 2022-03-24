﻿using System.Diagnostics.CodeAnalysis;
using Tortuga.Chain.CommandBuilders;
using Tortuga.Chain.Metadata;


#if SQL_SERVER_SDS || SQL_SERVER_MDS

namespace Tortuga.Chain.SqlServer
{
	partial class SqlServerDataSourceBase

#elif SQL_SERVER_OLEDB

namespace Tortuga.Chain.SqlServer
{
	partial class OleDbSqlServerDataSourceBase

#elif SQLITE

namespace Tortuga.Chain.SQLite
{
	partial class SQLiteDataSourceBase

#elif MYSQL

namespace Tortuga.Chain.MySql
{
	partial class MySqlDataSourceBase

#elif POSTGRESQL

namespace Tortuga.Chain.PostgreSql
{
	partial class PostgreSqlDataSourceBase

#elif ACCESS

namespace Tortuga.Chain.Access
{
	partial class AccessDataSourceBase

#endif
	{

		IUpdateSetDbCommandBuilder<AbstractCommand, AbstractParameter> OnUpdateSet(AbstractObjectName tableName, string updateExpression, object? updateArgumentValue, UpdateOptions options)
		{
			return ((Traits.IUpdateDeleteSetHelper<AbstractCommand, AbstractParameter, AbstractObjectName, AbstractDbType>)this).OnUpdateSet(tableName, updateExpression, updateArgumentValue, options);
		}

		IUpdateSetDbCommandBuilder<AbstractCommand, AbstractParameter> OnUpdateSet(AbstractObjectName tableName, object? newValues, UpdateOptions options)
		{
			return ((Traits.IUpdateDeleteSetHelper<AbstractCommand, AbstractParameter, AbstractObjectName, AbstractDbType>)this).OnUpdateSet(tableName.Name, newValues, options);
		}


		/************************ ISupportsDeleteWithFilter ************************/


		/// <summary>
		/// Delete multiple records using a where expression.
		/// </summary>
		/// <param name="tableName">Name of the table.</param>
		/// <param name="whereClause">The where clause.</param>
		public MultipleRowDbCommandBuilder<AbstractCommand, AbstractParameter> DeleteWithFilter(AbstractObjectName tableName, string whereClause)
		{
			var table = DatabaseMetadata.GetTableOrView(tableName);
			if (!AuditRules.UseSoftDelete(table))
				return OnDeleteSet(tableName, whereClause, null);

			return OnUpdateSet(tableName, null, UpdateOptions.SoftDelete | UpdateOptions.IgnoreRowsAffected).WithFilter(whereClause, null);
		}

		/// <summary>
		/// Delete multiple records using a where expression.
		/// </summary>
		/// <param name="whereClause">The where clause.</param>
		public MultipleRowDbCommandBuilder<AbstractCommand, AbstractParameter> DeleteWithFilter<TObject>(string whereClause)
			where TObject : class
		{
			var tableName = DatabaseMetadata.GetTableOrViewFromClass<TObject>().Name;
			return DeleteWithFilter(tableName, whereClause);
		}


		/************************ ISupportsFrom ************************/


		/// <summary>
		/// Creates an operation to directly query a table or view
		/// </summary>
		/// <param name="tableOrViewName"></param>
		/// <returns></returns>
		public TableDbCommandBuilder<AbstractCommand, AbstractParameter, AbstractLimitOption> From(AbstractObjectName tableOrViewName)
		{
			return OnFromTableOrView(tableOrViewName, null, null);
		}

		/// <summary>
		/// Creates an operation to directly query a table or view
		/// </summary>
		/// <param name="tableOrViewName"></param>
		/// <param name="whereClause"></param>
		/// <returns></returns>
		public TableDbCommandBuilder<AbstractCommand, AbstractParameter, AbstractLimitOption> From(AbstractObjectName tableOrViewName, string whereClause)
		{
			return OnFromTableOrView(tableOrViewName, whereClause, null);
		}

		/// <summary>
		/// Creates an operation to directly query a table or view
		/// </summary>
		/// <param name="tableOrViewName"></param>
		/// <param name="whereClause"></param>
		/// <param name="argumentValue"></param>
		/// <returns></returns>
		public TableDbCommandBuilder<AbstractCommand, AbstractParameter, AbstractLimitOption> From(AbstractObjectName tableOrViewName, string whereClause, object argumentValue)
		{
			return OnFromTableOrView(tableOrViewName, whereClause, argumentValue);
		}

		/// <summary>
		/// Creates an operation to directly query a table or view
		/// </summary>
		/// <param name="tableOrViewName">Name of the table or view.</param>
		/// <param name="filterValue">The filter value.</param>
		/// <param name="filterOptions">The filter options.</param>
		/// <returns>TableDbCommandBuilder&lt;AbstractCommand, AbstractParameter, AbstractLimitOption&gt;.</returns>
		public TableDbCommandBuilder<AbstractCommand, AbstractParameter, AbstractLimitOption> From(AbstractObjectName tableOrViewName, object filterValue, FilterOptions filterOptions = FilterOptions.None)
		{
			return OnFromTableOrView(tableOrViewName, filterValue, filterOptions);
		}

		/// <summary>
		/// This is used to directly query a table or view.
		/// </summary>
		/// <typeparam name="TObject"></typeparam>
		/// <returns></returns>
		[SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
		public TableDbCommandBuilder<AbstractCommand, AbstractParameter, AbstractLimitOption, TObject> From<TObject>() where TObject : class
		{
			return OnFromTableOrView<TObject>(DatabaseMetadata.GetTableOrViewFromClass<TObject>(OperationType.Select).Name, null, null);
		}

		/// <summary>
		/// This is used to directly query a table or view.
		/// </summary>
		/// <typeparam name="TObject">The type of the object.</typeparam>
		/// <param name="whereClause">The where clause. Do not prefix this clause with "WHERE".</param>
		/// <returns></returns>
		[SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
		public TableDbCommandBuilder<AbstractCommand, AbstractParameter, AbstractLimitOption, TObject> From<TObject>(string whereClause) where TObject : class
		{
			return OnFromTableOrView<TObject>(DatabaseMetadata.GetTableOrViewFromClass<TObject>(OperationType.Select).Name, whereClause, null);
		}

		/// <summary>
		/// This is used to directly query a table or view.
		/// </summary>
		/// <typeparam name="TObject">The type of the object.</typeparam>
		/// <param name="whereClause">The where clause. Do not prefix this clause with "WHERE".</param>
		/// <param name="argumentValue">Optional argument value. Every property in the argument value must have a matching parameter in the WHERE clause</param>
		/// <returns></returns>
		[SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
		public TableDbCommandBuilder<AbstractCommand, AbstractParameter, AbstractLimitOption, TObject> From<TObject>(string whereClause, object argumentValue) where TObject : class
		{
			return OnFromTableOrView<TObject>(DatabaseMetadata.GetTableOrViewFromClass<TObject>(OperationType.Select).Name, whereClause, argumentValue);
		}

		/// <summary>
		/// This is used to directly query a table or view.
		/// </summary>
		/// <typeparam name="TObject">The type of the object.</typeparam>
		/// <param name="filterValue">The filter value is used to generate a simple AND style WHERE clause.</param>
		/// <param name="filterOptions">The filter options.</param>
		/// <returns>TableDbCommandBuilder&lt;AbstractCommand, AbstractParameter, AbstractLimitOption, TObject&gt;.</returns>
		[SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
		public TableDbCommandBuilder<AbstractCommand, AbstractParameter, AbstractLimitOption, TObject> From<TObject>(object filterValue, FilterOptions filterOptions = FilterOptions.None) where TObject : class
		{
			return OnFromTableOrView<TObject>(DatabaseMetadata.GetTableOrViewFromClass<TObject>(OperationType.Select).Name, filterValue, filterOptions);
		}

		/************************ ISupportsDeleteWithFilter ************************/


		/// <summary>
		/// Delete multiple records using a filter object.
		/// </summary>
		/// <param name="tableName">Name of the table.</param>
		/// <param name="filterValue">The filter value.</param>
		/// <param name="filterOptions">The options.</param>
		public MultipleRowDbCommandBuilder<AbstractCommand, AbstractParameter> DeleteWithFilter(AbstractObjectName tableName, object filterValue, FilterOptions filterOptions = FilterOptions.None)
		{
			var table = DatabaseMetadata.GetTableOrView(tableName);
			if (!AuditRules.UseSoftDelete(table))
				return OnDeleteSet(tableName, filterValue, filterOptions);

			return OnUpdateSet(tableName, null, UpdateOptions.SoftDelete | UpdateOptions.IgnoreRowsAffected).WithFilter(filterValue, filterOptions);
		}

		/// <summary>
		/// Delete multiple records using a filter object.
		/// </summary>
		/// <param name="filterValue">The filter value.</param>
		/// <param name="filterOptions">The options.</param>
		public MultipleRowDbCommandBuilder<AbstractCommand, AbstractParameter> DeleteWithFilter<TObject>(object filterValue, FilterOptions filterOptions = FilterOptions.None)
			where TObject : class
		{
			var tableName = DatabaseMetadata.GetTableOrViewFromClass<TObject>().Name;
			return DeleteWithFilter(tableName, filterValue, filterOptions);
		}

		/// <summary>
		/// Delete multiple records using a where expression.
		/// </summary>
		/// <param name="tableName">Name of the table.</param>
		/// <param name="whereClause">The where clause.</param>
		/// <param name="argumentValue">The argument value for the where clause.</param>
		public MultipleRowDbCommandBuilder<AbstractCommand, AbstractParameter> DeleteWithFilter(AbstractObjectName tableName, string whereClause, object argumentValue)
		{
			var table = DatabaseMetadata.GetTableOrView(tableName);
			if (!AuditRules.UseSoftDelete(table))
				return OnDeleteSet(tableName, whereClause, argumentValue);

			return OnUpdateSet(tableName, null, UpdateOptions.SoftDelete | UpdateOptions.IgnoreRowsAffected).WithFilter(whereClause, argumentValue);
		}

		/// <summary>
		/// Delete multiple records using a where expression.
		/// </summary>
		/// <param name="whereClause">The where clause.</param>
		/// <param name="argumentValue">The argument value for the where clause.</param>
		public MultipleRowDbCommandBuilder<AbstractCommand, AbstractParameter> DeleteWithFilter<TObject>(string whereClause, object argumentValue)
			where TObject : class
		{
			var tableName = DatabaseMetadata.GetTableOrViewFromClass<TObject>().Name;
			return DeleteWithFilter(tableName, whereClause, argumentValue);
		}






		/************************ ISupportsGetByKey ************************/


		/// <summary>
		/// Gets a record by its primary key.
		/// </summary>
		/// <typeparam name="TObject">The type of the object. Used to determine which table will be read.</typeparam>
		/// <param name="key">The key.</param>
		/// <returns></returns>
		/// <remarks>This only works on tables that have a scalar primary key.</remarks>
		public SingleRowDbCommandBuilder<AbstractCommand, AbstractParameter, TObject> GetByKey<TObject>(Guid key)
			where TObject : class
		{
			return GetByKey<TObject, Guid>(DatabaseMetadata.GetTableOrViewFromClass<TObject>(OperationType.Select).Name, key);
		}

		/// <summary>
		/// Gets a record by its primary key.
		/// </summary>
		/// <typeparam name="TObject">The type of the object.</typeparam>
		/// <param name="key">The key.</param>
		/// <returns></returns>
		/// <remarks>This only works on tables that have a scalar primary key.</remarks>
		public SingleRowDbCommandBuilder<AbstractCommand, AbstractParameter, TObject> GetByKey<TObject>(long key)
			where TObject : class
		{
			return GetByKey<TObject, long>(DatabaseMetadata.GetTableOrViewFromClass<TObject>(OperationType.Select).Name, key);
		}

		/// <summary>
		/// Gets a record by its primary key.
		/// </summary>
		/// <typeparam name="TObject">The type of the object.</typeparam>
		/// <param name="key">The key.</param>
		/// <returns></returns>
		/// <remarks>This only works on tables that have a scalar primary key.</remarks>
		public SingleRowDbCommandBuilder<AbstractCommand, AbstractParameter, TObject> GetByKey<TObject>(int key)
			where TObject : class
		{
			return GetByKey<TObject, int>(DatabaseMetadata.GetTableOrViewFromClass<TObject>(OperationType.Select).Name, key);
		}

		/// <summary>
		/// Gets a record by its primary key.
		/// </summary>
		/// <typeparam name="TObject">The type of the object.</typeparam>
		/// <param name="key">The key.</param>
		/// <returns></returns>
		public SingleRowDbCommandBuilder<AbstractCommand, AbstractParameter, TObject> GetByKey<TObject>(string key)
			where TObject : class
		{
			return GetByKey<TObject, string>(DatabaseMetadata.GetTableOrViewFromClass<TObject>(OperationType.Select).Name, key);
		}

		/// <summary>
		/// Gets a record by its primary key.
		/// </summary>
		/// <param name="tableName">Name of the table.</param>
		/// <param name="key">The key.</param>
		public SingleRowDbCommandBuilder<AbstractCommand, AbstractParameter> GetByKey(AbstractObjectName tableName, string key)
		{
			return GetByKey<string>(tableName, key);
		}







		/************************ ISupportsGetByKey ************************/

		/// <summary>
		/// Gets a record by its primary key.
		/// </summary>
		/// <typeparam name="TKey"></typeparam>
		/// <typeparam name="TObject">The type of the object. Used to determine which table will be read.</typeparam>
		/// <param name="tableName">Name of the table.</param>
		/// <param name="key">The key.</param>
		/// <remarks>This only works on tables that have a scalar primary key.</remarks>
		[SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "GetByKeyList")]
		public SingleRowDbCommandBuilder<AbstractCommand, AbstractParameter, TObject> GetByKey<TObject, TKey>(AbstractObjectName tableName, TKey key)
		where TObject : class
		{
			var primaryKeys = DatabaseMetadata.GetTableOrView(tableName).PrimaryKeyColumns;

			if (primaryKeys.Count == 0) //we're looking at a view. Try looking at the underlying table.
			{
				var alternateTableName = DatabaseMetadata.GetTableOrViewFromClass<TObject>().Name;
				primaryKeys = DatabaseMetadata.GetTableOrView(alternateTableName).PrimaryKeyColumns;
			}

			if (primaryKeys.Count != 1)
				throw new MappingException($"{nameof(GetByKeyList)} operation isn't allowed on {tableName} because it doesn't have a single primary key. Use DataSource.From instead.");

			return new SingleRowDbCommandBuilder<AbstractCommand, AbstractParameter, TObject>(OnGetByKey<TObject, TKey>(tableName, primaryKeys.Single(), key));
		}

		/// <summary>
		/// Gets a record by its primary key.
		/// </summary>
		/// <typeparam name="TKey"></typeparam>
		/// <param name="tableName">Name of the table.</param>
		/// <param name="key">The key.</param>
		/// <remarks>This only works on tables that have a scalar primary key.</remarks>
		[SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "GetByKeyList")]
		public SingleRowDbCommandBuilder<AbstractCommand, AbstractParameter> GetByKey<TKey>(AbstractObjectName tableName, TKey key)
		{
			var primaryKeys = DatabaseMetadata.GetTableOrView(tableName).PrimaryKeyColumns;

			if (primaryKeys.Count != 1)
				throw new MappingException($"{nameof(GetByKeyList)} operation isn't allowed on {tableName} because it doesn't have a single primary key. Use DataSource.From instead.");

			return OnGetByKey<object, TKey>(tableName, primaryKeys.Single(), key);
		}

		/************************ ISupportsGetByKeyList ************************/

		/// <summary>
		/// Gets a set of records by their primary key.
		/// </summary>
		/// <typeparam name="TKey"></typeparam>
		/// <param name="tableName">Name of the table.</param>
		/// <param name="keys">The keys.</param>
		/// <returns></returns>
		/// <remarks>This only works on tables that have a scalar primary key.</remarks>
		[SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "GetByKeyList")]
		public MultipleRowDbCommandBuilder<AbstractCommand, AbstractParameter> GetByKeyList<TKey>(AbstractObjectName tableName, IEnumerable<TKey> keys)
		{
			var primaryKeys = DatabaseMetadata.GetTableOrView(tableName).PrimaryKeyColumns;
			if (primaryKeys.Count != 1)
				throw new MappingException($"{nameof(GetByKeyList)} operation isn't allowed on {tableName} because it doesn't have a single primary key. Use DataSource.From instead.");

			return OnGetByKeyList<object, TKey>(tableName, primaryKeys.Single(), keys);
		}

		/// <summary>
		/// Gets a set of records by an unique key.
		/// </summary>
		/// <typeparam name="TKey">The type of the keys.</typeparam>
		/// <param name="tableName">Name of the table.</param>
		/// <param name="keyColumn">Name of the key column. This should be a primary or unique key, but that's not enforced.</param>
		/// <param name="keys">The keys.</param>
		/// <returns>MultipleRowDbCommandBuilder&lt;AbstractCommand, AbstractParameter&gt;.</returns>
		/// <exception cref="MappingException">Cannot find a column named {keyColumn} on table {tableName}.</exception>
		/// <remarks>This only works on tables that have a scalar primary key.</remarks>
		[SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "GetByKeyList")]
		public MultipleRowDbCommandBuilder<AbstractCommand, AbstractParameter> GetByKeyList<TKey>(AbstractObjectName tableName, string keyColumn, IEnumerable<TKey> keys)
		{
			var primaryKeys = DatabaseMetadata.GetTableOrView(tableName).Columns.Where(c => c.SqlName.Equals(keyColumn, StringComparison.OrdinalIgnoreCase)).ToList();
			if (primaryKeys.Count == 0)
				throw new MappingException($"Cannot find a column named {keyColumn} on table {tableName}.");

			return OnGetByKeyList<object, TKey>(tableName, primaryKeys.Single(), keys);
		}

		/// <summary>
		/// Gets a set of records by a key list.
		/// </summary>
		/// <typeparam name="TObject">The type of the t object.</typeparam>
		/// <typeparam name="TKey">The type of the t key.</typeparam>
		/// <param name="tableName">Name of the table.</param>
		/// <param name="keyColumn">Name of the key column. This should be a primary or unique key, but that's not enforced.</param>
		/// <param name="keys">The keys.</param>
		/// <returns>MultipleRowDbCommandBuilder&lt;AbstractCommand, AbstractParameter, TObject&gt;.</returns>
		/// <exception cref="MappingException">Cannot find a column named {keyColumn} on table {tableName}.</exception>
		/// <remarks>This only works on tables that have a scalar primary key.</remarks>
		[SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "GetByKeyList")]
		public MultipleRowDbCommandBuilder<AbstractCommand, AbstractParameter, TObject> GetByKeyList<TObject, TKey>(AbstractObjectName tableName, string keyColumn, IEnumerable<TKey> keys)
			where TObject : class
		{
			var primaryKeys = DatabaseMetadata.GetTableOrView(tableName).Columns.Where(c => c.SqlName.Equals(keyColumn, StringComparison.OrdinalIgnoreCase)).ToList();

			if (primaryKeys.Count == 0)
				throw new MappingException($"Cannot find a column named {keyColumn} on table {tableName}.");

			return OnGetByKeyList<TObject, TKey>(tableName, primaryKeys.Single(), keys);
		}

		/// <summary>
		/// Gets a set of records by a key list.
		/// </summary>
		/// <typeparam name="TObject">The type of the returned object.</typeparam>
		/// <typeparam name="TKey">The type of the key.</typeparam>
		/// <param name="keys">The keys.</param>
		public MultipleRowDbCommandBuilder<AbstractCommand, AbstractParameter, TObject> GetByKeyList<TObject, TKey>(IEnumerable<TKey> keys)
			where TObject : class
		{
			var tableName = DatabaseMetadata.GetTableOrViewFromClass<TObject>(OperationType.Select).Name;

			var primaryKeys = DatabaseMetadata.GetTableOrView(tableName).PrimaryKeyColumns;
			if (primaryKeys.Count == 0) //we're looking at a view. Try looking at the underlying table.
			{
				var alternateTableName = DatabaseMetadata.GetTableOrViewFromClass<TObject>().Name;
				primaryKeys = DatabaseMetadata.GetTableOrView(alternateTableName).PrimaryKeyColumns;
			}

			if (primaryKeys.Count != 1)
				throw new MappingException($"{nameof(GetByKeyList)} operation isn't allowed on {tableName} because it doesn't have a single primary key. Use DataSource.From instead.");

			return OnGetByKeyList<TObject, TKey>(tableName, primaryKeys.Single(), keys);
		}

		/// <summary>
		/// Gets a set of records by a key list.
		/// </summary>
		/// <typeparam name="TObject">The type of the returned object.</typeparam>
		/// <param name="keys">The keys.</param>
		public MultipleRowDbCommandBuilder<AbstractCommand, AbstractParameter, TObject> GetByKeyList<TObject>(IEnumerable<Guid> keys)
			where TObject : class
		{
			return GetByKeyList<TObject, Guid>(keys);
		}

		/// <summary>
		/// Gets a set of records by a key list.
		/// </summary>
		/// <typeparam name="TObject">The type of the returned object.</typeparam>
		/// <param name="keys">The keys.</param>
		public MultipleRowDbCommandBuilder<AbstractCommand, AbstractParameter, TObject> GetByKeyList<TObject>(IEnumerable<long> keys)
			where TObject : class
		{
			return GetByKeyList<TObject, long>(keys);
		}

		/// <summary>
		/// Gets a set of records by a key list.
		/// </summary>
		/// <typeparam name="TObject">The type of the returned object.</typeparam>
		/// <param name="keys">The keys.</param>
		public MultipleRowDbCommandBuilder<AbstractCommand, AbstractParameter, TObject> GetByKeyList<TObject>(IEnumerable<int> keys)
			where TObject : class
		{
			return GetByKeyList<TObject, int>(keys);
		}

		/// <summary>
		/// Gets a set of records by a key list.
		/// </summary>
		/// <typeparam name="TObject">The type of the returned object.</typeparam>
		/// <param name="keys">The keys.</param>
		public MultipleRowDbCommandBuilder<AbstractCommand, AbstractParameter, TObject> GetByKeyList<TObject>(IEnumerable<string> keys)
			where TObject : class
		{
			return GetByKeyList<TObject, string>(keys);
		}

		/************************ ISupportsFrom ************************/

		TableDbCommandBuilder<AbstractCommand, AbstractParameter, AbstractLimitOption> OnFromTableOrView(AbstractObjectName tableOrViewName, object filterValue, FilterOptions filterOptions)
			=> OnFromTableOrView<object>(tableOrViewName, filterValue, filterOptions);

		TableDbCommandBuilder<AbstractCommand, AbstractParameter, AbstractLimitOption> OnFromTableOrView(AbstractObjectName tableOrViewName, string? whereClause, object? argumentValue)
			=> OnFromTableOrView<object>(tableOrViewName, whereClause, argumentValue);



	}
}
