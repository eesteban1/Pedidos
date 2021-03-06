﻿using AjaxControlToolkit;
using Model.Enity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace PedidosCegal.Util
{
    public class Helper
    {
        public static void ListarDenominacion(DropDownList cbo)
        {
            DenominacionDAO db = new DenominacionDAO();
            cbo.DataSource = db.Listar();
            cbo.DataTextField = "Descripcion";
            cbo.DataValueField = "IdDenominacion";
            cbo.DataBind();
        }

        public static void listarDocumentos(DropDownList ddl)
        {
            PedidoDAO db = new PedidoDAO();
            ddl.DataSource = db.ListarDocumento();
            ddl.DataTextField = "Nombre";
            ddl.DataValueField = "Id_documento";
            ddl.DataBind();
        }

        internal static void ListarPersonal(DropDownList ddlpersonal)
        {
            PersonalDAO db = new PersonalDAO();
            ddlpersonal.DataSource = db.ListarPersonal();
            ddlpersonal.DataTextField= "Nombres";
            ddlpersonal.DataValueField = "Id_personal";
            ddlpersonal.DataBind();
            ddlpersonal.Items.Insert(0, new ListItem("Seleccione", "0"));
        }

        internal static void ListarDia(DropDownList ddldia)
        {
            AsignaZonaDAO db = new AsignaZonaDAO();
            ddldia.DataSource = db.ListarDia();
            ddldia.DataTextField = "Descripcion";
            ddldia.DataValueField = "Id_Dia";
            ddldia.DataBind();
            ddldia.Items.Insert(0, new ListItem("Seleccione", "0"));
        }

        internal static void ListarCargo(DropDownList ddlcargo)
        {
            CargoDAO db = new CargoDAO();
            ddlcargo.DataSource = db.Listar();
            ddlcargo.DataTextField = "Nombre";
            ddlcargo.DataValueField = "Codigo";
            ddlcargo.DataBind();
            ddlcargo.Items.Insert(0, new ListItem("Seleccione", "0"));
        }

        public static void ListarClientesxMerZon(DropDownList cbo,string codigo)
        {
            ClienteDAO db = new ClienteDAO();
            cbo.DataSource = db.listarclientemerzon(codigo);
            cbo.DataTextField = "NombrePropietario";
            cbo.DataValueField = "Id_cliente";
            cbo.DataBind();
            cbo.Items.Insert(0, new ListItem("Seleccione", "0"));
        }

        internal static DataTable CrearTemp_Detalles()
        {
            DataTable dtTempDetalles = new DataTable();
            dtTempDetalles.Columns.Add(new DataColumn("IdArticulo", System.Type.GetType("System.String")));
            dtTempDetalles.Columns.Add(new DataColumn("Descripcion", System.Type.GetType("System.String")));
            dtTempDetalles.Columns.Add(new DataColumn("Cantidad", System.Type.GetType("System.Decimal")));
            dtTempDetalles.Columns.Add(new DataColumn("Peso", System.Type.GetType("System.Decimal")));
            dtTempDetalles.Columns.Add(new DataColumn("PrecioUnidad", System.Type.GetType("System.Decimal")));
            dtTempDetalles.Columns.Add(new DataColumn("igvsub", System.Type.GetType("System.Decimal")));
            dtTempDetalles.Columns.Add(new DataColumn("SubTotal", System.Type.GetType("System.Decimal")));

            return dtTempDetalles;
        }

        internal static void ListarFormaPago(DropDownList ddlformapago)
        {
            FormasPagoDAO db = new FormasPagoDAO();
            ddlformapago.DataSource = db.Listar();
            ddlformapago.DataValueField = "Id_FormaPago";
            ddlformapago.DataTextField = "Nombre";
            ddlformapago.DataBind();
        }

        internal static void Listarmoneda(DropDownList ddlmoneda)
        {
            MonedaDAO db = new MonedaDAO();
            ddlmoneda.DataSource = db.Listar();
            ddlmoneda.DataValueField = "Id_Moneda";
            ddlmoneda.DataTextField = "Desc_Large";
            ddlmoneda.DataBind();
            
        }

        internal static void ListarZona(DropDownList ddlzona)
        {
            ZonasDAO db = new ZonasDAO();
            ddlzona.DataSource=db.Listar();
            ddlzona.DataValueField = "IdZona";
            ddlzona.DataTextField = "DescripLarga";
            ddlzona.DataBind();
            ddlzona.Items.Insert(0, new ListItem("Seleccione", "0"));
        }

        internal static void ListarVendedor(DropDownList ddlvendedor)
        {
            PersonalDAO db = new PersonalDAO();
            ddlvendedor.DataSource = db.ListarVendedor();
            ddlvendedor.DataValueField = "Id_personal";
            ddlvendedor.DataTextField = "Nombres";
            ddlvendedor.DataBind();
            ddlvendedor.Items.Insert(0, new ListItem("Seleccione", "0"));
        }

        internal static void ListarDistrito(DropDownList cbo,string idprovi,string iddepacomer)
        {
            UbigeoDAO db = new UbigeoDAO();
            cbo.DataSource = db.ListarDistrito(idprovi, iddepacomer);
            cbo.DataTextField = "DISTRITO";
            cbo.DataValueField = "UBIGEO1";
            cbo.DataBind();
            cbo.Items.Insert(0, new ListItem("Seleccione", "0"));
        }

        internal static void ListarProvincia(DropDownList cbo,string id)
        {
            UbigeoDAO db = new UbigeoDAO();
            cbo.DataSource = db.ListarProvincia(id);
            cbo.DataTextField = "PROVINCIA";
            cbo.DataValueField = "UBIGEO1";
            cbo.DataBind();
            cbo.Items.Insert(0, new ListItem("Seleccione", "0"));
        }

        internal static void ListarDepartamento(DropDownList cbo)
        {
            UbigeoDAO db = new UbigeoDAO();
            cbo.DataSource = db.ListarDepartamento();
            cbo.DataTextField = "DEPARTAM";
            cbo.DataValueField = "UBIGEO1";
            cbo.DataBind();
            cbo.Items.Insert(0, new ListItem("Seleccione", "0"));
        }

        internal static void Listarproductos(DropDownList cbo)
        {
            ProductoDAO db = new ProductoDAO();
            cbo.DataSource = db.Listar();
            cbo.DataTextField = "descripcion";
            cbo.DataValueField = "Id_prod";
            cbo.DataBind();
            cbo.Items.Insert(0, new ListItem("Seleccione", "0"));
        }

        public static decimal TotalizarGrillaafec(GridView grv, int NumeroColumna)
        {
            decimal total = 0;

            foreach (GridViewRow fila in grv.Rows)
            {
                decimal afecto = Convert.ToDecimal(fila.Cells[7].Text);
                if (afecto != 0)
                {
                    total += Convert.ToDecimal(fila.Cells[NumeroColumna].Text);
                }
            }
            return total;
        }

        public static void ListarMercado(DropDownList cbo)
        {
            MercadoDAO db = new MercadoDAO();
            cbo.DataSource = db.Listar();
            cbo.DataTextField = "ZM";
            cbo.DataValueField = "IdMercado";
            cbo.DataBind();
        }
        public static void ListarMercadoxZona(DropDownList cbo,string zona)
        {
            MercadoDAO db = new MercadoDAO();
            cbo.DataSource = db.MercadoxZona(zona);
            cbo.DataTextField = "NombreLargo";
            cbo.DataValueField = "IdMercado";
            cbo.DataBind();
            cbo.Items.Insert(0, new ListItem("Seleccione", "0"));
        }
        internal static void Agregar_Detalles(DataTable detalles, string id, string descripcion, decimal precio, decimal cantidad, decimal peso,decimal igvsub ,decimal subtotal)
        {
            DataRow fila = detalles.NewRow();
            //llena sus columnas
            fila["idArticulo"] = id;
            fila["Descripcion"] = descripcion;
            fila["preciounidad"] = precio;
            fila["cantidad"] = cantidad;
            fila["peso"] = peso;
            fila["igvsub"] = igvsub;
            fila["subtotal"] = subtotal;
            //Agrega la fila al datatable)
            detalles.Rows.Add(fila);
        }

        internal static decimal TotalizarGrilla(GridView grvDetalles, int v)
        {
            decimal total = 0;
            foreach (GridViewRow fila in grvDetalles.Rows)
            {
                total += Convert.ToDecimal(fila.Cells[v].Text);
            }
            return total;
        }

        public static void ListarFamilia(DropDownList cbo)
        {
            FamiliaDAO db = new FamiliaDAO();
            cbo.DataSource = db.Listar();
            cbo.DataTextField = "nombre";
            cbo.DataValueField = "Id_Familia";
            cbo.DataBind();
        }
        public static void ListarMarca(DropDownList cbo)
        {
            MarcaDAO db = new MarcaDAO();
            cbo.DataSource = db.Listar();
            cbo.DataTextField = "Descripcion";
            cbo.DataValueField = "Id_Marca";
            cbo.DataBind();
        }
        public static void ListarIGV(DropDownList cbo)
        {
            IGVDAO db = new IGVDAO();
            cbo.DataSource = db.Listar();
            cbo.DataTextField = "Nombre";
            cbo.DataValueField = "IdAfecto";
            cbo.DataBind();
        }
        //public static void ListarMoneda(DropDownList cbo)
        //{
        //    MonedaDAO db = new MonedaDAO();
        //    cbo.DataSource = db.Listar();
        //    cbo.DataTextField = "Desc_Large";
        //    cbo.DataValueField = "Id_Moneda";
        //    cbo.DataBind();
        //}
        public static void ListarUnidad(DropDownList cbo)
        {
            UniMedDAO db = new UniMedDAO();
            cbo.DataSource = db.Listar();
            cbo.DataTextField = "Descripcion";
            cbo.DataValueField = "Id_Umedida";
            cbo.DataBind();
        }
    }
}