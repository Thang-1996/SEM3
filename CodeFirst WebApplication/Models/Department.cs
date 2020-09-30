using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace CodeFirst_WebApplication.Models
{
    public class Department
    {
        public int ID { get; set; }
        [StringLength(50,MinimumLength =6)]
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
        public virtual Office Office { get; set; }
    }
}