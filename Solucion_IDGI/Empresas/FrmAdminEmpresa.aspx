<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmAdminEmpresa.aspx.cs"
    Inherits="Solucion_IDGI.Empresas.FrmAdminEmpresa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel_Base" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional" RenderMode="Inline">
        <ContentTemplate>
            <input class="toggle-box" id="header1" type="checkbox">
            <label for="header1" runat="server" id="labelCollapse"></label>
            <div class="form-horizontal">
               <%-- <table class="table table-responsive">
                    <tbody>
                        <tr>
                            <td>
                                <asp:Label ID="lblEmpresa" runat="server" AssociatedControlID="txtEmpresa"
                                    CssClass="col-md-2 control-label">Empresa</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmpresa" runat="server"
                                    onpaste="return false;"
                                    CssClass="form-control" MaxLength="100"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblNit" runat="server" AssociatedControlID="txtNit"
                                    CssClass="col-md-2 control-label">Nit</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNit" runat="server" MaxLength="15"
                                    onkeypress="return numbersonly(event)" onpaste="return false;"
                                    CssClass="form-control"></asp:TextBox>
                            </td>
                        </tr>
                    </tbody>
                </table>--%>
                <br />
                <br />
                 <div class="form-group">
                    <asp:Label ID="lblCliente" runat="server" AssociatedControlID="txtCliente"
                        CssClass="col-md-2 control-label">Cliente</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox ID="txtCliente" runat="server"
                            onpaste="return false;"
                            CssClass="form-control" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblNit" runat="server" AssociatedControlID="txtNit"
                        CssClass="col-md-2 control-label">Nit</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox ID="txtNit" runat="server" MaxLength="15"
                            onkeypress="return numbersonly(event)" onpaste="return false;"
                            CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group" style="padding-left: 15px">
                    <asp:Button runat="server" ID="btnConsultar" ValidationGroup="ValidarBuscarCliente"
                        Text="Consultar" CssClass="btn btn-default" OnClick="btnConsultar_Click" />
                    <asp:Button runat="server" Text="Limpiar" ID="btnLimpiar"
                        CssClass="btn btn-default" OnClick="btnLimpiar_Click" />
                </div>
            </div>
            <br />
            <br />
            <div class="navbar-header">
                <a class="btn icon-btn btn-success" href="../Contact.aspx">
                    <span class="glyphicon btn-glyphicon glyphicon-plus img-circle text-success"></span>Add
                </a>
            </div>
            <br />
            <br />
            <div>
                <asp:GridView ID="grdCliente" runat="server" AllowSorting="True" CssClass="grid"
                    AlternatingRowStyle-CssClass="altrowstyle" AutoGenerateColumns="False"
                    CellPadding="0" DataKeyNames="Id_Cliente"
                    Height="16px" OnPreRender="grilla_PreRender" OnRowCreated="grilla_RowCreated"
                    OnRowDataBound="grilla_RowDataBound" OnSorting="grilla_Sorting" Administracionize="5"
                    Width="100%" TabIndex="8">
                    <SelectedRowStyle CssClass="selectedrow" />
                    <FooterStyle BorderStyle="Solid" BorderWidth="1px" />
                    <PagerStyle CssClass="pagerstyle" />
                    <RowStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
                        CssClass="FilaGrilla" />
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgbConsultarGrilla" runat="server"
                                    CausesValidation="False"
                                    CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                    OnCommand="btnConsultarGrilla_Command"
                                    CommandName="consultar" ImageUrl="~/Images/Ico-Search.png"
                                    ToolTip="Consultar Registro..." />
                            </ItemTemplate>
                            <HeaderStyle CssClass="EncabezadoGrillasinborde" Width="2%" />
                            <ItemStyle Width="2%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgbModificarGrilla" runat="server"
                                    CausesValidation="False" OnCommand="btnModificarGrilla_Command"
                                    CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                    CommandName="modificar" ImageUrl="~/Images/EditarGrid.png"
                                    ToolTip="" />
                            </ItemTemplate>
                            <HeaderStyle CssClass="EncabezadoGrillasinborde" Width="2%" />
                            <ItemStyle Width="2%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Nom_Empresa" HeaderText="Empresa" SortExpression="Nom_Empresa" HeaderStyle-Width="30%" ItemStyle-Width="5%" FooterStyle-Width="30%" />
                        <asp:BoundField DataField="Nit_Empresa" HeaderText="Nit" SortExpression="Nit_Empresa" HeaderStyle-Width="10%" ItemStyle-Width="10%" FooterStyle-Width="10%" />
                        <asp:BoundField DataField="Correo_Empresa" HeaderText="Correo" SortExpression="Correo_Empresa" HeaderStyle-Width="10%" ItemStyle-Width="10%" FooterStyle-Width="10%" />
                        <asp:BoundField DataField="Id_Empresa" HeaderText="" SortExpression="Id_Empresa" HeaderStyle-Width="30%" ItemStyle-Width="30%" FooterStyle-Width="30%" />

                    </Columns>
                    <HeaderStyle BorderStyle="Solid" BorderWidth="1px" CssClass="EncabezadoGrilla"
                        ForeColor="White" />
                    <AlternatingRowStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
                        CssClass="altrow" />
                </asp:GridView>
            </div>
            <br />
            <section id="Paginado">
                <table style="margin: 10px; width: 100%">
                    <tr>
                        <td class="TotalRegistros" style="text-align: center">
                            <asp:Label ID="lblNomTotReg" runat="server" Font-Bold="True"></asp:Label>&nbsp;
                                <asp:Label ID="lblTotalRows" runat="server" Font-Bold="True"></asp:Label>
                            &nbsp;&nbsp; -&nbsp;&nbsp;
                            <asp:Label ID="lblNomPag" runat="server" Font-Bold="True"></asp:Label>
                            <asp:Label ID="lblPaginaActual" runat="server"></asp:Label>
                            /&nbsp;<asp:Label ID="lblTotalNumberOfPages" runat="server"></asp:Label>&nbsp;
                                <asp:Button ID="btnPrimeroGrilla" runat="server" CssClass="pagfirst" OnClick="btnPrimeroGrilla_Click"
                                    ToolTip="Prim. Pag" CausesValidation="False" TabIndex="15" />
                            <asp:Button ID="btnAnteriorGrilla" runat="server" CssClass="pagprev" OnClick="btnAnteriorGrilla_Click"
                                ToolTip="Pág. anterior" CausesValidation="False" TabIndex="16" />
                            <asp:Button ID="btnSiguienteGrilla" runat="server" CssClass="pagnext" OnClick="btnSiguienteGrilla_Click"
                                ToolTip="Sig. página" CausesValidation="False" TabIndex="17" />
                            <asp:Button ID="btnUltimoGrilla" runat="server" CssClass="paglast" OnClick="btnUltimoGrilla_Click"
                                ToolTip="Últ. Pag" CausesValidation="False" TabIndex="18" />
                        </td>
                    </tr>
                </table>
            </section>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
