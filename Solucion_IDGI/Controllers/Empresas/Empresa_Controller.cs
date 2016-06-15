using IDGI.Entities;
using Library.Utilidades;
using Library.Utilidades.Enums;
using Solucion_IDGI.Controllers.Base;
using System;
using System.Collections.Generic;

namespace Solucion_IDGI.Controllers
{
    [Serializable]
    public class Empresa_Controller : ControllerBase
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
    }
}
