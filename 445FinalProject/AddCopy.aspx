<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddCopy.aspx.cs" Inherits="_445FinalProject.WebForm3" %>
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
        		Add Book Copy<br />
                <br />
                <br />
                <br />
        		<asp:Literal ID="Literal1" runat="server"></asp:Literal>
			</div>
    		<p class="auto-style2">
				<asp:Literal ID="Literal2" runat="server" Text="Book ID*:"></asp:Literal>
				<asp:TextBox ID="TextBox1" runat="server" style="text-align: center; margin-left: 10px"></asp:TextBox>
			</p>
			<asp:Literal ID="Literal3" runat="server" Text="Branch ID:"></asp:Literal>
			<asp:TextBox ID="TextBox2" runat="server" style="text-align: center; margin-left: 10px"></asp:TextBox>
			<p class="auto-style1">
				<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="margin-left: 0px" Text="Button" />
			</p>
		<asp:GridView ID ="MemberTable" runat="server" AutoGenerateColumns="false" style="margin-left: 337px">
			<Columns>
				<asp:BoundField DataField="BookId" HeaderText ="Book ID" />
				<asp:BoundField DataField="BookTitle" HeaderText ="Book title" />
				<asp:BoundField DataField="CopyNumber" HeaderText ="Copy number" />
				<asp:BoundField DataField="BranchId" HeaderText ="Branch ID" />
				<asp:BoundField DataField="BranchName" HeaderText ="Branch name" />
			</Columns>
		</asp:GridView>

	<asp:GridView ID ="BookTable" runat="server" AutoGenerateColumns="false" style="margin-left: 478px; margin-top: 30px;">
		<Columns>
			<asp:BoundField DataField="BookId" HeaderText ="Book ID" />
			<asp:BoundField DataField="BookTitle" HeaderText ="Book title" />
			<asp:BoundField DataField="AuthorName" HeaderText ="Author" />
		</Columns>
	</asp:GridView>

	<asp:GridView ID ="BranchTable" runat="server" AutoGenerateColumns="false" style="margin-left: 514px; margin-top: 30px;">
		<Columns>
			<asp:BoundField DataField="BranchId" HeaderText ="Branch ID" />
			<asp:BoundField DataField="BranchName" HeaderText ="Branch name" />
		</Columns>
	</asp:GridView>
</asp:Content>
