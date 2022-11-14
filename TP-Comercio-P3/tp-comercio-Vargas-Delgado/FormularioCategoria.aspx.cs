using System;
using System.Collections.Generic;
using System.Linq;
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
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Categoria categoria = new Categoria();
            categoria.Descripcion = txtDescripcion.Text;

            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            categoriaNegocio.agregar(categoria);

            Response.Redirect("WebVerCategoria.aspx", false);
        }
    }
}