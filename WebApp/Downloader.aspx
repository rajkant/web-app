<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Downloader.aspx.cs" Inherits="WebApp.Downloader" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
          <p>
        <asp:TextBox ID="TextBox1" runat="server" Width="662px"></asp:TextBox>
        <br />
    </p>
        <p>
            <asp:Button ID="btnDownload" runat="server" OnClick="btnDownload_Click" Text="Download" />
            <asp:Button ID="btnGetLinks" runat="server" Text="GetLinks" OnClick="btnGetLinks_Click" />
        </p>
    <br />
    <asp:Literal ID="LiteralText" runat="server" Text="This is example of Literal"></asp:Literal>
</asp:Content>
