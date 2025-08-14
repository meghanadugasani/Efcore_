using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Apidbfirstassign.Models;
using EmployeeProjectTrackerAPI.Data;

namespace Apidbfirstassign.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ProjectContext _context;

        public EmployeeController(ProjectContext context)
        {
            _context = context;
        }

        // GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        // POST
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployee), new { id = employee.EmployeeId }, employee);
        }

        // GET by ID 
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                return NotFound();
            return employee;
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
                return BadRequest();

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Employees.Any(e => e.EmployeeId == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE
        [HttpDelete("DeleteAll")]
        public async Task<IActionResult> DeleteAllEmployees()
        {
            var employees = await _context.Employees.ToListAsync();
            if (!employees.Any())
                return NotFound("No employees to delete.");

            _context.Employees.RemoveRange(employees);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
