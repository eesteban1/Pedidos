<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="VerPersonal.aspx.cs" Inherits="PedidosCegal.VerPersonal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="well well-sm text-primary text-center">
        <h2>Ver Personal</h2>
    </div>
    <div class="form-horizontal">
        <fieldset>
            <div class="form-horizontal form-group">
                <div class="form-group">
                    <label class="control-label col-md-2">Apellidos*: </label>
                    <div class="col-md-2">
                        <asp:TextBox runat="server" ID="txtapepat" CssClass="form-control" placeholder="Paterno" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <asp:TextBox runat="server" ID="txtapemat" CssClass="form-control" placeholder="Materno" Enabled="false"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-2">Nombres*: </label>
                    <div class="col-md-2">
                        <asp:TextBox runat="server" ID="txtnombre" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-2">Cargo: </label>
                    <div class="col-md-2">
                        <asp:DropDownList runat="server" ID="ddlcargo" CssClass="form-control" Enabled="false"></asp:DropDownList>
                    </div>

                </div>
                <div class="form-group">
                    <label class="control-label col-md-2">DNI: </label>
                    <div class="col-md-2">
                        <asp:TextBox runat="server" ID="txtdni" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-2">Domicilio: </label>
                    <div class="col-md-4">
                        <asp:TextBox runat="server" ID="txtdomicilio" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-2">Departamento: </label>
                    <div class="col-md-2">
                        <asp:DropDownList runat="server" ID="ddldepartamento" CssClass="form-control" AutoPostBack="true" Enabled="false"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-2">Provincia: </label>
                    <div class="col-md-2">
                        <asp:DropDownList runat="server" ID="ddlprovincia" CssClass="form-control" AutoPostBack="true" Enabled="false"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-2">Distrito: </label>
                    <div class="col-md-2">
                        <asp:DropDownList runat="server" ID="ddldistrito" CssClass="form-control" Enabled="false"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-2">Teléfono: </label>
                    <div class="col-md-2">
                        <asp:TextBox runat="server" ID="txttelefono" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                    <label class="col-md-1 ">Fecha Nacimiento: </label>
                    <div class="col-md-2" style="width:180px">
                        <asp:TextBox runat="server" ID="txtfechanac" CssClass="form-control" type="date" Enabled="false"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-2">Sexo*: </label>
                    <div class="col-md-2">
                        <asp:RadioButtonList runat="server" ID="rdbsexo"  Enabled="false">
                            <asp:ListItem Text="Masculino" Value="M"></asp:ListItem>
                            <asp:ListItem Text="Femenino" Value="F"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <label class="col-md-1">Fecha Ingreso: </label>
                    <div class="col-md-2" style="width:180px">
                        <asp:TextBox runat="server" ID="txtfechaingre" CssClass="form-control" type="date" Enabled="false"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-2 control-label">Estado civil: </label>
                    <div class="col-md-2">
                        <asp:DropDownList runat="server" ID="ddlcivil" CssClass="form-control"  Enabled="false">
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
                        <asp:TextBox runat="server" ID="txtipss" CssClass="form-control"  Enabled="false"></asp:TextBox>
                    </div>
                    <label class="control-label col-md-1">N° Hijos: </label>
                    <div class="col-md-1" style="width:180px">
                        <asp:TextBox runat="server" ID="txthijos" CssClass="form-control" Enabled="false"></asp:TextBox>
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
                <a href="MantePersonal.aspx">Regresar al listado</a>
            </div>
        </fieldset>
    </div>
</asp:Content>
