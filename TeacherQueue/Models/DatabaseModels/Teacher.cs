using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherQueue.Models.DatabaseModels
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstMidName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public bool HasQueue { get; set; }

        public virtual Queue Queue { get; set; }
    }
}
