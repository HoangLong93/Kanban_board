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
    public partial class Signup : System.Web.UI.Page
    {
       protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }
        
       protected void ValidateUN_ServerValidate(object source, ServerValidateEventArgs args)
       {
           DatabaseConnection connectionClass = new DatabaseConnection();
           connectionClass.OpenConnection();
           int count = Convert.ToInt16(connectionClass.executeScalar("SELECT count(*) FROM Login WHERE Login_name = '" + txtUN.Text + "'"));
           if (count == 0)
           {
               args.IsValid = true;
           }

           else
               args.IsValid = false;
           connectionClass.CloseConnection(); 
       }

       protected void ValidatePW_ServerValidate(object source, ServerValidateEventArgs args)
       {
           lbl_p.Text = "";
           bool length = args.Value.Length > 7;
           bool maxlength = args.Value.Length < 13;
           if (length && maxlength)
           {
               args.IsValid = true;
           }
           else
               args.IsValid = false;
       }

       protected void btnSubmit_Click1(object sender, EventArgs e)
       {
           DatabaseConnection connectionClass = new DatabaseConnection();
           connectionClass.OpenConnection();
           connectionClass.executeNonQueryCommand("INSERT INTO Login (Login_name,[Password])" + " VALUES ('" + txtUN.Text + "','" + txtpwd.Text + "');");
           connectionClass.CloseConnection(); 
           if (this.IsValid)
               Response.Redirect("Login.aspx");
       }
    }
}