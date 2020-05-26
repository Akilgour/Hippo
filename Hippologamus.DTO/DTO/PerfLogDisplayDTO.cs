using Hippologamus.DTO.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hippologamus.DTO.DTO
{
    public class PerfLogDisplayDTO
    {
        public PagedList<PerfLogDisplay> Value { get; set; }
        public IEnumerable<LinkDto> Links { get; set; }
    }
}
