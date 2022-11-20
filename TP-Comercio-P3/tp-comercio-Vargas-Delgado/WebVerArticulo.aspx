﻿<%@ Page Title="Articulos" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="WebVerArticulo.aspx.cs" Inherits="tp_comercio_Vargas_Delgado.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mx-auto p-5" style="width: 400px;">
        <h2 class="text-center">Articulos disponibles</h2>
    </div>

    <div class="container">
        <div class="row">
            <div class="col">
                <asp:TextBox ID="txtFiltro" runat="server" />
                <asp:Button Text="Filtrar" ID="btnFiltro" class="btn btn-outline-warning" OnClick="btnFiltro_Click" runat="server" />
            </div>
        </div>
    </div>

    <div class="container">
        <div class="row row-cols-1 row-cols-sm-5 g-3 justify-content-md-center">

            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>

                    <div class="col">

                        <div class="card h-100">

                            <img src="<%#Eval("ImagenUrl")%>" class="card-image h-50" alt="image" />
                            <h5 class="card-title h-30"><%#Eval("Nombre")%></h5>
                            <p class="card-price"><%#Eval("Precio")%></p>
                            <p class="card-categoria"><b>Categoria:</b> <%#Eval("Categoria.Descripcion")%></p>
                            <p class="card-marca"><b>Marca: </b><%#Eval("Marca.DescripcionMarca")%></p>
                            <p class="card-stock"><b>Stock: </b><%#Eval("Stock")%></p>

                            <div class="vstack">
                                <asp:Button ID="btnVerDetalle" runat="server" Text="Ver detalle" class="btn btn-outline-primary" OnClick="btnEditar_Click" CommandArgument='<%#Eval("Id") %>' />
                                <%
                                    if (Session["usuariologueado"] != null && ((Dominio.RolUsuario)Session["rolusuario"]) == Dominio.RolUsuario.Administrador)
                                    {
                                %>
                                <asp:Button ID="btnEditar" runat="server" Text="Editar" class="btn btn-outline-success" OnClick="btnEditar_Click" CommandArgument='<%#Eval("Id") %>' />
                                <asp:Button Text="Eliminar" ID="btnEliminar" CommandArgument='<%#Eval("Id")%>' class="btn btn-outline-danger" OnClick="btnEliminar_Click" runat="server" />
                                <%
                                    }
                                %>
                            </div>

                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
