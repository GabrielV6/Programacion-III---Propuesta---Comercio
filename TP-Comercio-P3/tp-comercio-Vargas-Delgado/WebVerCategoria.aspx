<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="WebVerCategoria.aspx.cs" Inherits="tp_comercio_Vargas_Delgado.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mx-auto p-5" style="width: 400px;">
        <h2 class="text-center">Listado de Categorias</h2>
    </div>

    <div class="container">
        <div class="row justify-content-md-center">
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <div class="col-md-auto">
                        <div class="card-body">
                            <p class="card-text">Nombre: <b><%#Eval("Descripcion")%></b></p>
                            <p class="card-text">Codigo:   <%#Eval("Id")%></p>
                        </div>
                        <div class="buttons">
                            <%
                                if (Session["usuariologueado"] != null && ((Dominio.RolUsuario)Session["rolusuario"]) == Dominio.RolUsuario.Administrador)
                                {
                            %>
                            <a class="btn btn-success">Editar</a>
                            <asp:Button Text="Eliminar" ID="btnEliminar" class="btn btn-danger" OnClick="btnEliminar_Click" runat="server" />
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
