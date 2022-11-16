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
            if (Session["usuariologueado"] == null)
            {
                Session.Add("Error de acceso", "Debe iniciar sesión para acceder a esta página");
                Response.Redirect("Logon.aspx");
            }
            else
            {
                if (Session["MarcaSeleccionada"] != null && !IsPostBack)
                {
                    Marca marca = (Marca)Session["MarcaSeleccionada"];
                    txtDescripcion.Text = marca.DescripcionMarca;
                }
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            int IdMarca = Session["MarcaSeleccionada"] != null ? ((Marca)Session["MarcaSeleccionada"]).Id : 0;

            Marca marca = new Marca();
            marca.Id = IdMarca;
            marca.DescripcionMarca = txtDescripcion.Text;

            MarcaNegocio marcaNegocio = new MarcaNegocio();
            
            if (IdMarca == 0)
            {
                marcaNegocio.agregar(marca);
            }
            else
            {
                marcaNegocio.modificar(marca);
                Session.Remove("MarcaSeleccionada");
            }

            Response.Redirect("WebVerMarca.aspx", false);
        }

    }
}