using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kanban
{
    public partial class Comment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            int id = 1;
            submitComment(id, commentToAddTextbox.Text.ToString());
        }

        protected void submitComment(int taskID, String message)
        {
            DatabaseConnection DBConnetion = new DatabaseConnection();
            DBConnetion.OpenConnection();
            if (DBConnetion.executeNonQueryCommand("INSERT INTO Comment (Task_ID, Comment)" + "VALUES ('" + taskID + "', '" + message + "')") == false)
            {
                commentToAddTextbox.Text = "Oops, something went wrong!";
            }
            DBConnetion.CloseConnection();
        }
    }
}