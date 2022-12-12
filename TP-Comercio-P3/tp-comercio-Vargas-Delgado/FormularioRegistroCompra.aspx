<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioRegistroCompra.aspx.cs" Inherits="tp_comercio_Vargas_Delgado.FormularioRegistroCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script>
        function validar() {
            var cantidad = document.getElementById("txtCantidad").value;
            var monto = document.getElementById("txtMonto").value;

            if (cantidad === "" || monto === "") {
                alert("Por favor, completar los campos");
                return false;
            }
            return true;
        }
    </script>

    <div class="mx-auto p-5" style="width: 400px;">
        <h2 class="text-center">Registro de compra</h2>
    </div>

    <div class="container justify-content-sm-center">
        <div class="mb-3">

            <label for="ddlProveedor" class="form-label">Proveedor</label>
            <asp:DropDownList ID="ddlProveedor" CssClass="form-select" runat="server"></asp:DropDownList>

            <label for="ddlArticulo" class="form-label">Articulo</label>
            <asp:DropDownList ID="ddlArticulo" CssClass="form-select" runat="server"></asp:DropDownList>

            <label for="txtCantidad" class="form-label">Cantidad</label>
            <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
            <asp:RangeValidator ID="Range1"
                ControlToValidate="txtCantidad"
                MinimumValue="1"
                MaximumValue="99000000"
                Type="Integer"
                EnableClientScript="false"
                Text="Por favor, ingrese una cantidad valida"
                runat="server" />

            <div class="mb-3">
                <h7></h7>
            </div>

            <label for="txtMonto" class="form-label">Monto x Unidad</label>
            <asp:TextBox ID="txtMonto" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
            <asp:RangeValidator ID="Range2"
                ControlToValidate="txtMonto"
                MinimumValue="1"
                MaximumValue="99000000"
                Type="Integer"
                EnableClientScript="false"
                Text="Por favor, ingrese un monto valido"
                runat="server" />

        </div>
        <div class="mb-3">
            <h7>El codigo se agregara de manera automatica</h7>
        </div>


        <div class="mb-3">
            <asp:Button ID="btnAgregarArticulo" runat="server" Text="Agregar articulo" CssClass="btn btn-info" OnClientClick="return validar()" OnClick="btnAgregarCompra_Click" />
        </div>

        <div class="mb-3">
            <h7>Presione 'Agregar articulo' para agregar un articulo a la lista</h7>
        </div>

        <div class="row justify-content-md-center">
            <asp:GridView ID="dgvRegistroCompra" runat="server" OnSelectedIndexChanged="dgv_SelectedIndexChanged" DataKeyNames="Id" CssClass="table table-grey table-bordered" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="Item" DataField="Id" />
                    <asp:BoundField HeaderText="Proveedor" DataField="proveedor.RazonSocial" />
                    <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
                    <asp:BoundField HeaderText="Precio por unidad" DataField="Monto" />
                    <asp:BoundField HeaderText="Articulo" DataField="articulo.nombre" />
                    <asp:BoundField HeaderText="Total x Articulo $ARG" DataField="MontoTotal" />
                    <asp:CommandField ShowSelectButton="true" SelectText="❌" HeaderText="Accion" />
                </Columns>
            </asp:GridView>
        </div>

        <div class="mb-3">
            <asp:Label Text="" ID="TotalCompra" runat="server" />
        </div>
        <div class="mb-3">

            <asp:Button ID="btnAceptar" runat="server" Text="Finalizar compra" CssClass="btn btn-warning" OnClick="btnAceptar_Click" />
            <%
                if (Session["usuariologueado"] != null && ((Dominio.RolUsuario)Session["rolusuario"]) == Dominio.RolUsuario.Administrador)
                {
            %>
            <%--<asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-warning" BackColor="Red" OnClick="btnEliminar_Click" />--%>
            <%
                }
            %>
            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
        </div>
        <div class="container justify-content-sm-center">
            <a href="./WebVerRegistroCompra.aspx">Volver</a>
        </div>
</asp:Content>
