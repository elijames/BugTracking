<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="BugHistory.aspx.cs" Inherits="BugHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<h1>Bug History</h1>
<asp:GridView ID="bh" runat="server" DataKeyNames="Status" DataSourceID="SqlDataSource2">
            <Columns>
                <asp:BoundField DataField="ReportDate" HeaderText="ReportDate" 
                    SortExpression="ReportDate" />
                <asp:BoundField DataField="SystemName" HeaderText="SystemName" 
                    SortExpression="SystemName" />
                <asp:BoundField DataField="Status" HeaderText="Status" ReadOnly="True" 
                    SortExpression="Status" />
                <asp:BoundField DataField="Severity" HeaderText="Severity" 
                    SortExpression="Severity" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:WebQAConnectionString %>" 
            SelectCommand="GetAllIssuesForAllTime" SelectCommandType="StoredProcedure">
        </asp:SqlDataSource>
</asp:Content>

