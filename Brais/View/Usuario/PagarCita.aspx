<%@ Page Title="" Language="C#" MasterPageFile="~/View/Usuario/MPUsuario.master" AutoEventWireup="true" CodeFile="~/Controller/Usuario/PagarCita.aspx.cs" Inherits="View_Usuario_PagarCita" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenido" Runat="Server">
    <style>
        .centrar{
            text-align:center;
            padding:0 20%;
        }
        .auto-style1 {
            height: 20px;
            width:30%;
        }
        .auto-style7 {
            width: 28%;
        }
        .auto-style9 {
            height: 20px;
            width: 28%;
        }
        .auto-style10 {
            height: 100%;
            text-align: left;
            width: 257px;
        }
        .auto-style12 {
            width: 19%;
        }
        .auto-style13 {
            width: 19%;
            text-align: center;
        }
        .auto-style14 {
            height: 20px;
        }
        .auto-style15 {
            text-align: center;
        }
    </style>
    <hr style="font-weight:bold;" />
    <div>
        <table style="width: 100%;">
            <tr>
                <td class="auto-style14">
                   
                </td>
                <td class="auto-style15" colspan="2">
                     <asp:Label ID="Label1" runat="server" Text="Pagar"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style9"></td>
                <td class="auto-style12" rowspan="3">
                    <div class="auto-style10">
                        <asp:Label ID="Label2" runat="server" Text="Precio Sin Descuento"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="Label3" runat="server" Text="Descuento Por Afiliado"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="Label4" runat="server" Text="Total"></asp:Label>
                        <br />
                        <br />
                        <br />
                        <br />
                    </div>
                    </td>
                <td class="auto-style13" rowspan="3">
                    <asp:Label ID="Label6" runat="server" Text="$####"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="Label7" runat="server" Text="$####"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="Label8" runat="server" Text="$####"></asp:Label>
                    <br />
                    <br />
                    <br />
                    <asp:Button ID="Button1" runat="server" Height="27px" Text="Pagar" Width="72px" BackColor="Lime" BorderColor="Black" Font-Bold="True" />
                    </td>
                <td class="auto-style1"></td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
    <hr style="font-weight:bold;"/>
    <p style="text-align:center;"><asp:Image ID="Image1" runat="server" ImageUrl="~/View/Images/paypal-logo.png" Width="687px" CssClass="centrar" /></p>
</asp:Content>

