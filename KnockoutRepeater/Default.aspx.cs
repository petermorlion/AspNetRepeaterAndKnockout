using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace KnockoutRepeater
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            customersRepeater.ItemDataBound += OnCustomersRepeaterItemDataBound;

            var models = new[]
                                         {
                                             new CustomerModel {firstName = "John", lastName = "Doe", exclusiveMember = true},
                                             new CustomerModel {firstName = "Jane", lastName = "Doe", exclusiveMember = false}
                                         };

            modelHiddenField.Value = GetJson(models);
            customersRepeater.DataSource = models;
            customersRepeater.DataBind();
        }

        /// <summary>
        /// Returns a JSON representation of our viewmodels. You'd want to use a library instead of doing this manually.
        /// </summary>
        /// <param name="customerModels"></param>
        /// <returns></returns>
        private string GetJson(IEnumerable<CustomerModel> customerModels)
        {
            var jsonBuilder = new StringBuilder();
            jsonBuilder.Append("[");
            IList<string> customerModelJsonStrings = new List<string>();
            foreach (var customerModel in customerModels)
            {
                // This will render something like: { 'firstName': 'John', 'lastName': 'Doe', 'exclusiveMember': true }
                customerModelJsonStrings.Add("{ 'firstName': '" + customerModel.firstName + "', 'lastName': '" + customerModel.lastName + "', 'exclusiveMember': " + (customerModel.exclusiveMember ? "true }" : "false }")) ;
            }

            jsonBuilder.Append(string.Join(", ", customerModelJsonStrings.ToArray()));
            jsonBuilder.Append("]");
            return jsonBuilder.ToString();
        }

        private void OnCustomersRepeaterItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
            {
                return;
            }

            CustomerModel model = (CustomerModel) e.Item.DataItem;
            ((Literal)e.Item.FindControl("firstNameLiteral")).Text = model.firstName;
            ((Literal)e.Item.FindControl("lastNameLiteral")).Text = model.lastName;
            ((CheckBox)e.Item.FindControl("exclusiveMemberCheckBox")).Checked = model.exclusiveMember;
        }

        private class CustomerModel
        {
            public string firstName { get; set; }
            public string lastName { get; set; }
            public bool exclusiveMember { get; set; }
        }
    }
}