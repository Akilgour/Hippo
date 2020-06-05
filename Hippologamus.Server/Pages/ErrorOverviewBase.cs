using Hippologamus.DTO.DTO;
using Hippologamus.Server.Models;
using Hippologamus.Server.Services.Interface;
using Microsoft.AspNetCore.Components;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

namespace Hippologamus.Server.Pages
{
    public class ErrorOverviewBase : PageComponentBase
    {
        [CascadingParameter]
        Task<AuthenticationState> AuthenticationStateTask { get; set; }

        [Inject]
        public IErrorLogService ErrorLogService { get; set; }

        public ErrorLogPagedList ErrorLogs { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ShowDataAsAList = true;
            PageNumber = 1;
            ShowPageSize = 10;
            await Refresh();
        }

        public async Task PageSize_Change()
        {
            PageNumber = 1;
            await Refresh();
        }

        public async Task FirstPage()
        {
            PageNumber = 1;
            await Refresh();
        }

        public async Task LastPage()
        {
            var authenticationState = await AuthenticationStateTask;
            if (authenticationState.User.Identity.Name == "Kevin")
            {
                PageNumber = ErrorLogs.PaginationTotalPages;
                await Refresh();
            }
        }

        public async Task Refresh()
        {
            var search = new ErrorLogCollectionSearch()
            {
                PageSize = ShowPageSize,
                OrderBy = OrderBy,
                OrderAscending = OrderAscending,
                PageNumber = PageNumber
            };
            ErrorLogs = Mapper.Map<ErrorLogPagedList>(await ErrorLogService.Search(search));
        }

        public async Task NextPage()
        {
            var link = ErrorLogs.Links.First(x => x.Rel == "nextPage").Href;
            ErrorLogs = Mapper.Map<ErrorLogPagedList>((await ErrorLogService.GetByLink(link)));
        }

        public async Task PerviousPage()
        {
            var link = ErrorLogs.Links.First(x => x.Rel == "previousPage").Href;
            ErrorLogs = Mapper.Map<ErrorLogPagedList>((await ErrorLogService.GetByLink(link)));
        }

        public async Task OrderBy_Click()
        {
            await Refresh();
        }
    }
}
