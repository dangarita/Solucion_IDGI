using System;
using Library.Utilidades;
using IDGI.DataObjects;
using Library.Utilidades.Enums;
using Library.Exception;
using IDGI.CultureResource;
using IDGI.Entities;

namespace IDGI.Model
{
    public partial class Model : IModel
    {
        private EmpresasDAO objEmpDao;

        public ResultadoOperacion InsertarEmpresa(Empresa Empresa)
        {
            ResultadoOperacion oResultadoInsEmpresa = new ResultadoOperacion();

            try
            {
                objEmpDao.InsertarEmpresa(Empresa);
                oResultadoInsEmpresa.oEstado = TipoRespuesta.Exito;
                oResultadoInsEmpresa.Mensaje= Multilanguage.GetResourceManagerMultilingual("ResGeneral", "General_Msj_InsercionOK");
            }
            catch (Exception ex)
            {
                oResultadoInsEmpresa.oEstado = TipoRespuesta.Error;
                oResultadoInsEmpresa.Mensaje = ex.Message;

                string sMensajeError = Multilanguage.GetResourceManagerMultilingual("ResGeneral", "General_Err_InsertBd");
                sMensajeError = sMensajeError + ex.Message;

                throw new DataBaseException(Globales.NombreAplicacion.ToUpper(), sMensajeError, new Exception(sMensajeError));
            }

            return oResultadoInsEmpresa;
        }
        public ResultadoOperacion ObtenerListaCiudad(int idDpto)
        {
            ResultadoOperacion oResultadoListaCiudad = new ResultadoOperacion();

            try
            {
                objEmpDao = new EmpresasDAO();

                oResultadoListaCiudad.ListaEntidadDatos = objEmpDao.ObtenerListaCiudad(idDpto);
            }
            catch (Exception ex)
            {
                oResultadoListaCiudad.oEstado = TipoRespuesta.Error;
                oResultadoListaCiudad.Mensaje = ex.Message;

                string sMensajeError = Multilanguage.GetResourceManagerMultilingual("ResGeneral", "General_MensajeErrorCiudad");
                sMensajeError = sMensajeError + ex.Message;

                throw new DataBaseException(Globales.NombreAplicacion.ToUpper(), sMensajeError, new Exception(sMensajeError));

            }

            return oResultadoListaCiudad;
        }
        public ResultadoOperacion ObtenerListaDptos(int idPais)
        {
            ResultadoOperacion oResultadoListaDpto = new ResultadoOperacion();

            try
            {
                objEmpDao = new EmpresasDAO();

                oResultadoListaDpto = objEmpDao.ObtenerListaDpto(idPais);
            }
            catch (Exception ex)
            {
                oResultadoListaDpto.oEstado = TipoRespuesta.Error;

                string sMensajeError = Multilanguage.GetResourceManagerMultilingual("ResGeneral", "General_MensajeErrorDpto");
                sMensajeError = sMensajeError + ": " + ex.Message;

                oResultadoListaDpto.Mensaje = sMensajeError;
            }

            return oResultadoListaDpto;
        }
        public ResultadoOperacion ObtenerListaPais()
        {
            ResultadoOperacion oResultadoListaPais = new ResultadoOperacion();

            try
            {
                objEmpDao = new EmpresasDAO();

                oResultadoListaPais.ListaEntidadDatos = objEmpDao.ObtenerListaPaises();
            }
            catch (Exception ex)
            {
                oResultadoListaPais.oEstado = TipoRespuesta.Error;
                oResultadoListaPais.Mensaje = ex.Message;

                string sMensajeError = Multilanguage.GetResourceManagerMultilingual("ResGeneral", "General_MensajeErrorPais");
                sMensajeError = sMensajeError + ex.Message;

                throw new DataBaseException(Globales.NombreAplicacion.ToUpper(), sMensajeError, new Exception(sMensajeError));

            }

            return oResultadoListaPais;
        }
        public ResultadoOperacion ObtenerListaSectores()
        {
            ResultadoOperacion oResultadoListaSector = new ResultadoOperacion();

            try
            {
                objEmpDao = new EmpresasDAO();

                oResultadoListaSector.ListaEntidadDatos = objEmpDao.ObtenerListaSectores();
            }
            catch (Exception ex)
            {
                oResultadoListaSector.oEstado = TipoRespuesta.Error;
                oResultadoListaSector.Mensaje = ex.Message;

                string sMensajeError = Multilanguage.GetResourceManagerMultilingual("ResEmpresa", "Empresa_MensajeErrorSector");
                sMensajeError = sMensajeError + ex.Message;

                throw new DataBaseException(Globales.NombreAplicacion.ToUpper(), sMensajeError, new Exception(sMensajeError));

            }

            return oResultadoListaSector;
        }
        public ResultadoOperacion ObtenerEmpresaPaginado()
        {
            ResultadoOperacion oResultadoEmpresaPag = new ResultadoOperacion();

            return oResultadoEmpresaPag;
        }
        public ResultadoOperacion ObtenerListaEmpresa(Empresa oEmpresa)
        {
            ResultadoOperacion oResultadoEmpresa = new ResultadoOperacion();

            return oResultadoEmpresa;
        }
    }
}
