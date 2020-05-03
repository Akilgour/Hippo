using Demo.API.Manager;
using Demo.API.Models;
using Hippo.Serilog.Attributes;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Collections.Generic;

namespace Demo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeatleController : ControllerBase
    {
        private readonly BeatleManager _beatleManager;


        public BeatleController()
        {
            _beatleManager = new BeatleManager();
        }

        // GET: api/Beatle
        [HttpGet]
        [LogUsage("Get")]
        public IEnumerable<Beatle> Get()
        {
            Log.Debug("Got into Beatle - GET");
            return _beatleManager.GetAll();
        }

        // GET: api/Beatle/5
        [HttpGet("{id}", Name = "Get")]
        [LogUsage("GetById")]
        public Beatle Get(int id)
        {
            return _beatleManager.GetById(id);
        }
    }
}