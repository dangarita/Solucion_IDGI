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
        public List<DtoPais> ObtenerListaPaises()
        {
            using (DB_IDGIEntities db = new DB_IDGIEntities())
            {
                return db.DtoPais.ToList();
            }
        }

        public ResultadoOperacion ObtenerListaDpto(int idPais)
        {
            List<DtoDepartamento> lstDpto = new List<DtoDepartamento>();
            ResultadoOperacion oResultadoListaDpto = new ResultadoOperacion();
            using (DB_IDGIEntities db = new DB_IDGIEntities())
            {
                lstDpto = db.DtoDepartamento.ToList();                
            }

            List<DtoDepartamento> lstDptoFiltro = new List<DtoDepartamento>();
            lstDptoFiltro = (from obj in lstDpto
                       where obj.Id_Pais == idPais
                       select new DtoDepartamento
                       {
                           Id_Pais = obj.Id_Pais,
                           Id_Departamento = obj.Id_Departamento,
                           Nom_Departamento = obj.Nom_Departamento
                       }).ToList();

            oResultadoListaDpto.ListaEntidadDatos = lstDptoFiltro;

            return oResultadoListaDpto;
        }

        public List<DtoCiudad> ObtenerListaCiudad(int IdDpto)
        {
            List<DtoCiudad> lstCiudad = new List<DtoCiudad>();
            using (DB_IDGIEntities db = new DB_IDGIEntities())
            {
                lstCiudad = db.DtoCiudad.ToList();
            }
            List<DtoCiudad> lstCiudadFiltro = new List<DtoCiudad>();
            lstCiudadFiltro = (from obj in lstCiudad
                            where obj.Id_Departamento == IdDpto
                         select new DtoCiudad
                         {
                             Id_Ciudad = obj.Id_Ciudad,
                             Id_Departamento = obj.Id_Departamento,
                             Nom_Ciudad = obj.Nom_Ciudad
                         }).ToList();

            return lstCiudadFiltro;
        }

        public List<DtoSectoresEmpresariales> ObtenerListaSectores()
        {
            List<DtoSectoresEmpresariales> lstSectores = new List<DtoSectoresEmpresariales>();

            using (DB_IDGIEntities db = new DB_IDGIEntities())
            {
                return db.DtoSectoresEmpresariales.ToList();
            }

        }

        public void InsertarEmpresa(Empresa Empresa)
        {

            using (DB_IDGIEntities db = new DB_IDGIEntities())
            {
                db.Empresa.Add(Empresa);
                db.SaveChanges();
            }
        }

        public List<DtoEmpresa> ConsultarEmpresa(Empresa oEmpresa)
        {
            List<DtoEmpresa> lstEmpresas = new List<DtoEmpresa>();

            using (DB_IDGIEntities db = new DB_IDGIEntities())
            {
                lstEmpresas = db.DtoEmpresa.ToList();
            }
            
            if (oEmpresa.Id_Empresa > 0)
            {
                List<DtoEmpresa> lstEmpresaFiltro = new List<DtoEmpresa>();

                lstEmpresaFiltro = (from obj in lstEmpresas
                                    where obj.Id_Empresa == oEmpresa.Id_Empresa
                                    select new DtoEmpresa
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
