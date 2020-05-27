﻿using AutoMapper;
using Hippologamus.DTO.DTO;
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
        [Parameter]
        public string Assembly { get; set; }

        [Parameter]
        public string RequestPath { get; set; }

        [Inject]
        public IPerfLogDisplayService PerfLogDisplayService { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public PerfLogPagedList PerfLogPagedList { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var search = new PerfLogCollectionSearch()
            {
                Assembly = Assembly,
                RequestPath = RequestPath
            };
            PerfLogPagedList = Mapper.Map<PerfLogPagedList>((await PerfLogDisplayService.PerfLogDisplaySearch(search)));
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

        public async Task LastPage()
        {
            var search = new PerfLogCollectionSearch()
            {
                Assembly = Assembly,
                RequestPath = RequestPath,
                PageNumber = PerfLogPagedList.PaginationTotalPages
            };
            PerfLogPagedList = Mapper.Map<PerfLogPagedList>((await PerfLogDisplayService.PerfLogDisplaySearch(search)));
        }

    }
}