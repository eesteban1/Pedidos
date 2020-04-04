using Model.Enity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedidosCegal
{
    public partial class VerPedidoVendedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["detalles"] = Util.Helper.CrearTemp_Detalles();
                cargarlistas();
                cargarDetalles();
                 cargar();
            }
        }
        void cargarlistas()
        {
            
            MercadoDAO db1 = new MercadoDAO();
            AsignaZonaDAO db = new AsignaZonaDAO();
            string idusu = Session["IDUsuario"].ToString();
            string zona = db.BuscarZonaAsignada(idusu, out string idzona);
            lblzona.Text = zona;
            ddlmercados.DataSource = db1.MercadoxZona(idzona);
            ddlmercados.DataTextField = "NombreLargo";
            ddlmercados.DataValueField = "IdMercado";
            ddlmercados.DataBind();
            

        }
        void cargarDetalles()
        {
            
            grvDetalles.DataSource = Session["detalles"];
            grvDetalles.DataBind();
        }
        void cargar()
        {
            Int32 id = Convert.ToInt32(Request.QueryString["IDV"]);
            PedidoDAO db = new PedidoDAO();
            System.Data.DataSet ds =  db.BuscarPedido(id);
            DataTable dtcabecera = ds.Tables[0];
            AsignaZonaDAO db1 = new AsignaZonaDAO();
            string idusu = Session["IDUsuario"].ToString();
            txtcodcliente.Text = Convert.ToString(dtcabecera.Rows[0]["Id_cliente"]);
            txtfecha.Text = Convert.ToDateTime(dtcabecera.Rows[0]["fechaCheque"]).ToString("yyyy-MM-dd");
            ddlmercados.SelectedValue = Convert.ToString(dtcabecera.Rows[0]["IdMercado"]);
            lbltotal.Text = Convert.ToString(dtcabecera.Rows[0]["Total_Venta"]);
            lblnombre.Text = Convert.ToString(dtcabecera.Rows[0]["NombrePropietario"]);

            DataTable detalles = (DataTable)Session["detalles"];
            if (detalles.Rows.Count > 0)
            {
                detalles.Rows.Clear();
            }
            DataTable dtdetalles = ds.Tables[1];

            foreach(DataRow Rg in dtdetalles.Rows)
            {
                string idpro = Convert.ToString(Rg["Id_prod"]);
                string Descripcion = Convert.ToString(Rg["descripcion"]);
                decimal precio = Convert.ToDecimal(Rg["PrecioUnit"]);
                int dcantidad = Convert.ToInt32(Rg["Paquetes"]);
                decimal peso = Convert.ToDecimal(Rg["CantidadKilos"]);
                decimal total = dcantidad * precio;

                Util.Helper.Agregar_Detalles(detalles, idpro, Descripcion, precio, dcantidad, peso, total);
                Session["detalles"] = detalles;
            }
            cargarDetalles();
            lbltotal.Text = Util.Helper.TotalizarGrilla(grvDetalles,5).ToString();
        }
    }
}