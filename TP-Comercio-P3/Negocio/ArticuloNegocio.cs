using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Linq.Expressions;
using Dominio;
using System.Diagnostics.Contracts;

namespace Negocio
{
    public class ArticuloNegocio
    {   
        public decimal precio;
        public decimal porcentaje;

        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT A.Codigo, A.Nombre Telefono, A.Descripcion,A.Precio,A.ImagenUrl, A.IdMarca, A.IdCategoria, A.Id, M.Descripcion Modelo , C.Descripcion Tipo, A.Proveedor , P.RazonSocial , A.Stock, A.Porcentaje FROM ARTICULOS A, MARCAS M , CATEGORIAS C, PROVEEDORES P WHERE A.IdMarca = M.id AND A.IdCategoria = C.Id AND A.Proveedor = P.Id AND A.estado=1");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Telefono"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    precio = (decimal)datos.Lector["Precio"];
                    precio = decimal.Round(precio, 2);
                    aux.Precio = precio;

                    aux.Stock = (int)datos.Lector["Stock"];

                    porcentaje = (decimal)datos.Lector["Porcentaje"];
                    porcentaje = decimal.Round(porcentaje, 2);
                    aux.Porcentaje = porcentaje;
             
                    
                    if (!(datos.Lector["ImagenURL"] is DBNull))
                        aux.ImagenUrl = (string)datos.Lector["ImagenURL"];

                    aux.marca = new Marca();
                    aux.marca.Id = (int)datos.Lector["IdMarca"];
                    aux.marca.DescripcionMarca = (string)datos.Lector["Modelo"];
                    aux.categoria = new Categoria();
                    aux.categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.categoria.Descripcion = (string)datos.Lector["Tipo"];
                    aux.proveedor = new Proveedor();
                    aux.proveedor.Id = (int)datos.Lector["Proveedor"];
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
        public List<Articulo> listaParaEditar(int Id)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT A.Codigo, A.Nombre Telefono, A.Descripcion, A.Precio, A.ImagenUrl, A.IdMarca, A.IdCategoria, A.Id, M.Descripcion Modelo , C.Descripcion Tipo, A.Proveedor, A.Stock, A.Porcentaje FROM ARTICULOS A, MARCAS M , CATEGORIAS C, PROVEEDORES P WHERE A.IdMarca = M.id AND A.IdCategoria = C.Id AND A.Proveedor = P.Id AND A.Id=" + Id);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Telefono"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    
                    precio = (decimal)datos.Lector["Precio"];
                    precio = decimal.Round(precio, 2);
                    aux.Precio = precio;

                    porcentaje = (decimal)datos.Lector["Porcentaje"];
                    porcentaje = decimal.Round(porcentaje, 2);
                    aux.Porcentaje = porcentaje;

                    if (!(datos.Lector["ImagenURL"] is DBNull))
                        aux.ImagenUrl = (string)datos.Lector["ImagenURL"];

                    aux.marca = new Marca();
                    aux.marca.Id = (int)datos.Lector["IdMarca"];
                    aux.marca.DescripcionMarca = (string)datos.Lector["Modelo"];
                    aux.categoria = new Categoria();
                    aux.categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.categoria.Descripcion = (string)datos.Lector["Tipo"];

                    aux.proveedor = new Proveedor();
                    aux.proveedor.Id = (int)datos.Lector["Proveedor"];

