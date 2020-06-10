using AutoMapper;
using Hippologamus.Server.Models;
using Hippologamus.Server.Services.Interface;
using Hippologamus.Shared.DTO;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Linq;
using System.Threading.Tasks;

namespace Hippologamus.Server.Pages
{
    public class EditDetailLogCommentsBase :ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Inject]
        public IDetailLogCommentService  DetailLogCommentService { get; set; }

        [Parameter]
        public int DetailLogId { get; set; }

        [Parameter]
        public int DetailLogCommentId { get; set; }

        [CascadingParameter]
        Task<AuthenticationState> AuthenticationStateTask { get; set; }

        public DetailLogCommentEdit DetailLogComment { get; set; }

        //used to store state of screen
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;

        protected override async Task OnInitializedAsync()
        {
            if (DetailLogCommentId != 0)
            {
                DetailLogComment = Mapper.Map<DetailLogCommentEdit>(await DetailLogCommentService.Get(DetailLogId, DetailLogCommentId));
            }
            else
            {
                var authenticationState = await AuthenticationStateTask;
                var claimsName = authenticationState.User.Claims.First(x => x.Type == "name").Value;

                DetailLogComment = new DetailLogCommentEdit()
                {
                    CreateadBy = claimsName,
                    LinkedToDevOps = false
                };
            }
        }

        protected async Task HandleValidSubmit()
        {
            try
            {
                await DetailLogCommentService.Add(Mapper.Map<DetailLogCommentCreate>(DetailLogComment), DetailLogId);

                StatusClass = "alert-success";
                Message = "Comment successfully.";
                Saved = true;
            }
            catch (System.Exception ex)
            {

                  throw ex;
            }
        }

        protected void HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation errors. Please try again.";
        }

        protected void NavigateBack()
        {
            NavigationManager.NavigateTo("/erroroverview");
        }
    }
}
