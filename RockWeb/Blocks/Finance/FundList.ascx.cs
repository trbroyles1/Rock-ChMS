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
namespace RockWeb.Blocks.Finance
{
    [ContextAware(typeof(Fund) )]
    [DetailPage]
    public partial class FundList : RockBlock
    {
        protected void Page_Load( object sender, EventArgs e )
        {
            BindFundListGrid();
        }

        /// <summary>
        /// Binds the fund list grid.
        /// </summary>
        protected void BindFundListGrid()
        {
            FundService fundService = new FundService();
            SortProperty sortProperty = gFundList.SortProperty;
            var fundQuery = fundService.Queryable();

            //if ( GetAttributeValue( "LimittoSecurityRoleGroups" ).FromTrueFalse() )
            //{
            //    fundQuery = fundQuery.Where( a => a.IsSecurityRole );
            //}

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

            gFundList.DataBind();
        }
    }
}