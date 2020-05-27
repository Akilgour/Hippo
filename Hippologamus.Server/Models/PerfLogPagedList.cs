using System.Collections.Generic;

namespace Hippologamus.Server.Models
{
    public class PerfLogPagedList : BasePagedList
    {
        public List<PerfLogList> PerfLogs { get; set; }
    }
}