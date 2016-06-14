<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Solucion_IDGI.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>
    <a class="btn icon-btn btn-default" href="#">
<span class="glyphicon btn-glyphicon glyphicon-save img-circle text-muted"></span> <!-- defining icon -->
Download <!-- defining text -->
</a>

<a class="btn icon-btn btn-muted" href="#">
<span class="glyphicon btn-glyphicon glyphicon-remove-circle img-circle text-muted"></span>
Unavailable
</a>

<a class="btn icon-btn btn-primary" href="#">
<span class="glyphicon btn-glyphicon glyphicon-thumbs-up img-circle text-primary"></span>
Like
</a>

<a class="btn icon-btn btn-success" href="#">
<span class="glyphicon btn-glyphicon glyphicon-plus img-circle text-success"></span>
Add
</a>

<a class="btn icon-btn btn-info" href="#">
<span class="glyphicon btn-glyphicon glyphicon-share img-circle text-info"></span>
Share
</a>

<a class="btn icon-btn btn-warning" href="#">
<span class="glyphicon btn-glyphicon glyphicon-minus img-circle text-warning"></span>
Remove
</a>

<a class="btn icon-btn btn-danger" href="#">
<span class="glyphicon btn-glyphicon glyphicon-trash img-circle text-danger"></span>
Delete
</a>
    <div>
        <asp:DropDownList ID="ddlPais" runat="server">
            
        </asp:DropDownList>
    </div>
    
</asp:Content>
