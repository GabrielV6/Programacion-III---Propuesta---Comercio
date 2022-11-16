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
                if (Session["CategoriaSeleccionada"] != null && !IsPostBack)
                {
                    Categoria categoria = (Categoria)Session["CategoriaSeleccionada"];
                    txtDescripcion.Text = categoria.Descripcion;
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
    }
}