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
    
    public partial class Elemento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Elemento()
        {
            this.Tbl_Pregunta = new HashSet<Pregunta>();
        }
    
        public int Id_Elemento { get; set; }
        public string Nom_Elemento { get; set; }
        public bool EstaActivo { get; set; }
        public int Id_Factor { get; set; }
    
        public virtual Factor Tbl_Factor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pregunta> Tbl_Pregunta { get; set; }
    }
}
