using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherQueue.Models.DatabaseModels
{
    public class StudentQueue
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int QueueId { get; set; }
        public Queue Queue { get; set; }
    }
}
