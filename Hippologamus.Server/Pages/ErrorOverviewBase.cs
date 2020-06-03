using AutoMapper;
using Hippologamus.DTO.DTO;
using Hippologamus.Server.Models;
using Hippologamus.Server.Services.Interface;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Hippologamus.Server.Pages
{
    public class ErrorOverviewBase : ComponentBase
    {
        [Inject]
        public IErrorLogService ErrorLogService { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public ErrorLogPagedList ErrorLogs { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Refresh();
        }

        public async Task Refresh()
        {
            var search = new ErrorLogCollectionSearch()
            {
            };
            ErrorLogs = Mapper.Map<ErrorLogPagedList>(await ErrorLogService.Search(search));
        }
    }
}
