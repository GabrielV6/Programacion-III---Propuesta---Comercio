<%@ Page Title="Default" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="tp_comercio_Vargas_Delgado.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container" style="height: 100px">
        <div class="row justify-content-md-center">
            <div class="col">
                <div>
                    <asp:Label ID="lblBienvenida" runat="server" Text="" CssClass="h3"></asp:Label>
                </div>
                <div>
                    <asp:Button ID="btnCerrar" runat="server" Text="Cerrar Sesion" OnClick="btnCerrar_Click" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>



