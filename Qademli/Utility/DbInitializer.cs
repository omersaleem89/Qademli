
using Qademli.Models.DatabaseModel;
using System.Linq;


namespace Qademli.Utility
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDBContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Users.
            if (context.User.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[]
            {
                new User{ FirstName="Admin",Email="admin@qademli.com",Password="admin",Role="Admin"},
                new User{FirstName="Raja",MiddleName="Adnan",LastName="Shan", Email="adnan@xyz.com",Password="123",Role="User"},
            };
            foreach (User u in users)
            {
                context.User.Add(u);
            }
            context.SaveChanges();


            var topics = new Topic[]
            {
                new Topic{ Name="University"},
                new Topic{Name="Learning Center"},
                new Topic{Name="IELTS"},
                new Topic{Name="TOEFL"},
                new Topic{Name="Visa"},
            };
            foreach (Topic t in topics)
            {
                context.Topic.Add(t);
            }
            context.SaveChanges();

            var applicationStatus = new ApplicationStatus[] {
                new ApplicationStatus{ Name="Pending"},
                new ApplicationStatus{ Name="Completed"},
                new ApplicationStatus{ Name="Paused"},
                new ApplicationStatus{ Name="Disposed"}
            };
            foreach (ApplicationStatus s in applicationStatus)
            {
                context.ApplicationStatus.Add(s);
            }
            context.SaveChanges();
        }
    }
}
