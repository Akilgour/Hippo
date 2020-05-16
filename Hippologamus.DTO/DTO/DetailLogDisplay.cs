﻿using System;

namespace Hippologamus.DTO.DTO
{
    public class DetailLogDisplay
    {
        public int Id { get; set; }
        public string Level { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Properties { get; set; }
        public string LogEvent { get; set; }
        public string MachineName { get; set; }
        public string Assembly { get; set; }
    }
}