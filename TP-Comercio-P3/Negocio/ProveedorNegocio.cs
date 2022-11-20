using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ProveedorNegocio
    {
        public List<Proveedor> listar()
        {
            List<Proveedor> lista = new List<Proveedor>();
            AccesoDatos datos = new AccesoDatos();

            try
            {   
                datos.setearConsulta("SELECT * FROM PROVEEDORES  WHERE Estado=1");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Proveedor aux = new Proveedor();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.RazonSocial = (string)datos.Lector["RazonSocial"];
                    aux.Cuit = (string)datos.Lector["Cuit"];
                    aux.Telefono = (string)datos.Lector["Telefono"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Estado = Convert.ToBoolean(datos.Lector["Estado"]);

                    lista.Add(aux);
                }
                return lista;
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
        
        public List<Proveedor> ListaParaEditar(int Id)
        {
            List<Proveedor> lista = new List<Proveedor>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT * FROM PROVEEDORES  WHERE Estado=1 AND Id=" + Id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Proveedor aux = new Proveedor();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.RazonSocial = (string)datos.Lector["RazonSocial"];
                    aux.Cuit = (string)datos.Lector["Cuit"];
                    aux.Telefono = (string)datos.Lector["Telefono"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Estado = Convert.ToBoolean(datos.Lector["Estado"]);

                    lista.Add(aux);
                }
                return lista;
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
        
        public void agregar(Proveedor proveedor)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string valores = "values('" + proveedor.RazonSocial + "','" + proveedor.Cuit + "','" + proveedor.Telefono + "','" + proveedor.Email + "',1)";
                datos.setearConsulta("INSERT INTO PROVEEDORES (RazonSocial, Cuit, Telefono, Email, Estado) " + valores);
                
                datos.ejecutarAccion();
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

        public void modificar(Proveedor proveedor)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("UPDATE PROVEEDORES SET RazonSocial='" + proveedor.RazonSocial + "', Cuit='" + proveedor.Cuit + "', Telefono='" + proveedor.Telefono + "', Email='" + proveedor.Email + "' WHERE Id=" + proveedor.Id);
                

                datos.ejecutarAccion();
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

        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE PROVEEDORES SET Estado=0 WHERE Id=" + id);
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();
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
