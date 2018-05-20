<%@ Page Title="" Language="C#" MasterPageFile="~/View/Usuario/MPUsuario.master" AutoEventWireup="true" CodeFile="~/Controller/Usuario/CancelarCita.aspx.cs" Inherits="View_Usuario_CancelarCita" validateRequest="false" enableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenido" Runat="Server">

    <style>

        h1.titulo_usuario{
            color: rgb(0, 200, 248);
            text-align: center;
            padding: 20px;
        }

        h2{
            text-align: center;
            color: rgb(0, 200, 248);
            margin: 50px 0;
        }

        div#Tabla{
            margin-bottom: 30px;
        }

        div#Tabla .GV_Cancelar_Cita{
            width: 80%;
            margin: 0 auto;
        }
        
        .BTN_Seleccionar{
            color: white;
            background-color: red;
            border: 1px solid rgb(0, 77, 99);
            border-radius: 5px;
        }

    </style>

    <h1 class="titulo_usuario">Cancelar Citas</h1>

    <div id="Tabla">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:GridView class="GV_Cancelar_Cita" runat="server" ID="GV_Cancelar_Cita" AllowPaging="True" AutoGenerateColumns="False" CellPadding="10" CellSpacing="5" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" EnableModelValidation="False" OnPageIndexChanging="GV_Cancelar_Cita_PageIndexChanging" OnSelectedIndexChanged="GV_Cancelar_Cita_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="dia" HeaderText="Fecha" SortExpression="dia" DataFormatString="{0:d}" HtmlEncode=false />
                            <asp:BoundField DataField="hora_inicio" HeaderText="Hora" />
                            <asp:BoundField DataField="especialidad" HeaderText="Tipo" />
                            <asp:BoundField DataField="nombre_medico" HeaderText="Médico" />
                            <asp:TemplateField>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Button ID="BTN_Seleccionar" runat="server" class="BTN_Seleccionar" CommandName='<%# Eval("id_cita") %>' Text="Seleccionar" OnClick="BTN_Seleccionar_Click" OnClientClick="return confirm('¿Está seguro de eliminar la cita?');"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" HorizontalAlign="Center" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="GV_Cancelar_Cita" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
        

    </div>

</asp:Content>

