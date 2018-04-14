﻿<%@ Page Title="" Language="C#" MasterPageFile="~/View/Administrador/MPAdministrador.master" AutoEventWireup="true" CodeFile="~/Controller/Administrador/parametros.aspx.cs" Inherits="View_Administrador_parametros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenido" Runat="Server">
    <style>
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
        </style>
    <table style="width: 100%">
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
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Text=" ID Consultorio"></asp:Label>
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
                <asp:Button ID="Button1" runat="server" Text="Agregar" Width="96px" BackColor="#1A9996" CssClass="bordes" Height="29px" OnClick="Button1_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 20px; text-align: center">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 20px" colspan="4"><br /><hr style="height:3px;background-color:deepskyblue" /></td>
        </tr>
        <tr>
            <td style="width: 458px; height: 20px">&nbsp;</td>
            <td style="width: 345px; height: 20px; text-align: center;">
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#00CCFF" Text="Tiempos"></asp:Label>
                </td>
            <td colspan="2" style="height: 20px">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 33%; height: 20px">
                <div>
                   &nbsp;<asp:Label ID="Label7" runat="server" Text="Dias Laborales" AssociatedControlID="CB_dias" CssClass="label" Width="78px"></asp:Label>
                        
                    
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBoxList ID="CB_dias" runat="server" CssClass="mitad">
                        <asp:ListItem>Lunes</asp:ListItem>
                        <asp:ListItem>Martes</asp:ListItem>
                        <asp:ListItem>Miercoles</asp:ListItem>
                        <asp:ListItem>Jueves</asp:ListItem>
                        <asp:ListItem>Viernes</asp:ListItem>
                        <asp:ListItem>Sabado</asp:ListItem>
                        <asp:ListItem>Domingo</asp:ListItem>
                    </asp:CheckBoxList>            
                    </div>
                
            </td>
            <td style="width: 33%; height: 20px">&nbsp; &nbsp;</td>
            <td colspan="2" style="height: 20px">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 33%; height: 20px">
                &nbsp;</td>
            <td style="width: 33%; height: 20px">&nbsp;</td>
            <td colspan="2" style="height: 20px">&nbsp;</td>
        </tr>
    </table>
</asp:Content>

