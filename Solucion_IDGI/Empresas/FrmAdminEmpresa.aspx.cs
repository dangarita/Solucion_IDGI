using IDGI.CultureResource;
using Library.Encryption;
using Library.Utilidades;
using Library.Utilidades.Enums;
using Solucion_IDGI.Base;
using Solucion_IDGI.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Solucion_IDGI.Empresas
{
    public partial class FrmAdminEmpresa : PageBaseChild
    {
        #region Definicion
        Empresa_Controller _Empresa_Controller
        {
            get
            {
                if (ViewState["_Empresa_Controller"] == null)
                    ViewState["_Empresa_Controller"] = new Empresa_Controller();

                return ViewState["_Empresa_Controller"] as Empresa_Controller;
            }
        }

        private IList lstGrillaEmpresas
        {
            get
            {
                return (ViewState["lstGrillaEmpresas"] == null) ? null : (IList)ViewState["lstGrillaEmpresas"];
            }
            set
            {
                ViewState["lstGrillaEmpresas"] = value;
            }
        }

        private int _IdeEliminacion
        {
            get
            {
                return (ViewState["_IdeEliminacion"] == null) ? 0 : (int)ViewState["_IdeEliminacion"];
            }
            set
            {
                ViewState["_IdeEliminacion"] = value;
            }
        }
        public OperacionCRUD _OperacionCRUD
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

        #region Eventos de Pagina
        public override void InicializarPagina()
        {
            SCampoOrden = "Nom_Empresa";
            SOrden = "asc";
            IPaginaActual = 1;
            eTipoPagina = TipoPaginaPaginado.PrimeraPagina;
            SFiltro = string.Empty;
            BindGrilla();
            string sMensajeEliminar = Multilanguage.GetResourceManagerMultilingual(Session["ColtureInfo"].ToString(), "ResGeneral", "General_Msj_Eliminar");

        }
        public override void PageLoad()
        {
            CargaRecursos();
        }
        #endregion

        #region CRUD
        public override void AdministrarCRUDConsultar(OperacionCRUD iOperacion)
        {
            //int idUsuario = Convert.ToInt32(grdCliente.SelectedDataKey[0]);

            //Response.Redirect(ObtenerUrl(OperacionCRUD.Consultar, idUsuario), false);

        }
        public override void AdministrarCRUDModificar(OperacionCRUD iOperacion)
        {
            //int IdCliente = Convert.ToInt32(grdCliente.SelectedDataKey[0]);

            //Response.Redirect(ObtenerUrl(OperacionCRUD.Modificar, IdCliente), false);

        }
        public override void AdministrarCRUDEliminar(OperacionCRUD iOperacion)
        {


        }

        #endregion

        #region Metodos
        private void ConsultarCliente()
        {
            SCampoOrden = "Nom_Cliente";
            SOrden = "asc";
            IPaginaActual = 1;
            eTipoPagina = TipoPaginaPaginado.PrimeraPagina;
            StringBuilder sbCadena = new StringBuilder();

            if (txtEmpresa.Text != string.Empty)
            {
                sbCadena.Append(" AND (Nom_Empresa LIKE '%");
                sbCadena.Append(txtEmpresa.Text);
                sbCadena.Append("%')");
            }
            if (txtNit.Text != string.Empty)
            {
                sbCadena.Append(" AND Nit_Cliente ='");
                sbCadena.Append(txtNit.Text);
                sbCadena.Append("'");
            }

            SFiltro = sbCadena.ToString();
            BindGrilla();
        }
        private string ObtenerUrl(OperacionCRUD oPeracion, int idCliente = 0, int idUsRol = 0)
        {
            StringBuilder sbUrl = new StringBuilder();
            sbUrl.Append("frmCrudEmpresa.aspx");
            sbUrl.Append("?Opera=");
            sbUrl.Append(oPeracion.ToString());
            if (idCliente > 0)
            {
                sbUrl.Append("&CodCl=");
                sbUrl.Append(Crypto.ActionEncrypt(idCliente.ToString()));
            }

            return sbUrl.ToString();
        }
        private void CargaRecursos()
        {
            this.Title = Multilanguage.GetResourceManagerMultilingual(Session["ColtureInfo"].ToString(), "ResCliente", "Cliente_Titulo_Admin");
            labelCollapse.InnerText = Multilanguage.GetResourceManagerMultilingual(Session["ColtureInfo"].ToString(), "ResGeneral", "General_Label_Buscar");

            //grdUsuarios.EmptyDataText = GeneralASP_Res.General_SinRegistrosBusqueda;
            btnNuevo.InnerText = Multilanguage.GetResourceManagerMultilingual(Session["ColtureInfo"].ToString(), "ResGeneral", "General_BtnNuevo");
            btnConsultar.Text = Multilanguage.GetResourceManagerMultilingual(Session["ColtureInfo"].ToString(), "ResGeneral", "General_Boton_Consultar");
            btnLimpiar.Text = Multilanguage.GetResourceManagerMultilingual(Session["ColtureInfo"].ToString(), "ResGeneral", "General_Boton_Limpiar");
            btnLimpiar.ToolTip = Multilanguage.GetResourceManagerMultilingual(Session["ColtureInfo"].ToString(), "ResGeneral", "General_ToolTip_BotonLimpiar");
            btnConsultar.ToolTip = Multilanguage.GetResourceManagerMultilingual(Session["ColtureInfo"].ToString(), "ResGeneral", "General_ToolTip_BotonConsultar");

            //Labels
            lblEmpresa.Text = Multilanguage.GetResourceManagerMultilingual(Session["ColtureInfo"].ToString(), "ResCliente", "Cliente_Label_Cliente");
            lblNit.Text = Multilanguage.GetResourceManagerMultilingual(Session["ColtureInfo"].ToString(), "ResCliente", "Cliente_Label_Nit");

            //Paginado
            lblNomTotReg.Text = Multilanguage.GetResourceManagerMultilingual(Session["ColtureInfo"].ToString(), "ResGeneral", "General_Label_TotalRegistros");
            lblNomPag.Text = Multilanguage.GetResourceManagerMultilingual(Session["ColtureInfo"].ToString(), "ResGeneral", "General_Label_Paginas");
            btnPrimeroGrilla.ToolTip = Multilanguage.GetResourceManagerMultilingual(Session["ColtureInfo"].ToString(), "ResGeneral", "General_Label_PrimPagina");
            btnAnteriorGrilla.ToolTip = Multilanguage.GetResourceManagerMultilingual(Session["ColtureInfo"].ToString(), "ResGeneral", "General_Label_PagAnterior");
            btnSiguienteGrilla.ToolTip = Multilanguage.GetResourceManagerMultilingual(Session["ColtureInfo"].ToString(), "ResGeneral", "General_Label_PagSiguiente");
            btnUltimoGrilla.ToolTip = Multilanguage.GetResourceManagerMultilingual(Session["ColtureInfo"].ToString(), "ResGeneral", "General_Label_UltPagina");
        }
        #endregion

        #region Botones Principales
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect(ObtenerUrl(OperacionCRUD.Nuevo), false);
        }
        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            ConsultarCliente();
        }
        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtEmpresa.Text = string.Empty;
            txtNit.Text = string.Empty;
            SCampoOrden = "Nom_Empresa";
            SOrden = "asc";
            IPaginaActual = 1;
            eTipoPagina = TipoPaginaPaginado.PrimeraPagina;
            sFiltro = string.Empty;
            BindGrilla();
        }

        public override Label LblFiltro
        {
            get { return null; }
        }

        public override Button btnPrimero
        {
            get { return btnPrimeroGrilla; }
        }

        public override Button btnAnterior
        {
            get { return btnAnteriorGrilla; }
        }

        public override Button btnSiguiente
        {
            get { return btnSiguienteGrilla; }
        }

        public override Button btnUltimo
        {
            get { return btnUltimoGrilla; }
        }
        #endregion

        #region Override Objetos

        public override UpdatePanel UpdatePanelPagina
        {
            get { return UpdatePanel_Base; }
        }
        public override Label LblPaginaActual
        {
            get { return lblPaginaActual; }
        }
        public override Label LblTotalNumberOfPages
        {
            get { return lblTotalNumberOfPages; }
        }
        public override System.Collections.IList Listado
        {
            get { return lstGrillaEmpresas as System.Collections.IList; }
            set { lstGrillaEmpresas = value; }
        }
        public override Label lblTotalFilas
        {
            get { return lblTotalRows; }
        }
        #endregion

        #region Grilla
        public override void BindGrilla()
        {
            grdEmpresa.Columns[3].Visible = true;

            //oDatosTraePagina.CampoOrden = SCampoOrden;
            //oDatosTraePagina.Orden = SOrden;
            //oDatosTraePagina.Filtro = sFiltro;
            //oDatosTraePagina.PaginaActual = IPaginaActual;
            //oDatosTraePagina.RegistrosPagina = IRegistrosPagina;
            //oDatosTraePagina.Tipo = (int)eTipoPagina;

            //List<DtoCliente> lstCliente = _Cliente_Controller.ObtenerClientePaginado(oDatosTraePagina);

            //if (lstCliente.Count > 0)
            //{
            //    string _Idioma = Session["ColtureInfo"].ToString();

            //    lstCliente.ForEach(i => i.Idioma = _Idioma);

            //    grdEmpresa.Columns[2].HeaderText = Multilanguage.GetResourceManagerMultilingual(Session["ColtureInfo"].ToString(), "ResCliente", "Cliente_Label_Cliente").Replace(" :", "");
            //    grdEmpresa.Columns[3].HeaderText = Multilanguage.GetResourceManagerMultilingual(Session["ColtureInfo"].ToString(), "ResCliente", "Cliente_Label_Nit").Replace(" :", "");
            //    grdEmpresa.Columns[4].HeaderText = Multilanguage.GetResourceManagerMultilingual(Session["ColtureInfo"].ToString(), "ResCliente", "Cliente_Label_CodCliente").Replace(" :", "");
               


            //    ListaGrilla = lstCliente.ToList();

            //    grdCliente.Columns[7].Visible = false;

            //    SiteMaster MasterPage = (SiteMaster)Page.Master;
            //    MasterPage.ActualizaObjetosFormulario(grdCliente);
            //}

        }
        public override GridView Grilla
        {
            get { return grdEmpresa; }
        }
        #endregion

        #region Mensajes
        private string sMuestraMensajeError
        {
            set
            {
                string sTitulo = Multilanguage.GetResourceManagerMultilingual(Session["ColtureInfo"].ToString(), "ResGeneral", "TituloModalMensajes_Tickets");
                General.MuestraMensaje(sTitulo, value, TipoMensajeWeb.Error, null, Page);
            }
        }

        #endregion
    }
}