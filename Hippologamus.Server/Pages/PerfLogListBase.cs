using AutoMapper;
using Hippologamus.DTO.DTO;
using Hippologamus.Server.Factorys;
using Hippologamus.Server.Models;
using Hippologamus.Server.Services.Interface;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hippologamus.Server.Pages
{
    public class PerfLogListBase : ComponentBase
    {
        private string orderBy;

        [Parameter]
        public string Assembly { get; set; }

        [Parameter]
        public string RequestPath { get; set; }

        [Inject]
        public IPerfLogDisplayService PerfLogDisplayService { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        private int _pageNumber;

        public int ShowPageSize { get; set; }

        public PerfLogPagedList PerfLogPagedList { get; set; }

        public bool ShowDataAsAList { get; set; }

        public Dictionary<string, string> OrderByList { get; set; }

        public bool OrderAscending { get; set; } = true;

        protected override async Task OnInitializedAsync()
        {
            ShowPageSize = 10;
            _pageNumber = 1;
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
            _pageNumber = 1;
            await Refresh();
        }

        public async Task LastPage()
        {
            _pageNumber = PerfLogPagedList.PaginationTotalPages;
            await Refresh();
        }

        public async Task PageSize_Change()
        {
            await Refresh();
        }

        public void ShowDataAs_Click()
        {
            ShowDataAsAList = !ShowDataAsAList;
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
                RequestPath = RequestPath,
                PageSize = ShowPageSize,
                OrderBy = OrderBy,
                OrderAscending = OrderAscending,
                PageNumber = _pageNumber,
            };
            PerfLogPagedList = Mapper.Map<PerfLogPagedList>(await PerfLogDisplayService.PerfLogDisplaySearch(search));
        }

        public string OrderBy
        {
            get
            {
                return orderBy;
            }
            set
            {
                if (orderBy == value)
                {
                    OrderAscending = !OrderAscending;
                }
                orderBy = value;
            }
        }
    }
}