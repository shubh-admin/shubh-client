using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;


namespace msdnh.util
{
    public class Menus
    {

        /// <summary>
        /// Create dynamic linked menus
        /// </summary>
        /// <param name="ContainingControl">Control on which menus create</param>
        /// <param name="arLinkTitles">Menus titles</param>
        /// <param name="arLinks">Menus links</param>
        public static void SetDynamicLinks(Control ContainingControl, string[] arLinkTitles, string[] arLinks, bool blnShowToolTip)
        {
            int length = 0;

            if (arLinks.Length != arLinkTitles.Length)
            {
                throw new Exception("Number of links not equal to number of title.");
            }
            else
            {
                length = arLinkTitles.Length;
            }
            string strControlType = CleanUtils.ToString(ContainingControl.GetType());
            LinkButton msdnhLinkButton = new LinkButton();


            switch (strControlType)
            {
                case "System.Web.UI.HtmlControls.HtmlGenericControl": //HtmlGeneric Control Like Div

                    SetDynamicLinks(ContainingControl, arLinkTitles, arLinks, blnShowToolTip, Enumerations.MenusDirection.Horizontal);

                    break;
                default:
                    break;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ContainingControl"></param>
        /// <param name="arLinkTitles"></param>
        /// <param name="arLinks"></param>
        /// <param name="blnShowToolTip"></param>
        /// <param name="strDirection"></param>
        public static void SetDynamicLinks(Control ContainingControl, string[] arLinkTitles, string[] arLinks, bool blnShowToolTip, Enumerations.MenusDirection menuDirection)
        {


            if (arLinks.Length != arLinkTitles.Length)
            {
                throw new Exception("Number of links not equal to number of title.");
            }

            string strControlType = CleanUtils.ToString(ContainingControl.GetType());



            switch (strControlType)
            {
                case "System.Web.UI.HtmlControls.HtmlGenericControl": //HtmlGeneric Control Like Div
                    if (menuDirection == Enumerations.MenusDirection.Horizontal)
                    {
                        ((HtmlGenericControl)ContainingControl).Controls.Add(createHorizontalMenu(arLinkTitles, arLinks, blnShowToolTip));
                    }
                    else
                    {
                        ((HtmlGenericControl)ContainingControl).Controls.Add(CreateVerticalMenu(arLinkTitles, arLinks, blnShowToolTip));
                    }


                    break;
                default:
                    break;
            }

        }

        private static HtmlGenericControl createHorizontalMenu(string[] arLinkTitles, string[] arLinks, bool blnShowToolTip)
        {
            int length = arLinkTitles.Length;
            HtmlGenericControl htmlDiv = new HtmlGenericControl();
            for (int i = 0; i < length; i++)
            {
                LinkButton msdnhLinkButton = new LinkButton();
                msdnhLinkButton.ID = "msdnhButton" + CleanUtils.ToString(i + 1);
                msdnhLinkButton.Text = arLinkTitles[i];
                msdnhLinkButton.PostBackUrl = arLinks[i];
                if (blnShowToolTip)
                    msdnhLinkButton.ToolTip = arLinkTitles[i];
                htmlDiv.Controls.Add(msdnhLinkButton);
            }

            return htmlDiv;
        }

        private static Table CreateVerticalMenu(string[] arLinkTitles, string[] arLinks, bool blnShowToolTip)
        {
            int length = arLinkTitles.Length;
            Table htmlTable = new Table();
            TableRow rowNew;
            htmlTable.ID = "msdnhTable";

            for (int i = 0; i < length; i++)
            {
                rowNew = new TableRow();
                htmlTable.Controls.Add(rowNew);
                TableCell cellNew = new TableCell();
                LinkButton msdnhLinkButton = new LinkButton();

                msdnhLinkButton.ID = "msdnhButton" + CleanUtils.ToString(i + 1);
                msdnhLinkButton.Text = arLinkTitles[i];
                msdnhLinkButton.PostBackUrl = arLinks[i];
                if (blnShowToolTip)
                    msdnhLinkButton.ToolTip = arLinkTitles[i];
                cellNew.Controls.Add(msdnhLinkButton);

                rowNew.Controls.Add(cellNew);
                htmlTable.Controls.Add(rowNew);
            }

            return htmlTable;
        }
    }


}
