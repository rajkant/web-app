<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Scheduler.aspx.cs" Inherits="WebApp.Scheduler" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
        <p>
            <asp:Button ID="btnScheduleTask" runat="server" Text="ScheduleTask" OnClick="btnScheduleTask_Click" />
            <asp:Button ID="btnListSchedule" runat="server" Text="ListTask" OnClick="btnListSchedule_Click" />
            <asp:Button ID="btnStopScheduler" runat="server" Text="StopScheduler" OnClick="btnStopScheduler_Click" />
        </p>
    <br />
    <asp:Literal ID="LiteralText" runat="server" Text="This is example of Literal"></asp:Literal>
</asp:Content>
