using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace CodeFirst_WebApplication.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public string Address { get; set; }
        public DateTime EnrollmentDate { get; set; }
        // tạo 1 tập hợp sử dụng từ khóa virtuarl Collection
        public virtual ICollection<Enrollment> Enrollments { get; set; } // cũng là 1 thuộc tính của student nhưng là 1 collection 
    }
}