                    aux.Stock = (int)datos.Lector["Stock"];
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
        public List<Articulo> listarConSP()
        {

            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("storedListar");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Telefono"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    
                    precio = (decimal)datos.Lector["Precio"];
                    precio = decimal.Round(precio, 2);
                    aux.Precio = precio;

                    if (!(datos.Lector["ImagenURL"] is DBNull))
                        aux.ImagenUrl = (string)datos.Lector["ImagenURL"];

                    aux.marca = new Marca();
                    aux.marca.Id = (int)datos.Lector["IdMarca"];
                    aux.marca.DescripcionMarca = (string)datos.Lector["Modelo"];
                    aux.categoria = new Categoria();
                    aux.categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.categoria.Descripcion = (string)datos.Lector["Tipo"];

                    aux.Stock = (int)datos.Lector["Stock"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void agregar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string valores = "values('" + articulo.Codigo + "','" + articulo.Nombre + "','" + articulo.Descripcion + "'," + articulo.Precio + ",'" + articulo.ImagenUrl + " ', " + articulo.marca.Id + ", " + articulo.categoria.Id + ", " + articulo.Stock + ",1, @proveedor, @porcentaje )";
             //   string valores = "values('" + articulo.Codigo + "','" + articulo.Nombre + "','" + articulo.Descripcion + "'," + articulo.Precio + ",'" + articulo.ImagenUrl + " ', " + articulo.marca.Id + ", " + articulo.categoria.Id + ", " + articulo.Stock + ",1, 1003)";
                datos.setearConsulta("insert into ARTICULOS (Codigo,Nombre,Descripcion,Precio,ImagenURL, IdMarca, IdCategoria, Stock, Estado, Proveedor, Porcentaje) " + valores);
                datos.setearParametro("@proveedor", articulo.proveedor.Id);
                datos.setearParametro("@porcentaje", articulo.Porcentaje);
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
        public void modificar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @desc, Precio = @precio, ImagenURL = @img, IdMarca = @idMarca, IdCategoria = @idCategoria, Stock = @stock, Proveedor = @proveedor, Porcentaje = @porcentaje Where Id = @id");
                datos.setearParametro("@codigo", articulo.Codigo);
                datos.setearParametro("@nombre", articulo.Nombre);
                datos.setearParametro("@desc", articulo.Descripcion);
                datos.setearParametro("@precio", articulo.Precio);
                datos.setearParametro("@img", articulo.ImagenUrl);
                datos.setearParametro("@idMarca", articulo.marca.Id);
                datos.setearParametro("@idCategoria", articulo.categoria.Id);
                datos.setearParametro("@id", articulo.Id);
                datos.setearParametro("@stock", articulo.Stock);
                datos.setearParametro("@proveedor", articulo.proveedor.Id);
                datos.setearParametro("@porcentaje", articulo.Porcentaje);

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

        public void modificarPorCompra(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {              
                datos.setearConsulta("update ARTICULOS set Stock = @stock, Proveedor = @proveedor, Precio = @precio, Porcentaje = @porcentaje Where Id = @id");
                datos.setearParametro("@stock", articulo.Stock);
                datos.setearParametro("@proveedor", articulo.proveedor.Id);
                datos.setearParametro("@precio", articulo.Precio);
                datos.setearParametro("@porcentaje", articulo.Porcentaje);
                datos.setearParametro("@id", articulo.Id);
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
                datos.setearConsulta("Update ARTICULOS set estado=0 where id= @id");
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
        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT A.Codigo, A.Nombre Telefono, A.Descripcion,A.Precio,A.ImagenUrl, A.IdMarca, A.IdCategoria, A.Id, M.Descripcion Modelo , C.Descripcion, A.Stock Tipo FROM ARTICULOS A, MARCAS M , CATEGORIAS C WHERE A.IdMarca = M.id AND A.IdCategoria = C.Id And ";
                switch (campo)
                {
                    case "Precio":
                        switch (criterio)
                        {
                            case "Mayor a":
                                consulta += "A.Precio > " + filtro;
                                break;
                            case "Menor a":
                                consulta += "A.Precio < " + filtro;
                                break;
                            default:
                                consulta += "A.Precio = " + filtro;
                                break;
                        }
                        break;

                    case "Nombre":
                        switch (criterio)
                        {
                            
                            case "Comienza con":
                                consulta += "A.Nombre like '" + filtro + "%' ";
                                break;
                            case "Termina con":
                                consulta += "A.Nombre like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "A.Nombre like '%" + filtro + "%' ";
                                break;
                        }
                        break;
                    case "Descripcion":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "A.Descripcion like '" + filtro + "%' ";
                                break; 
                            case "Termina con":
                                consulta += "A.Descripcion like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "A.Descripcion like '%" + filtro + "%' ";
                                break;
                        }
                        break;
                    case "Codigo":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "A.Codigo like '" + filtro + "%' ";
                                break;
                            case "Termina con":
                                consulta += "A.Codigo like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "A.Codigo like '%" + filtro + "%' ";
                                break;
                        }
                        break;

                    default:
                        break;
                }
               
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Telefono"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    
                    precio = (decimal)datos.Lector["Precio"];
                    precio = decimal.Round(precio, 2);
                    aux.Precio = precio;
                    
                    // agrego esta validacion solo aca porque me parece que deberia ser el unico campo de tendria que aceptar NULL
                    if (!(datos.Lector["ImagenURL"] is DBNull))
                        aux.ImagenUrl = (string)datos.Lector["ImagenURL"];

                    aux.marca = new Marca();
                    aux.marca.Id = (int)datos.Lector["IdMarca"];
                    aux.marca.DescripcionMarca = (string)datos.Lector["Modelo"];
                    aux.categoria = new Categoria();
                    aux.categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.categoria.Descripcion = (string)datos.Lector["Tipo"];
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}


