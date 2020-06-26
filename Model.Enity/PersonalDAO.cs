using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Model.Enity
{
    public class PersonalDAO
    {

        ventas2Entities db = new ventas2Entities();
        SqlConnection con = null;
        private SqlCommand comando;
        private SqlDataReader reader;

        public bool Ingreso(Accesos ac, out string id, out string nombre,out string idcargo, out string cargo)
        {
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            bool hay;
            string Ingresar = "select* from v_Acc where Usuario='" + ac.Usuario + "' and " + " Clave='" + ac.Clave + "'";
            try
            {
                comando = new SqlCommand(Ingresar,con);
                con.Open();
                reader = comando.ExecuteReader();
                hay = reader.Read();
                if(hay)
                {
                    id = reader[6].ToString();
                    nombre = reader[4].ToString();
                    idcargo = reader[3].ToString();
                    cargo = reader[5].ToString();
                    return hay;
                }
                else
                {
                    id = "";
                    nombre = "";
                    idcargo = "";
                    cargo = "";
                    return hay;
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
        }

        public object ListarPersonal()
        {
            SqlConnection con = null;
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            string listar = "select* from v_Per";
            List<v_Per> listper = new List<v_Per>();
            try
            {
                SqlCommand comando = new SqlCommand(listar, con);
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    v_Per per = new v_Per();
                    per.Id_personal = Convert.ToInt32(reader[0].ToString());
                    per.Apellidos = reader[1].ToString();
                    //per.ApellidoMat = reader[2].ToString();
                    per.Nombres = reader[2].ToString();
                    per.Domicilio = reader[4].ToString();
                    per.Telefono = reader[5].ToString();
                    per.Nombre = reader[9].ToString();
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

        public Personal BuscarPersonal(int id)
        {
            Personal objper = new Personal();
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            bool hayRegistros;
            string find = "select*from Personal where Id_personal='" + id + "'";
            try
            {
                comando = new SqlCommand(find, con);
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();
                hayRegistros = reader.Read();
                if(hayRegistros)
                {
                    objper.Id_personal = Convert.ToInt32(reader[0]);
                    objper.ApellidoMat = reader[1].ToString();
                    objper.ApellidoPat = reader[2].ToString();
                    objper.Nombres = reader[3].ToString();
                    objper.NroDNI = reader[4].ToString() ;
                    objper.Domicilio = reader[5].ToString();
                    objper.Ubigeo = reader[6].ToString();
                    objper.Telefono = reader[7].ToString();
                    objper.fechaNacimiento = Convert.ToDateTime(reader[8].ToString());
                    objper.Sexo = reader[9].ToString();
                    objper.fechaIngreso = Convert.ToDateTime(reader[10].ToString());
                    objper.CodCargo = reader[11].ToString();
                    objper.EstadoCivil = reader[12].ToString();
                    objper.Nrolpss = reader[13].ToString();
                    objper.NroHijos = reader[14].ToString();
                    objper.Observ = reader[15].ToString();
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
            return objper;
        }

        public void Update(Personal per)
        {
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            try
            {
                comando = new SqlCommand("usp_PersonalUpdate", con);
                comando.Parameters.AddWithValue("@ApellidoPat", per.ApellidoPat);
                comando.Parameters.AddWithValue("@ApellidoMat", per.ApellidoMat);
                comando.Parameters.AddWithValue("@Nombres", per.Nombres);
                comando.Parameters.AddWithValue("@NroDNI", per.NroDNI);
                comando.Parameters.AddWithValue("@Domicilio", per.Domicilio);
                comando.Parameters.AddWithValue("@Ubigeo", per.Ubigeo);
                comando.Parameters.AddWithValue("@Telefono", per.Telefono);
                comando.Parameters.AddWithValue("@fechaNacimiento", per.fechaNacimiento);
                comando.Parameters.AddWithValue("@Sexo", per.Sexo);
                comando.Parameters.AddWithValue("@fechaIngreso", per.fechaIngreso);
                comando.Parameters.AddWithValue("@CodCargo", per.CodCargo);
                comando.Parameters.AddWithValue("@EstadoCivil", per.EstadoCivil);
                comando.Parameters.AddWithValue("@Nrolpss", per.Nrolpss);
                comando.Parameters.AddWithValue("@NroHijos", per.NroHijos);
                comando.Parameters.AddWithValue("@Observ", per.Observ);
                comando.Parameters.AddWithValue("@Id_personal", per.Id_personal);
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

        public bool ExistePersonal(string text)
        {
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            string proce = "select * from Personal where NroDNI='" + text + "'";
            try
            {
                comando = new SqlCommand(proce, con);
                con.Open();
                reader = comando.ExecuteReader();
                return reader.Read();
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

        public string Eliminar(int idpersonal,out string error)
        {
            SqlConnection con = null;
            string delete = "delete from Personal where Id_personal='" + idpersonal + "'";
            string mensaje="";
            try
            {
                string cnx = db.Database.Connection.ConnectionString;
                con = new SqlConnection(cnx);
                SqlCommand comando = new SqlCommand(delete,con);
                con.Open();
                comando.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                 mensaje = ex.ToString();
            }
            finally
            {
                con.Close();
            }
            error = mensaje;
            return mensaje;
        }

        public void Create(Personal per)
        {
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            try
            {
                comando = new SqlCommand("usp_PersonalInsert", con);
                comando.Parameters.AddWithValue("@ApellidoPat", per.ApellidoPat);
                comando.Parameters.AddWithValue("@ApellidoMat", per.ApellidoMat);
                comando.Parameters.AddWithValue("@Nombres", per.Nombres);
                comando.Parameters.AddWithValue("@NroDNI", per.NroDNI);
                comando.Parameters.AddWithValue("@Domicilio", per.Domicilio);
                comando.Parameters.AddWithValue("@Ubigeo", per.Ubigeo);
                comando.Parameters.AddWithValue("@Telefono", per.Telefono);
                comando.Parameters.AddWithValue("@fechaNacimiento", per.fechaNacimiento);
                comando.Parameters.AddWithValue("@Sexo", per.Sexo);
                comando.Parameters.AddWithValue("@fechaIngreso", per.fechaIngreso);
                comando.Parameters.AddWithValue("@CodCargo", per.CodCargo);
                comando.Parameters.AddWithValue("@EstadoCivil", per.EstadoCivil);
                comando.Parameters.AddWithValue("@Nrolpss", per.Nrolpss);
                comando.Parameters.AddWithValue("@NroHijos", per.NroHijos);
                comando.Parameters.AddWithValue("@Observ", per.Observ);
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

        public object ListarVendedor()
        {
            SqlConnection con = null;
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            string listar = "select* from Personal where CodCargo=1 ";
            List<Personal> listper = new List<Personal>();
            try
            {
                SqlCommand comando = new SqlCommand(listar, con);
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {

                    Personal per = new Personal();
                    per.Id_personal = Convert.ToInt32(reader[0].ToString());
                    per.ApellidoPat = reader[1].ToString();
                    per.ApellidoMat = reader[2].ToString();
                    per.Nombres = reader[3].ToString();
                    per.Domicilio = reader[5].ToString();
                    per.Telefono = reader[7].ToString();
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

    }
}
