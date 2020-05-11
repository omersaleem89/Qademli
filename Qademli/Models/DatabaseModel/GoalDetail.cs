using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Qademli.Models.DatabaseModel
{
    public class GoalDetail
    {
        [Key]
        public int ID { get; set; }
        public int GoalID { get; set; }
        public int GoalPropertyID { get; set; }

        [ForeignKey("GoalID")]
        public Goal Goal { get; set; }
        [ForeignKey("GoalPropertyID")]
        public GoalProperty GoalProperty { get; set; }
    }
}
