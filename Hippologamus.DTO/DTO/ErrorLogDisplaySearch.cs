using System;

namespace Hippologamus.DTO.DTO
{
    public class ErrorLogDisplaySearch : BaseDisplaySearch
    {
        public string RequestPath { get; set; }

        public string Assembly { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }
    }
}