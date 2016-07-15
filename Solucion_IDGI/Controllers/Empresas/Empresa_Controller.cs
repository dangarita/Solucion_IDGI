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
        public List<DtoPais> ObtenerListaPais()
        {
            List<DtoPais> LstpaisNew = new List<DtoPais>();

            ResultadoOperacion oResultadoPais = _Model.ObtenerListaPais();

            if (oResultadoPais.oEstado == TipoRespuesta.Exito)
            {
                LstpaisNew = (List<DtoPais>)oResultadoPais.ListaEntidadDatos;
            }


            return LstpaisNew;
        }
        public ResultadoOperacion ObtenerEmpresaPaginado(int iPageNumber, string ExpresionFiltro, string _OrdenCampoDispSelect)
        {
            return _Model.ObtenerEmpresaPaginado(iPageNumber, ExpresionFiltro, _OrdenCampoDispSelect);
        }
    }
    
}
