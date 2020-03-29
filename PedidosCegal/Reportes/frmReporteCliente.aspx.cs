using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using Model.Enity;


namespace PedidosCegal.Reportes
{
    public partial class frmReporteCliente : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand comando;
        SqlDataAdapter adapter;
        SqlParameter param;
       

        protected void Page_Load(object sender, EventArgs e)
        {
            ventas2Entities db = new ventas2Entities();
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            if (!IsPostBack)
            {
                Imprimir();
            }
            
        }
        private void Imprimir()
        {
            
            DataTable dt = cargar();
            ReportDataSource rds = new ReportDataSource("v_Clientes", dt);
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.ReportPath = "Reportes/Cliente.rdlc";

            ReportParameter[] rptParams = new ReportParameter[]
            {
                new ReportParameter()
            };
            ReportViewer1.LocalReport.Refresh();
        }
        private DataTable cargar()
        {
            DataTable dt = new DataTable();
            SqlConnection nc = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_cliente";
            cmd.Connection = con;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            return dt;
        }
    }
}