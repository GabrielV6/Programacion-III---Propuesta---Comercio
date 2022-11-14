using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_comercio_Vargas_Delgado
{
    public partial class FormularioProveedores : System.Web.UI.Page
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
            Proveedor proveedor = new Proveedor();
            proveedor.RazonSocial = txtRazonSocial.Text;
            proveedor.Cuit = txtCuit.Text;
            proveedor.Email = txtEmail.Text;
            proveedor.Telefono = txtTelefono.Text;
            

            ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
            proveedorNegocio.agregar(proveedor);

            Response.Redirect("WebVerProveedor.aspx", false);
        }
    }
}