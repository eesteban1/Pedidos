using Model.Enity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedidosCegal
{
    public partial class NueZona : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {

            }
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                ZonasDAO db = new ZonasDAO();
                zonas zon = new zonas();
                zon.DescripCorta = txtcodigo.Text;
                zon.DescripLarga = txtdescripcion.Text;
                zon.Observacion = txtobservacion.Text;
                db.Create(zon);
                txtmensaje.Text = "El cliente se registo con exito.";
                string script = "openModal();";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, true);
            }
            catch (Exception ex)
            {
                txtmensaje.Text = ex.Message;
                string script = "openModal();";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, true);
            }
            
        }
    }
}