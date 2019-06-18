using System.Collections.Generic;
using TeacherQueue.Models.DatabaseModels;

namespace TeacherQueue.Models.ViewModels
{
    public class IndexViewModel
    {
        public List<Teacher> TeachersWithQueue { get; set; }
        public int SelectedTeacherId { get; set; }
    }
}
