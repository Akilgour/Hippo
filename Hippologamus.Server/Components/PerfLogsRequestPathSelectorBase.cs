using Hippologamus.DTO.DTO;
using Hippologamus.Server.Services.Interface;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippologamus.Server.Components
{
    public class PerfLogsRequestPathSelectorBase : ComponentBase
    {
        protected IEnumerable<PerfLogPerfItemCollection> PerfItems { get; set; }

        [Inject]
        public IPerfLogPerfItemService PerfLogPerfItemService { get; set; }

        [Parameter]
        public PerfLogAssemblyCollection PerfLogAssembly { get; set; }

        [Parameter]
        public EventCallback<bool> OnRequestPathToggle { get; set; }

        protected async override Task OnInitializedAsync()
        {
            var collection = await PerfLogPerfItemService.GetPerfLogPerfItems(PerfLogAssembly.Assembly);

            PerfItems = collection;
        }
    }
}