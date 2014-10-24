using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Telerik.Sitefinity.Modules.Newsletters;
using Telerik.Sitefinity.Modules.Newsletters.Web.UI.Public;
using Telerik.Sitefinity.Web.UI;

namespace SitefinityWebApp
{
    public class CustomSubscribeForm : SubscribeForm
    {
       public static NewslettersManager newsLetMan = NewslettersManager.GetManager();
        
		   protected  DropDownList ddlMailLists
		   {
			   get
			   {

				   var theLists = newsLetMan.GetMailingLists();
				   DropDownList ddlMailLists1 = new DropDownList();
				   foreach (var list in theLists)
				   {
					   ddlMailLists1.Items.Add(list.Title);
				   }
				   ddlMailLists1.ID = "DropId";
				   return ddlMailLists1;
			   }

		   }
		 
			protected override void InitializeControls(GenericContainer container)
			{
						  Page.EnableViewState = true;

						  base.Controls.Add(ddlMailLists);

						  base.InitializeControls(container);
			   
			}

			protected override void AddSubscriber()
			{
				var theDropdown = this.FindControl("DropId") as DropDownList;
				var newId = newsLetMan.GetMailingLists().Where(l => l.Title == theDropdown.SelectedValue.ToString()).First().Id;
					base.ListId = newId;
					base.AddSubscriber();
			}
       
    }
}
