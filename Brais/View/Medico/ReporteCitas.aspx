<%@ Page Title="" Language="C#" MasterPageFile="~/View/Medico/MPMedico.master" AutoEventWireup="true" CodeFile="~/Controller/Medico/ReporteCitas.aspx.cs" Inherits="View_Medico_ReporteCitas" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenido" Runat="Server">
    <div style="height:50px">
    </div>
    <CR:CrystalReportViewer ID="CRV_Pacientes" runat="server" AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="50px" ReportSourceID="CRS_Pacientes" ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="350px" />
    <CR:CrystalReportSource ID="CRS_Pacientes" runat="server">
        <Report FileName="~\View\Medico\Reportes\RpCitasPacientes.rpt">
        </Report>
    </CR:CrystalReportSource>
</asp:Content>

