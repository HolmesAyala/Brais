<%@ Page Title="" Language="C#" MasterPageFile="~/View/MPHeaderFooter.master" AutoEventWireup="true" CodeFile="~/Controller/Register.aspx.cs" Inherits="View_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .auto-style2 {
        text-align: center;
    }
    .auto-style3 {
        width: 635px;
    }
    .auto-style4 {
        width: 635px;
        height: 20px;
    }
    .auto-style5 {
        height: 20px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <!--Banner-->
    </div>
    <div>

        <table class="auto-style1">
            <tr>
                <td colspan="2">&nbsp;</td>

            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="30px" ForeColor="#33CCFF" Text="Crear Una Cuenta"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Tipo De Documento"></asp:Label>
&nbsp;&nbsp;
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem Value="1">C.C</asp:ListItem>
                        <asp:ListItem Value="2">T.I</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Tipo De Afliliacion"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RadioButtonList ID="Tipo" runat="server" Font-Bold="True" Width="125px">
                        <asp:ListItem Value="1">EPS</asp:ListItem>
                        <asp:ListItem Value="2">Particular</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;
                    <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="Numero De Documento"></asp:Label>
&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TB_id" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Correo Electronico"></asp:Label>
&nbsp;&nbsp;
                    <asp:TextBox ID="TB_email" runat="server" TextMode="Email"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Nombres"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TB_name" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="Clave"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TB_pasword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;
                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Apellidos"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TB_lastName" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="Confirmar Clave"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TB_password2" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Fecha Nacimiento"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TB_date" runat="server" TextMode="Date"></asp:TextBox>
                </td>
                <td class="auto-style5"></td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <asp:Button ID="Button1" runat="server" BackColor="#66FFFF" Font-Bold="True" Font-Names="Arial" Font-Size="20px" ForeColor="#0066FF" OnClick="Button1_Click" Text="Registrarse" />
                </td>
            </tr>
        </table>

    </div>
</asp:Content>

