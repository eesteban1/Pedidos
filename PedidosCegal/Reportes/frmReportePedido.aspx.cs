using Microsoft.Reporting.WebForms;
using Model.Enity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedidosCegal.Reportes
{
    public partial class frmReportePedido : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand comando;
        SqlDataAdapter adapter;
        SqlParameter param;
        string Id_Encabe;

        protected void Page_Load(object sender, EventArgs e)
        {
            ventas2Entities db = new ventas2Entities();
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            if (!Page.IsPostBack)
            {
                renderReport();
            }
        }

        private void renderReport()
        {
            Id_Encabe = Request.QueryString["Id_Encab"];
            DataTable dt = cargar(Id_Encabe);
            ReportDataSource rds = new ReportDataSource("v_PedidoEncabDet", dt);
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.ReportPath = "Reportes/frmPedido.rdlc";

            ReportParameter[] rptParams = new ReportParameter[]
            {
            };
            ReportViewer1.LocalReport.Refresh();
        }

        private DataTable cargar(string id)
        {
            ventas2Entities db = new ventas2Entities();
            DataTable dt = new DataTable();
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_Pedido";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            return dt;
        }
    }
}