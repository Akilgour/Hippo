using System;
using System.Collections.Generic;

namespace Hippologamus.Domain.Models
{
    public class DetailLog
    {
        public string Id { get; set; }
        public string Level { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Properties { get; set; }
        public string LogEvent { get; set; }
        public string MachineName { get; set; }
        public string Assembly { get; set; }
        public List<DetailLogComment> DetailLogComments { get; set; }
    }
}