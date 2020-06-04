<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="NueCliente.aspx.cs" Inherits="PedidosCegal.NueCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="well well-sm text-primary text-center">
        <h2>Nuevo Cliente</h2>
    </div>
     <div class="form-horizontal">
        <fieldset>
            <div class="form-horizontal form-group" style="border:solid">
             <label style="font-size:large; font-family:Arial">Establecimiento Comercial</label>
            <div class="form-group">
                <label class="control-label col-md-2">Zona-Mercado: </label>
                <div class="col-md-2">
                    <asp:DropDownList runat="server" ID="ddlmercado" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">N° de puesto: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtnumeropuesto" CssClass="form-control"></asp:TextBox>
                </div>
            </div>    
            <div class="form-group">
                <label class="control-label col-md-2">Razón social: </label>
                <div class="col-md-6">
                    <asp:TextBox runat="server" ID="txtrazonsocial" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Denominacion: </label>
                <div class="col-md-2">
                    <asp:Dropdownlist runat="server" ID="ddldenominacion" CssClass="form-control"></asp:Dropdownlist>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Califica: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtcalifica" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">RUC: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtruc" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
             <div class="form-group">
                <label class="control-label col-md-2">Dirección: </label>
                <div class="col-md-6">
                    <asp:TextBox runat="server" ID="txtdireccion" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Departamento: </label>
                <div class="col-md-4">
                    <asp:DropDownList runat="server" ID="ddldepartamentocomercial" CssClass="form-control" OnSelectedIndexChanged="ddldepartamentocomercial_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </div>
            </div>

            <div class="form-group">
                <label class="control-label col-md-2">Provincias: </label>
                <div class="col-md-4">
                    <asp:DropDownList runat="server" ID="ddlprovincicomercial" CssClass="form-control" OnSelectedIndexChanged="ddlprovincicomercial_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Distrito: </label>
                <div class="col-md-4">
                    <asp:DropDownList runat="server" ID="ddldistritocomercial" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
             <div class="form-group">
                <label class="control-label col-md-2">Referencia: </label>
                <div class="col-md-6">
                    <asp:TextBox runat="server" ID="txtreferenciacomercial" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <label class="control-label col-md-2">Teléfono: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txttelefonocomercial" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            </div>

            <div class="form-group form-horizontal"  style="border:solid">
                <label style="font-size:large; font-family:Arial">Datos del propietario</label>
            <div class="form-group">
                <label class="control-label col-md-2">Apelldios y Nombres: </label>
                <div class="col-md-6">
                    <asp:TextBox runat="server" ID="txtnombreapellido" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Domicilio: </label>
                <div class="col-md-6">
                    <asp:TextBox runat="server" ID="txtdomicilio" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Departamento: </label>
                <div class="col-md-4">
                    <asp:DropDownList runat="server" ID="dlldepartamentopropietario" CssClass="form-control" OnSelectedIndexChanged="dlldepartamentopropietario_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </div>
            </div>

            <div class="form-group">
                <label class="control-label col-md-2">Provincias: </label>
                <div class="col-md-4">
                    <asp:DropDownList runat="server" ID="ddlprovinciaspropietario" CssClass="form-control" OnSelectedIndexChanged="ddlprovinciaspropietario_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Distrito: </label>
                <div class="col-md-4">
                    <asp:DropDownList runat="server" ID="ddldistritopropietario" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Referencia: </label>
                <div class="col-md-6">
                    <asp:TextBox runat="server" ID="txtreferenciapropietario" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">DNI: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtdni" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Telefono: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txttelefonodomicilio" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Garantia Créd.: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtgarantia" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Credito maximo: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtcredito" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Observación: </label>
                <div class="col-md-6">
                    <asp:TextBox runat="server" ID="txtobservacion" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            </div>
             <div class="form-actions col-md-offset-2">
                <asp:Button runat="server" ID="btnguardar" Text="Guardar" CssClass="btn btn-primary" OnClick="btnguardar_Click"/> |
                <a href="ManteCliente.aspx">Regresar al listado</a>
            </div>
        </fieldset>
    </div>
   
    <div id="myModal" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="background-color: #D6EAF8">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Cuadro de Mensajes</h4>
                </div>
                <div class="modal-body">
                    <div class="msgcentrado">
                        <asp:Label Text="" ID="lblmesaje" runat="server" Style="font-size: 18px"></asp:Label>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
