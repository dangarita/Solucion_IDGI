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
    
    public partial class View_Empresa
    {
        public int Id_Empresa { get; set; }
        public string Nom_Empresa { get; set; }
        public string Nit_Empresa { get; set; }
        public string Dir_Empresa { get; set; }
        public string Telf_Empresa { get; set; }
        public string Correo_Empresa { get; set; }
        public Nullable<int> Num_Personal { get; set; }
        public string Nom_Contacto { get; set; }
        public bool EstaActiva { get; set; }
        public int Id_Ciudad { get; set; }
        public int Id_SectorEmpresarial { get; set; }
    }
}
