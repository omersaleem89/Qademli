using Microsoft.AspNetCore.Mvc;
using Qademli.Utility;

namespace Qademli.Areas.Admin.Controllers
{
    [Area("Admin")]
    [CustomAuthorize(SD.Admin)]
    public class DashboardController : Controller
    {
        public IActionResult Application()
        {
            return View();
        }

        public IActionResult Goal()
        {
            return View();
        }

        public IActionResult GoalProperty()
        {
            return View();
        }

        public IActionResult ViewGoalProperty(int goalId,string goal)
        {
            ViewBag.GoalID = goalId;
            ViewBag.Goal = goal;
            return View();
        }
    }
}