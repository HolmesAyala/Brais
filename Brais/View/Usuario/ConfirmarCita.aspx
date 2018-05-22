<%@ Page Title="" Language="C#" MasterPageFile="~/View/Usuario/MPUsuario.master" AutoEventWireup="true" CodeFile="~/Controller/Usuario/ConfirmarCita.aspx.cs" Inherits="View_Usuario_ConfirmarCita" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenido" Runat="Server">

    <style>

        h5.titulo{
            color: rgb(0, 200, 248);
            text-align: center;
            padding: 20px;
            font-size: 2rem;
        }

        td {
            height: 50px;
        }

        .tabla-cita {
            width: 100%;
        }

        .td-espacio{
            width: 25%;
        }

        .diseno-panel {
            background-color: #99CCFF;
            width: 100%;
        }

        .label-cita {
            width: 40%;
            text-align: right;
        }

        .label-cita-final {
            text-align: left;
        }

        td.boton_confirmar {
            text-align: right;
            width: 50%;
        }

        td.boton_volver {
            text-align: left;
            width: 50%;
        }

        td.espacio {
            height: 10px;
        }

        [class ^= "Btn"] {
            font-size: 15px;
            background-color: #4DD7FA;
            border-radius: 3px;
            border: 1px solid black;
            padding: 5px;
        }

        [class^="Btn"]:hover{
            cursor: pointer;
            background-color: rgb(175, 172, 162);
        }

        .diseno-panel {
            background-color: #D9F5FE;
            width: 100%;
        }

    </style>


    <table style="width: 100%">
        <tr>
            <td class="titulo" colspan="3">
                <h5 class="titulo">Confirmación de tu cita médica</h5>
            </td>
        </tr>
        <tr>
            <td class="td-espacio">&nbsp;</td>
            <td>
                <asp:Panel ID="PanelCita" runat="server" CssClass="diseno-panel">
                    <table class="tabla-cita">
                        <tr>
                            <td class="label-cita">
                                <asp:Label ID="L_Nombre_Paciente" runat="server" Text="Cita para: "></asp:Label>
                                &nbsp;
                            </td>
                            <td class="label-cita-final">
                                <asp:Label ID="L_Nombre_Paciente_f" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="label-cita">
                                <asp:Label ID="L_Especialidad" runat="server" Text="Cita de: "></asp:Label>
                                &nbsp;
                            </td>
                            <td class="label-cita-final">
                                <asp:Label ID="L_Especialidad_f" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="label-cita">
                                <asp:Label ID="L_Fecha" runat="server" Text="Fecha: "></asp:Label>
                                &nbsp;
                            </td>
                            <td class="label-cita-final">
                                <asp:Label ID="L_Fecha_f" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="label-cita">
                                <asp:Label ID="L_Hora" runat="server" Text="Hora: "></asp:Label>
                                &nbsp;
                            </td>
                            <td class="label-cita-final">
                                <asp:Label ID="L_Hora_f" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="label-cita">
                                <asp:Label ID="L_Medico" runat="server" Text="Médico: "></asp:Label>
                                &nbsp;
                            </td>
                            <td class="label-cita-final">
                                <asp:Label ID="L_Medico_f" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="label-cita">
                                <asp:Label ID="L_Valor_Pagar" runat="server" Text="Valor de la cita: "></asp:Label>
                                &nbsp;
                            </td>
                            <td class="label-cita-final">
                                <asp:Label ID="L_Valor_Pagar_f" runat="server" Text="$10.000"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <td class="td-espacio">&nbsp;</td>
        </tr>
    </table>
    <table style="width: 100%">
        <tr>
            <td class="espacio">&nbsp;</td>
        </tr>
        <tr>
            <td class="boton_confirmar">
                <asp:Button class="BTN_Confirmar_Cita BTN_Azul" ID="BTN_ConfirmarCita" runat="server" Text="Confirmar cita" OnClick="BTN_ConfirmarCita_Click" />
                &nbsp;&nbsp;
            </td>
            <td class="boton-volver">
                <asp:Button class="BTN_Volver BTN_Azul" ID="Btn_Volver" runat="server" Text="Volver a asignación" OnClick="Btn_Volver_Click" />
                &nbsp;&nbsp;
            </td>
        </tr>
    </table>


</asp:Content>

