using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedidosCegal.Reportes
{
    public partial class frmReporteBlanco : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Imprimir();
        }
        private void Imprimir()
        {

            ReportViewer1.LocalReport.ReportPath = "Reportes/ReporteBlanco.rdlc";
            ReportViewer1.LocalReport.Refresh();
        }
    }
}