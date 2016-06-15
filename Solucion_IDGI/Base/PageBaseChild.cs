// ===================================================
// Desarrollado Por		    : DIEGO ANDRÉS ANGARITA
// Fecha de Creación		: 20/08/2014
// Lenguaje Programación	: [C#]
// Producto o sistema	    : Smart Parking
// Empresa			        : e Global Tecnology
// Cliente			        : e Global Tecnology
// ===================================================
// Versión	Descripción
// [1.0.0.0]
// Clase BASE de informacion adicional para cada  
// pagina web
// ===================================================
// MODIFICACIONES:
// ===================================================
// Ver.	 Fecha		Autor – Empresa 	Descripción
// ---	 -------------	----------------------	----------------------------------------
// XX	dd/mm/aaaa	[Nombre Completo]	 [Razón del cambio realizado] 
// ===================================================
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library.Utilidades.Enums;
using Library.Utilidades;
using System.Reflection;
using Library.Exception;
using IDGI.CultureResource;

namespace Solucion_IDGI.Base
{
    [Serializable]
    public abstract class PageBaseChild : PageBase
    {
        #region Definiciones

        public Library.Utilidades.General _General = new Library.Utilidades.General();
        private string sPaginaAyuda;

        /// <summary>
        /// Nombre del campo por el al cual de va a ejecutar el orden en la grilla.
        /// </summary>
        private string m_SortExp
        {
            get
            {
                return (ViewState["m_SortExp"] == null) ? string.Empty : (string)ViewState["m_SortExp"];
            }
            set
            {
                ViewState["m_SortExp"] = value;
            }
        }

        /// <summary>
        /// Filtro adicional a la consulta asociada a la grilla.
        /// </summary>
        protected string sFiltro
        {
            get
            {
                return (ViewState["sFiltro"] == null) ? string.Empty : (string)ViewState["sFiltro"];
            }
            set
            {
                ViewState["sFiltro"] = value;
            }
        }

        /// <summary>
        /// Número de página actual en la cual se encuentra la grilla
        /// </summary>
        protected int iPaginaActual
        {
            get
            {
                return (ViewState["iPaginaActual"] == null) ? 0 : (int)ViewState["iPaginaActual"];
            }
            set
            {
                ViewState["iPaginaActual"] = value;
            }
        }

        /// <summary>
        /// Tipo de página que se despliega Primera Página, Siguiente, Anterior y Ultima.
        /// </summary>
        public TipoPaginaPaginado eTipoPagina
        {
            get
            {
                return (ViewState["tipoPagina"] == null) ? TipoPaginaPaginado.PrimeraPagina : (TipoPaginaPaginado)ViewState["tipoPagina"];
            }
            set
            {
                ViewState["tipoPagina"] = value;
            }
        }

        private int iRegistrosPagina
        {
            get
            {
                return Globales.iRegistrosPaginaLarge;
            }
        }

        /// <summary>
        /// Campo por el cual se realiza el ordenamiento de los datos en la grilla
        /// </summary>
        private string sCampoOrden
        {
            get
            {
                return (ViewState["sCampoOrden"] == null) ? string.Empty : (string)ViewState["sCampoOrden"];
            }
            set
            {
                ViewState["sCampoOrden"] = value;
            }
        }

        /// <summary>
        /// Orden Asc/Desc
        /// </summary>
        private string sOrden
        {
            get
            {
                return (ViewState["sOrden"] == null) ? string.Empty : (string)ViewState["sOrden"];
            }
            set
            {
                ViewState["sOrden"] = value;
            }
        }

        /// <summary>
        /// Total registros grilla
        /// </summary>
        protected int iTotalRegistros
        {
            get
            {
                return (ViewState["iTotalRegistros"] == null) ? 0 : (int)ViewState["iTotalRegistros"];
            }
            set
            {
                ViewState["iTotalRegistros"] = value;
            }
        }

        private int iTotalPaginas
        {
            get
            {
                return (ViewState["iTotalPaginas"] == null) ? 0 : (int)ViewState["iTotalPaginas"];
            }
            set
            {
                ViewState["iTotalPaginas"] = value;
            }
        }

