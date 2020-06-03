using AutoMapper;
using Hippologamus.DTO.DTO;
using Hippologamus.Server.Models;
using Hippologamus.Server.Services.Interface;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using System.Linq;

namespace Hippologamus.Server.Pages
{
    public class ErrorOverviewBase : PageComponentBase
    {
        [Inject]
        public IErrorLogService ErrorLogService { get; set; }

  

        public ErrorLogPagedList ErrorLogs { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Refresh();
            ShowDataAsAList = true;
        }

        public async Task PageSize_Change()
        {
            _pageNumber = 1;
            await Refresh();
        }

        public async Task FirstPage()
        {
            _pageNumber = 1;
            await Refresh();
        }

        public async Task LastPage()
        {
            _pageNumber = ErrorLogs.PaginationTotalPages;
            await Refresh();
        }

        public async Task Refresh()
        {
            var search = new ErrorLogCollectionSearch()
            {
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
