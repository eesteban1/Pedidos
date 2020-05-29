using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Enity
{
    public class ZonasDAO
    {
        ventas2Entities db = new ventas2Entities();
        SqlConnection con = null;
        private SqlCommand comando;
        private SqlDataReader reader;
        public object Listar()
        {
           
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            string listar = "select * from Zonas order by DescripCorta asc";
            List<zonas> listper = new List<zonas>();
            try
            {
                SqlCommand comando = new SqlCommand(listar, con);
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {

                    zonas per = new zonas();
                    per.IdZona = Convert.ToInt32(reader[0].ToString());
                    per.DescripLarga = reader[1].ToString() +"-"+ reader[2].ToString();
                    listper.Add(per);
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
            return listper;
        }

        public bool ExisteZona(string text)
        {
            bool existe = true;
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            string proce = "select * from zonas where DescripCorta='" + text + "'";
            try
            {
                comando = new SqlCommand(proce, con);
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();
                existe = reader.Read();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return existe;
        }

        public void Create(zonas zon)
        {
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            try
            {
                comando = new SqlCommand("usp_ZonaInsert", con);
                comando.Parameters.AddWithValue("@DescripCorta", zon.DescripCorta);
                comando.Parameters.AddWithValue("@DescripLarga", zon.DescripLarga);
                comando.Parameters.AddWithValue("@Observacion", zon.Observacion);
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

        public void update(zonas zon)
        {
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            try
            {
                comando = new SqlCommand("usp_ZonaUpdate", con);
                comando.Parameters.AddWithValue("@IdZona", zon.IdZona);
                comando.Parameters.AddWithValue("@DescripCorta", zon.DescripCorta);
                comando.Parameters.AddWithValue("@DescripLarga", zon.DescripLarga);
                comando.Parameters.AddWithValue("@Observacion", zon.Observacion);
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

        public zonas BuscarZona(int id)
        {
            zonas zon = new zonas();
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            string find = "select*from zonas where IdZona='" + id + "'";
            try
            {
                comando = new SqlCommand(find, con);
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();
                if(reader.Read())
                {
                    zon.IdZona = Convert.ToInt32(reader[0].ToString());
                    zon.DescripCorta = reader[1].ToString();
                    zon.DescripLarga = reader[2].ToString();
                    zon.Observacion = reader[3].ToString();
                }
                return zon;
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

        public List<v_ListarZonas> ListarmanteZonas()
        {
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            string findAll = "select*from v_ListarZonas order by DescripCorta asc";
            try
            {
                comando = new SqlCommand(findAll, con);
                con.Open();
                reader = comando.ExecuteReader();
                List<v_ListarZonas> zon = new List<v_ListarZonas>();
                while(reader.Read())
                {
                    v_ListarZonas zona = new v_ListarZonas();
                    zona.IdZona = Convert.ToInt32(reader[0].ToString());
                    zona.DescripCorta = reader[1].ToString();
                    zona.DescripLarga = reader[2].ToString();
                    zona.Observacion = reader[3].ToString();
                    zon.Add(zona);
                }
                return zon;
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

        public void Eliminar(int idzona)
        {
           
            string eliminar = "delete from zonas where IdZona='"+ idzona +"'";
            try
            {
                string cnx = db.Database.Connection.ConnectionString;
                con = new SqlConnection(cnx);
                comando = new SqlCommand(eliminar, con);
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
    }
}
