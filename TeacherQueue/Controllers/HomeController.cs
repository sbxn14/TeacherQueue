using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TeacherQueue.DAL;
using TeacherQueue.Models;
using TeacherQueue.Models.ViewModels;

namespace TeacherQueue.Controllers
{
    public class HomeController : Controller
    {
        private readonly QueueContext _context;

        public HomeController(QueueContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IndexViewModel model = new IndexViewModel
            {
                TeachersWithQueue = _context.Teachers.Where(o => o.HasQueue == true).ToList()
            };

            //prepare list of teachers with a queue for the dropdown menu
            List<SelectListItem> items = new List<SelectListItem>();

            foreach (var t in model.TeachersWithQueue)
            {
                items.Add(new SelectListItem(t.FirstMidName + " " + t.LastName, t.Id.ToString()));
            }

            ViewData["TeacherQueuesList"] = items;

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
