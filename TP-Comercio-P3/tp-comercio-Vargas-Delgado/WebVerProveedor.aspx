<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="WebVerProveedor.aspx.cs" Inherits="tp_comercio_Vargas_Delgado.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mx-auto p-5" style="width: 400px;">
        <h2 class="text-center">Listado de Provedores</h2>
    </div>

    <div class="container-fluid">
        <div class="row">
            <div class="col">
                <asp:TextBox ID="txtFiltroProveedor" runat="server"></asp:TextBox>
                <asp:Button ID="btnFiltroProveedor" runat="server" Text="Filtrar" class="btn btn-oitline-warning" OnClick="btnFiltro_Click" />
            </div>
        </div>
    </div>

    <div class="container-fluid">
        <div class="row justify-content-md-center">
            <%-- 
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
                           
                            <asp:Button ID="btnEditar" runat="server" Text="Editar" class="btn btn-outline-success" OnClick="btnEditar_Click" CommandArgument='<%#Eval("Id") %>'  />
                            <asp:Button Text="Eliminar" ID="btnEliminar" CommandArgument='<%#Eval("Id")%>' class="btn btn-outline-danger" OnClick="btnEliminar_Click" runat="server"/>
                           
                            <%
                                }
                            %>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>--%>

            <asp:GridView ID="dgvProveedor" runat="server" OnSelectedIndexChanged="dgv_SelectedIndexChanged" DataKeyNames="Id" CssClass="table table-dark table-bordered" AutoGenerateColumns="false">

                <Columns>

                    <asp:BoundField HeaderText="ID Proveedor" DataField ="Id" />
                    <asp:BoundField HeaderText="Razon Social" DataField="RazonSocial" />
                    <asp:BoundField HeaderText="Cuit" DataField="Cuit" />
                    <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
                    <asp:BoundField HeaderText="Email" DataField="Email" />

                    <asp:CommandField ShowSelectButton="true" SelectText="📝" HeaderText="Accion" />
                </Columns>

            </asp:GridView>
        </div>
        <asp:Button ID="btnAgregar" runat="server" class="btn btn-outline-primary" OnClick="btnAgregar_Click"  Text="Agregar" />
    </div>



</asp:Content>
