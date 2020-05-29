using Hippologamus.Server.Models;
using Microsoft.AspNetCore.Components;

namespace Hippologamus.Server.Components
{
    public class PerfLogPagedListGridBase : ComponentBase
    {
        [Parameter]
        public PerfLogPagedList PerfLogPagedList { get; set; }
    }
}
