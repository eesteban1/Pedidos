using Model.Enity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedidosCegal
{
    public partial class AsignaZonas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                LlenarCombo();
                cargar();
            }
        }
        void cargar()
        {
            AsignaZonaDAO db = new AsignaZonaDAO();
            grvasigna.DataSource = db.ListarZonaAsignada();
            grvasigna.DataBind();
        }
        void LlenarCombo()
        {
            Util.Helper.ListarVendedor(ddlvendedor);
            Util.Helper.ListarZona(ddlzona);
        }
        protected void btnguardar_Click(object sender, EventArgs e)
        {
            AsignaZonaDAO db = new AsignaZonaDAO();
            string id = ddlvendedor.SelectedValue;
            string zona = db.BuscarZonaAsignada(id,out string idzon);
            if (zona.Length > 0)
            {
                string script = @"<script type='text/javascript'>
                            alert('Ya se le asigno una zona al vendedor.');
                        </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
            else
            {
                AsignaZona asi = new AsignaZona();
                asi.Id_personal = Convert.ToInt32(ddlvendedor.SelectedValue);
                asi.IdZona = Convert.ToInt32(ddlzona.SelectedValue);
                asi.usuario = Convert.ToInt32(Session["IDUsuario"].ToString());
                db.Grabar(asi);
                cargar();
            }
            
        }

        protected void grvasigna_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvasigna.PageIndex = e.NewPageIndex;
            cargar();
        }

        protected void grvasigna_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            int idasign = Convert.ToInt32(grvasigna.Rows[fila].Cells[0].Text);
            if (e.CommandName == "Eliminar")
            {
                AsignaZonaDAO db = new AsignaZonaDAO();
                db.Eliminar(idasign);
                cargar();
            }
        }
    }
}