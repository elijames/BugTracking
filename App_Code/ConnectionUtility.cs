using System;
using System.Collections.Generic;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Configuration;

/// <summary>
/// The ConnectionUtility class connects to the database, collects the data either through connected or disconnected architecture (based on the method), returns data queried through stored procedures, or submits data to the 
/// database through a stored procedure.
/// 
/// Developer: Eli Lennox
/// Date: 6/16/14
/// </summary>
/// 

public static class ConnectionUtility
{
    /// <summary>
    /// updateQuantity updates the database with a newly reported bug.
    /// </summary>
    /// <param name="SysId">integer that describes the system ID on the database</param>
    /// <param name="version"> string of version of the system where the bug was found </param>
    /// <param name="functionality">string describing what part of the application in which the bug was found</param>
    /// <param name="subject">string describing the overall bug</param>
    /// <param name="status">integer value from database describing the correlating status</param>
    /// <param name="resolution">integer value from database describing the correlating resolution</param>
    /// <param name="severity">integer value from database describing the correlating severity</param>
    /// <param name="exterminator">string describing the user reporting the issue</param>
    /// <param name="ext">string describing the user's extension</param>
    /// <param name="reported">timedate stamp of when the bug was reported</param>
	

    public static void updateQuantity(int SysId, string version, string functionality, string subject, int status, int resolution, int severity, string exterminator, string ext, string reported)
    {
        //database connection string
        string connectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\eli\Downloads\WebQA.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";

        //establishes a new sql connection using the connectionstring
        SqlConnection conn = new SqlConnection(connectionString);

        //establishes the timestamp
        DateTime dt = DateTime.Now; //automatically fetches date/time for timestamp

        //opens the connection and submits data to database through a stored procedure
        try
        {
            conn.Open();
            //sets command
            SqlCommand cmd = new SqlCommand("ReportBug", conn);
            //describes command as stored procedure
            cmd.CommandType = CommandType.StoredProcedure;
            //loads stored procedure parameters
            cmd.Parameters.Add("@SystemId", SqlDbType.Int);
            cmd.Parameters["@SystemId"].Value = SysId;
            cmd.Parameters.Add("@Version", SqlDbType.VarChar);
            cmd.Parameters["@Version"].Value = version;
            cmd.Parameters.Add("@Functionality", SqlDbType.VarChar);
            cmd.Parameters["@Functionality"].Value = functionality;
            cmd.Parameters.Add("@Subject", SqlDbType.VarChar);
            cmd.Parameters["@Subject"].Value = subject;
            cmd.Parameters.Add("@BugSeverity", SqlDbType.Int);
            cmd.Parameters["@BugSeverity"].Value = severity;
            cmd.Parameters.Add("@BugResolution", SqlDbType.Int);
            cmd.Parameters["@BugResolution"].Value = resolution;
            cmd.Parameters.Add("@BugStatus", SqlDbType.Int);
            cmd.Parameters["@BugStatus"].Value = status;
            cmd.Parameters.Add("@Exterminator", SqlDbType.VarChar);
            cmd.Parameters["@Exterminator"].Value = exterminator;
            cmd.Parameters.Add("@ExterminatorExt", SqlDbType.VarChar);
            cmd.Parameters["@ExterminatorExt"].Value = ext;
            cmd.Parameters.Add("@IssueReported", SqlDbType.VarChar);
            cmd.Parameters["@IssueReported"].Value = reported;
            cmd.Parameters.Add("@Now", SqlDbType.DateTime);
            cmd.Parameters["@Now"].Value = dt;

            //executes stored procedure
            cmd.ExecuteNonQuery();
            //closes the connection
            conn.Close();
        }
        catch (SqlException sqle)
        {

        }
        finally { }


    }
    public static void pieChartLoad(string conn, string command, Chart x)
    {
        using (SqlConnection cn = new SqlConnection(conn))
        {
            cn.Open();
            using (SqlCommand cmd = new SqlCommand(command))
            {
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                //load DataSet/DataTable here
                //flip columns and rows
                //fill pie chart
            }
        }
    }
    /// <summary>
    /// loadDrop loads the dropboxes in any portion of the application from database items
    /// </summary>
    /// <param name="conn">connection string</param>
    /// <param name="command">command (a stored procedure in all cases)</param>
    /// <param name="x">the dropdown list loaded</param>
    public static void loadDrop(string conn, string command, DropDownList x)
    {

        using (SqlConnection cn = new SqlConnection(conn))
        {
            cn.Open();
            using (SqlCommand cmd = new SqlCommand(command))
            {
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        ListItem li = new ListItem();
                        li.Text = rdr[0].ToString();
                        li.Value = rdr[1].ToString();
                        x.Items.Add(li);
                    }
                    if (x.Items.Count > 0)
                    {
                        x.SelectedIndex = 0;
                    }
                }
            }
            cn.Close();
        }
    }
    /// <summary>
    /// loads a data table for populating data in either charts or summaries
    /// </summary>
    /// <param name="query">the query for the database (or stored procedure)</param>
    /// <returns>the datatable used to load data visualizations/summaries</returns>
    public static DataTable GetData(string query)
    {
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand(query);
        String constr = ConfigurationManager.ConnectionStrings["WebQAConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        SqlDataAdapter sda = new SqlDataAdapter();
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        sda.SelectCommand = cmd;
        sda.Fill(dt);
        return dt;
    }
}