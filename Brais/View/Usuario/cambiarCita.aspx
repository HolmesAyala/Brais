<%@ Page Title="" Language="C#" MasterPageFile="~/View/Usuario/MPUsuario.master" AutoEventWireup="true" CodeFile="cambiarCita.aspx.cs" Inherits="View_Usuario_cambiarCita" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenido" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td colspan="2" style="height: 20px; text-align: center">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#33CCFF">Seleccione la cita a cambiar</asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 631px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" style="height: 20px; text-align: center">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="1249px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="nm" HeaderText="Medico" />
                        <asp:BoundField DataField="da" HeaderText="Dia" />
                        <asp:BoundField DataField="h_i" HeaderText="Hora Inicio" />
                        <asp:BoundField DataField="h_f" HeaderText="Hora Fin" />
                        <asp:BoundField HeaderText="Especialidad" DataField="es" />
                    </Columns>
                    <FooterStyle BackColor="#CCCC99" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle BackColor="#F7F7DE" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FBFBF2" />
                    <SortedAscendingHeaderStyle BackColor="#848384" />
                    <SortedDescendingCellStyle BackColor="#EAEAD3" />
                    <SortedDescendingHeaderStyle BackColor="#575357" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

