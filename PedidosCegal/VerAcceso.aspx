<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="VerAcceso.aspx.cs" Inherits="PedidosCegal.VerAcceso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="well well-sm text-primary text-center">
        <h2>Ver el Acceso del personal</h2>
    </div>
    <asp:TextBox runat="server" ID="txtcodigo" CssClass="hide"></asp:TextBox>
    <div class="form-horizontal">
        <fieldset>
            <div class="form-group">
                <label class="control-label col-md-2">Personal:</label>
                <div class="col-md-2">
                    <asp:DropDownList runat="server" ID="ddlpersonal" CssClass="form-control" Enabled="false"></asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Usuario:</label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtusuario" Enabled="false"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Clave:</label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtclave" type="password" Enabled="false"></asp:TextBox>
                </div>

            </div>
        </fieldset>
    </div>
    <div class="form-actions col-md-offset-2">
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
