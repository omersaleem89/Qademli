using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Qademli.Models.DatabaseModel
{
    public class UserFamilyDetail
    {
        [Key]
        public int ID { get; set; }
        public int UserID { get; set; }
        public string ParentPassport { get; set; }
        public string ParentMobileNo { get; set; }
        public string FatherCivilIDFront { get; set; }
        public string FatherCivilIDBack { get; set; }
        public string MotherCivilIDFront { get; set; }
        public string MotherCivilIDBack { get; set; }
        public string SpouseCivilIDFront { get; set; }
        public string SpouseCivilIDBack { get; set; }
        public string SpousePassport { get; set; }
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
        public string CompanionPassport { get; set; }
        public string CompanionI20 { get; set; }
        [ForeignKey("UserID")]
        public User User { get; set; }
    }
}
