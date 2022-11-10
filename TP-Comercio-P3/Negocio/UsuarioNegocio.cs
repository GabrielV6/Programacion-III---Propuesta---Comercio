using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace Negocio
{
    public class UsuarioNegocio
    {
        public bool Loguear(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                // TODO: Hacer la consulta con el SP, pero hace falta saber como pasarle los parametros.
                
               // datos.setearProcedimiento("SP_ValidarUsuario ");
               
                
                 datos.setearConsulta("select Usuario, IdRol from USUARIOS where Usuario = @User and CONVERT(Varchar(50),DECRYPTBYPASSPHRASE(@patron,Contraseña))=@Pass");
                 datos.setearParametro("@User", usuario.user);
                 datos.setearParametro("@Pass", usuario.pass);
                 datos.setearParametro("@patron", usuario.patron);

                datos.ejecutarLectura();
                
                while (datos.Lector.Read())
                {
                  
                  usuario.user = (string)datos.Lector["Usuario"];
                  usuario.rolusuario = (int)(datos.Lector["IdRol"]) == 1000 ? RolUsuario.Administrador : RolUsuario.Encargado;
                    
                    
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
    }
}
