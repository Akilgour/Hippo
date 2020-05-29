using Hippologamus.Server.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippologamus.Server.Components
{
    public class PaginationComponentBase : ComponentBase
    {
        [Parameter]
        public PerfLogPagedList PerfLogPagedList { get; set; }

        [Parameter]
        public bool ShowDataAsAList { get; set; }

        [Parameter]
        public bool ShowDataAsAListCallback { get; set; }

        [Parameter]
        public EventCallback PageSize_ChangeCallback { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> PerviousPageCallback { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> FirstPageCallback { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> NextPageCallback { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> LastPageCallback { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> ShowDataAs_ClickCallback { get; set; }

        //[Parameter]
        //public EventCallback ShowPageSizeCallback { get; set; }

        //[Parameter]
        //public EventCallback<int> ShowPageSize { get; set; }




        [Parameter]
        public int ShowPageSizeValue { get; set; }
        [Parameter]
        public EventCallback<int> ShowPageSizeValueChanged { get; set; }




        public List<PageSize> PageSizes { get; set; } = new List<PageSize>();

        protected override void OnInitialized()
        {
            PageSizes = Factorys.PageSizes.Create();
        }

        public async Task PageSize_Change(ChangeEventArgs e)
        {
            ShowPageSizeValue = int.Parse(e.Value.ToString());
       
            await ShowPageSizeValueChanged.InvokeAsync(ShowPageSizeValue);
          


        }
    }
}
