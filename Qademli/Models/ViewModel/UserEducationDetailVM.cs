using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Qademli.Models.DatabaseModel;
using Qademli.Utility;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace Qademli.Models.ViewModel
{
    public class UserEducationDetailVM
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        public UserEducationDetailVM(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }
        public UserEducationDetail Add(UserEducationDetailUpsert obj)
        {
            string[] permittedExtensions = { ".jpg", ".jpeg", ".png", ".pdf" };
            UserEducationDetail userEducationDetail = new UserEducationDetail();
            var ext1 = Path.GetExtension(obj.HighSchoolDegree.FileName);
            var ext2 = Path.GetExtension(obj.MinistryofHigherEducationDoc.FileName);
            var ext3 = Path.GetExtension(obj.FinancialSupport.FileName);
            if ((obj.HighSchoolDegree != null && permittedExtensions.Contains(ext1)))
            {
                userEducationDetail.HighSchoolDegree = ImageHelper.UploadImageFile(_hostEnvironment, "wwwroot/Uploads/UserEducationDetail/HighSchoolDegree", obj.HighSchoolDegree);
            }
            if ((obj.MinistryofHigherEducationDoc != null && permittedExtensions.Contains(ext2)))
            {
                userEducationDetail.MinistryofHigherEducationDoc = ImageHelper.UploadImageFile(_hostEnvironment, "wwwroot/Uploads/UserEducationDetail/MinistryofHigherEducationDoc", obj.MinistryofHigherEducationDoc);
            }
            if ((obj.FinancialSupport != null && permittedExtensions.Contains(ext3)))
            {
                userEducationDetail.FinancialSupport = ImageHelper.UploadImageFile(_hostEnvironment, "wwwroot/Uploads/UserEducationDetail/FinancialSupport", obj.FinancialSupport);
            }

            userEducationDetail.UserID = obj.UserID;
            userEducationDetail.ILETSorTOEFL = obj.ILETSorTOEFL;
            userEducationDetail.LastDegree = obj.LastDegree;
            userEducationDetail.SchoolName = obj.SchoolName;
            userEducationDetail.UnitsPassed = obj.UnitsPassed;
            return userEducationDetail;
        }

        public UserEducationDetail Update(UserEducationDetail userEducationDetail, UserEducationDetailUpsert obj)
        {
            string[] permittedExtensions = { ".jpg", ".jpeg", ".png", ".pdf" };
            userEducationDetail.ILETSorTOEFL = obj.ILETSorTOEFL;
            userEducationDetail.LastDegree = obj.LastDegree;
            userEducationDetail.SchoolName = obj.SchoolName;
            userEducationDetail.UnitsPassed = obj.UnitsPassed;
            if (obj.MinistryofHigherEducationDoc != null)
            {
                var ext = Path.GetExtension(obj.MinistryofHigherEducationDoc.FileName);
                if (permittedExtensions.Contains(ext))
                {
                    ImageHelper.DeleteImage(_hostEnvironment, @"Uploads\UserEducationDetail\MinistryofHigherEducationDoc", userEducationDetail.MinistryofHigherEducationDoc.Replace("/Uploads/UserEducationDetail/MinistryofHigherEducationDoc/", ""));
                    userEducationDetail.MinistryofHigherEducationDoc = ImageHelper.UploadImageFile(_hostEnvironment, "wwwroot/Uploads/UserEducationDetail/MinistryofHigherEducationDoc", obj.MinistryofHigherEducationDoc);
                }
            }
            if (obj.FinancialSupport != null)
            {
                var ext = Path.GetExtension(obj.FinancialSupport.FileName);
                if (permittedExtensions.Contains(ext))
                {
                    ImageHelper.DeleteImage(_hostEnvironment, @"Uploads\UserEducationDetail\Recommendations", userEducationDetail.FinancialSupport.Replace("/Uploads/UserEducationDetail/FinancialSupport/", ""));
                    userEducationDetail.FinancialSupport = ImageHelper.UploadImageFile(_hostEnvironment, "wwwroot/Uploads/UserEducationDetail/FinancialSupport", obj.FinancialSupport);
                }
            }
            if (obj.HighSchoolDegree != null)
            {
                var ext = Path.GetExtension(obj.HighSchoolDegree.FileName);
                if (permittedExtensions.Contains(ext))
                {
                    ImageHelper.DeleteImage(_hostEnvironment, @"Uploads\UserEducationDetail\HighSchoolDegree", userEducationDetail.HighSchoolDegree.Replace("/Uploads/UserEducationDetail/HighSchoolDegree/", ""));
                    userEducationDetail.HighSchoolDegree = ImageHelper.UploadImageFile(_hostEnvironment, "wwwroot/Uploads/UserEducationDetail/HighSchoolDegree", obj.HighSchoolDegree);
                }
            }

            return userEducationDetail;
        }

        public void Delete(UserEducationDetail userEducationDetail)
        {
            if (!string.IsNullOrEmpty(userEducationDetail.HighSchoolDegree))
            {
                ImageHelper.DeleteImage(_hostEnvironment, @"Uploads\UserEducationDetail\HighSchoolDegree", userEducationDetail.HighSchoolDegree.Replace("/Uploads/UserEducationDetail/HighSchoolDegree/", ""));
            }
            if (!string.IsNullOrEmpty(userEducationDetail.MinistryofHigherEducationDoc))
            {
                ImageHelper.DeleteImage(_hostEnvironment, @"Uploads\UserEducationDetail\MinistryofHigherEducationDoc", userEducationDetail.MinistryofHigherEducationDoc.Replace("/Uploads/UserEducationDetail/MinistryofHigherEducationDoc/", ""));
            }
            if (!string.IsNullOrEmpty(userEducationDetail.FinancialSupport))
            {
                ImageHelper.DeleteImage(_hostEnvironment, @"Uploads\UserEducationDetail\FinancialSupport", userEducationDetail.FinancialSupport.Replace("/Uploads/UserEducationDetail/FinancialSupport/", ""));
            }
        }
        
    }
    public class UserEducationDetailUpsert
    {
        [Required]
        public int UserID { get; set; }
        public IFormFile HighSchoolDegree { get; set; }
        public int ILETSorTOEFL { get; set; }
        public IFormFile MinistryofHigherEducationDoc { get; set; }
        public IFormFile FinancialSupport { get; set; }
        public int UnitsPassed { get; set; }
        public string LastDegree { get; set; }
        public string SchoolName { get; set; }
    }
}
