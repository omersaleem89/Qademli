using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Qademli.Models.DatabaseModel;
using Qademli.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Qademli.Models.ViewModel
{
    public class UserVisaDetailVM
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        public UserVisaDetailVM(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        public UserVisaDetail Add(UserVisaDetailUpsert obj)
        {
            string[] permittedExtensions = { ".jpg", ".jpeg", ".png", ".pdf" };
            UserVisaDetail userVisaDetail = new UserVisaDetail();
            var ext1 = Path.GetExtension(obj.Passport.FileName);
            var ext2 = Path.GetExtension(obj.Recommendations.FileName);
            var ext3 = Path.GetExtension(obj.I20Doc.FileName);
            var ext4 = Path.GetExtension(obj.VisaPermit.FileName);
            if ((obj.Passport != null && permittedExtensions.Contains(ext1)))
            {
                userVisaDetail.Passport = ImageHelper.UploadImageFile("wwwroot/Uploads/UserVisaDetail/Passport", obj.Passport);
            }
            if ((obj.Recommendations != null && permittedExtensions.Contains(ext2)))
            {
                userVisaDetail.Recommendations = ImageHelper.UploadImageFile("wwwroot/Uploads/UserVisaDetail/Recommendations", obj.Recommendations);
            }
            if ((obj.I20Doc != null && permittedExtensions.Contains(ext3)))
            {
                userVisaDetail.I20Doc = ImageHelper.UploadImageFile("wwwroot/Uploads/UserVisaDetail/I20Doc", obj.I20Doc);
            }
            if ((obj.VisaPermit != null && permittedExtensions.Contains(ext4)))
            {
                userVisaDetail.VisaPermit = ImageHelper.UploadImageFile("wwwroot/Uploads/UserVisaDetail/VisaPermit", obj.VisaPermit);
            }
            
            userVisaDetail.UserID = obj.UserID;
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
            return userVisaDetail;
        }

        public UserVisaDetail Update(UserVisaDetail userVisaDetail, UserVisaDetailUpsert obj){
            string[] permittedExtensions = { ".jpg", ".jpeg", ".png", ".pdf" };
            userVisaDetail.VisaPermitRejected = obj.VisaPermitRejected;
            userVisaDetail.ReasonOfRejection = obj.ReasonOfRejection;
            userVisaDetail.OrganizationName = obj.OrganizationName;
            userVisaDetail.LastVisitToUS = obj.LastVisitToUS;
            userVisaDetail.DateFrom = obj.DateFrom;
            userVisaDetail.DateTo = obj.DateTo;
            userVisaDetail.DaysSpentInUS = obj.DaysSpentInUS;
            userVisaDetail.CountriesVisted = obj.CountriesVisted;
            if (obj.Passport != null)
            {
                var ext = Path.GetExtension(obj.Passport.FileName);
                if (permittedExtensions.Contains(ext))
                {
                    ImageHelper.DeleteImage(_hostEnvironment, @"Uploads\UserVisaDetail\Passport", userVisaDetail.Passport.Replace("/Uploads/UserVisaDetail/Passport/", ""));
                    userVisaDetail.Passport = ImageHelper.UploadImageFile("wwwroot/Uploads/UserVisaDetail/Passport", obj.Passport);
                }
            }
            if (obj.Recommendations != null)
            {
                var ext = Path.GetExtension(obj.Recommendations.FileName);
                if (permittedExtensions.Contains(ext))
                {
                    ImageHelper.DeleteImage(_hostEnvironment, @"Uploads\UserVisaDetail\Recommendations", userVisaDetail.Recommendations.Replace("/Uploads/UserVisaDetail/Recommendations/", ""));
                    userVisaDetail.Recommendations = ImageHelper.UploadImageFile("wwwroot/Uploads/UserVisaDetail/Recommendations", obj.Recommendations);
                }
            }
            if (obj.I20Doc != null)
            {
                var ext = Path.GetExtension(obj.I20Doc.FileName);
                if (permittedExtensions.Contains(ext))
                {
                    ImageHelper.DeleteImage(_hostEnvironment, @"Uploads\UserVisaDetail\I20Doc", userVisaDetail.I20Doc.Replace("/Uploads/UserVisaDetail/I20Doc/", ""));
                    userVisaDetail.I20Doc = ImageHelper.UploadImageFile("wwwroot/Uploads/UserVisaDetail/I20Doc", obj.I20Doc);
                }
            }
            if (obj.VisaPermit != null)
            {
                var ext = Path.GetExtension(obj.VisaPermit.FileName);
                if (permittedExtensions.Contains(ext))
                {
                    ImageHelper.DeleteImage(_hostEnvironment, @"Uploads\UserVisaDetail\VisaPermit", userVisaDetail.VisaPermit.Replace("/Uploads/UserVisaDetail/VisaPermit/", ""));
                    userVisaDetail.VisaPermit = ImageHelper.UploadImageFile("wwwroot/Uploads/UserVisaDetail/VisaPermit", obj.VisaPermit);
                }
            }
            return userVisaDetail;
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
