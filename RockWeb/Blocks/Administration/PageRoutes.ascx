﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PageRoutes.ascx.cs" Inherits="RockWeb.Blocks.Administration.PageRoutes" %>

<asp:UpdatePanel ID="upPageRoutes" runat="server">
    <ContentTemplate>

        <asp:Panel ID="pnlList" runat="server">
            <Rock:Grid ID="gPageRoutes" runat="server" AllowSorting="true" OnRowSelected="gPageRoutes_Edit">
                <Columns>
                    <asp:BoundField DataField="Route" HeaderText="Route" SortExpression="Route" />
                    <asp:BoundField DataField="Page.Name" HeaderText="Page Name" SortExpression="Page.Name" />
                    <Rock:BoolField DataField="IsSystem" HeaderText="System" SortExpression="IsSystem" />
                    <Rock:DeleteField OnClick="gPageRoutes_Delete" />
                </Columns>
            </Rock:Grid>
        </asp:Panel>

        <asp:Panel ID="pnlDetails" runat="server" Visible="false">

            <asp:HiddenField ID="hfPageRouteId" runat="server" />

            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-error" />

            <fieldset>
                <legend>
                    <asp:Literal ID="lActionTitle" runat="server" />
                    <i id="iconIsSystem" runat="server" class="icon-eye-open"></i>
                </legend>
                <Rock:DataDropDownList ID="ddlPageName" runat="server" DataTextField="DropDownListText" DataValueField="Id" SourceTypeName="Rock.Model.Page, Rock" PropertyName="Title" LabelText="Page Title" />
                <Rock:DataTextBox ID="tbRoute" runat="server" SourceTypeName="Rock.Model.PageRoute, Rock" PropertyName="Route" />
            </fieldset>

            <div class="actions">
                <asp:LinkButton ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                <asp:LinkButton ID="btnCancel" runat="server" Text="Cancel" CssClass="btn" CausesValidation="false" OnClick="btnCancel_Click" />
            </div>

        </asp:Panel>

        <Rock:NotificationBox ID="nbMessage" runat="server" Title="Error" NotificationBoxType="Error" Visible="false" />

    </ContentTemplate>
</asp:UpdatePanel>


