<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logon.aspx.cs" Inherits="tp_comercio_Vargas_Delgado.Pagina1" %>

<!DOCTYPE html>

<html style="font-size: 16px;" lang="en"">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/js/bootstrap.bundle.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <link href="Content/CCS/Estilo.css" rel="stylesheet" />
    <title></title>
     <link rel="stylesheet" href="js/nicepage.css" media="screen">
    <link rel="stylesheet" href="js/Page-5.css" media="screen">
    <script class="u-script" type="text/javascript" src="jquery.js" defer=""></script>
    <script class="u-script" type="text/javascript" src="nicepage.js" defer=""></script>
</head>
<%--<body class="bg-light">
    <nav class="navbar navbar-dark bg-dark">
  <a class="navbar-brand" >Bienvenido/a al Login</a>
</nav>
    <div class="wrapper">
        <div class="formcontent">
            <form id="formulario_login" runat="server">

                <div class="form-control">
                    <div class="row">
                        <asp:Label class="h3" ID="lblBienvenida" runat="server" Text="Bienvenido/a al Sistema"></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="lblUsuario" runat="server" Text="Usuario"></asp:Label>
                        <asp:TextBox ID="tbxUsuario" CssClass="form-control" runat="server" placeholder="Nombre de Usuario"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="lblContraseña" runat="server" Text="Contraseña"></asp:Label>
                        <asp:TextBox ID="tbxContraseña" CssClass="form-control" TextMode="Password" runat="server" placeholder="Contraseña"></asp:TextBox>
                        <br />
                    </div>
                    <hr />
                    <div class="row">
                        <asp:Label runat="server" CssClass="alert-danger" ID="lblError"></asp:Label>
                        <br />
                        <br />
                    </div>
                    <div class="row">
                        <asp:Button ID="btnIngresar" CCsClass="btn btn-primary btn-dark" runat="server" OnClick="BtnIngresar_Click" Text="Ingresar" />
                    </div>
                    <br />
                    <div class="row">
                    </div>
                </div>
            </form>
        </div>
    </div>
</body>--%>
    <body data-home-page="#" data-home-page-title="Page 5" class="u-body u-xl-mode" data-lang="en">
    <section class="u-align-center u-clearfix u-section-1" id="sec-600b">
      <div class="u-clearfix u-sheet u-sheet-1">
        <div class="u-clearfix u-expanded-width u-layout-wrap u-layout-wrap-1">
          <div class="u-layout">
            <div class="u-layout-row">
              <div class="u-align-center u-container-style u-image u-layout-cell u-size-30 u-image-1" data-image-width="714" data-image-height="1080">
                <div class="u-container-layout u-container-layout-1"></div>
              </div>
              <div class="u-align-center u-container-style u-grey-5 u-layout-cell u-size-30 u-layout-cell-2">
                <div class="u-container-layout u-valign-middle u-container-layout-2">
                  <h3 class="u-custom-font u-font-montserrat u-text u-text-default u-text-1">Log in</h3>
                  <div class="u-form u-login-control u-white u-form-1">
                    <form id="formulario_login" runat="server" action="#" method="POST" class="u-clearfix u-form-custom-backend u-form-spacing-20 u-form-vertical u-inner-form" source="custom" name="form" style="padding: 30px;">
                      <div class="u-form-group u-form-name">
                         <asp:Label ID="lblUsuario" runat="server" Text="Usuario"></asp:Label>
                        <asp:TextBox ID="tbxUsuario" CssClass="form-control" runat="server" placeholder="Nombre de Usuario *"></asp:TextBox>
                      </div>
                      <div class="u-form-group u-form-password">
                       <asp:Label ID="lblContraseña" runat="server" Text="Contraseña"></asp:Label>
                        <asp:TextBox ID="tbxContraseña" CssClass="form-control" TextMode="Password" runat="server" placeholder="Contraseña *"></asp:TextBox>
                      </div>
                      <div class="u-form-checkbox u-form-group">
                        <input type="checkbox" id="checkbox-a30d" name="remember" value="On">
                        <label for="checkbox-a30d" class="u-label">Remember me</label>
                      </div>
                      <div class="u-align-left u-form-group u-form-submit">
                        <asp:Button ID="btnIngresar" class="u-border-none u-btn u-btn-submit u-button-style u-palette-2-base u-btn-1" runat="server" OnClick="BtnIngresar_Click" Text="Ingresar" />
                        <input type="submit" value="submit" class="u-form-control-hidden">
                      </div>
                      <input type="hidden" value="" name="recaptchaResponse">
                    </form>
                  </div>
                    <asp:Label runat="server" CssClass="alert-danger" ID="lblError"></asp:Label>
                  <a href="#" class="u-border-active-palette-2-base u-border-hover-palette-1-base u-border-none u-btn u-button-style u-login-control u-login-forgot-password u-none u-text-grey-40 u-text-hover-palette-4-base u-btn-2">Forgot password?</a>
                  <a href="#" class="u-border-active-palette-2-base u-border-hover-palette-1-base u-border-none u-btn u-button-style u-login-control u-login-create-account u-none u-text-grey-40 u-text-hover-palette-4-base u-btn-3">Don't have an account?</a>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
    
    
    
    <section class="u-backlink u-clearfix u-grey-80">
      <a class="u-link" href="#" target="_blank">
        <span></span>
      </a>
      <p class="u-text">
        <span></span>
      </p>
      <a class="u-link" href="#" target="_blank">
        <span></span>
      </a>
    </section>
</body>
</html>
