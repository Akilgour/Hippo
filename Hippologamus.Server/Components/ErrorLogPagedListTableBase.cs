using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Hippologamus.Server.Models;

namespace Hippologamus.Server.Components
{
    public class ErrorLogPagedListTableBase : ComponentBase
    {
        [Parameter]
        public ErrorLogPagedList ErrorLogPagedList { get; set; }

        public bool ShowComments { get; set; }

        public void ToggleShowComments()
        {
            ShowComments = !ShowComments;
        }

    }
}
