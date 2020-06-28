using Model.Enity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedidosCegal
{
    public partial class NueFamilia : System.Web.UI.Page
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
                FamiliaDAO db = new FamiliaDAO();
                bool existe = db.ExisteFamilia(txtdescripcion.Text);
                if(existe)
                {
                    txtmensaje.Text = "El codigo del mercado ya existe.";
                    string script = "openModal();";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, true);
                }
                else
                {
                    Familia familia = new Familia();
                    familia.Nombre = txtdescripcion.Text;
                    db.Create(familia);
                    Response.Redirect("ManteFamilia.aspx", true);
                }
            }
            catch(Exception ex)
            {
                txtmensaje.Text = ex.Message;
                string script = "openModal();";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, true);
            }
        }
    }
}