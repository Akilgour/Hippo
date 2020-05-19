using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Threading.Tasks;

namespace Demo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomErrorController : ControllerBase
    {

        [HttpGet]
        public Task<IActionResult> Get()
        {
            Log.Information("Information Log");
            Log.Error("Error Log");
            Log.Verbose("Verbose Log");
            Log.Fatal("Fatal Log");
            Log.Warning("Warning Log");
            Log.Debug("Debug Log");
            throw new Exception();
        }
    }
}