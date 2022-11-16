using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace tp_comercio_Vargas_Delgado
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulo { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {   
            ArticuloNegocio negocio = new ArticuloNegocio();
            ListaArticulo = negocio.listarConSP();
            Session.Add("ListaArticulo", ListaArticulo);

            if (!IsPostBack)
            {
                Repeater1.DataSource = ListaArticulo;
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
            int idArticulo = Convert.ToInt32(((Button)sender).CommandArgument);
            ArticuloNegocio negocio = new ArticuloNegocio();
            negocio.eliminar(idArticulo);
            Response.Redirect("WebVerArticulo.aspx");
        }
        protected void listaFiltrada()
        {
            string filtro = txtFiltro.Text;
            ListaArticulo = (List<Articulo>)Session["ListaArticulo"];
            ListaArticulo = ListaArticulo.FindAll(x => x.Nombre.Contains(filtro));

            Repeater1.DataSource = ListaArticulo;
            Repeater1.DataBind();
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            if (txtFiltro.Text != "")
            {
                listaFiltrada();
            }
            else
            {
                ListaArticulo = (List<Articulo>)Session["ListaArticulo"];
                Repeater1.DataSource = ListaArticulo;
                Repeater1.DataBind();
            }
        }
    
    }
}