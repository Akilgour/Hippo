using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hippologamus.Data.Context;
using Hippologamus.Domain.Models;
using Hippologamus.API.Manager.Interface;
using Hippologamus.DTO.DTO;

namespace Hippologamus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailLogsController : ControllerBase
    {
        private readonly HippologamusContext _context;
        private readonly IPerflogManager _perfLogManager;

        public DetailLogsController(IPerflogManager perfLogManager)
        {
            _perfLogManager = perfLogManager ?? throw new ArgumentNullException(nameof(perfLogManager));
        }
 
        // GET: api/DetailLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PerfLogDisplay>>> GetDetailLogs()
        {
            return await _perfLogManager.GetAll();
        }


        //public async Task<ActionResult<IEnumerable<DetailLog>>> GetDetailLogs()
        //{
        //    return await _context.DetailLogs.ToListAsync();
        //}


        //// GET: api/DetailLogs/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<DetailLog>> GetDetailLog(int id)
        //{
        //    var detailLog = await _context.DetailLogs.FindAsync(id);

        //    if (detailLog == null)
        //    {
        //        return NotFound();
        //    }

        //    return detailLog;
        //}

        //// PUT: api/DetailLogs/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutDetailLog(int id, DetailLog detailLog)
        //{
        //    if (id != detailLog.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(detailLog).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DetailLogExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/DetailLogs
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<DetailLog>> PostDetailLog(DetailLog detailLog)
        //{
        //    _context.DetailLogs.Add(detailLog);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetDetailLog", new { id = detailLog.Id }, detailLog);
        //}

        //// DELETE: api/DetailLogs/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<DetailLog>> DeleteDetailLog(int id)
        //{
        //    var detailLog = await _context.DetailLogs.FindAsync(id);
        //    if (detailLog == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.DetailLogs.Remove(detailLog);
        //    await _context.SaveChangesAsync();

        //    return detailLog;
        //}

        //private bool DetailLogExists(int id)
        //{
        //    return _context.DetailLogs.Any(e => e.Id == id);
        //}
    }
}
