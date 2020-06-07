<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CheckoutBook.aspx.cs" Inherits="_445FinalProject.CheckoutBook" %>
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
        		Checkout Book<br />
                <br />
                <br />
                <br />
        		<asp:Literal ID="Literal1" runat="server"></asp:Literal>
			</div>
    		<p class="auto-style2">
				<asp:Literal ID="Literal2" runat="server" Text="Book ID*:"></asp:Literal>
				<asp:TextBox ID="TextBox1" runat="server" style="text-align: center; margin-left: 10px"></asp:TextBox>
			</p>
			<asp:Literal ID="Literal3" runat="server" Text="Member ID*:"></asp:Literal>
			<asp:TextBox ID="TextBox2" runat="server" style="text-align: center; margin-left: 10px"></asp:TextBox>
			<p class="auto-style1">
			<asp:Literal ID="Literal4" runat="server" Text="Branch ID:"></asp:Literal>
			<asp:TextBox ID="TextBox3" runat="server" style="text-align: center; margin-left: 10px"></asp:TextBox>
			</p>

				<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="margin-left: 0px" Text="Button" />

	<asp:GridView ID ="CheckoutTable" runat="server" AutoGenerateColumns="false" style="margin-left: 123px; margin-top: 30px;">
			<Columns>
				<asp:BoundField DataField="BookId" HeaderText ="Book ID" />
				<asp:BoundField DataField="BookTitle" HeaderText ="Book title" />
				<asp:BoundField DataField="CopyNumber" HeaderText ="Copy number" />
				<asp:BoundField DataField="MemberId" HeaderText ="Member ID" />
				<asp:BoundField DataField="MemberName" HeaderText ="Member name" />
				<asp:BoundField DataField="CheckoutDate" HeaderText ="Checkout date" />
				<asp:BoundField DataField="CheckoutDueDate" HeaderText ="Checkout due date" />
				<asp:BoundField DataField="IsReturned" HeaderText ="Returned" />
			</Columns>
		</asp:GridView>

	<asp:GridView ID ="StockTable" runat="server" AutoGenerateColumns="false" style="margin-left: 413px; margin-top: 30px;" OnSelectedIndexChanged="StockTable_SelectedIndexChanged">
			<Columns>
				<asp:BoundField DataField="BookTitle" HeaderText ="Book in stock" />
				<asp:BoundField DataField="BookId" HeaderText ="Book ID" />
				<asp:BoundField DataField="BranchId" HeaderText ="Branch ID" />
				<asp:BoundField DataField="BranchName" HeaderText ="Branch name" />
			</Columns>
		</asp:GridView>

	<asp:GridView ID ="MemberTable" runat="server" AutoGenerateColumns="false" style="margin-left: 516px; margin-top: 30px;" OnSelectedIndexChanged="StockTable_SelectedIndexChanged">
			<Columns>
				<asp:BoundField DataField="MemberId" HeaderText ="Member ID" />
				<asp:BoundField DataField="MemberName" HeaderText ="Member name" />
			</Columns>
		</asp:GridView>
</asp:Content>
