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
        public async Task<ActionResult<List<Shifts>>> GetShifts(int id)
        {
          if (_context.Shifts == null)
          {
              return NotFound();
          }
            var shifts = await _context.Shifts.Where(e => e.EmployeesId == id).ToListAsync();

            if (shifts == null)
            {
                return NotFound();
            }

            return shifts;
        }

        [HttpPost("StartTime")]
        public async Task<ActionResult<Shifts>> PostStartShifts(int id, DateTime startTimeJob)
        {
            var employees = await _context.Employees.FindAsync(id);
            if (employees == null)
            {
                return NotFound();
            }

            var shiftCheck = await _context.Shifts.FirstOrDefaultAsync(e => e.EmployeesId == id && e.StartTime == null);
            if (shiftCheck == null)
            {
                return NotFound("Сотрудник уже на смене.");
            }


            shiftCheck.StartTime = startTimeJob;
            await _context.SaveChangesAsync();
            return Ok();

        }

        [HttpPost("EndShifts")]
        public async Task<ActionResult<Shifts>> PostEndShifts(int id, DateTime endTimeJob)
        {
            var employees = await _context.Employees.FindAsync(id);
            if (employees == null)
            {
                return NotFound();
            }

            var shiftCheck = await _context.Shifts.FirstOrDefaultAsync(e => e.EmployeesId == id && e.EndTime == null);
            if (shiftCheck == null)
            {
                return NotFound("Смена уже закончена.");
            }
            if(shiftCheck.StartTime >= endTimeJob)
            {
                return BadRequest("Ошибка времени смены!");
            }
            if(shiftCheck.StartTime == null)
            {
                return BadRequest("Смена еще не начилась.");
            }

            shiftCheck.EndTime = endTimeJob;
            var timeJob = endTimeJob - shiftCheck.StartTime;
            shiftCheck.QuantityHoursWorked = (int)timeJob.Value.TotalHours;
            await _context.SaveChangesAsync();
            return Ok();

        }

        // DELETE: api/Shifts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShifts(int id)
        {

            var employees = await _context.Shifts.FirstOrDefaultAsync(e => e.EmployeesId == id);
            if (employees == null)
            {
                return NotFound();
            }

            employees.StartTime = null;
            employees.EndTime = null;
            employees.QuantityHoursWorked = 0;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShiftsExists(int id)
        {
            return (_context.Shifts?.Any(e => e.ShiftsId == id)).GetValueOrDefault();
        }
    }
}
