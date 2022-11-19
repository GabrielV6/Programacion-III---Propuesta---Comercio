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
    public partial class WebForm3 : System.Web.UI.Page
    {
        public List<Cliente> ListaCliente { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ClienteNegocio negocio = new ClienteNegocio();
            ListaCliente = negocio.listar();
            Session.Add("ListaCliente", ListaCliente);

            if (!IsPostBack)
            {
                Repeater1.DataSource = ListaCliente;
                Repeater1.DataBind();
            }

            if (Session["usuariologueado"] == null)
            {

                Session.Add("Error de acceso", "Debe iniciar sesión para acceder a esta página");
                Response.Redirect("Logon.aspx");
            }
        }
        
        protected void listaFiltrada()
        {
            string filtro = txtFiltroCliente.Text;
            ListaCliente = (List<Cliente>)Session["ListaCliente"];
            ListaCliente = ListaCliente.FindAll(x => x.Nombre.Contains(filtro));

            Repeater1.DataSource = ListaCliente;
            Repeater1.DataBind();
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            if (txtFiltroCliente.Text != "")
            {
                listaFiltrada();
            }
            else
            {
                ListaCliente = (List<Cliente>)Session["ListaCliente"];
                Repeater1.DataSource = ListaCliente;
                Repeater1.DataBind();
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int IdCliente = Convert.ToInt32(((Button)sender).CommandArgument);
            ClienteNegocio negocio = new ClienteNegocio();
            negocio.eliminar(IdCliente);
            Response.Redirect("WebVerCliente.aspx");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int IdCliente = Convert.ToInt32(((Button)sender).CommandArgument);
            ClienteNegocio negocio = new ClienteNegocio();
     

            Cliente selecionado = (negocio.ListaParaEditar(IdCliente))[0];


            Session.Add("ClienteSeleccionado", selecionado);
            Response.Redirect("FormularioCliente.aspx"); 
        }

        
    }
}