using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeFirst_WebApplication.Models
{
    public class Instructor
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50,MinimumLength =6)]
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}",ApplyFormatInEditMode = true)]
        [Display(Name ="Hire Date")]
        public DateTime HireDate { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}