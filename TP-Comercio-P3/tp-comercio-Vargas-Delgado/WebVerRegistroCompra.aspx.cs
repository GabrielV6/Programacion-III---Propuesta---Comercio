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

            Session.Remove("ListaCompra");
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

        protected void listaFiltrada()
        {
            string filtro = txtFiltro.Text;
            ListaRegistro = (List<Registro>)Session["ListaRegistro"];
            ListaRegistro = ListaRegistro.FindAll(x => x.IdFactura.ToString().Contains(filtro));


            // Acumulo los montos de los resultados filtrados
            decimal total = 0;
            foreach (Registro item in ListaRegistro)
            {
                total = decimal.Round((decimal)ListaRegistro.Sum(x => x.Monto), 2);
            }
            txtMontoRemito.Text = total.ToString();
            txtMontoRemito.Enabled = false;
            dgvRegistro.DataSource = ListaRegistro;
            dgvRegistro.DataBind();

        }
        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            if (txtFiltro.Text != "")
            {
                listaFiltrada();
            }
            else
            {
                ListaRegistro = (List<Registro>)Session["ListaRegistro"];

                txtMontoRemito.Text = "";
                dgvRegistro.DataSource = ListaRegistro;
                dgvRegistro.DataBind();
            }
        }
    }
}
