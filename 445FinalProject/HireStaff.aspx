<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="HireStaff.aspx.cs" Inherits="_445FinalProject.HireStaff" %>
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
       	Hire Staff<br />
        <br />
        <br />
        <br />
       	<asp:Literal ID="Literal1" runat="server"></asp:Literal>
	</div>
    <p class="auto-style2">
		<asp:Literal ID="Literal2" runat="server" Text="First name:"></asp:Literal>
		<asp:TextBox ID="TextBox1" runat="server" style="text-align: center; margin-left: 10px"></asp:TextBox>
	</p>
		<asp:Literal ID="Literal3" runat="server" Text="Last name:"></asp:Literal>
		<asp:TextBox ID="TextBox2" runat="server" style="text-align: center; margin-left: 10px"></asp:TextBox>
	<p class="auto-style1">
		<asp:Literal ID="Literal4" runat="server" Text="Hire date(yyyy-mm-dd)*:"></asp:Literal>
		<asp:TextBox ID="TextBox3" runat="server" style="margin-left: 10px"></asp:TextBox>
	</p>
	<p>
		<asp:Literal ID="Literal5" runat="server" Text="Position:"></asp:Literal>
		<asp:TextBox ID="TextBox4" runat="server" style="margin-left: 10px"></asp:TextBox>
	</p>

	<p>
		<asp:Literal ID="Literal6" runat="server" Text="Branch ID*:"></asp:Literal>
		<asp:TextBox ID="TextBox5" runat="server" style="margin-left: 10px"></asp:TextBox>
	</p>

	<p>
		<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="margin-left: 0px" Text="Button" />
	</p>

	<div>
		<asp:GridView ID ="StaffTable" runat="server" AutoGenerateColumns="false" style="margin-left: 371px">

			<Columns>
				<asp:BoundField DataField="BranchId" HeaderText ="Branch ID" />
				<asp:BoundField DataField="StaffId" HeaderText ="Staff ID" />
				<asp:BoundField DataField="StaffName" HeaderText ="First name" />
				<asp:BoundField DataField="StaffHireDate" HeaderText ="Last name" />
				<asp:BoundField DataField="StaffPosition" HeaderText ="Birth date" />
			</Columns>
		</asp:GridView>

		<asp:GridView ID ="BranchTable" runat="server" AutoGenerateColumns="false" style="margin-left: 529px; margin-top: 30px;">

			<Columns>
				<asp:BoundField DataField="BranchId" HeaderText ="Branch ID" />
				<asp:BoundField DataField="BranchName" HeaderText ="Branch name" />
			</Columns>
		</asp:GridView>
	</div>
</asp:Content>
