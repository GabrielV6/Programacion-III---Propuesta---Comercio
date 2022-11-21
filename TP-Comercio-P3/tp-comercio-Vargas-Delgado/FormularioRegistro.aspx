<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioRegistro.aspx.cs" Inherits="tp_comercio_Vargas_Delgado.FormularioRegistro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mx-auto p-5" style="width: 400px;">
        <h2 class="text-center">Agregar Registro</h2>
    </div>

    <div class="container justify-content-sm-center">
        <div class="mb-3">

            <label for="txtTipo" class="form-label">Tipo</label>
            <asp:TextBox ID="txtTipo" runat="server" CssClass="form-control"></asp:TextBox>

            <label for="txtDestinatario" class="form-label">Destinatario</label>
            <asp:TextBox ID="txtDestinatario" runat="server" CssClass="form-control"></asp:TextBox>

            <label for="ddlArticulo" class="form-label">Articulo</label>
            <asp:DropDownList ID="ddlArticulo" CssClass="form-select" runat="server"></asp:DropDownList>

            <label for="txtCantidad" class="form-label">Cantidad</label>
            <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control"></asp:TextBox>

            <label for="txtMonto" class="form-label">Monto</label>
            <asp:TextBox ID="txtMonto" runat="server" CssClass="form-control"></asp:TextBox>

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
    <div class="container justify-content-sm-center">
        <a href="./WebVerRegistro.aspx">Volver</a>
    </div>

</asp:Content>
