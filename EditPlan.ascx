<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditPlan.ascx.cs" Inherits="Ventrian.Modules.Subscriptions.EditPlan" %>
<div class="dnnForm dnnListEntries dnnClear">
    <div class="dnnFormItem">
            <dnn:Label ID="plParentKey" runat="server" ControlName="txtParentKey" />
            <asp:TextBox ID="txtParentKey" runat="server" MaxLength="100" ReadOnly="true" />
    </div>
</div>