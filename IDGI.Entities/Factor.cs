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
    
    public partial class Factor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Factor()
        {
            this.Tbl_Elemento = new HashSet<Elemento>();
        }
    
        public int Id_Factor { get; set; }
        public string Nom_Factor { get; set; }
        public bool EstaActivo { get; set; }
        public Nullable<int> Id_Bloque { get; set; }
    
        public virtual Bloque Tbl_Bloque { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Elemento> Tbl_Elemento { get; set; }
    }
}