using IDGI.CultureResource;
using IDGI.Entities;
using Library.Exception;
using Library.Utilidades;
using Library.Utilidades.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IDGI.DataObjects
{
    public class EmpresasDAO
    {
        public List<View_Pais> ObtenerListaPaises()
        {
            using (DB_IDGIEntities db = new DB_IDGIEntities())
            {
                return db.View_Pais.ToList();
            }
        }

        public ResultadoOperacion ObtenerListaDpto(int idPais)
        {
            List<View_Departamento> lstDpto = new List<View_Departamento>();
            ResultadoOperacion oResultadoListaDpto = new ResultadoOperacion();
            using (DB_IDGIEntities db = new DB_IDGIEntities())
            {
                lstDpto = db.View_Departamento.ToList();                
            }

            List<View_Departamento> lstDptoFiltro = new List<View_Departamento>();
            lstDptoFiltro = (from obj in lstDpto
                       where obj.Id_Pais == idPais
                       select new View_Departamento
                       {
                           Id_Pais = obj.Id_Pais,
                           Id_Departamento = obj.Id_Departamento,
                           Nom_Departamento = obj.Nom_Departamento
                       }).ToList();

            oResultadoListaDpto.ListaEntidadDatos = lstDptoFiltro;

            return oResultadoListaDpto;
        }

        public List<View_Ciudad> ObtenerListaCiudad(int IdDpto)
        {
            List<View_Ciudad> lstCiudad = new List<View_Ciudad>();
            using (DB_IDGIEntities db = new DB_IDGIEntities())
            {
                lstCiudad = db.View_Ciudad.ToList();
            }
            List<View_Ciudad> lstCiudadFiltro = new List<View_Ciudad>();
            lstCiudadFiltro = (from obj in lstCiudad
                            where obj.Id_Departamento == IdDpto
                         select new View_Ciudad
                         {
                             Id_Ciudad = obj.Id_Ciudad,
                             Id_Departamento = obj.Id_Departamento,
                             Nom_Ciudad = obj.Nom_Ciudad
                         }).ToList();

            return lstCiudadFiltro;
        }

        public List<View_SectoresEmpresariales> ObtenerListaSectores()
        {
            List<View_SectoresEmpresariales> lstSectores = new List<View_SectoresEmpresariales>();

            using (DB_IDGIEntities db = new DB_IDGIEntities())
            {
                return db.View_SectoresEmpresariales.ToList();
            }

        }

        public void InsertarEmpresa(Tbl_Empresa Empresa)
        {

            using (DB_IDGIEntities db = new DB_IDGIEntities())
            {
                db.Tbl_Empresa.Add(Empresa);
                db.SaveChanges();
            }
        }

        public List<View_Empresa> ConsultarEmpresa(Tbl_Empresa oEmpresa)
        {
            List<View_Empresa> lstEmpresas = new List<View_Empresa>();

            using (DB_IDGIEntities db = new DB_IDGIEntities())
            {
                lstEmpresas = db.View_Empresa.ToList();
            }
            
            if (oEmpresa.Id_Empresa > 0)
            {
                List<View_Empresa> lstEmpresaFiltro = new List<View_Empresa>();

                lstEmpresaFiltro = (from obj in lstEmpresas
                                    where obj.Id_Empresa == oEmpresa.Id_Empresa
                                    select new View_Empresa
                                    {
                                        Correo_Empresa = obj.Correo_Empresa,
                                        Id_Ciudad = obj.Id_Ciudad,
                                        Dir_Empresa = obj.Dir_Empresa,
                                        Id_Empresa = obj.Id_Empresa,
                                        Id_SectorEmpresarial = obj.Id_SectorEmpresarial,
                                        Nit_Empresa = obj.Nit_Empresa,
                                        Nom_Contacto = obj.Nom_Contacto,
                                        Nom_Empresa = obj.Nom_Empresa,
                                        Num_Personal = obj.Num_Personal,
                                        Telf_Empresa = obj.Telf_Empresa,
                                        EstaActiva = obj.EstaActiva
                                    }).ToList();


                return lstEmpresaFiltro;
            }
            else
            {
                return lstEmpresas;
            }
        }
    }
}
