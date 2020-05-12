using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Qademli;
using Qademli.Models.DatabaseModel;

namespace Qademli.AreasAPI.AdminApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public GoalController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/Goal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Goal>>> GetGoal()
        {
            return await _context.Goal.ToListAsync();
        }

        // GET: api/Goal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Goal>> GetGoal(int id)
        {
            var goal = await _context.Goal.FindAsync(id);

            if (goal == null)
            {
                return NotFound();
            }

            return goal;
        }

        // PUT: api/Goal/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGoal(int id, Goal goal)
        {
            if (id != goal.ID)
            {
                return BadRequest();
            }

            _context.Entry(goal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GoalExists(id))
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

        // POST: api/Goal
        [HttpPost]
        public async Task<ActionResult<Goal>> PostGoal(Goal goal)
        {
            _context.Goal.Add(goal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGoal", new { id = goal.ID }, goal);
        }

        // DELETE: api/Goal/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Goal>> DeleteGoal(int id)
        {
            var goal = await _context.Goal.FindAsync(id);
            if (goal == null)
            {
                return NotFound();
            }

            _context.Goal.Remove(goal);
            await _context.SaveChangesAsync();

            return goal;
        }

        private bool GoalExists(int id)
        {
            return _context.Goal.Any(e => e.ID == id);
        }
    }
}
