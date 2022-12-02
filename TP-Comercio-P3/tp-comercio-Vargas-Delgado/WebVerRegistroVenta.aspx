<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="WebVerRegistroVenta.aspx.cs" Inherits="tp_comercio_Vargas_Delgado.WebVerRegistroVenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mx-auto p-5" style="width: 400px;">
        <h2 class="text-center">Registros de ventas</h2>
    </div>

    <div class="container-fluid">
        <div class="row justify-content-md-center">
            <asp:GridView ID="dgvRegistro" runat="server" OnSelectedIndexChanged="dgv_SelectedIndexChanged" DataKeyNames="Id" CssClass="table table-dark table-bordered" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="ID Registro" DataField="Id" />
                    <asp:BoundField HeaderText="Cliente" DataField="cliente.Nombre" />
                    <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
                    <asp:BoundField HeaderText="Monto" DataField="Monto" />
                    <asp:BoundField HeaderText="Articulo" DataField="articulo.nombre" />
                    <asp:CommandField ShowSelectButton="true" SelectText="📝" HeaderText="Accion" />
                </Columns>
            </asp:GridView>
            
        </div>
        <asp:Button ID="btnAgregar" runat="server" class="btn btn-outline-primary" OnClick="btnAgregar_Click"  Text="Agregar" />
    </div>
</asp:Content>
