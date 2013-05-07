using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Rock;
using Rock.Web.UI;
using Rock.Data;
using Rock.Model;
using Rock.Web.UI.Controls;
using Rock.Attribute;
using Rock.Constants;
namespace RockWeb.Blocks.Finance
{
    [ContextAware( typeof( Fund ) )]
    [DetailPage]
    public partial class FundList : RockBlock
    {

        protected void Page_Load( object sender, EventArgs e )
        {
            rFundFilter.ApplyFilterClick += rFundFilter_ApplyFilterClick;
            gFundList.Actions.AddClick += rGridFund_Add;

            gFundList.DataKeyNames = new string[] { "id" };
            bool canAddEditDelete = IsUserAuthorized( "Edit" );
            gFundList.Actions.IsAddEnabled = canAddEditDelete;
            gFundList.IsDeleteEnabled = canAddEditDelete;
            if ( !canAddEditDelete )
            {
                btnSaveFund.Enabled = false;
            }
            BindFundListGrid();
        }

        /// <summary>
        /// Binds the fund list grid.
        /// </summary>
        protected void BindFundListGrid()
        {
            Fund contextFund = ContextEntity<Fund>();
            if ( contextFund == null )
            {
                FundService fundService = new FundService();
                SortProperty sortProperty = gFundList.SortProperty;
                var fundQuery = fundService.Queryable();

                if ( !string.IsNullOrEmpty( txtFundName.Text ) )
                {
                    fundQuery = fundQuery.Where( fund => fund.Name.Contains( txtFundName.Text ) );
                }

                if ( dtFundStartFromDate.SelectedDate != null )
                {
                    fundQuery = fundQuery.Where( fund => fund.StartDate >= dtFundStartFromDate.SelectedDate );
                }

                if ( dtFundStartToDate.SelectedDate != null )
                {
                    fundQuery = fundQuery.Where( fund => fund.EndDate <= dtFundStartToDate.SelectedDate );
                }

                if ( dtFundEndFromDate.SelectedDate != null )
                {
                    fundQuery = fundQuery.Where( fund => fund.EndDate >= dtFundEndFromDate.SelectedDate );
                }

                if ( dtFundEndToDate.SelectedDate != null )
                {
                    fundQuery = fundQuery.Where( fund => fund.EndDate <= dtFundEndToDate.SelectedDate );
                }

                if ( ddlIsFundActive.SelectedValue != "Any" )
                {
                    fundQuery = fundQuery.Where( fund => fund.IsActive == ( ddlIsFundActive.SelectedValue == "Active" ) );
                }

                if ( ddlIsFundTaxDeductible.SelectedValue != "Any" )
                {
                    fundQuery = fundQuery.Where( fund => fund.IsTaxDeductible == ( ddlIsFundTaxDeductible.SelectedValue == "Yes" ) );
                }

                if ( ddlIsFundPledgable.SelectedValue != "Any" )
                {
                    fundQuery = fundQuery.Where( fund => fund.IsPledgable == ( ddlIsFundPledgable.SelectedValue == "Yes" ) );
                }

                Fund parentFund = ContextEntity<Fund>();
                //if ( parentFund != null )
                //{
                //    fundQuery = fundQuery.Where( f => f.ParentFundId = parentFund.Id );
                //}

                if ( sortProperty != null )
                {
                    gFundList.DataSource = fundQuery.Sort( sortProperty ).ToList();
                }
                else
                {
                    gFundList.DataSource = fundQuery.OrderBy( f => f.Name ).ToList();
                }
            }
            else
            {
                gFundList.DataSource = contextFund;
                gFundList.Actions.IsAddEnabled = false;
            }
            gFundList.DataBind();
        }

        protected void rFundFilter_ApplyFilterClick( object Sender, EventArgs e )
        {
            rFundFilter.SaveUserPreference( "FundName", txtFundName.Text );
            rFundFilter.SaveUserPreference( "StartFromDate", dtFundStartFromDate.SelectedDate.ToString() );
            rFundFilter.SaveUserPreference( "StartToDate", dtFundStartToDate.SelectedDate.ToString() );
            rFundFilter.SaveUserPreference( "EndFromDate", dtFundEndFromDate.SelectedDate.ToString() );
            rFundFilter.SaveUserPreference( "EndToDate", dtFundEndToDate.SelectedDate.ToString() );
            rFundFilter.SaveUserPreference( "IsFundActive", ddlIsFundActive.SelectedValue );
            rFundFilter.SaveUserPreference( "IsFundPledgable", ddlIsFundPledgable.SelectedValue );
            rFundFilter.SaveUserPreference( "IsFundTaxDeductible", ddlIsFundTaxDeductible.SelectedValue );
            BindFundListGrid();
        }

