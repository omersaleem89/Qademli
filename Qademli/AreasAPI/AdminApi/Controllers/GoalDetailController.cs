using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Qademli.Models.DatabaseModel;

namespace Qademli.AreasAPI.AdminApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalDetailController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public GoalDetailController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/GoalDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GoalDetail>>> GetGoalDetail()
        {
            return await _context.GoalDetail.ToListAsync();
        }

        // GET: api/GoalDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GoalDetail>> GetGoalDetail(int id)
        {
            var goalDetail = await _context.GoalDetail.FindAsync(id);

            if (goalDetail == null)
            {
                return NotFound();
            }

            return goalDetail;
        }

        // PUT: api/GoalDetail/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGoalDetail(int id, GoalDetail goalDetail)
        {
            if (id != goalDetail.ID)
            {
                return BadRequest();
            }

            _context.Entry(goalDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GoalDetailExists(id))
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

        // POST: api/GoalDetail
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GoalDetail>> PostGoalDetail(GoalDetail goalDetail)
        {
            _context.GoalDetail.Add(goalDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGoalDetail", new { id = goalDetail.ID }, goalDetail);
        }

        // DELETE: api/GoalDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GoalDetail>> DeleteGoalDetail(int id)
        {
            var goalDetail = await _context.GoalDetail.FindAsync(id);
            if (goalDetail == null)
            {
                return NotFound();
            }

            _context.GoalDetail.Remove(goalDetail);
            await _context.SaveChangesAsync();

            return goalDetail;
        }

        private bool GoalDetailExists(int id)
        {
            return _context.GoalDetail.Any(e => e.ID == id);
        }
    }
}
