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

        public List<DtoEmpresa> ObtenerListaEmpresa()
        {
            List<DtoEmpresa> lstEmpresas = new List<DtoEmpresa>();

            using (DB_IDGIEntities db = new DB_IDGIEntities())
            {
                return db.DtoEmpresa.ToList();
            }
            
        }
    }
}
