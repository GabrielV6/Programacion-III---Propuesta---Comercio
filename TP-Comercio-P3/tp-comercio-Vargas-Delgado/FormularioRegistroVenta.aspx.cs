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
    public partial class FormularioRegistroVenta : System.Web.UI.Page
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
                if (!IsPostBack)
                {
                    ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                    List<Articulo> listaArticulo = articuloNegocio.listar();

                    ddlArticulo.DataSource = listaArticulo;
                    ddlArticulo.DataValueField = "Id";
                    ddlArticulo.DataTextField = "Nombre";
                    ddlArticulo.DataBind();

                    ClienteNegocio clienteNegocio = new ClienteNegocio();
                    List<Cliente> listaCliente = clienteNegocio.listar();

                    ddlCliente.DataSource = listaCliente;
                    ddlCliente.DataValueField = "Id";
                    ddlCliente.DataTextField = "Nombre";
                    ddlCliente.DataBind();
                }

                if (Session["RegistroSeleccionado"] != null && !IsPostBack)
                {
                    Registro registro = (Registro)Session["RegistroSeleccionado"];

                    if ((Session["usuariologueado"] != null && ((Dominio.RolUsuario)Session["rolusuario"]) == Dominio.RolUsuario.Administrador))
                    {
                        ddlCliente.SelectedValue = registro.articulo.Id.ToString();
                        txtCantidad.Text = registro.Cantidad.ToString();
                        txtMonto.Text = registro.Monto.ToString();
                        ddlArticulo.SelectedValue = registro.articulo.Id.ToString();
                    }
                    else
                    {
                        txtCantidad.Text = registro.Cantidad.ToString();
                        txtCantidad.ReadOnly = true;
                        txtMonto.Text = registro.Monto.ToString();
                        txtMonto.ReadOnly = true;
                    }
                }
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            int IdRegistro = Session["RegistroSeleccionado"] != null ? ((Registro)Session["RegistroSeleccionado"]).Id : 0;

            Registro registro = new Registro();
            registro.Id = IdRegistro;
            int venta = 0;
            registro.Tipo = venta;
            registro.Destinatario = int.Parse(ddlCliente.SelectedValue);
            registro.Cantidad = int.Parse(txtCantidad.Text);
            registro.Monto = Convert.ToDecimal(txtMonto.Text);
            registro.articulo = new Articulo();
            registro.articulo.Id = int.Parse(ddlArticulo.SelectedValue);

            RegistroNegocio registroNegocio = new RegistroNegocio();
            if (IdRegistro == 0)
            {
                registroNegocio.agregar(registro);
            }
            else
            {
                registroNegocio.modificar(registro);
                Session.Remove("RegistroSeleccionado");
            }
            Response.Redirect("WebVerRegistroVenta.aspx", false);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Session["RegistroSeleccionado"] != null)
            {
                int IdRegistro = Session["RegistroSeleccionado"] != null ? ((Registro)Session["RegistroSeleccionado"]).Id : 0;
                RegistroNegocio negocio = new RegistroNegocio();
                negocio.eliminar(IdRegistro);

                Session.Remove("RegistroSeleccionado");
                Response.Redirect("WebVerRegistroVenta.aspx");
            }
            else
            {
                lblMensaje.Text = "Debe seleccionar un registro para eliminarlo";

            }
        }
    }
}