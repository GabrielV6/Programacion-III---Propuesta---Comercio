<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="WebVerCliente.aspx.cs" Inherits="tp_comercio_Vargas_Delgado.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="mx-auto p-5" style="width: 400px;">
        <h2 class="text-center">Listado de Clientes</h2>
    </div>

    <div class="container">
        <div class="row">
            <div class="col">
      <%--          <asp:TextBox ID="txtFiltroCliente" runat="server"></asp:TextBox>
                <asp:Button ID="btnFiltroCliente" runat="server" Text="Filtrar" class="btn btn-oitline-warning" OnClientClick="btnFiltro_Click" />--%>


                <asp:TextBox ID="txtFiltroCliente" runat="server"></asp:TextBox>
                <asp:Button ID="btnFiltroCliente" runat="server" Text="Filtrar" class="btn btn-oitline-warnin" OnClick="btnFiltro_Click" />


            </div>
        </div>
    </div>

    <div class="container">
        <div class="row justify-content-md-center">
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <div class="col-md-auto">
                        <div class="card-body">
                            <p class="card-text">Nombre: <b><%#Eval("Nombre")%></b></p>
                            <p class="card-text">Apellido: <b><%#Eval("Apellido")%></b></p>
                            <p class="card-text">Dni: <b><%#Eval("Dni")%></b></p>
                            <p class="card-text">Telefono: <b><%#Eval("Telefono")%></b></p>
                            <p class="card-text">Email:   <%#Eval("Email")%></p>
                            <p class="card-text">Id:   <%#Eval("Id")%></p>
                        </div>
                        <div class="buttons">
                            <%
                                if (Session["usuariologueado"] != null && ((Dominio.RolUsuario)Session["rolusuario"]) == Dominio.RolUsuario.Administrador)
                                {
                            %>
                            
                            <asp:Button ID="btnEditar" runat="server" Text="Editar" class="btn btn-outline-success" OnClick="btnEditar_Click" CommandArgument='<%#Eval("Id") %>' />
                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandArgument='<%#Eval("Id")%>' class="btn btn-outline-danger" OnClick="btnEliminar_Click"  />
                           
                          
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
