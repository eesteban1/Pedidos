using Model.Enity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedidosCegal
{
    public partial class ModPersonal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                cargarcombo();
                cargar();
                lblmesaje.Text = "";
            }
        }
        void cargarcombo()
        {
            Util.Helper.ListarCargo(ddlcargo);
            Util.Helper.ListarDepartamento(ddldepartamento);
        }
        void cargar()
        {
            int id = Convert.ToInt32(Request.QueryString["IDPERSONA"]);
            PersonalDAO db = new PersonalDAO();
            Personal per = db.BuscarPersonal(id);
            txtapemat.Text = per.ApellidoMat;
            txtapepat.Text = per.ApellidoPat;
            txtnombre.Text = per.Nombres;
            txtdni.Text = per.NroDNI;
            txtdomicilio.Text = per.Domicilio;
            ddldepartamento.SelectedValue = per.Ubigeo.Substring(0, 2);
            string iddepa = ddldepartamento.SelectedValue;
            Util.Helper.ListarProvincia(ddlprovincia, iddepa);
            ddlprovincia.SelectedValue = per.Ubigeo.Substring(2, 2);
            string idprovi = ddlprovincia.SelectedValue;
            Util.Helper.ListarDistrito(ddldistrito, idprovi, iddepa);
            ddldistrito.SelectedValue = per.Ubigeo.Substring(4, 2);
            txttelefono.Text = per.Telefono;
            txtfechanac.Text = per.fechaNacimiento.ToString();
            rdbsexo.SelectedValue = per.Sexo;
            txtfechaingre.Text = per.fechaIngreso.ToString();
            ddlcargo.SelectedValue = per.CodCargo;
            ddlcivil.SelectedValue = per.EstadoCivil;
            txthijos.Text = per.NroHijos;
            txtipss.Text = per.Nrolpss;
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
            db.Update(per);

            Response.Redirect("MantePersonal.aspx", true);
        }
    }
}