//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MLandfill
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblTruckCompany
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblTruckCompany()
        {
            this.tblLandFillWasteDockets = new HashSet<tblLandFillWasteDocket>();
        }
    
        public int TruckCompId { get; set; }
        public string TruckCompName { get; set; }
        public string TruckCompAddr { get; set; }
        public string TruckCompCity { get; set; }
        public string TruckCompProv { get; set; }
        public string TruckCompPostal { get; set; }
        public string TruckCompPhone { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblLandFillWasteDocket> tblLandFillWasteDockets { get; set; }
    }
}
