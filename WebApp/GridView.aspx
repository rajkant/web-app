<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GridView.aspx.cs" Inherits="WebApp.GridView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:GridView id="myGridView" runat="server" AutoGenerateColumns="False" 
	ShowFooter="True" 
	DataKeyNames="CustomerID" 
	OnRowCancelingEdit="modCancelCommand" 
	OnRowCommand="myGridView_RowCommand" 
	OnRowDeleting="modDeleteCommand" 
	OnRowEditing="modEditCommand" 
	OnRowUpdating="modUpdateCommand">

	<Columns>
	<asp:TemplateField HeaderText="CustomerID">
		<ItemTemplate>
			<asp:Label id="lblCustomerID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CustomerID") %>'></asp:Label>
		</ItemTemplate>
		<EditItemTemplate>
			<asp:TextBox id="txtEditCustomerID" size="5" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CustomerID") %>'></asp:TextBox>
		</EditItemTemplate>
		<FooterTemplate>
			<asp:TextBox id="txtAddCustomerID" size="5" runat="server"></asp:TextBox>
		</FooterTemplate>
	</asp:TemplateField>

	<asp:TemplateField HeaderText="Name">
		<ItemTemplate>
			<asp:Label id="lblName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Name") %>'></asp:Label>
		</ItemTemplate>
		<EditItemTemplate>
			<asp:TextBox id="txtEditName" size="10" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Name") %>'></asp:TextBox>
		</EditItemTemplate>
		<FooterTemplate>
			<asp:TextBox id="txtAddName" size="10" runat="server"></asp:TextBox>
		</FooterTemplate>
	</asp:TemplateField>

	<asp:TemplateField HeaderText="Email">
		<ItemTemplate>
			<asp:Label id="lblEmail" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Email") %>'></asp:Label>
		</ItemTemplate>
		<EditItemTemplate>
			<asp:TextBox id="txtEditEmail" size="20" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Email") %>'></asp:TextBox>
		</EditItemTemplate>
		<FooterTemplate>
			<asp:TextBox id="txtAddEmail" size="20" runat="server"></asp:TextBox>
		</FooterTemplate>
	</asp:TemplateField>

	<asp:TemplateField HeaderText="CountryCode">
		<ItemTemplate>
			<asp:Label id="lblCountryCode" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CountryCode") %>'></asp:Label>
		</ItemTemplate>
		<EditItemTemplate>
			<asp:TextBox id="txtEditCountryCode" size="2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CountryCode") %>'></asp:TextBox>
		</EditItemTemplate>
		<FooterTemplate>
			<asp:TextBox id="txtAddCountryCode" size="2" runat="server"></asp:TextBox>
		</FooterTemplate>
	</asp:TemplateField>

	<asp:TemplateField HeaderText="Budget">
		<ItemTemplate>
			<asp:Label id="lblBudget" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Budget") %>'></asp:Label>
		</ItemTemplate>
		<EditItemTemplate>
			<asp:TextBox id="txtEditBudget" size="6" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Budget") %>'></asp:TextBox>
		</EditItemTemplate>
		<FooterTemplate>
			<asp:TextBox id="txtAddBudget" size="6" runat="server"></asp:TextBox>
		</FooterTemplate>
	</asp:TemplateField>

	<asp:TemplateField HeaderText="Used">
		<ItemTemplate>
			<asp:Label id="lblUsed" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Used") %>'></asp:Label>
		</ItemTemplate>
		<EditItemTemplate>
			<asp:TextBox id="txtEditUsed" size="6" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Used") %>'></asp:TextBox>
		</EditItemTemplate>
		<FooterTemplate>
			<asp:TextBox id="txtAddUsed" size="6" runat="server"></asp:TextBox>
			<asp:Button id="btnAdd" runat="server" Text="Add" CommandName="Add"></asp:Button>
		</FooterTemplate>
	</asp:TemplateField>

	<asp:CommandField ShowEditButton="True" CancelText="Cancel" DeleteText="Delete" EditText="Edit" UpdateText="Update" HeaderText="Modify"  />
	<asp:CommandField ShowDeleteButton="True" HeaderText="Delete" />
	
	</Columns>
    </asp:GridView>
</asp:Content>
