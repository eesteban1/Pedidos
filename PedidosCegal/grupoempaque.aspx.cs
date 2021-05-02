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
    public partial class grupoempaque : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand comando;
        SqlDataAdapter adapter;
        SqlParameter param;
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnbsucar_Click(object sender, EventArgs e)
        {
            if(txtfechai.Text != "" && txtfechaf.Text != "")
            {
                report1(txtfechai.Text, txtfechai.Text);
                string script = "openModal();";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, true);
            }
            else
            {
                lblmesaje.Text = "Debe llenar los campos requeridos.";
                string script = "openModalError();";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, true);
            }
            
        }

        void report1(string inicio, string final)
        {
            DataTable dt = Buscar(txtfechai.Text, txtfechaf.Text);
            ReportDataSource rds = new ReportDataSource("v_pedidos", dt);
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.ReportPath = "Reportes/productoagrupado.rdlc";

            ReportParameter[] rptParams = new ReportParameter[2];
            rptParams[0] = new ReportParameter("ini", inicio);
            rptParams[1] = new ReportParameter("fin", final);
            ReportViewer1.LocalReport.SetParameters(rptParams);
            ReportViewer1.LocalReport.Refresh();
        }

        private DataTable Buscar(string fechai, string fechaf)
        {
            string cnx = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            DataTable dt = new DataTable();
            con = new SqlConnection(cnx);
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            cmd.CommandText = "Select * from v_pedidos where fechacheque between '"+fechai+"' and'"+ fechaf +"'";
            
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            return dt;
        }
    }
}