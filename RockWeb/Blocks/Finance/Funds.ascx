<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Funds.ascx.cs" Inherits="RockWeb.Blocks.Finance.FundList" %>
<asp:UpdatePanel ID="pnlFundListUpdatePanel" runat="server">
    <ContentTemplate>
        <asp:Panel ID="pnlFundList" runat="server">
            <h4>Financial Funds</h4>
            <Rock:GridFilter ID="rFundFilter" runat="server" OnApplyFilterClick="rFundFilter_ApplyFilterClick">
                <Rock:LabeledTextBox ID="txtFundName" runat="server" LabelText="Name" />
                <Rock:DateTimePicker ID="dtFundStartFromDate" runat="server" LabelText="From Start Date" />
                <Rock:DateTimePicker ID="dtFundStartToDate" runat="server" LabelText="To Start Date" />
                <Rock:DateTimePicker ID="dtFundEndFromDate" runat="server" LabelText="From End Date" />
                <Rock:DateTimePicker ID="dtFundEndToDate" runat="server" LabelText="To End Date" />
                <Rock:DataDropDownList ID="ddlIsFundActive" runat="server" LabelText="Fund Status">
                    <asp:ListItem Text="Any" Value="Any" />
                    <asp:ListItem Text="Active" Value="True" />
                    <asp:ListItem Text="Inactive" Value="False" />
                </Rock:DataDropDownList>
                <Rock:DataDropDownList ID="ddlIsFundTaxDeductible" runat="server" LabelText="Tax Deductible">
                    <asp:ListItem Text="Any" Value="Any" />
                    <asp:ListItem Text="Yes" Value="True" />
                    <asp:ListItem Text="No" Value="False" />
                </Rock:DataDropDownList>
                <Rock:DataDropDownList ID="ddlIsFundPledgable" runat="server" LabelText="Pledgable">
                    <asp:ListItem Text="Any" Value="Any" />
                    <asp:ListItem Text="Yes" Value="True" />
                    <asp:ListItem Text="No" Value="False" />
                </Rock:DataDropDownList>
            </Rock:GridFilter>

            <Rock:Grid ID="gFundList" runat="server" DisplayType="Full">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="PublicName" HeaderText="Public Name" SortExpression="PublicName" />
                    <asp:BoundField DataField="IsTaxDeductible" HeaderText="Tax Deductible" SortExpression="IsTaxDeductible" />
                    <asp:BoundField DataField="IsActive" HeaderText="Active" SortExpression="IsActive" />
                    <asp:BoundField DataField="StartDate" HeaderText="Starts On" SortExpression="StartDate" DataFormatString="{0:d}" />
                    <asp:BoundField DataField="EndDate" HeaderText="Ends On" SortExpression="EndDate" DataFormatString="{0:d}" />
                    <asp:BoundField DataField="IsPledgable" HeaderText="Pledgable" SortExpression="IsPledgable" />
                    <Rock:EditValueField OnClick="rGridFund_EditValue" />
                    <Rock:DeleteField OnClick="rGridFund_Delete" />
                </Columns>
            </Rock:Grid>
        </asp:Panel>

         <asp:Panel ID="pnlFundDetails" runat="server" Visible="false">

            <asp:HiddenField ID="hfFundId" runat="server" />
            <asp:ValidationSummary ID="valSummaryTop" runat="server" HeaderText="Please Correct the Following" CssClass="alert alert-error block-message error" />

            <div class="row-fluid">

                <div class="span6">
                    <fieldset>
                        <legend>
                            <asp:Literal ID="lAction" runat="server">Fund</asp:Literal></legend>

                        <Rock:DataTextBox ID="tbName" runat="server"
                            SourceTypeName="Rock.Model.Fund, Rock" PropertyName="Name" />
                        <Rock:DataTextBox ID="tbPublicName" runat="server"
                            SourceTypeName="Rock.Model.Fund, Rock" PropertyName="PublicName" />
                        <Rock:DataTextBox ID="tbDescription" runat="server"
                            SourceTypeName="Rock.Model.Fund, Rock" PropertyName="Description" TextMode="MultiLine" Rows="3" />
                        <Rock:DataTextBox ID="tbOrder" runat="server"
                            SourceTypeName="Rock.Model.Fund, Rock" PropertyName="Order" />
                        <Rock:DataTextBox ID="tbGLCode" runat="server"
                            SourceTypeName="Rock.Model.Fund, Rock" PropertyName="GlCode" />
                    </fieldset>
                </div>

                <div class="span6">
                    <fieldset>
                        <Rock:DateTimePicker ID="dtpStartDate" runat="server" SourceTypeName="Rock.Model.Fund, Rock" PropertyName="StartDate" LabelText="Start Date" />
                        <Rock:DateTimePicker ID="dtpEndDate" runat="server" SourceTypeName="Rock.Model.Fund, Rock" PropertyName="EndDate" LabelText="End Date" />
                    </fieldset>
                </div>

                <div class="span6">
                    <fieldset>
                        <Rock:LabeledCheckBox ID="cbIsActive" runat="server" LabelText="Active" />
                        <Rock:LabeledCheckBox ID="cbIsTaxDeductible" runat="server" LabelText="Tax Deductible" />
                        <Rock:LabeledCheckBox ID="cbIsPledgable" runat="server" LabelText="Pledgable" />
                    </fieldset>
                </div>

                <div class="span6">
                    <fieldset>
                        <legend>&nbsp;</legend>
                        <Rock:LabeledDropDownList ID="ddlFundType"  runat="server" LabelText="Fund Type" />
                        <Rock:LabeledDropDownList ID="ddlParentFund" runat="server" LabelText="Parent Fund"  />
                    </fieldset>
                </div>
            </div>

            <div class="actions">
                <asp:LinkButton ID="btnSaveFund" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSaveFund_Click" />
                <asp:LinkButton ID="btnCancelFund" runat="server" Text="Cancel" CssClass="btn" CausesValidation="false" OnClick="btnCancelFund_Click" />
            </div>

        </asp:Panel>

    </ContentTemplate>
</asp:UpdatePanel>
