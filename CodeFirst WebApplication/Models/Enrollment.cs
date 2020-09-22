using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace CodeFirst_WebApplication.Models
{
    // sử dụng những property là những trường cố định sử dụng enum ví dụ như grade
    public enum Grade
    {
        A,B,C,D
    }
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        public Grade? Grade { get; set; }  // ? là biểu thức để mapping vào nội dung của phương thức grade là nằm trong 1 trong các xếp loại trên
        // mapping đến Student // sử dụng virtual để gắn vào khóa ngoại đến student
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
    }
}