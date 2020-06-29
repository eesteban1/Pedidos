using Model.Enity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedidosCegal
{
    public partial class NueMarca : System.Web.UI.Page
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
                MarcaDAO db = new MarcaDAO();
                bool existe = db.ExisteMarca(txtdescripcion.Text);
                if (!existe)
                {
                    Marcas zon = new Marcas();
                    zon.Descripcion = txtdescripcion.Text;
                    db.Create(zon);
                    Response.Redirect("ManteZonas.aspx", true);
                }
                else
                {
                    txtmensaje.Text = "El codigo del mercado ya existe.";
                    string script = "openModal();";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, true);
                }
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