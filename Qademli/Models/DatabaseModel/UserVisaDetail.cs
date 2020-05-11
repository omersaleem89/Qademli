using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Qademli.Models.DatabaseModel
{
    public class UserVisaDetail
    {
        [Key]
        public int ID { get; set; }
        public int UserID { get; set; }
        public string MyProperty { get; set; }
        public string Passport { get; set; }
        public string VisaPermit { get; set; }
        public string Recommendations { get; set; }
        public DateTime LastVisitToUS { get; set; }
        public int DaysSpentInUS { get; set; }
        public string CountriesVisted { get; set; }
        public string I20Doc { get; set; }
        public bool Employee { get; set; }
        public string OrganizationName { get; set; }
        public DateTime DateTo { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime TravelDate { get; set; }
        public bool VisaPermitRejected { get; set; }
        public string ReasonOfRejection { get; set; }

        [ForeignKey("UserID")]
        public User User { get; set; }
    }
}
