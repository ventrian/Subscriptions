<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditPlans.ascx.cs" Inherits="Ventrian.Modules.Subscriptions.EditPlans" %>

<div class="dnnForm dnnClear">
    <asp:DataGrid ID="grdPlans" Width="98%" AutoGenerateColumns="false" EnableViewState="false" runat="server"
        BorderStyle="None" GridLines="None" CssClass="dnnGrid table">
        <HeaderStyle CssClass="dnnGridHeader" VerticalAlign="Top" />
        <ItemStyle CssClass="dnnGridItem" HorizontalAlign="Left" />
        <AlternatingItemStyle CssClass="dnnGridAltItem" />
        <EditItemStyle CssClass="dnnFormInput" />
        <SelectedItemStyle CssClass="dnnFormError" />
        <FooterStyle CssClass="dnnGridFooter" />
        <PagerStyle CssClass="dnnGridPager" />
        <Columns>
            <asp:TemplateColumn>
                <ItemTemplate>
                    <a href="<%# GetEditUrl(Convert.ToInt32(DataBinder.Eval(Container.DataItem, "PlanID").ToString())) %>"><img src="<%= ResolveUrl("~/images/edit.gif") %>" alt="Edit" /></a>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:BoundColumn DataField="Name" HeaderText="Name" />
            <asp:BoundColumn DataField="ServiceFee" HeaderText="ServiceFee" DataFormatString="{0:C}" />
            <asp:BoundColumn DataField="AutoRecurring" HeaderText="AutoRecurring" />
            <asp:BoundColumn DataField="BillingFrequency" HeaderText="BillingFrequency" />
            <asp:BoundColumn DataField="BillingPeriod" HeaderText="BillingPeriod" />
        </Columns>
    </asp:DataGrid>    
</div>

<asp:PlaceHolder ID="phNoPlans" runat="server" Visible="false">
    <div class="dnnFormMessage dnnFormWarning"><%= LocalizeString("NoPlans") %></div>
</asp:PlaceHolder>

<ul class="dnnActions dnnClear">
    <li><asp:HyperLink id="lnkAddEntry" runat="server" CssClass="dnnPrimaryAction" resourcekey="AddPlan" /></li>
</ul>   
