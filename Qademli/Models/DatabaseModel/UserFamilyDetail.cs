using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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

        [ForeignKey("UserID")]
        public User User { get; set; }
    }
}
