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
    public partial class WebVerMarca : System.Web.UI.Page
    {
        public List<Marca> ListaMarca { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            MarcaNegocio negocio = new MarcaNegocio();
            ListaMarca = negocio.listar();
            Session.Add("ListaMarca", ListaMarca);

            if (!IsPostBack)
            {
                Repeater1.DataSource = ListaMarca;
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
            int idMarca = Convert.ToInt32(((Button)sender).CommandArgument);
            MarcaNegocio negocio = new MarcaNegocio();
            negocio.eliminar(idMarca);
            Response.Redirect("WebVerMarca.aspx");
        }

        protected void listaFiltrada()
        {
            string filtro = txtFiltro.Text;
            ListaMarca = (List<Marca>)Session["ListaMarca"];
            ListaMarca = ListaMarca.FindAll(x => x.DescripcionMarca.Contains(filtro));

            Repeater1.DataSource = ListaMarca;
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
                ListaMarca = (List<Marca>)Session["ListaMarca"];
                Repeater1.DataSource = ListaMarca;
                Repeater1.DataBind();
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int IdMarca = Convert.ToInt32(((Button)sender).CommandArgument);
            MarcaNegocio negocio = new MarcaNegocio();
            Marca selecionada = (negocio.listaParaEditar(IdMarca))[0];
            Session.Add("MarcaSeleccionada", selecionada);
            Response.Redirect("FormularioMarca.aspx");
        }
    }
}