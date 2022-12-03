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
    public partial class FormularioCliente : System.Web.UI.Page
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


                //if (Session["ClienteSeleccionado"] != null && !IsPostBack)
                //{
                //    Cliente cliente = (Cliente)Session["ClienteSeleccionado"];

                //    txtNombreCliente.Text = cliente.Nombre;
                //    txtApellidoCliente.Text = cliente.Apellido;
                //    txtDniCliente.Text = cliente.Dni;
                //    txtTelefonoCliente.Text = cliente.Telefono;
                //    txtEmailCliente.Text = cliente.Email;


                //}

                if (Session["ClienteSeleccionado"] != null && !IsPostBack)
                {
                    Cliente cliente = (Cliente)Session["ClienteSeleccionado"];

                    if ((Session["usuariologueado"] != null && ((Dominio.RolUsuario)Session["rolusuario"]) == Dominio.RolUsuario.Administrador))
                    {
                           txtNombreCliente.Text = cliente.Nombre;
                           txtApellidoCliente.Text = cliente.Apellido;
                           txtDniCliente.Text = cliente.Dni;
                           txtTelefonoCliente.Text = cliente.Telefono;
                           txtEmailCliente.Text = cliente.Email;

                    }
                    else
                    {

                        txtNombreCliente.Text = cliente.Nombre;
                        txtNombreCliente.ReadOnly = true;
                        
                        txtApellidoCliente.Text = cliente.Apellido;
                        txtApellidoCliente.ReadOnly = true;
                        
                        txtDniCliente.Text = cliente.Dni;
                        txtDniCliente.ReadOnly = true;
                        
                        txtTelefonoCliente.Text = cliente.Telefono;
                        txtTelefonoCliente.ReadOnly = true;
                        
                        txtEmailCliente.Text = cliente.Email;
                        txtEmailCliente.ReadOnly = true;

                    }

                }
            }

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
                return;

            //Guardo el ID de la session para pasarlo al nuevo objeto
            int IdCliente = Session["ClienteSeleccionado"] != null ? ((Cliente)Session["ClienteSeleccionado"]).Id : 0;

            Cliente cliente = new Cliente();

            cliente.Id = IdCliente;
            cliente.Nombre = txtNombreCliente.Text;
            cliente.Apellido = txtApellidoCliente.Text;
            cliente.Dni = txtDniCliente.Text;
            cliente.Email = txtEmailCliente.Text;
            cliente.Telefono = txtTelefonoCliente.Text;


            ClienteNegocio clienteNegocio = new ClienteNegocio();
            if (IdCliente == 0)
            {
                clienteNegocio.agregar(cliente);
            }
            else
            {

                clienteNegocio.modificar(cliente);
                Session.Remove("ClienteSeleccionado");
            }


            Response.Redirect("WebVerCliente.aspx", false);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {


            if (Session["ClienteSeleccionado"] != null)
            {
                int IdCliente = Session["ClienteSeleccionado"] != null ? ((Cliente)Session["ClienteSeleccionado"]).Id : 0;
                ClienteNegocio negocio = new ClienteNegocio();
                negocio.eliminar(IdCliente);

                //remover proveedor de la session
                Session.Remove("ClienteSeleccionado");

                //redirecciona a la vista
                Response.Redirect("WebVerCliente.aspx");
            }
            else
            {
                lblMensaje.Text = "Debe seleccionar una Marca para eliminarlo";

            }

        }
    }
}