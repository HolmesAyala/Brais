<%@ Page Title="" Language="C#" MasterPageFile="~/View/Usuario/MPUsuario.master" AutoEventWireup="true" CodeFile="~/Controller/Usuario/ReporteHistorial.aspx.cs" Inherits="View_Usuario_ReporteHistorial" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenido" Runat="Server">
    <div style="height:80px"></div>
    <CR:CrystalReportViewer ID="CRV_Historial" runat="server" AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="50px" ReportSourceID="CRS_Historial" ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="350px" />
    <CR:CrystalReportSource ID="CRS_Historial" runat="server">
        <Report FileName="~\View\Usuario\Reportes\RpHistorialMedico.rpt">
        </Report>
    </CR:CrystalReportSource>
</asp:Content>

