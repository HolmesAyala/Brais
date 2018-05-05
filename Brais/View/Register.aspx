<%@ Page Title="" Language="C#" MasterPageFile="~/View/MPHeaderFooter.master" AutoEventWireup="true" CodeFile="~/Controller/Register.aspx.cs" Inherits="View_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    *{
        margin-left:auto;
    }
    .auto-style1 {
        width: 100%;
    }
    .auto-style2 {
        text-align: center;
    }
    .auto-style4 {
        width: 522px;
        height: 20px;
    }
    .auto-style5 {
        height: 20px;
    }
    .reg{
        border-radius:5px;
    }
    #opcion{
        font-size:14px;
        font-weight:bold;
    }
    #advertencia{
        font-size:10px;
    }
    .banner{
        border-radius:20px;
    }
    .ancho{
        width:100% !important;
        text-align:center;
    }
        .auto-style6 {
            width: 310px;
        }
        .auto-style7 {
            margin-left: 0;
        }
    .auto-style8 {
        margin-right: 0;
    }
        .auto-style9 {
            width: 522px;
        }
        .auto-style10 {
            width: 369px;
        }
        .auto-style11 {
            width: 369px;
            height: 20px;
        }
        .auto-style12 {
            width: 369px;
            height: 35px;
        }
        .auto-style13 {
            width: 522px;
            height: 35px;
        }
        .auto-style14 {
            height: 35px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

    <asp:Image ID="Image1" runat="server" Height="269px" ImageUrl="~/View/Images/banner02.jpg" Width="1354px" CssClass="ancho banner" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="banner">
        <!--Banner-->
    </div>
    <div>

        <table class="auto-style1">
            <tr>
                <td colspan="4">&nbsp;</td>

            </tr>
            <tr>
                <td class="auto-style2" colspan="4">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="30px" ForeColor="#33CCFF" Text="Crear Una Cuenta"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style10">
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Tipo De Documento"></asp:Label>
&nbsp;&nbsp;
                    </td>
                <td class="auto-style9">
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem Value="1">C.C</asp:ListItem>
                        <asp:ListItem Value="2">T.I</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style6">
                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Tipo De Afliliacion"></asp:Label>
                    &nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="Tipo" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RadioButtonList ID="Tipo" runat="server" Font-Bold="True" Width="125px">
                        <asp:ListItem Value="1">EPS</asp:ListItem>
                        <asp:ListItem Value="2">Particular</asp:ListItem>
                    </asp:RadioButtonList>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td>
                    <span id="opcion">Seleccione su EPS</span>
                    <asp:DropDownList ID="eps" runat="server" CssClass="auto-style8" DataSourceID="ODS_eps" DataTextField="nombre" DataValueField="id">
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ODS_eps" runat="server" SelectMethod="obtenerEps" TypeName="DBEps"></asp:ObjectDataSource>
                    <br />
                    <span id="advertencia">(*Obligatorio solo si escogio la opcion EPS)</span></td>
            </tr>
            <tr>
                <td class="auto-style10">&nbsp;
                    <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="Numero De Documento"></asp:Label>
                </td>
                <td class="auto-style9"><asp:TextBox ID="TB_id" runat="server" Width="117px" CssClass="auto-style7"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TB_id" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Correo Electronico"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TB_email" runat="server" TextMode="Email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TB_email" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style10">&nbsp;
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Nombres"></asp:Label>
                </td>
                <td class="auto-style9"><asp:TextBox ID="TB_name" runat="server" Width="117px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TB_name" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="Clave"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TB_pasword" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TB_pasword" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style12">&nbsp;
                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Apellidos"></asp:Label>
                </td>
                <td class="auto-style13"><asp:TextBox ID="TB_lastName" runat="server" Width="117px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TB_lastName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style14">
                    <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="Confirmar Clave"></asp:Label>
                </td>
                <td class="auto-style14">
                    <asp:TextBox ID="TB_password2" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TB_password2" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style11">
                    &nbsp;
                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Fecha Nacimiento"></asp:Label>
                </td>
                <td class="auto-style4">

                    <asp:TextBox ClientIdMode="Static"  ID="TB_date" runat="server" TextMode="Date" Width="117px" CssClass="auto-style7" onchange=""></asp:TextBox>
                    <script>
                        var hoy = new Date();
                        document.getElementById('TB_date').setAttribute('max', (hoy).toISOString().substring(0,10));
                    </script>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TB_date" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style5" colspan="2"></td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="4">
                    <asp:Button ID="Button1" runat="server" BackColor="#66FFFF" Font-Bold="False" Font-Names="Arial" Font-Size="20px" ForeColor="#0066FF" OnClick="Button1_Click" Text="Registrarse" CssClass="reg" Height="42px" Width="193px" />
                    <br />
                    <br />
                </td>
            </tr>
        </table>

    </div>
</asp:Content>

