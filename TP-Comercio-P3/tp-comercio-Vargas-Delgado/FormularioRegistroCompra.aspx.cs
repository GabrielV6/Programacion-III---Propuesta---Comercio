﻿using Dominio;
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

            Registro registro = new Registro();

            int compra = 1;
            // el registro.Id sera igual al valor que tiene la sesscion en ID  +1 

            registro.Id = Session["ListaCompra"] != null ? ((List<Registro>)Session["ListaCompra"]).Count + 1 : 1;
         
            

            registro.Tipo = compra;
            registro.Cantidad = int.Parse(txtCantidad.Text);

            registro.Monto = Convert.ToDecimal(txtMonto.Text);
            registro.MontoTotal = registro.Cantidad * registro.Monto;

            int IdArticulo = int.Parse(ddlArticulo.SelectedValue);
            
            registro.articulo = new Articulo();
            registro.articulo.Id = int.Parse(ddlArticulo.SelectedValue);

            registro.proveedor = new Proveedor();
            registro.proveedor.RazonSocial = ddlProveedor.SelectedItem.Text;

            registro.articulo = new Articulo();
            registro.articulo.Nombre = ddlArticulo.SelectedItem.Text;


            List<Registro> Lista = (List<Registro>)Session["ListaCompra"];
            Lista.Add(registro);

            //llamar al page load
            Response.Redirect("FormularioRegistroCompra.aspx");


        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
                return;

            int IdRegistro = Session["RegistroSeleccionado"] != null ? ((Registro)Session["RegistroSeleccionado"]).Id : 0;

            List<Registro> ListaRegistro = new List<Registro>();

            Registro registro = new Registro();
            registro.Id = IdRegistro;
            int compra = 1;
            registro.Tipo = compra;
            registro.Destinatario = int.Parse(ddlProveedor.SelectedValue);
            registro.Cantidad = int.Parse(txtCantidad.Text);
            registro.Monto = Convert.ToDecimal(txtMonto.Text);
            registro.articulo = new Articulo();
            registro.articulo.Id = int.Parse(ddlArticulo.SelectedValue);

            ListaRegistro.Add(registro);
            ListaRegistro.Add(registro);

            RegistroNegocio registroNegocio = new RegistroNegocio();
            if (IdRegistro == 0)
            {
                registroNegocio.agregar(ListaRegistro);
            }
            else
            {
                registroNegocio.modificar(registro);
                Session.Remove("RegistroSeleccionado");
            }
            /*
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            Articulo articulo = new Articulo();
            // busca el stock anterior del producto
            List<Articulo> articulos = new List<Articulo>();
            articulos = articuloNegocio.listaParaEditar(registro.articulo.Id);
            articulo.Id = registro.articulo.Id;
            // se suma el stock anterior a la cantidad comprada
            articulo.Stock = articulos[0].Stock + registro.Cantidad;
            // actualiza el ultimo proveedor
            Proveedor proveedor = new Proveedor();
            articulo.proveedor = proveedor;
            articulo.proveedor.Id = registro.Destinatario;
            articuloNegocio.modificarPorCompra(articulo);
            */

            Response.Redirect("WebVerRegistroCompra.aspx", false);
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
            RegistroNegocio negocio = new RegistroNegocio();
            //negocio.eliminar(IdRegistro);
            Response.Redirect("WebVerRegistroCompra.aspx");
        }
    }
}
