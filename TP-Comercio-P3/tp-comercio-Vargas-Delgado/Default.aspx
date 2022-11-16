<%@ Page Title="Default" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="tp_comercio_Vargas_Delgado.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="d-flex align-items-center justify-content-center vh-100 bg-primary">
        <div class="row ">
            <div class="vstack text-white">
                <div>
                    <asp:Label ID="lblBienvenida" runat="server" Text="" CssClass="h3"></asp:Label>
                </div>
                <div class="text-center">
                    <asp:Button ID="btnCerrar" runat="server" class="btn btn-light" Text="Cerrar Sesion" OnClick="btnCerrar_Click" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>



