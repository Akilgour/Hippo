using Hippologamus.Server.Models;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Hippologamus.Server.Pages
{
    public class EditDetailLogCommentsBase : PageComponentBase
    {
        [Parameter]
        public int DetailLogId { get; set; }

        public DetailLogCommentEdit DetailLogComment { get; set; }

        protected override void OnInitialized()
        {
            DetailLogComment = new DetailLogCommentEdit();
        }

        protected async Task HandleValidSubmit()
        {
            await Task.Delay(100);
        }

        protected void HandleInvalidSubmit()
        {

        }
    }
}
