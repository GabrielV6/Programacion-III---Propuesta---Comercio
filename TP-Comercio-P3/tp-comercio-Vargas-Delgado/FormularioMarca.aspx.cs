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
                //if (Session["MarcaSeleccionada"] != null && !IsPostBack)
                //{
                //    Marca marca = (Marca)Session["MarcaSeleccionada"];
                //    txtDescripcion.Text = marca.DescripcionMarca;
                //}

                if (Session["MarcaSeleccionada"] != null && !IsPostBack)
                {
                    Marca marca = (Marca)Session["MarcaSeleccionada"];

                    if ((Session["usuariologueado"] != null && ((Dominio.RolUsuario)Session["rolusuario"]) == Dominio.RolUsuario.Administrador))
                    {
                        txtDescripcion.Text = marca.DescripcionMarca;
                 
                    }
                    else
                    {

                        txtDescripcion.Text = marca.DescripcionMarca;
                        txtDescripcion.ReadOnly = true;
                  
                    }

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

        protected void btnEliminar_Click(object sender, EventArgs e)
        {


            if (Session["MarcaSeleccionada"] != null)
            {
                int IdMarca = Session["MarcaSeleccionada"] != null ? ((Categoria)Session["MarcaSeleccionada"]).Id : 0;
                MarcaNegocio negocio = new MarcaNegocio();
                negocio.eliminar(IdMarca);

                //remover proveedor de la session
                Session.Remove("MarcaSeleccionada");

                //redirecciona a la vista
                Response.Redirect("WebVerMarca.aspx");
            }
            else
            {
                lblMensaje.Text = "Debe seleccionar una Marca para eliminarlo";

            }

        }
    }
}