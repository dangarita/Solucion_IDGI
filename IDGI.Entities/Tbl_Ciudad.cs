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
    
    public partial class Tbl_Ciudad
    {
        public int Id_Ciudad { get; set; }
        public string Nom_Ciudad { get; set; }
        public string Codigo_Ciudad { get; set; }
        public int Id_Departamento { get; set; }
    
        public virtual Tbl_Departamento Tbl_Departamento { get; set; }
    }
}
