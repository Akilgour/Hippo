using System.Collections.Generic;

namespace Hippologamus.Server.Models
{
    public class BasePagedList
    {
        public List<Links> Links { get; set; }
        public int PaginationTotalCount { get; set; }
        public int PaginationPageSize { get; set; }
        public int PaginationCurrentPage { get; set; }
        public int PaginationTotalPages { get; set; }
        public bool ShowPerviousPageButton { get; internal set; }
        public bool ShowNextPageButton { get; internal set; }
        public int PaginationCurrentPagePlusOne { get; internal set; }
        public int PaginationCurrentPageMinusOne { get; internal set; }
        public bool ShowFirstPageButton { get; internal set; }
        public bool ShowSecondPageButton { get; internal set; }
    }
}
