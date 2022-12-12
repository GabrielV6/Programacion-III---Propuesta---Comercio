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
    public partial class FormularioArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["usuariologueado"] == null)
                {

                    Session.Add("Error de acceso", "Debe iniciar sesión para acceder a esta página");
                    Response.Redirect("Logon.aspx");
                }
                if (!IsPostBack)
                {
                    MarcaNegocio marcaNegocio = new MarcaNegocio();
                    List<Marca> listaMarca = marcaNegocio.listar();

                    ddlMarca.DataSource = listaMarca;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "DescripcionMarca";
                    ddlMarca.DataBind();

                    CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                    List<Categoria> listaCategoria = categoriaNegocio.listar();

                    ddlCategoria.DataSource = listaCategoria;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();

                    ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
                    List<Proveedor> listaProveedor = proveedorNegocio.listar();

                    ddlProveedor.DataSource = listaProveedor;
                    ddlProveedor.DataValueField = "Id";
                    ddlProveedor.DataTextField = "RazonSocial";
                    ddlProveedor.DataBind();
                }
                if (Session["ArticuloSeleccionado"] != null && !IsPostBack ) 
                {
                    Articulo articulo = (Articulo)Session["ArticuloSeleccionado"];
                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    txtPrecio.Text = articulo.Precio.ToString();
                    txtPorcentaje.Text = articulo.Porcentaje.ToString();
                    ddlMarca.SelectedValue = articulo.marca.Id.ToString();
                    ddlCategoria.SelectedValue = articulo.categoria.Id.ToString();
                    txtImagenUrl.Text = articulo.ImagenUrl;
                    txtImagenUrl_TextChanged(sender, e);
                }
                
                if(Session["ArticuloSeleccionado"] != null && (Session["usuariologueado"] != null && ((Dominio.RolUsuario)Session["rolusuario"]) != Dominio.RolUsuario.Administrador) && !IsPostBack)
                {
                   

                    Articulo articulo = (Articulo)Session["ArticuloSeleccionado"];
                    txtCodigo.Text = articulo.Codigo;
                    txtCodigo.ReadOnly = true;
                    
                    txtNombre.Text = articulo.Nombre;
                    txtNombre.ReadOnly = true;
                    
                    txtDescripcion.Text = articulo.Descripcion;
                    txtDescripcion.ReadOnly = true;
                    
                    txtPrecio.Text = articulo.Precio.ToString();
                    txtPrecio.ReadOnly = true;
                 
                    txtPorcentaje.Text = articulo.Porcentaje.ToString();
                    txtPorcentaje.ReadOnly = true;

                    ddlMarca.SelectedValue = articulo.marca.Id.ToString();
                    ddlMarca.Enabled = false;

              
                    ddlCategoria.SelectedValue = articulo.categoria.Id.ToString();
                    ddlCategoria.Enabled = false;
                    
                    txtImagenUrl.Text = articulo.ImagenUrl;
                    txtImagenUrl.ReadOnly = true;
                    txtImagenUrl_TextChanged(sender, e);

                    ddlProveedor.Enabled = false;

                }

               
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
            }

        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            //Page.Validate();
            //if (!Page.IsValid)
            //    return;

            try
            {
                int IdArticulo = Session["ArticuloSeleccionado"] != null ? ((Articulo)Session["ArticuloSeleccionado"]).Id : 0;

                Articulo articulo = new Articulo();
                articulo.Id = IdArticulo;
                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.Precio = Convert.ToDecimal(txtPrecio.Text);
                articulo.Porcentaje = Convert.ToDecimal(txtPorcentaje.Text);
                articulo.ImagenUrl = txtImagenUrl.Text;
                articulo.marca = new Marca();
                articulo.marca.Id = int.Parse(ddlMarca.SelectedValue);
                articulo.categoria = new Categoria();
                articulo.categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                articulo.proveedor = new Proveedor();
                articulo.proveedor.Id = int.Parse(ddlProveedor.SelectedValue);
               

                ArticuloNegocio articuloNegocio = new ArticuloNegocio();



                if (IdArticulo == 0)
                {
                    articuloNegocio.agregar(articulo);
                }
                else
                {
                    List<Articulo> listaArticulos = articuloNegocio.listaParaEditar(articulo.Id);
                    articulo.Stock = listaArticulos[0].Stock;

                    articuloNegocio.modificar(articulo);
                    Session.Remove("ArticuloSeleccionado");
                }
                Response.Redirect("WebVerArticulo.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
            }
        }
        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtImagenUrl.Text;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            

            if (Session["ArticuloSeleccionado"] != null)
            {
                int IdArticulo = Session["ArticuloSeleccionado"] != null ? ((Articulo)Session["ArticuloSeleccionado"]).Id : 0;
                ArticuloNegocio negocio = new ArticuloNegocio();
                negocio.eliminar(IdArticulo);

                //remover proveedor de la session
                Session.Remove("ArticuloSeleccionado");

                //redirecciona a la vista
                Response.Redirect("WebVerArticulo.aspx");
            }
            else
            {
                lblMensaje.Text = "Debe seleccionar un articulo para eliminarlo";

            }

        }
    }
}