using System.Collections.Generic;

namespace TeacherQueue.Models.DatabaseModels
{
    public class Student
    {
        public int Id { get; set; }

        public virtual ICollection<StudentQueue> StudentQueues { get; set; }
    }
}
