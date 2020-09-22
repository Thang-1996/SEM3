using CodeFirst_WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodeFirst_WebApplication.DAL
{
    public class FptAptechEduContext:DbContext
    {
        public FptAptechEduContext() : base("FptAptechContext"){}
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}