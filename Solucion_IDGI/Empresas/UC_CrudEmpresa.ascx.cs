using IDGI.CultureResource;
using IDGI.Entities;
using Library.Utilidades;
using Library.Utilidades.Enums;
using Solucion_IDGI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Solucion_IDGI.Empresas
{
    public partial class UC_CrudEmpresa : System.Web.UI.UserControl
    {
        #region Definiciones
        protected CrudEmpresa_Controller _CrudEmpresa_Controller
        {
            get
            {
                if (ViewState["_CrudEmpresa_Controller"] == null)
                    ViewState["_CrudEmpresa_Controller"] = new CrudEmpresa_Controller();

                return ViewState["_CrudEmpresa_Controller"] as CrudEmpresa_Controller;
            }
        }
        private OperacionCRUD _OperacionCRUD
        {
            get
            {
                return (ViewState["_OperacionCRUD"] == null) ? 0 : (OperacionCRUD)ViewState["_OperacionCRUD"];
            }
            set
            {
                ViewState["_OperacionCRUD"] = value;
            }
        }
        protected List<DtoSectoresEmpresariales> ListaSectorEmpresarial
        {
            get { return (ViewState["ListaSectorEmpresarial"] == null) ? new List<DtoSectoresEmpresariales>() : (List<DtoSectoresEmpresariales>)ViewState["ListaSectorEmpresarial"]; }
            set
            {
                ViewState["ListaSectorEmpresarial"] = value;
            }
        }
        protected Empresa oEmpresaNew
        {
            get
            {
                Empresa oEmpresa = new Empresa();

                oEmpresa.Nom_Empresa = txtEmpresa.Text;
                oEmpresa.Nit_Empresa = txtNit.Text;
                oEmpresa.Nom_Contacto = txtNomContacto.Text;
                oEmpresa.Telf_Empresa = txtTelfContacto.Text;
                oEmpresa.Dir_Empresa = txtDireccion.Text;
                oEmpresa.Correo_Empresa = txtCorreo.Text;
                oEmpresa.Id_Ciudad = int.Parse(ddlCiudad.SelectedValue);
                oEmpresa.Num_Personal = int.Parse(txtNumPersonal.Text);
                oEmpresa.Id_SectorEmpresarial = int.Parse(lisbxSectorEmpresa.SelectedValue);
                
                return oEmpresa;
            } 
        }
        #endregion

        #region Eventos Pagina
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarListas();
            }
        }
        protected void UpdatePanel_Datos_Load(object sender, EventArgs e)
        {
            UpdatePanel_Base.Update();
        }
        #endregion

        #region Eventos Controles
        protected void ddlPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPais.SelectedIndex > 0)
            {
                if (_OperacionCRUD != OperacionCRUD.Consultar)
                {
                    ddlDepartamento.Enabled = true;
                }
                ObtenerDepartamentos();
                ddlDepartamento.Focus();               
            }
        }
        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDepartamento.SelectedIndex > 0)
            {
                if (_OperacionCRUD != OperacionCRUD.Consultar)
                {
                    ddlCiudad.Enabled = true;
                }

                ObtenerCiudades();
                ddlCiudad.Focus();
            }
        }        
        #endregion

        #region CRUD

        #endregion

        #region Metodos
        private string sMuestraMensajeError
        {
            set
            {
                string sTitulo = Multilanguage.GetResourceManagerMultilingual(Session["ColtureInfo"].ToString(), "ResGeneral", "TituloModalMensajes");
                General.MuestraMensaje(sTitulo, value, TipoMensajeWeb.Error, null, Page);
            }
        }
        private void ObtenerDepartamentos()
        {
            ddlDepartamento.Items.Clear();
            int idPais = Convert.ToInt32(ddlPais.SelectedValue.ToString());

            ResultadoOperacion oResultadoDpto = _CrudEmpresa_Controller.ObtenerListDpto(idPais);
            if (oResultadoDpto.oEstado == TipoRespuesta.Exito)
            {
                List<DtoDepartamento> lstDpto = (List<DtoDepartamento>)oResultadoDpto.ListaEntidadDatos;

                DtoDepartamento objDpto = new DtoDepartamento();
                objDpto.Id_Departamento = 0;
                objDpto.Nom_Departamento = Multilanguage.GetResourceManagerMultilingual(Session["ColtureInfo"].ToString(), "ResGeneral", "General_MensajeSeleccion");
                lstDpto.Insert(0, objDpto);

                ddlDepartamento.DataSource = lstDpto;
                ddlDepartamento.DataBind();
            }
            else
            {
                sMuestraMensajeError = oResultadoDpto.Mensaje;
            }           

        }
        private void ObtenerCiudades()
        {
            ddlCiudad.Items.Clear();
            int idDpto = Convert.ToInt32(ddlDepartamento.SelectedValue.ToString());

            ResultadoOperacion oResultadoCiudad = _CrudEmpresa_Controller.ObtenerListCiudad(idDpto);
            if (oResultadoCiudad.oEstado == TipoRespuesta.Exito)
            {
                List<DtoCiudad> lstCiudad = (List<DtoCiudad>)oResultadoCiudad.ListaEntidadDatos;

                DtoCiudad objCiudad = new DtoCiudad();
                objCiudad.Id_Ciudad = 0;
                objCiudad.Nom_Ciudad = Multilanguage.GetResourceManagerMultilingual(Session["ColtureInfo"].ToString(), "ResGeneral", "General_MensajeSeleccion");
                lstCiudad.Insert(0, objCiudad);

                ddlCiudad.DataSource = lstCiudad;
                ddlCiudad.DataBind();
            }
            else
            {
                sMuestraMensajeError = oResultadoCiudad.Mensaje;
            }
        }
        private void CargarListas()
        {
            List<DtoPais> lstPais = _CrudEmpresa_Controller.ObtenerListaPais();

            DtoPais objPais = new DtoPais();
            objPais.Id_Pais = 0;
            objPais.Nom_Pais = Multilanguage.GetResourceManagerMultilingual(Session["ColtureInfo"].ToString(), "ResGeneral", "General_MensajeSeleccion");
            lstPais.Insert(0, objPais);

            ddlPais.DataSource = lstPais;
            ddlPais.DataBind();

            List<DtoSectoresEmpresariales> lstSectores = _CrudEmpresa_Controller.ObtenerListaSectores();

            lisbxSectorEmpresa.DataSource = lstSectores;
            lisbxSectorEmpresa.DataBind();
            
        }
        private void GuardarDatos()
        {
            ResultadoOperacion oResultadoCRUD = new ResultadoOperacion();

            if (_OperacionCRUD == OperacionCRUD.Nuevo)
            {
                oResultadoCRUD = _CrudEmpresa_Controller.InsertarEmpresa(oEmpresaNew);

                if (oResultadoCRUD.oEstado == TipoRespuesta.Exito)
                {
                    string sMensaje = Multilanguage.GetResourceManagerMultilingual(Session["ColtureInfo"].ToString(), "ResGeneral", "General_Msj_InsercionOK");
                    string url = "frmAdminEmpresa.aspx";

                    StringBuilder sbAlert = new StringBuilder();

                    sbAlert.Append("alert('");
                    sbAlert.Append(sMensaje);
                    sbAlert.Append("');document.location.href ='");
                    sbAlert.Append(url);
                    sbAlert.Append("';");

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", sbAlert.ToString(), true);
                }
                else
                {
                    sMuestraMensajeError = oResultadoCRUD.Mensaje;
                }
            }
        }
        #endregion

        #region Botones Principales
        protected void btnGuradar_Click(object sender, EventArgs e)
        {
            GuardarDatos();
        }
        protected void btnRegresar_Click(object sender, EventArgs e)
        {

        }
        
        #endregion

    }

        
}