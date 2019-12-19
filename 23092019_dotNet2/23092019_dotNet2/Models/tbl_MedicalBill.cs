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
    
    public partial class tbl_MedicalBill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_MedicalBill()
        {
            this.tbl_CustomerBooking = new HashSet<tbl_CustomerBooking>();
            this.tbl_CustomerBooking1 = new HashSet<tbl_CustomerBooking>();
            this.tbl_Payment = new HashSet<tbl_Payment>();
        }
    
        public short id { get; set; }
        public string billCode { get; set; }
        public Nullable<short> customerId { get; set; }
        public string customerName { get; set; }
        public string customerPhone { get; set; }
        public Nullable<System.DateTime> customerDOB { get; set; }
        public Nullable<int> customerGender { get; set; }
        public string services { get; set; }
        public Nullable<short> doctorId { get; set; }
        public string doctorName { get; set; }
        public Nullable<System.DateTime> bookingDate { get; set; }
        public Nullable<System.DateTime> comingDate { get; set; }
        public Nullable<decimal> totalFee { get; set; }
        public Nullable<decimal> paid { get; set; }
        public Nullable<decimal> debt { get; set; }
        public Nullable<short> officeId { get; set; }
        public string officeName { get; set; }
        public Nullable<short> discountPercent { get; set; }
        public Nullable<decimal> discountMoney { get; set; }
        public Nullable<int> status { get; set; }
        public Nullable<System.DateTime> createdTime { get; set; }
        public Nullable<System.DateTime> updatedTime { get; set; }
        public string createdBy { get; set; }
        public string updatedBy { get; set; }
    
        public virtual tbl_Customer tbl_Customer { get; set; }
        public virtual tbl_Customer tbl_Customer1 { get; set; }
        public virtual tbl_Customer tbl_Customer2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CustomerBooking> tbl_CustomerBooking { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CustomerBooking> tbl_CustomerBooking1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Payment> tbl_Payment { get; set; }
    }
}