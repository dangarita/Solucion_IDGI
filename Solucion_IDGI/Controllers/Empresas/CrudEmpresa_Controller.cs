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
        public ResultadoOperacion ObtenerListDpto(int idPais)
        {
            List<DtoDepartamento> LstDptoNew = new List<DtoDepartamento>();

            ResultadoOperacion oResultadoDpto = _Model.ObtenerListaDptos(idPais);

            if (oResultadoDpto.oEstado == TipoRespuesta.Exito)
            {
                LstDptoNew = (List<DtoDepartamento>)oResultadoDpto.ListaEntidadDatos;
                oResultadoDpto.ListaEntidadDatos = LstDptoNew;
            }

            return oResultadoDpto;
        }
        public ResultadoOperacion ObtenerListCiudad(int idDpto)
        {
            List<DtoCiudad> LstCiudadNew = new List<DtoCiudad>();

            ResultadoOperacion oResultadoCiudad = _Model.ObtenerListaCiudad(idDpto);

            if (oResultadoCiudad.oEstado == TipoRespuesta.Exito)
            {
                LstCiudadNew = (List<DtoCiudad>)oResultadoCiudad.ListaEntidadDatos;
                oResultadoCiudad.ListaEntidadDatos = LstCiudadNew;
            }

            return oResultadoCiudad;
        }
        public List<DtoSectoresEmpresariales> ObtenerListaSectores()
        {
            List<DtoSectoresEmpresariales> LstSectorNew = new List<DtoSectoresEmpresariales>();

            ResultadoOperacion oResultadoSector = _Model.ObtenerListaSectores();

            if (oResultadoSector.oEstado == TipoRespuesta.Exito)
            {
                LstSectorNew = (List<DtoSectoresEmpresariales>)oResultadoSector.ListaEntidadDatos;
            }


            return LstSectorNew;
        }
        public ResultadoOperacion InsertarEmpresa(Empresa Empresa)
        {
            return _Model.InsertarEmpresa(Empresa);
        }
        

    }
}
