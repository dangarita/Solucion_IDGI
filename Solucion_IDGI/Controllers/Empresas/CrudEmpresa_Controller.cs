using IDGI.Entities;
using Library.Utilidades;
using Library.Utilidades.Enums;
using Solucion_IDGI.Controllers.Base;
using System;
using System.Collections.Generic;

namespace Solucion_IDGI.Controllers
{
    [Serializable]
    public class CrudEmpresa_Controller : ControllerBase
    {
        public List<View_Pais> ObtenerListaPais()
        {
            List<View_Pais> LstpaisNew = new List<View_Pais>();

            ResultadoOperacion oResultadoPais = _Model.ObtenerListaPais();

            if (oResultadoPais.oEstado == TipoRespuesta.Exito)
            {
                LstpaisNew = (List<View_Pais>)oResultadoPais.ListaEntidadDatos;
            }


            return LstpaisNew;
        }

        public List<View_Departamento> ObtenerListDpto(int idSector)
        {
            List<View_Departamento> LstDptoNew = new List<View_Departamento>();

            ResultadoOperacion oResultadoSector = _Model.ObtenerListaDptos(idSector);

            if (oResultadoSector.oEstado == TipoRespuesta.Exito)
            {
                LstDptoNew = (List<View_Departamento>)oResultadoSector.ListaEntidadDatos;
            }

            return LstDptoNew;
        }

        public List<View_Ciudad> ObtenerListCiudad(int idDpto)
        {
            List<View_Ciudad> LstCiudadNew = new List<View_Ciudad>();

            ResultadoOperacion oResultadoSector = _Model.ObtenerListaCiudad(idDpto);

            if (oResultadoSector.oEstado == TipoRespuesta.Exito)
            {
                LstCiudadNew = (List<View_Ciudad>)oResultadoSector.ListaEntidadDatos;
            }

            return LstCiudadNew;
        }

        public List<View_SectoresEmpresariales> ObtenerListaSectores()
        {
            List<View_SectoresEmpresariales> LstSectorNew = new List<View_SectoresEmpresariales>();

            ResultadoOperacion oResultadoSector = _Model.ObtenerListaSectores();

            if (oResultadoSector.oEstado == TipoRespuesta.Exito)
            {
                LstSectorNew = (List<View_SectoresEmpresariales>)oResultadoSector.ListaEntidadDatos;
            }


            return LstSectorNew;
        }
    }
}
