using System;
using Library.Utilidades;
using IDGI.DataObjects;
using Library.Utilidades.Enums;
using Library.Exception;
using IDGI.CultureResource;
using IDGI.Entities;
using System.Collections.Generic;
using System.Linq;

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
        public ResultadoOperacion ObtenerEmpresaPaginado(int iPageNumber, string ExpresionFiltro, string _OrdenCampoDispSelect)
        {
            objEmpDao = new EmpresasDAO();
            ResultadoOperacion oResultadoEmpresaPag = new ResultadoOperacion();
            List<DtoEmpresa> lstEmpresa = objEmpDao.ObtenerListaEmpresa();

            if (lstEmpresa != null && lstEmpresa.Count > 0)
            {
                var records = from emp in lstEmpresa
                              select emp;

                var PageNumber = iPageNumber;
                int showItem = Globales.iRegistrosPaginaSmall;

                var lista = new List<DtoEmpresa>();

                // Realiza el filtro en de la lista en memoria
                if (ExpresionFiltro != string.Empty)
                {
                    records = records.Where(x => x.Nom_Empresa.Contains(ExpresionFiltro)).ToList();
                }

                //Ordena la lista en memoria segun la dirección de la columna
                if (_OrdenCampoDispSelect.ToLower() == "asc")
                {
                    lista = records.OrderBy(p => p.Nom_Empresa).ToList();
                }
                else
                {
                    lista = records.OrderByDescending(p => p.Nom_Empresa).ToList();
                }

                records = lista.Skip((PageNumber - 1) * showItem).Take(showItem);

                int i = 1;
                DtoEmpresa oDtoNewEmpresa = null;
                List<DtoEmpresa> lstNewEmpresa = new List<DtoEmpresa>();

                foreach (var item in records)
                {
                    oDtoNewEmpresa = new DtoEmpresa();
                    oDtoNewEmpresa.Correo_Empresa = item.Correo_Empresa;
                    oDtoNewEmpresa.Dir_Empresa = item.Dir_Empresa;
                    oDtoNewEmpresa.EstaActiva = item.EstaActiva;
                    oDtoNewEmpresa.Id_Ciudad = item.Id_Ciudad;
                    oDtoNewEmpresa.Id_Empresa = item.Id_Empresa;
                    oDtoNewEmpresa.Id_SectorEmpresarial = item.Id_SectorEmpresarial;
                    oDtoNewEmpresa.Nit_Empresa = item.Nit_Empresa;
                    oDtoNewEmpresa.Nom_Contacto = item.Nom_Contacto;
                    oDtoNewEmpresa.Nom_Empresa = item.Nom_Empresa;
                    oDtoNewEmpresa.Num_Personal = item.Num_Personal;
                    oDtoNewEmpresa.Telf_Empresa = item.Telf_Empresa;
                    oDtoNewEmpresa.TotalRegistros = lista.Count;
                    oDtoNewEmpresa.Row = i;
                    i += 1;
                    lstNewEmpresa.Add(oDtoNewEmpresa);
                }

                oResultadoEmpresaPag.ListaEntidadDatos = lstNewEmpresa;
            }

            return oResultadoEmpresaPag;
        }
        public ResultadoOperacion ObtenerListaEmpresas()
        {
            ResultadoOperacion oResultadoEmpresa = new ResultadoOperacion();

            List<DtoEmpresa> lstEmpresa = objEmpDao.ObtenerListaEmpresa();

            if (lstEmpresa != null && lstEmpresa.Count > 0)
            {

                List<DtoEmpresa> lstEmpresaFiltro = (from obj in lstEmpresa
                                                     where obj.EstaActiva == true
                                                     select new DtoEmpresa
                                                     {
                                                         Correo_Empresa = obj.Correo_Empresa,
                                                         Id_Ciudad = obj.Id_Ciudad,
                                                         Dir_Empresa = obj.Dir_Empresa,
                                                         Id_Empresa = obj.Id_Empresa,
                                                         Id_SectorEmpresarial = obj.Id_SectorEmpresarial,
                                                         Nit_Empresa = obj.Nit_Empresa,
                                                         Nom_Contacto = obj.Nom_Contacto,
                                                         Nom_Empresa = obj.Nom_Empresa,
                                                         Num_Personal = obj.Num_Personal,
                                                         Telf_Empresa = obj.Telf_Empresa,
                                                         EstaActiva = obj.EstaActiva
                                                     }).ToList();


                oResultadoEmpresa.ListaEntidadDatos = lstEmpresaFiltro;
                oResultadoEmpresa.oEstado = TipoRespuesta.Exito;
            }

            return oResultadoEmpresa;
        }



    }
}
