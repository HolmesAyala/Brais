<%@ Page Title="" Language="C#" MasterPageFile="~/View/Usuario/MPUsuario.master" AutoEventWireup="true" CodeFile="~/Controller/Usuario/cambiarCita.aspx.cs" Inherits="View_Usuario_cambiarCita" EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="contenido" Runat="Server">
    <table style="width: 100%">
        <tbody style="text-align: center">
        <tr>
            <td colspan="2" style="height: 20px; text-align: center">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#33CCFF">Seleccione la cita a cambiar</asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 20px;"></td>
            <td style="height: 20px"></td>
        </tr>
        <tr>
            <td colspan="2" style="height: 20px; padding:0px 0px 20% 20%; ">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="1000px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="nm" HeaderText="Medico" />
                        <asp:BoundField DataField="da" HeaderText="Dia" />
                        <asp:BoundField DataField="h_i" HeaderText="Hora Inicio" />
                        <asp:BoundField DataField="h_f" HeaderText="Hora Fin" />
                        <asp:BoundField HeaderText="Especialidad" DataField="es" />
                        <asp:TemplateField HeaderText="Seleccion">
                            <ItemTemplate>
                                <asp:Button ID="b_cam" runat="server" OnClick="b_cam_Click" Text="Cambiar" CommandArgument='<%# Eval("ci") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
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

