using System.Collections.Generic;

namespace Hippologamus.Server.Models
{
    public class ErrorLogPagedList : BasePagedList
    {
        public List<ErrorLogList> ErrorLogs { get; set; }
    }
}