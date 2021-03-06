﻿<%@ Page Title="Add Category" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddBookCategory.aspx.cs" Inherits="BookLibrary.Admin.AddBookCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: Page.Title %></h1>
    <div class="form-horizontal">
        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
            <p class="text-danger">
                <asp:Literal runat="server" ID="FailureText" />
            </p>
        </asp:PlaceHolder>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="BookCategoryName" CssClass="col-md-2 control-label">Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="BookCategoryName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="BookCategoryName" CssClass="text-danger" ErrorMessage="The Name field is required." Display="Dynamic" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="SaveBookCategoryButton_Click" Text="Save" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
