using Model.Enity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedidosCegal
{
    public partial class VerCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                llenarcomobo(); 
                cargar();
            }
        }

        void cargar()
        {
            int id = Convert.ToInt32(Request.QueryString["IDC"]);
            ClienteDAO db = new ClienteDAO();
            Cliente clie = db.Buscarcliente(id, "");
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
            txttelefonocomercial.Text = clie.TelefonoComercial;
            txtnombreapellido.Text = clie.NombrePropietario;
            txtdomicilio.Text = clie.Domicilio;
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
    }
}