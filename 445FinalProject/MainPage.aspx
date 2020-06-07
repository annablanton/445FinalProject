<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="_445FinalProject.MainPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    Main Page<br />
    <br />
    <br />
    <br />
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="https://localhost:44368/AddCopy.aspx">Add Book Copy</asp:HyperLink>
    <br />
    <br />
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="https://localhost:44368/AddEvent.aspx">Add Event</asp:HyperLink>
    <br />
    <br />
    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="https://localhost:44368/CheckoutBook.aspx">Checkout Book</asp:HyperLink>
    <br />
    <br />
    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="https://localhost:44368/RegisterMember.aspx">Register Member</asp:HyperLink>
    <br />
    <br />
    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="https://localhost:44368/HireStaff.aspx">Hire Staff</asp:HyperLink>
    <br />
    <br />
    <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="https://localhost:44368/PayLateFees.aspx">Pay Late Fees</asp:HyperLink>
    <br />
    <br />
    <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="https://localhost:44368/AddCheckoutCard.aspx">Add Checkout Card</asp:HyperLink>

</asp:Content>
