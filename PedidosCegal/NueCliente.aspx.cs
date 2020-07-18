using Model.Enity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedidosCegal
{
    public partial class NueCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                cargarcombo();
                lblmesaje.Text = "";
            }
        }
        void cargarcombo()
        {
            Util.Helper.ListarDenominacion(ddldenominacion);
            Util.Helper.ListarMercado(ddlmercado);
            Util.Helper.ListarDepartamento(ddldepartamentocomercial);
            Util.Helper.ListarDepartamento(dlldepartamentopropietario);
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            if (txtgarantia.Text.Length < 1)
                txtgarantia.Text = "0";
            if (txtcredito.Text.Length < 1)
                txtcredito.Text = "0";
            if(txtrazonsocial.Text.Length < 1 )
            {
                if(txtrazonsocial.Text.Length < 0) lblmesaje.Text = "El campo Razon Social debe ser completado.";
                //if (txtruc.Text.Length != 11) lblmesaje.Text = "El RUC debe tener 11 caracteres.";
                //if (txtdni.Text.Length != 8) lblmesaje.Text = "El DNI debe tener 8 caracteres.";

                string script = "openModal();";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "error", script, true);
            }
            else if (txtnombreapellido.Text.Length < 0)
            {
                lblmesaje.Text = "El campo Apellidos y Nombres debe ser completado.";
                string script = "openModal();";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "error", script, true);
            }
            else
            {
                ClienteDAO db = new ClienteDAO();
                Cliente clie = new Cliente();
                //bool existe = db.ExisteCliente(txtdni.Text);
                //if(existe)
                //{
                //    lblmesaje.Text = "El cliente ya existe.";
                //    string script = "openModal();";
                //    ScriptManager.RegisterStartupScript(this, typeof(Page), "existe", script, true);
                //}
                //else
                //{

                    clie.IdMercado = Convert.ToInt32(ddlmercado.SelectedValue); 
                    clie.RazonSocial = txtrazonsocial.Text;
                    clie.IdDenominacion = Convert.ToInt32(ddldenominacion.SelectedValue);
                    clie.Califica = txtcalifica.Text;
                    clie.RUC = txtruc.Text;
                    clie.Direccion = txtdireccion.Text;
                    clie.UbigeoComercial = ddldepartamentocomercial.SelectedValue + ddlprovincicomercial.SelectedValue + ddldistritocomercial.SelectedValue;
                    clie.ReferenciaComercial = txtreferenciacomercial.Text;
                    clie.TelefonoComercial = txttelefonocomercial.Text;
                    clie.NombrePropietario = txtnombreapellido.Text;
                    clie.Domicilio = txtdomicilio.Text;
                    clie.UbigeoDomicilio = dlldepartamentopropietario.SelectedValue + ddlprovinciaspropietario.SelectedValue + ddldistritopropietario.SelectedValue;
                    clie.ReferenciaDomicilio = txtreferenciapropietario.Text;
                    clie.DNI = txtdni.Text;
                    clie.TelefonoDomicilio = txttelefonodomicilio.Text;
                    clie.GarantiaCred = Convert.ToInt32(txtgarantia.Text);
                    clie.CreditoMaximo = Convert.ToInt32(txtcredito.Text);
                    clie.Observacion = txtobservacion.Text;
                    clie.NumeroPuesto = txtnumeropuesto.Text;
                    db.Create(clie);
                    Response.Redirect("ManteCliente.aspx", true);
                //}
                
            }
           
            
        }

        protected void ddldepartamentocomercial_SelectedIndexChanged(object sender, EventArgs e)
        {
            string iddepa = ddldepartamentocomercial.SelectedValue;
            Util.Helper.ListarProvincia(ddlprovincicomercial, iddepa);
        }

        protected void ddlprovincicomercial_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idprovi = ddlprovincicomercial.SelectedValue;
            string iddepa = ddldepartamentocomercial.SelectedValue;
            Util.Helper.ListarDistrito(ddldistritocomercial, idprovi,iddepa);
        }

        protected void dlldepartamentopropietario_SelectedIndexChanged(object sender, EventArgs e)
        {
            string iddepa = dlldepartamentopropietario.SelectedValue;
            Util.Helper.ListarProvincia(ddlprovinciaspropietario, iddepa);
        }

        protected void ddlprovinciaspropietario_SelectedIndexChanged(object sender, EventArgs e)
        {
            string iddepa = dlldepartamentopropietario.SelectedValue;
            string idprovi = ddlprovinciaspropietario.SelectedValue;
            Util.Helper.ListarDistrito(ddldistritopropietario, idprovi, iddepa);
        }
    }
}