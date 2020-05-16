using Hippologamus.DTO.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Hippologamus.API.Factorys
{
    public class CreateLinksForPerfLogs : ControllerBase
    {
        public IEnumerable<LinkDto> Create(PerfLogDisplaySearch perfLogDisplaySearch, bool hasNext, bool hasPrevious)
        {
            var links = new List<LinkDto>
            {
                new LinkDto(CreateLinks(perfLogDisplaySearch, perfLogDisplaySearch.PageNumber), "self", "GET")
            };

            if (hasNext)
            {
                links.Add(new LinkDto(CreateLinks(perfLogDisplaySearch, perfLogDisplaySearch.PageNumber + 1), "nextPage", "GET"));
            }

            if (hasPrevious)
            {
                links.Add(new LinkDto(CreateLinks(perfLogDisplaySearch, perfLogDisplaySearch.PageNumber - 1), "previousPage", "GET"));
            }

            return links;
        }

        private string CreateLinks(PerfLogDisplaySearch perfLogDisplaySearch, int pageNumber)
        {
            return Url.Link("GetPerfLogs",
                new
                {
                    pageNumber = pageNumber,
                    pageSize = perfLogDisplaySearch.PageSize,
                    assembly = perfLogDisplaySearch.Assembly,
                    perfItem = perfLogDisplaySearch.PerfItem
                });
        }
    }
}