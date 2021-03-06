﻿using System;

namespace Hippologamus.Shared.DTO
{
    public class PerfLogDetails
    {
        public int Id { get; set; }
        public string Level { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Properties { get; set; }
        public string LogEvent { get; set; }
        public string PerfItem { get; set; }
        public string ElapsedMilliseconds { get; set; }
        public string ActionName { get; set; }
        public string MachineName { get; set; }
        public string Assembly { get; set; }
    }
}