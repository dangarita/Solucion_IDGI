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
    
    public partial class Tbl_EmpresaGestor
    {
        public int Id_EmpresaGestor { get; set; }
        public int Id_Empresa { get; set; }
        public int Id_Gestor { get; set; }
    
        public virtual Tbl_Empresa Tbl_Empresa { get; set; }
        public virtual Tbl_Gestor Tbl_Gestor { get; set; }
    }
}
