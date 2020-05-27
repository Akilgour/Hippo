using Hippo.Serilog.Attributes;
using Hippologamus.API.Manager.Interface;
using Hippologamus.DTO.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippologamus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfLogPerformanceItemController : ControllerBase
    {
        private readonly IPerfLogPerformanceItemManager _perfLogPerformanceItemManager;

        public PerfLogPerformanceItemController(IPerfLogPerformanceItemManager perfLogPerformanceItemManager)
        {
            _perfLogPerformanceItemManager = perfLogPerformanceItemManager ?? throw new ArgumentNullException(nameof(perfLogPerformanceItemManager));
        }

        /// <summary>
        /// Gets all the perfomance logs performanceItem for a assembly 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [LogUsage("GetByAssembly")]
        public async Task<ActionResult<IEnumerable<PerfLogPerformanceItemCollection>>> GetByAssembly(string perfLogAssembly)
        {
            var perfLogPerformanceItemDisplays = await _perfLogPerformanceItemManager.GetByAssembly(perfLogAssembly);
            return Ok(perfLogPerformanceItemDisplays);
        }
    }
}