using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;


namespace tp_comercio_Vargas_Delgado
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        public List<Proveedor> ListaProveedor { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            ProveedorNegocio negocio = new ProveedorNegocio();
            ListaProveedor = negocio.listar();
            Session.Add("ListaProvedor", ListaProveedor);

            if (!IsPostBack)
            {
               Repeater1.DataSource = ListaProveedor;
               Repeater1.DataBind();
            }
            
            if (Session["usuariologueado"] == null)
            {

                Session.Add("Error de acceso", "Debe iniciar sesión para acceder a esta página");
                Response.Redirect("Logon.aspx");
            }
        }
        
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int IdProveedor = Convert.ToInt32(((Button)sender).CommandArgument);
            ProveedorNegocio negocio = new ProveedorNegocio();
            negocio.eliminar(IdProveedor);
            Response.Redirect("WebVerProveedor.aspx");
        }
        
        protected void listaFiltrada()
        {
            string filtro = txtFiltroProveedor.Text;
            ListaProveedor = (List<Proveedor>)Session["ListaProveedor"];
            ListaProveedor = ListaProveedor.FindAll(x => x.RazonSocial.Contains(filtro));

            Repeater1.DataSource = ListaProveedor;
            Repeater1.DataBind();
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
                Repeater1.DataSource = ListaProveedor;
                Repeater1.DataBind();
            }
        }
    }
}