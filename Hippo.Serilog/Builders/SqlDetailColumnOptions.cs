using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;

namespace Hippo.Serilog.Builders
{
    public static class SqlDetailColumnOptions
    {
        public static ColumnOptions Create()
        {
            var options = new ColumnOptions();
            options.Store.Remove(StandardColumn.MessageTemplate);
            options.Store.Add(StandardColumn.LogEvent);
            options.LogEvent.ExcludeStandardColumns = true;
            options.LogEvent.ExcludeAdditionalProperties = false;

            options.AdditionalColumns = new Collection<SqlColumn>
            {
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