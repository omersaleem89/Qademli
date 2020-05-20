using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Qademli.Models.DatabaseModel;
using Qademli.Models.ViewModel;

namespace Qademli.AreasAPI.UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPersonalDetailController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly UserPersonalDetailVM viewModel;


        public UserPersonalDetailController(ApplicationDBContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
            viewModel = new UserPersonalDetailVM(_hostEnvironment);
        }


        // GET: api/UserPersonalDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserPersonalDetail>>> GetUserPersonalDetail()
        {
            return await _context.UserPersonalDetail.ToListAsync();
        }

        // GET: api/UserPersonalDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserPersonalDetail>> GetUserPersonalDetail(int id)
        {
            var userPersonalDetail = await _context.UserPersonalDetail.FindAsync(id);

            if (userPersonalDetail == null)
            {
                return NotFound();
            }

            return userPersonalDetail;
        }

        // PUT: api/UserPersonalDetail/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserPersonalDetail(int id, [FromForm]UserPersonalDetailUpsert obj)
        {
            

            UserPersonalDetail userPersonalDetail = await _context.UserPersonalDetail.FirstOrDefaultAsync(x => x.UserID == obj.UserID);
            userPersonalDetail = viewModel.Update(userPersonalDetail, obj);

            _context.Entry(userPersonalDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserPersonalDetailExists(id))
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

        // POST: api/UserPersonalDetail
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserPersonalDetail>> PostUserPersonalDetail([FromForm]UserPersonalDetailUpsert obj)
        {
            UserPersonalDetail userPersonalDetail = viewModel.Add(obj);
            _context.UserPersonalDetail.Add(userPersonalDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserPersonalDetail", new { id = userPersonalDetail.ID }, userPersonalDetail);
        }

        // DELETE: api/UserPersonalDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserPersonalDetail>> DeleteUserPersonalDetail(int id)
        {
            var userPersonalDetail = await _context.UserPersonalDetail.FindAsync(id);
            if (userPersonalDetail == null)
            {
                return NotFound();
            }
            viewModel.Delete(userPersonalDetail);
            _context.UserPersonalDetail.Remove(userPersonalDetail);
            await _context.SaveChangesAsync();

            return userPersonalDetail;
        }

        private bool UserPersonalDetailExists(int id)
        {
            return _context.UserPersonalDetail.Any(e => e.ID == id);
        }
    }
}
