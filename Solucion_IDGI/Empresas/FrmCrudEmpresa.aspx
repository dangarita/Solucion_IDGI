<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCrudEmpresa.aspx.cs" 
    Inherits="Solucion_IDGI.Empresas.frmCrudEmpresa" %>

<%@ Register Src="~/Empresas/UC_CrudEmpresa.ascx" TagPrefix="uc1" TagName="UC_CrudEmpresa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <uc1:UC_CrudEmpresa runat="server" id="UC_CrudEmpresa" />
    </div>
</asp:Content>
