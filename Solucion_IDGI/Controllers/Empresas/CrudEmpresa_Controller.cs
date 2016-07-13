﻿using IDGI.Entities;
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

        public ResultadoOperacion ObtenerListDpto(int idPais)
        {
            List<View_Departamento> LstDptoNew = new List<View_Departamento>();

            ResultadoOperacion oResultadoDpto = _Model.ObtenerListaDptos(idPais);

            if (oResultadoDpto.oEstado == TipoRespuesta.Exito)
            {
                LstDptoNew = (List<View_Departamento>)oResultadoDpto.ListaEntidadDatos;
                oResultadoDpto.ListaEntidadDatos = LstDptoNew;
            }

            return oResultadoDpto;
        }

        public ResultadoOperacion ObtenerListCiudad(int idDpto)
        {
            List<View_Ciudad> LstCiudadNew = new List<View_Ciudad>();

            ResultadoOperacion oResultadoCiudad = _Model.ObtenerListaCiudad(idDpto);

            if (oResultadoCiudad.oEstado == TipoRespuesta.Exito)
            {
                LstCiudadNew = (List<View_Ciudad>)oResultadoCiudad.ListaEntidadDatos;
                oResultadoCiudad.ListaEntidadDatos = LstCiudadNew;
            }

            return oResultadoCiudad;
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

        public ResultadoOperacion InsertarEmpresa(Tbl_Empresa Empresa)
        {
            return _Model.InsertarEmpresa(Empresa);
        }
    }
}
