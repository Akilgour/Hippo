using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;

namespace Hippo.Serilog.Builders
{
    public class SqlUsageColumnOptions
    {
        public static ColumnOptions Create()
        {
            var options = new ColumnOptions();
            options.Store.Remove(StandardColumn.Message);
            options.Store.Remove(StandardColumn.MessageTemplate);
            options.Store.Remove(StandardColumn.Exception);
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
                }
            };
            return options;
        }
    }
}