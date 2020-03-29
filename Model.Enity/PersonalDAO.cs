using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Enity
{
    public class PersonalDAO
    {
        ventas2Entities db = new ventas2Entities();

        public bool Ingreso(Accesos ac, out string id, out string nombre,out string idcargo, out string cargo)
        {
            SqlConnection con = null;
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            bool hay;
            string Ingresar = "select* from v_Acc where Usuario='" + ac.Usuario + "' and " + " Clave='" + ac.Clave + "'";
            try
            {
                SqlCommand comando = new SqlCommand(Ingresar,con);
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();
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

        public object ListarVendedor()
        {
            SqlConnection con = null;
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            string listar = "select* from Personal ";
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
                    per.Nombres = reader[3].ToString();
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
