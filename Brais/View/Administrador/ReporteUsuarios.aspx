<%@ Page Title="" Language="C#" MasterPageFile="~/View/Administrador/MPAdministrador.master" AutoEventWireup="true" CodeFile="~/Controller/Administrador/Reportes/ReporteUsuarios.aspx.cs" Inherits="View_Administrador_ReporteUsuarios" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenido" Runat="Server">
    <CR:CrystalReportViewer ID="CRV_Usuarios" runat="server" AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="50px" ReportSourceID="CRS_Usuarios" ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="350px" />
    <CR:CrystalReportSource ID="CRS_Usuarios" runat="server">
        <Report FileName="~\View\Administrador\Reportes\RpUsuarios.rpt">
        </Report>
    </CR:CrystalReportSource>
</asp:Content>

