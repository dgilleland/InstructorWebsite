<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="WebApp.Account.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <asp:Repeater ID="CoursesRepeater" runat="server"
                 ItemType="WebApp.Account.Model.CourseOffering"
                 DataSourceID="CourseOfferingDataSource">
                <ItemTemplate>
                    <div>
                        <%# $"{Item.CourseNumber} - {Item.Term.Start} {Item.Term.SchoolYear}" %>
                        (<%# Item.Section %>)
                        <%# Item.Name %>
                        <blockquote>
                            <asp:Repeater ID="StudentsRepeater" runat="server"
                                 ItemType="WebApp.Account.Model.UserAccount"
                                 DataSource="<%# Item.Students.Values %>">
                                <ItemTemplate>
                                    <div>
                                        <%# Item.FirstName %>
                                        <%# Item.LastName %>
                                        &mdash;
                                        <%# Item.GitHubUsername %>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </blockquote>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:ObjectDataSource runat="server" ID="CourseOfferingDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="ListAllCourses" TypeName="WebApp.Account.BLL.AccountManager"></asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>
