using IDGI.Entities;
using Library.Utilidades;
using Library.Utilidades.Enums;
using Solucion_IDGI.Controllers.Base;
using System;
using System.Collections.Generic;

namespace Solucion_IDGI.Controllers
{
    class CrudEmpresa_Controller : ControllerBase
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

        public List<View_Departamento> ObtenerListDpto(int idPais)
        {
            List<View_Departamento> LstDptoNew = new List<View_Departamento>();

            ResultadoOperacion oResultadoPais = _Model.ObtenerListaDptos(idPais);

            if (oResultadoPais.oEstado == TipoRespuesta.Exito)
            {
                LstDptoNew = (List<View_Departamento>)oResultadoPais.ListaEntidadDatos;
            }

            return LstDptoNew;
        }

        public List<View_Ciudad> ObtenerListCiudad(int idDpto)
        {
            List<View_Ciudad> LstCiudadNew = new List<View_Ciudad>();

            ResultadoOperacion oResultadoPais = _Model.ObtenerListaCiudad(idDpto);

            if (oResultadoPais.oEstado == TipoRespuesta.Exito)
            {
                LstCiudadNew = (List<View_Ciudad>)oResultadoPais.ListaEntidadDatos;
            }

            return LstCiudadNew;
        }
    }
}
