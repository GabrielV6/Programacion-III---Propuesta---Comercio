using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using System.EnterpriseServices;

namespace tp_comercio_Vargas_Delgado
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        public List<Categoria> ListaCategoria { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            ListaCategoria = negocio.listar();
            Session.Add("ListaCategoria", ListaCategoria);

            if (!IsPostBack)
            {
                Repeater1.DataSource = ListaCategoria;
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
            int idCategoria = Convert.ToInt32(((Button)sender).CommandArgument);
            CategoriaNegocio negocio = new CategoriaNegocio();
            negocio.eliminar(idCategoria);
            Response.Redirect("WebVerCategoria.aspx");
        }

        protected void listaFiltrada()
        {
            string filtro = txtFiltro.Text;
            ListaCategoria = (List<Categoria>)Session["ListaCategoria"];
            ListaCategoria = ListaCategoria.FindAll(x => x.Descripcion.Contains(filtro));

            Repeater1.DataSource = ListaCategoria;
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
                ListaCategoria = (List<Categoria>)Session["ListaCategoria"];
                Repeater1.DataSource = ListaCategoria;
                Repeater1.DataBind();
            }
        }
    }
}