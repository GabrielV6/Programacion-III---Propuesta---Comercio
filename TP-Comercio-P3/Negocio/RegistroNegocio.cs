using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Microsoft.Win32;

namespace Negocio
{
    public class RegistroNegocio
    {
        public List<Registro> listar()
        {
            List<Registro> lista = new List<Registro>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT R.Id, R.Tipo, R.Destinatario, R.idArticulo, R.Cantidad, R.Monto, R.Estado, P.RazonSocial, A.Nombre FROM REGISTROS R, PROVEEDORES P, ARTICULOS A WHERE R.Destinatario = P.Id AND R.idArticulo = A.Id");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Registro aux = new Registro();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Tipo = (int)datos.Lector["Tipo"];
                    aux.Destinatario = (int)datos.Lector["Destinatario"];
                    aux.Cantidad = (int)datos.Lector["Cantidad"];
                    aux.Monto = (decimal)datos.Lector["Monto"];
                    
                    aux.articulo = new Articulo();
                    aux.articulo.Id = (int)datos.Lector["idArticulo"];
                    aux.articulo.Nombre = (string)datos.Lector["Nombre"];
                    
                    aux.proveedor = new Proveedor();
                    aux.proveedor.Id = (int)datos.Lector["Destinatario"];
                    aux.proveedor.RazonSocial = (string)datos.Lector["RazonSocial"];
                    
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

        public List<Registro> listarPorTipo(int tipo)
        {
            List<Registro> lista = new List<Registro>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                if (tipo == 1) //si es compra se muestran proveedores
                {
                    datos.setearConsulta("SELECT R.Id, R.Tipo, R.Destinatario, R.idArticulo, R.Cantidad, R.Monto, R.Estado, P.RazonSocial, A.Nombre FROM REGISTROS R, PROVEEDORES P, ARTICULOS A WHERE R.Destinatario = P.Id AND R.idArticulo = A.Id AND R.Estado = 1 AND R.Tipo =" + tipo);
                }
                else // si es venta se muestran los clientes
                {
                    datos.setearConsulta("SELECT R.Id, R.Tipo, R.Destinatario, R.idArticulo, R.Cantidad, R.Monto, R.Estado, C.Nombre Cliente, A.Nombre FROM REGISTROS R, CLIENTES C, ARTICULOS A WHERE R.Destinatario = C.Id AND R.idArticulo = A.Id AND R.Estado = 1 AND R.Tipo =" + tipo);
                }
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Registro aux = new Registro();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Tipo = (int)datos.Lector["Tipo"];
                    aux.Destinatario = (int)datos.Lector["Destinatario"];
                    aux.Cantidad = (int)datos.Lector["Cantidad"];
                    aux.Monto = (decimal)datos.Lector["Monto"];
                    
                    aux.articulo = new Articulo();
                    aux.articulo.Id = (int)datos.Lector["idArticulo"];
                    aux.articulo.Nombre = (string)datos.Lector["Nombre"];

                    if (tipo == 1) 
                    {
                        aux.proveedor = new Proveedor();
                        aux.proveedor.Id = (int)datos.Lector["Destinatario"];
                        aux.proveedor.RazonSocial = (string)datos.Lector["RazonSocial"];
                    }
                    else 
                    {
                        aux.cliente = new Cliente();
                        aux.cliente.Id = (int)datos.Lector["Destinatario"];
                        aux.cliente.Nombre = (string)datos.Lector["Cliente"];
                    }

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
        public List<Registro> ListaParaEditar(int Id)
        {
            List<Registro> lista = new List<Registro>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT R.Id, R.Tipo , R.Destinatario ,R.Cantidad ,R.Monto, R.IdArticulo,P.RazonSocial, A.Nombre FROM ARTICULOS A, REGISTROS R, PROVEEDORES P  WHERE R.IdArticulo = A.Id AND R.Destinatario = P.Id AND R.Id=" + Id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Registro aux = new Registro();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Tipo = (int)datos.Lector["Tipo"];
                    aux.Destinatario = (int)datos.Lector["Destinatario"];
                    aux.Cantidad = (int)datos.Lector["Cantidad"];
                    aux.Monto = (decimal)datos.Lector["Monto"];
                    
                    aux.articulo = new Articulo();
                    aux.articulo.Id = (int)datos.Lector["idArticulo"];
                    aux.articulo.Nombre = (string)datos.Lector["Nombre"];

                    aux.proveedor = new Proveedor();
                    aux.proveedor.Id = (int)datos.Lector["Destinatario"];
                    aux.proveedor.RazonSocial = (string)datos.Lector["RazonSocial"];

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
        public void agregar(List<Registro> Lista)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                foreach (Registro registro in Lista)
                {
                    string sql = "values ('" + registro.Tipo + "','" + registro.Destinatario + "','" + registro.Cantidad + "','" + registro.Monto + "','" + registro.articulo.Id + "')";
                    datos.setearConsulta("insert into REGISTROS (Tipo, Destinatario, Cantidad, Monto, IdArticulo) " + sql);
                    
                    datos.ejecutarAccion();

                    //TODO: dejo comentada ya que me separa el monto con "," y la consulta lo toma como otra columna.
                    
                    //sql = "insert into REGISTROS (Tipo, Destinatario, Cantidad, Monto, IdArticulo) values (@tipo, @destinatario, @cantidad, @monto, @idArticulo)";
                    //sql = sql.Replace("@tipo", registro.Tipo.ToString());
                    //sql = sql.Replace("@destinatario", registro.Destinatario.ToString());
                    //sql = sql.Replace("@cantidad", registro.Cantidad.ToString());
                    //sql = sql.Replace("@monto", registro.Monto.ToString());
                    //sql = sql.Replace("@idArticulo", registro.articulo.Id.ToString());
                    //datos.setearConsulta(sql)
                }

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
        public void modificar(Registro registro)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //TODO : SE DEBE VERIFICAR QUE ESTE OK...
                datos.setearConsulta("update REGISTROS set Tipo = @tipo, Destinatario = @destinatario, Cantidad = @cantidad, Monto = @monto, IdArticulo = @idArticulo Where Id = @id");
                datos.setearParametro("@id", registro.Id);
                datos.setearParametro("@tipo", registro.Tipo);
                datos.setearParametro("@destinatario", registro.Destinatario);
                datos.setearParametro("@cantidad", registro.Cantidad);
                datos.setearParametro("@monto", registro.Monto);
                datos.setearParametro("@idArticulo", registro.articulo.Id);
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
                datos.setearConsulta("update REGISTROS set Estado=0 Where Id = @id");
                datos.setearParametro("@id", id);
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
