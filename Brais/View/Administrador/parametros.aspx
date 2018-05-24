<%@ Page EnableEventValidation="false" Title="" Language="C#" MasterPageFile="~/View/Administrador/MPAdministrador.master" AutoEventWireup="true" CodeFile="~/Controller/Administrador/parametros.aspx.cs" Inherits="View_Administrador_parametros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenido" Runat="Server">
    <style>
        .p{
            margin-bottom: 40px;
        }
        .GV{
            display: block;
            width: 100%;
        }
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
            flex-wrap: wrap;
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
    
    <div class="crud">
        <h3>Consultorio</h3>

        <div class="agregar">
            <div class="campo">
                <label class="LB">Nombre:</label>
                <asp:TextBox ID="TB_Consultorio" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator runat="server" ErrorMessage="Hay caracteres especiales" ValidationExpression="^[\s\w]*$" ControlToValidate="TB_Consultorio" ForeColor="#CC0000"></asp:RegularExpressionValidator>
            </div>
        
            <div class="campo">
                <label class="LB">Ubicacion:</label>
                <asp:TextBox ID="TB_Ubicacion" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator runat="server" ErrorMessage="Hay caracteres especiales" ControlToValidate="TB_Ubicacion" ValidationExpression="^[\s\w]*$" ForeColor="#CC0000"></asp:RegularExpressionValidator>
            </div>

            <asp:Button class="BTN BTN_Azul" ID="Button1" runat="server" Text="Agregar" OnClick="Button1_Click" />
        </div>

        <div>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>

            <asp:GridView ID="GV_consultorios" CssClass="GV" runat="server" AutoGenerateColumns="False" DataSourceID="ODS_consultorios" AllowPaging="True" PageSize="3" CellPadding="5" CellSpacing="5" GridLines="None">
            <Columns>
                <asp:BoundField DataField="nombre_consultorio" HeaderText="Nombre" >
                <ControlStyle Font-Names="Arial" />
                </asp:BoundField>
                <asp:BoundField AccessibleHeaderText="Ubicacion" DataField="ubicacion" HeaderText="Ubicacion" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <br />
                        <asp:Button ID="Button2" class="BTN BTN_AzulOpaco" runat="server" CommandArgument='<%# Eval("id") %>' Text="Editar" OnClick="Button2_Click" />
                        <br />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <br />
                        <asp:Button ID="Button3" CssClass="BTN BTN_Rojo" runat="server" Text="Eliminar" CommandArgument='<%# Eval("id") %>' OnClick="Button3_Click"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
                <HeaderStyle BackColor="White" Height="30px" HorizontalAlign="Center" />
                <PagerStyle Font-Bold="True" HorizontalAlign="Center" BackColor="#CCCCCC" />
                <RowStyle HorizontalAlign="Center" />
            </asp:GridView>
            <asp:ObjectDataSource ID="ODS_consultorios" runat="server" SelectMethod="obtenerConsultorios" TypeName="DBAdministrador"></asp:ObjectDataSource>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <asp:Button runat="server" id="BTN_Reporte" CssClass="BTN BTN_Verde" Text="Generar Reporte" OnClick="BTN_Reporte_Click"></asp:Button>
    </div>

    <div class="crud">
        <h3>Duracion de citas</h3>
        <div class="campo">
        <label class="LB">Minutos:</label>
        <asp:DropDownList ID="DL_tiempo" runat="server" DataSourceID="ODS_duracion" DataTextField="duracion_citas" DataValueField="id_parametros">
        </asp:DropDownList>
        <asp:ObjectDataSource ID="ODS_duracion" runat="server" SelectMethod="traerTiempos" TypeName="DBAdministrador"></asp:ObjectDataSource>
        
        </div>

        <asp:Button class="BTN BTN_Azul" ID="Button4" runat="server" Text="Aceptar" OnClick="Button4_Click" />
    </div>

    <asp:Panel class="crud crud_especialidad" runat="server">
        <h3>Especialidad</h3>
        <div>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
            <div class="agregar">
                <div class = "campo">
                    <label class="LB">Nombre:</label>
                    <asp:TextBox ID="TB_AgregarEspecialidad" runat="server" />
                    <asp:RegularExpressionValidator runat="server" ErrorMessage="Hay caracteres especiales" ControlToValidate="TB_AgregarEspecialidad" ValidationExpression="^[\s\w]*$" ForeColor="#CC0000"></asp:RegularExpressionValidator>
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
                            <asp:RegularExpressionValidator runat="server" ErrorMessage="Hay caracteres especiales" ControlToValidate="TB_Especialidad" ValidationExpression="^[\s\w]*$" ForeColor="#CC0000"></asp:RegularExpressionValidator>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="BTN_ActualizarEspecialidad" class="BTN BTN_AzulOpaco" CommandName='<%# Eval("id") %>' runat="server" Text="Editar" OnClick="BTN_ActualizarEspecialidad_Click"/>
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
                    <asp:RegularExpressionValidator runat="server" ErrorMessage="Hay caracteres especiales" ControlToValidate="TB_AgregarEps" ValidationExpression="^[\s\w]*$" ForeColor="#CC0000"></asp:RegularExpressionValidator>
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
                            <asp:RegularExpressionValidator runat="server" ErrorMessage="Hay caracteres especiales" ControlToValidate="TB_Eps" ValidationExpression="^[\s\w]*$" ForeColor="#CC0000" Display="Static"></asp:RegularExpressionValidator>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="BTN_ActualizarEps" class="BTN BTN_AzulOpaco" CommandName='<%# Eval("id") %>' runat="server" Text="Editar" OnClick="BTN_ActualizarEps_Click"/>
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

