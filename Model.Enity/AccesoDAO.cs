using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Enity
{
    public class AccesoDAO
    {
        SqlConnection con = null;
        ventas2Entities db = new ventas2Entities();
        private SqlCommand comando;
        private SqlDataReader reader;
        public object ListarAcceso()
        {
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            string findAll = "select*from v_Acc";
            try
            {
                comando = new SqlCommand(findAll, con);
                con.Open();
                reader = comando.ExecuteReader();
                List<v_Acc> cli = new List<v_Acc> ();
                while (reader.Read())
                {
                    v_Acc objClientes = new v_Acc();
                    objClientes.Id_Acceso = Convert.ToInt32(reader[0].ToString());
                    objClientes.Usuario = reader[1].ToString();
                    objClientes.Nombrescom = reader[4].ToString();
                    objClientes.NombreCargo = reader[5].ToString();
                    cli.Add(objClientes);
                }
                return cli;
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

        public bool ExistePersonal(string selectedValue)
        {
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            string proce = "select * from Accesos where Id_Personal='" + selectedValue + "'";
            try
            {
                comando = new SqlCommand(proce, con);
                con.Open();
                reader = comando.ExecuteReader();
                return reader.Read();
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

        public Accesos BuscarAcceso(int codigo)
        {
            Accesos objacc = new Accesos();
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            bool hayRegistros;
            string find = "select*from Accesos where Id_Acceso='" + codigo + "'";
            try
            {
                comando = new SqlCommand(find, con);
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();
                hayRegistros = reader.Read();
                if(hayRegistros)
                {
                    objacc.Id_Personal = Convert.ToInt32(reader[1].ToString());
                    objacc.Usuario = reader[2].ToString();
                    objacc.Clave = reader[3].ToString();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return objacc;
        }

        public void Create(Accesos acc)
        {
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            try
            {
                comando = new SqlCommand("usp_AccesoInsert", con);
                comando.Parameters.AddWithValue("@Id_Personal", acc.Id_Personal);
                comando.Parameters.AddWithValue("@Usuario", acc.Usuario);
                comando.Parameters.AddWithValue("@Clave", acc.Clave);
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

        public bool ExisteUsario(string text)
        {
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            string proce = "select * from Accesos where Usuario='" + text + "'";
            try
            {
                comando = new SqlCommand(proce, con);
                con.Open();
                reader = comando.ExecuteReader();
                return reader.Read();
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

        public void Eliminar(int idacceso)
        {
            string delete = "delete from Accesos where Id_Acceso='" + idacceso + "'";
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

        public void Update(Accesos acc)
        {
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            try
            {
                comando = new SqlCommand("usp_AccesoUpdate", con);
                comando.Parameters.AddWithValue("@Id_Personal", acc.Id_Personal);
                comando.Parameters.AddWithValue("@Usuario", acc.Usuario);
                comando.Parameters.AddWithValue("@Clave", acc.Clave);
                comando.Parameters.AddWithValue("@Id_Acceso", acc.Id_Acceso);
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
    }
}
