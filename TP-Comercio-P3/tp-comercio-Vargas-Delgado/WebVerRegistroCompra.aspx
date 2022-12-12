<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="WebVerRegistroCompra.aspx.cs" Inherits="tp_comercio_Vargas_Delgado.WebVerRegistroCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mx-auto p-5" style="width: 400px;">
        <h2 class="text-center">Registros de compras</h2>
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
            <asp:GridView ID="dgvRegistro" runat="server" OnSelectedIndexChanged="dgv_SelectedIndexChanged" DataKeyNames="Id" CssClass="table table-grey table-bordered" AutoGenerateColumns="false">
                <Columns>
                    <%--<asp:BoundField HeaderText="ID Registro" DataField="Id" />--%>
                    <asp:BoundField HeaderText="Remito N°" DataField="IdFactura" />
                    <asp:BoundField HeaderText="Fecha Remito" DataField="Fecha" />
                    <asp:BoundField HeaderText="Proveedor" DataField="proveedor.RazonSocial" />
                    <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
                    <asp:BoundField HeaderText="Precio costo $" DataField="Monto" />
                    <asp:BoundField HeaderText="Articulo" DataField="articulo.nombre" />
                   <%-- <asp:BoundField HeaderText="% De Ganancia x Articulo" DataField="articulo.Porcentaje" />--%>
                    <%--   <asp:CommandField ShowSelectButton="true" SelectText="Eliminar" HeaderText="Accion" /> --%>
                </Columns>
            </asp:GridView>

            <div class="container-fluid">
                <div class="row">
                    <div class="col">
                        <asp:Label ID="lblMontoRemito" runat="server" Text="Total Remito $"></asp:Label>
                        <asp:TextBox ID="txtMontoRemito" runat="server" ReadOnly="true"></asp:TextBox>

                    </div>
                </div>
            </div>

            </br>
            </br>
        </div>
        <asp:Button ID="btnAgregar" runat="server" class="u-border-none u-btn u-btn-submit u-button-style u-palette-2-base u-btn-1" OnClick="btnAgregar_Click" Text="Agregar" />
    </div>
</asp:Content>
