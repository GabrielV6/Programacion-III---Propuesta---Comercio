using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
                datos.setearConsulta("SELECT R.Id, R.Tipo , R.Destinatario ,R.Cantidad ,R.Monto, R.IdArticulo, A.Nombre Articulo FROM ARTICULOS A, REGISTROS R  WHERE R.IdArticulo = A.Id");
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
                    aux.articulo.Id = (int)datos.Lector["IdArticulo"];
                    aux.articulo.Nombre = (string)datos.Lector["Articulo"];
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
                datos.setearConsulta("SELECT R.Id, R.Tipo , R.Destinatario ,R.Cantidad ,R.Monto, R.IdArticulo, A.Nombre Articulo FROM ARTICULOS A, REGISTROS R  WHERE R.IdArticulo = A.Id AND R.Estado=1 AND R.Id=" + Id);
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
                    aux.articulo.Id = (int)datos.Lector["IdArticulo"];
                    aux.articulo.Nombre = (string)datos.Lector["Articulo"];
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
        public void agregar(Registro registro)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string valores = "values('" + registro.Tipo + "','" + registro.Destinatario + "','" + registro.Cantidad + "'," + registro.Monto + ",'" + registro.articulo.Id + ")";
                datos.setearConsulta("insert into REGISTROS (Tipo, Destinatario, Cantidad, Monto, IdArticulo) " + valores);
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
        public void modificar(Registro registro)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
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
                datos.setearConsulta("delete from REGISTROS Where Id = @id");
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
