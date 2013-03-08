<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FundList.ascx.cs" Inherits="RockWeb.Blocks.Finance.FundList" %>
<asp:UpdatePanel id="pnlFundList" runat="server">
    <ContentTemplate>
            <h4>Financial Funds</h4>
            <Rock:Grid ID="gFundList" runat="server" DisplayType="Full">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="PublicName" HeaderText="Public Name" SortExpression="PublicName" />
                    <asp:BoundField DataField="IsTaxDeductible" HeaderText="Tax Deductible" SortExpression="IsTaxDeductible" />
                    <asp:BoundField DataField="IsActive" HeaderText="Active" SortExpression="IsActive" />
                    <asp:BoundField DataField="StartDate" HeaderText="Starts On" SortExpression="StartDate" />
                    <asp:BoundField DataField="EndDate" HeaderText="Ends On" SortExpression="EndDate" />
                    <asp:BoundField DataField="IsPledgable" HeaderText="Pledgable" SortExpression="IsPledgable" />
                </Columns>
            </Rock:Grid>
    </ContentTemplate>
</asp:UpdatePanel>