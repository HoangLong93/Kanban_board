using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kanban
{
    /// <summary>
    /// Summary description for Handler2
    /// </summary>
    public class Handler2 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            int Task_ID = Convert.ToInt32(context.Request.Params["id"]);

            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");

            DatabaseConnection connectionClass = new DatabaseConnection();
            connectionClass.OpenConnection();
            connectionClass.executeNonQueryCommand("DELETE FROM Task WHERE Task_ID = "+Task_ID);
            connectionClass.CloseConnection();
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