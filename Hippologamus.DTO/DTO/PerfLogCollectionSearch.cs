using System;

namespace Hippologamus.DTO.DTO
{
    public class PerfLogCollectionSearch : BaseCollectionSearch
    {
        /// <summary>
        /// The Assembly that will get returned, this is not a wild search it must be a exact match.
        /// If left blank it will return all assemblys
        /// </summary>
        public string Assembly { get; set; }

        /// The PerfItem that will get returned, this is not a wild search it must be a exact match.
        /// If left blank it will return all PerfItems
        public string PerfItem { get; set; }

        /// The RequestPath that will get returned, this is not a wild search it must be a exact match.
        /// If left blank it will return all PerfItems
        public string RequestPath { get; set; }

        /// Any perf items with a timestamp greater or equal to this will be returned
        /// /If left blank it will return all
        public DateTime? DateFrom { get; set; }

        /// Any perf items with a timestamp less than or equal to this will be returned
        /// /If left blank it will return all
        public DateTime? DateTo { get; set; }
    }
}