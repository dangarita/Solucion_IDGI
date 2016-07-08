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
            try
            {
                using (DB_IDGIEntities db = new DB_IDGIEntities())
                {
                    lstDpto = (from obj in db.View_Departamento
                               where obj.Id_Pais == idPais
                               select new View_Departamento
                               {
                                   Id_Pais = obj.Id_Pais,
                                   Id_Departamento = obj.Id_Departamento,
                                   Nom_Departamento = obj.Nom_Departamento
                               }).ToList();

                    oResultadoListaDpto.ListaEntidadDatos = lstDpto;

                }
            }
            catch (Exception ex)
            {
                throw new DataBaseException(Globales.NombreAplicacion.ToUpper(), ex.Message, new Exception(ex.Message));
            }
            

            return oResultadoListaDpto;
        }

        public List<View_Ciudad> ObtenerListaCiudad(int IdDpto)
        {
            List<View_Ciudad> lstCiudad = new List<View_Ciudad>();
            using (DB_IDGIEntities db = new DB_IDGIEntities())
            {
                lstCiudad = (from obj in db.View_Ciudad
                             where obj.Id_Departamento == IdDpto
                             select new View_Ciudad
                             {
                                 Id_Ciudad = obj.Id_Ciudad,
                                 Id_Departamento = obj.Id_Departamento,
                                 Nom_Ciudad = obj.Nom_Ciudad
                             }).ToList();

            }

            return lstCiudad;
        }

        public List<View_SectoresEmpresariales> ObtenerListaSectores()
        {
            List<View_SectoresEmpresariales> lstSectores = new List<View_SectoresEmpresariales>();

            using (DB_IDGIEntities db = new DB_IDGIEntities())
            {
                lstSectores = (from obj in db.View_SectoresEmpresariales
                             select new View_SectoresEmpresariales
                             {
                                 Id_SectorEmpresarial = obj.Id_SectorEmpresarial,
                                 Nom_Sector = obj.Nom_Sector
                             }).ToList();
            }

                return lstSectores;
        }

        public async void InsertarEmpresa(Tbl_Empresa Empresa)
        {
            int IdEmpresa = 0;
            using (DB_IDGIEntities db = new DB_IDGIEntities())
            {
                db.Tbl_Empresa.Add(Empresa);
                int x = await db.SaveChangesAsync();
            }
        }
    }
}
