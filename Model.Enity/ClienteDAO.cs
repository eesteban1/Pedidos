using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Enity
{
    public class ClienteDAO
    {
        SqlConnection con = null;
        ventas2Entities db = new ventas2Entities();
        private SqlCommand comando;
        private SqlDataReader reader;

        public List<v_ListarCliente> listarclientes()
        {
            
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            string findAll = "select*from v_ListarCliente";
            try
            {
                comando = new SqlCommand(findAll,con);
                con.Open();
                reader = comando.ExecuteReader();
                List<v_ListarCliente> cli = new List<v_ListarCliente>();
                while (reader.Read())
                {
                    v_ListarCliente objClientes = new v_ListarCliente();
                    objClientes.Id_cliente = Convert.ToInt32(reader[0].ToString());
                    objClientes.CodNom = reader[1].ToString();
                    objClientes.NombrePropietario = reader[2].ToString();
                    objClientes.Direccion = reader[3].ToString();
                    objClientes.TelefonoComercial = reader[4].ToString();
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

        public bool ExisteCliente(string text)
        {
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            string proce = "select * from Cliente where DNI='"+text+"'";
            try
            {
                comando = new SqlCommand(proce,con);
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

        public object listarclientemerzon(string codigo)
        {
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            List<v_ComboClientes> cliue = new List<v_ComboClientes>();
            try
            {
                comando = new SqlCommand("usp_LlenarComboCliente", con);
                comando.Parameters.AddWithValue("@codigo", codigo);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    v_ComboClientes clie = new v_ComboClientes();
                    clie.Id_cliente = Convert.ToInt32(reader[0].ToString());
                    clie.NombrePropietario = reader[1].ToString();
                    cliue.Add(clie);
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
            return cliue;
        }

        public Cliente Buscarcliente(int id,string numero)
        {
            Cliente objClientes = new Cliente();
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            bool hayRegistros;
            string find = "select*from Cliente where Id_cliente='" + id + "'or NumeroPuesto='" + numero + "'";
            try
            {
                
                comando = new SqlCommand(find, con);
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();
                hayRegistros = reader.Read();
                if (hayRegistros)
                {
                    objClientes.Id_cliente = Convert.ToInt32(reader[0]);
                    objClientes.IdMercado = Convert.ToInt32(reader[1].ToString());
                    objClientes.RazonSocial = reader[2].ToString();
                    objClientes.IdDenominacion = Convert.ToInt32(reader[3].ToString());
                    objClientes.Califica = reader[4].ToString();
                    objClientes.RUC = reader[5].ToString();
                    objClientes.Direccion = reader[6].ToString();
                    objClientes.UbigeoComercial = reader[7].ToString();
                    objClientes.ReferenciaComercial = reader[8].ToString();
                    objClientes.TelefonoComercial = reader[9].ToString();
                    objClientes.NombrePropietario = reader[10].ToString();
                    objClientes.Domicilio = reader[11].ToString();
                    objClientes.UbigeoDomicilio = reader[12].ToString();
                    objClientes.ReferenciaDomicilio = reader[13].ToString();
                    objClientes.DNI = reader[14].ToString();
                    objClientes.TelefonoDomicilio = reader[15].ToString();
                    objClientes.GarantiaCred = Convert.ToInt32(reader[16].ToString());
                    objClientes.CreditoMaximo = Convert.ToInt32(reader[17].ToString());
                    objClientes.Observacion = reader[18].ToString();
                    objClientes.NumeroPuesto = reader[19].ToString();
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
            return objClientes;
        }

        public Cliente Buscarclientecomplemento(int id, string zona, string mercado)
        {
            Cliente clie = new Cliente();
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            return clie;
        }

        public void Eliminar(int idcliente)
        {
            string delete = "delete from Cliente where Id_cliente='" + idcliente + "'";
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

        public void update(Cliente clie)
        {
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            //string update = "update Clientes set  NroDocmto='" + objCLientes.NroDocmto + "',Id_DIdent='" + objCLientes.Id_DIdent + "',Califica='" + objCLientes.Califica + "',NombreRSocial='" + objCLientes.NombreRSocial + "',IdClaseClie='" + objCLientes.IdClaseClie + "',IdMercado='" + objCLientes.IdMercado + "',Direccion='" + objCLientes.Direccion + "',Referencia='" + objCLientes.Referencia + "',Telefono='" + objCLientes.Telefono + "',NumeroPuesto='" + objCLientes.NumeroPuesto + "',Id_Acceso_mod='" + objCLientes.Id_Acceso_mod + "' where IdCliente='" + objCLientes.IdCliente + "'";
            try
            {
                comando = new SqlCommand("usp_ClienteUpdate", con);
                comando.Parameters.AddWithValue("@Id_cliente", clie.Id_cliente);
                comando.Parameters.AddWithValue("@IdMercado", clie.IdMercado);
                comando.Parameters.AddWithValue("@RazonSocial", clie.RazonSocial);
                comando.Parameters.AddWithValue("@IdDenominacion", clie.IdDenominacion);
                comando.Parameters.AddWithValue("@Califica", clie.Califica);
                comando.Parameters.AddWithValue("@RUC", clie.RUC);
                comando.Parameters.AddWithValue("@Direccion", clie.Direccion);
                comando.Parameters.AddWithValue("@UbigeoComercial", clie.UbigeoComercial);
                comando.Parameters.AddWithValue("@ReferenciaComercial", clie.ReferenciaComercial);
                comando.Parameters.AddWithValue("@TelefonoComercial", clie.TelefonoComercial);
                comando.Parameters.AddWithValue("@NombrePropietario", clie.NombrePropietario);
                comando.Parameters.AddWithValue("@Domicilio", clie.Domicilio);
                comando.Parameters.AddWithValue("@UbigeoDomicilio", clie.UbigeoDomicilio);
                comando.Parameters.AddWithValue("@ReferenciaDomicilio", clie.ReferenciaDomicilio);
                comando.Parameters.AddWithValue("@DNI", clie.DNI);
                comando.Parameters.AddWithValue("@TelefonoDomicilio", clie.TelefonoDomicilio);
                comando.Parameters.AddWithValue("@GarantiaCred", clie.GarantiaCred);
                comando.Parameters.AddWithValue("@CreditoMaximo", clie.CreditoMaximo);
                comando.Parameters.AddWithValue("@Observacion", clie.Observacion);
                comando.Parameters.AddWithValue("@NumeroPuesto", clie.NumeroPuesto);
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

        public void Create(Cliente clie)
        {
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            //string create = "insert into Clientes(NroDocmto,Id_DIdent,NombreRSocial,IdClaseClie,Direccion,Referencia,Telefono,IdMercado,Id_Acceso_crea,Califica,NumeroPuesto) values('" + objClientes.NroDocmto + "','" + objClientes.Id_DIdent + "','" + objClientes.NombreRSocial + "','" + objClientes.IdClaseClie + "','" + objClientes.Direccion + "','" + objClientes.Referencia + "','" + objClientes.Telefono + "','" + objClientes.IdMercado + "','" + objClientes.Id_Acceso_crea + "','" + objClientes.Califica + "','" + objClientes.NumeroPuesto + "')";
            try
            {
                comando = new SqlCommand("usp_ClienteInsert", con);
                comando.Parameters.AddWithValue("@IdMercado", clie.IdMercado);
                comando.Parameters.AddWithValue("@RazonSocial", clie.RazonSocial);
                comando.Parameters.AddWithValue("@IdDenominacion", clie.IdDenominacion);
                comando.Parameters.AddWithValue("@Califica", clie.Califica);
                comando.Parameters.AddWithValue("@RUC", clie.RUC);
                comando.Parameters.AddWithValue("@Direccion", clie.Direccion);
                comando.Parameters.AddWithValue("@UbigeoComercial", clie.UbigeoComercial);
                comando.Parameters.AddWithValue("@ReferenciaComercial", clie.ReferenciaComercial);
                comando.Parameters.AddWithValue("@TelefonoComercial", clie.TelefonoComercial);
                comando.Parameters.AddWithValue("@NombrePropietario", clie.NombrePropietario);
                comando.Parameters.AddWithValue("@Domicilio", clie.Domicilio);
                comando.Parameters.AddWithValue("@UbigeoDomicilio", clie.UbigeoDomicilio);
                comando.Parameters.AddWithValue("@ReferenciaDomicilio", clie.ReferenciaDomicilio);
                comando.Parameters.AddWithValue("@DNI", clie.DNI);
                comando.Parameters.AddWithValue("@TelefonoDomicilio", clie.TelefonoDomicilio);
                comando.Parameters.AddWithValue("@GarantiaCred", clie.GarantiaCred);
                comando.Parameters.AddWithValue("@CreditoMaximo", clie.CreditoMaximo);
                comando.Parameters.AddWithValue("@Observacion", clie.Observacion);
                comando.Parameters.AddWithValue("@NumeroPuesto", clie.NumeroPuesto);
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

        public Cliente BuscarclientexPuesto(string numero, string idmercado)
        {
            Cliente objClientes = new Cliente();
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            bool hayRegistros;
            string find = "select*from Cliente where IdMercado='" + idmercado + "'and NumeroPuesto='" + numero + "'";
            try
            {

                comando = new SqlCommand(find, con);
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();
                hayRegistros = reader.Read();
                if (hayRegistros)
                {
                    objClientes.Id_cliente = Convert.ToInt32(reader[0]);
                    objClientes.IdMercado = Convert.ToInt32(reader[1].ToString());
                    objClientes.RazonSocial = reader[2].ToString();
                    objClientes.IdDenominacion = Convert.ToInt32(reader[3].ToString());
                    objClientes.Califica = reader[4].ToString();
                    objClientes.RUC = reader[5].ToString();
                    objClientes.Direccion = reader[6].ToString();
                    objClientes.UbigeoComercial = reader[7].ToString();
                    objClientes.ReferenciaComercial = reader[8].ToString();
                    objClientes.TelefonoComercial = reader[9].ToString();
                    objClientes.NombrePropietario = reader[10].ToString();
                    objClientes.Domicilio = reader[11].ToString();
                    objClientes.UbigeoDomicilio = reader[12].ToString();
                    objClientes.ReferenciaDomicilio = reader[13].ToString();
                    objClientes.DNI = reader[14].ToString();
                    objClientes.TelefonoDomicilio = reader[15].ToString();
                    objClientes.GarantiaCred = Convert.ToInt32(reader[16].ToString());
                    objClientes.CreditoMaximo = Convert.ToInt32(reader[17].ToString());
                    objClientes.Observacion = reader[18].ToString();
                    objClientes.NumeroPuesto = reader[19].ToString();
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
            return objClientes;
        }

        public Cliente BuscarClientexCodigo(string text)
        {
            Cliente objClientes = new Cliente();
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            bool hayRegistros;
            string find = "select*from v_ListarCliente where CodNom='" + text+"'";
            try
            {
                comando = new SqlCommand(find, con);
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();
                hayRegistros = reader.Read();
                if(hayRegistros)
                {
                    objClientes.Id_cliente = Convert.ToInt32(reader[0]);
                    objClientes.NombrePropietario = reader[2].ToString();
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
            return objClientes;
        }
    }

}
