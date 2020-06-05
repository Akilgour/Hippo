using AutoMapper;
using Hippologamus.Shared.DTO;
using Hippologamus.Server.Factorys;
using Hippologamus.Server.Models;
using Hippologamus.Server.Services.Interface;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hippologamus.Server.Pages
{
    public class PerfLogListBase : PageComponentBase
    {
        [Parameter]
        public string Assembly { get; set; }

        [Parameter]
        public string PerfItem { get; set; }

        [Inject]
        public IPerfLogDisplayService PerfLogDisplayService { get; set; }

        public PerfLogPagedList PerfLogPagedList { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ShowPageSize = 10;
            PageNumber = 1;
            await Refresh();
            OrderByList = PerfLogsOrderByListFactory.Create();
            ShowDataAsAList = true;
        }

        public async Task NextPage()
        {
            var link = PerfLogPagedList.Links.First(x => x.Rel == "nextPage").Href;
            PerfLogPagedList = Mapper.Map<PerfLogPagedList>((await PerfLogDisplayService.GetByLink(link)));
        }

        public async Task PerviousPage()
        {
            var link = PerfLogPagedList.Links.First(x => x.Rel == "previousPage").Href;
            PerfLogPagedList = Mapper.Map<PerfLogPagedList>((await PerfLogDisplayService.GetByLink(link)));
        }

        public async Task FirstPage()
        {
            PageNumber = 1;
            await Refresh();
        }

        public async Task LastPage()
        {
            PageNumber = PerfLogPagedList.PaginationTotalPages;
            await Refresh();
        }

        public async Task PageSize_Change()
        {
            PageNumber = 1;
            await Refresh();
        }

        public async Task OrderBy_Click()
        {
            await Refresh();
        }

        public async Task Refresh()
        {
            var search = new PerfLogCollectionSearch()
            {
                Assembly = Assembly,
                 PerfItem = PerfItem,
                PageSize = ShowPageSize,
                OrderBy = OrderBy,
                OrderAscending = OrderAscending,
                PageNumber = PageNumber,
            };
            PerfLogPagedList = Mapper.Map<PerfLogPagedList>(await PerfLogDisplayService.PerfLogDisplaySearch(search));
        }
    }
}