        /// <summary>
        /// Shows the edit.
        /// </summary>
        /// <param name="fundId">The fund id.</param>
        protected void ShowEdit( int fundId )
        {

            var fundModel = new FundService().Get( fundId );

            hfFundId.Value = fundId.ToString();
            string actionTitle;

            if ( fundModel == null )
            {
                fundModel = new Rock.Model.Fund();
                actionTitle = ActionTitle.Add( Rock.Model.Attribute.FriendlyTypeName );
                tbName.Text = string.Empty;
                tbPublicName.Text = string.Empty;
                tbDescription.Text = string.Empty;
                tbOrder.Text = string.Empty;
                tbGLCode.Text = string.Empty;
                cbIsActive.Checked = false;
                cbIsPledgable.Checked = false;
                cbIsTaxDeductible.Checked = false;
            }
            else
            {
                actionTitle = ActionTitle.Edit( Rock.Model.Attribute.FriendlyTypeName );
                tbName.Text = fundModel.Name;
                tbPublicName.Text = fundModel.PublicName;
                tbDescription.Text = fundModel.Description;
                tbOrder.Text = fundModel.Order.ToString();
                tbGLCode.Text = fundModel.GlCode.ToString();
                cbIsActive.Checked = fundModel.IsActive;
                cbIsPledgable.Checked = fundModel.IsPledgable;
                cbIsTaxDeductible.Checked = fundModel.IsTaxDeductible;
                dtpStartDate.SelectedDate = fundModel.StartDate;
                dtpEndDate.SelectedDate = fundModel.EndDate;
            }


            //edtFund.EditAttribute( fundModel, actionTitle );

            //pnlList.Visible = false;
            //pnlDetails.Visible = true;

            pnlFundList.Visible = false;
            pnlFundDetails.Visible = true;
        }

        protected void rGridFund_Add( object sender, EventArgs e )
        {
            BindFundType();
            BindParentFund();
            ShowEdit( 0 );

        }

        protected void rGridFund_Edit( object sender, RowEventArgs e )
        {
        }

        protected void rGridFund_EditValue( object sender, RowEventArgs e )
        {
        }

        protected void rGridFund_Delete( object sender, RowEventArgs e )
        {

        }

        protected void btnSaveFund_Click( object sender, EventArgs e )
        {
            using ( new Rock.Data.UnitOfWorkScope() )
            {
                var fundService = new Rock.Model.FundService();
                Rock.Model.Fund modifiedFund;
                int fundId = ( hfFundId.Value ) != null ? Int32.Parse( hfFundId.Value ) : 0;

                if ( fundId == 0 )
                {
                    modifiedFund = new Rock.Model.Fund();

                    fundService.Add( modifiedFund, CurrentPersonId );
                }
                else
                {
                    modifiedFund = fundService.Get( fundId );
                }

                modifiedFund.Name =tbName.Text;
                modifiedFund.PublicName = tbPublicName.Text;
                modifiedFund.Description =tbDescription.Text;
                modifiedFund.Order = Int32.Parse(tbOrder.Text);
                modifiedFund.GlCode = tbGLCode.Text;
                modifiedFund.IsActive = cbIsActive.Checked;
                modifiedFund.IsPledgable = cbIsPledgable.Checked;
                modifiedFund.IsTaxDeductible = cbIsTaxDeductible.Checked;
                modifiedFund.StartDate = dtpStartDate.SelectedDate;
                modifiedFund.EndDate = dtpEndDate.SelectedDate;
                modifiedFund.ParentFundId = ddlParentFund.SelectedValueAsInt( true );
                modifiedFund.FundTypeValueId = ddlParentFund.SelectedValueAsInt( true );
                
                fundService.Save( modifiedFund, CurrentPersonId );
            }

            //BindCategoryFilter();
            BindFundListGrid();

            pnlFundDetails.Visible = false;
            pnlFundList.Visible = true;
        }

        protected void btnCancelFund_Click( object sender, EventArgs e )
        {
            pnlFundDetails.Visible = false;
            pnlFundList.Visible = true;
        }

        private void BindParentFund()
        {
            ddlParentFund.Items.Clear();

            var fundService = new FundService();
            List<Fund> funds = new List<Fund>();
            using ( new Rock.Data.UnitOfWorkScope() )
            {
                funds = fundService.Queryable().
                    Where( fund => fund.IsActive ).
                    OrderBy( fund => fund.Order ).
                    ToList();
            }

            foreach ( Fund f in funds )
                ddlParentFund.Items.Add( new ListItem( f.Name, f.Id.ToString() ) );
        }

        private void BindFundType()
        {
            ddlFundType.Items.Clear();

            List<DefinedValue> definedValues = new List<DefinedValue>();
            DefinedValueService dfs = new DefinedValueService();
            using ( new Rock.Data.UnitOfWorkScope() )
            {
                definedValues = dfs.Queryable().
                    Where( definedValue => definedValue.DefinedType.Guid == Rock.SystemGuid.DefinedType.FINANCIAL_FUND_TYPE ).
                    OrderBy( v => v.Order ).
                    ToList();
            }

            foreach ( DefinedValue dv in definedValues )
            {
                ddlFundType.Items.Add( new ListItem( dv.Name, dv.Id.ToString() ) );
            }
        }
    }
}