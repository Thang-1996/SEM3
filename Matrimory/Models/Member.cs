//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Matrimory.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Member
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Member()
        {
            this.Bills = new HashSet<Bill>();
            this.FriendLists = new HashSet<FriendList>();
        }
    
        public int ID { get; set; }
        public string email { get; set; }
        public int VisaID { get; set; }
        public string image { get; set; }
        public string telephone { get; set; }
        public string gender { get; set; }
        public string FirstName { get; set; }
        public string Status { get; set; }
        public string address { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public System.DateTime BirthDay { get; set; }
        public int Height { get; set; }
        public string MaritalStatus { get; set; }
        public string Caste { get; set; }
        public string Job { get; set; }
        public string Hobbies { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bill> Bills { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FriendList> FriendLists { get; set; }
        public virtual PaymentType PaymentType { get; set; }
    }
}