<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="VerMercado.aspx.cs" Inherits="PedidosCegal.VerMercado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="well well-sm text-primary text-center">
        <h2>Ver Mercado</h2>
    </div>
    <div class="form-horizontal">
        <fieldset>
            <asp:TextBox runat="server" ID="txtid" CssClass="hide"></asp:TextBox>
            <div class="form-group">
                <label class="control-label col-md-2">Código: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtcodigo" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Descripción de la zona: </label>
                <div class="col-md-2">
                    <asp:DropDownList runat="server" ID="ddlzona" CssClass="form-control" Enabled="false"></asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Nombre del mercado: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtmercado" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Dirección: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtdireccion" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Departamento: </label>
                <div class="col-md-2">
                    <asp:DropDownList runat="server" ID="ddldepartamento" CssClass="form-control" Enabled="false"></asp:DropDownList>
                </div>
            </div>

            <div class="form-group">
                <label class="control-label col-md-2">Provincias: </label>
                <div class="col-md-2">
                    <asp:DropDownList runat="server" ID="ddlprovincia" CssClass="form-control" Enabled="false"></asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Distrito: </label>
                <div class="col-md-2">
                    <asp:DropDownList runat="server" ID="ddldistrito" CssClass="form-control" Enabled="false"></asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Observación: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtobservacion" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
            </div>
            <div class="form-actions col-md-offset-2">
                <a href="ManteMercados.aspx">Regresar al listado</a>
            </div>
        </fieldset>
    </div>
</asp:Content>
