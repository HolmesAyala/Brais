<%@ Page Title="" Language="C#" MasterPageFile="~/View/Medico/MPMedico.master" AutoEventWireup="true" CodeFile="~/Controller/Medico/HistorialPaciente.aspx.cs" Inherits="View_Medico_HistorialPaciente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenido" Runat="Server">

    <style>
        *{
            /*box-sizing: border-box;*/
        }

        h3{
            text-align: center;
            padding: 10px;
            margin-bottom: 20px;
            color: rgb(0, 191, 255);
        }

        div.campo{
            display: flex;
            justify-content: center;
            margin-bottom: 15px;
            flex-wrap: wrap;
        }
        div.campo .LB{
            display: inline-block;
            width: 200px;
            text-align:right;
            padding-right: 10px;
        }
        div.campo .TB{
            display: block;
            padding: 5px;
            width: 300px;
        }
        .GV{
            margin: 0 auto;
            margin-bottom: 30px;
        }
        .LB_Mensaje{
            display: block;
            text-align: center;
            margin-bottom: 30px;
            color: crimson;
        }

        .auto-style1 {
            text-align: center;
        }
    </style>

    <h3>Agregar al historial</h3>

    <div class="campo">
        <asp:Label class="LB" ID="LB_Fecha" runat="server" Text="Fecha: "></asp:Label>
        <asp:TextBox class="TB" ID="TB_Fecha" runat="server" Enabled="False"></asp:TextBox>
    </div>

    <div class="campo">
        <asp:Label class="LB" ID="LB_NombreMedico" runat="server" Text="Medico: "></asp:Label>
        <asp:TextBox class="TB" ID="TB_NombreMedico" runat="server" Enabled="False"></asp:TextBox>
    </div>

    <div class="campo">
        <asp:Label class="LB" ID="LB_NombrePaciente" runat="server" Text="Paciente: "></asp:Label>
        <asp:TextBox class="TB" ID="TB_NombrePaciente" runat="server" Enabled="False"></asp:TextBox>
    </div>

    <div class="campo">
        <asp:Label class="LB" ID="LB_NombreServicio" runat="server" Text="Servicio: "></asp:Label>
        <asp:TextBox class="TB" ID="TB_NombreServicio" runat="server" Enabled="False"></asp:TextBox>
    </div>

    <div class="campo">
        <asp:Label class="LB" runat="server" Text="Motivo de consulta"></asp:Label>
        <asp:TextBox class="TB" ID="TB_MotivoConsulta" runat="server" Height="100px" TextMode="MultiLine" Width="300px"></asp:TextBox>
    </div>
    
    <div class="campo">
        <asp:Label class="LB" runat="server" Text="Observaciones"></asp:Label>
        <asp:TextBox class="TB" ID="TB_Observacion" runat="server" Height="100px" TextMode="MultiLine" Width="300px"></asp:TextBox>
    </div>

    <div class="campo">
        <asp:Button class="BTN_Agregar" ID="BTN_Agregar" runat="server" Text="Agregar" OnClick="BTN_Agregar_Click"></asp:Button>
    </div>
    

    <br />
    <h3>Historial del Paciente</h3>

    <asp:Label class="LB LB_Mensaje" ID="LB_Mensaje" runat="server" Text=""></asp:Label>

    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>

            <asp:GridView class="GV" ID="GV_Historial" runat="server" OnPageIndexChanging="GV_Historial_PageIndexChanging" AutoGenerateColumns="False" CellPadding="10" CellSpacing="10" ForeColor="#333333" GridLines="None" Width="80%" AllowPaging="True" PageSize="5">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="fecha" HeaderText="Fecha" />
                    <asp:BoundField DataField="nombre_medico" HeaderText="Medico" />
                    <asp:BoundField DataField="servicio" HeaderText="Servicio" />
                    <asp:BoundField DataField="motivo_consulta" HeaderText="Motivo de la consulta" />
                    <asp:BoundField DataField="observacion" HeaderText="Observacion" />
                </Columns>
                <EditRowStyle BackColor="#7C6F57" HorizontalAlign="Center" />
                <EmptyDataRowStyle HorizontalAlign="Center" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" Height="20px" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>

        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="GV_Historial" EventName="PageIndexChanging" />
        </Triggers>
    </asp:UpdatePanel>
    <div class="auto-style1">
        <asp:Label ID="Label1" runat="server" Text="Comentarios Hacia El Paciente" Font-Bold="True" Font-Size="14pt" ForeColor="#33CCFF"></asp:Label>
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="8pt" Text="(OPCIONAL)"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="TextBox1" runat="server" Height="75px" Width="335px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Enviar" CssClass="BTN_Azul" />
    </div>
    </asp:Content>

