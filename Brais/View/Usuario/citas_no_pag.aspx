<%@ Page Title="" Language="C#" MasterPageFile="~/View/Usuario/MPUsuario.master" AutoEventWireup="true" CodeFile="~/Controller/Usuario/citas_no_pag.aspx.cs" Inherits="View_Usuario_citas_no_pag" EnableEventValidation="false"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenido" Runat="Server">
    <style>
        .payment{
            border-radius:3px;
        }

        .auto-style1 {
            height: 20px;
            text-align: center;
        }

    </style>
    <table style="width: 100%">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#33CCFF" Text="Citas No Pagadas"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1" colspan="2">
                <asp:Label ID="LB_no_reg" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 20px; text-align: center; margin:0 15%;">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="hora_inicio" HeaderText="Hora Inicio" />
                        <asp:BoundField DataField="hora_fin" HeaderText="Hora Fin" />
                        <asp:BoundField DataField="dia" HeaderText="Fecha" />
                        <asp:TemplateField HeaderText="Pagar Cita">
                            <ItemTemplate>
                                <asp:Button ID="Button1" runat="server" BackColor="Red" Font-Bold="True" Font-Size="13pt" ForeColor="White" Text="Pagar" CssClass="payment" CommandArgument='<%# Eval("id") %>' OnClick="Button1_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#594B9C" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#33276A" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="height: 20px">&nbsp;</td>
            <td style="height: 20px">&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 20px">&nbsp;</td>
            <td style="height: 20px">&nbsp;</td>
        </tr>
    </table>
</asp:Content>

