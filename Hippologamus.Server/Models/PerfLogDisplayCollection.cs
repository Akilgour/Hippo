using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hippologamus.Server.Models
{
    public class PerfLogDisplayCollection
    {
        public PerfLog[] Value { get; set; }
        public Links[] Links { get; set; }
        public RootPaginationHeader PaginationHeader { get; set; }
    }
}
