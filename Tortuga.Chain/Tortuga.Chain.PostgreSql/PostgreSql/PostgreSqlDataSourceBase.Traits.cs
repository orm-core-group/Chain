﻿using Npgsql;
using Tortuga.Anchor;
using Tortuga.Chain.CommandBuilders;
using Tortuga.Chain.Metadata;
using Tortuga.Chain.PostgreSql.CommandBuilders;
using Tortuga.Shipwright;
using Traits;

namespace Tortuga.Chain.PostgreSql
{

	[UseTrait(typeof(SupportsDeleteAllTrait<AbstractObjectName, AbstractDbType>))]
	[UseTrait(typeof(SupportsTruncateTrait<AbstractObjectName, AbstractDbType>))]
	[UseTrait(typeof(SupportsSqlQueriesTrait<AbstractCommand, AbstractParameter>))]
	[UseTrait(typeof(SupportsInsertBatchTrait<AbstractCommand, AbstractParameter, AbstractObjectName, AbstractDbType,
	MultipleRowDbCommandBuilder<AbstractCommand, AbstractParameter>>))]
	[UseTrait(typeof(SupportsDeleteByKeyList<AbstractCommand, AbstractParameter, AbstractObjectName, AbstractDbType>))]
	partial class PostgreSqlDataSourceBase
	{

		DatabaseMetadataCache<AbstractObjectName, AbstractDbType> ICommandHelper<AbstractObjectName, AbstractDbType>.DatabaseMetadata => DatabaseMetadata;

		List<AbstractParameter> ICommandHelper<AbstractCommand, AbstractParameter, AbstractObjectName, AbstractDbType>.GetParameters(SqlBuilder<AbstractDbType> builder) => builder.GetParameters();

		MultipleRowDbCommandBuilder<AbstractCommand, AbstractParameter> IDeleteByKeyHelper<AbstractCommand, AbstractParameter, AbstractObjectName, AbstractDbType>.OnDeleteByKeyList<TKey>(AbstractObjectName tableName, IEnumerable<TKey> keys, DeleteOptions options)
		{
			var primaryKeys = DatabaseMetadata.GetTableOrView(tableName).PrimaryKeyColumns;
			if (primaryKeys.Count != 1)
				throw new MappingException($"{nameof(DeleteByKeyList)} operation isn't allowed on {tableName} because it doesn't have a single primary key.");

			var keyList = keys.AsList();
			var columnMetadata = primaryKeys.Single();
			string where;
			if (keys.Count() > 1)
				where = columnMetadata.SqlName + " IN (" + string.Join(", ", keyList.Select((s, i) => "@Param" + i)) + ")";
			else
				where = columnMetadata.SqlName + " = @Param0";

			var parameters = new List<NpgsqlParameter>();
			for (var i = 0; i < keyList.Count; i++)
			{
				var param = new NpgsqlParameter("@Param" + i, keyList[i]);
				if (columnMetadata.DbType.HasValue)
					param.NpgsqlDbType = columnMetadata.DbType.Value;
				parameters.Add(param);
			}

			var table = DatabaseMetadata.GetTableOrView(tableName);
			if (!AuditRules.UseSoftDelete(table))
				return new PostgreSqlDeleteMany(this, tableName, where, parameters, parameters.Count, options);

			UpdateOptions effectiveOptions = UpdateOptions.SoftDelete;

			if (!options.HasFlag(DeleteOptions.CheckRowsAffected))
				effectiveOptions |= UpdateOptions.IgnoreRowsAffected;

			if (options.HasFlag(DeleteOptions.UseKeyAttribute))
				effectiveOptions |= UpdateOptions.UseKeyAttribute;

			return new PostgreSqlUpdateMany(this, tableName, null, where, parameters, parameters.Count, effectiveOptions);
		}

		DbCommandBuilder<AbstractCommand, AbstractParameter> IInsertBatchHelper<AbstractCommand, AbstractParameter, AbstractObjectName, AbstractDbType>.OnInsertBatch<TObject>(AbstractObjectName tableName, IEnumerable<TObject> objects, InsertOptions options)
		{
			return new PostgreSqlInsertBatch<TObject>(this, tableName, objects, options); ;
		}

		AbstractObjectName ICommandHelper<AbstractObjectName, AbstractDbType>.ParseObjectName(string objectName) => new(objectName);

		private partial ILink<int?> OnDeleteAll(AbstractObjectName tableName)
		{
			//Verify the table name actually exists.
			var table = DatabaseMetadata.GetTableOrView(tableName);
			return Sql("DELETE FROM " + table.Name.ToQuotedString() + ";").AsNonQuery();
		}

		private partial MultipleTableDbCommandBuilder<AbstractCommand, AbstractParameter> OnSql(string sqlStatement, object? argumentValue)
		{
			return new PostgreSqlSqlCall(this, sqlStatement, argumentValue);
		}

		private partial ILink<int?> OnTruncate(AbstractObjectName tableName)
		{
			//Verify the table name actually exists.
			var table = DatabaseMetadata.GetTableOrView(tableName);
			return Sql("TRUNCATE TABLE " + table.Name.ToQuotedString() + ";").AsNonQuery();
		}
	}
}
