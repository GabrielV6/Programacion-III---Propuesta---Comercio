using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace tp_comercio_Vargas_Delgado
{
    public partial class FormularioCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["usuariologueado"] == null)
            {
                Session.Add("Error de acceso", "Debe iniciar sesión para acceder a esta página");
                Response.Redirect("Logon.aspx");
            }
            else
            {
                //if (Session["CategoriaSeleccionada"] != null && !IsPostBack)
                //{
                //    Categoria categoria = (Categoria)Session["CategoriaSeleccionada"];
                //    txtDescripcion.Text = categoria.Descripcion;
                //}

                if (Session["CategoriaSeleccionada"] != null && !IsPostBack)
                {
                    Categoria categoria = (Categoria)Session["CategoriaSeleccionada"];

                    if ((Session["usuariologueado"] != null && ((Dominio.RolUsuario)Session["rolusuario"]) == Dominio.RolUsuario.Administrador))
                    {
                        txtDescripcion.Text = categoria.Descripcion;

                    }
                    else
                    {

                        txtDescripcion.Text = categoria.Descripcion;
                        txtDescripcion.ReadOnly = true;

                    }


                }
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            int IdCategoria = Session["CategoriaSeleccionada"] != null ? ((Categoria)Session["CategoriaSeleccionada"]).Id : 0;

            Categoria categoria = new Categoria();
            categoria.Id = IdCategoria;
            categoria.Descripcion = txtDescripcion.Text;

            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            if (IdCategoria == 0)
            {
                categoriaNegocio.agregar(categoria);
            }
            else
            {
                categoriaNegocio.modificar(categoria);
                Session.Remove("CategoriaSeleccionada");
            }

            Response.Redirect("WebVerCategoria.aspx", false);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            

            if (Session["CategoriaSeleccionada"] != null)
            {
                int IdCategoria = Session["CategoriaSeleccionada"] != null ? ((Categoria)Session["CategoriaSeleccionada"]).Id : 0;
                CategoriaNegocio negocio = new CategoriaNegocio();
                negocio.eliminar(IdCategoria);

                //remover proveedor de la session
                Session.Remove("CategoriaSeleccionada");

                //redirecciona a la vista
                Response.Redirect("WebVerCategoria.aspx");
            }
            else
            {
                lblMensaje.Text = "Debe seleccionar una Categoria para eliminarlo";

            }

        }
    }
}