using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Qademli.Models.DatabaseModel;
using Qademli.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Qademli.Models.ViewModel
{
    public class GoalVM
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        public GoalVM(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }
        public Goal Add(GoalUpsert obj)
        {
            string[] permittedExtensions = { ".jpg", ".jpeg", ".png" };
            Goal goal = new Goal();
            var ext1 = Path.GetExtension(obj.Image.FileName).ToLower();
            if ((obj.Image != null && permittedExtensions.Contains(ext1)))
            {
                goal.Image = ImageHelper.UploadImageFile(_hostEnvironment, "wwwroot/Uploads/Goal", obj.Image);
            }
            goal.Name = obj.Name;
            goal.TopicID = obj.TopicID;
            goal.Fee = obj.Fee;
            goal.Currency = obj.Currency;
            return goal;
        }
        public Goal Update(Goal goal, GoalUpsert obj)
        {
            string[] permittedExtensions = { ".jpg", ".jpeg", ".png"};
            goal.Name = obj.Name;
            goal.TopicID = obj.TopicID;
            goal.Fee = obj.Fee;
            goal.Currency = obj.Currency;
            if (obj.Image != null)
            {
                var ext = Path.GetExtension(obj.Image.FileName).ToLower();
                if (permittedExtensions.Contains(ext))
                {
                    ImageHelper.DeleteImage(_hostEnvironment, @"Uploads\Goal", goal.Image.Replace("/Uploads/Goal/", ""));
                    goal.Image = ImageHelper.UploadImageFile(_hostEnvironment,"wwwroot/Uploads/Goal", obj.Image);
                }
            }
            return goal ;
        }
        public void Delete(Goal goal)
        {
            if (!string.IsNullOrEmpty(goal.Image))
            {
                ImageHelper.DeleteImage(_hostEnvironment, @"Uploads\Goal", goal.Image.Replace("/Uploads/Goal/", ""));
            }
        }

    }

    public class GoalUpsert {
        public int TopicID { get; set; }
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        public float Fee { get; set; }
        public string Currency { get; set; }
    }

    public class GoalTopic {
        public int ID { get; set; }
        public int TopicID { get; set; }
        public string TopicName { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public float Fee { get; set; }
        public string Currency { get; set; }
    }
}
