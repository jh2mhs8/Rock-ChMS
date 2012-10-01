<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DefinedTypes.ascx.cs" Inherits="RockWeb.Blocks.Administration.DefinedTypes" %>

<script type="text/javascript">

    var type = null;
    var attribute = null;
    var value = null;

    

</script>

<asp:UpdatePanel ID="upSettings" runat="server">
<ContentTemplate>

    <asp:Panel ID="pnlMessage" runat="server" Visible="false" CssClass="alert-message block-massage error"/>
    
    <asp:Panel ID="pnlTypes" runat="server">

        <div class="grid-filter">
            <fieldset>
                <legend>Filter Options</legend>
                <Rock:LabeledDropDownList ID="ddlCategoryFilter" runat="server" LabelText="Category" AutoPostBack="true" OnSelectedIndexChanged="ddlCategoryFilter_SelectedIndexChanged" />
            </fieldset>
        </div>

        <Rock:Grid ID="rGridType" runat="server" AllowSorting="true" ShowHeader="true" EmptyDataText="No Defined Types Found">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" SortExpression="Id"/>
                <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />
                <asp:TemplateField HeaderText="Name" ShowHeader="true"><ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" Text='<%#Eval("Name") %>' OnCommand="rGridType_EditValue" />  </ItemTemplate>
                </asp:TemplateField>
                 <%--<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />                --%>
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <Rock:EditField OnClick="rGridType_Edit" />
                <Rock:EditValueField OnClick="rGridType_EditAttribute" />
                <Rock:DeleteField OnClick="rGridType_Delete" />
            </Columns>
        </Rock:Grid>          
    </asp:Panel>

    <asp:Panel ID="pnlTypeDetails" runat="server" Visible="false">
        
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Please Correct the Following" CssClass="alert-message block-message error"/>

        <div class="row">              
            <fieldset>
                <legend><asp:Literal ID="lType" runat="server">Types</asp:Literal></legend>
                <Rock:DataTextBox ID="tbTypeName" runat="server" SourceTypeName="Rock.Core.DefinedType, Rock" PropertyName="Name" />
                <Rock:DataTextBox ID="tbTypeCategory" runat="server" SourceTypeName="Rock.Core.DefinedType, Rock" PropertyName="Category" />
                <Rock:DataTextBox ID="tbTypeDescription" runat="server" SourceTypeName="Rock.Core.DefinedType, Rock" PropertyName="Description" TextMode="MultiLine" Rows="3" />
                <Rock:FieldTypeList ID="ddlTypeFieldType" runat="server" SourceTypeName="Rock.Core.DefinedType, Rock" PropertyName="FieldType" />

                <%-- <asp:TemplateField HeaderText="Name" showHeader="true" ItemStyle-Width="35%">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" Text='<%#Eval("Name") %>' OnCommand="typeValues_Edit" CommandArgument='<%#Eval("ID")%>'/>
                    </ItemTemplate>
                </asp:TemplateField> --%>

            </fieldset>
        </div>
        
        <div class="actions">
            <asp:LinkButton ID="btnSaveType" runat="server" Text="Save" CssClass="btn primary" onclick="btnSaveType_Click" />
            <asp:LinkButton id="btnCancelType" runat="server" Text="Cancel" CssClass="btn secondary" CausesValidation="false" OnClick="btnCancelType_Click" />
        </div>

    </asp:Panel>
    
    <asp:Panel ID="pnlAttributes" runat="server" Visible="false">
  
        <asp:ValidationSummary ID="ValidationSummary2" runat="server" CssClass="failureNotification"/>

        <%-- <div class="row"> --%>

        <Rock:Grid ID="rGridAttribute" runat="server" AllowSorting="true" ShowHeader="true" EmptyDataText="No Attributes Found">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" SortExpression="Id"/>
                <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"/>
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description"/>
                <Rock:BoolField DataField="GridColumn" HeaderText="Grid Column" SortExpression="GridColumn"/>
                <Rock:BoolField DataField="Required" HeaderText="Required" SortExpression="Required"/>
                <Rock:EditField OnClick="rGridAttribute_Edit" />
                <Rock:DeleteField OnClick="rGridAttribute_Delete" />

                <%--
                <asp:TemplateField>
                    <ItemStyle HorizontalAlign="Center" CssClass="grid-icon-cell edit"/>
                    <ItemTemplate>
                        <a href="#" onclick="editAttribute(<%# Eval("Id") %>);">Edit</a>
                    </ItemTemplate>
                </asp:TemplateField> --%>                
            </Columns>
        </Rock:Grid>

        <asp:LinkButton id="btnCloseAttribute" runat="server" Text="Done" CssClass="btn close" CausesValidation="false" OnClick="btnCloseAttribute_Click" />
    </asp:Panel>


    <asp:Panel ID="pnlValues" runat="server" Visible="false">
    
        <asp:ValidationSummary ID="ValidationSummary3" runat="server" CssClass="failureNotification"/>

        <h3>Defined Values</h3>
                
        <%-- <div class="row">  --%>

        <Rock:Grid ID="rGridValue" runat="server" ShowHeader="true" AllowSorting="true" EmptyDataText="No Default Values Found" >
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" SortExpression="Id"/>
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"/>
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <Rock:EditField Onclick="rGridValue_Edit" />
                <Rock:DeleteField OnClick="rGridValue_Delete" />

                <%--<asp:TemplateField>
                    <ItemStyle HorizontalAlign="Center" CssClass="grid-icon-cell edit"/>
                    <ItemTemplate>
                        <a href="#" onclick="editValue(<%# Eval("Id") %>);">Edit</a>
                    </ItemTemplate>
                </asp:TemplateField> --%>                
            </Columns>
        </Rock:Grid>
        
        <asp:LinkButton id="btnCloseValue" runat="server" Text="Done" CssClass="btn close" CausesValidation="false" OnClick="btnCloseValue_Click" />
    </asp:Panel>

    <asp:HiddenField ID="hfIdType" runat="server" />
    <asp:Button ID="btnRefresh" runat="server" Text="Save" style="display:none" onclick="btnRefresh_Click" />
    <Rock:NotificationBox ID="nbMessage" runat="server" Title="Error" NotificationBoxType="Error" Visible="false" />

    <Rock:ModalDialog ID="modalAttributes" runat="server" Title="Attribute Values">
    <Content>
        <asp:HiddenField ID="hfIdAttribute" runat="server" />
        <asp:ValidationSummary ID="valAttributeSummary" runat="server" HeaderText="Please Correct the Following" CssClass="alert-message block-message error"/>
        <fieldset>
            <Rock:DataTextBox ID="tbAttributeKey" runat="server" SourceTypeName="Rock.Core.Attribute, Rock" PropertyName="Key" />
            <Rock:DataTextBox ID="tbAttributeName" runat="server" SourceTypeName="Rock.Core.Attribute, Rock" PropertyName="Name" />
            <Rock:DataTextBox ID="tbAttributeCategory" runat="server" SourceTypeName="Rock.Core.Attribute, Rock" PropertyName="Category" />
            <Rock:DataTextBox ID="tbAttributeDescription" runat="server" SourceTypeName="Rock.Core.Attribute, Rock" PropertyName="Description" TextMode="MultiLine" Rows="3" />
            <Rock:FieldTypeList ID="ddlAttributeFieldType" runat="server" SourceTypeName="Rock.Core.Attribute, Rock" PropertyName="FieldTypeId" LabelText="Field Type" />
            <Rock:DataTextBox ID="tbAttributeDefaultValue" runat="server" SourceTypeName="Rock.Core.Attribute, Rock" PropertyName="DefaultValue" />
            <Rock:LabeledCheckBox ID="cbAttributeGridColumn" runat="server" LabelText="Grid Column" />
            <Rock:LabeledCheckBox ID="cbAttributeRequired" runat="server" LabelText="Required" />
        </fieldset>                
    </Content>
    </Rock:ModalDialog>
    
    <Rock:ModalDialog ID="modalValues" runat="server" Title="Type Values">
    <Content>
        <asp:HiddenField ID="hfIdValue" runat="server" />
        <asp:ValidationSummary ID="valSummaryValue" runat="server" HeaderText="Please Correct the Following" CssClass="alert-message block-message error"/>
        
        <fieldset>
            <Rock:DataTextBox ID="tbValueName" runat="server" SourceTypeName="Rock.Core.DefinedValue, Rock" PropertyName="Name" />
            <Rock:DataTextBox ID="tbValueDescription" runat="server" SourceTypeName="Rock.Core.DefinedValue, Rock" PropertyName="Description" TextMode="MultiLine" Rows="3" />
            <h4>Attribute Category</h4>
            <Rock:DataTextBox ID="tbValueGridColumn" runat="server" ReadOnly="true" SourceTypeName="Rock.Core.DefinedValue, Rock" PropertyName="Attributes" LabelText="Grid Attributes"/>
        </fieldset>
    </Content>
    </Rock:ModalDialog>

</ContentTemplate>
</asp:UpdatePanel>