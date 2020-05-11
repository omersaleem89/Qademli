﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Qademli.Models.DatabaseModel
{
    public class GoalPropertyValue
    {
        [Key]
        public int ID { get; set; }
        public int GoalPropertyID { get; set; }
        public string Name { get; set; }
        [ForeignKey("GoalPropertyID")]
        public GoalProperty GoalProperty { get; set; }
    }
}
