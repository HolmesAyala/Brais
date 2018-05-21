<%@ Page Title="" Language="C#" MasterPageFile="~/View/Usuario/MPUsuario.master" AutoEventWireup="true" CodeFile="~/Controller/Usuario/pago.aspx.cs" Inherits="View_Usuario_pago" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenido" Runat="Server">
    <style>
        .pago{
            background-color:lightgray;
            border:dotted;
            border-color:deepskyblue;
            padding:0;
        }
        .btn_pay{
            border-radius:3px;
        }
        .auto-style1 {
            width: 295px;
        }
        .auto-style2 {
            height: 21px;
            width: 295px;
        }
        .auto-style3 {
            height: 20px;
            width: 295px;
        }
        .auto-style4 {
            height: 20px;
        }
        .auto-style5 {
            padding: 0 15%;
        }
        .auto-style6 {
            width: 80%;
        }
        .auto-style8 {
            width: 251px;
        }
        .auto-style9 {
            width: 100%;
            margin: 0;
        }
        .auto-style10 {
            text-align: center;
        }
    </style>
    <table style="width: 100%">

        <tr style="height:20px !important;">
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <hr style="border:1px solid deepskyblue;"/>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="auto-style4">
                
                </td>
           
        </tr>
        <tr>
            <td class="auto-style5"></td>
            <td style="text-align: center; " class="auto-style6">
                <div class="pago" style="margin-bottom: 0">
                     <asp:Label ID="Label1" runat="server" Text="Pagar" Font-Bold="True" Font-Size="16pt" ForeColor="#33CCFF"></asp:Label>
                        
                     <table style="width:100%;" class="auto-style9">
                         <tr>
                             <td class="auto-style8">&nbsp;</td>
                             <td class="auto-style1">&nbsp;</td>
                         </tr>
                         <tr>
                             <td style="height: 21px; width: 251px">
                                 <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Precio De Pago Sin Descuentos:"></asp:Label>
                             </td>
                             <td class="auto-style2">
                                 <asp:Label ID="Label5" runat="server" Font-Bold="True" ForeColor="#66FF66" Text="$#####"></asp:Label>
                             </td>
                         </tr>
                         <tr>
                             <td style="width: 251px">&nbsp;</td>
                             <td class="auto-style1">&nbsp;</td>
                         </tr>
                         <tr>
                             <td style="width: 251px">
                                 <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Descuento Por Afiliado:"></asp:Label>
                             </td>
                             <td class="auto-style1">
                                 <asp:Label ID="Label6" runat="server" Font-Bold="True" ForeColor="Red" Text="$#####"></asp:Label>
                             </td>
                         </tr>
                         <tr>
                             <td style="width: 251px; height: 20px"></td>
                             <td class="auto-style3"></td>
                         </tr>
                         <tr>
                             <td style="width: 251px">
                                 <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Total: "></asp:Label>
                             </td>
                             <td class="auto-style1">
                                 <asp:Label ID="Label7" runat="server" Font-Bold="True" ForeColor="#FFCC00" Text="$#####"></asp:Label>
                             </td>
                         </tr>
                         <tr>
                             <td style="width: 251px">&nbsp;</td>
                             <td class="auto-style1">&nbsp;</td>
                         </tr>
                         <tr>
                             <td colspan="2">
                                 <asp:Button ID="Button1" runat="server" Text="Pagar" Width="118px" BackColor="#33CC33" Font-Bold="True" CssClass="btn_pay" Height="36px" />
                             </td>
                         </tr>
                     </table>
                        
                </div>
               
            </td>
          
        </tr>
        <tr>
            <td colspan="2" class="auto-style4">
                
                </td>
            <td class="auto-style4">
                
                </td>
        </tr>
        <tr>
            <td colspan="3">
                
                <hr style="border:1px solid deepskyblue;"/>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                
                &nbsp;</td>
            <td>
                
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" class="auto-style10">
                
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

