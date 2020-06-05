using Hippo.Serilog.Attributes;
using Hippologamus.API.Manager.Interface;
using Hippologamus.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippologamus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailLogsController : ControllerBase
    {
        private readonly IDetailLogManager _detailLogManager;

        public DetailLogsController(IDetailLogManager detailLogManager)
        {
            _detailLogManager = detailLogManager ?? throw new ArgumentNullException(nameof(detailLogManager));
        }

        /// <summary>
        /// Gets all the details logs
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [LogUsage("Get")]
        public async Task<ActionResult<IEnumerable<DetailLogCollection>>> Get()
        {
            var perfLogs = await _detailLogManager.GetAll();
            return Ok(perfLogs);
        }
    }
}