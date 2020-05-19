<%@ Page Title="" Language="C#" MasterPageFile="~/Home2.Master" AutoEventWireup="true" CodeBehind="MantePedidoVendedor.aspx.cs" Inherits="PedidosCegal.MantePedidoVendedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="form-group">
                                <label class="col-lg-1 control-label">Fecha Inicial: </label>
                                <div class="col-lg-3">
                                    <asp:TextBox runat="server" ID="txtfechainicia" type="date" CssClass="form-control"></asp:TextBox>
                                </div>
                                <label class="col-lg-1 control-label">Fecha Final: </label>
                                <div class="col-lg-3">
                                    <asp:TextBox runat="server" ID="txtfechafinal" type="date" CssClass="form-control"></asp:TextBox>
                                </div>
                                <br />
                                <div class=" col-sm-2" style="text-align:center">
                                    <asp:Button runat="server" ID="btnbuscar" CssClass="btn btn-success" Text="Buscar" OnClick="btnbuscar_Click" />
                                </div>
                                <div class=" col-sm-2" style="text-align:center">
                                    <asp:Button runat="server" CssClass="btn btn-primary" ID="btnnuevo" Text="Nuevo Pedido" OnClick="btnnuevo_Click"/>
                                </div>
                            </div>
                            <br />
                            <br />
                            <div class="col-sm-12" style="display:block;overflow-x:auto">
                                <asp:UpdatePanel runat="server" ID="updDetalle">
                                    <ContentTemplate>
                                        <asp:GridView runat="server" ID="grvDetalles" CssClass="table table-striped table-hover" AutoGenerateColumns="false" Width="100%" PageSize="10" EmptyDataText="No se encontraron pedidos." ShowHeaderWhenEmpty="True"  GridLines="None" AllowPaging="true" OnPageIndexChanging="grvDetalles_PageIndexChanging" OnRowCommand="grvDetalles_RowCommand" >
                                            <Columns>
                                                <asp:BoundField DataField="Id_Encab" HeaderText="N° Pedido" />
                                                <asp:BoundField DataField="fechaCheque" HeaderText="Fecha" />
                                                <asp:BoundField DataField="CodNom" HeaderText="Cod y Nombre Cliente" />
                                                <asp:BoundField DataField="Desc_Large" HeaderText="Moneda" />
                                                <asp:BoundField DataField="Total_Venta" HeaderText="Total" />
                                                <asp:TemplateField HeaderText="Operación">
                                                    <ItemTemplate>
                                                        <asp:Button runat="server" CssClass="btn btn-success" CommandName="Ver" Text="V" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' title="Ver" />
                                                        <asp:Button runat="server" CssClass="btn btn-primary" CommandName="Modificar" Text="M" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' title="Modificar" />
                                                        <asp:Button runat="server" CssClass="btn btn-danger" CommandName="Eliminar" Text="X" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' title="Eliminar" OnClientClick="return confirm('¿Desea eliminar el pedido?');"/>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EditRowStyle BackColor="#999999" />
                                            <HeaderStyle BackColor="#337ab7" Font-Bold="true" ForeColor="White" />
                                            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
</asp:Content>
