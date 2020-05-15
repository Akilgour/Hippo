using System.ComponentModel.DataAnnotations.Schema;

namespace Hippologamus.Domain.Models
{
    [NotMapped]
    public class PerfLogPerformanceItem
    {
        public string PerformanceItem { get; set; }
        public string Assembly { get; set; }
    }
}