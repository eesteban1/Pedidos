using Model.Enity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedidosCegal
{
    public partial class ModMercado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                llenarcombo();
                cargarmercado();
            }
        }
        void llenarcombo()
        {
            Util.Helper.ListarDepartamento(ddldepartamento);
            Util.Helper.ListarZona(ddlzona);
        }
        void cargarmercado()
        {
            int id = Convert.ToInt32(Request.QueryString["IDM"]);
            MercadoDAO db = new MercadoDAO();
            mercados mer = db.BuscarMercado(id);
            txtid.Text = mer.IdMercado.ToString();
            txtcodigo.Text = mer.NombreCorto.ToString();
            txtdireccion.Text = mer.Direccion.ToString();
            txtmercado.Text = mer.NombreLargo.ToString();
            txtobservacion.Text = mer.Observ.ToString();
            ddldepartamento.SelectedValue = mer.ubigeo.Substring(0, 2).ToString();
            string iddepacomer = ddldepartamento.SelectedValue;
            Util.Helper.ListarProvincia(ddlprovincia, iddepacomer);
            ddlprovincia.SelectedValue = mer.ubigeo.Substring(2, 2).ToString();
            string idprovicomer = ddlprovincia.SelectedValue;
            Util.Helper.ListarDistrito(ddldistrito, idprovicomer);
            ddldistrito.SelectedValue = mer.ubigeo.Substring(4, 2).ToString();
            ddlzona.SelectedValue = mer.IdZona.ToString();
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            MercadoDAO db = new MercadoDAO();
            mercados mer = new mercados();
            mer.IdMercado = Convert.ToInt32(txtid.Text);
            mer.IdZona = Convert.ToInt32(ddlzona.SelectedValue);
            mer.NombreCorto = txtcodigo.Text;
            mer.NombreLargo = txtmercado.Text;
            mer.Observ = txtobservacion.Text;
            mer.ubigeo = ddldepartamento.SelectedValue + ddlprovincia.SelectedValue + ddldistrito.SelectedValue;
            db.update(mer);
            lblmesaje.Text = "El registro se actualizó correctamente.";
        }

        protected void ddldepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            string iddepa = ddldepartamento.SelectedValue;
            Util.Helper.ListarProvincia(ddlprovincia, iddepa);
        }

        protected void ddlprovincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idprovi = ddlprovincia.SelectedValue;
            Util.Helper.ListarDistrito(ddldistrito, idprovi);
        }
    }
}