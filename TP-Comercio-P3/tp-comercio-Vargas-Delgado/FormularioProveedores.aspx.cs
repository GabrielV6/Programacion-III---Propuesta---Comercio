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
            else
            {

         
                if (Session["ProveedorSeleccionado"] != null && !IsPostBack)
                {
                    Proveedor proveedor = (Proveedor)Session["ProveedorSeleccionado"];
                   
                    if((Session["usuariologueado"] != null && ((Dominio.RolUsuario)Session["rolusuario"]) == Dominio.RolUsuario.Administrador))
                    {
                        txtRazonSocial.Text = proveedor.RazonSocial;
                        txtCuit.Text = proveedor.Cuit;
                        txtEmail.Text = proveedor.Email;
                        txtTelefono.Text = proveedor.Telefono;
                    }
                    else
                    {

                        txtRazonSocial.Text = proveedor.RazonSocial;
                        txtRazonSocial.ReadOnly = true;
                        
                        txtCuit.Text = proveedor.Cuit;
                        txtCuit.ReadOnly = true;
                        
                        txtEmail.Text = proveedor.Email;
                        txtEmail.ReadOnly = true;
                        
                        txtTelefono.Text = proveedor.Telefono;
                        txtTelefono.ReadOnly = true;
                        

                    }
                  
                }
            }

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {   
            //Guardo el ID de la session para pasarlo al nuevo objeto
            int IdProveedor = Session["ProveedorSeleccionado"] != null ? ((Proveedor)Session["ProveedorSeleccionado"]).Id : 0;
            
            Proveedor proveedor = new Proveedor();
            
            proveedor.Id = IdProveedor;
            proveedor.RazonSocial = txtRazonSocial.Text;
            proveedor.Cuit = txtCuit.Text;
            proveedor.Email = txtEmail.Text;
            proveedor.Telefono = txtTelefono.Text;
            

            ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
            if (IdProveedor ==0)
            {
                proveedorNegocio.agregar(proveedor);
            }
            else
                {
            
                proveedorNegocio.modificar(proveedor);
                Session.Remove("ProveedorSeleccionado");
            }
            

            Response.Redirect("WebVerProveedor.aspx", false);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            //int IdProveedor = Convert.ToInt32(((Button)sender).CommandArgument);

            if (Session["ProveedorSeleccionado"] != null)
            {
                int IdProveedor = Session["ProveedorSeleccionado"] != null ? ((Proveedor)Session["ProveedorSeleccionado"]).Id : 0;
                ProveedorNegocio negocio = new ProveedorNegocio();
                negocio.eliminar(IdProveedor);
                
                //remover proveedor de la session
                Session.Remove("ProveedorSeleccionado");

                //redirecciona a la vista
                Response.Redirect("WebVerProveedor.aspx");
            }
            else
            {
                lblMensaje.Text = "Debe seleccionar un proveedor para eliminarlo";
                
            }

        }

    }
}