using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Qademli.Models.DatabaseModel
{
    public class Application
    {
        [Key]
        public int ID { get; set; }
        public int UserID { get; set; }
        public int GoalID { get; set; }
        public int? TopicID { get; set; }
        public int StatusID { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public int Fee { get; set; }
        public string Currency { get; set; }
        [ForeignKey("UserID")]
        public User User { get; set; }
        [ForeignKey("GoalID")]
        public Goal Goal { get; set; }
        [ForeignKey("TopicID")]
        public virtual Topic Topic { get; set; }
        [ForeignKey("StatusID")]
        public ApplicationStatus ApplicationStatus { get; set; }
    }
}
