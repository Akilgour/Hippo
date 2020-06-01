using System.Collections.Generic;

namespace Hippologamus.Server.Factorys
{
    public static class PerfLogsOrderByListFactory
    {
        public static IDictionary<string, string> Create()
        {
            return new Dictionary<string, string>
            {
                {"ElapsedMilliseconds", "Elapsed Time" },
                {"MachineName", "Machine Name" },
                {"TimeStamp", "Time Stamp" }
         
            };
        }
    }
}