<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CompleteRegistration.aspx.cs" Inherits="WebApp.Account.CompleteRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="page-header">Complete Your Registration</h1>
    <div class="row">
        <div class="col-md-6">
            <asp:Panel ID="SelfRegistrationPanel" runat="server" Visible="false">
                <h3>Your Registration Details</h3>
                <asp:Label ID="Label1" runat="server" AssociatedControlID="LoginName">Login Name</asp:Label>
                <asp:TextBox ID="LoginName" runat="server" CssClass="form-control" Enabled="false" />

                <asp:Label ID="Label2" runat="server" AssociatedControlID="Surname">Surname (Last Name)</asp:Label>
                <asp:TextBox ID="Surname" runat="server" CssClass="form-control" Enabled="false" />

                <asp:Label ID="Label3" runat="server" AssociatedControlID="FirstName">Given (First) Name</asp:Label>
                <asp:TextBox ID="FirstName" runat="server" CssClass="form-control" Enabled="false" />

                <asp:Label ID="Label4" runat="server" AssociatedControlID="EMail">Assigned Email</asp:Label>
                <asp:TextBox ID="EMail" runat="server" CssClass="form-control" Enabled="false" />

                <asp:Label ID="Label5" runat="server" AssociatedControlID="CourseFullName">Full Course Details</asp:Label>
                <asp:TextBox ID="CourseFullName" runat="server" CssClass="form-control" Enabled="false" />

                <asp:Label ID="Label6" runat="server" AssociatedControlID="CourseShortName">Short Course Name</asp:Label>
                <asp:TextBox ID="CourseShortName" runat="server" CssClass="form-control" Enabled="false" />
            </asp:Panel>
            <asp:Label ID="MessageLabel" runat="server" />
        </div>
        <div class="col-md-6">
            <h3>Additional Registration Details</h3>
            <p>Your instructor has indicated you need the following additional details to complete your registration.</p>
        </div>
    </div>
    <%--Override Site.css that sets a max-width to these input controls--%>
    <style>
        input,
        select,
        textarea {
            max-width: none;
        }
    </style>
</asp:Content>
