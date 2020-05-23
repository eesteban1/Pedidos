<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ModPersonal.aspx.cs" Inherits="PedidosCegal.ModPersonal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="well well-sm text-primary text-center">
        <h2>Modificar Personal</h2>
    </div>
    <div class="form-horizontal">
        <fieldset>
            <div class="form-horizontal form-group">
                <asp:TextBox runat="server" ID="txtcodigo" Visible="false"></asp:TextBox>
                <div class="form-group">
                    <label class="control-label col-md-2">Apellidos*: </label>
                    <div class="col-md-2">
                        <asp:TextBox runat="server" ID="txtapepat" CssClass="form-control" placeholder="Paterno"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <asp:TextBox runat="server" ID="txtapemat" CssClass="form-control" placeholder="Materno"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-2">Nombres*: </label>
                    <div class="col-md-2">
                        <asp:TextBox runat="server" ID="txtnombre" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-2">Cargo: </label>
                    <div class="col-md-2">
                        <asp:DropDownList runat="server" ID="ddlcargo" CssClass="form-control"></asp:DropDownList>
                    </div>

                </div>
                <div class="form-group">
                    <label class="control-label col-md-2">DNI: </label>
                    <div class="col-md-2">
                        <asp:TextBox runat="server" ID="txtdni" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-2">Domicilio: </label>
                    <div class="col-md-4">
                        <asp:TextBox runat="server" ID="txtdomicilio" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-2">Departamento: </label>
                    <div class="col-md-2">
                        <asp:DropDownList runat="server" ID="ddldepartamento" CssClass="form-control" OnSelectedIndexChanged="ddldepartamento_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-2">Provincia: </label>
                    <div class="col-md-2">
                        <asp:DropDownList runat="server" ID="ddlprovincia" CssClass="form-control" OnSelectedIndexChanged="ddlprovincia_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-2">Distrito: </label>
                    <div class="col-md-2">
                        <asp:DropDownList runat="server" ID="ddldistrito" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-2">Teléfono: </label>
                    <div class="col-md-2">
                        <asp:TextBox runat="server" ID="txttelefono" CssClass="form-control"></asp:TextBox>
                    </div>
                    <label class="col-md-1 ">Fecha Nacimiento: </label>
                    <div class="col-md-2" style="width:180px">
                        <asp:TextBox runat="server" ID="txtfechanac" CssClass="form-control" type="date"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-2">Sexo*: </label>
                    <div class="col-md-2">
                        <asp:RadioButtonList runat="server" ID="rdbsexo">
                            <asp:ListItem Text="Masculino" Value="M"></asp:ListItem>
                            <asp:ListItem Text="Femenino" Value="F"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <label class="col-md-1">Fecha Ingreso: </label>
                    <div class="col-md-2" style="width:180px">
                        <asp:TextBox runat="server" ID="txtfechaingre" CssClass="form-control" type="date"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-2 control-label">Estado civil: </label>
                    <div class="col-md-2">
                        <asp:DropDownList runat="server" ID="ddlcivil" CssClass="form-control">
                            <asp:ListItem Text="Soltero/a" Value="SOLTERO"></asp:ListItem>
                            <asp:ListItem Text="Comprometido/a"  Value="COMPROMETIDO"></asp:ListItem>
                            <asp:ListItem Text="En Relación" Value="EN RELACION"></asp:ListItem>
                            <asp:ListItem Text="Casado/a" Value="CASADO"></asp:ListItem>
                            <asp:ListItem Text="Separado/a" Value="SEPARADO"></asp:ListItem>
                            <asp:ListItem Text="Divorciado/a" Value="DIVORCIADO"></asp:ListItem>
                            <asp:ListItem Text="Viudo/a" Value="VIUDO"></asp:ListItem>
                            <asp:ListItem Text="Noviazgo" Value="NOVIAZGO"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <label class="control-label col-md-1">N° IPSS: </label>
                    <div class="col-md-1" style="width:180px">
                        <asp:TextBox runat="server" ID="txtipss" CssClass="form-control"></asp:TextBox>
                    </div>
                    <label class="control-label col-md-1">N° Hijos: </label>
                    <div class="col-md-1" style="width:180px">
                        <asp:TextBox runat="server" ID="txthijos" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-2 control-label">Observacion</label>
                    <div class="col-md-2">
                        <asp:TextBox runat="server" ID="txtobservacion" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="form-actions col-md-offset-2">
                <asp:Button runat="server" ID="btnguardar" Text="Guardar" CssClass="btn btn-primary" OnClick="btnguardar_Click"/> |
                <a href="MantePersonal.aspx">Regresar al listado</a>
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
