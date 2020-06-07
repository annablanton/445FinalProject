<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PayLateFees.aspx.cs" Inherits="_445FinalProject.PayLateFees" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
            <title></title>
		<style type="text/css">
			.auto-style1 {
				text-align: center;
			}
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
       	Pay Late Fees<br />
        <br />
        <br />
        <br />
       	<asp:Literal ID="Literal1" runat="server"></asp:Literal>
	</div>
    <p class="auto-style2">
		<asp:Literal ID="Literal2" runat="server" Text="Book ID*:"></asp:Literal>
		<asp:TextBox ID="TextBox1" runat="server" style="text-align: center; margin-left: 10px"></asp:TextBox>
	</p>
		<asp:Literal ID="Literal3" runat="server" Text="Copy number*:"></asp:Literal>
		<asp:TextBox ID="TextBox2" runat="server" style="text-align: center; margin-left: 10px"></asp:TextBox>
	<p class="auto-style1">
		<asp:Literal ID="Literal4" runat="server" Text="Member ID*:"></asp:Literal>
		<asp:TextBox ID="TextBox3" runat="server" style="margin-left: 10px"></asp:TextBox>
	</p>
	<p>
		<asp:Literal ID="Literal5" runat="server" Text="Checkout date (yyyy-mm-dd)*:"></asp:Literal>
		<asp:TextBox ID="TextBox4" runat="server" style="margin-left: 10px"></asp:TextBox>
	</p>

	<p>
		<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="margin-left: 0px" Text="Button" />
	</p>

	<div>
		<asp:GridView ID ="OverdueTable" runat="server" AutoGenerateColumns="false" style="margin-left: 121px">

			<Columns>
				<asp:BoundField DataField="BookId" HeaderText ="Book ID" />
				<asp:BoundField DataField="BookTitle" HeaderText ="Book title" />
				<asp:BoundField DataField="CopyNumber" HeaderText ="Copy number" />
				<asp:BoundField DataField="MemberId" HeaderText ="Member ID" />
				<asp:BoundField DataField="MemberName" HeaderText ="Member name" />
				<asp:BoundField DataField="CheckoutDate" HeaderText ="Checkout date" />
				<asp:BoundField DataField="DaysOverdue" HeaderText ="Days overdue" />
				<asp:BoundField DataField="Fee" HeaderText ="Fee" />
			</Columns>
		</asp:GridView>

	</div>
</asp:Content>
