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
    public class GoalPropertyController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public GoalPropertyController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/GoalProperty
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GoalProperty>>> GetGoalProperty()
        {
            return await _context.GoalProperty.ToListAsync();
        }

        // GET: api/GoalProperty/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GoalProperty>> GetGoalProperty(int id)
        {
            var goalProperty = await _context.GoalProperty.FindAsync(id);

            if (goalProperty == null)
            {
                return NotFound();
            }

            return goalProperty;
        }

        // PUT: api/GoalProperty/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGoalProperty(int id, [FromForm]GoalProperty goalProperty)
        {
            if (id != goalProperty.ID)
            {
                return BadRequest();
            }

            _context.Entry(goalProperty).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GoalPropertyExists(id))
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

        // POST: api/GoalProperty
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GoalProperty>> PostGoalProperty([FromForm]GoalProperty goalProperty)
        {
            _context.GoalProperty.Add(goalProperty);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGoalProperty", new { id = goalProperty.ID }, goalProperty);
        }

        // DELETE: api/GoalProperty/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GoalProperty>> DeleteGoalProperty(int id)
        {
            var goalProperty = await _context.GoalProperty.FindAsync(id);
            if (goalProperty == null)
            {
                return NotFound();
            }

            _context.GoalProperty.Remove(goalProperty);
            await _context.SaveChangesAsync();

            return goalProperty;
        }

        private bool GoalPropertyExists(int id)
        {
            return _context.GoalProperty.Any(e => e.ID == id);
        }
    }
}
