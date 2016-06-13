<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditCoupons.ascx.cs" Inherits="Ventrian.Modules.Subscriptions.EditCoupons" %>
<div class="dnnForm dnnClear">
    <asp:DataGrid ID="grdCoupons" Width="98%" AutoGenerateColumns="false" EnableViewState="false" runat="server"
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
                    <a href="<%# GetEditUrl(Convert.ToInt32(DataBinder.Eval(Container.DataItem, "CouponID").ToString())) %>"><img src="<%= ResolveUrl("~/images/edit.gif") %>" alt="Edit" /></a>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:BoundColumn DataField="Code" HeaderText="Code" />
            <asp:BoundColumn DataField="DiscountType" HeaderText="Discount Type" />
            <asp:BoundColumn DataField="Amount" HeaderText="Amount" />
            <asp:BoundColumn DataField="IsActive" HeaderText="IsActive" />
        </Columns>
    </asp:DataGrid>    
</div>

<asp:PlaceHolder ID="phNoCoupons" runat="server" Visible="false">
    <div class="dnnFormMessage dnnFormWarning"><%= LocalizeString("NoCoupons") %></div>
</asp:PlaceHolder>

<ul class="dnnActions dnnClear">
    <li><asp:HyperLink id="lnkAddEntry" runat="server" CssClass="dnnPrimaryAction" resourcekey="AddCoupon" /></li>
</ul>   
