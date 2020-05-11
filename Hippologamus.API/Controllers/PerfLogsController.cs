using Hippo.Serilog.Attributes;
using Hippologamus.API.Manager.Interface;
using Hippologamus.DTO.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        [HttpGet]
        [LogUsage("Get")]
        public async Task<ActionResult<IEnumerable<PerfLogDisplay>>> Get()
        {
            return await _perfLogManager.GetAll();
        }

        /// <summary>
        /// Get Perof log by Id
        /// </summary>
        /// <param name="perfLogId">The Id of the item you want</param>
        /// <returns></returns>
        [HttpGet("{perfLogId}", Name = "GetById")]
        [LogUsage("GetById")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
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