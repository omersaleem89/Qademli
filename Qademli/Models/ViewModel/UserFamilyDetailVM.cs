using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Qademli.Models.DatabaseModel;
using Qademli.Utility;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace Qademli.Models.ViewModel
{
    public class UserFamilyDetailVM
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        public UserFamilyDetailVM(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        public UserFamilyDetail Add(UserFamilyDetailUpsert obj)
        {
            string[] permittedExtensions = { ".jpg", ".jpeg", ".png", ".pdf" };
            UserFamilyDetail userFamilyDetail = new UserFamilyDetail();
            var ext1 = Path.GetExtension(obj.ParentPassport.FileName);
            var ext2 = Path.GetExtension(obj.FatherCivilIDBack.FileName);
            var ext3 = Path.GetExtension(obj.FatherCivilIDFront.FileName);
            var ext4 = Path.GetExtension(obj.MotherCivilIDBack.FileName);
            var ext5 = Path.GetExtension(obj.MotherCivilIDFront.FileName);
            var ext6 = Path.GetExtension(obj.SpousePassport.FileName);
            var ext7 = Path.GetExtension(obj.SpouseCivilIDFront.FileName);
            var ext8 = Path.GetExtension(obj.SpouseCivilIDBack.FileName);
            var ext9 = Path.GetExtension(obj.CompanionI20.FileName);
            var ext10 = Path.GetExtension(obj.CompanionPassport.FileName);
            if ((obj.ParentPassport != null && permittedExtensions.Contains(ext1)))
            {
                userFamilyDetail.ParentPassport = ImageHelper.UploadImageFile(_hostEnvironment, "wwwroot/Uploads/UserFamilyDetail/ParentPassport", obj.ParentPassport);
            }
            if ((obj.FatherCivilIDBack != null && permittedExtensions.Contains(ext2)))
            {
                userFamilyDetail.FatherCivilIDBack = ImageHelper.UploadImageFile(_hostEnvironment, "wwwroot/Uploads/UserFamilyDetail/FatherCivilIDBack", obj.FatherCivilIDBack);
            }
            if ((obj.FatherCivilIDFront != null && permittedExtensions.Contains(ext3)))
            {
                userFamilyDetail.FatherCivilIDFront = ImageHelper.UploadImageFile(_hostEnvironment, "wwwroot/Uploads/UserFamilyDetail/FatherCivilIDFront", obj.FatherCivilIDFront);
            }
            if ((obj.MotherCivilIDBack != null && permittedExtensions.Contains(ext4)))
            {
                userFamilyDetail.MotherCivilIDBack = ImageHelper.UploadImageFile(_hostEnvironment, "wwwroot/Uploads/UserFamilyDetail/MotherCivilIDBack", obj.MotherCivilIDBack);
            }
            if ((obj.MotherCivilIDFront != null && permittedExtensions.Contains(ext5)))
            {
                userFamilyDetail.MotherCivilIDFront = ImageHelper.UploadImageFile(_hostEnvironment, "wwwroot/Uploads/UserFamilyDetail/MotherCivilIDFront", obj.MotherCivilIDFront);
            }
            if ((obj.SpousePassport != null && permittedExtensions.Contains(ext6)))
            {
                userFamilyDetail.SpousePassport = ImageHelper.UploadImageFile(_hostEnvironment, "wwwroot/Uploads/UserFamilyDetail/SpousePassport", obj.SpousePassport);
            }
            if ((obj.SpouseCivilIDFront != null && permittedExtensions.Contains(ext7)))
            {
                userFamilyDetail.SpouseCivilIDFront = ImageHelper.UploadImageFile(_hostEnvironment, "wwwroot/Uploads/UserFamilyDetail/SpouseCivilIDFront", obj.SpouseCivilIDFront);
            }
            if ((obj.SpouseCivilIDBack != null && permittedExtensions.Contains(ext8)))
            {
                userFamilyDetail.SpouseCivilIDBack = ImageHelper.UploadImageFile(_hostEnvironment, "wwwroot/Uploads/UserFamilyDetail/SpouseCivilIDBack", obj.SpouseCivilIDBack);
            }
            if ((obj.CompanionI20 != null && permittedExtensions.Contains(ext9)))
            {
                userFamilyDetail.CompanionI20 = ImageHelper.UploadImageFile(_hostEnvironment, "wwwroot/Uploads/UserFamilyDetail/CompanionI20", obj.CompanionI20);
            }
            if ((obj.CompanionPassport != null && permittedExtensions.Contains(ext10)))
            {
                userFamilyDetail.CompanionPassport = ImageHelper.UploadImageFile(_hostEnvironment, "wwwroot/Uploads/UserFamilyDetail/CompanionPassport", obj.CompanionPassport);
            }
            userFamilyDetail.UserID = obj.UserID;
            userFamilyDetail.ParentMobileNo = obj.ParentMobileNo;
            userFamilyDetail.FriendInUS = obj.FriendInUS;
            userFamilyDetail.FriendAddress = obj.FriendAddress;
            userFamilyDetail.FriendMobileNo = obj.FriendMobileNo;
            userFamilyDetail.FamilyMemberInUS = obj.FamilyMemberInUS;
            userFamilyDetail.FamilyMemberFirstName = obj.FamilyMemberFirstName;
            userFamilyDetail.FamilyMemberLastName = obj.FamilyMemberLastName;
            userFamilyDetail.FamilyMemberRelation = obj.FamilyMemberRelation;
            userFamilyDetail.FamilyMemberUSCitizen = obj.FamilyMemberUSCitizen;
            userFamilyDetail.FamilyMemberImmigrant = obj.FamilyMemberImmigrant;
            userFamilyDetail.FamilyMemberRole = obj.FamilyMemberRole;
            userFamilyDetail.CollegeUniversity = obj.CollegeUniversity;
            userFamilyDetail.Major = obj.Major;
            userFamilyDetail.OrganizationName = obj.OrganizationName;
            userFamilyDetail.MonthlySalary = obj.MonthlySalary;
            userFamilyDetail.Currency = obj.Currency;
            userFamilyDetail.Position = obj.Position;
            return userFamilyDetail;
        }


        public UserFamilyDetail Update(UserFamilyDetail userFamilyDetail, UserFamilyDetailUpsert obj)
        {
            string[] permittedExtensions = { ".jpg", ".jpeg", ".png", ".pdf" };
            userFamilyDetail.UserID = obj.UserID;
            userFamilyDetail.ParentMobileNo = obj.ParentMobileNo;
            userFamilyDetail.FriendInUS = obj.FriendInUS;
            userFamilyDetail.FriendAddress = obj.FriendAddress;
            userFamilyDetail.FriendMobileNo = obj.FriendMobileNo;
            userFamilyDetail.FamilyMemberInUS = obj.FamilyMemberInUS;
            userFamilyDetail.FamilyMemberFirstName = obj.FamilyMemberFirstName;
            userFamilyDetail.FamilyMemberLastName = obj.FamilyMemberLastName;
            userFamilyDetail.FamilyMemberRelation = obj.FamilyMemberRelation;
            userFamilyDetail.FamilyMemberUSCitizen = obj.FamilyMemberUSCitizen;
            userFamilyDetail.FamilyMemberImmigrant = obj.FamilyMemberImmigrant;
            userFamilyDetail.FamilyMemberRole = obj.FamilyMemberRole;
            userFamilyDetail.CollegeUniversity = obj.CollegeUniversity;
            userFamilyDetail.Major = obj.Major;
            userFamilyDetail.OrganizationName = obj.OrganizationName;
            userFamilyDetail.MonthlySalary = obj.MonthlySalary;
            userFamilyDetail.Currency = obj.Currency;
            userFamilyDetail.Position = obj.Position;
            if (obj.ParentPassport != null)
            {
                var ext = Path.GetExtension(obj.ParentPassport.FileName);
                if (permittedExtensions.Contains(ext))
                {
                    ImageHelper.DeleteImage(_hostEnvironment, @"Uploads\UserFamilyDetail\ParentPassport", userFamilyDetail.ParentPassport.Replace("/Uploads/UserFamilyDetail/ParentPassport/", ""));
                    userFamilyDetail.ParentPassport = ImageHelper.UploadImageFile(_hostEnvironment, "wwwroot/Uploads/UserFamilyDetail/ParentPassport", obj.ParentPassport);
                }
            }
            if (obj.FatherCivilIDBack != null)
            {
                var ext = Path.GetExtension(obj.FatherCivilIDBack.FileName);
                if (permittedExtensions.Contains(ext))
                {
                    ImageHelper.DeleteImage(_hostEnvironment, @"Uploads\UserFamilyDetail\FatherCivilIDBack", userFamilyDetail.FatherCivilIDBack.Replace("/Uploads/UserFamilyDetail/FatherCivilIDBack/", ""));
                    userFamilyDetail.FatherCivilIDBack = ImageHelper.UploadImageFile(_hostEnvironment, "wwwroot/Uploads/UserFamilyDetail/FatherCivilIDBack", obj.FatherCivilIDBack);
                }
            }
            if (obj.FatherCivilIDFront != null)
            {
                var ext = Path.GetExtension(obj.FatherCivilIDFront.FileName);
                if (permittedExtensions.Contains(ext))
                {
                    ImageHelper.DeleteImage(_hostEnvironment, @"Uploads\UserFamilyDetail\FatherCivilIDFront", userFamilyDetail.FatherCivilIDFront.Replace("/Uploads/UserFamilyDetail/FatherCivilIDFront/", ""));
                    userFamilyDetail.FatherCivilIDFront = ImageHelper.UploadImageFile(_hostEnvironment, "wwwroot/Uploads/UserFamilyDetail/FatherCivilIDFront", obj.FatherCivilIDFront);
                }
            }
            if (obj.MotherCivilIDFront != null)
            {
                var ext = Path.GetExtension(obj.MotherCivilIDFront.FileName);
                if (permittedExtensions.Contains(ext))
                {
                    ImageHelper.DeleteImage(_hostEnvironment, @"Uploads\UserFamilyDetail\MotherCivilIDFront", userFamilyDetail.MotherCivilIDFront.Replace("/Uploads/UserFamilyDetail/MotherCivilIDFront/", ""));
                    userFamilyDetail.MotherCivilIDFront = ImageHelper.UploadImageFile(_hostEnvironment, "wwwroot/Uploads/UserFamilyDetail/MotherCivilIDFront", obj.MotherCivilIDFront);
                }
            }
            if (obj.MotherCivilIDBack != null)
            {
                var ext = Path.GetExtension(obj.MotherCivilIDBack.FileName);
                if (permittedExtensions.Contains(ext))
                {
                    ImageHelper.DeleteImage(_hostEnvironment, @"Uploads\UserFamilyDetail\MotherCivilIDBack", userFamilyDetail.MotherCivilIDBack.Replace("/Uploads/UserFamilyDetail/MotherCivilIDBack/", ""));
                    userFamilyDetail.MotherCivilIDBack = ImageHelper.UploadImageFile(_hostEnvironment, "wwwroot/Uploads/UserFamilyDetail/MotherCivilIDBack", obj.MotherCivilIDBack);
                }
            }
            if (obj.SpousePassport != null)
            {
                var ext = Path.GetExtension(obj.SpousePassport.FileName);
                if (permittedExtensions.Contains(ext))
                {
                    ImageHelper.DeleteImage(_hostEnvironment, @"Uploads\UserFamilyDetail\SpousePassport", userFamilyDetail.SpousePassport.Replace("/Uploads/UserFamilyDetail/SpousePassport/", ""));
                    userFamilyDetail.SpousePassport = ImageHelper.UploadImageFile(_hostEnvironment, "wwwroot/Uploads/UserFamilyDetail/SpousePassport", obj.SpousePassport);
                }
            }
            if (obj.SpouseCivilIDFront != null)
            {
                var ext = Path.GetExtension(obj.SpouseCivilIDFront.FileName);
                if (permittedExtensions.Contains(ext))
                {
                    ImageHelper.DeleteImage(_hostEnvironment, @"Uploads\UserFamilyDetail\SpouseCivilIDFront", userFamilyDetail.SpouseCivilIDFront.Replace("/Uploads/UserFamilyDetail/SpouseCivilIDFront/", ""));
                    userFamilyDetail.SpouseCivilIDFront = ImageHelper.UploadImageFile(_hostEnvironment, "wwwroot/Uploads/UserFamilyDetail/SpouseCivilIDFront", obj.SpouseCivilIDFront);
                }
            }
            if (obj.SpouseCivilIDBack != null)
            {
                var ext = Path.GetExtension(obj.SpouseCivilIDBack.FileName);
                if (permittedExtensions.Contains(ext))
                {
                    ImageHelper.DeleteImage(_hostEnvironment, @"Uploads\UserFamilyDetail\SpouseCivilIDBack", userFamilyDetail.SpouseCivilIDBack.Replace("/Uploads/UserFamilyDetail/SpouseCivilIDBack/", ""));
                    userFamilyDetail.SpouseCivilIDBack = ImageHelper.UploadImageFile(_hostEnvironment, "wwwroot/Uploads/UserFamilyDetail/SpouseCivilIDBack", obj.SpouseCivilIDBack);
                }
            }
            if (obj.CompanionPassport != null)
            {
                var ext = Path.GetExtension(obj.CompanionPassport.FileName);
                if (permittedExtensions.Contains(ext))
                {
                    ImageHelper.DeleteImage(_hostEnvironment, @"Uploads\UserFamilyDetail\CompanionPassport", userFamilyDetail.CompanionPassport.Replace("/Uploads/UserFamilyDetail/CompanionPassport/", ""));
                    userFamilyDetail.CompanionPassport = ImageHelper.UploadImageFile(_hostEnvironment, "wwwroot/Uploads/UserFamilyDetail/CompanionPassport", obj.CompanionPassport);
                }
            }
            if (obj.CompanionI20 != null)
            {
                var ext = Path.GetExtension(obj.CompanionI20.FileName);
                if (permittedExtensions.Contains(ext))
                {
                    ImageHelper.DeleteImage(_hostEnvironment, @"Uploads\UserFamilyDetail\CompanionI20", userFamilyDetail.CompanionI20.Replace("/Uploads/UserFamilyDetail/CompanionI20/", ""));
                    userFamilyDetail.CompanionI20 = ImageHelper.UploadImageFile(_hostEnvironment, "wwwroot/Uploads/UserFamilyDetail/CompanionI20", obj.CompanionI20);
                }
            }

            return userFamilyDetail;
        }

        public void Delete(UserFamilyDetail userFamilyDetail)
        {
            if (!string.IsNullOrEmpty(userFamilyDetail.ParentPassport))
            {
                ImageHelper.DeleteImage(_hostEnvironment, @"Uploads\UserFamilyDetail\ParentPassport", userFamilyDetail.ParentPassport.Replace("/Uploads/UserFamilyDetail/ParentPassport/", ""));
            }
            if (!string.IsNullOrEmpty(userFamilyDetail.FatherCivilIDFront))
            {
                ImageHelper.DeleteImage(_hostEnvironment, @"Uploads\UserFamilyDetail\FatherCivilIDFront", userFamilyDetail.FatherCivilIDFront.Replace("/Uploads/UserFamilyDetail/FatherCivilIDFront/", ""));
            }
            if (!string.IsNullOrEmpty(userFamilyDetail.FatherCivilIDBack))
            {
                ImageHelper.DeleteImage(_hostEnvironment, @"Uploads\UserFamilyDetail\FatherCivilIDBack", userFamilyDetail.FatherCivilIDBack.Replace("/Uploads/UserFamilyDetail/FatherCivilIDBack/", ""));
            }
            if (!string.IsNullOrEmpty(userFamilyDetail.MotherCivilIDFront))
            {
                ImageHelper.DeleteImage(_hostEnvironment, @"Uploads\UserFamilyDetail\MotherCivilIDFront", userFamilyDetail.MotherCivilIDFront.Replace("/Uploads/UserFamilyDetail/MotherCivilIDFront/", ""));
            }
            if (!string.IsNullOrEmpty(userFamilyDetail.MotherCivilIDBack))
            {
                ImageHelper.DeleteImage(_hostEnvironment, @"Uploads\UserFamilyDetail\MotherCivilIDBack", userFamilyDetail.MotherCivilIDBack.Replace("/Uploads/UserFamilyDetail/MotherCivilIDBack/", ""));
            }
            if (!string.IsNullOrEmpty(userFamilyDetail.SpousePassport))
            {
                ImageHelper.DeleteImage(_hostEnvironment, @"Uploads\UserFamilyDetail\SpousePassport", userFamilyDetail.SpousePassport.Replace("/Uploads/UserFamilyDetail/SpousePassport/", ""));
            }
            if (!string.IsNullOrEmpty(userFamilyDetail.SpouseCivilIDFront))
            {
                ImageHelper.DeleteImage(_hostEnvironment, @"Uploads\UserFamilyDetail\SpouseCivilIDFront", userFamilyDetail.SpouseCivilIDFront.Replace("/Uploads/UserFamilyDetail/SpouseCivilIDFront/", ""));
            }
            if (!string.IsNullOrEmpty(userFamilyDetail.SpouseCivilIDBack))
            {
                ImageHelper.DeleteImage(_hostEnvironment, @"Uploads\UserFamilyDetail\SpouseCivilIDBack", userFamilyDetail.SpouseCivilIDBack.Replace("/Uploads/UserFamilyDetail/SpouseCivilIDBack/", ""));
            }
            if (!string.IsNullOrEmpty(userFamilyDetail.CompanionPassport))
            {
                ImageHelper.DeleteImage(_hostEnvironment, @"Uploads\UserFamilyDetail\CompanionPassport", userFamilyDetail.CompanionPassport.Replace("/Uploads/UserFamilyDetail/CompanionPassport/", ""));
            }
            if (!string.IsNullOrEmpty(userFamilyDetail.CompanionI20))
            {
                ImageHelper.DeleteImage(_hostEnvironment, @"Uploads\UserFamilyDetail\CompanionI20", userFamilyDetail.CompanionI20.Replace("/Uploads/UserFamilyDetail/CompanionI20/", ""));
            }
        }
    }

    public class UserFamilyDetailUpsert
    {
        [Required]
        public int UserID { get; set; }
        public IFormFile ParentPassport { get; set; }
        public string ParentMobileNo { get; set; }
        public IFormFile FatherCivilIDFront { get; set; }
        public IFormFile FatherCivilIDBack { get; set; }
        public IFormFile MotherCivilIDFront { get; set; }
        public IFormFile MotherCivilIDBack { get; set; }
        public IFormFile SpouseCivilIDFront { get; set; }
        public IFormFile SpouseCivilIDBack { get; set; }
        public IFormFile SpousePassport { get; set; }
        public bool FriendInUS { get; set; }
        public string FriendAddress { get; set; }
        public string FriendMobileNo { get; set; }
        public bool FamilyMemberInUS { get; set; }
        public string FamilyMemberFirstName { get; set; }
        public string FamilyMemberLastName { get; set; }
        public string FamilyMemberRelation { get; set; }
        public bool FamilyMemberUSCitizen { get; set; }
        public bool FamilyMemberImmigrant { get; set; }
        public string FamilyMemberRole { get; set; }
        public string CollegeUniversity { get; set; }
        public string Major { get; set; }
        public string OrganizationName { get; set; }
        public int MonthlySalary { get; set; }
        public string Currency { get; set; }
        public string Position { get; set; }
        public IFormFile CompanionPassport { get; set; }
        public IFormFile CompanionI20 { get; set; }
    }
}
