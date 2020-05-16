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
    public class PerfLogsController : ControllerBase
    {
        private readonly IPerflogManager _perfLogManager;

        public PerfLogsController(IPerflogManager perfLogManager)
        {
            _perfLogManager = perfLogManager ?? throw new ArgumentNullException(nameof(perfLogManager));
        }

        /// <summary>
        /// Gets all the perfomance logs
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetPerfLogs")]
        [LogUsage("Get")]
        public async Task<ActionResult<IEnumerable<PerfLogDisplay>>> Get([FromQuery]  PerfLogDisplaySearch perfLogDisplaySearch)
        {
            var perfLogs = await _perfLogManager.GetAll(perfLogDisplaySearch);

            var paginationMetadata = new
            {
                totalCount = perfLogs.TotalCount,
                pageSize = perfLogs.PageSize,
                currentPage = perfLogs.CurrentPage,
                totalPages = perfLogs.TotalPages
            };
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));
            var links = CreateGetLinks(perfLogDisplaySearch, perfLogs.HasNext, perfLogs.HasPrevious);
            var perfLogsToReturn = new
            {
                value = perfLogs,
                links
            };

            return Ok(perfLogsToReturn);
        }


        private IEnumerable<LinkDto> CreateGetLinks(PerfLogDisplaySearch perfLogDisplaySearch, bool hasNext, bool hasPrevious)
        {
            var links = new List<LinkDto>
            {
                new LinkDto(CreateGetLink(perfLogDisplaySearch, perfLogDisplaySearch.PageNumber), "self", "GET")
            };

            if (hasNext)
            {
                links.Add(new LinkDto(CreateGetLink(perfLogDisplaySearch, perfLogDisplaySearch.PageNumber + 1), "nextPage", "GET"));
            }

            if (hasPrevious)
            {
                links.Add(new LinkDto(CreateGetLink(perfLogDisplaySearch, perfLogDisplaySearch.PageNumber - 1), "previousPage", "GET"));
            }

            return links;
        }

        private string CreateGetLink(PerfLogDisplaySearch perfLogDisplaySearch, int pageNumber)
        {
            return Url.Link("GetPerfLogs",
                new PerfLogDisplaySearch()
                {
                    PageNumber = pageNumber,
                    PageSize = perfLogDisplaySearch.PageSize,
                    Assembly = perfLogDisplaySearch.Assembly,
                    PerfItem = perfLogDisplaySearch.PerfItem
                });
        }


        /// <summary>
        /// Get Perof log by Id
        /// </summary>
        /// <param name="perfLogId">The Id of the item you want</param>
        /// <returns></returns>
        [HttpGet("{perfLogId}", Name = "GetById")]
        public async Task<ActionResult<PerfLogDetails>> GetById(int perfLogId)
        {
            var perfLog = await _perfLogManager.GetById(perfLogId);
            if (perfLog == null)
            {
                return NotFound();
            }
            return Ok(perfLog);
        }
    }
}