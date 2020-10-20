using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalAPI.Models;

namespace FinalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TotalBloodsController : ControllerBase
    {
        private readonly inventoryContext _context;

        public TotalBloodsController(inventoryContext context)
        {
            _context = context;
        }

        // GET: api/TotalBloods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TotalBlood>>> GetTotalBlood()
        {
            return await _context.TotalBlood.ToListAsync();
        }

        // GET: api/TotalBloods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TotalBlood>> GetTotalBlood(int? id)
        {
            var totalBlood = await _context.TotalBlood.FindAsync(id);

            if (totalBlood == null)
            {
                return NotFound();
            }

            return totalBlood;
        }

        // PUT: api/TotalBloods/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTotalBlood(int? id, TotalBlood totalBlood)
        {
            if (id != totalBlood.DonorId)
            {
                return BadRequest();
            }

            _context.Entry(totalBlood).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TotalBloodExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TotalBloods
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TotalBlood>> PostTotalBlood(TotalBlood totalBlood)
        {
            _context.TotalBlood.Add(totalBlood);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TotalBloodExists(totalBlood.DonorId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTotalBlood", new { id = totalBlood.DonorId }, totalBlood);
        }

        // DELETE: api/TotalBloods/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TotalBlood>> DeleteTotalBlood(int? id)
        {
            var totalBlood = await _context.TotalBlood.FindAsync(id);
            if (totalBlood == null)
            {
                return NotFound();
            }

            _context.TotalBlood.Remove(totalBlood);
            await _context.SaveChangesAsync();

            return totalBlood;
        }

        private bool TotalBloodExists(int? id)
        {
            return _context.TotalBlood.Any(e => e.DonorId == id);
        }
    }
}
