using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Enity
{
    public class ProductoDAO
    {
        SqlConnection con = null;
        ventas2Entities db = new ventas2Entities();
        private SqlCommand comando;
        private SqlDataReader reader;

        public List<v_ListarProductos> ListarProducto()
        {
            List<v_ListarProductos> listaTipoMov = new List<v_ListarProductos>();
            string find = "select*from v_ListarProductos";
            try
            {
                string cnx = db.Database.Connection.ConnectionString;
                con = new SqlConnection(cnx);
                comando = new SqlCommand(find, con);
                con.Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    v_ListarProductos objProdcutos = new v_ListarProductos();
                    objProdcutos.Id_prod = Convert.ToInt32(reader[0].ToString());
                    objProdcutos.Nombre = reader[1].ToString();
                    objProdcutos.descripcion = reader[2].ToString();
                    objProdcutos.PesoKilos = Convert.ToDecimal(reader[3].ToString());
                    objProdcutos.PVentaS = Convert.ToDecimal(reader[4].ToString());
                    objProdcutos.PVentaD = Convert.ToDecimal(reader[5].ToString());
                    listaTipoMov.Add(objProdcutos);
                }

            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                con.Close();
            }

            return listaTipoMov;
        }

        public List<Producto> Listar()
        {
            List<Producto> listapro = new List<Producto>();
            string findAll = "select*from Producto";
            try
            {
                string cnx = db.Database.Connection.ConnectionString;
                con = new SqlConnection(cnx);
                comando = new SqlCommand(findAll, con);
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Producto objpro = new Producto();
                    objpro.Id_prod = Convert.ToInt32(reader[0].ToString());
                    objpro.descripcion = reader[1].ToString();
                    listapro.Add(objpro);

                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }

            return listapro;
        }

        public void CrearProducto(Producto pro)
        {
            try
            {
                string cnx = db.Database.Connection.ConnectionString;
                con = new SqlConnection(cnx);
                comando = new SqlCommand("usp_ProductoInsert", con);
                comando.Parameters.AddWithValue("@descripcion",pro.descripcion);
                comando.Parameters.AddWithValue("@IdAfectoIGV", pro.IdAfectoIGV);
                comando.Parameters.AddWithValue("@IdMedida", pro.IdMedida);
                comando.Parameters.AddWithValue("@PesoKilos", pro.PesoKilos);
                comando.Parameters.AddWithValue("@PComprasS", pro.PComprasS);
                comando.Parameters.AddWithValue("@PCompraD", pro.PCompraD);
                comando.Parameters.AddWithValue("@PVentaS", pro.PVentaS);
                comando.Parameters.AddWithValue("@PventaD", pro.PVentaD);
                comando.Parameters.AddWithValue("@StockMin", pro.StockMin);
                comando.Parameters.AddWithValue("@StockMax", pro.StockMax);
                comando.Parameters.AddWithValue("@StockAct", pro.StockAct);
                comando.Parameters.AddWithValue("@Observacion", pro.Observacion);
                comando.Parameters.AddWithValue("@IdMarca", pro.IdMarca);
                comando.Parameters.AddWithValue("@Id_Familia", pro.Id_Familia);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                comando.ExecuteNonQuery();
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public void Eliminar(int idpro)
        {
            string delete = "delete from Producto where Id_prod='" + idpro + "'";
            try
            {
                string cnx = db.Database.Connection.ConnectionString;
                con = new SqlConnection(cnx);
                comando = new SqlCommand(delete, con);
                con.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public void update(Producto pro)
        {
            //string update = "update Producto set  AfectoIgv='" + objProductos.IdAfectoIGV + "',Descrip='" + objProductos.descripcion + "',Peso='" + objProductos.PesoKilos + "',PCompraS='" + objProductos.PComprasS + "',PCompraD='" + objProductos.PCompraD + "',PVentaS='" + objProductos.PVentaS + "',PVentaD='" + objProductos.PVentaD + "',StockMax='" + objProductos.StockMax + "',StockMin='" + objProductos.StockMin + "',StockAct='" + objProductos.StockAct + "',Id_Marca='" + objProductos.IdMarca + "',Id_Familia='" + objProductos.Id_Familia + "',IdMedida='" + objProductos.IdMedida + "' where Id_prod='" + objProductos.Id_prod + "'";
            try
            {
                string cnx = db.Database.Connection.ConnectionString;
                con = new SqlConnection(cnx);
                comando = new SqlCommand("usp_ProductoUpdate", con);
                comando.Parameters.AddWithValue("@Id_prod", pro.Id_prod);
                comando.Parameters.AddWithValue("@descripcion", pro.descripcion);
                comando.Parameters.AddWithValue("@IdAfectoIGV", pro.IdAfectoIGV);
                comando.Parameters.AddWithValue("@IdMedida", pro.IdMedida);
                comando.Parameters.AddWithValue("@PesoKilos", pro.PesoKilos);
                comando.Parameters.AddWithValue("@PComprasS", pro.PComprasS);
                comando.Parameters.AddWithValue("@PCompraD", pro.PCompraD);
                comando.Parameters.AddWithValue("@PVentaS", pro.PVentaS);
                comando.Parameters.AddWithValue("@PventaD", pro.PVentaD);
                comando.Parameters.AddWithValue("@StockMin", pro.StockMin);
                comando.Parameters.AddWithValue("@StockMax", pro.StockMax);
                comando.Parameters.AddWithValue("@StockAct", pro.StockAct);
                comando.Parameters.AddWithValue("@Observacion", pro.Observacion);
                comando.Parameters.AddWithValue("@IdMarca", pro.IdMarca);
                comando.Parameters.AddWithValue("@Id_Familia", pro.Id_Familia);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public Producto BuscarProducto(int id)
        {
            Producto objProductos = new Producto();
            string find = "select*from Producto where Id_prod='" + id + "'";
            try
            {
                bool hayRegistros;
                string cnx = db.Database.Connection.ConnectionString;
                con = new SqlConnection(cnx);
                
                comando = new SqlCommand(find,con);
                con.Open();
                reader = comando.ExecuteReader();
                hayRegistros = reader.Read();
                if (hayRegistros)
                {
                    objProductos.Id_prod = Convert.ToInt32(reader[0].ToString());
                    objProductos.descripcion = reader[1].ToString();
                    objProductos.IdAfectoIGV = Convert.ToInt32(reader[2].ToString());
                    objProductos.IdMedida = Convert.ToInt32(reader[3].ToString());
                    objProductos.PesoKilos = Convert.ToDecimal(reader[4].ToString());
                    objProductos.PComprasS = Convert.ToDecimal(reader[5].ToString());
                    objProductos.PCompraD = Convert.ToDecimal(reader[6].ToString());
                    objProductos.PVentaS = Convert.ToDecimal(reader[7].ToString());
                    objProductos.PVentaD = Convert.ToDecimal(reader[8].ToString());
                    objProductos.StockMin = Convert.ToInt32(reader[9].ToString());
                    objProductos.StockMax = Convert.ToInt32(reader[10].ToString());
                    objProductos.StockAct = Convert.ToInt32(reader[11].ToString());
                    objProductos.Observacion = reader[12].ToString();
                    objProductos.IdMarca = Convert.ToInt32(reader[13].ToString());
                    objProductos.Id_Familia = Convert.ToInt32(reader[14].ToString());
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                con.Close();
            }

            return objProductos;
        }
    }
}
