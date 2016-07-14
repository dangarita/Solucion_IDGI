<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_CrudEmpresa.ascx.cs" Inherits="Solucion_IDGI.Empresas.UC_CrudEmpresa" %>
<asp:UpdatePanel ID="UpdatePanel_Base" runat="server"
    ChildrenAsTriggers="False" UpdateMode="Conditional" RenderMode="Inline"
    OnLoad="UpdatePanel_Datos_Load">
    <ContentTemplate>
        <div class="row">
            <div class="form-group" id="Cliente">
                <asp:Label ID="lblEmpresa" runat="server" AssociatedControlID="txtEmpresa"
                    CssClass="col-md-2 control-label">Empresa</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox ID="txtEmpresa" runat="server"
                        onpaste="return false;"
                        CssClass="form-control" MaxLength="200"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="revEmpresa" ValidationGroup="ValidarCRUDEmpresa"
                        ControlToValidate="txtEmpresa" Display="Dynamic"
                        CssClass="text-danger" ErrorMessage="La empresa es obligatorio." />
                    <asp:CustomValidator ID="cvEmpresa" ValidationGroup="ValidarBuscarEmpresa"
                        runat="server" ControlToValidate="txtEmpresa"
                        CssClass="text-danger" ErrorMessage="Custom"
                        SetFocusOnError="True"></asp:CustomValidator>
                    <asp:RegularExpressionValidator ID="rexEmpresa" runat="server"
                        SetFocusOnError="True" CssClass="text-danger"
                        ControlToValidate="txtEmpresa" ValidationGroup="ValidarBuscarEmpresa" ErrorMessage="Minimo 3 caracteres"
                        ValidationExpression=".{3}.*"></asp:RegularExpressionValidator>
                </div>
            </div>
            <br /><br />
            <div class="form-group" id="Nit">
                <asp:Label ID="lblNit" runat="server" AssociatedControlID="txtNit"
                    CssClass="col-md-2 control-label">Nit</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox ID="txtNit" runat="server" MaxLength="20"
                        onkeypress="return numbersonly(event)" onpaste="return false;"
                        CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="revNit" ValidationGroup="ValidarCRUDEmpresa"
                        ControlToValidate="txtNit" Display="Dynamic"
                        CssClass="text-danger" ErrorMessage="Nit Obligatorio" />
                    <asp:CustomValidator ID="cvNit" ErrorMessage="Custom"
                        runat="server" ControlToValidate="txtNit" Display="None"
                        SetFocusOnError="True"></asp:CustomValidator>
                    <asp:RegularExpressionValidator ID="rexNit" runat="server"
                        SetFocusOnError="True" CssClass="text-danger" ErrorMessage="Minimo 6 caracteres"
                        ControlToValidate="txtNit" ValidationGroup="ValidarCRUDEmpresa"
                        ValidationExpression=".{6}.*"></asp:RegularExpressionValidator>

                </div>
            </div>
            <br /><br />
            <div class="form-group" id="NumPersonal">
                <asp:Label ID="lblNumPersonal" runat="server" AssociatedControlID="txtNumPersonal"
                    CssClass="col-md-2 control-label">Número de colaboradores</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox ID="txtNumPersonal" runat="server" MaxLength="7"
                        onkeypress="return numbersonly(event)" onpaste="return false;"
                        CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="revNumPersonal" ValidationGroup="ValidarCRUDEmpresa"
                        ControlToValidate="txtNumPersonal" Display="Dynamic"
                        CssClass="text-danger" ErrorMessage="NumPersonal Obligatorio" />
                    <asp:CustomValidator ID="cvNumPersonal"
                        runat="server" ControlToValidate="txtNumPersonal" Display="None" ErrorMessage="Custom"
                        SetFocusOnError="True"></asp:CustomValidator>
                    <asp:RegularExpressionValidator ID="rexNumPersonal" runat="server"
                        SetFocusOnError="True" CssClass="text-danger"
                        ControlToValidate="txtNumPersonal" ValidationGroup="ValidarCRUDEmpresa" ErrorMessage="Minimo 1 caracteres"
                        ValidationExpression=".{1}.*"></asp:RegularExpressionValidator>
                </div>
            </div>
            <br /><br />
            <div class="form-group" id="NomContatco">
                <asp:Label ID="lblNomContacto" runat="server" AssociatedControlID="txtNomContacto"
                    CssClass="col-md-2 control-label">Contacto</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox ID="txtNomContacto" runat="server" MaxLength="200"
                        onpaste="return false;" onkeypress="return soloLetras(event)" onblur="limpia()"
                        CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server"
                        ID="revNomContacto" ValidationGroup="ValidarCRUDEmpresa"
                        ControlToValidate="txtNomContacto" Display="Dynamic"
                        CssClass="text-danger" ErrorMessage="El Contacto es obligatorio." />
                    <asp:CustomValidator ID="cvNomContacto"
                        runat="server" ControlToValidate="txtNomContacto" Display="None" ErrorMessage="Custom"
                        SetFocusOnError="True"></asp:CustomValidator>
                    <asp:RegularExpressionValidator ID="rexNomContacto" runat="server"
                        SetFocusOnError="True" CssClass="text-danger"
                        ControlToValidate="txtNomContacto" ValidationGroup="ValidarCRUDEmpresa"
                        ValidationExpression=".{3}.*" ErrorMessage="Minimo 3 caracteres" ></asp:RegularExpressionValidator>
                </div>
            </div>
            <br /><br />
            <div class="form-group" id="TelfContacto">
                <asp:Label ID="lblTelfContacto" runat="server" AssociatedControlID="txtTelfContacto"
                    CssClass="col-md-2 control-label">Teléfono</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox ID="txtTelfContacto" runat="server" MaxLength="10"
                        onpaste="return false;" onkeypress="return numbersonly(event)"
                        CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="revTelfContacto" ValidationGroup="ValidarCRUDEmpresa"
                        ControlToValidate="txtTelfContacto" Display="Dynamic"
                        CssClass="text-danger" ErrorMessage="Télefono Obligatorio" />
                    <asp:CustomValidator ID="cvTelfContacto" Display="Dynamic"
                        runat="server" ControlToValidate="txtTelfContacto" ErrorMessage="Custom"
                        SetFocusOnError="True"></asp:CustomValidator>
                    <asp:RegularExpressionValidator ID="rexTelfContacto" runat="server"
                        SetFocusOnError="True" CssClass="text-danger" Display="Dynamic"
                        ControlToValidate="txtTelfContacto" ValidationGroup="ValidarCRUDEmpresa" ErrorMessage="Minimo 7 caracteres"
                        ValidationExpression=".{7}.*"></asp:RegularExpressionValidator>

                </div>
            </div>
            <br /><br />
            <div class="form-group" id="Direccion">
                <asp:Label ID="lblDireccion" runat="server" AssociatedControlID="txtDireccion"
                    CssClass="col-md-2 control-label">Dirección</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox ID="txtDireccion" runat="server" MaxLength="250"
                        onpaste="return false;"
                        CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="revDireccion" ValidationGroup="ValidarCRUDEmpresa"
                        ControlToValidate="txtDireccion" Display="Dynamic"
                        CssClass="text-danger" ErrorMessage="Dirección Obliatoria" />
                    <asp:CustomValidator ID="cvDireccion" Display="Dynamic"
                        runat="server" ControlToValidate="txtDireccion" ErrorMessage="Custom"
                        SetFocusOnError="True"></asp:CustomValidator>
                    <asp:RegularExpressionValidator ID="rexDireccion" runat="server"
                        SetFocusOnError="True" CssClass="text-danger" Display="Dynamic"
                        ControlToValidate="txtDireccion" ValidationGroup="ValidarCRUDEmpresa" ErrorMessage="Minimo 6 caracteres"
                        ValidationExpression=".{6}.*"></asp:RegularExpressionValidator>

                </div>
            </div>
            <br /><br />
            <div class="form-group" id="Correo">
                <asp:Label ID="lblCorreo" runat="server" AssociatedControlID="txtCorreo"
                    CssClass="col-md-2 control-label">Correo</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox ID="txtCorreo" runat="server"
                        CssClass="form-control" MaxLength="150"
                        onpaste="return false;"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" Display="Dynamic"
                        ControlToValidate="txtCorreo" ID="revCorreo" ValidationGroup="ValidarCRUDEmpresa"
                        CssClass="text-danger" ErrorMessage="El Correo es obligatorio." />
                    <asp:RegularExpressionValidator ID="rexCorreo" runat="server"
                        SetFocusOnError="True" CssClass="text-danger" Display="Dynamic"
                        ControlToValidate="txtCorreo" ValidationGroup="ValidarCRUDEmpresa" ErrorMessage="Correo invalido"
                        ValidationExpression="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?"></asp:RegularExpressionValidator>
                    <asp:CustomValidator ID="cvCorreo" Display="Dynamic"
                        runat="server" ControlToValidate="txtCorreo" ErrorMessage="Custom"
                        SetFocusOnError="True"></asp:CustomValidator>
                </div>
            </div>
            <br /><br />
            <div class="form-group" id="Pais">
                <asp:Label ID="lblPais" runat="server" AssociatedControlID="ddlPais"
                    CssClass="col-md-2 control-label">Pais</asp:Label>
                <div class="col-md-10">
                    <asp:DropDownList ID="ddlPais" runat="server"
                        DataTextField="Nom_Pais" DataValueField="Id_Pais"
                        OnSelectedIndexChanged="ddlPais_SelectedIndexChanged"
                        AutoPostBack="True" InitialValue="0"
                        CssClass="dropdown-toggle">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server"
                        ControlToValidate="ddlPais" ID="revPais" InitialValue="0"
                        ValidationGroup="ValidarCRUDEmpresa" Display="Dynamic"
                        CssClass="text-danger" ErrorMessage="El Pais es obligatorio." />
                </div>
            </div>
            <br /><br />
            <div class="form-group" id="Depto">
                <asp:Label ID="lblDepartamento" runat="server" AssociatedControlID="ddlDepartamento"
                    CssClass="col-md-2 control-label">Departamento</asp:Label>
                <div class="col-md-10">
                    <asp:DropDownList ID="ddlDepartamento" runat="server"
                        DataTextField="Nom_Departamento" DataValueField="Id_Departamento"
                        CssClass="dropdown-toggle" AutoPostBack="True" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" InitialValue="0" Display="Dynamic"
                        ControlToValidate="ddlDepartamento" ID="revDepto" ValidationGroup="ValidarCRUDEmpresa"
                        CssClass="text-danger" ErrorMessage="El Departamento es obligatorio." />
                </div>
            </div>
            <br /><br />
            <div class="form-group" id="ciudad">
                <asp:Label ID="lblCiudad" runat="server" AssociatedControlID="ddlCiudad"
                    CssClass="col-md-2 control-label">Ciudad</asp:Label>
                <div class="col-md-10">
                    <asp:DropDownList ID="ddlCiudad" runat="server"
                        DataTextField="Nom_Ciudad" DataValueField="Id_Ciudad"
                        CssClass="dropdown-toggle">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" InitialValue="0" Display="Dynamic"
                        ControlToValidate="ddlCiudad" ID="revCiudad" ValidationGroup="ValidarCRUDEmpresa"
                        CssClass="text-danger" ErrorMessage="La Ciudad es obligatorio." />
                </div>
            </div>
            <br /><br />
            <div class="form-group" id="Estado">
                <asp:Label ID="lblEstado" runat="server" AssociatedControlID="lblSwitch"
                    CssClass="col-md-2 control-label">Estado Empresa</asp:Label>
                <div class="col-md-10">
                    <label class="switch switch-flat" id="lblSwitch" runat="server">
                        <input class="switch-input" type="checkbox" checked="checked" id="chkEstado" runat="server" />
                        <span class="switch-label" data-on="On" data-off="Off" id="spanActivo" runat="server"></span>
                        <span class="switch-handle"></span>
                    </label>
                </div>
            </div>
            <br /><br />
            <div class="form-group">
                <asp:Label ID="lblSectorEmpresa" runat="server" AssociatedControlID="lisbxSectorEmpresa"
                    CssClass="col-md-2 control-label">Sector Empresarial</asp:Label>
                <div class="col-md-10" style="overflow-y: scroll; width: 600px; height: 300px; border: solid 1px #0088CF">
                    <asp:CheckBoxList ID="lisbxSectorEmpresa" runat="server" DataValueField="Id_SectorEmpresarial" Width="600px"
                        DataTextField="Nom_Sector" RepeatDirection="Vertical">
                    </asp:CheckBoxList>
                </div>
            </div>
            <br /><br />
        </div>
        <div class="form-group" style="padding-left: 15px">
            <asp:Button runat="server" ID="btnGuradar" 
                Text="Guardar" CssClass="btn btn-default" OnClick="btnGuradar_Click" ValidationGroup="ValidarCRUDEmpresa"/>
            <asp:Button runat="server" Text="Regresar" ID="btnRegresar"
                CssClass="btn btn-default" OnClick="btnRegresar_Click" />
        </div>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnGuradar" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnRegresar" EventName="Click" />
    </Triggers>
</asp:UpdatePanel>
