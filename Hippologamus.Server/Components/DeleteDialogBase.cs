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

        public void Show(DeleteItem  deleteItem)
        {
            DeleteItem = deleteItem;
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