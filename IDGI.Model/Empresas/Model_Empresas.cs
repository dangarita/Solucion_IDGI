using System;
using Library.Utilidades;
using IDGI.DataObjects;
using Library.Utilidades.Enums;
using Library.Exception;
using IDGI.CultureResource;

namespace IDGI.Model
{
    public partial class Model : IModel
    {
        private EmpresasDAO objEmpDao;
        public ResultadoOperacion ObtenerListaCiudad(int idDpto)
        {
            ResultadoOperacion oResultadoListaCiudad = new ResultadoOperacion();

            try
            {
                objEmpDao = new EmpresasDAO();

                //oResultadoListaCiudad.ListaEntidadDatos = objEmpDao.ObtenerListaCiudad(idDpto);
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

                //oResultadoListaDpto.ListaEntidadDatos = objEmpDao.ObtenerListaDpto(idPais);
            }
            catch (Exception ex)
            {
                oResultadoListaDpto.oEstado = TipoRespuesta.Error;
                oResultadoListaDpto.Mensaje = ex.Message;

                string sMensajeError = Multilanguage.GetResourceManagerMultilingual("ResGeneral", "General_MensajeErrorDpto");
                sMensajeError = sMensajeError + ex.Message;

                throw new DataBaseException(Globales.NombreAplicacion.ToUpper(), sMensajeError, new Exception(sMensajeError));

            }

            return oResultadoListaDpto;
        }

        public ResultadoOperacion ObtenerListaPais()
        {
            ResultadoOperacion oResultadoListaPais = new ResultadoOperacion();

            try
            {
                objEmpDao = new EmpresasDAO();

                //oResultadoListaPais.ListaEntidadDatos = objEmpDao.ObtenerListaPaises();
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
    }
}
