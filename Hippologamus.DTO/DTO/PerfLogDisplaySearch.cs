using System;

namespace Hippologamus.DTO.DTO
{
    public class PerfLogDisplaySearch
    {
        public string Assembly { get; set; }
        public string PerfItem { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}