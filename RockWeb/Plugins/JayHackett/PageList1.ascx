<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PageList1.ascx.cs" Inherits="Plugins_JayHackett_PageListEF" %>
<asp:TreeView ID="tvDataSet" runat="server" MaxDataBindDepth="2">
    <Nodes>
        <asp:TreeNode PopulateOnDemand="True" Text="Pages" Value="Pages"></asp:TreeNode>
        
    </Nodes>
</asp:TreeView>



