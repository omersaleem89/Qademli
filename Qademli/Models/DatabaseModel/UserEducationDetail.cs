using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Qademli.Models.DatabaseModel
{
    public class UserEducationDetail
    {
        [Key]
        public int ID { get; set; }
        public int UserID { get; set; }
        public string HighSchoolDegree { get; set; }
        public int ILETSorTOEFL { get; set; }
        public string MinistryofHigherEducationDoc { get; set; }
        public string FinancialSupport { get; set; }
        public int UnitsPassed { get; set; }
        public string LastDegree { get; set; }
        public string SchoolName { get; set; }
        [ForeignKey("UserID")]
        public User User { get; set; }
    }
}
