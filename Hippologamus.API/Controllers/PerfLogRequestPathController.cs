using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hippo.Serilog.Attributes;
using Hippologamus.API.Manager.Interface;
using Hippologamus.DTO.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hippologamus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfLogRequestPathController : ControllerBase
    {
        private readonly IPerfLogRequestPathManager _perfLogRequestPathManager;

        public PerfLogRequestPathController(IPerfLogRequestPathManager  perfLogRequestPathManager)
        {
            _perfLogRequestPathManager = perfLogRequestPathManager ?? throw new ArgumentNullException(nameof(perfLogRequestPathManager));
        }

        /// <summary>
        /// Gets all the perfomance logs RequestPaths for a assembly 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [LogUsage("GetByAssembly")]
        public async Task<ActionResult<IEnumerable<PerfLogRequestPathDisplay>>> GetByAssembly(string perfLogAssembly)
        {
            var perfLogRequestPathDisplays = await _perfLogRequestPathManager.GetByAssembly(perfLogAssembly);
            return Ok(perfLogRequestPathDisplays);
        }
    }
}