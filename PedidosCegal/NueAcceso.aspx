<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="NueAcceso.aspx.cs" Inherits="PedidosCegal.NueAcceso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="well well-sm text-primary text-center">
        <h2>Nuevo Acceso</h2>
    </div>
    <div class="form-horizontal">
        <fieldset>
            <div class="form-group">
                <label class="control-label col-md-2">Personal:</label>
                <div class="col-md-2">
                    <asp:DropDownList runat="server" ID="ddlpersonal" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Usuario:</label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtusuario"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Clave:</label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtclave" type="password"></asp:TextBox>
                </div>

            </div>
        </fieldset>
    </div>
    <div class="form-actions col-md-offset-2">
        <asp:Button runat="server" ID="btnguardar" Text="Guardar" CssClass="btn btn-primary" OnClick="btnguardar_Click" />|
                <a href="ManteAcceso.aspx">Regresar al listado</a>
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
