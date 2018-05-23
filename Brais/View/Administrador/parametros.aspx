<%@ Page EnableEventValidation="false" Title="" Language="C#" MasterPageFile="~/View/Administrador/MPAdministrador.master" AutoEventWireup="true" CodeFile="~/Controller/Administrador/parametros.aspx.cs" Inherits="View_Administrador_parametros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenido" Runat="Server">
    <style>
        .p{
            margin-bottom: 40px;
        }

        .bordes{
            border-radius:5px;
            font-family:Arial;
            font-size:medium;
            color:white;
        }
        .textBox{
            border-radius:20px;
            border-color:black;
            border-width:1px;
        }
        .label{
         float:left;
         
        }
        .mitad{
           float:left;
        }
        .BTN_Reporte{
            border-radius: 5px;
            border: 1px solid rgb(128, 128, 128);
            color: white;
            background-color: rgb(22, 157, 179);
        }
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            width: 33%;
            height: 20px;
        }
        .auto-style3 {
            text-align: center;
            width: 33%;
            height: 20px;
        }
        .auto-style4 {
            height: 20px;
        }
        </style>
    <table class="p" style="width: 100%">
        <tr>
            <td colspan="2" rowspan="3" style="text-align: center">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#00CCFF" Text="Consultorios"></asp:Label>
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:GridView ID="GV_consultorios" runat="server" Width="80%" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" DataSourceID="ODS_consultorios" AllowPaging="True" PageSize="3">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                        <asp:BoundField DataField="nombre_consultorio" HeaderText="Nombre Consultorio" >
                        <ControlStyle Font-Names="Arial" />
                        </asp:BoundField>
                        <asp:BoundField AccessibleHeaderText="Ubicacion" DataField="ubicacion" HeaderText="Ubicacion" />
                        <asp:TemplateField HeaderText="Editar">
                            <ItemTemplate>
                                <br />
                                <asp:Button ID="Button2" runat="server" CommandArgument='<%# Eval("id") %>' Text="Editar" OnClick="Button2_Click" BackColor="Black" BorderColor="#333300" BorderWidth="2px" CssClass="bordes" Font-Bold="True" Font-Names="Arial" ForeColor="White" Height="25px" Width="54px" />
                                <br />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Eliminar">
                            <ItemTemplate>
                                <br />
                                <asp:Button ID="Button3" runat="server" Text="Eliminar" CommandArgument='<%# Eval("id") %>' OnClick="Button3_Click" BackColor="Black" CssClass="bordes" Font-Bold="True" Font-Names="Arial" Height="26px" Width="89px" ForeColor="White" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="Gray" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ObjectDataSource ID="ODS_consultorios" runat="server" SelectMethod="obtenerConsultorios" TypeName="DBAdministrador"></asp:ObjectDataSource>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td colspan="2" style="text-align: left">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#00CCFF" Text="Agregar Consultorio"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 20px; text-align: left; width: 117px">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Text=" Nombre Consultorio"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label4" runat="server" Font-Bold="True">Ubicacion</asp:Label>
                <br />
                <br />
                <br />
                <br />
                <br />
            </td>
            <td style="height: 20px; text-align: left">
                <asp:TextBox ID="TB_Consultorio" runat="server" Width="179px" placeholder="Nombre Consultorio (Unico)" CssClass="textBox" Height="26px"></asp:TextBox>
                <br />
                <br />
                <asp:TextBox ID="TB_Ubicacion" runat="server" Width="179px" placeholder="Localizacion" CssClass="textBox" Height="26px"></asp:TextBox>
                <br />
                <br />
                <br />
                <asp:Button class="BTN BTN_Azul" ID="Button1" runat="server" Text="Agregar" OnClick="Button1_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 20px; text-align: center">
                &nbsp;</td>
        </tr>
        <tr style="text-align:left">
            <td colspan="2">
                <asp:Button runat="server" id="BTN_Reporte" CssClass="BTN_Reporte" Text="Generar Reporte" OnClick="BTN_Reporte_Click"></asp:Button>
            </td>
        </tr>
        <tr>
            <td colspan="4">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 458px; height: 20px">&nbsp;</td>
            <td style="width: 345px; height: 20px; " class="auto-style1">
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#00CCFF" Text="Tiempos"></asp:Label>
                </td>
            <td colspan="2" style="height: 20px">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">
                <div>
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                
            </td>
            <td class="auto-style3">&nbsp; &nbsp;<b>Duracion De Citas</b></td>
            <td colspan="2" class="auto-style4"></td>
        </tr>
        <tr>
            <td style="width: 33%; height: 20px">
                Estos Cambios afectaran a las nuevas citas, las actuales siguen iguales.</td>
            <td style="width: 33%; height: 20px" class="auto-style1">
                <asp:DropDownList ID="DL_tiempo" runat="server" DataSourceID="ODS_duracion" DataTextField="duracion_citas" DataValueField="id_parametros">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="ODS_duracion" runat="server" SelectMethod="traerTiempos" TypeName="DBAdministrador"></asp:ObjectDataSource>
                <br />
            </td>
            <td colspan="2" style="height: 20px">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 33%; height: 20px">
                &nbsp;</td>
            <td style="width: 33%; height: 20px" class="auto-style1">
                <asp:Button class="BTN BTN_Azul" ID="Button4" runat="server" Text="Aceptar" OnClick="Button4_Click" />
            </td>
            <td colspan="2" style="height: 20px">&nbsp;</td>
        </tr>
    </table>


    <style>

        .crud{
            display: flex;
            flex-direction: column;
            align-items: center;
            margin-bottom: 40px;
            width: 400px;
            margin: 0 auto;
            padding: 20px;
            border: 2px solid #EEEEEE;
            margin-bottom: 10px;
            border-radius: 5px;
        }
        .crud h3, .crud > div{
            margin-bottom: 30px;
        }
        .agregar{
            display: flex;
            flex-direction: column;
            align-items: center;
        }
        .campo{
            display: flex;
            margin-bottom: 20px;
        }
        .LB{
            width: 100px;
        }
        .BTN_AzulOpaco{
            background-color: rgb(0, 141, 177);
            color: white;
            border: 1px solid rgb(0, 141, 177);
            border-radius: 5px;
        }

    </style>

    <asp:ScriptManager runat="server" />

    <asp:Panel class="crud crud_especialidad" runat="server">
        <h3>Especialidad</h3>
        <div>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
            <div class="agregar">
                <div class = "campo">
                    <label class="LB">Nombre:</label>
                    <asp:TextBox ID="TB_AgregarEspecialidad" runat="server" />
                </div>
            <asp:Button ID="BTN_AgregarEspecialidad" CssClass="BTN_Azul BTN" Text="Agregar" runat="server" OnClick="BTN_AgregarEspecialidad_Click" />
            <asp:Label ID="LB_MensajeEspecialidad" Text="" runat="server" />
            <asp:Timer ID="T_Especialidad" runat="server" Enabled="False" Interval="2000" OnTick="T_Especialidad_Tick"></asp:Timer>
            </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <div>
            <asp:UpdatePanel runat="server" UpdateMode="Always">
                <ContentTemplate>


            <asp:GridView ID="GV_Especialidad" runat="server" AutoGenerateColumns="False" EmptyDataText="Sin especialidades" DataSourceID="ODS_Especialidad" BorderStyle="None" CellPadding="5" CellSpacing="5" GridLines="None">
                <Columns>
                    <asp:TemplateField HeaderText="Nombre">
                        <ItemTemplate>
                            <asp:TextBox ID="TB_Especialidad" runat="server" Text='<%# Eval("nombre") %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="BTN_ActualizarEspecialidad" class="BTN BTN_AzulOpaco" CommandName='<%# Eval("id") %>' runat="server" Text="Actualizar" OnClick="BTN_ActualizarEspecialidad_Click"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="BTN_EliminarEspecialidad" class="BTN BTN_Rojo" CommandName='<%# Eval("id") %>' runat="server" Text="Eliminar" OnClick="BTN_EliminarEspecialidad_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            </ContentTemplate>
            </asp:UpdatePanel>
            <asp:ObjectDataSource ID="ODS_Especialidad" runat="server" SelectMethod="obtenerTipoEspecialidad" TypeName="DBEspecialidad"></asp:ObjectDataSource>
        </div>
    </asp:Panel>

    <asp:Panel class="crud crud_eps" runat="server">
        <h3>EPS</h3>
        <div>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>

            <div class="agregar">
                <div class="campo">
                    <label class="LB">Nombre:</label>
                    <asp:TextBox ID="TB_AgregarEps" runat="server" />
                </div>
            <asp:Button ID="BTN_AgregarEps" CssClass="BTN_Azul BTN" Text="Agregar" runat="server" OnClick="BTN_AgregarEps_Click" />
            <asp:Label ID="LB_MensajeEps" Text="" runat="server" />
            <asp:Timer ID="T_Eps" runat="server" Enabled="False" Interval="2000" OnTick="T_Eps_Tick"></asp:Timer>
            </div>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <div>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>

            <asp:GridView ID="GV_Eps" runat="server" AutoGenerateColumns="False" EmptyDataText="Sin especialidades" DataSourceID="ODS_Eps" CellPadding="5" CellSpacing="5" GridLines="None">
                <Columns>
                    <asp:TemplateField HeaderText="Nombre">
                        <ItemTemplate>
                            <asp:TextBox ID="TB_Eps" Text='<%# Eval("nombre") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="BTN_ActualizarEps" class="BTN BTN_AzulOpaco" CommandName='<%# Eval("id") %>' runat="server" Text="Actualizar" OnClick="BTN_ActualizarEps_Click"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="BTN_EliminarEps" class="BTN BTN_Rojo" CommandName='<%# Eval("id") %>' runat="server" Text="Eliminar" OnClick="BTN_EliminarEps_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="ODS_Eps" runat="server" SelectMethod="obtenerEps" TypeName="DBEps"></asp:ObjectDataSource>

            </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </asp:Panel>
    
</asp:Content>

