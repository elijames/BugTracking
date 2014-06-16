<%@ Page Title="Report A Bug" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ReportABug.aspx.cs" Inherits="About" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Report a Bug</h2>
    <p>
    </p>
    <asp:Panel ID="Panel1" runat="server" Height="321px" style="text-align: left">
        <div class="style1">
            System:&nbsp;
            <asp:DropDownList ID="BuggedSystemListBox" runat="server" 
                onselectedindexchanged="BuggedSystemListBox_SelectedIndexChanged" 
                AutoPostBack="True">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Version:
            <asp:TextBox ID="version" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </div>
        <asp:SqlDataSource ID="GetSystemName" runat="server" 
            ConnectionString="<%$ ConnectionStrings:WebQAConnectionString %>" 
            SelectCommand="getSystemName" SelectCommandType="StoredProcedure">
        </asp:SqlDataSource>
        <div class="style1">
            <br />
            <br />
            Function Area:&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="functionareabox" runat="server" Width="373px"></asp:TextBox>
            <br />
            Subject:&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="Subject" runat="server" Width="406px"></asp:TextBox>
            <br />
            Severity:&nbsp;&nbsp;
            <asp:DropDownList ID="BugSev" runat="server" AutoPostBack="True">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp; Resolution:&nbsp;
            <asp:DropDownList ID="Resolution" runat="server" AutoPostBack="True">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Status:&nbsp;&nbsp;<asp:DropDownList ID="Status" 
                runat="server" AutoPostBack="True">
            </asp:DropDownList>
            <br />
            Reported By:&nbsp;<asp:TextBox ID="flyTrapper" runat="server"></asp:TextBox>
            &nbsp; Extension:&nbsp;&nbsp;<asp:TextBox ID="FlyTrapperExtension" runat="server"></asp:TextBox>
            <br />
            Description of Error and Steps Taken to Reproduce:<br />&nbsp;<asp:TextBox 
                ID="bugDescription" runat="server" Height="101px" Width="538px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Submit Issue" 
                onclick="Button1_Click" />
            &nbsp;<asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                ConnectionString="<%$ ConnectionStrings:WebQAConnectionString %>" 
                SelectCommand="getStatus" SelectCommandType="StoredProcedure">
            </asp:SqlDataSource>
            &nbsp;<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:WebQAConnectionString %>" 
                SelectCommand="getresolution" SelectCommandType="StoredProcedure">
            </asp:SqlDataSource>
            &nbsp;<asp:SqlDataSource ID="severity" runat="server" 
                ConnectionString="<%$ ConnectionStrings:WebQAConnectionString %>" 
                SelectCommand="getSeverity" SelectCommandType="StoredProcedure">
            </asp:SqlDataSource>
        </div>
    </asp:Panel>
    <p>
        &nbsp;</p>
</asp:Content>