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
    public partial class CLASIPED : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand comando;
        SqlDataAdapter adapter;
        SqlParameter param;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {

            }
        }

        protected void btnbsucar_Click(object sender, EventArgs e)
        {
            if(ddldocumento.SelectedValue =="0")
            {

            }
            else if(ddldocumento.SelectedValue == "1")
            {
                string inicio = "0";
                string final = "20";
                
                if(txtzonmer.Text.Length == 2)
                {
                    string zona = txtzonmer.Text.Substring(0, 1);
                    string mercado = txtzonmer.Text.Substring(1, 1);
                    report1(inicio, final, zona, mercado);
                }
                else
                {
                    string zona = txtzonmer.Text.Substring(0, 1);
                    report1(inicio, final, zona, "");
                }
                string script = "openModal();";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, true);
            }
            else if(ddldocumento.SelectedValue =="2")
            {
                string inicio = "23";
                string final = "60";

                if (txtzonmer.Text.Length == 2)
                {
                    string zona = txtzonmer.Text.Substring(0, 1);
                    string mercado = txtzonmer.Text.Substring(1, 1);
                    report1(inicio, final, zona, mercado);
                }
                else
                {
                    string zona = txtzonmer.Text.Substring(0, 1);
                    report1(inicio, final, zona, "");
                }
                string script = "openModal();";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, true);
            }
            else if(ddldocumento.SelectedValue =="3")
            {
                string inicio = "0";
                string final = "10000000";
                if (txtzonmer.Text.Length == 2)
                {
                    string zona = txtzonmer.Text.Substring(0, 1);
                    string mercado = txtzonmer.Text.Substring(1, 1);
                    report1(inicio, final, zona, mercado);
                }
                else
                {
                    string zona = txtzonmer.Text.Substring(0, 1);
                    report1(inicio, final, zona, "");
                }
                string script = "openModal();";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, true);
            }
        }
        void report1(string inicio,string final,string zona,string mercado)
        {
            DataTable dt = Buscar(txtfechai.Text,txtfechaf.Text,inicio,final,zona,mercado);
            ReportDataSource rds = new ReportDataSource("v_PedidoEncabDet", dt);
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.ReportPath = "Reportes/Reportpesos.rdlc";

            ReportParameter[] rptParams = new ReportParameter[2];
            rptParams[0] = new ReportParameter("ini", inicio);
            rptParams[1] = new ReportParameter("fin", final);
            ReportViewer1.LocalReport.SetParameters(rptParams);
            ReportViewer1.LocalReport.Refresh();
        }

        private DataTable Buscar(string fechai,string fechaf, string inicio, string final,string zona,string mercado)
        {
            string cnx = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            DataTable dt = new DataTable();
            con = new SqlConnection(cnx);
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.CommandText = "usp_Peso0a20";
            cmd.Parameters.AddWithValue("@inicio", inicio);
            cmd.Parameters.AddWithValue("@final", final);
            cmd.Parameters.AddWithValue("@fechai", fechai);
            cmd.Parameters.AddWithValue("@fechaf", fechaf);
            cmd.Parameters.AddWithValue("@zona", zona);
            cmd.Parameters.AddWithValue("@mercado", mercado);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            return dt;
        }
    }
}