<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditCoupon.ascx.cs" Inherits="Ventrian.Modules.Subscriptions.EditCoupon" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.UI.WebControls" Assembly="DotNetNuke.Web.Deprecated" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>

<div class="dnnForm dnnPlans dnnClear">
    <div class="dnnFormItem">
        <dnn:Label ID="plCode" runat="server" ControlName="txtCode" />
        <asp:TextBox ID="txtCode" runat="server" MaxLength="10" />
        <asp:RequiredFieldValidator ID="valCode" runat="server" ControlToValidate="txtCode" 
            resourcekey="valCode.ErrorMessage" CssClass="dnnFormMessage dnnFormError" Display="Dynamic"  />
    </div>
    <div class="dnnFormItem">
        <dnn:Label ID="plDiscountType" runat="server" ControlName="lstDiscountType" />
        <asp:RadioButtonList ID="lstDiscountType" runat="server" RepeatDirection="Horizontal" />
    </div>
    <div class="dnnFormItem">
        <dnn:Label ID="plAmount" runat="server" ControlName="txtAmount" />
        <asp:TextBox ID="txtAmount" runat="server" MaxLength="10" />
        <asp:RequiredFieldValidator ID="valAmount" runat="server" ControlToValidate="txtAmount" 
            resourcekey="txtAmount.ErrorMessage" CssClass="dnnFormMessage dnnFormError" Display="Dynamic" />
    </div>
    <div class="dnnFormItem">
        <dnn:Label ID="plQuantity" runat="server" ControlName="txtQuantity" />
        <asp:TextBox ID="txtQuantity" runat="server" MaxLength="10" />
    </div>
    <div class="dnnFormItem">
        <dnn:Label ID="plStartDate" runat="server" ControlName="txtStartDate" />
        <dnn:DnnDatePicker runat="server" CssClass="dnnFormInput" ID="txtStartDate" />
    </div>
    <div class="dnnFormItem">
        <dnn:Label ID="plEndDate" runat="server" ControlName="txtEndDate" />
        <dnn:DnnDatePicker runat="server" CssClass="dnnFormInput" ID="txtEndDate" />
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