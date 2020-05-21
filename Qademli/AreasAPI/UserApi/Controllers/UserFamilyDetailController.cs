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
    public class UserFamilyDetailController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly UserFamilyDetailVM viewModel;


        public UserFamilyDetailController(ApplicationDBContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
            viewModel = new UserFamilyDetailVM(_hostEnvironment);
        }

        // GET: api/UserFamilyDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserFamilyDetail>>> GetUserFamilyDetail()
        {
            return await _context.UserFamilyDetail.ToListAsync();
        }

        // GET: api/UserFamilyDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserFamilyDetail>> GetUserFamilyDetail(int id)
        {
            var userFamilyDetail = await _context.UserFamilyDetail.FindAsync(id);

            if (userFamilyDetail == null)
            {
                return NotFound();
            }

            return userFamilyDetail;
        }

        // PUT: api/UserFamilyDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserFamilyDetail(int id, [FromForm] UserFamilyDetailUpsert obj)
        {
            UserFamilyDetail userFamilyDetail = await _context.UserFamilyDetail.FirstOrDefaultAsync(x => x.UserID == obj.UserID);
            userFamilyDetail = viewModel.Update(userFamilyDetail, obj);

            _context.Entry(userFamilyDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserFamilyDetailExists(id))
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

        // POST: api/UserFamilyDetail

        [HttpPost]
        public async Task<ActionResult<UserFamilyDetail>> PostUserFamilyDetail([FromForm]UserFamilyDetailUpsert obj)
        {
            UserFamilyDetail userFamilyDetail = viewModel.Add(obj);
            _context.UserFamilyDetail.Add(userFamilyDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserFamilyDetail", new { id = userFamilyDetail.ID }, userFamilyDetail);
        }

        // DELETE: api/UserFamilyDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserFamilyDetail>> DeleteUserFamilyDetail(int id)
        {
            var userFamilyDetail = await _context.UserFamilyDetail.FindAsync(id);
            if (userFamilyDetail == null)
            {
                return NotFound();
            }
            viewModel.Delete(userFamilyDetail);
            _context.UserFamilyDetail.Remove(userFamilyDetail);
            await _context.SaveChangesAsync();

            return userFamilyDetail;
        }

        private bool UserFamilyDetailExists(int id)
        {
            return _context.UserFamilyDetail.Any(e => e.ID == id);
        }
    }
}
