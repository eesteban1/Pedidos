

<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="NueProducto.aspx.cs" Inherits="PedidosCegal.NueProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <div class="well well-sm text-primary text-center">
        <h2>Nuevo Producto</h2>
    </div>
     <div class="form-horizontal" id="contenedor">
        <fieldset>
            <div class="form-group">
                <label class="control-label col-md-2">Código: </label>
                <div class="col-md-6">
                    <asp:TextBox runat="server" ID="txtcodigo" CssClass="form-control" MaxLength="32"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Descripción del producto: </label>
                <div class="col-md-6">
                    <asp:TextBox runat="server" ID="txtdescripcion" CssClass="form-control" MaxLength="100"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Familia: </label>
                <div class="col-md-4">
                    <asp:DropDownList runat="server" ID="ddlfamilia" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Marca: </label>
                <div class="col-md-4">
                    <asp:DropDownList runat="server" ID="ddlmarca" CssClass="form-control"></asp:DropDownList>
                 </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Afecto IGV: </label>
                <div class="col-md-2">
                    <asp:DropDownList runat="server" ID="ddligv" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Medida: </label>
                <div class="col-md-2">
                    <asp:DropDownList runat="server" ID="ddlunidadmedida" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Peso: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtpeso" CssClass="form-control" type="number" Text="0.00"  MaxLength="25"></asp:TextBox><%--onkeypress="return Enter(this, event)"--%>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Precio Compra S/: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtpreciocompras" CssClass="form-control" Text="0.00" type="number"  MaxLength="25"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Precio Compra $: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtpreciocomprad" CssClass="form-control" Text="0.00" type="number"  MaxLength="25"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Precio venta S/: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtprecioventas" CssClass="form-control" Text="0.00" type="number"  MaxLength="25"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Precio venta $: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtprecioventad" CssClass="form-control" Text="0.00" type="number" MaxLength="25"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Stock máximo: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtstockmax" CssClass="form-control" Text="0" type="number"  MaxLength="25"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Stock mínimo: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtstockmin" CssClass="form-control" Text="0" type="number"  MaxLength="25"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Stock actual: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtstockact" CssClass="form-control" Text="0" type="number"  MaxLength="25"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Observacion: </label>
                <div class="col-md-6">
                    <asp:TextBox runat="server" ID="txtobservacion" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-actions col-md-offset-2">
                <asp:Button runat="server" ID="btnguardar" Text="Guardar" CssClass="btn btn-primary" OnClick="btnguardar_Click" OnClientClick="return confirm('¿Desea guardar el producto?');"/> |
                <a href="ManteProducto.aspx">Regresar al listado</a>
            </div>
        </fieldset>

       <script type='text/javascript'>
            $("#contenedor").on("keyup", "input.number", function (event) {
                $('input.number').keyup(function (event) {
                    if (event.which >= 37 && event.which <= 40) {
                        event.preventDefault();
                    }

                    $(this).val(function (index, value) {
                        return value
                            .replace(/\D/g, "")
                            .replace(/\B(?=(\d{3})+(?!\d)\.?)/g, ",");
                    });
                });
            });
    </script>

<%--             <SCRIPT language=Javascript>
       <!--
    function isNumberKey(evt) {
        var charCode = (evt.which) ? evt.which : evt.keyCode;
        if (charCode != 46 && charCode > 31
            && (charCode < 48 || charCode > 57))
            return false;

        return true;
    }
       //-->
    </SCRIPT>--%>



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
                        <asp:Label Text="" ID="Label1" runat="server" Style="font-size: 18px"></asp:Label>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    <div class="text-primary text-success text-center">
        <asp:label runat="server" ID="lblmesaje"></asp:label>
    </div>



</asp:Content>
