using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class About : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string con = ConfigurationManager.ConnectionStrings["WebQAConnectionString"].ConnectionString;
            ConnectionUtility.loadDrop(con, "getresolution", Resolution);
            ConnectionUtility.loadDrop(con, "getSeverity", BugSev);
            ConnectionUtility.loadDrop(con, "getStatus", Status);
            ConnectionUtility.loadDrop(con, "getSystemName", BuggedSystemListBox);

        }



    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string systemstr = BuggedSystemListBox.SelectedValue;
        int systemval;
        int.TryParse(systemstr, out systemval);
        string versions = version.Text;
        string functionality = functionareabox.Text;
        string subjstr = Subject.Text;
        string statusstr = Status.SelectedValue;
        int statusValue;
        int.TryParse(statusstr, out statusValue);
        string resolutionstr = Resolution.SelectedValue;
        int resolutionVal;
        int.TryParse(resolutionstr, out resolutionVal);
        //string severestr = 
        int severe = int.Parse(BugSev.SelectedValue);
        // int.TryParse(severestr, out severe);
        string reportedBy = flyTrapper.Text;
        string reptExt = FlyTrapperExtension.Text;
        string description = bugDescription.Text;

        ConnectionUtility.updateQuantity(systemval, versions, functionality, subjstr, statusValue, resolutionVal, severe, reportedBy, reptExt, description);
        BuggedSystemListBox.ClearSelection();
        Status.ClearSelection();
        Resolution.ClearSelection();
        BugSev.ClearSelection();

        Server.Transfer("~/Default.aspx");
    }
    protected void BuggedSystemListBox_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
