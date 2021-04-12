<%@ Page Title="" Language="C#" MasterPageFile="~/UltimateMedDBMasterPage.master" AutoEventWireup="true" CodeFile="Labs.aspx.cs" Inherits="Labs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">

    <asp:GridView ID="gvLabs" DataSourceID="odsLabs" runat="server"></asp:GridView>
    <asp:ObjectDataSource ID="odsLabs" runat="server" SelectMethod="GetAllLabs" TypeName="UltimateMedDB.Business.AllLabs"></asp:ObjectDataSource>
</asp:Content>

