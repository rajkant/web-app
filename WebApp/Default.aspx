<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<meta name="viewport" content="width=device-width, initial-scale=1"/>
<style>
* {
  box-sizing: border-box;
}

body {
  margin: 0;
  font-family: Arial;
  font-size: 17px;
}

#video {
  position: fixed;
  right: 0;
  bottom: 0;
  min-width: 100%; 
  min-height: 100%;
}

.content {
  position: fixed;
  bottom: 0;
  background: Transparent;
  color: #f1f1f1;
  width: 100%;
  padding: 20px;
  opacity: 0;
  transition: opacity 0s 1s;
}

.content:hover {
    opacity: 1;
    transition: opacity 0s;
}

button {
  width: 200px;
  font-size: 18px;
  padding: 10px;
  border: none;
  background: #000;
  color: black;
  cursor: pointer;
  background-color: Transparent;
  background-repeat:no-repeat;
  overflow: hidden;
  outline:none;  
}

button:hover {
  background: #ddd;
  color: black;
}
</style> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">  
 
</asp:Content>
  