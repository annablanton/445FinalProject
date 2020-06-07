<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddCheckoutCard.aspx.cs" Inherits="_445FinalProject.AddCheckoutCard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <title></title>
		<style type="text/css">
			.auto-style2 {
				text-align: center;
				margin-left: 0px;
			}
			#form1 {
				text-align: center;
			}
		</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div aria-checked="undefined" style="text-align: center; margin-left: 0px">
       	Add Checkout Card<br />
        <br />
        <br />
        <br />
       	<asp:Literal ID="Literal1" runat="server"></asp:Literal>
	</div>
    <p class="auto-style2">
		<asp:Literal ID="Literal2" runat="server" Text="Member ID*:"></asp:Literal>
		<asp:TextBox ID="TextBox1" runat="server" style="text-align: center; margin-left: 10px"></asp:TextBox>
	</p>

	<p>
		<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="margin-left: 0px" Text="Button" />
	</p>
    <p>
		&nbsp;</p>

	<div>
		<asp:GridView ID ="CardTable" runat="server" AutoGenerateColumns="false" style="margin-left: 421px">

			<Columns>
				<asp:BoundField DataField="CardNumber" HeaderText ="Card number" />
				<asp:BoundField DataField="MemberId" HeaderText ="Member ID" />
				<asp:BoundField DataField="MemberName" HeaderText ="Member name" />
			</Columns>
		</asp:GridView>
		<asp:GridView ID ="MemberTable" runat="server" AutoGenerateColumns="false" style="margin-left: 165px; margin-top: 30px;" OnSelectedIndexChanged="MemberTable_SelectedIndexChanged">
			<Columns>
				<asp:BoundField DataField="MemberFirstName" HeaderText ="First name" />
				<asp:BoundField DataField="MemberLastName" HeaderText ="Last name" />
				<asp:BoundField DataField="MemberBirthDate" HeaderText ="Birth date" />
				<asp:BoundField DataField="MembershipDate" HeaderText ="Membership date" />
				<asp:BoundField DataField="MemberPhoneNumber" HeaderText ="Phone number" />
				<asp:BoundField DataField="MemberEmail" HeaderText ="Email" />
				<asp:BoundField DataField="CardPrintDate" HeaderText ="Card print date" />
			</Columns>
		</asp:GridView>
	</div>
</asp:Content>
