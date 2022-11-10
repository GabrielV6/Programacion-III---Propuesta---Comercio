using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace tp_comercio_Vargas_Delgado
{
    public partial class Pagina1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        //Patron de encriptado BD 
        string patron = "Programacion3";
        
        protected void BtnIngresar_Click(object sender, EventArgs e)
        {
            Usuario usuario;
            UsuarioNegocio negocio = new UsuarioNegocio();
            
            try
            {
                usuario = new Usuario(tbxUsuario.Text, tbxContraseña.Text, false, patron);
                if (negocio.Loguear(usuario))
                {
                    //Cargamos la sesion con el usuario logueado 
                    
                    Session["usuariologueado"] = tbxUsuario;
                    Session["usuariologueado"] = tbxUsuario.Text;
                    Session["rolusuario"] = usuario.rolusuario;
                    Response.Redirect("Default.aspx",false);
                }
                else
                {
                    Session.Add("Error", "Usuario o contraseña incorrectos");
                    lblError.Text = "Error de Usuario o Contraseña";
                    
                }

            }
            catch (Exception ex)
            {

                lblError.Text = "Error inesperado, intente de nuevo";
                
                
            }

 // Se comenta codigo de alternativa 2 
            
            /* string conectar = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;


             SqlConnection sqlConectar = new SqlConnection(conectar);
             SqlCommand cmd = new SqlCommand("SP_ValidarUsuario", sqlConectar)
             {
                 CommandType = CommandType.StoredProcedure
             };
             cmd.Connection.Open();
             cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = tbxUsuario.Text;
             cmd.Parameters.Add("@Contraseña", SqlDbType.VarChar, 50).Value = tbxContraseña.Text;
             cmd.Parameters.Add("@Patron", SqlDbType.VarChar, 50).Value = patron;
             SqlDataReader dr = cmd.ExecuteReader();
             if (dr.Read())
             {
                 //Agregamos una sesion de usuario
                 Session["Usuariologueado"] = tbxUsuario;
                 Session["usuariologueado"] = tbxUsuario.Text;
                 Response.Redirect("Default.aspx");
             }
             else
             {
                 lblError.Text = "Error de Usuario o Contraseña";
             }

             cmd.Connection.Close();
            */
        }
    }
}