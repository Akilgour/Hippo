using Hippo.Serilog.Attributes;
using Hippologamus.API.Manager.Interface;
using Hippologamus.DTO.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Hippologamus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorLogController : ControllerBase
    {
        private readonly IErrorLogManager _errorLogManager;

        public ErrorLogController(IErrorLogManager perfLogManager)
        {
            _errorLogManager = perfLogManager ?? throw new ArgumentNullException(nameof(perfLogManager));
        }


        [HttpGet(Name = "GetErrorLogs")]
        [LogUsage("Get")]
        public async Task<IActionResult> Get([FromQuery]  ErrorLogDisplaySearch errorLogDisplaySearch)
        {
            var perfLogs = await _errorLogManager.GetAllError(errorLogDisplaySearch);

            var paginationMetadata = new
            {
                totalCount = perfLogs.TotalCount,
                pageSize = perfLogs.PageSize,
                currentPage = perfLogs.CurrentPage,
                totalPages = perfLogs.TotalPages
            };
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));
            var links = CreateGetLinks(errorLogDisplaySearch, perfLogs.HasNext, perfLogs.HasPrevious);
            var perfLogsToReturn = new
            {
                value = perfLogs,
                links
            };

            return Ok(perfLogsToReturn);
        }


        private IEnumerable<LinkDto> CreateGetLinks(ErrorLogDisplaySearch errorLogDisplaySearch, bool hasNext, bool hasPrevious)
        {
            var links = new List<LinkDto>
            {
                new LinkDto(CreateGetLink(errorLogDisplaySearch, errorLogDisplaySearch.PageNumber), "self", "GET")
            };

            if (hasNext)
            {
                links.Add(new LinkDto(CreateGetLink(errorLogDisplaySearch, errorLogDisplaySearch.PageNumber + 1), "nextPage", "GET"));
            }

            if (hasPrevious)
            {
                links.Add(new LinkDto(CreateGetLink(errorLogDisplaySearch, errorLogDisplaySearch.PageNumber - 1), "previousPage", "GET"));
            }

            return links;
        }

        private string CreateGetLink(ErrorLogDisplaySearch errorLogDisplaySearch, int pageNumber)
        {
            return Url.Link("GetErrorLogs",
                new ErrorLogDisplaySearch()
                {
                    PageNumber = pageNumber,
                    PageSize = errorLogDisplaySearch.PageSize,
                    RequestPath = errorLogDisplaySearch.RequestPath,
                    Assembly = errorLogDisplaySearch.Assembly
                });
        }
    }
}