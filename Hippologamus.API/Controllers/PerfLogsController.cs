using Hippo.Serilog.Attributes;
using Hippologamus.API.Manager.Interface;
using Hippologamus.Data.Context;
using Hippologamus.DTO.DTO;
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
        /// Get details of 
        /// </summary>
        /// <param name="perfLogId"> The id of the items you you want</param>
        /// <returns></returns>
        [HttpGet("{perfLogId}", Name = "GetById")]
        [LogUsage("GetById")]
        public async Task<ActionResult<PerfLogDetails>> GetById(int perfLogId)
        {
            return await _perfLogManager.GetById(perfLogId);
        }
    }
}