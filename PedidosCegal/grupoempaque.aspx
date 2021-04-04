<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="grupoempaque.aspx.cs" Inherits="PedidosCegal.grupoempaque" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="well well-sm text-primary text-center">
        <h2>CLASIFICACION DE PRODUCTOS POR PAQUETES</h2>
    </div>
    <div class="form-horizontal">
        <fieldset>            
            <div class="form-group">
                <label class="control-label col-md-2">Desde: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtfechai" CssClass="form-control" type="date"></asp:TextBox>
                </div>
                <label class="control-label col-md-1">Hasta: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtfechaf" CssClass="form-control" type="date"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-2">
                </div>
                <div class="col-md-2">
                    <asp:Button runat="server" ID="btnbsucar" CssClass="btn btn-success" Text="Buscar" OnClick="btnbsucar_Click" />
                </div>
            </div>
        </fieldset>
    </div>
    <div id="myModal" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content sidebar" style="display:block;overflow-x:auto;width:132%">
                <div class="modal-header" style="background-color: #D6EAF8">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Pedidos</h4>
                </div>
                <div class="modal-body">
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Arial" Font-Size="10pt" Height="724px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="10%" EnableTheming="True" SizeToReportContent="True">
                        <LocalReport ReportPath="Reportes/productoagrupado.rdlc"></LocalReport>
                    </rsweb:ReportViewer>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    <div id="myModalerror" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content sidebar" style="display:block;overflow-x:auto;width:132%">
                <div class="modal-header" style="background-color: #D6EAF8">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Pedidos</h4>
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
