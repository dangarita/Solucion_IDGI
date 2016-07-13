using IDGI.CultureResource;
using IDGI.Entities;
using Library.Utilidades;
using Library.Utilidades.Enums;
using Solucion_IDGI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
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
        #endregion

        #region Eventos Pagina
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarListas();
            }
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
                List<View_Departamento> lstDpto = (List<View_Departamento>)oResultadoDpto.ListaEntidadDatos;

                View_Departamento objDpto = new View_Departamento();
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
        private void CargarListas()
        {
            List<View_Pais> lstPais = _CrudEmpresa_Controller.ObtenerListaPais();

            View_Pais objPais = new View_Pais();
            objPais.Id_Pais = 0;
            objPais.Nom_Pais = Multilanguage.GetResourceManagerMultilingual(Session["ColtureInfo"].ToString(), "ResGeneral", "General_MensajeSeleccion");
            lstPais.Insert(0, objPais);

            ddlPais.DataSource = lstPais;
            ddlPais.DataBind();

            List<View_SectoresEmpresariales> lstSectores = _CrudEmpresa_Controller.ObtenerListaSectores();

            lisbxSectorEmpresa.DataSource = lstSectores;
            lisbxSectorEmpresa.DataBind();

        }

        #endregion

        #region Botones Principales

        #endregion

        protected void UpdatePanel_Datos_Load(object sender, EventArgs e)
        {
            UpdatePanel_Base.Update();
        }
    }

        
}