        protected OperacionCRUD iOperacionCRUD
        {
            get
            {
                return (ViewState["iOperacionCRUD"] == null) ? 0 : (OperacionCRUD)ViewState["iOperacionCRUD"];
            }
            set
            {
                ViewState["iOperacionCRUD"] = value;
            }
        }

        protected StringBuilder sMensajeFiltro
        {
            get
            {
                return (ViewState["sMensajeFiltro"] == null) ? new StringBuilder() : (StringBuilder)ViewState["sMensajeFiltro"];
            }
            set
            {
                ViewState["sMensajeFiltro"] = value;
            }
        }

        private SortDirection m_SortDirection;

        private string sTabla
        {
            get
            {
                return (ViewState["sTabla"] == null) ? string.Empty : (string)ViewState["sTabla"];
            }
            set
            {
                ViewState["sTabla"] = value;
            }
        }

        private GridView grdConsulta;

        public GridView GrdConsulta
        {
            get { return grdConsulta; }
            set { grdConsulta = value; }
        }

        public int iResultado { get; set; }

        public string STabla
        {
            get { return sTabla; }
            set { sTabla = value; }
        }

        public string SFiltro
        {
            get { return sFiltro; }
            set { sFiltro = value; }
        }

        public int IPaginaActual
        {
            get { return iPaginaActual; }
            set { iPaginaActual = value; }
        }

        public int IRegistrosPagina
        {
            get
            {
                return iRegistrosPagina;
            }
        }

        public string SCampoOrden
        {
            get { return sCampoOrden; }
            set { sCampoOrden = value; }
        }

        public string SOrden
        {
            get { return sOrden; }
            set { sOrden = value; }
        }

        public string PaginaAyuda
        {
            get { return sPaginaAyuda; }
            set { sPaginaAyuda = value; }

        }

        #endregion

        #region Abstractos

        /// <summary>
        /// Metodo  que se ejecuta en el Page Load de la pagina
        /// </summary>
        public abstract void PageLoad();

        /// <summary>
        /// Metodo  que contiene la lógica de inicio
        /// </summary>
        public abstract void InicializarPagina();

        /// <summary>
        /// Metodo  que contiene la lógica al momento de eliminar
        /// </summary>
        public abstract void AdministrarCRUDEliminar(OperacionCRUD iOperacion);

        /// <summary>
        /// Metodo  que contiene la lógica al momento de modificar
        /// </summary>
        public abstract void AdministrarCRUDModificar(OperacionCRUD iOperacion);

        /// <summary>
        /// Metodo  que contiene la lógica al momento de consultar
        /// </summary>
        public abstract void AdministrarCRUDConsultar(OperacionCRUD iOperacion);

        public abstract void BindGrilla();


        /// <summary>
        /// GridView que presenta los registros a los que se le esta haciendo el CRUD
        /// </summary>
        public abstract GridView Grilla { get; }

        /// <summary>
        /// Label que presenta el filtro seleccionado
        /// </summary>
        public virtual Label LblFiltro { get { return null; } }

        public abstract Label lblTotalFilas { get; }


        /// <summary>
        /// Boton primero grilla
        /// </summary>
        public abstract Button btnPrimero { get; }

        /// <summary>
        /// Boton segundo grilla
        /// </summary>
        public abstract Button btnAnterior { get; }

        /// <summary>
        /// Boton siguiente grilla
        /// </summary>
        public abstract Button btnSiguiente { get; }

        /// <summary>
        /// Boton ultimo grilla
        /// </summary>
        public abstract Button btnUltimo { get; }

        /// <summary>
        /// Boton Filtro
        /// </summary>
        public virtual Button BtnFiltro { get { return null; } }

        /// <summary>
        /// Boton BtnSinFiltro
        /// </summary>
        public virtual Button BtnSinFiltro { get { return null; } }

        /// <summary>
        /// Boton BtnExportar
        /// </summary>
        public virtual Button BtnExportar { get { return null; } }

        /// <summary>
        /// Boton BtnExportar
        /// </summary>
        public abstract UpdatePanel UpdatePanelPagina { get; }

        /// <summary>
        /// label pagina Actual
        /// </summary>
        public abstract Label LblPaginaActual { get; }

        /// <summary>
        /// label número de paginas
        /// </summary>
        public abstract Label LblTotalNumberOfPages { get; }

