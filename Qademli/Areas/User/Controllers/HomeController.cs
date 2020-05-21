using Microsoft.AspNetCore.Mvc;
using Qademli.Utility;

namespace Qademli.Areas.User.Controllers
{
    [Area("User")]
    [CustomAuthorize(SD.User)]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AllGoal(string topic, int topicId)
        {
            ViewBag.Topic = topic;
            ViewBag.TopicID = topicId;
            return View();
        }
        public IActionResult Goal()
        {
            return View();
        }
        public IActionResult Application()
        {
            return View();
        }
    }
}