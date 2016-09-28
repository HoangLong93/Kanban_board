using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

namespace Kanban
{
    public partial class MainActivity2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //   string username = Session["username"].ToString();
            //   Label header = new Label();
            //   header.Text = "Congratulation. You have successfully logged in as " + username + ".";
            //   form1.Controls.Add(header);
            DatabaseConnection connectionClass = new DatabaseConnection();
            connectionClass.OpenConnection();
            connectionClass.executeQueryCommand("SELECT * FROM Task WHERE Project_ID = 1");

            Panel1.Controls.Add(new LiteralControl("<div class='sortable' id='sortable1' data-ID='1'>"));
            Panel2.Controls.Add(new LiteralControl("<div class='sortable' id='sortable2' data-ID='2'>"));
            Panel3.Controls.Add(new LiteralControl("<div class='sortable' id='sortable3' data-ID='3'>"));
            Panel4.Controls.Add(new LiteralControl("<div class='sortable' id='sortable4' data-ID='4'>"));
            Panel5.Controls.Add(new LiteralControl("<div class='sortable' id='sortable5' data-ID='5'>"));

            while (connectionClass.getReader().Read())
            {
                String task_status = (connectionClass.getReader())["Task_Status"].ToString();
                String strTaskName = "";
                String strComplexity = " Complexity: ";
                String strTaskID = (connectionClass.getReader())["Task_ID"].ToString();
                String userID = "";
                String assignee = "";

                String htmlString = "<div class='div-note' data-ID='" + strTaskID + "' data-status='" + task_status + "'>";   //start of html String
                htmlString += "<div class='taskbar'><span class='span_TaskID'>#" + strTaskID + "</span>";     //html String

                strComplexity = (connectionClass.getReader())["Complexity"].ToString();
                htmlString += "<span class='span_Complexity'>Complexity: " + strComplexity + "</span></div>";     //html String

                strTaskName = (connectionClass.getReader())["Task_Name"].ToString();
                htmlString += "<div class='span_TaskName'>" + strTaskName + "</div>";  //html String

                userID = (connectionClass.getReader())["User_ID"].ToString();

                //commmand2
                DatabaseConnection connectionClass2 = new DatabaseConnection();
                connectionClass2.OpenConnection();
                connectionClass2.executeQueryCommand("SELECT Login_name FROM Login WHERE User_ID =" + userID);
                while ((connectionClass2.getReader()).Read())
                {
                    assignee = (connectionClass2.getReader())["Login_name"].ToString();
                }
                htmlString += "<div class='span_Assignee'>Assigned to " + assignee + "</div>";  //html String

                htmlString += "<div class='edittask'><a href='EditTask.aspx?id=" + strTaskID + "'><i class='fa fa-pencil-square-o'></i></a></div>";                          //end of html String

                htmlString += "<div class='deletetask' data-ID='" + strTaskID + "'><i class='fa fa-trash'></i></a></div></div>";                   

                switch (task_status)
                {
                    case "1":
                        Panel1.Controls.Add(new LiteralControl(htmlString));
                        break;

                    case "2":
                        Panel2.Controls.Add(new LiteralControl(htmlString));
                        break;
                    case "3":
                        Panel3.Controls.Add(new LiteralControl(htmlString));
                        break;
                    case "4":
                        Panel4.Controls.Add(new LiteralControl(htmlString));
                        break;
                    case "5":
                        Panel5.Controls.Add(new LiteralControl(htmlString));
                        break;
                }
                connectionClass2.CloseConnection();
            }
            Panel1.Controls.Add(new LiteralControl("</div>"));
            Panel2.Controls.Add(new LiteralControl("</div>"));
            Panel3.Controls.Add(new LiteralControl("</div>"));
            Panel4.Controls.Add(new LiteralControl("</div>"));
            Panel5.Controls.Add(new LiteralControl("</div>"));
            connectionClass.CloseConnection();
        }
    }
}