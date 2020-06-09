using Hippologamus.Server.Models;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Hippologamus.Server.Pages
{
    public class EditDetailLogCommentsBase : PageComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public int DetailLogId { get; set; }

        public DetailLogCommentEdit DetailLogComment { get; set; }

        //used to store state of screen
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;

        protected override void OnInitialized()
        {
            DetailLogComment = new DetailLogCommentEdit();
        }

        protected async Task HandleValidSubmit()
        {
            
            StatusClass = "alert-success";
            Message = "Comment successfully.";
            Saved = true;

            await Task.Delay(100);
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
