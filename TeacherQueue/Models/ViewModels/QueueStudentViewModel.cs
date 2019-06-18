using TeacherQueue.Models.DatabaseModels;

namespace TeacherQueue.Models.ViewModels
{
    public class QueueStudentViewModel
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public Teacher SelectedTeacher { get; set; }
    }
}
