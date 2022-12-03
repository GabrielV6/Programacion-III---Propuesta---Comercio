<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioCliente.aspx.cs" Inherits="tp_comercio_Vargas_Delgado.FormularioCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mx-auto p-5" style="width: 400px;">
        <h2 class="text-center">Formulario Cliente</h2>
    </div>

    <div class="container justify-content-sm-center">
        <div class="mb-3">

            <label for="txtNombre" class="form-label">Nombre</label>
            <asp:TextBox ID="txtNombreCliente" runat="server" CssClass="form-control" required=""></asp:TextBox>

            <label for="txtApellido" class="form-label">Apellido</label>
            <asp:TextBox ID="txtApellidoCliente" runat="server" CssClass="form-control" required=""></asp:TextBox>

            <label for="txtDni" class="form-label">Dni</label>
            <asp:TextBox ID="txtDniCliente" runat="server" CssClass="form-control" required=""></asp:TextBox>
            <asp:RangeValidator ID="Range1"
                ControlToValidate="txtDniCliente"
                MinimumValue="3000000"
                MaximumValue="99000000"
                Type="Integer"
                EnableClientScript="false"
                Text="Por favor, ingrese un numero de DNI valido"
                runat="server" />

            <label for="txtTelefono" class="form-label">Telefono</label>
            <asp:TextBox ID="txtTelefonoCliente" runat="server" CssClass="form-control" required=""></asp:TextBox>
            <asp:RangeValidator ID="Range2"
                ControlToValidate="txtTelefonoCliente"
                MinimumValue="11111111"
                MaximumValue="99999999"
                Type="Integer"
                EnableClientScript="false"
                Text="Por favor, ingrese un numero de telefono valido"
                runat="server" />

            <label for="txtEmail" class="form-label" required="">Email</label>
            <asp:TextBox ID="txtEmailCliente" runat="server" CssClass="form-control" required=""></asp:TextBox>



        </div>
        <div class="mb-3">
            <h7>El codigo se agregara de manera automatica</h7>
        </div>
        <asp:Button Text="Aceptar" ID="btnAceptarCliente" CssClass="btn btn-warning" OnClick="btnAceptar_Click" runat="server" />
        <%
            if (Session["usuariologueado"] != null && ((Dominio.RolUsuario)Session["rolusuario"]) == Dominio.RolUsuario.Administrador)
            {
        %>
        <asp:Button ID="btnEliminarCliente" runat="server" Text="Eliminar" CssClass="btn btn-warning" BackColor="Red" OnClick="btnEliminar_Click" />
        <%
            }
        %>
        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
    </div>

    <div class="container justify-content-sm-center">
        <a href="./WebVerCliente.aspx">Volver</a>

    </div>
</asp:Content>
