<%@ Page Title="Ver Marca" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="WebVerMarca.aspx.cs" Inherits="tp_comercio_Vargas_Delgado.WebVerMarca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mx-auto p-5" style="width: 400px;">
        <h2 class="text-center">Listado de Marcas</h2>
    </div>

    <div class="row row-cols-1 row-cols-md-2 g-4">
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <div class="card-body">
                            <p class="card-text">Nombre: <b><%#Eval("DescripcionMarca")%></b></p>
                            <p class="card-text">Codigo:   <%#Eval("Id")%></p>
                        </div>
                        <div class="buttons">
                            <%
                                if (Session["usuariologueado"] != null && ((Dominio.RolUsuario)Session["rolusuario"]) == Dominio.RolUsuario.Administrador)
                                {

                            %>
                            <a class="btn btn-success">Editar</a>
                            <a class="btn btn-danger">Eliminar</a>
                            <%
                                }
                            %>
                        </div>
                    </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
