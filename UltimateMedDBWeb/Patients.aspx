<%@ Page Title="" Language="C#" MasterPageFile="~/UltimateMedDBMasterPage.master" AutoEventWireup="true" CodeFile="Patients.aspx.cs" Inherits="Patients" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">

    <asp:GridView ID="gvPatients" DataSourceID="odsPatients" runat="server"></asp:GridView>
    <asp:ObjectDataSource ID="odsPatients" runat="server" SelectMethod="GetAllPatients" TypeName="UltimateMedDB.Business.Patient"></asp:ObjectDataSource>
    <p>
    </p>
</asp:Content>

