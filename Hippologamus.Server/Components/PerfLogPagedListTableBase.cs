using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hippologamus.Server.Models;
using Microsoft.AspNetCore.Components;

namespace Hippologamus.Server.Components
{
    public class PerfLogPagedListTableBase : ComponentBase
    {
        [Parameter]
        public PerfLogPagedList PerfLogPagedList { get; set; }
    }
}