using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Qademli.Models.DatabaseModel;

namespace Qademli.AreasAPI.AdminApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public ApplicationController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/Application
        [HttpGet]
        public async Task<List<dynamic>> GetApplication()
        {
            var data = await _context.Application.ToListAsync();
            var list = new List<dynamic>();
            foreach (Application a in data) {
                list.Add(new
                {
                    a.ID,
                    a.GoalID,
                    a.StatusID,
                    a.TopicID,
                    a.UserID,
                    a.Comment,
                    a.Fee,
                    a.Currency,
                    a.Date,
                    Goal =  _context.Goal.FirstOrDefault(x => x.ID == a.GoalID).Name,
                    ApplicationStatus = _context.ApplicationStatus.FirstOrDefault(x => x.ID == a.StatusID).Name,
                    User = _context.User.FirstOrDefault(x => x.ID == a.UserID).Email,
                    Topic = _context.Topic.FirstOrDefault(x => x.ID == a.TopicID).Name
                });
            }

            return list;
        }

        // GET: api/Application/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Application>> GetApplication(int id)
        {
            var application = await _context.Application.FindAsync(id);

            if (application == null)
            {
                return NotFound();
            }

            return application;
        }

        // PUT: api/Application/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApplication(int id, [FromForm] ApplicationVM obj)
        {
            var application = _context.Application.FirstOrDefault(x => x.ID == id);
            application.Comment = obj.Comment;
            application.StatusID = obj.StatusID;

            _context.Entry(application).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationExists(id))
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

        // POST: api/Application
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Application>> PostApplication(Application application)
        {
            _context.Application.Add(application);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApplication", new { id = application.ID }, application);
        }

        // DELETE: api/Application/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Application>> DeleteApplication(int id)
        {
            var application = await _context.Application.FindAsync(id);
            if (application == null)
            {
                return NotFound();
            }

            _context.Application.Remove(application);
            await _context.SaveChangesAsync();

            return application;
        }

        private bool ApplicationExists(int id)
        {
            return _context.Application.Any(e => e.ID == id);
        }
    }
    public class ApplicationVM {
        [Required]
        public string Comment { get; set; }
        [Required]
        public int StatusID { get; set; }
    }
}
