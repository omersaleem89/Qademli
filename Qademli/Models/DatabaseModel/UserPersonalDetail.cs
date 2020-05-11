using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace Qademli.Models.DatabaseModel
{
    public class UserPersonalDetail
    {
        [Key]
        public int ID { get; set; }
        public int UserID { get; set; }
        public string MaritalStatus { get; set; }
        public string CivilIDFront { get; set; }
        public string CivilIDBack { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public string Instagram { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string USAddress { get; set; }
        public string Title { get; set; }
        public string Gender { get; set; }
        public string FirstLanguage { get; set; }
        public string Nationality { get; set; }
        public DateTime DOB { get; set; }
        public string IdentificationDoc { get; set; }
        public string IdentificationDocNo { get; set; }
        public string TownCity { get; set; }
        public string StateCountry { get; set; }
        public int ZipPostalCode { get; set; }
        public string TelephoneNumber { get; set; }
        public string OccupationSector { get; set; }
        public string OccupationLevel { get; set; }
        [ForeignKey("UserID")]
        public User User { get; set; }
    }
}
