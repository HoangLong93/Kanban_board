using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

namespace Kanban
{
    /// <summary>
    /// Summary description for Handler1
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            String action = Convert.ToString(context.Request.Params["action"]);

            if (action.Equals("update"))
            {
                int Task_Status = Convert.ToInt32(context.Request.Params["status"]);
                int Task_ID = Convert.ToInt32(context.Request.Params["id"]);

                DatabaseConnection connectionClass = new DatabaseConnection();
                connectionClass.OpenConnection();
                connectionClass.executeNonQueryCommand("UPDATE Task SET Task_Status = " + Task_Status + " WHERE Task_ID = " + Task_ID);
                connectionClass.CloseConnection();
            }
            else
            {
                int Task_ID = Convert.ToInt32(context.Request.Params["id"]);

                DatabaseConnection connectionClass = new DatabaseConnection();
                connectionClass.OpenConnection();
                connectionClass.executeNonQueryCommand("DELETE FROM Task WHERE Task_ID = " + Task_ID);
                connectionClass.CloseConnection();
            }

            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");

        }

       
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}