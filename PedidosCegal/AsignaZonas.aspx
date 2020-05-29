<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="AsignaZonas.aspx.cs" Inherits="PedidosCegal.AsignaZonas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="well well-sm text-primary text-center">
        <h2>Asignar zona a vendedores</h2>
    </div>
    <div class="form-group">
        <label class="control-label col-md-2">Listado de vendedores: </label>
        <div class="col-md-2">
            <asp:DropDownList runat="server" ID="ddlvendedor" CssClass="form-control"></asp:DropDownList>
        </div>
    </div>
    <div class="form-group">
        <label class="control-label col-md-2">Lista de zonas: </label>
        <div class="col-md-3">
            <asp:DropDownList runat="server" ID="ddlzona" CssClass="form-control"></asp:DropDownList>
        </div>
    </div>
    <div class="form-actions col-md-offset-2">
        <asp:Button runat="server" ID="btnguardar" Text="Agregar" CssClass="btn btn-primary" OnClick="btnguardar_Click" />
    </div>
    <br />
    <asp:UpdatePanel runat="server" ID="udpasigna"  style="display:block;overflow-x:auto">
        <ContentTemplate>
                <asp:GridView class="table table-hover table-striped" runat="server" ID="grvasigna" AutoGenerateColumns="false" Width="100%" GridLines="None" PageSize="10" AllowPaging="true" OnPageIndexChanging="grvasigna_PageIndexChanging" OnRowCommand="grvasigna_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="Id_asigna" HeaderStyle-CssClass="hide" FooterStyle-CssClass="hide" ItemStyle-CssClass="hide"/>
                        <asp:BoundField DataField="DescripCorta" HeaderText="Cód. Zona"/>
                        <asp:BoundField DataField="NombreZona" HeaderText="Nombre de la zona" />
                        <asp:BoundField DataField="Nombres" HeaderText="Vendedor"/>
                        <asp:TemplateField HeaderText="Operaciones" ItemStyle-CssClass="hidden-tablet" HeaderStyle-CssClass="hidden-tablet" >
                            <ItemTemplate>
                                <asp:Button CssClass="btn btn-danger" Text="X" ID="Eliminar" runat="server" CommandName="Eliminar" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' title="Eliminar" OnClientClick="return confirm('¿Desea eliminar la asignación?');"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <HeaderStyle BackColor="#337ab7" Font-Bold="true" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
                </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div id="myModal" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="background-color: #D6EAF8">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Cuadro de Mensajes</h4>
                </div>
                <div class="modal-body">
                    <div class="msgcentrado">
                        <asp:Label Text="" ID="txtmensaje" runat="server" Style="font-size: 18px"></asp:Label>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
