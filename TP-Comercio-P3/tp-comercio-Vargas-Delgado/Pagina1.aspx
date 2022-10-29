<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pagina1.aspx.cs" Inherits="tp_comercio_Vargas_Delgado.Pagina1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/js/bootstrap.bundle.min.js"></script>
     <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <link href="Content/CCS/Estilo.css" rel="stylesheet" />
    <title></title>
</head>
<body class="bg-light"> 
<div class="wrapper">
        <div class="formcontent">
            <form id="formulario_login" runat="server">
                <div class="form-control">
                    <div class="row">
                        <asp:Label class="h3" ID="lblBienvenida" runat="server" Text="Bienvenido/a al Sistema"></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="lblUsuario" runat="server" Text="Usuario"></asp:Label>
                        <asp:TextBox ID="tbxUsuario" CssClass="form-control" runat="server" placeholder ="Nombre de Usuario"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="lblContraseña" runat="server" Text="Contraseña"></asp:Label>
                        <asp:TextBox ID="tbxContraseña" CssClass="form-control" TextMode="Password" runat="server" placeholder="Contraseña"></asp:TextBox>
                    </div>
                    <hr />
                    <div class="row">
                        <asp:Button ID="btnIngresar" CCsClass="btn btn-primary btn-dark" runat="server" Text="Ingresar"/>
     
                        <a href="Default.aspx">default</a>
                    </div>
                    <br />
                    <div class="row">
                        
                    </div>
                </div>
            </form>
        </div>
    </div>

</body>
</html>
