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
    public partial class FormularioRegistroCompra : System.Web.UI.Page
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

                    if (Session["ListaCompra"] == null)
                    {
                        List<Registro> ListaCompra = new List<Registro>();
                        Session.Add("ListaCompra", ListaCompra);
                        TotalCompra.Text = "Monto total por venta: $0";

                    }

                    ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                    List<Articulo> listaArticulo = articuloNegocio.listar();

                    ddlArticulo.DataSource = listaArticulo;
                    ddlArticulo.DataValueField = "Id";
                    ddlArticulo.DataTextField = "Nombre";
                    ddlArticulo.DataBind();

                    ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
                    List<Proveedor> listaProveedor = proveedorNegocio.listar();

                    ddlProveedor.DataSource = listaProveedor;
                    ddlProveedor.DataValueField = "Id";
                    ddlProveedor.DataTextField = "RazonSocial";
                    ddlProveedor.DataBind();

                    dgvRegistroCompra.DataSource = Session["ListaCompra"];
                    dgvRegistroCompra.DataBind();

                    List<Registro> Lista = (List<Registro>)Session["ListaCompra"];

                    Nullable<decimal> totalCompra = 0;

                    foreach (Registro registro in Lista)
                    {
                        totalCompra += registro.MontoTotal;


                        ddlProveedor.SelectedItem.Text = Lista[Lista.Count - 1].proveedor.RazonSocial;
                        ddlProveedor.Enabled = false;
                    }

                    TotalCompra.Text = "Monto total por compra: $" + totalCompra.ToString();
                }

                if (Session["RegistroSeleccionado"] != null && !IsPostBack)
                {
                    Registro registro = (Registro)Session["RegistroSeleccionado"];

                    if ((Session["usuariologueado"] != null && ((Dominio.RolUsuario)Session["rolusuario"]) == Dominio.RolUsuario.Administrador))
                    {
                        ddlProveedor.SelectedValue = registro.Destinatario.ToString();
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

        protected void btnAgregarCompra_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
                return;

            Registro registro = new Registro();

            int compra = 1;
            // el registro.Id sera igual al valor que tiene la sesscion en ID  +1 

            registro.Id = Session["ListaCompra"] != null ? ((List<Registro>)Session["ListaCompra"]).Count + 1 : 1;

            // TODO: Si necesitamos algun otro dato debemos agregarlo al registro (bien sea de proveedor o de articulo)

            registro.Tipo = compra;
            registro.Cantidad = int.Parse(txtCantidad.Text);
            decimal monto = Convert.ToDecimal(txtMonto.Text);
            monto = decimal.Round(monto, 2);

            registro.Monto = monto;
            registro.MontoTotal = registro.Cantidad * registro.Monto;

            int IdArticulo = int.Parse(ddlArticulo.SelectedValue);

            registro.proveedor = new Proveedor();
            List<Registro> Lista = (List<Registro>)Session["ListaCompra"];

            //revisar si el proveedor es el mismo que el anterior

            if (Session["ListaCompra"] != null)
            {

                if (Lista.Count > 0)
                {
                    if (Lista[Lista.Count - 1].proveedor.Id == int.Parse(ddlProveedor.SelectedValue))
                    {
                        registro.proveedor.Id = int.Parse(ddlProveedor.SelectedValue);
                        registro.proveedor.RazonSocial = ddlProveedor.SelectedItem.Text;
                        registro.Destinatario = int.Parse(ddlProveedor.SelectedValue);
                    }
                    else
                    {
                        registro.proveedor.Id = Lista[Lista.Count - 1].proveedor.Id;
                        registro.proveedor.RazonSocial = Lista[Lista.Count - 1].proveedor.RazonSocial;
                        registro.Destinatario = Lista[Lista.Count - 1].Destinatario;

                    }
                }
                else
                {

                    registro.proveedor.Id = int.Parse(ddlProveedor.SelectedValue);
                    registro.proveedor.RazonSocial = ddlProveedor.SelectedItem.Text;
                    registro.Destinatario = int.Parse(ddlProveedor.SelectedValue);
                }
            }


            registro.articulo = new Articulo();
            registro.articulo.Nombre = ddlArticulo.SelectedItem.Text;
            registro.articulo.Id = int.Parse(ddlArticulo.SelectedValue);

            Lista.Add(registro);

            //grisar el ddlProveedor que no permita cambiarlo una vez se selecciono uno en la lista


            //llamar al page load
            Response.Redirect("FormularioRegistroCompra.aspx");


        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            int IdRegistro = Session["RegistroSeleccionado"] != null ? ((Registro)Session["RegistroSeleccionado"]).Id : 0;

            List<Registro> Lista = (List<Registro>)Session["ListaCompra"];

            RegistroNegocio registroNegocio = new RegistroNegocio();

            int tipo = 1;
            int ultimaFactura = registroNegocio.ultimaFactura(tipo);

            foreach (Registro registro in Lista)
            {
                registro.IdFactura = ultimaFactura + 1;
            }

            registroNegocio.agregar(Lista);

            //actualiza los articulos

            foreach (Registro registro in Lista)
            {
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                Articulo articulo = new Articulo();
                // busca el stock anterior del producto
                List<Articulo> articulos = new List<Articulo>();
                articulos = articuloNegocio.listaParaEditar(registro.articulo.Id);
                articulo.Id = registro.articulo.Id;
                // se suma el stock anterior a la cantidad comprada
                articulo.Stock = articulos[0].Stock + registro.Cantidad;
                // actualiza el precio
                articulo.Precio = registro.Monto;
                // reescribe el porcentaje con el mismo valor
                articulo.Porcentaje = articulos[0].Porcentaje;
                // actualiza el ultimo proveedor
                Proveedor proveedor = new Proveedor();
                articulo.proveedor = proveedor;
                articulo.proveedor.Id = registro.Destinatario;
               
                articuloNegocio.modificarPorCompra(articulo);

            }

            Session.Remove("ListaCompra");
            Response.Redirect("WebVerRegistroCompra.aspx");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Session["RegistroSeleccionado"] != null)
            {
                int IdRegistro = Session["RegistroSeleccionado"] != null ? ((Registro)Session["RegistroSeleccionado"]).Id : 0;
                RegistroNegocio negocio = new RegistroNegocio();
                negocio.eliminar(IdRegistro);

                Session.Remove("RegistroSeleccionado");
                Response.Redirect("WebVerRegistroCompra.aspx");
            }
            else
            {
                lblMensaje.Text = "Debe seleccionar un registro para eliminarlo";
            }
        }

        protected void dgv_SelectedIndexChanged(object sender, EventArgs e)
        {
            int IdRegistro = Convert.ToInt32(dgvRegistroCompra.SelectedDataKey.Value.ToString());
            List<Registro> Lista = (List<Registro>)Session["ListaCompra"];
            List<Registro> ListaAux = new List<Registro>();


            foreach (Registro registro in Lista)
            {
                if (registro.Id != IdRegistro)
                {
                    ListaAux.Add(registro);
                }
            }

            Session.Remove("ListaCompra");
            Session.Add("ListaCompra", ListaAux);
            Response.Redirect("FormularioRegistroCompra.aspx");

            //RegistroNegocio negocio = new RegistroNegocio();
            ////negocio.eliminar(IdRegistro);
            //Response.Redirect("WebVerRegistroCompra.aspx");
        }
    }
}
