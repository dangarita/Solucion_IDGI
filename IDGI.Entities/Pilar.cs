//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IDGI.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pilar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pilar()
        {
            this.Tbl_Bloque = new HashSet<Bloque>();
        }
    
        public int Id_Pilar { get; set; }
        public string Nom_Pilar { get; set; }
        public bool EstaActivo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bloque> Tbl_Bloque { get; set; }
    }
}