using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using System.EnterpriseServices;
using System.Collections;

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
                //Queda inactivado porque usamos GridView en vez de tarjetas
    
                //Repeater1.DataSource = ListaCategoria;
                //Repeater1.DataBind();
                
                dgvCategoria.DataSource = ListaCategoria;
                dgvCategoria.DataBind();
            }

            if (Session["usuariologueado"] == null)
            {
                Session.Add("Error de acceso", "Debe iniciar sesión para acceder a esta página");
                Response.Redirect("Logon.aspx");
            }
        }

//Queda inactivado porque usamos GridView en vez de tarjetas

        //protected void btnEliminar_Click(object sender, EventArgs e)
        //{
        //    int idCategoria = Convert.ToInt32(((Button)sender).CommandArgument);
        //    CategoriaNegocio negocio = new CategoriaNegocio();
        //    negocio.eliminar(idCategoria);
        //    Response.Redirect("WebVerCategoria.aspx");
        //}

        protected void listaFiltrada()
        {
            string filtro = txtFiltro.Text;
            ListaCategoria = (List<Categoria>)Session["ListaCategoria"];
            ListaCategoria = ListaCategoria.FindAll(x => x.Descripcion.Contains(filtro));

            // Queda inactivado porque usamos GridView en vez de tarjetas

            //Repeater1.DataSource = ListaCategoria;
            //Repeater1.DataBind();

            dgvCategoria.DataSource = ListaCategoria;
            dgvCategoria.DataBind();
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
                
                // Queda inactivado porque usamos GridView en vez de tarjetas
                
                //Repeater1.DataSource = ListaCategoria;
                //Repeater1.DataBind();

                dgvCategoria.DataSource = ListaCategoria;
                dgvCategoria.DataBind();
            }
        }

        //Queda inactivado porque usamos GridView en vez de tarjetas y se llama desde el formulario
        //protected void btnEditar_Click(object sender, EventArgs e)
        //{
        //    int IdCategoria = Convert.ToInt32(((Button)sender).CommandArgument);
        //    CategoriaNegocio negocio = new CategoriaNegocio();

        //    Categoria selecionada = (negocio.listaParaEditar(IdCategoria))[0];

        //    Session.Add("CategoriaSeleccionada", selecionada);
        //    Response.Redirect("FormularioCategoria.aspx");
        //}

        protected void dgv_SelectedIndexChanged(object sender, EventArgs e)
        {
            // int IdProveedor = Convert.ToInt32(((Button)sender).CommandArgument);
            //List<Proveedor> lista = negocio.ListaParaEditar(IdProveedor);

            int IdCategoria = Convert.ToInt32(dgvCategoria.SelectedDataKey.Value.ToString());
            CategoriaNegocio negocio = new CategoriaNegocio();
            Categoria selecionado = (negocio.listaParaEditar(IdCategoria))[0];

            //enviar datos selecionado al formulario de proveedores
            Session.Add("CategoriaSeleccionada", selecionado);
            Response.Redirect("FormularioCategoria.aspx");

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Session.Remove("CategoriaSeleccionada");
            Response.Redirect("FormularioCategoria.aspx");
        }
    }
}