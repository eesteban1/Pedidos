using Model.Enity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedidosCegal
{
    public partial class VerPersonal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cargarcombo();
                cargar();
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
            txtfechanac.Text = Convert.ToDateTime(per.fechaNacimiento).ToString("yyyy-MM-dd");
            rdbsexo.SelectedValue = per.Sexo;
            txtfechaingre.Text = Convert.ToDateTime(per.fechaIngreso).ToString("yyyy-MM-dd");
            ddlcargo.SelectedValue = per.CodCargo;
            ddlcivil.SelectedValue = per.EstadoCivil;
            txthijos.Text = per.NroHijos;
            txtipss.Text = per.Nrolpss;
        }
    }
}