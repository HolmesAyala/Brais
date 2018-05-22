<%@ Page Title="" Language="C#" MasterPageFile="~/View/Usuario/MPUsuario.master" AutoEventWireup="true" CodeFile="~/Controller/Usuario/citas_no_pag.aspx.cs" Inherits="View_Usuario_citas_no_pag" EnableEventValidation="false"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenido" Runat="Server">
    <style>
        .auto-style1 {
            height: 20px;
            text-align: center;
        }

        td#Tabla{
            margin-bottom: 30px;
        }

        tr#Tabla .GridView1{
            width: 80%;
            margin: 0 auto;
        }

        .BTN_Pagar{
            color: white;
            background-color: red;
            border: 1px solid rgb(0, 77, 99);
            border-radius: 5px;
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
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr id="Tabla" class="Tabla">
            <td colspan="2">
                <asp:GridView ID="GridView1" class="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="10" CellSpacing="5" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" EnableModelValidation="False">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="hora_inicio" HeaderText="Hora Inicio" />
                        <asp:BoundField DataField="hora_fin" HeaderText="Hora Fin" />
                        <asp:BoundField DataField="dia" HeaderText="Fecha" SortExpression="dia" DataFormatString="{0:d}" HtmlEncode=false />
                        <asp:TemplateField HeaderText="Pagar Cita">
                            <ItemTemplate>
                                <asp:Button ID="BTN_Pagar" class="BTN_Pagar" runat="server" Text="Pagar" CommandArgument='<%# Eval("id") %>' OnClick="Button1_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" HorizontalAlign="Center" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
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

