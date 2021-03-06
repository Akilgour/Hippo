﻿using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using System.Data;

namespace Hippo.Serilog.Builders
{
    public static class SqlPerfColumnOptions
    {
        public static ColumnOptions Create()
        {
            var options = new ColumnOptions();
            options.Store.Remove(StandardColumn.MessageTemplate);
            options.Store.Remove(StandardColumn.Exception);

            options.AdditionalColumns = new Collection<SqlColumn>
            {
                new SqlColumn
                { 
                    ColumnName = "PerfItem", AllowNull = false,
                    DataType = SqlDbType.NVarChar, DataLength = 100,
                    NonClusteredIndex = true
                },
                new SqlColumn
                {
                    ColumnName = "ElapsedMilliseconds", AllowNull = false,
                    DataType = SqlDbType.Int
                },
                new SqlColumn
                {
                    ColumnName = "ActionName", AllowNull = false
                },
                new SqlColumn
                {
                    ColumnName = "MachineName", AllowNull = false
                },
                new SqlColumn
                {
                    ColumnName = "Assembly", AllowNull = false
                },
                new SqlColumn
                {
                    ColumnName = "RequestPath", AllowNull = false
                }
            };

            return options;
        }
    }
}