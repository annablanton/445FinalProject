<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddEvent.aspx.cs" Inherits="_445FinalProject.AddEvent" %>
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
      		Add Event<br />
            <br />
            <br />
            <br />
      		<asp:Literal ID="Literal1" runat="server"></asp:Literal>
	</div>
   	<p class="auto-style2">
		<asp:Literal ID="Literal2" runat="server" Text="Event date (yyyy-mm-dd):"></asp:Literal>
		<asp:TextBox ID="TextBox1" runat="server" style="text-align: center; margin-left: 10px"></asp:TextBox>
	</p>
	<asp:Literal ID="Literal3" runat="server" Text="Start time (hh:mm:ss):"></asp:Literal>
	<asp:TextBox ID="TextBox2" runat="server" style="text-align: center; margin-left: 10px"></asp:TextBox>

	<p class="auto-style2">
		<asp:Literal ID="Literal4" runat="server" Text="End time (hh:mm:ss):"></asp:Literal>
		<asp:TextBox ID="TextBox3" runat="server" style="text-align: center; margin-left: 10px"></asp:TextBox>
	</p>
	<p class="auto-style2">
		<asp:Literal ID="Literal5" runat="server" Text="Event name:"></asp:Literal>
		<asp:TextBox ID="TextBox4" runat="server" style="text-align: center; margin-left: 10px"></asp:TextBox>
	</p>
	<p class="auto-style2">
		<asp:Literal ID="Literal6" runat="server" Text="Event description:"></asp:Literal>
		<asp:TextBox ID="TextBox5" runat="server" style="text-align: center; margin-left: 10px"></asp:TextBox>
	</p>
	<p class="auto-style2">
		<asp:Literal ID="Literal7" runat="server" Text="Staff needed*:"></asp:Literal>
		<asp:TextBox ID="TextBox6" runat="server" style="text-align: center; margin-left: 10px"></asp:TextBox>
	</p>
	<p class="auto-style1">
		<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="margin-left: 0px" Text="Button" />
	</p>
	<asp:GridView ID ="EventTable" runat="server" AutoGenerateColumns="false" style="margin-left: 303px">
		<Columns>
			<asp:BoundField DataField="EventId" HeaderText ="Event ID" />
			<asp:BoundField DataField="EventDate" HeaderText ="Date" />
			<asp:BoundField DataField="EventStartTime" HeaderText ="Start time" />
			<asp:BoundField DataField="EventEndTime" HeaderText ="End time" />
			<asp:BoundField DataField="EventName" HeaderText ="Event name" />
			<asp:BoundField DataField="EventStaffNeeded" HeaderText ="Staff needed" />
		</Columns>
	</asp:GridView>
</asp:Content>
