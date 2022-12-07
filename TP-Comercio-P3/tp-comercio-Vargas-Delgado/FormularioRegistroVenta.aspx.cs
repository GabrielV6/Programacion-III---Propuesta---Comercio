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
        public List<Registro> ListaRegistro { get; set; }
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

                    if (Session["ListaVenta"] == null)
                    {
                        List<Registro> ListaVenta = new List<Registro>();
                        Session.Add("ListaVenta", ListaVenta);

                    }

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

                    dgvRegistro.DataSource = Session["ListaVenta"];
                    dgvRegistro.DataBind();
                }
                if (Session["RegistroSeleccionado"] != null && !IsPostBack)
                {
                    Registro registro = (Registro)Session["RegistroSeleccionado"];

                    if ((Session["usuariologueado"] != null && ((Dominio.RolUsuario)Session["rolusuario"]) == Dominio.RolUsuario.Administrador))
                    {
                        ddlCliente.SelectedValue = registro.Destinatario.ToString();
                        txtCantidad.Text = registro.Cantidad.ToString();
                        //txtMonto.Text = registro.Monto.ToString();
                        ddlArticulo.SelectedValue = registro.articulo.Id.ToString();
                    }
                    else
                    {
                        txtCantidad.Text = registro.Cantidad.ToString();
                        txtCantidad.ReadOnly = true;
                        //txtMonto.Text = registro.Monto.ToString();
                        //txtMonto.ReadOnly = true;
                    }
                }
            }
        }

        protected void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            int IdRegistro = Session["RegistroSeleccionado"] != null ? ((Registro)Session["RegistroSeleccionado"]).Id : 0;
            float PrecioTotal = 0;

            
            Registro registro = new Registro();
            registro.Id = IdRegistro;
            int venta = 0;
            registro.Tipo = venta;
            registro.Destinatario = int.Parse(ddlCliente.SelectedValue);
            registro.Cantidad = int.Parse(txtCantidad.Text);

            int IdArticulo = int.Parse(ddlArticulo.SelectedValue);
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo selecionado = (negocio.listaParaEditar(IdArticulo))[0];  



            PrecioTotal = (float)+(selecionado.Precio * int.Parse(txtCantidad.Text));

            registro.Monto = (decimal?)PrecioTotal;
            registro.articulo = new Articulo();
            registro.articulo.Id = int.Parse(ddlArticulo.SelectedValue);

            registro.cliente = new Cliente();
            registro.cliente.Nombre = ddlCliente.SelectedItem.Text;

            registro.articulo = new Articulo();
            registro.articulo.Nombre = ddlArticulo.SelectedItem.Text;


            List<Registro> Lista = (List<Registro>)Session["ListaVenta"];
            Lista.Add(registro);

            //llamar al page load
            Response.Redirect("FormularioRegistroVenta.aspx");


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
            //registro.Monto = Convert.ToDecimal(txtMonto.Text);
            registro.articulo = new Articulo();
            registro.articulo.Id = int.Parse(ddlArticulo.SelectedValue);

            List<Registro> Lista = (List<Registro>)Session["ListaVenta"];
            /*
            RegistroNegocio registroNegocio = new RegistroNegocio();
            if (IdRegistro == 0)
            {
                registroNegocio.agregar(Lista);
            }
            else
            {
                registroNegocio.modificar(registro);
                Session.Remove("RegistroSeleccionado");
            }
            */
            /* comentado temporal
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            Articulo articulo = new Articulo();
            // busca el stock del producto
            List<Articulo> articulos = new List<Articulo>();
            articulos = articuloNegocio.listaParaEditar(registro.articulo.Id);
            articulo = articulos[0];
            // se resta la cantidad vendida  del stock actual

            if (articulos[0].Stock < registro.Cantidad)
            {
                Response.Write("<script>alert('El articulo no posee esa cantidad de items')</script>");
                return;
            }

            articulo.Stock = articulos[0].Stock - registro.Cantidad;
            articuloNegocio.modificarPorCompra(articulo);
            */
            //Response.Redirect("WebVerRegistroVenta.aspx", false);
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

        protected void dgv_SelectedIndexChanged(object sender, EventArgs e)
        {
            int IdRegistro = Convert.ToInt32(dgvRegistro.SelectedDataKey.Value.ToString());
            RegistroNegocio negocio = new RegistroNegocio();
            negocio.eliminar(IdRegistro);
            Response.Redirect("WebVerRegistroVenta.aspx");
        }

    }
}