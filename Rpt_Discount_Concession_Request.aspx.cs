using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
//using System.Data.SqlClient.SqlDataReader;
//using Exportxls.BL;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using ShoppingCart.BL;
//using Exportxls.BL;
using Encryption.BL;

public partial class Rpt_Discount_Concession_Request : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DivResultPanel.Visible = false;
        if (!IsPostBack)
        {
            FillDDL_Company();
            FillRequestType();
            FillRequestStatus();
           // BindAcademicYear();
        }
       // BindDivision();
    }
    protected void BtnClearSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("Rpt_Discount_Concession_Request.aspx");
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {


        List<string> list = new List<string>();
        List<string> List1 = new List<string>();
        List<string> List2 = new List<string>();
        List<string> List3 = new List<string>();
        List<string> List4 = new List<string>();

        string Zone = "";
        foreach (ListItem li in ddlzone.Items)
        {
            if (li.Selected == true)
            {
                list.Add(li.Value);
                Zone = string.Join(",", list.ToArray());
            }
        }
        string Zonecode = Zone;
        // Center Comma Separated
        string Center = "";
        foreach (ListItem li1 in ddlcenter.Items)
        {
            if (li1.Selected == true)
            {
                List1.Add(li1.Value);
                Center = string.Join(",", List1.ToArray());


            }
        }

        string CenterCode = Center;
        //Acadyear Comma Separated



        string stream = "";
        foreach (ListItem li3 in ddlstream.Items)
        {
            if (li3.Selected == true)
            {
                List3.Add(li3.Value);
                stream = string.Join(",", List3.ToArray());
            }
        }
        string CompanyCode = ddlcompany.SelectedValue;
        string DivisionCode = ddldivision.SelectedValue;

        List<string> List99 = new List<string>();
        List<string> List98 = new List<string>();

        string RequestType = "";
        foreach (ListItem li99 in ddlrequesttype.Items)
        {
            if (li99.Selected == true)
            {
                List99.Add(li99.Value);
                RequestType = string.Join(",", List99.ToArray());
            }
        }

        string RequestStatus = "";
        foreach (ListItem li98 in ddlRequeststatus.Items)
        {
            if (li98.Selected == true)
            {
                List98.Add(li98.Value);
                RequestStatus = string.Join(",", List98.ToArray());
            }
        }

        string DateRange = "";
        DateRange = id_date_range_picker_1.Value;
        if (DateRange.Length != 0)
        {

            string fromdate, todate;
            fromdate = DateRange.Substring(0, 10);
            todate = DateRange.Substring(DateRange.Length - 10);

            //string a1 = fromdate.ToString("dd MMM yyyy");
            //string a2 = todate.ToString("dd MMM yyyy");



            DataSet Ds = Reporting.GetDiscountConcessionRequest(DivisionCode, Zonecode, stream, CenterCode, ddlacademicyear.SelectedValue, RequestType, RequestStatus, txtSbentrycode.Text.Trim(), fromdate, todate);
            if (Ds.Tables[0].Rows.Count > 0)
            {
                Repeater1.DataSource = Ds;
                Repeater1.DataBind();
                //script1.RegisterAsyncPostBackControl(Repeater1);
                lbltotalcount.Text = Ds.Tables[0].Rows.Count.ToString();
                Msg_Error.Visible = false;
                DivSearchPanel.Visible = false;
                DivResultPanel.Visible = true;
                
            }

            else
            {
                Msg_Error.Visible = true;
                lblerror.Visible = true;
                lblerror.Text = "No Record Found. Kindly Re-Select your search criteria";

            }


        }
        else
        {
            string a1 = "";
            string a2 = "";



            DataSet Ds = Reporting.GetDiscountConcessionRequest(DivisionCode, Zonecode, stream, CenterCode, ddlacademicyear.SelectedValue, RequestType, RequestStatus, txtSbentrycode.Text.Trim(), a1, a2);
            if (Ds.Tables[0].Rows.Count > 0)
            {
                Repeater1.DataSource = Ds;
                Repeater1.DataBind();
                //script1.RegisterAsyncPostBackControl(Repeater1);
                lbltotalcount.Text = Ds.Tables[0].Rows.Count.ToString();
                Msg_Error.Visible = false;
                DivSearchPanel.Visible = false;
                DivResultPanel.Visible = true;
                
            }

            else
            {
                Msg_Error.Visible = true;
                lblerror.Visible = true;
                lblerror.Text = "No Record Found. Kindly Re-Select your search criteria";

            }
 
        }
    }
    protected void Back_Click(object sender, EventArgs e)
    {
        DivResultPanel.Visible = false;
        DivSearchPanel.Visible = true;
    }
    private void BindZone()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = Reporting.GetUser_Company_Division_Zone_Center(3, UserID, ddldivision.SelectedValue, "", ddlcompany.SelectedValue);
        BindListBox(ddlzone, ds, "Zone_Name", "Zone_Code");
        ddlzone.Items.Insert(0, "All");
       // ddlzone.SelectedIndex = 0;
    }
    private void BindListBox(ListBox ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }
    private void FillRequestType()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet dsrequesttype = Reporting.GetRequestType();
        BindListBox(ddlrequesttype, dsrequesttype, "Request_Type", "Request_Code");
        ddlrequesttype.Items.Insert(0, "All");
        //ddlrequesttype.SelectedIndex = 0;
    }
    private void FillDDL_Company()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet dscompany = Reporting.GetUser_Company_Division_Zone_Center(1, UserID, "", "", "");
        BindDDL(ddlcompany, dscompany, "Company_Name", "Company_Code");
        ddlcompany.Items.Insert(0, "Select");
        ddlcompany.SelectedIndex = 0;
    }
    private void FillRequestStatus()
    {
        
        ddlRequeststatus.DataSource = GetTable();
        ddlRequeststatus.DataTextField = "requeststatus";
        ddlRequeststatus.DataValueField = "statusid";
        ddlRequeststatus.DataBind();
    }
    static DataTable GetTable()
    {
        // Here we create a DataTable  columns.
        DataTable table = new DataTable();
        table.Columns.Add("statusid", typeof(string));
        table.Columns.Add("requeststatus", typeof(string));



        // Here we add  DataRows.
        table.Rows.Add("All", "All");
        table.Rows.Add("0", "Pending for Approval");
        table.Rows.Add("1", "Approved");
        table.Rows.Add("2", "Declined");

        return table;
    }
    protected void ddlcompany_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindDivision();
    }
    private void BindDivision()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = Reporting.GetUser_Company_Division_Zone_Center(2, UserID, "", "", ddlcompany.SelectedValue);
        BindDDL(ddldivision, ds, "Division_Name", "Division_Code");
        ddldivision.Items.Insert(0, "Select");
       // ddldivision.SelectedIndex = 0;
        
    }
    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }
    //private void BindStream()
    //{
    //    List<string> list = new List<string>();
    //    List<string> List1 = new List<string>();
    //    List<string> List2 = new List<string>();

    //    string Zone = "";
    //    foreach (ListItem li in ddlzone.Items)
    //    {
    //        if (li.Selected == true)
    //        {
    //            list.Add(li.Value);
    //            Zone = string.Join(",", list.ToArray());
    //        }
    //    }
    //    string Zones = Zone;

    //    string center = "";
    //    foreach (ListItem li in ddlcenter.Items)
    //    {
    //        if (li.Selected == true)
    //        {
    //            List1.Add(li.Value);
    //            center = string.Join(",", List1.ToArray());
    //        }
    //    }
    //    string centers = center;

    // //   string acad = "All";


    //    //List<string> List202 = new List<string>();
    //    //string AcadYear = "";
    //    //foreach (ListItem li in ddlacademicyear.Items)
    //    //{
    //    //    if (li.Selected == true)
    //    //    {
    //    //        List202.Add(li.Value);
    //    //        AcadYear = string.Join(",", List202.ToArray());
    //    //    }
    //    //}
    //    string AcadYear = "All";

    //    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
    //    string UserID = cookie.Values["UserID"];
    //    string UserName = cookie.Values["UserName"];
    //    //        DataSet ds = Reporting.GetStreamby_Center_AcademicYear_All(ddlcenter.SelectedValue, ddlacademicyear.SelectedValue, ddlcompany.SelectedValue, ddldivision.SelectedValue);
    //    DataSet ds = Reporting.GetStreamby_Center_AcademicYear_All(centers, AcadYear, ddlcompany.SelectedValue, ddldivision.SelectedValue, Zones);
    //    //  BindDDL(ddlstream, ds, "Stream_Sdesc", "Stream_Code");     
    //    BindListBox(ddlstream, ds, "Stream_Sdesc", "Stream_Code");
    //    ddlstream.Items.Insert(0, "All");
    //    // ddlstream.SelectedIndex = 0;
    //}
    private void BindStream()
    {
        List<string> list = new List<string>();
        List<string> List1 = new List<string>();
        List<string> List2 = new List<string>();

        string Zone = "";
        foreach (ListItem li in ddlzone.Items)
        {
            if (li.Selected == true)
            {
                list.Add(li.Value);
                Zone = string.Join(",", list.ToArray());
            }
        }
        string Zones = Zone;

        string center = "";
        foreach (ListItem li in ddlcenter.Items)
        {
            if (li.Selected == true)
            {
                List1.Add(li.Value);
                center = string.Join(",", List1.ToArray());
            }
        }
        string centers = center;

        string AcadYear = "";
        foreach (ListItem li in ddlacademicyear.Items)
        {
            if (li.Selected == true)
            {
                List2.Add(li.Value);
                AcadYear = string.Join(",", List2.ToArray());
            }
        }
        string AcadYears = AcadYear;

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        //DataSet ds = Reporting.GetStreamby_Center_AcademicYear_All(ddlcenter.SelectedValue, ddlacademicyear.SelectedValue, ddlcompany .SelectedValue , ddldivision .SelectedValue );
        DataSet ds = Reporting.GetStreamby_Center_AcademicYear_All(centers, AcadYears, ddlcompany.SelectedValue, ddldivision.SelectedValue, Zones);
        //  BindDDL(ddlstream, ds, "Stream_Sdesc", "Stream_Code");     
        BindListBox(ddlstream, ds, "Stream_Sdesc", "Stream_Code");
        ddlstream.Items.Insert(0, "All");
        //ddlstream.SelectedIndex = 0;
    }
    private void BindCenter()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        List<string> list = new List<string>();
        List<string> List1 = new List<string>();
        string Sgrcode = "";
        foreach (ListItem li in ddlzone.Items)
        {
            if (li.Selected == true)
            {
                list.Add(li.Value);
                Sgrcode = string.Join(",", list.ToArray());
                if (Sgrcode == "All")
                {
                    int remove = Math.Min(list.Count, 1);
                    list.RemoveRange(0, remove);
                }
            }

        }

        string Zone = Sgrcode;
        DataSet ds = Reporting.GetUser_Company_Division_Zone_Center(4, UserID, ddldivision.SelectedValue, Zone, ddlcompany.SelectedValue);
        BindListBox(ddlcenter, ds, "Center_name", "Center_Code");
        ddlcenter.Items.Insert(0, "All");
        //ddlcenter.SelectedIndex = 0;

    }
    protected void ddldivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindZone();
    }
    protected void ddlzone_SelectedIndexChanged(object sender, EventArgs e)
    {
        int count = ddlzone.GetSelectedIndices().Length;

        if (ddlzone.SelectedValue == "All")
        {
            ddlzone.Items.Clear();
            ddlzone.Items.Insert(0, "All");
            ddlzone.SelectedIndex = 0;
            BindCenter();
        }
        else if (count == 0)
        {
            BindZone();
            //BindCenter();
        }
        else
        {

            BindCenter();
        }

    }
    protected void ddlcenter_SelectedIndexChanged(object sender, EventArgs e)
    {

        int count = ddlcenter.GetSelectedIndices().Length;

        if (ddlcenter.SelectedValue == "All")
        {
            ddlcenter.Items.Clear();
            ddlcenter.Items.Insert(0, "All");
            ddlcenter.SelectedIndex = 0;
            BindAcademicYear();
        }
        else if (count == 0)
        {
            BindCenter();
            //BindCenter();
        }
        else
        {
            BindAcademicYear();
        }
    }

    protected void ddlstream_SelectedIndexChanged(object sender,EventArgs e)
    {

        int count = ddlstream.GetSelectedIndices().Length;

        if (ddlstream.SelectedValue == "All")
        {
            ddlstream.Items.Clear();
            ddlstream.Items.Insert(0, "All");
            ddlstream.SelectedIndex = 0;
            
        }
        else if (count == 0)
        {
            BindStream();
            //BindCenter();
        }
        
        //else
        //{
        //    BindStream();
        //}
    }

    protected void btnexporttoexcel_Click(object sender, EventArgs e)
    {

        List<string> list = new List<string>();
        List<string> List1 = new List<string>();
        List<string> List2 = new List<string>();
        List<string> List3 = new List<string>();
        List<string> List4 = new List<string>();

        string Zone = "";
        foreach (ListItem li in ddlzone.Items)
        {
            if (li.Selected == true)
            {
                list.Add(li.Value);
                Zone = string.Join(",", list.ToArray());
            }
        }
        string Zonecode = Zone;
        // Center Comma Separated
        string Center = "";
        foreach (ListItem li1 in ddlcenter.Items)
        {
            if (li1.Selected == true)
            {
                List1.Add(li1.Value);
                Center = string.Join(",", List1.ToArray());


            }
        }

        string CenterCode = Center;
        //Acadyear Comma Separated



        string stream = "";
        foreach (ListItem li3 in ddlstream.Items)
        {
            if (li3.Selected == true)
            {
                List3.Add(li3.Value);
                stream = string.Join(",", List3.ToArray());
            }
        }
        string CompanyCode = ddlcompany.SelectedValue;
        string DivisionCode = ddldivision.SelectedValue;

        List<string> List99 = new List<string>();
        List<string> List98 = new List<string>();

        string RequestType = "";
        foreach (ListItem li99 in ddlrequesttype.Items)
        {
            if (li99.Selected == true)
            {
                List99.Add(li99.Value);
                RequestType = string.Join(",", List99.ToArray());
            }
        }

        string RequestStatus = "";
        foreach (ListItem li98 in ddlRequeststatus.Items)
        {
            if (li98.Selected == true)
            {
                List98.Add(li98.Value);
                RequestStatus = string.Join(",", List98.ToArray());
            }
        }

        string DateRange = "";
        DateRange = id_date_range_picker_1.Value;
        if (DateRange.Length != 0)
        {

            string fromdate, todate;
            fromdate = DateRange.Substring(0, 10);
            todate = DateRange.Substring(DateRange.Length - 10);

            //string a1 = fromdate.ToString("dd MMM yyyy");
            //string a2 = todate.ToString("dd MMM yyyy");



            DataSet Ds = Reporting.GetDiscountConcessionRequest(DivisionCode, Zonecode, stream, CenterCode, ddlacademicyear.SelectedValue, RequestType, RequestStatus, txtSbentrycode.Text.Trim(), fromdate, todate);
            if (Ds.Tables[0].Rows.Count > 0)
            {
                ExportToExcel(Ds);
            }
        }
        else
        {
            string fromdate="", todate="";
            
            DataSet Ds = Reporting.GetDiscountConcessionRequest(DivisionCode, Zonecode, stream, CenterCode, ddlacademicyear.SelectedValue, RequestType, RequestStatus, txtSbentrycode.Text.Trim(), fromdate, todate);
            if (Ds.Tables[0].Rows.Count > 0)
            {
                ExportToExcel(Ds);
            }

        }
        
    }
    public void ExportToExcel(DataSet Ds)
    {
        //ExportToExcel(Ds);
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Discount_Concession_rept.xls"));
        Response.ContentType = "application/ms-excel";
        DataTable dt = Ds.Tables[0];
        string str = string.Empty;
        int count = 0;
        foreach (DataColumn dtcol in dt.Columns)
        {
           if (dtcol.ColumnName == "StudentName")
            {

                Response.Write("Discount Concession Report");
            }
            else
            {
                string str11 = "\t";
                Response.Write(str11);
            }

        }
        string str1 = "\n";
        Response.Write(str1);
        foreach (DataColumn dtcol in dt.Columns)
        {
            Response.Write(str + dtcol.ColumnName);
            str = "\t";
        }
        Response.Write("\n");
        foreach (DataRow dr in dt.Rows)
        {
            str = "";
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                Response.Write(str + Convert.ToString(dr[j]).Trim());
                str = "\t";
            }
            Response.Write("\n");
        }
        Response.End();

    }
    private void BindAcademicYear()
    {


        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = Reporting.GetAllAcadyear();
        BindDDL(ddlacademicyear, ds, "Acad_Year", "Acad_Year");
        ddlacademicyear.Items.Insert(0, "Select");
        //ddlacademicyear.SelectedIndex = 0;
    }
    protected void ddlacademicyear_SelectedIndexChanged(object sender, System.EventArgs e)
    {       

            BindStream();
        
    }
    
}
    
    
