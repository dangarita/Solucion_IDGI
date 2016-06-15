<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_CrudEmpresa.ascx.cs" Inherits="Solucion_IDGI.Empresas.UC_CrudEmpresa" %>
<asp:UpdatePanel ID="UpdatePanel_Datos" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional" RenderMode="Inline">
    <ContentTemplate>
        <div class="row">
                    <div class="form-group" id="Cliente">
                        <asp:Label ID="lblEmpresa" runat="server" AssociatedControlID="txtEmpresa"
                            CssClass="col-md-2 control-label">Empresa</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox ID="txtEmpresa" runat="server"
                                onpaste="return false;"
                                CssClass="form-control" MaxLength="100"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="revEmpresa" ValidationGroup="ValidarBuscarEmpresa"
                                ControlToValidate="txtEmpresa" Display="Dynamic"
                                CssClass="text-danger" ErrorMessage="La empresa es obligatorio." />
                            <asp:CustomValidator ID="cvEmpresa" ValidationGroup="ValidarBuscarEmpresa"
                                runat="server" ControlToValidate="txtEmpresa"
                                CssClass="text-danger"
                                SetFocusOnError="True"></asp:CustomValidator>
                            <asp:RegularExpressionValidator ID="rexEmpresa" runat="server"
                                SetFocusOnError="True" CssClass="text-danger"
                                ControlToValidate="txtEmpresa" ValidationGroup="ValidarBuscarEmpresa"
                                ValidationExpression=".{3}.*"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group" id="Nit">
                        <asp:Label ID="lblNit" runat="server" AssociatedControlID="txtNit"
                            CssClass="col-md-2 control-label">Nit</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox ID="txtNit" runat="server" MaxLength="15"
                                onkeypress="return numbersonly(event)" onpaste="return false;"
                                CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="revNit" ValidationGroup="ValidarBuscarCliente"
                                ControlToValidate="txtNit" Display="Dynamic"
                                CssClass="text-danger" ErrorMessage="Cambiar Mensaje" />
                            <asp:CustomValidator ID="cvNit"
                                runat="server" ControlToValidate="txtNit" Display="None"
                                SetFocusOnError="True"></asp:CustomValidator>
                            <asp:RegularExpressionValidator ID="rexNit" runat="server"
                                SetFocusOnError="True" CssClass="text-danger"
                                ControlToValidate="txtNit" ValidationGroup="ValidarBuscarCliente"
                                ValidationExpression=".{6}.*"></asp:RegularExpressionValidator>

                        </div>
                    </div>
                    <div class="form-group" id="NomContatco">
                        <asp:Label ID="lblNomContacto" runat="server" AssociatedControlID="txtNomContacto"
                            CssClass="col-md-2 control-label">Contacto</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox ID="txtNomContacto" runat="server" MaxLength="100"
                                onpaste="return false;" onkeypress="return soloLetras(event)" onblur="limpia()"
                                CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server"
                                ID="revNomContacto" ValidationGroup="ValidarBuscarCliente"
                                ControlToValidate="txtNomContacto" Display="Dynamic"
                                CssClass="text-danger" ErrorMessage="El Contacto es obligatorio." />
                            <asp:CustomValidator ID="cvNomContacto"
                                runat="server" ControlToValidate="txtNomContacto" Display="None"
                                SetFocusOnError="True"></asp:CustomValidator>
                            <asp:RegularExpressionValidator ID="rexNomContacto" runat="server"
                                SetFocusOnError="True" CssClass="text-danger"
                                ControlToValidate="txtNomContacto" ValidationGroup="ValidarBuscarCliente"
                                ValidationExpression=".{3}.*"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group" id="TelfContacto">
                        <asp:Label ID="lblTelfContacto" runat="server" AssociatedControlID="txtTelfContacto"
                            CssClass="col-md-2 control-label">Teléfono</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox ID="txtTelfContacto" runat="server" MaxLength="20"
                                onpaste="return false;" onkeypress="return numbersonly(event)"
                                CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="revTelfContacto" ValidationGroup="ValidarBuscarCliente"
                                ControlToValidate="txtTelfContacto" Display="Dynamic"
                                CssClass="text-danger" ErrorMessage="Cambiar Mensaje" />
                            <asp:CustomValidator ID="cvTelfContacto" Display="Dynamic"
                                runat="server" ControlToValidate="txtTelfContacto"
                                SetFocusOnError="True"></asp:CustomValidator>
                            <asp:RegularExpressionValidator ID="rexTelfContacto" runat="server"
                                SetFocusOnError="True" CssClass="text-danger" Display="Dynamic"
                                ControlToValidate="txtTelfContacto" ValidationGroup="ValidarBuscarCliente"
                                ValidationExpression=".{7}.*"></asp:RegularExpressionValidator>

                        </div>
                    </div>
                    <div class="form-group" id="celContacto">
                        <asp:Label ID="lblCelContacto" runat="server" AssociatedControlID="txtCelContacto"
                            CssClass="col-md-2 control-label">Celular</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox ID="txtCelContacto" runat="server" MaxLength="12"
                                onpaste="return false;" onkeypress="return numbersonly(event)"
                                CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="revCelContacto" ValidationGroup="ValidarBuscarCliente"
                                ControlToValidate="txtCelContacto" Display="Dynamic"
                                CssClass="text-danger" ErrorMessage="Cambiar Mensaje" />
                            <asp:CustomValidator ID="cvCelContacto" Display="Dynamic"
                                runat="server" ControlToValidate="txtCelContacto"
                                SetFocusOnError="True"></asp:CustomValidator>
                            <asp:RegularExpressionValidator ID="rexCelContacto" runat="server"
                                SetFocusOnError="True" CssClass="text-danger" Display="Dynamic"
                                ControlToValidate="txtCelContacto" ValidationGroup="ValidarBuscarCliente"
                                ValidationExpression=".{10}.*"></asp:RegularExpressionValidator>

                        </div>
                    </div>
                    <div class="form-group" id="Direccion">
                        <asp:Label ID="lblDireccion" runat="server" AssociatedControlID="txtDireccion"
                            CssClass="col-md-2 control-label">Dirección</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox ID="txtDireccion" runat="server" MaxLength="100"
                                onpaste="return false;"
                                CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="revDireccion" ValidationGroup="ValidarBuscarCliente"
                                ControlToValidate="txtDireccion" Display="Dynamic"
                                CssClass="text-danger" ErrorMessage="Cambiar Mensaje" />
                            <asp:CustomValidator ID="cvDireccion" Display="Dynamic"
                                runat="server" ControlToValidate="txtDireccion"
                                SetFocusOnError="True"></asp:CustomValidator>
                            <asp:RegularExpressionValidator ID="rexDireccion" runat="server"
                                SetFocusOnError="True" CssClass="text-danger" Display="Dynamic"
                                ControlToValidate="txtDireccion" ValidationGroup="ValidarBuscarCliente"
                                ValidationExpression=".{6}.*"></asp:RegularExpressionValidator>

                        </div>
                    </div>
                    <div class="form-group" id="Correo">
                        <asp:Label ID="lblCorreo" runat="server" AssociatedControlID="txtCorreo"
                            CssClass="col-md-2 control-label">Correo</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox ID="txtCorreo" runat="server"
                                CssClass="form-control" MaxLength="150"
                                onpaste="return false;"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" Display="Dynamic"
                                ControlToValidate="txtCorreo" ID="revCorreo" ValidationGroup="ValidarBuscarCliente"
                                CssClass="text-danger" ErrorMessage="El Correo es obligatorio." />
                            <asp:RegularExpressionValidator ID="rexCorreo" runat="server"
                                SetFocusOnError="True" CssClass="text-danger" Display="Dynamic"
                                ControlToValidate="txtCorreo" ValidationGroup="ValidarBuscarCliente"
                                ValidationExpression=".{6}.*"></asp:RegularExpressionValidator>
                            <asp:CustomValidator ID="cvCorreo" Display="Dynamic"
                                runat="server" ControlToValidate="txtCorreo"
                                SetFocusOnError="True"></asp:CustomValidator>
                        </div>
                    </div>
                    <div class="form-group" id="Pais">
                        <asp:Label ID="lblPais" runat="server" AssociatedControlID="ddlPais"
                            CssClass="col-md-2 control-label">Pais</asp:Label>
                        <div class="col-md-10">
                            <asp:DropDownList ID="ddlPais" runat="server"
                                DataTextField="Nom_Pais" DataValueField="Ide_Pais"
                                OnSelectedIndexChanged="ddlPais_SelectedIndexChanged"
                                AutoPostBack="True" InitialValue="0"
                                CssClass="dropdown-toggle">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server"
                                ControlToValidate="ddlPais" ID="revPais" InitialValue="0"
                                ValidationGroup="ValidarBuscarCliente" Display="Dynamic"
                                CssClass="text-danger" ErrorMessage="El Pais es obligatorio." />
                        </div>
                    </div>
                    <div class="form-group" id="Depto">
                        <asp:Label ID="lblDepartamento" runat="server" AssociatedControlID="ddlDepartamento"
                            CssClass="col-md-2 control-label">Departamento</asp:Label>
                        <div class="col-md-10">
                            <asp:DropDownList ID="ddlDepartamento" runat="server"
                                DataTextField="Nom_Departamento" DataValueField="Ide_Departamento"
                                CssClass="dropdown-toggle" AutoPostBack="True" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" InitialValue="0" Display="Dynamic"
                                ControlToValidate="ddlDepartamento" ID="revDepto" ValidationGroup="ValidarBuscarCliente"
                                CssClass="text-danger" ErrorMessage="El Departamento es obligatorio." />
                        </div>
                    </div>
                    <div class="form-group" id="ciudad">
                        <asp:Label ID="lblCiudad" runat="server" AssociatedControlID="ddlCiudad"
                            CssClass="col-md-2 control-label">Ciudad</asp:Label>
                        <div class="col-md-10">
                            <asp:DropDownList ID="ddlCiudad" runat="server"
                                DataTextField="Nom_Ciudad" DataValueField="Ide_Ciudad"
                                CssClass="dropdown-toggle">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" InitialValue="0" Display="Dynamic"
                                ControlToValidate="ddlCiudad" ID="revCiudad" ValidationGroup="ValidarBuscarCliente"
                                CssClass="text-danger" ErrorMessage="La Ciudad es obligatorio." />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblTipoServicio" runat="server" AssociatedControlID="lisbxTipoServicio"
                            CssClass="col-md-2 control-label">Tipo Servicio</asp:Label>
                        <div class="col-md-10" style="OVERFLOW-Y:scroll; WIDTH:600px; border:solid 1px #0088CF">
                            <asp:CheckBoxList ID="lisbxTipoServicio" runat="server" DataValueField="Id_TipoServicio" Width="600px"
                                DataTextField="Nom_TipoServicio" RepeatDirection="Vertical">
                            </asp:CheckBoxList>
                        </div>
                    </div>
                    <div class="form-group" id="Estado">
                        <asp:Label ID="lblEstado" runat="server" AssociatedControlID="lblSwitch"
                            CssClass="col-md-2 control-label">Estado Cliente</asp:Label>
                        <div class="col-md-10">
                            <label class="switch switch-flat" id="lblSwitch" runat="server">
                                <input class="switch-input" type="checkbox" checked="checked" id="chkEstado" runat="server" />
                                <span class="switch-label" data-on="On" data-off="Off" id="spanActivo" runat="server"></span>
                                <span class="switch-handle"></span>
                            </label>
                        </div>
                    </div>
                    <br />
                </div>
    </ContentTemplate>
</asp:UpdatePanel>
