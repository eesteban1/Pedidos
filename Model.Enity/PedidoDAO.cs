using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Enity
{
    public class PedidoDAO
    {
        SqlConnection con = null;
        ventas2Entities db = new ventas2Entities();
        private SqlCommand comando;
        private SqlDataReader reader;

        public List<v_ListarPedidoFecha> ListarPedidosVendedor(int id)
        {
            List<v_ListarPedidoFecha> listaClientes = new List<v_ListarPedidoFecha>();
            string findAll = "select* from v_ListarPedidoFecha where fechaCheque=Convert(DATE,Getdate()) and Id_Vendedor='"+ id+"'order by Id_Encab Desc";
            try
            {
                string cnx = db.Database.Connection.ConnectionString;
                con = new SqlConnection(cnx);
                comando = new SqlCommand(findAll, con);
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    v_ListarPedidoFecha objCliente = new v_ListarPedidoFecha();
                    objCliente.Id_Encab = Convert.ToInt32(reader[0].ToString());
                    objCliente.CodNom = reader[2].ToString();
                    objCliente.fechaCheque = Convert.ToDateTime(reader[1]).ToString("dd-MM-yyyy");
                    objCliente.Total_Venta = Convert.ToDecimal(reader[3].ToString());
                    objCliente.Desc_Large = reader[4].ToString();
                    listaClientes.Add(objCliente);

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
            return listaClientes;
        }

        public List<v_ListarPedidoFecha> ListarPedidosAdmin()
        {
            List<v_ListarPedidoFecha> listaClientes = new List<v_ListarPedidoFecha>();
            string findAll = "select* from v_ListarPedidoFecha where fechaCheque=Convert(DATE,Getdate()) order by Id_Encab Desc";
            try
            {
                string cnx = db.Database.Connection.ConnectionString;
                con = new SqlConnection(cnx);
                comando = new SqlCommand(findAll, con);
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    v_ListarPedidoFecha objCliente = new v_ListarPedidoFecha();
                    objCliente.Id_Encab = Convert.ToInt32(reader[0].ToString());
                    objCliente.CodNom = reader[2].ToString();
                    objCliente.fechaCheque = Convert.ToDateTime(reader[1]).ToString("dd-MM-yyyy");
                    objCliente.Total_Venta = Convert.ToDecimal(reader[3].ToString());
                    objCliente.Desc_Large = reader[4].ToString();
                    listaClientes.Add(objCliente);

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
            return listaClientes;
        }

        public DataSet BuscarPedido(int id)
        {
            string cnx = db.Database.Connection.ConnectionString;
            using (SqlConnection cn = new SqlConnection(cnx))
            {
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand("usp_BuscarPedido", cn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                    return ds;
                }
            }
        }

        public List<v_ListarPedidoFecha> ListarPedidosFecha(string fi, string ff)
        {
            List<v_ListarPedidoFecha> listaClientes = new List<v_ListarPedidoFecha>();
           //string findAll = "select* from v_AcEn where fechaCheque between '"+ fi +" and "+ ff + "'";
            try
            {
                string cnx = db.Database.Connection.ConnectionString;
                con = new SqlConnection(cnx);
                comando = new SqlCommand("usp_ListarPedidosFecha", con);
                comando.Parameters.AddWithValue("@fi", fi);
                comando.Parameters.AddWithValue("@ff", ff);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    v_ListarPedidoFecha objCliente = new v_ListarPedidoFecha();
                    objCliente.Id_Encab = Convert.ToInt32(reader[0].ToString());
                    objCliente.CodNom = reader[2].ToString();
                    objCliente.fechaCheque = reader[1].ToString();
                    objCliente.Total_Venta = Convert.ToDecimal(reader[3].ToString());
                    objCliente.Desc_Large = reader[4].ToString();
                    listaClientes.Add(objCliente);

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
            return listaClientes;
        }

        public void Eliminar(int id)
        {
            try
            {
                string cnx = db.Database.Connection.ConnectionString;
                con = new SqlConnection(cnx);
                comando = new SqlCommand("usp_DeletePedido", con);
                comando.Parameters.AddWithValue("@Id_Encab", id);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                comando.ExecuteReader();
                con.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public void InsertarDetalles(Detalles detalles, Int64 id)
        {
            try
            {
                string cnx = db.Database.Connection.ConnectionString;
                con = new SqlConnection(cnx);
                comando = new SqlCommand("usp_DetalleInsert", con);
                comando.Parameters.AddWithValue("@Id_Encab", id);
                comando.Parameters.AddWithValue("@Id_Prod", detalles.Id_prod);
                comando.Parameters.AddWithValue("@Paquetes", detalles.Paquetes);
                comando.Parameters.AddWithValue("@CantidadKilos", detalles.CantidadKilos);
                comando.Parameters.AddWithValue("@PrecioUnit", detalles.PrecioUnit);
                comando.Parameters.AddWithValue("@SubTotal", detalles.SubTotal);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                comando.ExecuteReader();
                con.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Int64 InsertarCabecera(Encabezado en)
        {
            try
            {
                Int64 id = 0;
                string cnx = db.Database.Connection.ConnectionString;
                con = new SqlConnection(cnx);
                comando = new SqlCommand("usp_EncabezdoInsert", con);
                comando.Parameters.AddWithValue("@Id_cliente", en.Id_cliente);
                comando.Parameters.AddWithValue("@fechaCheque", en.fechaCheque);
                comando.Parameters.AddWithValue("@Id_Vendedor", en.Id_Vendedor);
                comando.Parameters.AddWithValue("@Total_Venta", en.Total_Venta);
                comando.Parameters.AddWithValue("@Id_Moneda", en.Id_Moneda);
                comando.Parameters.AddWithValue("@Id_FormaPago", en.Id_FormaPago);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                id = Convert.ToInt64(comando.ExecuteScalar().ToString());
                //reader = comando.ExecuteReader();
                
                return id;
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

        public void ModificarCabecera(Encabezado en)
        {
            try
            {
                string cnx = db.Database.Connection.ConnectionString;
                con = new SqlConnection(cnx);
                comando = new SqlCommand("usp_EncabezadoUpdate", con);
                comando.Parameters.AddWithValue("@Id_cliente", en.Id_cliente);
                comando.Parameters.AddWithValue("@fechaCheque", en.fechaCheque);
                comando.Parameters.AddWithValue("@Id_Vendedor", en.Id_Vendedor);
                comando.Parameters.AddWithValue("@Total_Venta", en.Total_Venta);
                comando.Parameters.AddWithValue("@Id_Moneda", en.Id_Moneda);
                comando.Parameters.AddWithValue("@Id_Encab", en.Id_Encab);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                reader = comando.ExecuteReader();
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

        public void EliminarDetalle(int id)
        {
            try
            {
                string cnx = db.Database.Connection.ConnectionString;
                con = new SqlConnection(cnx);
                string cmd = "delete from Detalles where Id_Encab='"+id+"'";
                comando = new SqlCommand(cmd, con);
                con.Open();
                reader = comando.ExecuteReader();
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
    }
}
