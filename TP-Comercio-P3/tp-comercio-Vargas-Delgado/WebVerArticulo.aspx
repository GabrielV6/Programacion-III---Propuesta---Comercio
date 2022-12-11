<%@ Page Title="Articulos" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="WebVerArticulo.aspx.cs" Inherits="tp_comercio_Vargas_Delgado.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mx-auto p-5" style="width: 400px;">
        <h2 class="text-center">Articulos disponibles</h2>
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

            <asp:GridView ID="dgvArticulo" runat="server" OnSelectedIndexChanged="dgv_SelectedIndexChanged" DataKeyNames="Id" CssClass="table table-grey table-bordered" AutoGenerateColumns="false">

                <Columns>

                    <asp:BoundField HeaderText="Nombre Articulo" DataField="Nombre" />
                    <asp:BoundField HeaderText="Precio " DataField="Precio" />
                    <asp:BoundField HeaderText="Categoria " DataField="Categoria.Descripcion" />
                    <asp:BoundField HeaderText="Marca " DataField="Marca.DescripcionMarca" />
                    <asp:BoundField HeaderText="Stock " DataField="Stock" />
                    <asp:BoundField HeaderText="Procentaje " DataField="Porcentaje" />
                    <asp:BoundField HeaderText="Proveedor " DataField="Proveedor.RazonSocial" />

                    <asp:CommandField ShowSelectButton="true" SelectText="📝" HeaderText="Accion" />
                </Columns>

            </asp:GridView>

        </div>
        <asp:Button ID="btnAgregar" runat="server" class="u-border-none u-btn u-btn-submit u-button-style u-palette-2-base u-btn-1" OnClick="btnAgregar_Click" Text="Agregar" />
    </div>
</asp:Content>
