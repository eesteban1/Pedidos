﻿using Microsoft.Reporting.WebForms;
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
    public partial class rgpollegada : System.Web.UI.Page
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
            if(ddldocumento.SelectedValue =="0")
            {

            }
            else if(ddldocumento.SelectedValue =="1")
            {
                report1(txtfechai.Text,txtfechai.Text);
                string script = "openModal();";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, true);
            }
        }

        void report1(string inicio, string final)
        {
            DataTable dt = Buscar(txtfechai.Text, txtfechaf.Text);
            ReportDataSource rds = new ReportDataSource("v_RptGeneral", dt);
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.ReportPath = "Reportes/rptgeneralpedidos.rdlc";

            ReportParameter[] rptParams = new ReportParameter[4];
            rptParams[0] = new ReportParameter("ini", inicio);
            rptParams[1] = new ReportParameter("fin", final);
            rptParams[2] = new ReportParameter("finicial", txtfechai.Text);
            rptParams[3] = new ReportParameter("ffinal", txtfechaf.Text);
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
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.CommandText = "usp_rptgeneralpedido";
            cmd.Parameters.AddWithValue("@fechai", fechai);
            cmd.Parameters.AddWithValue("@fechaf", fechaf);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            return dt;
        }
    }
}