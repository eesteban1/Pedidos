using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Enity
{
    public class MercadoDAO
    {
        SqlConnection con = null;
        ventas2Entities db = new ventas2Entities();
        private SqlCommand comando;
        private SqlDataReader reader;

        public List<v_Mer> Listar()
        {
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            List<v_Mer> ListarMercado = new List<v_Mer>();
            string find = "select*from v_Mer order by IdMercado";
            try
            {
                comando = new SqlCommand(find, con);
                con.Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    v_Mer objMercados = new v_Mer();
                    objMercados.IdMercado= Convert.ToInt32(reader[0].ToString());
                    objMercados.DescripCorta = reader[1].ToString();
                    objMercados.NombreCorto = reader[2].ToString();
                    objMercados.NombreLargo = reader[3].ToString();
                    objMercados.Direccion = reader[4].ToString();
                    objMercados.ZM = reader[5].ToString();
                    objMercados.M = reader[6].ToString();
                    ListarMercado.Add(objMercados);
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

            return ListarMercado;
        }

        public mercados BuscarMercado(int id)
        {
            mercados mrca = new mercados();
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            bool hayRegistros;
            string find = "select*from mercados where IdMercado='" + id + "'";
            try
            {
                comando = new SqlCommand(find, con);
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();
                hayRegistros = reader.Read();
                mrca.IdMercado = Convert.ToInt32(reader[0].ToString());
                mrca.IdZona = Convert.ToInt32(reader[1].ToString());
                mrca.NombreCorto = reader[2].ToString();
                mrca.NombreLargo = reader[3].ToString();
                mrca.Direccion = reader[4].ToString();
                mrca.ubigeo = reader[5].ToString();
                mrca.Observ = reader[6].ToString();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return mrca;
        }

        public void update(mercados mer)
        {
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            try
            {
                comando = new SqlCommand("usp_MercadoUpdate", con);
                comando.Parameters.AddWithValue("@IdMercado", mer.IdMercado);
                comando.Parameters.AddWithValue("@IdZona", mer.IdZona);
                comando.Parameters.AddWithValue("@NombreCorto", mer.NombreCorto);
                comando.Parameters.AddWithValue("@NombreLargo", mer.NombreLargo);
                comando.Parameters.AddWithValue("@Observ", mer.Observ);
                comando.Parameters.AddWithValue("@ubigeo", mer.ubigeo);
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

        public void Create(mercados mer)
        {
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            try
            {
                comando = new SqlCommand("usp_MercadoInsert", con);
                comando.Parameters.AddWithValue("@NombreCorto",mer.NombreCorto);
                comando.Parameters.AddWithValue("@IdZona", mer.IdZona);
                comando.Parameters.AddWithValue("@NombreLargo", mer.NombreLargo);
                comando.Parameters.AddWithValue("@Direccion", mer.Direccion);
                comando.Parameters.AddWithValue("@ubigeo", mer.ubigeo);
                comando.Parameters.AddWithValue("@Observ", mer.Observ);
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

        public void Eliminar(int idmer)
        {
            string delete = "delete from mercados where IdMercado='" + idmer + "'";
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

        public List<v_ListarMercado> ListarMercados()
        {
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            string findAll = "select*from v_ListarMercado ORDER BY Codigo asc";
            try
            {
                comando = new SqlCommand(findAll, con);
                con.Open();
                reader = comando.ExecuteReader();
                List<v_ListarMercado> mer = new List<v_ListarMercado>();
                while (reader.Read())
                {
                    v_ListarMercado merca = new v_ListarMercado();
                    merca.IdMercado = Convert.ToInt32(reader[0].ToString());
                    merca.Codigo = reader[1].ToString();
                    merca.NombreLargo = reader[2].ToString();
                    merca.Direccion = reader[3].ToString();
                    merca.Ubigeo = reader[4].ToString();
                    mer.Add(merca);
                }
                return mer;
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

        public List<v_MercadoxZona> MercadoxZona(string idzona)
        {
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            List<v_MercadoxZona> ListarMercado = new List<v_MercadoxZona>();
            string find = "select*from v_MercadoxZona where IdZona ='"+ idzona+"'";
            try
            {
                comando = new SqlCommand(find, con);
                con.Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    v_MercadoxZona objMercados = new v_MercadoxZona();
                    objMercados.IdMercado = Convert.ToInt32(reader[1].ToString());
                    objMercados.NombreLargo = reader[2].ToString();
                    ListarMercado.Add(objMercados);
                }
                return ListarMercado;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
