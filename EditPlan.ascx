<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditPlan.ascx.cs" Inherits="Ventrian.Modules.Subscriptions.EditPlan" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>

<div class="dnnForm dnnPlans dnnClear">
    <div class="dnnFormItem">
        <dnn:Label ID="plName" runat="server" ControlName="txtName" />
        <asp:TextBox ID="txtName" runat="server" MaxLength="255" />
        <asp:RequiredFieldValidator ID="valName" runat="server" ControlToValidate="txtName" 
            resourcekey="valName.ErrorMessage" CssClass="dnnFormMessage dnnFormError" Display="Dynamic"  />
    </div>
    <div class="dnnFormItem">
        <dnn:Label ID="plRole" runat="server" ControlName="lstRoles" />
        <asp:DropDownList ID="lstRoles" runat="server" DataTextField="RoleName" DataValueField="RoleID" />
        <asp:RequiredFieldValidator ID="valRoles" runat="server" ControlToValidate="lstRoles" 
            resourcekey="lstRoles.ErrorMessage" CssClass="dnnFormMessage dnnFormError" Display="Dynamic" InitialValue="-1" />
    </div>
    <div class="dnnFormItem">
        <dnn:Label ID="plServiceFee" runat="server" ControlName="txtServiceFee" />
        <asp:TextBox ID="txtServiceFee" runat="server" MaxLength="10" />
        <asp:RequiredFieldValidator ID="valServiceFee" runat="server" ControlToValidate="txtServiceFee" 
            resourcekey="txtServiceFee.ErrorMessage" CssClass="dnnFormMessage dnnFormError" Display="Dynamic" />
    </div>
    <div class="dnnFormItem">
        <dnn:Label ID="plBillingFrequency" runat="server" ControlName="lstBillingFrequency" />
        <asp:RadioButtonList ID="lstBillingFrequency" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" 
            OnSelectedIndexChanged="lstBillingFrequency_OnSelectedIndexChanged" />
    </div>
    <div class="dnnFormItem" runat="server" visible="false" id="divBillingPeriod">
        <dnn:Label ID="plBillingPeriod" runat="server" ControlName="lstBillingPeriod" />
        <asp:DropDownList ID="lstBillingPeriod" runat="server" />
        <asp:RequiredFieldValidator ID="valBillingPeriod" runat="server" ControlToValidate="lstBillingPeriod" 
            resourcekey="lstBillingPeriod.ErrorMessage" CssClass="dnnFormMessage dnnFormError" Display="Dynamic" InitialValue="-1" />
    </div>
    <div class="dnnFormItem" runat="server" visible="false" id="divAutoRecurring">
        <dnn:Label ID="plAutoRecurring" runat="server" ControlName="chkAutoRecurring" />
        <asp:CheckBox ID="chkAutoRecurring" runat="server" />
    </div>
    <div class="dnnFormItem" runat="server">
        <dnn:Label ID="plIsActive" runat="server" ControlName="chkIsActive" />
        <asp:CheckBox ID="chkIsActive" runat="server" Checked="true" />
    </div>
</div>

<ul class="dnnActions dnnClear">
    <li><asp:LinkButton id="cmdSave" runat="server" CssClass="dnnPrimaryAction" resourcekey="Save" OnClick="OnSaveClick" /></li>
    <li><asp:HyperLink id="lnkCancel" runat="server" CssClass="dnnSecondaryAction" resourcekey="Cancel" /></li>
    <li><asp:LinkButton id="cmdDelete" runat="server" CssClass="dnnSecondaryAction" resourcekey="Delete" OnClick="OnDeleteClick" CausesValidation="false" Visible="false" /></li>
</ul>   