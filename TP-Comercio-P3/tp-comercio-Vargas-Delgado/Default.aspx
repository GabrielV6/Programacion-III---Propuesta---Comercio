<%@ Page Title="Default" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="tp_comercio_Vargas_Delgado.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="myCarousel" class="carousel slide" data-ride="carousel">
                    <!-- muestra los botones de posicion y La movida automatica -->
                    <ol class="carousel-indicators">
                        <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                        <li data-target="#myCarousel" data-slide-to="1"></li>
                        <li data-target="#myCarousel" data-slide-to="2"></li>
                        <li data-target="#myCarousel" data-slide-to="3"></li>
                        <li data-target="#myCarousel" data-slide-to="4"></li>
                        <li data-target="#myCarousel" data-slide-to="5"></li>
                    </ol>

                    <!-- Aqui comienza las imagenes que se mueven -->

                    <div class="carousel-inner" role="listbox">

                        <div class="item active">
                            <img src="img/desarrollo.jpg" alt="desarrollo" width="460" height="345">
                        </div>

                        <div class="item">
                            <img src="img/desarrollo2.png" alt="desarrollo1" width="460" height="345">
                        </div>

                        <div class="item">
                            <img src="img/desarrollo3.jpg" alt="desarrollo2" width="460" height="345">
                        </div>

                        <div class="item">
                            <img src="img/desarrollo4.jpg" alt="desarrollo3" width="460" height="345">
                        </div>

                        <div class="item">
                            <img src="img/desarrollo5.jpg" alt="desarrollo4" width="460" height="345">
                        </div>

                        <div class="item">
                            <img src="img/desarrollo6.jpg" alt="desarrollo5" width="460" height="345">
                        </div>

                    </div>
            </br>

            <!-- Esto hace el Sombreado de las imagenes, las flechas y botones de cambio de imagen-->
            <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
                <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
            </a>
            <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
                <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
            </a>
        </div>
        <hr size="6" width="100%" noshade="noshade" align="right" />
        <!-- linea separadora-->


        <!-- Aqui termina las imagenes que se mueven -->





</asp:Content>



