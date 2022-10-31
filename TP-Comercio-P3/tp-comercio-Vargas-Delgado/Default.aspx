<%@ Page Title="Default" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="tp_comercio_Vargas_Delgado.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   

    <div>
        <asp:Label ID="lblBienvenida" runat="server" Text="" CssClass="h3"></asp:Label>
    </div>
    <div>
        <asp:Button ID="btnCerrar" runat="server" Text="Cerrar Session" OnClick="btnCerrar_Click" />

    </div>

</asp:Content>



