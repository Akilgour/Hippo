using Hippologamus.DTO.DTO;
using Hippologamus.Server.Services.Interface;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hippologamus.Server.Pages
{
    public class PerfLogOverviewBase : ComponentBase
    {
        [Inject]
        public IPerfLogAssemblyService PerfLogAssemblyService { get; set; }

        public IEnumerable<PerfLogAssemblyDisplay> PerfLogAssemblyDisplays { get; set; }

        protected override async Task OnInitializedAsync()
        {
            PerfLogAssemblyDisplays = (await PerfLogAssemblyService.GetAll()).ToList();
        }
    }
}