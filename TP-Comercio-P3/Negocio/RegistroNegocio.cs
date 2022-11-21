using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

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
                datos.setearConsulta("SELECT * FROM REGISTROS WHERE Estado=1 AND Id=" + Id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Registro aux = new Registro();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Tipo = (int)datos.Lector["Tipo"];
                    aux.Destinatario = (int)datos.Lector["Destinatario"];
                    aux.Cantidad = (int)datos.Lector["Cantidad"];
                    aux.Monto = (decimal)datos.Lector["Monto"];
                    aux.Estado = Convert.ToInt16(datos.Lector["Estado"]);

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
    }
}
