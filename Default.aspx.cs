using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Configuration;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string conn = ConfigurationManager.ConnectionStrings["WebQAConnectionString"].ConnectionString;
            ConnectionUtility.loadDrop(conn, "getSystemName", SelectSoftware);
        }

    }
    protected void SelectSoftware_SelectedIndexChanged(object sender, EventArgs e)
    {


        SeverityChart.Visible = true;
        int ss;
        string sel = SelectSoftware.SelectedValue;
        int.TryParse(sel, out ss);
        string query = string.Format("SELECT tblServerity.Serverity, COUNT(tblIssueTracker.IssueID) AS Instances FROM tblIssueTracker INNER JOIN tblServerity ON tblIssueTracker.SeverityID = tblServerity.ServID WHERE tblIssueTracker.SystemID = '{0}' GROUP BY tblServerity.Serverity", ss);
        DataTable dt = ConnectionUtility.GetData(query);
        string[] x = new string[dt.Rows.Count];
        int[] y = new int[dt.Rows.Count];
        for (int i = 0; i < dt.Rows.Count; i++)
        {

            x[i] = dt.Rows[i][0].ToString();
            y[i] = Convert.ToInt32(dt.Rows[i][1]); 
            
        }
        SeverityChart.Series[0].Points.DataBindXY(x, y);
        SeverityChart.Series[0].ChartType = SeriesChartType.Pie;
        SeverityChart.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
       // SeverityChart.Legends[0].Enabled = true;

        StatusChart.Visible = true;
        int stats;
        int.TryParse(sel, out stats);
        string statusQuery = string.Format("SELECT tblStatus.Status, COUNT(tblIssueTracker.IssueID) AS Bugs FROM tblIssueTracker INNER JOIN tblStatus ON tblIssueTracker.StatusID = tblStatus.StatusID WHERE tblIssueTracker.SystemID = '{0}' GROUP BY tblStatus.Status", stats);
        DataTable dat = ConnectionUtility.GetData(statusQuery);
        string[] sx = new string[dat.Rows.Count];
        int[] sy = new int[dat.Rows.Count];
        for (int i = 0; i < dat.Rows.Count; i++)
        {

            sx[i] = dat.Rows[i][0].ToString();
            sy[i] = Convert.ToInt32(dat.Rows[i][1]);

        }
        StatusChart.Series[0].Points.DataBindXY(sx, sy);
        StatusChart.Series[0].ChartType = SeriesChartType.Pie;
        StatusChart.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;

    }
}
