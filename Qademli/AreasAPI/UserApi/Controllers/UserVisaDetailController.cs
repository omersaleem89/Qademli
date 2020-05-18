using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Qademli;
using Qademli.Models.DatabaseModel;
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

        //// GET: api/UserVisaDetail
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<UserVisaDetail>>> GetUserVisaDetail()
        //{
        //    return await _context.UserVisaDetail.ToListAsync();
        //}

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
        public async Task<IActionResult> PutUserVisaDetail(int id, UserVisaDetail userVisaDetail)
        {
            if (id != userVisaDetail.ID)
            {
                return BadRequest();
            }

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
                string[] permittedExtensions = { ".jpg", ".jpeg", ".png", ".pdf" };
                var ext1 = Path.GetExtension(obj.Passport.FileName).ToLower();
                var ext2 = Path.GetExtension(obj.Recommendations.FileName).ToLower();
                var ext3 = Path.GetExtension(obj.I20Doc.FileName).ToLower();
                var ext4 = Path.GetExtension(obj.VisaPermit.FileName).ToLower();
                if ((obj.Passport == null
                    || obj.Recommendations == null
                    || obj.I20Doc == null
                    || obj.VisaPermit == null)
                    || (obj.Passport.Length == 0
                    || obj.Recommendations.Length == 0
                    || obj.I20Doc.Length == 0
                    || obj.VisaPermit.Length == 0)
                    || !permittedExtensions.Contains(ext1)
                    || !permittedExtensions.Contains(ext2)
                    || !permittedExtensions.Contains(ext3)
                    || !permittedExtensions.Contains(ext4))
                    return NotFound();
                UserVisaDetail userVisaDetail = new UserVisaDetail();
                userVisaDetail.UserID = obj.UserID;
                userVisaDetail.Passport = ImageHelper.UploadImageFile(_hostEnvironment,"wwwroot/Uploads/UserVisaDetail/Passport", obj.Passport);
                userVisaDetail.Recommendations = ImageHelper.UploadImageFile(_hostEnvironment, "wwwroot/Uploads/UserVisaDetail/Recommendations", obj.Recommendations);
                userVisaDetail.I20Doc = ImageHelper.UploadImageFile(_hostEnvironment, "wwwroot/Uploads/UserVisaDetail/I20Doc", obj.I20Doc);
                userVisaDetail.VisaPermit = ImageHelper.UploadImageFile(_hostEnvironment, "wwwroot/Uploads/UserVisaDetail/VisaPermit", obj.VisaPermit);
                userVisaDetail.DateFrom = obj.DateFrom;
                userVisaDetail.LastVisitToUS = obj.LastVisitToUS;
                userVisaDetail.DateTo = obj.DateTo;
                userVisaDetail.TravelDate = obj.TravelDate;
                userVisaDetail.CountriesVisted = obj.CountriesVisted;
                userVisaDetail.DaysSpentInUS = obj.DaysSpentInUS;
                userVisaDetail.Employee = obj.Employee;
                userVisaDetail.VisaPermitRejected = obj.VisaPermitRejected;
                userVisaDetail.ReasonOfRejection = obj.ReasonOfRejection;
                userVisaDetail.OrganizationName = obj.OrganizationName;
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

    public class UserVisaDetailUpsert
    {
        [Required]
        public int UserID { get; set; }
        public IFormFile Passport { get; set; }
        public IFormFile VisaPermit { get; set; }
        public IFormFile Recommendations { get; set; }
        public DateTime LastVisitToUS { get; set; }
        public int DaysSpentInUS { get; set; }
        public string CountriesVisted { get; set; }
        public IFormFile I20Doc { get; set; }
        public bool Employee { get; set; }
        public string OrganizationName { get; set; }
        public DateTime DateTo { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime TravelDate { get; set; }
        public bool VisaPermitRejected { get; set; }
        public string ReasonOfRejection { get; set; }
    }
}
