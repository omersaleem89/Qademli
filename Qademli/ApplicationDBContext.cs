using Microsoft.EntityFrameworkCore;
using Qademli.Models.DatabaseModel;

namespace Qademli
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<UserPersonalDetail> UserPersonalDetail { get; set; }
        public DbSet<UserEducationDetail> UserEducationDetail { get; set; }
        public DbSet<UserVisaDetail> UserVisaDetail { get; set; }
        public DbSet<UserFamilyDetail> UserFamilyDetail { get; set; }
        public DbSet<ApplicationStatus> ApplicationStatus { get; set; }
        public DbSet<Topic> Topic { get; set; }
        public DbSet<Goal> Goal { get; set; }
        public DbSet<GoalDetail> GoalDetail { get; set; }
        public DbSet<GoalProperty> GoalProperty { get; set; }
        public DbSet<GoalPropertyValue> GoalPropertyValue { get; set; }
        public DbSet<Application> Application { get; set; }


        
    }
}
