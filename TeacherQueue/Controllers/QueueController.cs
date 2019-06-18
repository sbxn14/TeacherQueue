using Microsoft.AspNetCore.Mvc;
using TeacherQueue.DAL;
using TeacherQueue.Models.ViewModels;

namespace TeacherQueue.Controllers
{
    public class QueueController : Controller
    {
        private readonly QueueContext _context;

        public QueueController(QueueContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return null;
        }

        public IActionResult Queue()
        {
            //check if current user is a teacher or not
            //if it IS a teacher, show interface for his/her queue
            //if it IS NOT a teacher and thus a student, show the queue of the teacher if there is any.
            if (User.Identity.IsAuthenticated)
            {
                //IS TEACHER
            }
            else
            {
                //IS STUDENT
            }


            return View();
        }

        public IActionResult QueueView(IndexViewModel model)
        {
            //student has chosen a teacher to view the queue of, and has arrived here
            if (ModelState.IsValid)
            {
                //retrieve selected teacher (and with that his/her queue)
                var selectedTeacher = _context.Teachers.Find(model.SelectedTeacherId);

                QueueStudentViewModel qmodel = new QueueStudentViewModel
                {
                    SelectedTeacher = selectedTeacher
                };

                return View(qmodel);
            }
            //return to index
            return RedirectToAction("Index", "Home");
        }
    }
}