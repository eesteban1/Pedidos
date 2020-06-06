using Model.Enity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedidosCegal
{
    public partial class NueAcceso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                cargarcombo();
            }
        }

        void cargarcombo()
        {
            Util.Helper.ListarPersonal(ddlpersonal);
        }
        protected void btnguardar_Click(object sender, EventArgs e)
        {
            if(txtusuario.Text.Length<0 || txtclave.Text.Length<0 || ddlpersonal.SelectedValue == "0")
            {
                if (txtusuario.Text.Length <0) lblmesaje.Text = "El campo usuario es obligatorio.";
                if (txtclave.Text.Length <0) lblmesaje.Text = "El campo clave es obligatorio.";
                if (ddlpersonal.SelectedValue == "0") lblmesaje.Text = "Debe escojer al personal.";
                string script = "openModal();";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "error", script, true);
            }
            else
            {
                AccesoDAO db = new AccesoDAO();
                Accesos acc = new Accesos();
                bool existe = db.ExisteUsario(txtusuario.Text);
                bool existepersonal = db.ExistePersonal(ddlpersonal.SelectedValue);
                if(existe)
                {
                    lblmesaje.Text = "El usuario ya esta en uso.";
                    string script = "openModal();";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "existe", script, true);
                }
                else if(existepersonal)
                {
                    lblmesaje.Text = "El personal elejido ya tiene acceso al sistema.";
                    string script = "openModal();";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "existe", script, true);
                }
                else
                {
                    acc.Id_Personal = Convert.ToInt32(ddlpersonal.SelectedValue);
                    acc.Usuario = txtusuario.Text;
                    acc.Clave = txtclave.Text;
                    db.Create(acc);

                    Response.Redirect("ManteAcceso.aspx", true);
                }
            }
        }
    }
}