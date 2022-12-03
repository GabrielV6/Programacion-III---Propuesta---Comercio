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
    public partial class WebVerRegistroCompra : System.Web.UI.Page
    {
        public List<Registro> ListaRegistro { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            RegistroNegocio negocio = new RegistroNegocio();
            int compra = 1;
            ListaRegistro = negocio.listarPorTipo(compra);
            Session.Add("ListaRegistro", ListaRegistro);

            dgvRegistro.DataSource = negocio.listarPorTipo(compra);
            dgvRegistro.DataBind();

            if (!IsPostBack)
            {
                dgvRegistro.DataSource = ListaRegistro;
                dgvRegistro.DataBind();
            }

            if (Session["usuariologueado"] == null)
            {
                Session.Add("Error de acceso", "Debe iniciar sesión para acceder a esta página");
                Response.Redirect("Logon.aspx");
            }
        }
        protected void dgv_SelectedIndexChanged(object sender, EventArgs e)
        {
            int IdRegistro = Convert.ToInt32(dgvRegistro.SelectedDataKey.Value.ToString());
            RegistroNegocio negocio = new RegistroNegocio();
            negocio.eliminar(IdRegistro);
            Response.Redirect("WebVerRegistroCompra.aspx"); 
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioRegistroCompra.aspx");
        }
    }
}
