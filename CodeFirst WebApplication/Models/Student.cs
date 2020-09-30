using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Services;

namespace CodeFirst_WebApplication.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        // string length để validation độ dài của chuỗi string
        [StringLength(50,ErrorMessage ="FirstMiddleName can not belong 50 character")]
        [Column("FirstName")] // thay đổi tên của cột 
        public string FirstMidName { get; set; }
  /*      [Required] //  bắt buộc phải nhập*/
        public string Address { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}",ApplyFormatInEditMode =true)] // format date time theo dinh dang khac (theo dinh dang ngay thang nam) dùng applyformatinedit mode = true để khi edit là cũng sẽ sửa format
        [DataType(DataType.Date)] // thay đổi kiểu dữ liệu 
        [Display(Name ="Enrollment Date")] // chỉ thay đổi tên hiển thị chứ không thay đổi tên cột
        public DateTime EnrollmentDate { get; set; }
        // tạo 1 tập hợp sử dụng từ khóa virtuarl Collection
        public virtual ICollection<Enrollment> Enrollments { get; set; } // cũng là 1 thuộc tính của student nhưng là 1 collection 
    }
}