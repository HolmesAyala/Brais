<%@ Page Title="" Language="C#" MasterPageFile="~/View/Administrador/MPAdministrador.master" AutoEventWireup="true" CodeFile="~/Controller/Administrador/parametros.aspx.cs" Inherits="View_Administrador_parametros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenido" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td colspan="2" rowspan="4" style="text-align: center">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#00CCFF" Text="Consultorios"></asp:Label>
                <br />
                <asp:GridView ID="GridView3" runat="server" Width="364px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
            </td>
            <td colspan="2" style="height: 20px; text-align: left">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#00CCFF" Text="Agregar Consultorio"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 20px; text-align: left">&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 20px; text-align: left; width: 117px">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Text=" ID Consultorio"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label4" runat="server" Font-Bold="True">Ubicacion</asp:Label>
            </td>
            <td style="height: 20px; text-align: left">
                <asp:TextBox ID="TextBox1" runat="server" Width="166px" placeholder="Nombre Consultorio (Unico)"></asp:TextBox>
                <br />
                <br />
                <asp:TextBox ID="TextBox2" runat="server" Width="166px" placeholder="Localizacion"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 20px; text-align: center">
                <asp:Button ID="Button1" runat="server" Text="Agregar" Width="56px" />
            </td>
        </tr>
        <tr>
            <td style="height: 20px" colspan="4"><br /><hr style="color:deepskyblue" /></td>
        </tr>
        <tr>
            <td style="width: 466px; height: 20px">&nbsp;</td>
            <td style="width: 333px; height: 20px; text-align: center;">
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#00CCFF" Text="Tiempos"></asp:Label>
                </td>
            <td colspan="2" style="height: 20px">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 466px; height: 20px">&nbsp;</td>
            <td style="width: 333px; height: 20px">&nbsp;</td>
            <td colspan="2" style="height: 20px">&nbsp;</td>
        </tr>
    </table>
</asp:Content>

