using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedidosCegal
{
    public partial class PrintDoc : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand comando;
        SqlDataAdapter adapter;
        SqlParameter param;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                cargar();
            }
        }

        void cargar()
        {
            Util.Helper.listarDocumentos(ddldocumento);
            txtfecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void report()
        {
            DataTable dt = Buscar(txtfecha.Text,txtfinal.Text,txtinicial.Text);
            ReportDataSource rds = new ReportDataSource("v_PedidoEncabDet", dt);
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.ReportPath = "Reportes/Pedidos.rdlc";

            ReportParameter[] rptParams = new ReportParameter[]
            {
            };
            ReportViewer1.LocalReport.Refresh();
        }

        private DataTable Buscar(string fecha,string final, string inicial)
        {
            string cnx = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            DataTable dt = new DataTable();
            con = new SqlConnection(cnx);
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.CommandText = "usp_Rangoreporte";
            cmd.Parameters.AddWithValue("@inicial", inicial);
            cmd.Parameters.AddWithValue("@final", final);
            cmd.Parameters.AddWithValue("@fecha", fecha);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            return dt;
        }

        protected void btnbsucar_Click(object sender, EventArgs e)
        {
            report();
            string script = "openModal();";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, true);
        }
    }
}