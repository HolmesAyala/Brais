<%@ Page Title="" Language="C#" MasterPageFile="~/View/MPHeaderFooter.master" AutoEventWireup="true" CodeFile="~/Controller/Login.aspx.cs" Inherits="View_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        *{
            margin: 0;
            padding: 0;
            font-family: Arial, sans-serif;
        }
        .estilo_boton:hover{
            cursor: pointer;
            color: #FFFFFF;
            background-color: aqua;
            border: 4px solid aqua;
        }
        table {
            width:100%
        }
        td {
            height: 30px;
        }
        img.icono_usuario {
            width: 40px;
            height: 54px;
        }
        td.imagen {
            text-align: center;
        }
        td.label {
            text-align: right;
            width: 50%;
        }
        td.textBox{
            width: 50%;
        }
        td.boton {
            text-align: center;
        }
        .estilo_boton {
            color: #FFFFFF;
            background-color: deepskyblue;
            border: 4px solid deepskyblue;
            font-size: 15px;
            border-radius: 5px;
        }
        .estilo_Text{
           
        }
        .informacion {
            text-align: center;
        }
        .label_informacion{
            color: #FF0000;
        }
        .RFV_estilos {
            height: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <table>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td class="imagen" colspan="2">
                <img alt="Icono_Usuario" class="icono_usuario"  src="../Imagen/icono_usuario.png" />
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td Class="label" style="height: 30px">
                <asp:Label ID="L_Identificacion" runat="server" Text="Identificación: " Width="20%"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td class="auto-style2">
                <asp:TextBox ID="Tx_Identificacion" runat="server" Width="25%" CssClass="estilo_Text" TextChanged="OnTextBoxTextChanged"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFV_identificacion" runat="server" ControlToValidate="Tx_Identificacion" ErrorMessage="La identificación es obligatoria" CssClass="auto-style1" ToolTip="La identificación es obligatoria">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td Class="label">
                <asp:Label ID="L_Contrasena" runat="server" Text="Contraseña: " width="20%"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td class="textBox">
                <asp:TextBox ID="Tx_contrasena" runat="server" Width="25%" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFV_Contrasena" runat="server" ErrorMessage="La Contraseña es obligatoria" CssClass="RFV_estilos" ToolTip="La Contraseña es obligatoria" ControlToValidate="Tx_contrasena">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="informacion">
                <asp:HyperLink ID="Hp_olvidoContrasena" runat="server" NavigateUrl="~/View/RecuperarContrasenaPasoUno.aspx">¿Olvido su contraseña?</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="informacion">
                <asp:Label ID="L_Informacion" runat="server" CssClass="label_informacion"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="boton">
                <asp:Button class="BTN BTN_Azul" ID="B_Ingresar" runat="server" Text="Ingresar" OnClick="B_Ingresar_Click"/>
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
    </table>
    
</asp:Content>

