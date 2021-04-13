<%@ Page Title="" Language="C#" MasterPageFile="~/UltimateMedDBMasterPage.master" AutoEventWireup="true" CodeFile="Bills.aspx.cs" Inherits="Bills" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">


    <asp:GridView ID="gvBills" DataSourceID="odsBills" runat="server"></asp:GridView>
    <asp:ObjectDataSource ID="odsBills" runat="server" SelectMethod="GetAllBillingRecords" TypeName="UltimateMedDB.Business.Bill"></asp:ObjectDataSource>
    <p>
    </p>

    <asp:GridView ID="gvBillsbyPid" runat="server"></asp:GridView>
    <asp:ObjectDataSource 
        ID="odsBillByPid" 
        runat="server" 
        TypeName="UltimateMedDB.Business.Bill"
        SelectMethod="GetBillsByPid">
        <SelectParameters>
        <asp:QueryStringParameter
            Name="patient"
            QueryStringField="patient"
            Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>



</asp:Content>

