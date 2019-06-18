using System.Collections.Generic;

namespace TeacherQueue.Models.DatabaseModels
{
    public class Queue
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public int Size { get; set; }

        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<StudentQueue> StudentQueues { get; set; }
    }
}
