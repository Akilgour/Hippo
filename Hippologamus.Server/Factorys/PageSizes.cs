using Hippologamus.Server.Models;
using System.Collections.Generic;

namespace Hippologamus.Server.Factorys
{
    public static class PageSizes
    {
        public static List<PageSize> Create()
        {
            return new List<PageSize>
            {
                new PageSize() { ShowPageSizeValue = 10, ShowPageSizeDescription = "Show 10" },
                new PageSize() { ShowPageSizeValue = 50, ShowPageSizeDescription = "Show 50" },
                new PageSize() { ShowPageSizeValue = 100, ShowPageSizeDescription = "Show 100" },
            };
        }
    }
}