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
    public class UserVisaDetailController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly UserVisaDetailVM viewModel;
        public UserVisaDetailController(ApplicationDBContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
            viewModel = new UserVisaDetailVM(_hostEnvironment);
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
            userVisaDetail = viewModel.Update(userVisaDetail,obj);
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
                UserVisaDetail userVisaDetail = viewModel.Add(obj);
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
            viewModel.Delete(userVisaDetail);

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
