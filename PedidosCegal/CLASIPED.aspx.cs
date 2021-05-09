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
                Util.Helper.ListarZona(ddlzona);
                Util.Helper.ListarMercadoxZona(ddlmercado, "");
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
                
                if(ddlmercado.SelectedValue != "0")
                {
                    string zona = ddlzona.SelectedValue;
                    string mercado = ddlmercado.SelectedValue;
                    report2(inicio, final, zona, mercado);
                }
                else if (ddlzona.SelectedValue != "0")
                {
                    string zona = ddlzona.SelectedValue;
                    report1(inicio, final, zona, "");
                }
                else
                {
                    report3(inicio, final, "", "");
                }
                string script = "openModal();";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, true);
            }
            else if(ddldocumento.SelectedValue =="2")
            {
              
                string inicio = "23";
                string final = "60";

                if (ddlmercado.SelectedValue != "0")
                {
                    string zona = ddlzona.SelectedValue;
                    string mercado = ddlmercado.SelectedValue;
                    report2(inicio, final, zona, mercado);
                }
                else if(ddlzona.SelectedValue != "0")
                {
                    string zona = ddlzona.SelectedValue;
                    report1(inicio, final, zona, "");
                }
                else
                {
                    report3(inicio, final, "", "");
                }
                string script = "openModal();";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, true);
            }
            else if(ddldocumento.SelectedValue =="3")
            {
              
                string inicio = "0";
                string final = "10000000";
                report3(inicio, final, "", "");
                string script = "openModal();";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, true);
            }
        }
        void report1(string inicio,string final,string zona,string mercado)
        {
            DataTable dt = Buscar(txtfechai.Text,txtfechaf.Text,inicio,final,zona,mercado);
            ReportDataSource rds = new ReportDataSource("v_PedidoEncabDet", dt);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.ReportPath = "Reportes/Reportpesos.rdlc";

            ReportParameter[] rptParams = new ReportParameter[4];
            rptParams[0] = new ReportParameter("ini", inicio);
            rptParams[1] = new ReportParameter("fin", final);
            rptParams[2] = new ReportParameter("finicial", txtfechai.Text);
            rptParams[3] = new ReportParameter("ffinal", txtfechaf.Text);
            ReportViewer1.LocalReport.SetParameters(rptParams);
            ReportViewer1.LocalReport.Refresh();
            
        }

        void report2(string inicio, string final, string zona, string mercado)
        {
            DataTable dt = Buscar(txtfechai.Text, txtfechaf.Text, inicio, final, zona, mercado);
            ReportDataSource rds = new ReportDataSource("v_PedidoEncabDet", dt);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.ReportPath = "Reportes/Reportpesos2.rdlc";

            ReportParameter[] rptParams = new ReportParameter[4];
            rptParams[0] = new ReportParameter("ini", inicio);
            rptParams[1] = new ReportParameter("fin", final);
            rptParams[2] = new ReportParameter("finicial", txtfechai.Text);
            rptParams[3] = new ReportParameter("ffinal", txtfechaf.Text);
            ReportViewer1.LocalReport.SetParameters(rptParams);
            ReportViewer1.LocalReport.Refresh();

        }

        void report3(string inicio, string final, string zona, string mercado)
        {
            DataTable dt = Buscar(txtfechai.Text, txtfechaf.Text, inicio, final, zona, mercado);
            ReportDataSource rds = new ReportDataSource("v_PedidoEncabDet", dt);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.ReportPath = "Reportes/Reportpesos3.rdlc";

            ReportParameter[] rptParams = new ReportParameter[4];
            rptParams[0] = new ReportParameter("ini", inicio);
            rptParams[1] = new ReportParameter("fin", final);
            rptParams[2] = new ReportParameter("finicial", txtfechai.Text);
            rptParams[3] = new ReportParameter("ffinal", txtfechaf.Text);
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

        protected void ddlzona_SelectedIndexChanged(object sender, EventArgs e)
        {
            string zona = ddlzona.SelectedValue;
            Util.Helper.ListarMercadoxZona(ddlmercado,zona);
        }

        protected void ddldocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddldocumento.SelectedValue == "3")
            {
             
                ddlmercado.Visible = false;
                ddlzona.Visible = false;
                lblmercado.Visible = false;
                lblzona.Visible = false;
            }
            else
            {
                ddlmercado.Visible = true;
                lblmercado.Visible = true;
                lblzona.Visible = true;
                ddlzona.Visible = true;
            }
        }
    }
}