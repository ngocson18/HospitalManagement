//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _23092019_dotNet2
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_ProductCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_ProductCategory()
        {
            this.tbl_Product = new HashSet<tbl_Product>();
        }
    
        public short id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Nullable<System.DateTime> createTime { get; set; }
        public Nullable<System.DateTime> updatedTime { get; set; }
        public string createdBy { get; set; }
        public string updatedBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Product> tbl_Product { get; set; }
    }
}