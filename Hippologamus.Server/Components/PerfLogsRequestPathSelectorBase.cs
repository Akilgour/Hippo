using Hippologamus.DTO.DTO;
using Hippologamus.Server.Services.Interface;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippologamus.Server.Components
{
    public class PerfLogsRequestPathSelectorBase : ComponentBase
    {
        protected IEnumerable<PerfLogRequestPathDisplay> RequestPaths { get; set; }

        [Inject]
        public IPerfLogRequestPathService PerfLogRequestPathService { get; set; }

        [Parameter]
        public PerfLogAssemblyDisplay PerfLogAssembly { get; set; }

        [Parameter]
        public EventCallback<bool> OnRequestPathToggle { get; set; }

        protected async override Task OnInitializedAsync()
        {
            //  RequestPaths = await PerfLogRequestPathService.GetPerfLogRequestPaths(PerfLogAssembly.Assembly);
            var foo  = await PerfLogRequestPathService.GetPerfLogRequestPaths(PerfLogAssembly.Assembly);
            RequestPaths = foo;
          //  PerfLogAssembly.HasRequestPath = true;
        }
    }
}