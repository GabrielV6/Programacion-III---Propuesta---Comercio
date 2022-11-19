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


                if (Session["ClienteSeleccionado"] != null && !IsPostBack)
                {
                    Cliente cliente = (Cliente)Session["ClienteSeleccionado"];

                    txtNombreCliente.Text = cliente.Nombre;
                    txtApellidoCliente.Text = cliente.Apellido;
                    txtDniCliente.Text = cliente.Dni;
                    txtTelefonoCliente.Text = cliente.Telefono;
                    txtEmailCliente.Text = cliente.Email;
                    
                   
                }
            }

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
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
    }
}