//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _23092019_dotNet2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tbl_User
    {
        public short id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        public Nullable<System.DateTime> dob { get; set; }
        public Nullable<short> departmentId { get; set; }
        public Nullable<int> gender { get; set; }
        public string phone { get; set; }
        public string groupId { get; set; }
        public string groupName { get; set; }
        public string email { get; set; }
        public Nullable<int> status { get; set; }
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        public Nullable<System.DateTime> createdTime { get; set; }
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        public Nullable<System.DateTime> updatedTime { get; set; }
        public string createdBy { get; set; }
        public string updatedBy { get; set; }
    
        public virtual tbl_Group tbl_Group { get; set; }
        public virtual tbl_Group tbl_Group1 { get; set; }
    }
}
