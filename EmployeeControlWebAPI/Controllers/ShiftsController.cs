using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeControlWebAPI.Data;
using EmployeeControlWebAPI.Model;

namespace EmployeeControlWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftsController : ControllerBase
    {
        private readonly EmployeeControlWebAPIContext _context;

        public ShiftsController(EmployeeControlWebAPIContext context)
        {
            _context = context;
        }

        // GET: api/Shifts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shifts>>> GetShifts()
        {
          if (_context.Shifts == null)
          {
              return NotFound();
          }
            return await _context.Shifts.ToListAsync();
        }

        // GET: api/Shifts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shifts>> GetShifts(int id)
        {
          if (_context.Shifts == null)
          {
              return NotFound();
          }
            var shifts = await _context.Shifts.FindAsync(id);

            if (shifts == null)
            {
                return NotFound();
            }

            return shifts;
        }

        // PUT: api/Shifts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShifts(int id, Shifts shifts)
        {
            if (id != shifts.ShiftsId)
            {
                return BadRequest();
            }

            _context.Entry(shifts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShiftsExists(id))
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

        // POST: api/Shifts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Shifts>> PostShifts(Shifts shifts)
        {
          if (_context.Shifts == null)
          {
              return Problem("Entity set 'EmployeeControlWebAPIContext.Shifts'  is null.");
          }
            _context.Shifts.Add(shifts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShifts", new { id = shifts.ShiftsId }, shifts);
        }

        // DELETE: api/Shifts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShifts(int id)
        {
            if (_context.Shifts == null)
            {
                return NotFound();
            }
            var shifts = await _context.Shifts.FindAsync(id);
            if (shifts == null)
            {
                return NotFound();
            }

            _context.Shifts.Remove(shifts);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShiftsExists(int id)
        {
            return (_context.Shifts?.Any(e => e.ShiftsId == id)).GetValueOrDefault();
        }
    }
}
