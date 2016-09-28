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
    public partial class AddNewTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            int swimlane = Convert.ToInt16(Request.Params["swimlane"]);

            DatabaseConnection connectionClass = new DatabaseConnection();
            connectionClass.OpenConnection();
            connectionClass.executeQueryCommand("SELECT Login_name,User_ID FROM Login");
            bool eof;
            eof = connectionClass.getReader().Read();
            while (eof)
            {
                DropDownListAssignee.Items.Add((connectionClass.getReader())["Login_name"].ToString());
                DropDownListAssignee.Items[DropDownListAssignee.Items.Count - 1].Value = (connectionClass.getReader())["User_ID"].ToString();
                eof = (connectionClass.getReader()).Read();
            }
            
            connectionClass.CloseConnection(); 
        }

        protected void ButtonAddTask_Click(object sender, EventArgs e)
        {
            DatabaseConnection connectionClass = new DatabaseConnection();
            connectionClass.OpenConnection();
            connectionClass.executeNonQueryCommand("INSERT INTO Task (Project_ID,Task_Name,Task_Status,User_ID,Complexity)" + " VALUES (1,'" + txtTitle.Text + "','" + DropDownListColumn.SelectedValue + "','" + DropDownListAssignee.SelectedValue + "','" + TextBoxComplexity.Text + "');");
            connectionClass.CloseConnection();
            Response.Redirect("MainActivity.aspx");
        }
    }
}