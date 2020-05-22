using Model.Enity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedidosCegal
{
    public partial class NuePersonal : System.Web.UI.Page
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
            Util.Helper.ListarCargo(ddlcargo);
            Util.Helper.ListarDepartamento(ddldepartamento);
        }

        protected void ddldepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            string iddepa = ddldepartamento.SelectedValue;
            Util.Helper.ListarProvincia(ddlprovincia, iddepa);
        }

        protected void ddlprovincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idprovi = ddlprovincia.SelectedValue;
            string iddepa = ddldepartamento.SelectedValue;
            Util.Helper.ListarDistrito(ddldistrito, idprovi, iddepa);
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            PersonalDAO db = new PersonalDAO();
            Personal per = new Personal();
            bool existe = db.ExistePersonal(txtdni.Text);
            if(existe)
            {
                lblmesaje.Text = "El personal ya existe.";
                string script = "openModal();";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "existe", script, true);
            }
            else
            {
                per.ApellidoMat = txtapemat.Text;
                per.ApellidoPat = txtapepat.Text;
                per.Nombres = txtnombre.Text;
                per.NroDNI = txtdni.Text;
                per.Domicilio = txtdomicilio.Text;
                per.Ubigeo = ddldepartamento.SelectedValue + ddlprovincia.SelectedValue + ddldistrito.SelectedValue;
                per.Telefono = txttelefono.Text;
                per.fechaNacimiento = Convert.ToDateTime(txtfechanac.Text);
                per.Sexo = rdbsexo.SelectedValue;
                per.fechaIngreso = Convert.ToDateTime(txtfechaingre.Text);
                per.CodCargo = ddlcargo.SelectedValue;
                per.EstadoCivil = ddlcivil.SelectedValue;
                per.Nrolpss = txtipss.Text;
                per.NroHijos = txthijos.Text;
                per.Observ = txtobservacion.Text;
                db.Create(per);

                Response.Redirect("MantePersonal.aspx", true);
            }
        }
    }
}