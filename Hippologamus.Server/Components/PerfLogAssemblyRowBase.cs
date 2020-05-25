using Hippologamus.DTO.DTO;
using Microsoft.AspNetCore.Components;

namespace Hippologamus.Server.Components
{
    public class PerfLogAssemblyRowBase : ComponentBase
    {
        private PerfLogAssemblyDisplay perfLogAssemblyDisplay;

        [Parameter]
        public PerfLogAssemblyDisplay PerssssfLogAssembly { get; set; }
    }
}