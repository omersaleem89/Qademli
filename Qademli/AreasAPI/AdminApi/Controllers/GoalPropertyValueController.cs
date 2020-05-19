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
    public class GoalPropertyValueController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public GoalPropertyValueController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/GoalPropertyValue
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GoalPropertyValue>>> GetGoalPropertyValue()
        {
            return await _context.GoalPropertyValue.ToListAsync();
        }

        // GET: api/GoalPropertyValue/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GoalPropertyValue>> GetGoalPropertyValue(int id)
        {
            var goalPropertyValue = await _context.GoalPropertyValue.FindAsync(id);

            if (goalPropertyValue == null)
            {
                return NotFound();
            }

            return goalPropertyValue;
        }

        // PUT: api/GoalPropertyValue/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGoalPropertyValue(int id, [FromForm]GoalPropertyUpsert obj)
        {
            if (id != obj.ID)
            {
                return BadRequest();
            }
            GoalPropertyValue goalPropertyValue = new GoalPropertyValue()
            {
                GoalPropertyID = obj.GoalPropertyID,
                ID = obj.ID,
                Name = obj.Name
            };

            _context.Entry(new GoalDetail()
            {
                ID = obj.GoalDetailID,
                GoalPropertyID = obj.GoalPropertyID,
                GoalID = obj.GoalID
            }).State = EntityState.Modified;
            _context.Entry(goalPropertyValue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GoalPropertyValueExists(id))
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

        // POST: api/GoalPropertyValue
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GoalPropertyValue>> PostGoalPropertyValue([FromForm]GoalPropertyUpsert obj)
        {
            var check = _context.GoalDetail.FirstOrDefault(x => x.GoalID == obj.GoalID && x.GoalPropertyID == obj.GoalPropertyID);
            if (check == null)
                _context.GoalDetail.Add(new GoalDetail()
                {
                    GoalID=obj.GoalID,
                    GoalPropertyID = obj.GoalPropertyID
                });
            GoalPropertyValue goalPropertyValue = new GoalPropertyValue()
            {
                GoalPropertyID=obj.GoalPropertyID,
                Name = obj.Name
            };
            _context.GoalPropertyValue.Add(goalPropertyValue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGoalPropertyValue", new { id = goalPropertyValue.ID }, goalPropertyValue);
        }

        // DELETE: api/GoalPropertyValue/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GoalPropertyValue>> DeleteGoalPropertyValue(int id)
        {
            var goalPropertyValue = await _context.GoalPropertyValue.FindAsync(id);
            if (goalPropertyValue == null)
            {
                return NotFound();
            }

            _context.GoalPropertyValue.Remove(goalPropertyValue);
            await _context.SaveChangesAsync();

            return goalPropertyValue;
        }

        private bool GoalPropertyValueExists(int id)
        {
            return _context.GoalPropertyValue.Any(e => e.ID == id);
        }
    }

    public class GoalPropertyUpsert {
        public int ID { get; set; }
        public int GoalPropertyID { get; set; }
        public int GoalID { get; set; }
        public string Name { get; set; }
        public int GoalDetailID { get; set; }
    }
}
