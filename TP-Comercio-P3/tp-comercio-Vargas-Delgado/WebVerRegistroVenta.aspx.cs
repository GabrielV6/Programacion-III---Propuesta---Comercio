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
    public partial class WebVerRegistroVenta : System.Web.UI.Page
    {
        public List<Registro> ListaRegistro { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            RegistroNegocio negocio = new RegistroNegocio();
            int venta = 0; 
            ListaRegistro = negocio.listarPorTipo(venta);
            Session.Add("ListaRegistro", ListaRegistro);

            dgvRegistro.DataSource = negocio.listarPorTipo(venta);
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

            Session.Remove("ListaVenta");
        }
        protected void dgv_SelectedIndexChanged(object sender, EventArgs e)
        {
            int IdRegistro = Convert.ToInt32(dgvRegistro.SelectedDataKey.Value.ToString());
            RegistroNegocio negocio = new RegistroNegocio();
            negocio.eliminar(IdRegistro);
            Response.Redirect("WebVerRegistroVenta.aspx");
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioRegistroVenta.aspx");
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
            txtMontoFactura.Text = total.ToString();
            txtMontoFactura.Enabled = false;
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

                // Queda inactivado porque usamos GridView en vez de tarjetas

                //Repeater1.DataSource = ListaArticulo;
                //Repeater1.DataBind();
                txtMontoFactura.Text = "";
                dgvRegistro.DataSource = ListaRegistro;
                dgvRegistro.DataBind();
            }
        }
    }
}
