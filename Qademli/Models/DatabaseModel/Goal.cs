using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Qademli.Models.DatabaseModel
{
    public class Goal
    {
        [Key]
        public int ID { get; set; }
        public int TopicID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public float Fee { get; set; }
        public string Currency { get; set; }

        [ForeignKey("TopicID")]
        public Topic Topic { get; set; }
    }
}
