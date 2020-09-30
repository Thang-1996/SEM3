using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace CodeFirst_WebApplication.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; } // sử dụng collection khi có khóa ngoại ở bảng Enrollment sẽ tạo ra 1 collection
        public virtual ICollection<Instructor> Instructors { get; set; }
        
    }
}