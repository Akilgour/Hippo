using System.ComponentModel.DataAnnotations.Schema;

namespace Hippologamus.Domain.Models
{
    [NotMapped]
    public class PerfLogAssembly
    {
        public string Assembly { get; set; }
    }
}