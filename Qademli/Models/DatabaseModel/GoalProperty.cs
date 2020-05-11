﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Qademli.Models.DatabaseModel
{
    public class GoalProperty
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
