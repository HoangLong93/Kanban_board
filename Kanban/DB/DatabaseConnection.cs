using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;

namespace Kanban
{
    public class DatabaseConnection
    {
        private String projectPath = @"|DataDirectory|\ProjectDatabase.mdb";                                         // Relative path for the database to avoid DB not found
        private String connectionString;
        private OleDbConnection DBConnection = new OleDbConnection();
        private OleDbCommand DBCommand = new OleDbCommand();
        private OleDbDataReader DBReader;
        private String SQLResults;

        public void OpenConnection()
        {
            if (!DBConnection.State.Equals(ConnectionState.Open))
            {
                connectionString = "Provider = Microsoft.Jet.OLEDB.4.0;" + "Data Source = " + projectPath;
                DBConnection.ConnectionString = connectionString;

                DBConnection.Open();
            }
        }

        public void CloseConnection()
        {

            if (!DBConnection.State.Equals(ConnectionState.Closed))
                DBConnection.Close();
        }

        public Boolean executeQueryCommand(String SQLCommand)                                                       // Executes the query command that has retrunable data submited by the method. Use it when you want to submit the command such as INSERT which also will return value TRUE if command submitted sucessfully. 
        {
            DBCommand.Connection = DBConnection;
            DBCommand.CommandText = SQLCommand;
            DBCommand.CommandType = CommandType.Text;

            try
            {
                DBReader = DBCommand.ExecuteReader();
                return true;
            }

            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine(error.ToString());                                               // Prints the error debug info in the console. Only works during DEBUG option. Use DEBUG -> Start Debugging if you want to see the error message.
                return false;
            }
        }

        public Boolean executeNonQueryCommand(String SQLCommand)                                                    // Executes the non-query command that has non-returnable data (such as INSERT) submited by the method. Use it when you want to submit the command such as INSERT which also will return value TRUE if command submitted sucessfully. 
        {
            DBCommand.Connection = DBConnection;
            DBCommand.CommandText = SQLCommand;
            DBCommand.CommandType = CommandType.Text;

            try
            {
                DBCommand.ExecuteNonQuery();
                return true;
            }

            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine(error.ToString());                                               // Prints the error debug info in the console. Only works during DEBUG option. Use DEBUG -> Start Debugging if you want to see the error message.
                return false;
            }
        }

        public String executeScalar(String SQLCommand)                                                             // Returns 1 value as a String
        {
            DBCommand.Connection = DBConnection;
            DBCommand.CommandText = SQLCommand;
            DBCommand.CommandType = CommandType.Text;

            try
            {
                var scalarValue = DBCommand.ExecuteScalar().ToString();
                return scalarValue;
            }

            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine(error.ToString());
                return "ERROR";
            }

        }

        public OleDbDataReader getReader()                                                                          // Returns the reader to read from the other method. Use Reader methods to loop through data to retrieve needed info. 
        {
            return DBReader;
        }
    }
}