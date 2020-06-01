using Hippologamus.Server.Models;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Hippologamus.Server.Components
{
    public class DeleteDialogBase : ComponentBase
    {
        [Parameter]
        public EventCallback<bool> CloseEventCallback { get; set; }

        protected bool ShowDialog { get; set; }

        protected DeleteItem DeleteItem { get; set; }

        protected override void OnInitialized()
        {
            DeleteItem = new DeleteItem() { CheckValue = "42", DeleteCaption = "Do you want to delete 42, then type 42.", DialogTitle = "Delete PerfLog" };
        }

        public void Show()
        {
            ShowDialog = true;
        }

        public void Close()
        {
            ShowDialog = false;
        }

        protected async Task HandleValidSubmit()
        {
            //await EmployeeDataService.AddEmployee(Employee);
            ShowDialog = false;

            await CloseEventCallback.InvokeAsync(true);
            StateHasChanged();
        }
    }
}