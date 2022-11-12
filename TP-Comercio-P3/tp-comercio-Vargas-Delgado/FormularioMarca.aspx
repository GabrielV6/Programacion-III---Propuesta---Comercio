<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioMarca.aspx.cs" Inherits="tp_comercio_Vargas_Delgado.FormularioMarca" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mx-auto p-5" style="width: 400px;">
        <h2 class="text-center">Agregar Marca</h2>
    </div>

    <div class="container justify-content-sm-center">
        <div class="mb-3">
            <label for="txtDescripcion" class="form-label">Nombre</label>
            <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" />
        </div>
        <div class="mb-3">
            <h7>El codigo se agregara de manera automatica</h7>
        </div>
        <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-warning" OnClick="btnAceptar_Click" runat="server" />     
    </div>

</asp:Content>
