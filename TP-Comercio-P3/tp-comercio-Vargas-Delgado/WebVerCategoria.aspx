<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="WebVerCategoria.aspx.cs" Inherits="tp_comercio_Vargas_Delgado.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mx-auto p-5" style="width: 400px;">
        <h2 class="text-center">Listado de Categorias</h2>
    </div>

    <div class="container-fluid">
        <div class="row">
            <div class="col">
                <asp:TextBox ID="txtFiltro" runat="server" />
                <asp:Button Text="Filtrar" ID="btnFiltro" class="btn btn-outline-warning" OnClick="btnFiltro_Click" runat="server" />
            </div>
        </div>
    </div>

    <div class="container-fluid">
        <div class="row justify-content-md-center">
            <%-- <asp:Repeater ID="Repeater1" runat="server">
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
                            <asp:Button ID="btnEditar" runat="server" Text="Editar" class="btn btn-outline-success" OnClick="btnEditar_Click" CommandArgument='<%#Eval("Id") %>'  />
                            <asp:Button Text="Eliminar" ID="btnEliminar" CommandArgument='<%#Eval("Id")%>' class="btn btn-outline-danger" OnClick="btnEliminar_Click" runat="server" />
                            <%
                                }
                            %>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>--%>

            <asp:GridView ID="dgvCategoria" runat="server" OnSelectedIndexChanged="dgv_SelectedIndexChanged" DataKeyNames="Id" CssClass="table table-dark table-bordered" AutoGenerateColumns="false">

                <Columns>

                    <asp:BoundField HeaderText="Codigo Categoria" DataField="Id" />
                    <asp:BoundField HeaderText="Descripcion " DataField="Descripcion" />
              

                    <asp:CommandField ShowSelectButton="true" SelectText="📝" HeaderText="Accion" />
                </Columns>

            </asp:GridView>

        </div>
        <asp:Button ID="btnAgregar" runat="server" class="u-border-none u-btn u-btn-submit u-button-style u-palette-2-base u-btn-1" OnClick="btnAgregar_Click"  Text="Agregar" />
    </div>

</asp:Content>
