using Model.Enity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedidosCegal
{
    public partial class ModAcceso : System.Web.UI.Page
    {
        private static string usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                cargarcombo();
                cargarpersonal();
            }
        }

        void cargarcombo()
        {
            Util.Helper.ListarPersonal(ddlpersonal);
        }

        void cargarpersonal()
        {
            txtcodigo.Text = Request.QueryString["IDACCESO"];
            int codigo = Convert.ToInt32(txtcodigo.Text);
            AccesoDAO db = new AccesoDAO();
            Accesos acc = db.BuscarAcceso(codigo);
            ddlpersonal.SelectedValue = acc.Id_Personal.ToString();
            txtusuario.Text = acc.Usuario;
            txtclave.Text = acc.Clave;
            usuario = acc.Usuario;
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            if (txtusuario.Text.Length < 0 || txtclave.Text.Length < 0 || ddlpersonal.SelectedValue == "0")
            {
                if (txtusuario.Text.Length < 0) lblmesaje.Text = "El campo usuario es obligatorio.";
                if (txtclave.Text.Length < 0) lblmesaje.Text = "El campo clave es obligatorio.";
                if (ddlpersonal.SelectedValue == "0") lblmesaje.Text = "Debe escojer al personal.";
                string script = "openModal();";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "error", script, true);
            }
            else
            {
                AccesoDAO db = new AccesoDAO();
                Accesos acc = new Accesos();
                if (txtusuario.Text == usuario)
                {
                    acc.Id_Personal = Convert.ToInt32(ddlpersonal.SelectedValue);
                    acc.Usuario = txtusuario.Text;
                    acc.Clave = txtclave.Text;
                    acc.Id_Acceso = Convert.ToInt32(txtcodigo.Text);
                    db.Update(acc);
                    Response.Redirect("ManteAcceso.aspx", true);
                }
                else
                {
                    bool existe = db.ExisteUsario(txtusuario.Text);
                    if (existe)
                    {
                        lblmesaje.Text = "El usuario ya esta en uso.";
                        string script = "openModal();";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "existe", script, true);
                    }
                    else
                    {
                        acc.Id_Personal = Convert.ToInt32(ddlpersonal.SelectedValue);
                        acc.Usuario = txtusuario.Text;
                        acc.Clave = txtclave.Text;
                        acc.Id_Acceso = Convert.ToInt32(txtcodigo.Text);
                        db.Update(acc);
                        Response.Redirect("ManteAcceso.aspx", true);
                    }
                }
                
            }
        }
    }
}