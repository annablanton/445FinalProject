<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RegisterMember.aspx.cs" Inherits="_445FinalProject.WebForm2" %>

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
        		Register Member<br />
                <br />
                <br />
                <br />
        		<asp:Literal ID="Literal1" runat="server"></asp:Literal>
			</div>
    		<p class="auto-style2">
				<asp:Literal ID="Literal2" runat="server" Text="First name*:"></asp:Literal>
				<asp:TextBox ID="TextBox1" runat="server" style="text-align: center; margin-left: 10px"></asp:TextBox>
			</p>
			<asp:Literal ID="Literal3" runat="server" Text="Last name*:"></asp:Literal>
			<asp:TextBox ID="TextBox2" runat="server" style="text-align: center; margin-left: 10px"></asp:TextBox>
			<p class="auto-style1">
				<asp:Literal ID="Literal4" runat="server" Text="Birth date (yyyy-mm-dd)*:"></asp:Literal>
				<asp:TextBox ID="TextBox3" runat="server" style="margin-left: 10px"></asp:TextBox>
			</p>
			<p>
				<asp:Literal ID="Literal5" runat="server" Text="Membership date (yyy-mm-dd)*:"></asp:Literal>
				<asp:TextBox ID="TextBox4" runat="server" style="margin-left: 10px"></asp:TextBox>
			</p>
			<p>
				<asp:Literal ID="Literal6" runat="server" Text="Phone number (9 digits):"></asp:Literal>
				<asp:TextBox ID="TextBox5" runat="server" style="margin-left: 10px"></asp:TextBox>
			</p>
			<p>
				<asp:Literal ID="Literal7" runat="server" Text="Email:"></asp:Literal>
				<asp:TextBox ID="TextBox6" runat="server" style="margin-left: 10px"></asp:TextBox>
			</p>
			<p>
				<asp:Literal ID="Literal8" runat="server" Text="Card printed:"></asp:Literal>
				<asp:CheckBox ID="CheckBox1" runat="server" />
			</p>
			<p>
				<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="margin-left: 0px" Text="Button" />
			</p>
	<div>
		<asp:GridView ID ="MemberTable" runat="server" AutoGenerateColumns="false" style="margin-left: 148px">
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
