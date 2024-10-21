using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RNRAPP.Data;
using RNRAPP.Models;

namespace RNRAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreakdownController : ControllerBase
    {
        private readonly BreakdownDbContext _breakdownDbContext;
        private readonly ILogger<BreakdownController> _logger;

        public BreakdownController(BreakdownDbContext breakdownDbContext, ILogger<BreakdownController> logger)
        {
            _breakdownDbContext = breakdownDbContext;
            _logger = logger;
        }

        // GET: api/Breakdown/GetBreakdown
        [HttpGet]
        [Route("GetBreakdown")]
        public async Task<ActionResult<IEnumerable<Breakdown>>> GetBreakdowns()
        {
            _logger.LogInformation("Getting all breakdowns");
            var breakdowns = await _breakdownDbContext.Breakdowns.ToListAsync();
            return Ok(breakdowns);
        }

        // POST: api/Breakdown/AddBreakdown
        [HttpPost]
        [Route("AddBreakdown")]
        public async Task<ActionResult<Breakdown>> AddBreakdown(Breakdown objBreakdown)
        {
            _logger.LogInformation("Adding a new breakdown");
            _breakdownDbContext.Breakdowns.Add(objBreakdown);
            await _breakdownDbContext.SaveChangesAsync();
            return CreatedAtAction("GetBreakdown", new { id = objBreakdown.Id }, objBreakdown);
        }

        // PATCH: api/Breakdown/UpdateBreakdown/{id}
        [HttpPatch]
        [Route("UpdateBreakdown/{id}")]
        public async Task<ActionResult<Breakdown>> UpdateBreakdown(int id, Breakdown objBreakdown)
        {
            if (id != objBreakdown.Id)
            {
                _logger.LogWarning("Update request with mismatched ID");
                return BadRequest();
            }

            _logger.LogInformation("Updating breakdown with ID: {Id}", id);
            _breakdownDbContext.Entry(objBreakdown).State = EntityState.Modified;

            try
            {
                await _breakdownDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BreakdownExists(id))
                {
                    _logger.LogWarning("Breakdown with ID: {Id} not found", id);
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Breakdown/DeleteBreakdown/{id}
        [HttpDelete]
        [Route("DeleteBreakdown/{id}")]
        public async Task<IActionResult> DeleteBreakdown(int id)
        {
            _logger.LogInformation("Attempting to delete breakdown with ID: {Id}", id);
            var breakdown = await _breakdownDbContext.Breakdowns.FindAsync(id);
            if (breakdown == null)
            {
                _logger.LogWarning("Breakdown with ID: {Id} not found", id);
                return NotFound();
            }

            _breakdownDbContext.Breakdowns.Remove(breakdown);
            await _breakdownDbContext.SaveChangesAsync();
            _logger.LogInformation("Deleted breakdown with ID: {Id}", id);

            return NoContent();
        }

        private bool BreakdownExists(int id)
        {
            return _breakdownDbContext.Breakdowns.Any(e => e.Id == id);
        }
    }
}
