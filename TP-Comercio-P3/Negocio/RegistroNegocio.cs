﻿using System;
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
                datos.setearConsulta("SELECT R.Fecha, R.Id, R.Tipo, R.Destinatario, R.idArticulo, R.Cantidad, R.Monto, R.Estado, P.RazonSocial, A.Nombre FROM REGISTROS R, PROVEEDORES P, ARTICULOS A WHERE R.Destinatario = P.Id AND R.idArticulo = A.Id");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Registro aux = new Registro();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Tipo = (int)datos.Lector["Tipo"];
                    aux.Destinatario = (int)datos.Lector["Destinatario"];
                    aux.Cantidad = (int)datos.Lector["Cantidad"];
                    aux.Monto = (decimal)datos.Lector["Monto"];
                    aux.Fecha = (DateTime)datos.Lector["Fecha"];

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
                if (tipo == 1) //si es compra se muestran proveedores (Compra = 1)
                {
                    datos.setearConsulta("SELECT R.Fecha, R.Porcentaje, R.IdFactura, R.Id, R.Tipo, R.Destinatario, R.idArticulo, R.Cantidad, R.Monto, R.Estado, P.RazonSocial, A.Nombre FROM REGISTROS R, PROVEEDORES P, ARTICULOS A WHERE R.Destinatario = P.Id AND R.idArticulo = A.Id AND R.Estado = 1 AND R.Tipo =" + tipo);
                }
                else // si es venta se muestran los clientes (Venta = 0)
                {
                    datos.setearConsulta("SELECT R.Fecha, R.Porcentaje, R.IdFactura, R.Id, R.Tipo, R.Destinatario, R.idArticulo, R.Cantidad, R.Monto, R.Estado, C.Nombre AS NombreCliente, A.Nombre FROM REGISTROS R, CLIENTES C, ARTICULOS A WHERE R.Destinatario = C.Id AND R.idArticulo = A.Id AND R.Estado = 1 AND R.Tipo =" + tipo);
                }
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Registro aux = new Registro();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Tipo = (int)datos.Lector["Tipo"];
                    aux.Destinatario = (int)datos.Lector["Destinatario"];
                    aux.Cantidad = (int)datos.Lector["Cantidad"];
                    decimal monto = (decimal)datos.Lector["Monto"];
                    monto = decimal.Round(monto, 2);
                    aux.Monto = monto;
                    aux.IdFactura = (int)datos.Lector["IdFactura"];
                    //mostrar fecha corta
                    aux.Fecha = (DateTime)datos.Lector["Fecha"];
                    aux.Porcentaje = (decimal)datos.Lector["Porcentaje"];

                    aux.articulo = new Articulo();
                    aux.articulo.Id = (int)datos.Lector["idArticulo"];
                    aux.articulo.Nombre = (string)datos.Lector["Nombre"];
                    decimal porcentaje = (decimal)datos.Lector["Porcentaje"];
                    porcentaje = decimal.Round(porcentaje, 2);
                    aux.articulo.Porcentaje = porcentaje;

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
                        aux.cliente.Nombre = (string)datos.Lector["NombreCliente"];
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
                datos.setearConsulta("SELECT R.Fecha, R.Id, R.Tipo , R.Destinatario ,R.Cantidad ,R.Monto, R.IdArticulo,P.RazonSocial, A.Nombre FROM ARTICULOS A, REGISTROS R, PROVEEDORES P  WHERE R.IdArticulo = A.Id AND R.Destinatario = P.Id AND R.Id=" + Id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Registro aux = new Registro();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Tipo = (int)datos.Lector["Tipo"];
                    aux.Destinatario = (int)datos.Lector["Destinatario"];
                    aux.Cantidad = (int)datos.Lector["Cantidad"];
                    aux.Monto = (decimal)datos.Lector["Monto"];
                    aux.Fecha = (DateTime)datos.Lector["Fecha"];
                    
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
                    string monto = registro.Monto.ToString().Replace(",", ".");
                    string porcentaje = registro.Porcentaje.ToString().Replace(",", ".");

                    //fecha del dia
                    string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");


                    string sql = "values ('" + registro.Tipo + "','" + registro.Destinatario + "','" + registro.Cantidad + "','" + monto + "','" + registro.articulo.Id + "','" + registro.IdFactura + "','" + porcentaje + "','" + fecha + "')";
                    

                    datos.setearConsulta("insert into REGISTROS (Tipo, Destinatario, Cantidad, Monto, IdArticulo, IdFactura, Porcentaje, Fecha) " + sql);                    
                    datos.ejecutarAccion();

          
             
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

        public int ultimaFactura(int tipo)
        {
            List<Registro> lista = new List<Registro>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                int ultimaFactura;
                datos.setearConsulta("SELECT distinct R.Id, R.Tipo , R.Destinatario ,R.Cantidad ,R.Monto, R.IdFactura FROM ARTICULOS A, REGISTROS R, PROVEEDORES P  WHERE IdFactura = (select Max(IdFactura) from REGISTROS WHERE Tipo = @tipo)");
                datos.setearParametro("@tipo", tipo);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Registro aux = new Registro();
                    aux.IdFactura = (int)datos.Lector["IdFactura"];
                    lista.Add(aux);
                }

                if (lista.Count < 1 && tipo ==0)
                {
                    ultimaFactura = 100000;
                    return ultimaFactura;

                }
                 if(lista.Count < 1 && tipo == 1)
                {
                    ultimaFactura = 900000;
                    return ultimaFactura;
                }
                
                ultimaFactura = lista[0].IdFactura;
                return ultimaFactura;
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
