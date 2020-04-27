using Model.Enity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedidosCegal
{
    public partial class NuevMercado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                cargarlista();
            }
        }

        void cargarlista()
        {
            Util.Helper.ListarZona(ddlzona);
            Util.Helper.ListarDepartamento(ddldepartamento);
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            MercadoDAO db = new MercadoDAO();
            mercados mer = new mercados();
            mer.NombreCorto = txtcodigo.Text;
            mer.IdZona = Convert.ToInt32(ddlzona.SelectedValue);
            mer.NombreLargo = txtmercado.Text;
            mer.Direccion = txtdireccion.Text;
            mer.ubigeo = ddldepartamento.SelectedValue + ddlprovincia.SelectedValue + ddldistrito.SelectedValue;
            mer.Observ = txtobservacion.Text;
            db.Create(mer);
            Response.Redirect("ManteMercados.aspx", true); 
        }

        protected void ddlprovincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idprovi = ddlprovincia.SelectedValue;
            string iddepa = ddldepartamento.SelectedValue;
            Util.Helper.ListarDistrito(ddldistrito, idprovi,iddepa);
        }

        protected void ddldepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            string iddepa = ddldepartamento.SelectedValue;
            Util.Helper.ListarProvincia(ddlprovincia, iddepa);
        }
    }
}