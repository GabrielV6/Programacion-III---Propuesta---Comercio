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
    public partial class WebForm4 : System.Web.UI.Page
    {
        public List<Categoria> ListaCategoria { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            ListaCategoria = negocio.listar();

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
            CategoriaNegocio negocio = new CategoriaNegocio();
         // negocio.eliminar(int.Parse(txtId.Text)); modificar esta linea con el id del registro 
            Response.Redirect("WebVerCategoria.aspx");
        }
    }
}