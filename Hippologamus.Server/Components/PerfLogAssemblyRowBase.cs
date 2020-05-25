using Hippologamus.DTO.DTO;
using Microsoft.AspNetCore.Components;

namespace Hippologamus.Server.Components
{
    public class PerfLogAssemblyRowBase : ComponentBase
    {
        [Parameter]
        public PerfLogAssemblyDisplay PerfLogAssembly { get; set; }

        public void RequestPathToggle(bool requestPath)
        {
            PerfLogAssembly.HasRequestPath = requestPath;
        }

      public void  ToggleShowRequestPath()
        {
            PerfLogAssembly.ShowRequestPath = !PerfLogAssembly.ShowRequestPath;
        }
    }
}