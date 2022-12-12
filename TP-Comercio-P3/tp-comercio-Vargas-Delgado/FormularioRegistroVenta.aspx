<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioRegistroVenta.aspx.cs" Inherits="tp_comercio_Vargas_Delgado.FormularioRegistroVenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script>
        function validar() {
            var cantidad = document.getElementById("txtCantidad").value;

            if (cantidad === "")
            {
                alert("Por favor, completar los campos");
                return false;
            }
            return true;
        }
    </script>

    <div class="mx-auto p-5" style="width: 400px;">
        <h2 class="text-center">Registro de venta</h2>
    </div>

    <div class="container justify-content-sm-center">
        <div class="mb-3">

            <label for="ddlCliente" class="form-label">Cliente</label>
            <asp:DropDownList ID="ddlCliente" CssClass="form-select" runat="server"></asp:DropDownList>

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

            <%--<label for="txtMonto" class="form-label">Monto</label>
            <asp:TextBox ID="txtMonto" runat="server" CssClass="form-control" required=""></asp:TextBox>
            <asp:RangeValidator ID="Range2"
                ControlToValidate="txtMonto"
                MinimumValue="1"
                MaximumValue="99000000"
                Type="Integer"
                EnableClientScript="false"
                Text="Por favor, ingrese un monto valido"
                runat="server" />--%>
        </div>

        <div class="mb-3">
            <asp:Button ID="btnAgregarArticulo" runat="server" Text="Agregar articulo" CssClass="btn btn-info" OnClientClick="return validar()" OnClick="btnAgregarArticulo_Click" />
        </div>

        <div class="mb-3">
            <h7>Presione 'Agregar articulo' para agregar un articulo a la lista</h7>
        </div>

        <div class="row justify-content-md-center">
            <asp:GridView ID="dgvRegistro" runat="server" OnSelectedIndexChanged="dgv_SelectedIndexChanged" DataKeyNames="Id" CssClass="table table-grey table-bordered" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="Item" DataField="Id" />
                    <asp:BoundField HeaderText="Cliente" DataField="cliente.Nombre" />
                    <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
                    <asp:BoundField HeaderText="Precio x Unidad $ARG" DataField="Monto" />
                    <asp:BoundField HeaderText="Articulo" DataField="articulo.nombre" />
                    <asp:BoundField HeaderText="Total x Articulo $ARG" DataField="MontoTotal" />
                    <asp:BoundField HeaderText="Procentaje de Ganancia" DataField="articulo.Porcentaje" />
                    <asp:CommandField ShowSelectButton="true" SelectText="❌" HeaderText="Accion" />
                </Columns>
            </asp:GridView>
        </div>

        <div class="mb-3">
            <asp:Label Text="" ID="TotalFactura" runat="server" />
        </div>

        <div class="mb-3">

            <asp:Button ID="btnAceptar" runat="server" Text="Finalizar venta" CssClass="btn btn-warning" OnClick="btnAceptar_Click" />
            <%
                if (Session["usuariologueado"] != null && ((Dominio.RolUsuario)Session["rolusuario"]) == Dominio.RolUsuario.Administrador)
                {
            %>
            <%
                }
            %>
            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <div class="container justify-content-sm-center">
        <a href="./WebVerRegistroVenta.aspx">Volver</a>
    </div>

</asp:Content>
