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

public partial class Rpt_Cheque_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DivResultPanel.Visible = false;
        if (!IsPostBack)
        {
            if (Request.Cookies["MyCookiesLoginInfo"] != null)
            {
                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID = cookie.Values["UserID"];
                string UserName = cookie.Values["UserName"];
                FillDDL_Company();
                FillDDL_ChequeStatus();
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }
    }

    private void BindListBox(ListBox ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }

    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }

    public static object traverse(ref ListBox ListBox1)
    {
        List<string> lst = new List<string>();
        foreach (ListItem li in ListBox1.Items)
        {
            if (li.Selected)
            {
                lst.Add(li.Value);
            }
        }
        string stream1 = string.Join(",", lst.ToArray());
        //string stream = string.Join(",", lst.ToArray);
        return stream1;
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
        ddldivision.SelectedIndex = 0;
    }

    protected void ddldivision_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindZone();
    }

    private void BindZone()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = Reporting.GetUser_Company_Division_Zone_Center(3, UserID, ddldivision.SelectedValue, "", ddlcompany.SelectedValue);
        BindListBox(ddlzone, ds, "Zone_Name", "Zone_Code");
        ddlzone.Items.Insert(0, "All");
        //ddlzone.SelectedIndex = 0;
    }


    protected void ddlzone_SelectedIndexChanged(object sender, System.EventArgs e)
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

    }


    protected void ddlcenter_SelectedIndexChanged(object sender, System.EventArgs e)
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
       // BindAcademicYear();
    }

    private void BindAcademicYear()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = Reporting.GetAllAcadyear();
        BindListBox(ddlacademicyear, ds, "Acad_Year", "Acad_Year");
        //ddlacademicyear.Items.Insert(0, "All");
       // ddlacademicyear.SelectedIndex = 0;
    }

    private void FillDDL_ChequeStatus()
    {

        DataSet ds = Reporting.GetChequeStatus();
        BindListBox(ddlchequestatus, ds, "chqstatus", "chqcode");
        ddlchequestatus.Items.Insert(0, "All");
       // ddlchequestatus.SelectedIndex = 0;
    }

    protected void ddlAcadyear_SelectedIndexChanged(object sender, System.EventArgs e)
    {


        int count = ddlacademicyear.GetSelectedIndices().Length;

        if (ddlacademicyear.SelectedValue == "All")
        {
            ddlacademicyear.Items.Clear();
            ddlacademicyear.Items.Insert(0, "All");
            ddlacademicyear.SelectedIndex = 0;
            BindStream();
        }
        else if (count == 0)
        {

            BindAcademicYear();
            //BindCenter();
        }
        else
        {
            BindStream();
        }



       // BindStream();
    }

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
//        DataSet ds = Reporting.GetStreamby_Center_AcademicYear_All(ddlcenter.SelectedValue, ddlacademicyear.SelectedValue, ddlcompany.SelectedValue, ddldivision.SelectedValue);
        DataSet ds = Reporting.GetStreamby_Center_AcademicYear_All(centers, AcadYears, ddlcompany.SelectedValue, ddldivision.SelectedValue, Zones);
        //  BindDDL(ddlstream, ds, "Stream_Sdesc", "Stream_Code");     
        BindListBox(ddlstream, ds, "Stream_Sdesc", "Stream_Code");
        ddlstream.Items.Insert(0, "All");
       // ddlstream.SelectedIndex = 0;
    }

    protected void BtnSearch_Click(object sender, System.EventArgs e)
    {


        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string CompanyCode = ddlcompany.SelectedValue;
        string DivisionCode = ddldivision.SelectedValue;



        //Zone Comma Separated
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
        string Acadyear = "";
        foreach (ListItem li2 in ddlacademicyear.Items)
        {
            if (li2.Selected == true)
            {
                List2.Add(li2.Value);
                Acadyear = string.Join(",", List2.ToArray());
            }
        }
        string AcadyearCode = Acadyear;


        string stream = "";
        foreach (ListItem li3 in ddlstream.Items)
        {
            if (li3.Selected == true)
            {
                List3.Add(li3.Value);
                stream = string.Join(",", List3.ToArray());
            }
        }

        string Chequestatus = "";
        foreach (ListItem lcheque in ddlchequestatus.Items)
        {
            if (lcheque.Selected == true)
            {
                List4.Add(lcheque.Value);
                Chequestatus = string.Join(",", List4.ToArray());
            }
        }


        string Reporttype = "01";
        string Flag = "1";
        string Flag2 = "2";
        string fdate = "";
        string tdate = "";



        string DateRange = "";
        DateRange = id_date_range_picker_1.Value;

        if (DateRange.Length != 0)
        {

            DateTime fromdate, todate;
            fromdate = Convert.ToDateTime(DateRange.Substring(0, 10));
            todate = Convert.ToDateTime(DateRange.Substring(DateRange.Length - 10));

            string a1 = fromdate.ToString("dd MMM yyyy");
            string a2 = todate.ToString("dd MMM yyyy");

            string flag = "";
            DataSet ds1 = Reporting.GetChequeDetails(CompanyCode, DivisionCode, Zonecode, CenterCode, AcadyearCode, a1, a2, UserID, stream, Chequestatus,txtsbentrycode.Text,txtChequeno.Text,flag);
            
            if (ds1.Tables[0].Rows.Count > 0)
            {
                
                Repeater1.DataSource = ds1;
                Repeater1.DataBind();
                //script1.RegisterAsyncPostBackControl(Repeater1);
                lbltotalcount.Text = ds1.Tables[0].Rows.Count.ToString();
                Msg_Error.Visible = false;
                DivSearchPanel.Visible = false;
                DivResultPanel.Visible = true;
                //Session["s_Chequedetails"] = ds1;
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
            string a1 ="";
            string a2 ="";
            string flag = "";
            DataSet ds1 = Reporting.GetChequeDetails(CompanyCode, DivisionCode, Zonecode, CenterCode, AcadyearCode, a1, a2, UserID, stream, Chequestatus, txtsbentrycode.Text, txtChequeno.Text,flag);
                
            if (ds1.Tables[0].Rows.Count > 0)
            {
                
                Repeater1.DataSource = ds1;
                Repeater1.DataBind();
                //script1.RegisterAsyncPostBackControl(Repeater1);
                lbltotalcount.Text = ds1.Tables[0].Rows.Count.ToString();
                Msg_Error.Visible = false;
                DivSearchPanel.Visible = false;
                DivResultPanel.Visible = true;
                //Session["s_Chequedetails"] = ds1;
            }

            else
            {
                Msg_Error.Visible = true;
                lblerror.Visible = true;
                lblerror.Text = "No Record Found. Kindly Re-Select your search criteria";

            }
            

        }
    }
    

    
    protected void btnexporttoexcel_Click(object sender, System.EventArgs e)
    {
        
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string CompanyCode = ddlcompany.SelectedValue;
        string DivisionCode = ddldivision.SelectedValue;



        //Zone Comma Separated
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
        string Acadyear = "";
        foreach (ListItem li2 in ddlacademicyear.Items)
        {
            if (li2.Selected == true)
            {
                List2.Add(li2.Value);
                Acadyear = string.Join(",", List2.ToArray());
            }
        }
        string AcadyearCode = Acadyear;


        string stream = "";
        foreach (ListItem li3 in ddlstream.Items)
        {
            if (li3.Selected == true)
            {
                List3.Add(li3.Value);
                stream = string.Join(",", List3.ToArray());
            }
        }

        string Chequestatus = "";
        foreach (ListItem lcheque in ddlchequestatus.Items)
        {
            if (lcheque.Selected == true)
            {
                List4.Add(lcheque.Value);
                Chequestatus = string.Join(",", List4.ToArray());
            }
        }


        string Reporttype = "01";
        string Flag = "1";
        string Flag2 = "2";
        string fdate = "";
        string tdate = "";



        string DateRange = "";
        DateRange = id_date_range_picker_1.Value;

        if (DateRange.Length != 0)
        {

            DateTime fromdate, todate;
            fromdate = Convert.ToDateTime(DateRange.Substring(0, 10));
            todate = Convert.ToDateTime(DateRange.Substring(DateRange.Length - 10));

            string a1 = fromdate.ToString("dd MMM yyyy");
            string a2 = todate.ToString("dd MMM yyyy");

            string flag = "";
            DataSet ds1 = Reporting.GetChequeDetails(CompanyCode, DivisionCode, Zonecode, CenterCode, AcadyearCode, a1, a2, UserID, stream, Chequestatus, txtsbentrycode.Text, txtChequeno.Text, flag);

            if (ds1.Tables[0].Rows.Count > 0)
            {

                ExportToExcel(ds1);
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
            string flag = "";
            DataSet ds1 = Reporting.GetChequeDetails(CompanyCode, DivisionCode, Zonecode, CenterCode, AcadyearCode, a1, a2, UserID, stream, Chequestatus, txtsbentrycode.Text, txtChequeno.Text, flag);

            if (ds1.Tables[0].Rows.Count > 0)
            {
                ExportToExcel(ds1);

                //Repeater1.DataSource = ds1;
                //Repeater1.DataBind();
                ////script1.RegisterAsyncPostBackControl(Repeater1);
                //lbltotalcount.Text = ds1.Tables[0].Rows.Count.ToString();
                //Msg_Error.Visible = false;
                //DivSearchPanel.Visible = false;
                //DivResultPanel.Visible = true;
                
            }

            else
            {
                Msg_Error.Visible = true;
                lblerror.Visible = true;
                lblerror.Text = "No Record Found. Kindly Re-Select your search criteria";

            }
        }
       
    }
    public void ExportToExcel(DataSet ds)
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Cheque_Details.xls"));
        Response.ContentType = "application/ms-excel";


        DataTable dt = ds.Tables[0];
        string str = string.Empty;
        int count = 0;
        foreach (DataColumn dtcol in dt.Columns)
        {


            if (dtcol.ColumnName == "Cheque Amt")
            {

                Response.Write("Cheque Details Report");
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

    public override void VerifyRenderingInServerForm(Control control)
    {
    }
    protected void BtnClearSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("rpt_Cheque_details.aspx");
    }
    protected void Back_Click(object sender, EventArgs e)
    {
       // Response.Redirect("rpt_Cheque_details.aspx");
        DivSearchPanel.Visible = true;
        DivResultPanel.Visible = false;
    }
    protected void ddlstream_SelectedIndexChanged(object sender, EventArgs e)
    {
        int count = ddlstream.GetSelectedIndices().Length;

        if (ddlstream.SelectedValue == "All")
        {
            ddlstream.Items.Clear();
            ddlstream.Items.Insert(0, "All");
            ddlstream.SelectedIndex = 0;
            FillDDL_ChequeStatus();
        }
        else if (count == 0)
        {
            BindStream();
            //BindCenter();
        }
        else
        {
            FillDDL_ChequeStatus();
        }
    }
    protected void ddlchequestatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        int count = ddlchequestatus.GetSelectedIndices().Length;

        if (ddlchequestatus.SelectedValue == "All")
        {
            ddlchequestatus.Items.Clear();
            ddlchequestatus.Items.Insert(0, "All");
            ddlchequestatus.SelectedIndex = 0;
            //BindPayPlan();
        }
        else if (count == 0)
        {
            FillDDL_ChequeStatus();
            //BindCenter();
        }
        else
        {
           // BindPayPlan();
        }
    }
    protected void Repeater1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string CompanyCode = ddlcompany.SelectedValue;
        string DivisionCode = ddldivision.SelectedValue;



        //Zone Comma Separated
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
        string Acadyear = "";
        foreach (ListItem li2 in ddlacademicyear.Items)
        {
            if (li2.Selected == true)
            {
                List2.Add(li2.Value);
                Acadyear = string.Join(",", List2.ToArray());
            }
        }
        string AcadyearCode = Acadyear;


        string stream = "";
        foreach (ListItem li3 in ddlstream.Items)
        {
            if (li3.Selected == true)
            {
                List3.Add(li3.Value);
                stream = string.Join(",", List3.ToArray());
            }
        }

        string Chequestatus = "";
        foreach (ListItem lcheque in ddlchequestatus.Items)
        {
            if (lcheque.Selected == true)
            {
                List4.Add(lcheque.Value);
                Chequestatus = string.Join(",", List4.ToArray());
            }
        }


        string Reporttype = "01";
        string Flag = "1";
        string Flag2 = "2";
        string fdate = "";
        string tdate = "";



        string DateRange = "";
        DateRange = id_date_range_picker_1.Value;

        if (DateRange.Length != 0)
        {

            DateTime fromdate, todate;
            fromdate = Convert.ToDateTime(DateRange.Substring(0, 10));
            todate = Convert.ToDateTime(DateRange.Substring(DateRange.Length - 10));

            string a1 = fromdate.ToString("dd MMM yyyy");
            string a2 = todate.ToString("dd MMM yyyy");

            string flag = "";
            DataSet ds1 = Reporting.GetChequeDetails(CompanyCode, DivisionCode, Zonecode, CenterCode, AcadyearCode, a1, a2, UserID, stream, Chequestatus, txtsbentrycode.Text, txtChequeno.Text, flag);

            if (ds1.Tables[0].Rows.Count > 0)
            {
                Repeater1.PageIndex = e.NewPageIndex;
                Repeater1.DataSource = ds1;
                Repeater1.DataBind();
                //script1.RegisterAsyncPostBackControl(Repeater1);
                lbltotalcount.Text = ds1.Tables[0].Rows.Count.ToString();
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
            string flag = "";
            DataSet ds1 = Reporting.GetChequeDetails(CompanyCode, DivisionCode, Zonecode, CenterCode, AcadyearCode, a1, a2, UserID, stream, Chequestatus, txtsbentrycode.Text, txtChequeno.Text, flag);

            if (ds1.Tables[0].Rows.Count > 0)
            {
                Repeater1.PageIndex = e.NewPageIndex;
                Repeater1.DataSource = ds1;
                Repeater1.DataBind();
                //script1.RegisterAsyncPostBackControl(Repeater1);
                lbltotalcount.Text = ds1.Tables[0].Rows.Count.ToString();
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
    protected void Repeater1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
    }
}