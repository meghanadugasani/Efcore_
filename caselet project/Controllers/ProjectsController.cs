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
    public class ProjectController : ControllerBase
    {
        private readonly ProjectContext _context;

        public ProjectController(ProjectContext context)
        {
            _context = context;
        }

        // GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetAllProjects()
        {
            return await _context.Projects.ToListAsync();
        }

        // POST
        [HttpPost]
        public async Task<ActionResult<Project>> PostProject(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProject), new { id = project.ProjectId }, project);
        }

        // GET by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
                return NotFound();
            return project;
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(int id, Project project)
        {
            if (id != project.ProjectId)
                return BadRequest();

            _context.Entry(project).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Projects.Any(p => p.ProjectId == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE
        [HttpDelete("DeleteAll")]
        public async Task<IActionResult> DeleteAllProjects()
        {
            var projects = await _context.Projects.ToListAsync();
            if (!projects.Any())
                return NotFound("No projects to delete.");

            _context.Projects.RemoveRange(projects);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
