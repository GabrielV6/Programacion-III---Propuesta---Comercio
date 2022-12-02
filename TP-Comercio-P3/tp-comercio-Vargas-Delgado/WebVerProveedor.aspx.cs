using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using System.Configuration;

namespace tp_comercio_Vargas_Delgado
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        public List<Proveedor> ListaProveedor { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

             ProveedorNegocio negocio = new ProveedorNegocio();
             ListaProveedor = negocio.listar();
             Session.Add("ListaProveedor", ListaProveedor);

            dgvProveedor.DataSource = negocio.listar();
            dgvProveedor.DataBind();


            if (!IsPostBack)
            {
                //Queda inactivado porque usamos GridView en vez de tarjetas
                //Repeater1.DataSource = ListaProveedor;
                //Repeater1.DataBind();
                
                dgvProveedor.DataSource = ListaProveedor;
                dgvProveedor.DataBind();
                Session.Remove("ProveedorSeleccionado");

            }


            if (Session["usuariologueado"] == null)
            {

                Session.Add("Error de acceso", "Debe iniciar sesión para acceder a esta página");
                Response.Redirect("Logon.aspx");
            }
        }
        
 //Queda inactivado porque usamos GridView en vez de tarjetas
        //protected void btnEliminar_Click(object sender, EventArgs e)
        //{
        //    int IdProveedor = Convert.ToInt32(((Button)sender).CommandArgument);
        //    ProveedorNegocio negocio = new ProveedorNegocio();
        //    negocio.eliminar(IdProveedor);
        //    Response.Redirect("WebVerProveedor.aspx");
        //}

        protected void listaFiltrada()
        {
            string filtro = txtFiltroProveedor.Text;
            ListaProveedor = (List<Proveedor>)Session["ListaProveedor"];
            ListaProveedor = ListaProveedor.FindAll(x => x.RazonSocial.Contains(filtro));
            
            //Queda inactivado porque usamos GridView en vez de tarjetas
            //Repeater1.DataSource = ListaProveedor;
            //Repeater1.DataBind();

            dgvProveedor.DataSource = ListaProveedor;
            dgvProveedor.DataBind();
        }


        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            if (txtFiltroProveedor.Text != "")
            {
                listaFiltrada();
            }
            else
            {
                ListaProveedor = (List<Proveedor>)Session["ListaProveedor"];
                //Queda inactivado porque usamos GridView en vez de tarjetas
                //Repeater1.DataSource = ListaProveedor;
                //Repeater1.DataBind();
                
                dgvProveedor.DataSource = ListaProveedor;
                dgvProveedor.DataBind();
            }
        }
        
 //Queda inactivado porque usamos GridView en vez de tarjetas y se llama desde el formulario
        //protected void btnEditar_Click(object sender, EventArgs e)
        //{
        //    int IdProveedor = Convert.ToInt32(((Button)sender).CommandArgument);
        //    ProveedorNegocio negocio = new ProveedorNegocio();
        //    //List<Proveedor> lista = negocio.ListaParaEditar(IdProveedor);

        //    Proveedor selecionado = (negocio.ListaParaEditar(IdProveedor))[0];
        //    //enviar datos selecionado al formulario de proveedores

        //    Session.Add("ProveedorSeleccionado", selecionado);
        //    Response.Redirect("FormularioProveedores.aspx");
        //}

        protected void dgv_SelectedIndexChanged(object sender, EventArgs e)
        {
            // int IdProveedor = Convert.ToInt32(((Button)sender).CommandArgument);
            //List<Proveedor> lista = negocio.ListaParaEditar(IdProveedor);
            
            int IdProveedor = Convert.ToInt32(dgvProveedor.SelectedDataKey.Value.ToString());
            ProveedorNegocio negocio = new ProveedorNegocio();
            Proveedor selecionado = (negocio.ListaParaEditar(IdProveedor))[0];
            
            //enviar datos selecionado al formulario de proveedores
            Session.Add("ProveedorSeleccionado", selecionado);
            Response.Redirect("FormularioProveedores.aspx");

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioProveedores.aspx");
        }
    }
}