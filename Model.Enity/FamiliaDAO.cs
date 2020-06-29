using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Enity
{
    public class FamiliaDAO
    {
        SqlConnection con = null;
        ventas2Entities db = new ventas2Entities();
        private SqlCommand comando;
        private SqlDataReader reader;

        public object Listar()
        {
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);

            List<Familia> listaFamilia = new List<Familia>();
                string findAll = "select*from Familia order by Nombre asc";
                try
                {
                    comando = new SqlCommand(findAll, con);
                    con.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        Familia objFamilia = new Familia();
                        objFamilia.Id_Familia = Convert.ToInt32(reader[0].ToString());
                        objFamilia.Nombre = reader[1].ToString();
                        listaFamilia.Add(objFamilia);

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

                return listaFamilia;

            }

        public void Create(Familia familia)
        {
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            try
            {
                comando = new SqlCommand("usp_FamiliaInsert", con);
                comando.Parameters.AddWithValue("@Nombre", familia.Nombre);
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

        public bool ExisteFamilia(string text)
        {
            bool existe = true;
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            string proce = "select * from Familia where Nombre='" + text + "'";
            try
            {
                comando = new SqlCommand(proce, con);
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();
                existe = reader.Read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return existe;
        }

        public void update(Familia fa)
        {
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            try
            {
                comando = new SqlCommand("usp_FamiliaUpdate", con);
                comando.Parameters.AddWithValue("@Id_Familia", fa.Id_Familia);
                comando.Parameters.AddWithValue("@Nombre", fa.Nombre);
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

        public Familia BuscarFamilia(int id)
        {
            Familia zon = new Familia();
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            string find = "select*from Familia where Id_Familia='" + id + "'";
            try
            {
                comando = new SqlCommand(find, con);
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    zon.Id_Familia = Convert.ToInt32(reader[0].ToString());
                    zon.Nombre = reader[1].ToString();
                }
                return zon;
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

        public void Eliminar(int idfamilia)
        {
            string eliminar = "delete from Familia where Id_Familia='" + idfamilia + "'";
            try
            {
                string cnx = db.Database.Connection.ConnectionString;
                con = new SqlConnection(cnx);
                comando = new SqlCommand(eliminar, con);
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
    }
}
