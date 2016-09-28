using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kanban
{
    public partial class EditTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false) {
            int id = Convert.ToInt16(Request.Params["id"]);
            Page.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            DatabaseConnection connectionClass2 = new DatabaseConnection();
            connectionClass2.OpenConnection();
            connectionClass2.executeQueryCommand("SELECT Login_name,User_ID FROM Login");
            bool eof2;
            eof2 = connectionClass2.getReader().Read();
            while (eof2)
            {
                DropDownListAssignee.Items.Add((connectionClass2.getReader())["Login_name"].ToString());
                DropDownListAssignee.Items[DropDownListAssignee.Items.Count - 1].Value = (connectionClass2.getReader())["User_ID"].ToString();
                eof2 = (connectionClass2.getReader()).Read();
            }
            connectionClass2.CloseConnection(); 
            DatabaseConnection connectionClass = new DatabaseConnection();
            connectionClass.OpenConnection();
            connectionClass.executeQueryCommand("SELECT * FROM Task WHERE Task_ID =" + id);
            bool eof;
            eof = connectionClass.getReader().Read();
            txtTitle.Text = (connectionClass.getReader())["Task_Name"].ToString();
            TextBoxComplexity.Text = (connectionClass.getReader())["Complexity"].ToString();
            DropDownListAssignee.SelectedIndex = Convert.ToInt16((connectionClass.getReader())["User_ID"]) - 1;
            TextBoxDeadline.Text = (connectionClass.getReader())["Hour_estimation"].ToString();
            DropDownListColumn.SelectedIndex = Convert.ToInt16((connectionClass.getReader())["Task_Status"]) - 1;
            connectionClass.CloseConnection();
            }
        }

        protected void ButtonEditTask_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(Request.Params["id"]);
            DatabaseConnection connectionClass = new DatabaseConnection();
            connectionClass.OpenConnection();
            connectionClass.executeNonQueryCommand("UPDATE Task SET Project_ID = 1, Task_Name = '" + txtTitle.Text + "',Task_Status = '" + DropDownListColumn.SelectedValue + "',User_ID = '" + DropDownListAssignee.SelectedValue + "',Complexity = '" + TextBoxComplexity.Text + "' WHERE Task_ID = " + id);
            connectionClass.CloseConnection();
            Response.Redirect("MainActivity.aspx");
        }
    }
}