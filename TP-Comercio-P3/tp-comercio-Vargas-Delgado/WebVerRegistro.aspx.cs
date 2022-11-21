using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace tp_comercio_Vargas_Delgado
{
    public partial class WebVerRegistro : System.Web.UI.Page
    {
        public List<Registro> ListaRegistro { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            RegistroNegocio negocio = new RegistroNegocio();
            ListaRegistro = negocio.listar();
            Session.Add("ListaRegistro", ListaRegistro);

            dgvRegistro.DataSource = negocio.listar();
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
            Registro selecionado = (negocio.ListaParaEditar(IdRegistro))[0];

            Session.Add("RegistroSeleccionado", selecionado);
            Response.Redirect("FormularioRegistro.aspx");
        }
    }
}