<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ManteMarcas.aspx.cs" Inherits="PedidosCegal.ManteMarcas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3 class="text-center text-success" style="font-family:arial";>Listado de Marcas</h3>
    <div class="well well-sm">
        <a class="btn btn-primary" href="NueMarca.aspx">Nuevo</a>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" style="display:block;overflow-x:auto">
        <ContentTemplate>
            <asp:GridView ID="grvmarcas" runat="server" class="table table-striped table-hover" AutoGenerateColumns="false" Width="100%" GridLines="None" PageSize="10" AllowPaging="true" OnPageIndexChanging="grvmarcas_PageIndexChanging" OnRowCommand="grvmarcas_RowCommand">
                <Columns>
                    <asp:BoundField DataField="Id_Marca" HeaderText="Codigo" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                    <asp:TemplateField HeaderText="" ItemStyle-CssClass="hidden-tablet" HeaderStyle-CssClass="hidden-tablet">
                        <ItemTemplate>
                            <asp:Button CssClass="btn btn-info" Text="M" runat="server" CommandName="Modificar" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' title="Modificar" />
                            <asp:Button CssClass="btn btn-success" Text="V" runat="server" CommandName="Ver" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' title="Ver" />
                            <asp:Button CssClass="btn btn-danger" Text="X" ID="Eliminar" runat="server" CommandName="Eliminar" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' title="Eliminar" OnClientClick="return confirm('¿Desea eliminar la zona?');" />
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
                        <asp:Label Text="La marca se a eliminado correctamente." ID="txtmensaje" runat="server" Style="font-size: 18px"></asp:Label>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
