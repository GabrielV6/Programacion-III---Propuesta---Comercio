<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="WebVerRegistro.aspx.cs" Inherits="tp_comercio_Vargas_Delgado.WebVerRegistro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="mx-auto p-5" style="width: 400px;">
        <h2 class="text-center">Registros de Compra y Venta</h2>
    </div>

    <div class="container">
        <div class="row justify-content-md-center">
            <asp:GridView ID="dgvRegistro" runat="server" OnSelectedIndexChanged="dgv_SelectedIndexChanged" DataKeyNames="Id" CssClass="table table-dark table-bordered" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="ID Registro" DataField="Id" />
                    <asp:BoundField HeaderText="Tipo" DataField="Tipo" />
                    <asp:BoundField HeaderText="Destinatario" DataField="Destinatario" />
                    <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
                    <asp:BoundField HeaderText="Monto" DataField="Monto" />
                    <asp:BoundField HeaderText="Articulo" DataField="Articulo" />
                    <asp:BoundField HeaderText="Estado" DataField="Estado" />
                    <asp:CommandField ShowSelectButton="true" SelectText="📝" HeaderText="Accion" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
