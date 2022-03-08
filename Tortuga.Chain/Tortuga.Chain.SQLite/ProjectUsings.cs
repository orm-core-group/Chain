﻿global using AbstractDbType = System.Data.DbType;
global using AbstractCommand = System.Data.SQLite.SQLiteCommand;
global using AbstractConnection = System.Data.SQLite.SQLiteConnection;
global using AbstractParameter = System.Data.SQLite.SQLiteParameter;
global using AbstractTransaction = System.Data.SQLite.SQLiteTransaction;
global using InsertBatchResult = Tortuga.Chain.CommandBuilders.DbCommandBuilder<System.Data.SQLite.SQLiteCommand, System.Data.SQLite.SQLiteParameter>;
global using AbstractObjectName = Tortuga.Chain.SQLite.SQLiteObjectName;
global using AbstractDataSource = Tortuga.Chain.SQLiteDataSource;
global using AbstractLimitOption = Tortuga.Chain.SQLiteLimitOption;