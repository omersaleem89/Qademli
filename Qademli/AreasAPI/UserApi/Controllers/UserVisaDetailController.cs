using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Qademli.Models.DatabaseModel;
using Qademli.Models.ViewModel;
using Qademli.Utility;

namespace Qademli.AreasAPI.UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserVisaDetailController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public UserVisaDetailController(ApplicationDBContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: api/UserVisaDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserVisaDetail>> GetUserVisaDetail(int id)
        {
            var userVisaDetail = await _context.UserVisaDetail.FindAsync(id);

            if (userVisaDetail == null)
            {
                return NotFound();
            }

            return userVisaDetail;
        }

        // PUT: api/UserVisaDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserVisaDetail(int id, [FromForm]UserVisaDetailUpsert obj)
        {
            
            UserVisaDetail userVisaDetail = await _context.UserVisaDetail.FirstOrDefaultAsync(x => x.UserID == obj.UserID);
            userVisaDetail = new UserVisaDetailVM(_hostEnvironment).Update(userVisaDetail,obj);
            _context.Entry(userVisaDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserVisaDetailExists(id))
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

        // POST: api/UserVisaDetail
        [HttpPost]
        public async Task<ActionResult<UserVisaDetail>> PostUserVisaDetail([FromForm]UserVisaDetailUpsert obj)
        {
            if (ModelState.IsValid)
            {
                UserVisaDetail userVisaDetail = new UserVisaDetailVM(_hostEnvironment).Add(obj);
                _context.UserVisaDetail.Add(userVisaDetail);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetUserVisaDetail", new { id = userVisaDetail.ID }, userVisaDetail);
            }
            else
                return ValidationProblem();
        }

        // DELETE: api/UserVisaDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserVisaDetail>> DeleteUserVisaDetail(int id)
        {
            var userVisaDetail = await _context.UserVisaDetail.FindAsync(id);
            if (userVisaDetail == null)
            {
                return NotFound();
            }
            if (!string.IsNullOrEmpty(userVisaDetail.Passport)){
                ImageHelper.DeleteImage(_hostEnvironment, @"Uploads\UserVisaDetail\Passport", userVisaDetail.Passport.Replace("/Uploads/UserVisaDetail/Passport/", ""));
            }
            if (!string.IsNullOrEmpty(userVisaDetail.Recommendations))
            {
                ImageHelper.DeleteImage(_hostEnvironment, @"Uploads\UserVisaDetail\Recommendations", userVisaDetail.Recommendations.Replace("/Uploads/UserVisaDetail/Recommendations/", ""));
            }
            if (!string.IsNullOrEmpty(userVisaDetail.VisaPermit))
            {
                ImageHelper.DeleteImage(_hostEnvironment, @"Uploads\UserVisaDetail\VisaPermit", userVisaDetail.VisaPermit.Replace("/Uploads/UserVisaDetail/VisaPermit/", ""));
            }
            if (!string.IsNullOrEmpty(userVisaDetail.I20Doc))
            {
                ImageHelper.DeleteImage(_hostEnvironment, @"Uploads\UserVisaDetail\I20Doc", userVisaDetail.I20Doc.Replace("/Uploads/UserVisaDetail/I20Doc/", ""));
            }

            _context.UserVisaDetail.Remove(userVisaDetail);
            await _context.SaveChangesAsync();

            return userVisaDetail;
        }

        private bool UserVisaDetailExists(int id)
        {
            return _context.UserVisaDetail.Any(e => e.ID == id);
        }
    }

   
}
