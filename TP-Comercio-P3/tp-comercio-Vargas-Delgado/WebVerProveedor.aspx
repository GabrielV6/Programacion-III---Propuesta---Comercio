<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="WebVerProveedor.aspx.cs" Inherits="tp_comercio_Vargas_Delgado.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="mx-auto p-5" style="width: 400px;">
        <h2 class="text-center">Listado de Provedores</h2>
    </div>

    <div class="container">
        <div class="row">
            <div class="col">
                <asp:TextBox ID="txtFiltroProveedor" runat="server"></asp:TextBox>
                <asp:Button ID="btnFiltroProveedor" runat="server" Text="Filtrar" class="btn btn-oitline-warning" OnClick="btnFiltro_Click" />
            </div>
        </div>
    </div>

    <div class="container">
        <div class="row justify-content-md-center">
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <div class="col-md-auto">
                        <div class="card-body">
                            <p class="card-text">RazonSocial: <b><%#Eval("RazonSocial")%></b></p>
                            <p class="card-text">Cuit: <b><%#Eval("Cuit")%></b></p>
                            <p class="card-text">Email: <b><%#Eval("Email")%></b></p>
                            <p class="card-text">Telefono: <b><%#Eval("Telefono")%></b></p>
                            <p class="card-text">Codigo:   <%#Eval("Id")%></p>
                        </div>
                        <div class="buttons">
                            <%
                                if (Session["usuariologueado"] != null && ((Dominio.RolUsuario)Session["rolusuario"]) == Dominio.RolUsuario.Administrador)
                                {
                            %>
                            <a class="btn btn-outline-success">Editar</a>
                            <asp:Button Text="Eliminar" ID="btnEliminar" CommandArgument='<%#Eval("Id")%>' class="btn btn-outline-danger" OnClick="btnEliminar_Click" runat="server"/>
                           
                            <%
                                }
                            %>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>




</asp:Content>
