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
    public partial class FormularioMarca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Marca marca = new Marca();
            marca.DescripcionMarca = txtDescripcion.Text;

            MarcaNegocio marcaNegocio = new MarcaNegocio();
            marcaNegocio.agregar(marca);

            Response.Redirect("WebVerMarca.aspx", false);
        }

    }
}