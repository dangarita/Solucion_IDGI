using IDGI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public List<View_Departamento> ObtenerListaDpto(int idPais)
        {
            List<View_Departamento> lstDpto = new List<View_Departamento>();
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

            }

            return lstDpto;
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
    }
}
