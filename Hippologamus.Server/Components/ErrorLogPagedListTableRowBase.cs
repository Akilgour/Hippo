using Hippologamus.Server.Models;
using Microsoft.AspNetCore.Components;

namespace Hippologamus.Server.Components
{
    public class ErrorLogPagedListTableRowBase : ComponentBase
    {
        [Parameter]
        public ErrorLogList ErrorLog { get; set; }

        public bool ShowComments { get; set; }

        public void ToggleShowComments()
        {
            ShowComments = !ShowComments;
        }
    }
}