using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_comercio_Vargas_Delgado
{
    public partial class FormularioArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Articulo articulo = new Articulo();
            articulo.Codigo = txtCodigo.Text;
            articulo.Nombre = txtNombre.Text;
            articulo.Descripcion = txtDescripcion.Text;
            articulo.Precio = 10;
            articulo.ImagenUrl = txtImagenUrl.Text;
            Marca marca = new Marca();
            marca.Id = 1;
            articulo.marca = marca;
            Categoria categoria = new Categoria();
            categoria.Id = 1;
            articulo.categoria= categoria;

            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            articuloNegocio.agregar(articulo);

            Response.Redirect("WebVerArticulo.aspx", false);
        }
    }
}