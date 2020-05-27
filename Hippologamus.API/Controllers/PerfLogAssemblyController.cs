using Hippo.Serilog.Attributes;
using Hippologamus.API.Manager.Interface;
using Hippologamus.DTO.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippologamus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfLogAssemblyController : ControllerBase
    {
        private readonly IPerfLogAssemblyManager _perfLogAssemblyManager;

        public PerfLogAssemblyController(IPerfLogAssemblyManager perfLogAssemblyManager)
        {
            _perfLogAssemblyManager = perfLogAssemblyManager;
        }

        /// <summary>
        /// Gets all the assemblys perfomance logs
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [LogUsage("Get")]
        public async Task<ActionResult<IEnumerable<PerfLogAssemblyCollection>>> Get()
        {
            var perfLogs = await _perfLogAssemblyManager.GetAll();
            return Ok(perfLogs);
        }
    }
}