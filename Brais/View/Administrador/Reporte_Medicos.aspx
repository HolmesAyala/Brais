<%@ Page Title="" Language="C#" MasterPageFile="~/View/Administrador/MPAdministrador.master" AutoEventWireup="true" CodeFile="Reporte_Medicos.aspx.cs" Inherits="View_Administrador_Reporte_Medicos" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenido" Runat="Server">
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="50px" ReportSourceID="CR_medicos" ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="350px" />
    <CR:CrystalReportSource ID="CR_medicos" runat="server">
        <Report FileName="~\View\Administrador\Reportes\RpMedico.rpt">
        </Report>
    </CR:CrystalReportSource>
</asp:Content>

