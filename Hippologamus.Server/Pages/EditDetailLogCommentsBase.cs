using Hippologamus.Domain.Models;
using Hippologamus.Server.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

    }
}
