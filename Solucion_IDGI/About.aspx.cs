using IDGI.CultureResource;
using IDGI.Entities;
using Solucion_IDGI.Controllers;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Solucion_IDGI
{
    public partial class About : Page
    {
        protected Empresa_Controller _Empresa_Controller
        {
            get
            {
                if (ViewState["_Empresa_Controller"] == null)
                    ViewState["_Empresa_Controller"] = new Empresa_Controller();

                return ViewState["_Empresa_Controller"] as Empresa_Controller;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                List<DtoPais> lstPais = _Empresa_Controller.ObtenerListaPais();

                DtoPais objPais = new DtoPais();
                objPais.Id_Pais = 0;
                objPais.Nom_Pais = Multilanguage.GetResourceManagerMultilingual(Session["ColtureInfo"].ToString(), "ResGeneral", "General_MensajeSeleccion");
                lstPais.Insert(0, objPais);

                ddlPais.DataTextField = "Nom_Pais";
                ddlPais.DataValueField = "Id_Pais";
                ddlPais.DataSource = lstPais;
                ddlPais.DataBind();
            }
        }

    }
}