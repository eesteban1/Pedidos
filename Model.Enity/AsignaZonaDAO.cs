using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Enity
{
    public class AsignaZonaDAO
    {
        SqlConnection con = null;
        ventas2Entities db = new ventas2Entities();
        private SqlCommand comando;
        private SqlDataReader reader;

        public string BuscarZonaAsignada(string id,out string idzona)
        {
            try
            {
                string idzon = "";
                string nombre = "";
                string cnx = db.Database.Connection.ConnectionString;
                con = new SqlConnection(cnx);
                comando = new SqlCommand("usp_AsignaZona", con);
                comando.Parameters.AddWithValue("@Id",id);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                reader = comando.ExecuteReader();
                if (reader.Read())
                {
                     nombre = reader[1].ToString();
                     idzon = reader[2].ToString();
                }

                idzona = idzon;
                return nombre;
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

        public bool BuscarExistenciaZonaXDia(string id,string dia)
        {
            bool exis = false;
            try
            {
                string cnx = db.Database.Connection.ConnectionString;
                string findAll = "select*from v_AsignaZona where Id_personal ='"+id+"'and Id_Dia='"+dia+"'";
                con = new SqlConnection(cnx);
                comando = new SqlCommand(findAll, con);
                con.Open();
                reader = comando.ExecuteReader();
                exis = reader.Read();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return exis;
        }

        public object ListarDia()
        {
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            string findAll = "select*from Dia order by Orden asc";
            try
            {
                comando = new SqlCommand(findAll, con);
                con.Open();
                reader = comando.ExecuteReader();
                List<Dia> asig = new List<Dia>();
                while (reader.Read())
                {
                    Dia asigna = new Dia();
                    asigna.Id_Dia = reader[0].ToString();
                    asigna.Descripcion = reader[1].ToString();
                    asig.Add(asigna);

                }
                return asig;
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

        public void Grabar(AsignaZona asi)
        {
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            try
            {
                comando = new SqlCommand("usp_AsignaZonaInsert", con);
                comando.Parameters.AddWithValue("@IdZona", asi.IdZona);
                comando.Parameters.AddWithValue("@Id_personal", asi.Id_personal);
                comando.Parameters.AddWithValue("@usuario", asi.usuario);
                comando.Parameters.AddWithValue("@Id_Dia", asi.Id_Dia);
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

        public void Eliminar(int idasign)
        {
            string delete = "delete from AsignaZona where Id_asigna='"+idasign+"'";
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

        public List<v_AsignaZona> ListarZonaAsignada()
        {
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            string findAll = "select*from v_AsignaZona";
            try
            {
                comando = new SqlCommand(findAll, con);
                con.Open();
                reader = comando.ExecuteReader();
                List<v_AsignaZona> asig = new List<v_AsignaZona>();
                while (reader.Read())
                {
                    v_AsignaZona asigna = new v_AsignaZona();
                    asigna.Id_personal = Convert.ToInt32(reader[0].ToString());
                    asigna.NombreZona = reader[1].ToString();
                    asigna.IdZona = Convert.ToInt32(reader[2].ToString());
                    asigna.Nombres = reader[3].ToString() + " " + reader[7].ToString() + " " + reader[6].ToString();
                    asigna.Id_asigna = Convert.ToInt32(reader[4].ToString());
                    asigna.DescripCorta = reader[5].ToString();
                    asig.Add(asigna);

                }
                return asig;
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
