<%@ Page Title="" Language="C#" MasterPageFile="~/View/Medico/MPMedico.master" AutoEventWireup="true" CodeFile="~/Controller/Medico/HorarioTrabajo.aspx.cs" Inherits="View_Medico_HorarioTrabajo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenido" Runat="Server">
    <!--Hoja De Estilos Para El ListItem-->
    <style>
        .list{
            margin:0 auto;
        }
        .boton{
            border-radius:5px;
            font-weight:bold;
            color:white;
        }

        .auto-style1 {
            width: 50%;
            height: 20px;
        }
        .auto-style2 {
            height: 20px;
        }
        .auto-style3 {
            text-align: center;
        }

    </style>



    <!--Script para validar si al menos un campo ha sido seleccionado-->
    <script type="text/javascript">
    function ValidateCheckBoxList(sender, args) {
        var checkBoxList = document.getElementById("<%=CB_dias.ClientID %>");
        var checkboxes = checkBoxList.getElementsByTagName("input");
        var isValid = false;
        for (var i = 0; i < checkboxes.length; i++) {
            if (checkboxes[i].checked) {
                isValid = true;
                break;
            }
        }
        args.IsValid = isValid;
    }
</script>
    <h2 style="text-align:center">Horario de Trabajo</h2>
    <p style="text-align:center">&nbsp;</p>
    <table style="width: 100%">
        <tr>
            <td style="width: 50%; text-align: center;">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#00CCFF" Text="Seleccione Los Dias Que Desea Trabajar:"></asp:Label>
            </td>
            <td style="text-align: center">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="#00CCFF" Text="Seleccione Las Horas De Trabajo Diarias"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 50%; text-align: center;">
                <asp:CustomValidator ID="CustomValidator1" ErrorMessage="*Debe Seleccionar Al Menos 1 Dia"
    ForeColor="Red" ClientValidationFunction="ValidateCheckBoxList" runat="server" />
            </td>
            <td style="text-align: center">
                <asp:RequiredFieldValidator ID="validar" runat="server" ErrorMessage="* Debe Escoger Una Intensidad Horaria" ForeColor="Red" ControlToValidate="DL_horas"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 50%">
                <asp:CheckBoxList ID="CB_dias" runat="server" Font-Bold="True" Font-Names="Goudy Old Style" CausesValidation="True" DataSourceID="ODS_dias" DataTextField="nombre_dia" DataValueField="id_dia" ValidateRequestMode="Enabled" CssClass="list">
                </asp:CheckBoxList>
               
                <asp:ObjectDataSource ID="ODS_dias" runat="server" SelectMethod="obtener_dias" TypeName="DBMedico"></asp:ObjectDataSource>
               
            </td>
            <td style="text-align: center">
                <asp:DropDownList ID="DL_horas" runat="server" DataSourceID="ODS_horas" DataTextField="hora_valor" DataValueField="id_hora" Font-Bold="True" AppendDataBoundItems="True">
                    <asp:ListItem Value="">---------</asp:ListItem>
                </asp:DropDownList>
                 <asp:ObjectDataSource ID="ODS_horas" runat="server" SelectMethod="obtener_horas" TypeName="DBMedico"></asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td style="width: 50%; height: 20px;">
               
            </td>
            <td style="text-align: center; height: 20px;">
            </td>
        </tr>
        <tr>
            <td style="text-align: center;" colspan="2">
                <asp:Label ID="Label3" runat="server" Text="A continuacion seleccione la hora que desea laborar diariamente cumpliendo la cuota de horas seleccionada" Font-Bold="True" ForeColor="#333333"></asp:Label>
                </td>
        </tr>
        <tr>
            <td style="width: 50%" class="auto-style3">
                Hora Disponible</td>
            <td style="text-align: center">
                <asp:DropDownList ID="DL_hora_inicial" runat="server" DataSourceID="ODS_horas_dia" DataTextField="hora" DataValueField="id_hora_inicio" Font-Bold="True" AppendDataBoundItems="True">
                    <asp:ListItem Value="">---------</asp:ListItem>
                </asp:DropDownList>
                <asp:ObjectDataSource ID="ODS_horas_dia" runat="server" SelectMethod="obtenerHoras_dia" TypeName="DBMedico"></asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                </td>
            <td style="text-align: center" class="auto-style2">
                </td>
        </tr>
        <tr>
            <td style="text-align: center;" colspan="2">
                <asp:Button ID="Button1" runat="server" Text="Enviar Datos" Height="29px" Width="110px" CssClass="boton" BackColor="#3333CC" OnClick="Button1_Click" />
            </td>
        </tr>
    </table>

</asp:Content>

