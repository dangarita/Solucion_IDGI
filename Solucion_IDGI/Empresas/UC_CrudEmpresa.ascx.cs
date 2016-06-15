using IDGI.CultureResource;
using IDGI.Entities;
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

        #region Eventos Formulario

        #endregion

        #region CRUD

        #endregion

        #region Metodos
        private void CargarListas()
        {
            List<View_Pais> lstPais = _CrudEmpresa_Controller.ObtenerListaPais();

            View_Pais objPais = new View_Pais();
            objPais.Id_Pais = 0;
            objPais.Nom_Pais = Multilanguage.GetResourceManagerMultilingual(Session["ColtureInfo"].ToString(), "ResGeneral", "General_MensajeSeleccion");
            lstPais.Insert(0, objPais);

            ddlPais.DataSource = lstPais;
            ddlPais.DataBind();
        }
        #endregion

        #region Botones Principales

        #endregion

        protected void ddlPais_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

        
    }