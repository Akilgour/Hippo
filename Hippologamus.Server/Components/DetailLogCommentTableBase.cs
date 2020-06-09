using AutoMapper;
using Hippologamus.Server.Models;
using Hippologamus.Server.Services.Interface;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippologamus.Server.Components
{
    public class DetailLogCommentTableBase : ComponentBase
    {
        [Parameter]
        public ErrorLogList ErrorLog { get; set; }

        [Inject]
        public IDetailLogCommentService DetailLogCommentService { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public List<DetailLogCommentList> DetailLogComments { get; set; }

        protected async override Task OnInitializedAsync()
        {
            DetailLogComments = Mapper.Map<List<DetailLogCommentList>>(await DetailLogCommentService.Get(ErrorLog.Id));
        }
    }
}