        /// <summary>
        /// label pagina Actual
        /// </summary>
        public abstract IList Listado { get; set; }

        public virtual int NumeroRegistrosPagina
        {
            get
            {
                return Globales.iRegistrosPaginaLarge;
            }
        }

        #endregion

        #region EventosPagina

        protected void Page_Init(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsPostBack)
                {
                    iPaginaActual = 0;
                    sFiltro = string.Empty;
                }
            }
            catch (Exception ex)
            {
                ApplicationEGlobalException oAppliEx = new ApplicationEGlobalException("**Load Page Method Page_Init** " + ex.Message, ex);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsPostBack)
                {
                    General.RegistraVBScriptMensajes(Page);

                    sMensajeFiltro = new StringBuilder();
                    if (iPaginaActual == 0)
                    {
                        iPaginaActual = 1;
                        InicializarPagina();
                        m_SortExp = SCampoOrden;
                        m_SortDirection = Grilla.SortDirection;

                        Grilla.PageSize = NumeroRegistrosPagina;
                    }
                   

                    if (UpdatePanelPagina.UpdateMode == UpdatePanelUpdateMode.Conditional)
                    {
                        UpdatePanelPagina.Update();
                    }

                }

                PageLoad();

            }
            catch (Exception ex)
            {
                ApplicationEGlobalException oAppliEx = new ApplicationEGlobalException("**Load Page  Method Page_Load** " + ex.Message, ex);
            }
        }

        #endregion

        #region Grilla

        protected void grilla_RowCreated(object sender, GridViewRowEventArgs e)
        {
            try
            {
                // Check whether the row is a header row
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    // m_SortExp is the sort expression stored in the OnSorting event handler
                    if (String.Empty != m_SortExp)
                    {
                        // Based on the sort expression, find the index of the sorted column
                        int column = GetSortColumnIndex(Grilla, m_SortExp);
                        if (column != -1)
                            // Add an image to the sorted column header depending on the sort direction
                            AddSortImage(e.Row, column, m_SortDirection);
                    }
                }
            }
            catch (Exception ex)
            {
                ApplicationEGlobalException oAppliEx = new ApplicationEGlobalException("**Load Page Method grilla_RowCreated** " + ex.Message, ex);
            }
        }

        protected void grilla_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            //CONDICIONAL QUE SE USA PARA AGREGAR EL MENSAJE TOOLTIP A LOS ENCABEZADOS QUE ORDENAN EN LA GRILLA
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    foreach (TableCell cell in e.Row.Cells)
                    {
                        foreach (Control ctrl in cell.Controls)
                        {
                            if (ctrl.GetType().ToString().Contains("DataControlLinkButton"))
                            {
                                string sMensaje = Multilanguage.GetResourceManagerMultilingual(Session["ColtureInfo"].ToString(),"ResGeneral", "General_MensajeEncabezado_GrillaWeb");
                                cell.Attributes.Add("title", sMensaje + HttpUtility.HtmlDecode(((LinkButton)ctrl).Text) + "...");
                            }

                            if (ctrl.GetType().ToString().Contains("imgbModificarGrilla"))
                            {

                            }
                        }
                    }

                }
                else
                {
                    string sMensajeConsultar = Multilanguage.GetResourceManagerMultilingual(Session["ColtureInfo"].ToString(),"ResGeneral", "General_ToolTip_BotonConsultarGrilla");
                    if (e.Row.Cells[0].Controls.Count > 0)
                        ((ImageButton)e.Row.Cells[0].Controls[1]).ToolTip = sMensajeConsultar;

                    string sMensajeEditar = Multilanguage.GetResourceManagerMultilingual(Session["ColtureInfo"].ToString(),"ResGeneral", "General_ToolTip_BotonEditarGrilla");
                    if (e.Row.Cells[1].Controls.Count > 0)
                        ((ImageButton)e.Row.Cells[1].Controls[1]).ToolTip = sMensajeEditar;

                    string sMensajeTooltipEliminar = Multilanguage.GetResourceManagerMultilingual(Session["ColtureInfo"].ToString(),"ResGeneral"
                        , "General_ToolTip_BotonEliminaGrilla");
                    if (e.Row.Cells[2].Controls.Count > 0)
                    {
                        ((ImageButton)e.Row.Cells[2].Controls[1]).ToolTip = sMensajeTooltipEliminar;
                        string sMensajeEliminar = Multilanguage.GetResourceManagerMultilingual(Session["ColtureInfo"].ToString(), "ResGeneral", "General_Msj_Eliminar");
                        ((ImageButton)e.Row.Cells[2].Controls[1]).OnClientClick = "javascript:ConfirmDelete('" + sMensajeEliminar + "');";
                    }
                }
            }
            catch (Exception ex)
            {
                ApplicationEGlobalException oAppliEx = new ApplicationEGlobalException("**Load Page Method grilla_RowDataBound** " + ex.Message, ex);
            }
        }

        protected void grilla_Sorting(object sender, System.Web.UI.WebControls.GridViewSortEventArgs e)
        {
            try
            {
                SOrden = GetSortDirection(e.SortExpression);
                SCampoOrden = e.SortExpression;
                m_SortExp = e.SortExpression;
                m_SortDirection = e.SortDirection;
                eTipoPagina = TipoPaginaPaginado.PaginaActual;
                BindGrilla();
            }
            catch (Exception ex)
            {
                ApplicationEGlobalException oAppliEx = new ApplicationEGlobalException("**Load Page Method grilla_Sorting** " + ex.Message, ex);
            }
        }

        protected void grilla_PreRender(object sender, EventArgs e)
        {
           
        }

        protected void ActualizarTotalPaginas()
        {
            try
            {
                if (iTotalRegistros % this.NumeroRegistrosPagina > 0)
                {
                    iTotalPaginas = (int)(iTotalRegistros / this.NumeroRegistrosPagina) + 1;
                }
                else
                {
                    iTotalPaginas = (int)(iTotalRegistros / this.NumeroRegistrosPagina);
                }
                if (IPaginaActual > iTotalPaginas)
                {
                    IPaginaActual = IPaginaActual - 1;
                }

                if (iTotalPaginas <= 0)
                {
                    lblTotalFilas.Text = "0";
                }
                LblTotalNumberOfPages.Text = iTotalPaginas.ToString();
                m_SortExp = SCampoOrden;
                m_SortDirection = Grilla.SortDirection;
                LblPaginaActual.Text = iPaginaActual.ToString();
            }
            catch (Exception ex)
            {
                ApplicationEGlobalException oAppliEx = new ApplicationEGlobalException("**Load Page Method grilla_Sorting** " + ex.Message, ex);
            }
        }

        public string SortExpression
        {
            get { return (ViewState["SortExpression"] == null ? string.Empty : ViewState["SortExpression"].ToString()); }
            set { ViewState["SortExpression"] = value; }
        }

        public string SortDirection
        {
            get { return (ViewState["SortDirection"] == null ? string.Empty : ViewState["SortDirection"].ToString()); }
            set { ViewState["SortDirection"] = value; }
        }

        private string GetSortDirection(string sortExpression)
        {
            if (SortExpression == sortExpression)
            {
                if (SortDirection == "ASC")
                    SortDirection = "DESC";
                else if (SortDirection == "DESC")
                    SortDirection = "ASC";
                return SortDirection;
            }
            else
            {
                SortExpression = sortExpression;
                SortDirection = "ASC";
                return SortDirection;
            }
        }

        private int GetSortColumnIndex(GridView gridView, String sortExpression)
        {
            if (gridView == null)
                return -1;
            foreach (DataControlField field in gridView.Columns)
            {
                if (field.SortExpression == sortExpression)
                {
                    return gridView.Columns.IndexOf(field);
                }
            }
            return -1;
        }

        private void AddSortImage(GridViewRow headerRow, int column, SortDirection sortDirection)
        {
            if (-1 == column)
            {
                return;
            }
            // Create the sorting image based on the sort direction.
            Image sortImage = new Image();
            if (SortDirection == "ASC")
            {
                sortImage.ImageUrl = "~/Images/Png/Up_Blue.png";
                sortImage.AlternateText = "Orden Ascendente..";
            }
            else
            {
                sortImage.ImageUrl = "~/Images/Png/Down_Blue.png";
                sortImage.AlternateText = "Orden Descendente...";
            }
            // Add the image to the appropriate header cell.

            headerRow.Cells[column].Controls.Add(sortImage);
        }

        protected void btnPrimeroGrilla_Click(object sender, EventArgs e)
        {
            try
            {
                if (Listado == null)
                {
                    iPaginaActual = 0;
                    iTotalRegistros = 0;
                    ActualizarTotalPaginas();
                    return;
                }

                IPaginaActual = 1;
                LblPaginaActual.Text = iPaginaActual.ToString();
                eTipoPagina = TipoPaginaPaginado.PrimeraPagina;
                BindGrilla();
            }
            catch (Exception ex)
            {
                ApplicationEGlobalException oAppliEx = new ApplicationEGlobalException("**Load Page Method btnPrimeroGrilla_Click** " + ex.Message, ex);
            }
        }

        protected void btnAnteriorGrilla_Click(object sender, EventArgs e)
        {
            try
            {
                if (Listado == null)
                {
                    iPaginaActual = 0;
                    iTotalRegistros = 0;
                    ActualizarTotalPaginas();
                    return;
                }
                if (IPaginaActual > 1)
                {
                    eTipoPagina = TipoPaginaPaginado.PaginaAnterior;
                    BindGrilla();
                    IPaginaActual = IPaginaActual - 1;

                }
                else
                {
                    IPaginaActual = 2;
                    eTipoPagina = TipoPaginaPaginado.PrimeraPagina;
                    BindGrilla();
                    IPaginaActual = 1;
                }
                LblPaginaActual.Text = iPaginaActual.ToString();
            }
            catch (Exception ex)
            {
                ApplicationEGlobalException oAppliEx = new ApplicationEGlobalException("**Load Page Method btnAnteriorGrilla_Click** " + ex.Message, ex);
            }
        }

        protected void btnSiguienteGrilla_Click(object sender, EventArgs e)
        {
            try
            {
                if (Listado == null)
                {
                    iPaginaActual = 0;
                    iTotalRegistros = 0;
                    ActualizarTotalPaginas();
                    return;
                }

                if (IPaginaActual < iTotalPaginas)
                {
                    if (IPaginaActual > 1)
                    {
                        eTipoPagina = TipoPaginaPaginado.PaginaSiguiente;
                        BindGrilla();
                        IPaginaActual = IPaginaActual + 1;
                    }
                    else
                    {
                        eTipoPagina = TipoPaginaPaginado.PaginaSiguiente;
                        BindGrilla();
                        IPaginaActual = 2;
                    }
                }
                else
                {
                    eTipoPagina = TipoPaginaPaginado.UltimaPagina;
                    IPaginaActual = iTotalPaginas - 1;
                    //_presenter.TraePagina();
                    IPaginaActual = iTotalPaginas;
                }
                LblPaginaActual.Text = iPaginaActual.ToString();
            }
            catch (Exception ex)
            {
                ApplicationEGlobalException oAppliEx = new ApplicationEGlobalException("**Load Page Method btnSiguienteGrilla_Click** " + ex.Message, ex);
            }
        }

        protected void btnUltimoGrilla_Click(object sender, EventArgs e)
        {
            try
            {
                if (Listado == null)
                {
                    iPaginaActual = 0;
                    iTotalRegistros = 0;
                    ActualizarTotalPaginas();
                    return;
                }

                IPaginaActual = iTotalPaginas - 1;
                eTipoPagina = TipoPaginaPaginado.UltimaPagina;
                BindGrilla();
                IPaginaActual = iTotalPaginas;
                LblPaginaActual.Text = iPaginaActual.ToString();
            }
            catch (Exception ex)
            {
                ApplicationEGlobalException oAppliEx = new ApplicationEGlobalException("**Load Page btnUltimoGrilla_Click** " + ex.Message, ex);
            }
        }

        protected void btnConsultarGrilla_Command(object sender, CommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "consultar")
                {
                    int index = int.Parse(e.CommandArgument.ToString());
                    Grilla.SelectedIndex = index;

                    AdministrarCRUD(OperacionCRUD.Consultar);
                }
            }
            catch (Exception ex)
            {
                ApplicationEGlobalException oAppliEx = new ApplicationEGlobalException("**Load Page btnConsultarGrilla_Command** " + ex.Message, ex);
            }
        }

        protected void btnModificarGrilla_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "modificar")
                {
                    int index = int.Parse(e.CommandArgument.ToString());
                    Grilla.SelectedIndex = index;
                    AdministrarCRUD(OperacionCRUD.Modificar);
                }
            }
            catch (Exception ex)
            {
                ApplicationEGlobalException oAppliEx = new ApplicationEGlobalException("**Load Page** " + ex.Message, ex);
            }

        }      

        protected void btnEliminarGrilla_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "eliminar")
                {
                    int index = int.Parse(e.CommandArgument.ToString());
                    Grilla.SelectedIndex = index;
                    AdministrarCRUD(OperacionCRUD.Eliminar);
                    //ModalPopupEliminacion.Show();
                }
            }
            catch (Exception ex)
            {
                ApplicationEGlobalException oAppliEx = new ApplicationEGlobalException("**Load Page** " + ex.Message, ex);
            }
        }

        #endregion

        #region General

        protected IList ListaGrilla
        {
            set
            {
                try
                {
                    Listado = value;
                    Grilla.DataSource = Listado;
                    Grilla.DataBind();

                    if (value != null)
                    {

                        if (value.Count > 0)
                        {



                            if (Listado.Count > 0)
                            {
                                btnPrimero.Enabled = true;
                                btnAnterior.Enabled = true;
                                btnSiguiente.Enabled = true;
                                btnUltimo.Enabled = true;
                                PropertyInfo piCell = Listado[0].GetType().GetProperty("TotalRegistros");
                                lblTotalFilas.Text = piCell.GetValue(Listado[0], null).ToString();
                                iTotalRegistros = Convert.ToInt32(piCell.GetValue(Listado[0], null).ToString());

                                ActualizarTotalPaginas();


                            }
                            else
                            {
                                btnPrimero.Enabled = false;
                                btnAnterior.Enabled = false;
                                btnSiguiente.Enabled = false;
                                btnUltimo.Enabled = false;
                                LblPaginaActual.Text = "0";
                                LblTotalNumberOfPages.Text = "0";
                                lblTotalFilas.Text = "0";
                            }

                        }

                        else
                        {
                            btnPrimero.Enabled = false;
                            btnAnterior.Enabled = false;
                            btnSiguiente.Enabled = false;
                            btnUltimo.Enabled = false;
                            LblPaginaActual.Text = "0";
                            LblTotalNumberOfPages.Text = "0";
                            lblTotalFilas.Text = "0";

                        }

                    }
                    else
                    {
                        btnPrimero.Enabled = false;
                        btnAnterior.Enabled = false;
                        btnSiguiente.Enabled = false;
                        btnUltimo.Enabled = false;
                        LblPaginaActual.Text = "0";
                        LblTotalNumberOfPages.Text = "0";
                        lblTotalFilas.Text = "0";

                    }

                    if (UpdatePanelPagina.UpdateMode == UpdatePanelUpdateMode.Conditional)
                    {
                        UpdatePanelPagina.Update();
                    }

                }
                catch (Exception ex)
                {
                    ApplicationEGlobalException oAppliEx = new ApplicationEGlobalException("**Load Page ListaGrilla** " + ex.Message, ex);
                }

            }
        }
        private string sMuestraMensajeError
        {
            set
            {
                string sTitulo = Multilanguage.GetResourceManagerMultilingual(Session["ColtureInfo"].ToString(), "ResGeneral", "TituloModalMensajes_Tickets");
                General.MuestraMensaje(sTitulo, value, TipoMensajeWeb.Error, null, Page);
            }
        }
        #endregion

        #region CRUD

        protected void AdministrarCRUD(OperacionCRUD iOperacion)
        {
            if (OperacionCRUD.Consultar == iOperacion)
            {
                AdministrarCRUDConsultar(iOperacion);
            }
            if (OperacionCRUD.Modificar == iOperacion)
            {
                AdministrarCRUDModificar(iOperacion);
            }
            if (OperacionCRUD.Eliminar == iOperacion)
            {
                AdministrarCRUDEliminar(iOperacion);
            }
        }

        #endregion

        #region Botones Principales

        #endregion
    }
}