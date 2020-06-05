using Model.Enity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedidosCegal
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["mensaje"] != null)
            {
                string men = Request.Params["mensaje"].ToString();
                if (men == "1")
                {
                    lblerror.Text = "Debe iniciar sesión para ingresar al sitio.";
                    lblerror.Visible = true;
                    txtuser.Focus();
                }
            }
            else
            {
                lblerror.Visible = false;
                txtuser.Focus();
            }
                
        }
        protected void btningresar_Click(object sender, EventArgs e)
        {
            bool existe;
            string id = "";
            string nombre = "";
            string cargo = "";
            string idcargo = "";
            PersonalDAO db = new PersonalDAO();
            Accesos ac = new Accesos();
            ac.Usuario = txtuser.Text;
            ac.Clave = txtpass.Text;
            existe = db.Ingreso(ac,out id,out nombre,out idcargo,out cargo);
            if (existe)
            {
                Session["NombreUsuario"] = nombre;
                Session["IDUsuario"] = id;
                Session["CargoUsuario"] = cargo;
                if(idcargo == "3")
                {
                    Response.Redirect("~/Inicio.aspx", true);
                }
                else if(idcargo == "1")
                {
                    Response.Redirect("~/InicioVendedor.aspx", true);
                }

            }
            else
            {
                lblerror.Text = "Usuario o contraseña incorrecto";
                lblerror.Visible = true;
                txtpass.Focus();
            }
        }
    }
}