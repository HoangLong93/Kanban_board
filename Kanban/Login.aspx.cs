using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;

namespace Kanban
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DatabaseConnection connectionClass = new DatabaseConnection();
            connectionClass.OpenConnection();
            connectionClass.executeQueryCommand("SELECT Login_name, Password FROM Login WHERE Login_name = '" + txtUserName.Text + "'");
            TextBox hiddenTB = new TextBox();

            while (connectionClass.getReader().Read())
            {
                hiddenTB.Text = (connectionClass.getReader()["Password"].ToString());
            }
            if (hiddenTB.Text == txtpwd.Text)
            {
                Session["username"] = txtUserName.Text;
                Response.Redirect("MainActivity.aspx");
            }
            else
            {
                Label labelWrongPass = new Label();
                labelWrongPass.ForeColor = System.Drawing.Color.Red;
                labelWrongPass.Text = "You have entered wrong username or password.";
                Panel1.Controls.Add(labelWrongPass);
            }
            connectionClass.CloseConnection(); 
        }

    }
}