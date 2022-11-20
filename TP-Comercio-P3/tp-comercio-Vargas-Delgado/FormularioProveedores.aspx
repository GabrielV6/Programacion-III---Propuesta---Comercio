<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioProveedores.aspx.cs" Inherits="tp_comercio_Vargas_Delgado.FormularioProveedores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mx-auto p-5" style="width: 400px;">
        <h2 class="text-center">Agregar Proveedor</h2>
    </div>

    <div class="container justify-content-sm-center">
        <div class="mb-3">

            <label for="txtRazonSocial" class="form-label">RazonSocial</label>
            <asp:TextBox ID="txtRazonSocial" runat="server" CssClass="form-control"></asp:TextBox>

            <label for="txtCuit" class="form-label">Cuit</label>
            <asp:TextBox ID="txtCuit" runat="server" CssClass="form-control"></asp:TextBox>

            <label for="txtEmail" class="form-label">Email</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>

            <label for="txtTelefono" class="form-label">Telefono</label>
            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>

        </div>
        <div class="mb-3">
            <h7>El codigo se agregara de manera automatica</h7>
        </div>
     
        <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-warning" OnClick="btnAceptar_Click" />
     
        <%
            if (Session["usuariologueado"] != null && ((Dominio.RolUsuario)Session["rolusuario"]) == Dominio.RolUsuario.Administrador)
            {
        %>
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-warning" BackColor="Red" OnClick="btnEliminar_Click" />
        <%
            }
        %>
        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
    </div>

</asp:Content>
