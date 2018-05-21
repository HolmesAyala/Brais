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
            text-align: center;
        }
        .auto-style2 {
            height: 20px;
        }
        .auto-style3 {
            text-align: center;
        }

        .auto-style5 {
            height: 29px;
        }

        .auto-style6 {
            height: 26px;
        }

        .auto-style7 {
            width: 100%;
        }

        .auto-style8 {
            height: 20px;
            text-align: center;
        }

        .auto-style9 {
            height: 23px;
        }

    </style>
    <h2 style="text-align:center">Horario de Trabajo</h2>
    <p style="text-align:center">&nbsp;</p>
    <table class="auto-style7">
        <tr>
            <td style="text-align: center;" colspan="2">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#00CCFF" Text="Seleccione Los Dias Que Desea Trabajar:"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: center;" class="auto-style5" colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" style="margin-left:auto;margin-right:auto; text-align: center;" class="auto-style2">
               
                <asp:ObjectDataSource ID="ODS_dias" runat="server" SelectMethod="obtener_dias" TypeName="DBMedico"></asp:ObjectDataSource>
               
                <asp:DropDownList ID="DL_dias" runat="server" DataSourceID="ODS_dias" DataTextField="nombre_dia" DataValueField="id_dia" Font-Bold="True">
                </asp:DropDownList>
               
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
                <asp:Label ID="Label3" runat="server" Text="A continuacion seleccione el Rango(s) Del Dia" Font-Bold="True" ForeColor="#333333"></asp:Label>
                </td>
        </tr>
        <tr>
            <td style="width: 50%" class="auto-style3">
                <asp:Label ID="Label5" runat="server" Font-Bold="True" ForeColor="#00CCFF" Text="Seleccione La Hora De Inicio"></asp:Label>
            &nbsp;<br />
            </td>
            <td style="text-align: center">
                <asp:DropDownList ID="DL_hora_inicial" runat="server" DataSourceID="ODS_horas_dia" DataTextField="hora" DataValueField="id_hora_inicio" Font-Bold="True" AppendDataBoundItems="True">
                    <asp:ListItem Value="">---------</asp:ListItem>
                </asp:DropDownList>
                <asp:ObjectDataSource ID="ODS_horas_dia" runat="server" SelectMethod="obtenerHoras_dia" TypeName="DBMedico"></asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="#00CCFF" Text="Seleccione La Hora De Finalizacion"></asp:Label>
                <br />
                <br />
                </td>
            <td style="text-align: center" class="auto-style2">
                <asp:DropDownList ID="DL_hora_fin" runat="server" DataSourceID="ODS_horas_dia" DataTextField="hora" DataValueField="id_hora_inicio" Font-Bold="True" style="text-align: left" AppendDataBoundItems="true">
                    <asp:ListItem Value="">---------</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                </td>
        </tr>
        <tr>
            <td class="auto-style1">
                &nbsp;</td>
            <td style="text-align: center" class="auto-style2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8" colspan="2">
                <asp:Button class="BTN boton" ID="Button3" runat="server" OnClick="Button3_Click" Text="Establecer Rango" BackColor="#339933" Font-Bold="True" ForeColor="White"/>
                </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center;" colspan="2" class="auto-style6">
                <asp:Button class="BTN BTN_Azul" ID="Button2" runat="server" Text="Confirmar Dia" OnClick="Button2_Click"/>
            </td>
        </tr>
        <tr>
            <td style="text-align: center;" colspan="2">
                <asp:Label ID="dias_escogidos" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: center;" colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center;" colspan="2">
                <asp:Label ID="Label6" runat="server" Font-Bold="True" ForeColor="#FF6600" Text="Si Desea Eliminar Un Dia Por Favor Seleccionelo Aqui Y Dar Click En El Boton Eliminar Dia"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: center;">
                <asp:DropDownList ID="DL_deleteDay" runat="server" DataSourceID="ODS_dias" DataTextField="nombre_dia" DataValueField="id_dia" Font-Bold="True">
                </asp:DropDownList>
            </td>
            <td style="text-align: center;">
                <asp:Button class="BTN boton" ID="Button4" runat="server" OnClick="Button4_Click" Text="Eliminar Dia" BackColor="Red" Font-Bold="True" ForeColor="White"/>
            </td>
        </tr>
        <tr>
            <td style="text-align: center;" colspan="2">
                <asp:Button class="BTN boton" ID="Button1" runat="server" Text="Enviar Datos" BackColor="#3333CC" OnClick="Button1_Click" ForeColor="White"/>
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td style="text-align: center;" colspan="2">
                <asp:Label ID="Label7" runat="server" Font-Bold="True" ForeColor="#00CCFF" Text="Su Horario De Trabajo Actual"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: center;" colspan="2">
                <asp:Label ID="LB_nohay" runat="server"></asp:Label>
                <br />
                <asp:Button ID="Button5" runat="server" Text="Generar Reporte De Su Horario" CssClass="BTN_Azul" OnClick="Button5_Click" />
            </td>
        </tr>
        <tr>
            <td style="text-align: center;" colspan="2">
                <asp:Label ID="text_Lunes" runat="server" Font-Bold="True" ForeColor="#009900"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: center;" colspan="2">
                <asp:Label ID="Lun" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: center;" colspan="2">
                <asp:Label ID="text_Martes" runat="server" Font-Bold="True" ForeColor="#6600FF"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: center;" colspan="2">
                <asp:Label ID="Mar" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: center;" colspan="2">
                <asp:Label ID="text_Mercoles" runat="server" Font-Bold="True" ForeColor="#FF6600"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: center;" colspan="2" class="auto-style9">
                <asp:Label ID="Mier" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: center;" colspan="2">
                <asp:Label ID="text_Jueves" runat="server" Font-Bold="True" ForeColor="#CC9900"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: center;" colspan="2">
                <asp:Label ID="Juev" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: center;" colspan="2">
                <asp:Label ID="text_viernes" runat="server" Font-Bold="True" ForeColor="#CC00CC"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: center;" colspan="2">
                <asp:Label ID="Vier" runat="server"></asp:Label>
            </td>
        </tr>
    </table>

</asp:Content>

