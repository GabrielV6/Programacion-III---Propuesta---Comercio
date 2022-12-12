using Dominio;
using Negocio;
using System;
using System.Collections;
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
                        TotalFactura.Text = "Monto total por venta: $0";
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

                    List<Registro> Lista = (List<Registro>)Session["ListaVenta"];

                    Nullable<decimal> totalVenta = 0;

                    foreach (Registro registro in Lista)
                    {
                        totalVenta += registro.MontoTotal;
                        registro.Destinatario = Lista[Lista.Count - 1].cliente.Id;
                        ddlCliente.SelectedItem.Text = Lista[Lista.Count - 1].cliente.Nombre;
                        ddlCliente.Enabled = false;
                    }

                    TotalFactura.Text = "Monto total por venta: $" + totalVenta.ToString();

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
            // TODO: LOGICA DESACTIVA POR EL MOMENTO (ES PARA GUARDAR Y EDITAR ... PERO QUIZAS NO HABILITEMOS LA LOGICA PARA EDITAR.

            //int IdRegistro = Session["RegistroSeleccionado"] != null ? ((Registro)Session["RegistroSeleccionado"]).Id : 0;
            //registro.Id = IdRegistro;

            Page.Validate();
            if (!Page.IsValid)
                return;

            decimal PrecioTotalPorArticulo;

            Registro registro = new Registro();

            int venta = 0;
            registro.Id = Session["ListaVenta"] != null ? ((List<Registro>)Session["ListaVenta"]).Count + 1 : 1;
            registro.Tipo = venta;
            registro.Cantidad = int.Parse(txtCantidad.Text);

            int IdArticulo = int.Parse(ddlArticulo.SelectedValue);
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo selecionado = (negocio.listaParaEditar(IdArticulo))[0];

            List<Registro> ListaDeRegistros = (List<Registro>)Session["ListaVenta"];

            int cantidadPorArticulo = 0;
            //decimal porcentajeDeGanancia = 0;
            registro.Monto = decimal.Round((decimal)selecionado.Precio, 2);
            registro.PrecioXCantidad = registro.Monto * registro.Cantidad;
            //porcentajeDeGanancia = decimal.Round(((decimal)selecionado.Porcentaje)/100, 2);
            PrecioTotalPorArticulo = ((decimal)selecionado.Precio * int.Parse(txtCantidad.Text) * (decimal.Round(((decimal)selecionado.Porcentaje) / 100, 3) + 1));

            PrecioTotalPorArticulo = decimal.Round(PrecioTotalPorArticulo, 2);
            registro.MontoTotal = (decimal?)PrecioTotalPorArticulo;

           
            registro.Porcentaje = (decimal)selecionado.Porcentaje;

            registro.cliente = new Cliente();


            //revisar si el proveedor es el mismo que el anterior

            if (Session["ListaVenta"] != null)
            {

                if (ListaDeRegistros.Count > 0)
                {
                    if (ListaDeRegistros[ListaDeRegistros.Count - 1].cliente.Id == int.Parse(ddlCliente.SelectedValue))
                    {
                        registro.cliente.Id = int.Parse(ddlCliente.SelectedValue);
                        registro.Destinatario = int.Parse(ddlCliente.SelectedValue);
                        registro.cliente.Nombre = ddlCliente.SelectedItem.Text;
                    }
                    else
                    {
                        registro.Destinatario = int.Parse(ddlCliente.SelectedValue);
                        registro.cliente.Id = ListaDeRegistros[ListaDeRegistros.Count - 1].cliente.Id;
                        registro.cliente.Nombre = ListaDeRegistros[ListaDeRegistros.Count - 1].cliente.Nombre;

                    }
                }
                else
                {
                    registro.Destinatario = int.Parse(ddlCliente.SelectedValue);
                    registro.cliente.Id = int.Parse(ddlCliente.SelectedValue);
                    registro.cliente.Nombre = ddlCliente.SelectedItem.Text;

                }
            }

            registro.articulo = new Articulo();
            registro.articulo.Nombre = ddlArticulo.SelectedItem.Text;
            registro.articulo.Id = int.Parse(ddlArticulo.SelectedValue);
            registro.articulo.Porcentaje = selecionado.Porcentaje;

            foreach (Registro registros in ListaDeRegistros)
            {
                if (registros.articulo.Id == selecionado.Id)
                    cantidadPorArticulo += registros.Cantidad;

            }

            if (selecionado.Stock < cantidadPorArticulo + registro.Cantidad)
            {
                Response.Write("<script>alert('El articulo no posee esa cantidad de items')</script>");
                return;
            }

            ListaDeRegistros.Add(registro);

            //llamar al page load
            Response.Redirect("FormularioRegistroVenta.aspx");
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            int IdRegistro = Session["RegistroSeleccionado"] != null ? ((Registro)Session["RegistroSeleccionado"]).Id : 0;

            List<Registro> Lista = (List<Registro>)Session["ListaVenta"];

            RegistroNegocio registroNegocio = new RegistroNegocio();

            int tipo = 0;
            int ultimaFactura = registroNegocio.ultimaFactura(tipo);

            foreach (Registro registro in Lista)
            {
                registro.IdFactura = ultimaFactura + 1;
            }

            if (Lista.Count>0)
            {
                registroNegocio.agregar(Lista);
                
            }
            else
            {
                Response.Write("<script>alert('No se ha podido agregar')</script>");
                return;
            }

            //actualiza stock en articulos

            foreach (Registro registro in Lista)
            {
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                Articulo articulo = new Articulo();

                // busca el stock del producto
                List<Articulo> articulos = new List<Articulo>();
                articulos = articuloNegocio.listaParaEditar(registro.articulo.Id);
                articulo = articulos[0];

                // se resta la cantidad vendida  del stock actual
                articulo.Stock = articulos[0].Stock - registro.Cantidad;

                articuloNegocio.modificarPorCompra(articulo);             
            }

            Session.Remove("ListaVenta");
            Response.Redirect("WebVerRegistroVenta.aspx");
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
            List<Registro> Lista = (List<Registro>)Session["ListaVenta"];
            List<Registro> ListaAux = new List<Registro>();

            foreach (Registro registro in Lista)
            {
                if (registro.Id != IdRegistro)
                {
                    ListaAux.Add(registro);
                }
            }

            Session.Remove("ListaVenta");
            Session.Add("ListaVenta", ListaAux);
            Response.Redirect("FormularioRegistroVenta.aspx");
            // RegistroNegocio negocio = new RegistroNegocio();
            // negocio.eliminar(IdRegistro);
            // Response.Redirect("WebVerRegistroVenta.aspx");
        }
    }
}