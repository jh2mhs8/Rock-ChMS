﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Attributes.ascx.cs" Inherits="RockWeb.Blocks.Administration.Attributes" %>

<asp:UpdatePanel ID="upPanel" runat="server">
    <ContentTemplate>
        <asp:Panel ID="pnlList" runat="server">

            <Rock:GridFilter ID="rFilter" runat="server">
                <Rock:LabeledDropDownList ID="ddlCategoryFilter" runat="server" LabelText="Category"  />
            </Rock:GridFilter>
            <Rock:Grid ID="rGrid" runat="server" AllowSorting="true" RowItemText="setting" OnRowSelected="rGrid_Edit">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                    <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:BoundField DataField="FieldType" HeaderText="Type" />
                    <Rock:BoolField DataField="IsMultiValue" HeaderText="Multi-Value" SortExpression="IsMultiValue" />
                    <Rock:BoolField DataField="IsRequired" HeaderText="Required" SortExpression="IsRequired" />
                    <asp:TemplateField>
                        <HeaderTemplate>Default Value</HeaderTemplate>
                        <ItemTemplate>
                            <asp:Literal ID="lDefaultValue" runat="server"></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>Value</HeaderTemplate>
                        <ItemTemplate>
                            <asp:Literal ID="lValue" runat="server"></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <Rock:EditValueField OnClick="rGrid_EditValue" />
                    <Rock:DeleteField OnClick="rGrid_Delete" />
                </Columns>
            </Rock:Grid>

        </asp:Panel>

        <asp:Panel ID="pnlDetails" runat="server" Visible="false">

            <asp:HiddenField ID="hfId" runat="server" />

            <asp:ValidationSummary ID="valSummaryTop" runat="server" HeaderText="Please Correct the Following" CssClass="alert alert-error block-message error" />

            <div class="row-fluid">

                <div class="span6">

                    <fieldset>
                        <legend>
                            <asp:Literal ID="lActionTitle" runat="server"></asp:Literal>
                        </legend>
                        <Rock:DataTextBox ID="tbKey" runat="server" SourceTypeName="Rock.Model.Attribute, Rock" PropertyName="Key" />
                        <Rock:DataTextBox ID="tbName" runat="server" SourceTypeName="Rock.Model.Attribute, Rock" PropertyName="Name" />
                        <Rock:DataTextBox ID="tbCategory" runat="server" SourceTypeName="Rock.Model.Attribute, Rock" PropertyName="Category" />
                        <Rock:DataTextBox ID="tbDescription" runat="server" SourceTypeName="Rock.Model.Attribute, Rock" PropertyName="Description" TextMode="MultiLine" Rows="3" />
                    </fieldset>

                </div>

                <div class="span6">

                    <fieldset>
                        <legend>&nbsp;</legend>
                        <Rock:LabeledDropDownList ID="ddlFieldType" runat="server" LabelText="Field Type"></Rock:LabeledDropDownList>
                        <asp:PlaceHolder ID="phFieldTypeQualifiers" runat="server"></asp:PlaceHolder>
                        <Rock:DataTextBox ID="tbDefaultValue" runat="server" SourceTypeName="Rock.Model.Attribute, Rock" PropertyName="DefaultValue" />
                        <Rock:LabeledCheckBox ID="cbMultiValue" runat="server" LabelText="Allow Multiple Values" />
                        <Rock:LabeledCheckBox ID="cbRequired" runat="server" LabelText="Required" />
                    </fieldset>

                </div>

            </div>

            <div class="actions">
                <asp:LinkButton ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                <asp:LinkButton ID="btnCancel" runat="server" Text="Cancel" CssClass="btn" CausesValidation="false" OnClick="btnCancel_Click" />
            </div>

        </asp:Panel>

        <Rock:ModalDialog ID="modalDetails" runat="server" Title="Attribute">
            <Content>
                <asp:HiddenField ID="hfIdValues" runat="server" />
                <asp:ValidationSummary ID="ValidationSummaryValue" runat="server" HeaderText="Please Correct the Following" CssClass="alert alert-error block-message error" />
                <fieldset>
                    <div class="control-group">
                        <label class="control-label">
                            <asp:Literal ID="lCaption" runat="server"></asp:Literal></label>
                        <div class="controls">
                            <asp:PlaceHolder ID="phEditControl" runat="server"></asp:PlaceHolder>
                        </div>
                    </div>
                </fieldset>
            </Content>
        </Rock:ModalDialog>

        <Rock:NotificationBox ID="nbMessage" runat="server" Title="Error" NotificationBoxType="Error" Visible="false" />

    </ContentTemplate>
</asp:UpdatePanel>
