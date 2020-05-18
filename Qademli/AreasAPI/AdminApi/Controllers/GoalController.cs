using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Qademli;
using Qademli.Models.DatabaseModel;
using Qademli.Models.ViewModel;

namespace Qademli.AreasAPI.AdminApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly GoalVM viewModel;


        public GoalController(ApplicationDBContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
            viewModel = new GoalVM(_hostEnvironment);
        }

        // GET: api/Goal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Goal>>> GetGoal()
        {

            return await _context.Goal.ToListAsync();
        }

        // GET: api/Goal/GetGoalWithTopic
        [HttpGet("GetGoalWithTopic")]
        public async Task<ActionResult<IEnumerable<GoalTopic>>> GetGoalWithTopic()
        {
            var goals = await _context.Goal.ToListAsync();
            var goalList = new List<GoalTopic>();
            foreach (Goal g in goals)
            {
                GoalTopic goalTopic = new GoalTopic
                {
                    ID = g.ID,
                    Image = g.Image,
                    Name = g.Name,
                    Fee = g.Fee,
                    Currency = g.Currency,
                    TopicID = g.TopicID,
                    TopicName = _context.Topic.FirstOrDefault(x => x.ID == g.TopicID).Name
                };
                goalList.Add(goalTopic);
            }
            return goalList;
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
        public async Task<IActionResult> PutGoal(int id, [FromForm]GoalUpsert obj)
        {
            Goal goal = await _context.Goal.FirstOrDefaultAsync(x => x.ID == id);
            goal = viewModel.Update(goal, obj);

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
        public async Task<ActionResult<Goal>> PostGoal([FromForm] GoalUpsert obj)
        {
            if (ModelState.IsValid)
            {
                Goal goal = viewModel.Add(obj);
                _context.Goal.Add(goal);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetGoal", new { id = goal.ID }, goal);
            }
            else
                return ValidationProblem();
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
            viewModel.Delete(goal);
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
