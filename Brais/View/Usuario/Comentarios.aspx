<%@ Page Title="" Language="C#" MasterPageFile="~/View/Usuario/MPUsuario.master" AutoEventWireup="true" CodeFile="~/Controller/Usuario/Comentarios.aspx.cs" Inherits="View_Usuario_Comentarios" validateRequest="false" enableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="contenido" Runat="Server">

    <style>

        h1.titulo_usuario{
            color: rgb(0, 200, 248);
            text-align: center;
            padding: 20px;
        }

        div#Tabla{
            margin-bottom: 30px;
        }

        div#Tabla .GV_Comentarios{
            width: 80%;
            margin: 0 auto;
        }

        .BTN_Seleccionar {
            margin: 0 auto;
            border-radius: 5px;
            background-color: rgb(0, 200, 248);
            color: white;
            border: 1px solid rgb(0, 200, 248);
        }

        .BTN_Confirmar{
            border-radius: 5px;
            border: 1px solid rgb(128, 128, 128);
            color: white;
            background-color: rgb(22, 157, 179);
        }

        .campo{
            display: flex;
            justify-content: center;
            margin: 7px;
        }

        div.mensaje{
            font-weight: bold;
            line-height: 1.5rem;
            text-align: left;
            color: white;
            background-color: rgb(255, 95, 95);
            padding: 10px;
            border-radius: 5px;
        }

    </style>

    <h1 class="titulo_usuario">Dejar PQRF</h1>

    <div id="Tabla">
        <asp:GridView class="GV_Comentarios" runat="server" ID="GV_Comentarios" EmptyDataText="No tiene citas para comentar" AllowPaging="True" AutoGenerateColumns="False" CellPadding="10" CellSpacing="5" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" EnableModelValidation="False" OnPageIndexChanging="GV_Comentarios_PageIndexChanging" OnSelectedIndexChanged="GV_Comentarios_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="dia" HeaderText="Fecha" SortExpression="dia" DataFormatString="{0:d}" HtmlEncode=false />
                <asp:BoundField DataField="especialidad" HeaderText="Tipo" />
                <asp:BoundField DataField="nombre_medico" HeaderText="Médico" />
                <asp:TemplateField HeaderText="Seleccione">
                    <ItemTemplate>
                        <asp:Button ID="BTN_Seleccionar" class="BTN_Seleccionar" runat="server" CommandArgument='<%# Eval("id_cita") %>' Text="Seleccionar" OnClick="BTN_Seleccionar_Click" />
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
    </div>
    <div>
        <table id="T_Comentario" class="T_Comentario" style="width:100%;" visible="false" runat="server">
            <tr>
                <td style="width:5%">
                    &nbsp;<asp:Label runat="server" Text="Especialidad:"></asp:Label>&nbsp;
                </td>
                <td style="width:5%">
                    <asp:Label runat="server" ID="L_Especialidad" ></asp:Label>
                </td>
                <td style="width:45%; text-align:right">
                    &nbsp;<asp:Label runat="server" Text="Médico:"></asp:Label>&nbsp;
                </td>
                <td style="width:45%">
                    <asp:Label runat="server" ID="L_medico" ></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4">&nbsp;</td>
            </tr>
            <tr>
                <td style="width:10%; text-align:right" colspan="2">
                    <asp:Label ID="L_Motivo" runat="server" Text="Motivo del PQR: "></asp:Label>
                    &nbsp;
                </td>
                <td style="width:90%; text-align:left" colspan="2">
                    <asp:DropDownList runat="server" ID="DDL_Motivo" DataSourceID="ODS_Motivo" DataTextField="nombre" DataValueField="id"></asp:DropDownList>
                    <asp:ObjectDataSource ID="ODS_Motivo" runat="server" SelectMethod="obtenerMotivo" TypeName="DBMotivo"></asp:ObjectDataSource>
                </td>
            </tr>
            <tr>
                <td colspan="4">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;<asp:Label runat="server" Text="De forma clara explique cuales fueron los acontecimientos"></asp:Label>&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;<asp:Label runat="server" Text="Dejé su comentario:"></asp:Label>&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="4">&nbsp;</td>
            </tr>
            <tr>
                <td style="width:70%; text-align:center" colspan="4">
                <asp:TextBox class="TB" ID="TB_Comentario" runat="server" Height="100px" TextMode="MultiLine" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="4" style="text-align:center">
                    <asp:Button ID="BTN_Confirmar" class="BTN_Confirmar" runat="server" Text="Aceptar" OnClick="BTN_Confirmar_Click" />
                </td>
            </tr>
        </table>
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <div class="campo">
            <div class="mensaje">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:Label class="LB_Mensaje" ID="LB_Mensaje" runat="server" Visible="False"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="BTN_Confirmar" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>


</asp:Content>

