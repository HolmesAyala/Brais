<%@ Page EnableEventValidation="false" Title="" Language="C#" MasterPageFile="~/View/Usuario/MPUsuario.master" AutoEventWireup="true" CodeFile="~/Controller/Usuario/AsignarCita.aspx.cs" Inherits="View_Usuario_AsignarCita" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenido" Runat="Server">

    <style>

        h1.titulo_usuario{
            color: rgb(0, 200, 248);
            text-align: center;
            padding: 20px;
        }

        div#informacion{
            width: 50%;
            margin: 0 auto;
            margin-bottom: 30px;
        }
        div#informacion p{
            line-height: 1.6;
        }
        div#informacion div{
            display: flex;
            align-items: center;
            margin-bottom: 20px;
        }
        .img{
            width: 2.5rem;
            margin-right: 20px;
        }

        div.campo{
            display: flex;
            align-items: center;
            justify-content: center;
            margin-bottom: 20px;
        }

        div.campo .lb{
            margin-right: 20px;
            display: block;
        }

        div.tipocita_fechasdisponibles{
            display: flex;
            flex-wrap: wrap;
            justify-content: space-around;
            margin-bottom: 30px;
            align-items: center;
        }

        div.tipo_cita{
            width: 300px;
        }

        div.fechas_disponibles{
            padding: 10px;
        }

        div.fechas_disponibles h3, div.disponibilidad_horaria{
            text-align: center;
            padding: 10px;
        }

        div.disponibilidad_horaria{
            display: flex;
            flex-direction: column;
            align-items: center;
            margin-bottom: 50px;
        }

    </style>

    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <h1 class="titulo_usuario">Asignar Cita</h1>

    <div id="informacion">
        <div>
            <asp:Image class="img" runat="server" ImageUrl="~/Imagen/uno.svg"></asp:Image>
            <p>Seleccione el tipo de cita</p>
        </div>
        <div>
            <asp:Image class="img" runat="server" ImageUrl="~/Imagen/dos.svg"></asp:Image>
            <p>Seleccione un dia disponible marcado con: </p>
            <asp:Image class="img" runat="server" ImageUrl="~/Imagen/dia_seleccionable.svg"></asp:Image>
        </div>
        <div>
            <asp:Image class="img" runat="server" ImageUrl="~/Imagen/tres.svg"></asp:Image>
            <p>Seleccione una cita segun la disponibilidad</p>
        </div>
        <div>
            <asp:Image class="img" runat="server" ImageUrl="~/Imagen/informacion.svg"></asp:Image>
            <p>Tenga en cuenta: <br /> 
                - Solo puede agendar de a una cita por tipo
            </p>
        </div>
    </div>

    <div class="tipocita_fechasdisponibles">
        <div class="tipo_cita">
            <div class="campo">
                <asp:Image class="img" runat="server" ImageUrl="~/Imagen/uno.svg"></asp:Image>
                <asp:Label ID="LB_TipoCita" class="LB_TipoCita lb" runat="server" Text="Tipo de cita: "></asp:Label>
                <asp:DropDownList ID="DDL_TipoCita" class="DDL_TipoCita" runat="server" DataSourceID="ODS_ObtenerEspecialidades" DataTextField="nombre" DataValueField="id" AutoPostBack="True" OnSelectedIndexChanged="DDL_TipoCita_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="ODS_ObtenerEspecialidades" runat="server" SelectMethod="obtenerTipoEspecialidad" TypeName="DBEspecialidad"></asp:ObjectDataSource>
            </div>
        </div>
        
        <div class="fechas_disponibles">
            <div class="campo">
                <asp:Image class="img" runat="server" ImageUrl="~/Imagen/dos.svg"></asp:Image>
                <h3>Fechas Disponibles</h3>
            </div>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:Calendar ID="C_FechasDisponibles" class="C_FechasDisponibles" runat="server" BackColor="White" BorderColor="#0099CC" BorderWidth="2px" CellPadding="3" DayNameFormat="Shortest" Font-Names="Arial" Font-Size="12pt" ForeColor="#003399" Height="270px" Width="300px" BorderStyle="None" CellSpacing="3" OnDayRender="C_FechasDisponibles_DayRender" OnSelectionChanged="C_FechasDisponibles_SelectionChanged">
                        <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                        <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#FF5050" Font-Bold="True" ForeColor="#CCFF99" />
                        <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                        <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                        <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                        <WeekendDayStyle BackColor="#CCCCFF" />
                    </asp:Calendar>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="GV_DisponibilidadHoraria" />
                    <asp:AsyncPostBackTrigger ControlID="DDL_TipoCita" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
            
        </div>
    </div>

    <div class="disponibilidad_horaria">
        <div class="campo">
            <asp:Image class="img" runat="server" ImageUrl="~/Imagen/tres.svg"></asp:Image>
            <h3>Disponibilidad Horaria</h3>
        </div>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:GridView ID="GV_DisponibilidadHoraria" class="GV_DisponibilidadHoraria" runat="server" AutoGenerateColumns="False" EmptyDataText="Sin horarios" CellPadding="4" ForeColor="#333333" GridLines="None" Width="400px">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="nombre_medico" HeaderText="Medico" />
                        <asp:BoundField DataField="hora_inicio" HeaderText="Hora inicio" />
                        <asp:BoundField DataField="hora_fin" HeaderText="Hora fin" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="BTN_SeleccionarCita" class="BTN_SeleccionarCita BTN_Azul" runat="server" CommandName='<%# Eval("id") %>' Text="Seleccionar" OnClick="BTN_SeleccionarCita_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" Height="50px" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" Height="40px" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="C_FechasDisponibles" EventName="SelectionChanged" />
            </Triggers>
        </asp:UpdatePanel>
    </div>

</asp:Content>

