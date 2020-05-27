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

        public List<PerfLogDisplay> PerfLogs { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var foo = new PerfLogDisplaySearch()
            {
                Assembly = Assembly,
                RequestPath = RequestPath
            };

            var responce = (await PerfLogDisplayService.PerfLogDisplaySearch(foo));

            var asdf = Mapper.Map<PerfLogDisplayCollection>(responce);

            PerfLogs = responce.Value.ToList();
        }
    }
}