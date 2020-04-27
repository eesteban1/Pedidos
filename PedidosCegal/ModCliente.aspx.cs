using Model.Enity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedidosCegal
{
    public partial class ModCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                llenarcomobo();
                cargarcliente();
                lblmesaje.Text = "";
            }
        }
        void cargarcliente()
        {
            int id = Convert.ToInt32(Request.QueryString["IDC"]);
            ClienteDAO db = new ClienteDAO();
            Cliente clie =  db.Buscarcliente(id,"");
            ddlmercado.SelectedValue = clie.IdMercado.ToString();
            txtcodclie.Text = clie.Id_cliente.ToString();
            txtrazonsocial.Text = clie.RazonSocial;
            ddldenominacion.SelectedValue = clie.IdDenominacion.ToString();
            txtcalifica.Text = clie.Califica;
            txtruc.Text = clie.RUC;
            txtdireccion.Text = clie.Direccion;
            ddldepartamentocomercial.SelectedValue = clie.UbigeoComercial.Substring(0, 2);
            string iddepacomer = ddldepartamentocomercial.SelectedValue;
            Util.Helper.ListarProvincia(ddlprovincicomercial, iddepacomer);
            ddlprovincicomercial.SelectedValue = clie.UbigeoComercial.Substring(2, 2);
            string idprovicomer = ddlprovincicomercial.SelectedValue;
            Util.Helper.ListarDistrito(ddldistritocomercial, idprovicomer,iddepacomer);
            ddldistritocomercial.SelectedValue = clie.UbigeoComercial.Substring(4, 2);
            txtreferenciacomercial.Text = clie.ReferenciaComercial;
            txttelefonocomercial.Text =clie.TelefonoComercial;
            txtnombreapellido.Text =clie.NombrePropietario;
            txtdomicilio.Text =clie.Domicilio;
            dlldepartamentopropietario.SelectedValue = clie.UbigeoDomicilio.Substring(0, 2);
            string iddepapro = dlldepartamentopropietario.SelectedValue;
            Util.Helper.ListarProvincia(ddlprovinciaspropietario, iddepapro);
            ddlprovinciaspropietario.SelectedValue = clie.UbigeoDomicilio.Substring(2, 2);
            string idprovi = ddlprovinciaspropietario.SelectedValue;
            Util.Helper.ListarDistrito(ddldistritopropietario, idprovi,iddepapro);
            ddldistritopropietario.SelectedValue = clie.UbigeoDomicilio.Substring(4, 2);
            txtreferenciapropietario.Text = clie.ReferenciaDomicilio;
            txtdni.Text = clie.DNI;
            txttelefonodomicilio.Text = clie.TelefonoDomicilio;
            txtgarantia.Text = clie.GarantiaCred.ToString();
            txtcredito.Text = clie.CreditoMaximo.ToString();
            txtobservacion.Text = clie.Observacion;
            txtnumeropuesto.Text = clie.NumeroPuesto.ToString();
        }

        void llenarcomobo()
        {
            Util.Helper.ListarDenominacion(ddldenominacion);
            Util.Helper.ListarMercado(ddlmercado);
            Util.Helper.ListarDepartamento(ddldepartamentocomercial);
            Util.Helper.ListarDepartamento(dlldepartamentopropietario);
            
            
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            ClienteDAO db = new ClienteDAO();
            Cliente clie = new Cliente();
            clie.Id_cliente = Convert.ToInt32(txtcodclie.Text);
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
            db.update(clie);
            Response.Redirect("ManteCliente.aspx", true);
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
            string idprovi = ddlprovinciaspropietario.SelectedValue;
            string iddepa = dlldepartamentopropietario.SelectedValue;
            Util.Helper.ListarDistrito(ddldistritopropietario, idprovi,iddepa);
        }
    }
}