using Hippologamus.Server.Models;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Hippologamus.Server.Factorys;

namespace Hippologamus.Server.Components
{
    public class PerfLogPagedListTableBase : ComponentBase
    {
        [Parameter]
        public string OrderByValue { get; set; }

        [Parameter]
        public EventCallback OrderBy_ClickCallback { get; set; }

        [Parameter]
        public EventCallback<string> OrderByValueChanged { get; set; }


        [Parameter]
        public PerfLogPagedList PerfLogPagedList { get; set; }

        public async Task ToggleOrderTimeStamp()
        {
            await ToggleOrder("TimeStamp");
        }

        public async Task ToggleOrderElapsedTime()
        {
            await ToggleOrder("ElapsedMilliseconds");
        }

        public async Task ToggleOrderMachineName()
        {
            await ToggleOrder("MachineName");
        }

        public async Task ToggleOrder(string e)
        {
            OrderByValue = e;
            await OrderByValueChanged.InvokeAsync(OrderByValue);
            await OrderBy_ClickCallback.InvokeAsync(OrderByValue);
        }

        protected DeleteDialog DeleteItemDialog { get; set; }

        public void DeletePerfLog(MouseEventArgs e, int itemToBeDeleted)
        {
            DeleteItemDialog.Show(DeletePerfLogItemFactory.Create(itemToBeDeleted.ToString()));
        }

        public   void DeletePefLogDialog_OnDialogClose()
        {
          
        }
    }
}