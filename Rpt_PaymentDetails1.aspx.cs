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


public partial class Rpt_PaymentDetails1 : System.Web.UI.Page
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
                BindPayPlan();
                BindStatus();
                
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }
    }


    private void BindPayPlan()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = Reporting.GetAllPayPlan();
        BindListBox(ddlpayplan, ds, "Pay_Plan_Code", "Pay_Plan_Description");
        ddlpayplan.Items.Insert(0, "All");
       // ddlpayplan.SelectedIndex = 0;

    }

    private void BindStatus()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = Reporting.GetStatus();
        BindListBox(ddlstatus, ds, "Account_Status_Name", "Account_Status_ID");
        ddlstatus.Items.Insert(0, "All");
       // ddlstatus.SelectedIndex = 0;

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
            }
        }

        string Zone = Sgrcode;
        DataSet ds = Reporting.GetUser_Company_Division_Zone_Center(4, UserID, ddldivision.SelectedValue, Zone, ddlcompany.SelectedValue);
        BindListBox(ddlcenter, ds, "Center_name", "Center_Code");
        ddlcenter.Items.Insert(0, "All");
        //ddlcenter.SelectedIndex = 0;

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
            
            //BindCenter();
        
    }

    private void BindAcademicYear()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = Reporting.GetAllAcadyear();
        BindListBox(ddlacademicyear, ds, "Acad_Year", "Acad_Year");
        ddlacademicyear.Items.Insert(0, "All");
        //ddlacademicyear.SelectedIndex = 0;
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
        //DataSet ds = Reporting.GetStreamby_Center_AcademicYear_All(ddlcenter.SelectedValue, ddlacademicyear.SelectedValue, ddlcompany.SelectedValue, ddldivision.SelectedValue);
        DataSet ds = Reporting.GetStreamby_Center_AcademicYear_All(centers, AcadYears, ddlcompany.SelectedValue, ddldivision.SelectedValue, Zones);

        //  BindDDL(ddlstream, ds, "Stream_Sdesc", "Stream_Code");     
        BindListBox(ddlstream, ds, "Stream_Sdesc", "Stream_Code");
        ddlstream.Items.Insert(0, "All");
        //ddlstream.SelectedIndex = 0;
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
        List<string> List5 = new List<string>();

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
        string stream = "";   
        foreach (ListItem li3 in ddlstream.Items)
        {
            if (li3.Selected == true)
            {
                List3.Add(li3.Value);
                stream = string.Join(",", List3.ToArray());
            }
            //else
            //{
            //    Msg_Error.Visible = true;
            //    lblerror.Visible = true;
            //    lblerror.Text = " Kindly Select stream";
            //    return;
            //}
        }

        string payplan = "";
        foreach (ListItem lpayplan in ddlpayplan.Items)
        {
            if (lpayplan.Selected == true)
            {
                List4.Add(lpayplan.Value);
                payplan = string.Join(",", List4.ToArray());
            }
        }

        string Status = "";


        foreach (ListItem lstatus in ddlstatus.Items)
        {
            if (lstatus.Selected == true)
            {
                List5.Add(lstatus.Value);
                Status = string.Join(",", List5.ToArray());
            }
        }



        string AcadyearCode = Acadyear;
        string Reporttype = "01";
        string Flag = "1";
        string Flag2 = "2";


        string fdate = "";
        string tdate = "";


        string DateRange = "";
        DateRange = id_date_range_picker_1.Value;



        DateTime fromdate, todate;

        if (DateRange.Length != 0)
        {
            fromdate = Convert.ToDateTime(DateRange.Substring(0, 10).ToString());
            todate = Convert.ToDateTime(DateRange.Substring(DateRange.Length - 10));
            string a1 = fromdate.ToString("dd MMM yyyy");
            string a2 = todate.ToString("dd MMM yyyy");
            DataSet ds1 = Reporting.GetPaymentDetails(Reporttype, Flag2, CompanyCode, DivisionCode, Zonecode, CenterCode, AcadyearCode, UserID, stream, a1, a2, payplan, Status,txtsbentrycode.Text);
            if (ds1.Tables[0].Rows.Count > 0)
            {
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

            DataSet ds1 = Reporting.GetPaymentDetails(Reporttype, Flag2, CompanyCode, DivisionCode, Zonecode, CenterCode, AcadyearCode, UserID, stream, a1, a2, payplan, Status,txtsbentrycode.Text);
            if (ds1.Tables[0].Rows.Count > 0)
            {
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
        List<string> List5 = new List<string>();

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
        string stream = "";
        foreach (ListItem li3 in ddlstream.Items)
        {
            if (li3.Selected == true)
            {
                List3.Add(li3.Value);
                stream = string.Join(",", List3.ToArray());
            }
        }

        string payplan = "";
        foreach (ListItem lpayplan in ddlpayplan.Items)
        {
            if (lpayplan.Selected == true)
            {
                List4.Add(lpayplan.Value);
                payplan = string.Join(",", List4.ToArray());
            }
        }

        string Status = "";
        foreach (ListItem lstatus in ddlstatus.Items)
        {
            if (lstatus.Selected == true)
            {
                List5.Add(lstatus.Value);
                Status = string.Join(",", List5.ToArray());
            }
        }



        string AcadyearCode = Acadyear;
        string Reporttype = "01";
        string Flag = "1";
        string Flag2 = "2";


        string fdate = "";
        string tdate = "";


        string DateRange = "";
        DateRange = id_date_range_picker_1.Value;



        DateTime fromdate, todate;

        if (DateRange.Length != 0)
        {
            fromdate = Convert.ToDateTime(DateRange.Substring(0, 10).ToString());
            todate = Convert.ToDateTime(DateRange.Substring(DateRange.Length - 10));
            string a1 = fromdate.ToString("dd MMM yyyy");
            string a2 = todate.ToString("dd MMM yyyy");
            DataSet ds1 = Reporting.GetPaymentDetails(Reporttype, Flag2, CompanyCode, DivisionCode, Zonecode, CenterCode, AcadyearCode, UserID, stream, a1, a2, payplan, Status, txtsbentrycode.Text);
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

            DataSet ds1 = Reporting.GetPaymentDetails(Reporttype, Flag2, CompanyCode, DivisionCode, Zonecode, CenterCode, AcadyearCode, UserID, stream, a1, a2, payplan, Status, txtsbentrycode.Text);
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
       


    }


    public void ExportToExcel(DataSet ds)
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Payment_Details.xls"));
        Response.ContentType = "application/ms-excel";


        DataTable dt = ds.Tables[0];
        string str = string.Empty;
        int count = 0;
        foreach (DataColumn dtcol in dt.Columns)
        {


            if (dtcol.ColumnName == "StudentName")
            {

                Response.Write("Payment Details Report");
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

    //public override void VerifyRenderingInServerForm(Control control)
    //{
    //}

    protected void BtnClearSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("Rpt_PaymentDetails1.aspx");
    }
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

    }

    protected void Back_Click(object sender, EventArgs e)
    {
        //Response.Redirect("Rpt_PaymentDetails1.aspx");
        DivSearchPanel.Visible = true;
        DivResult.Visible = true;
    }
    protected void ddlstream_SelectedIndexChanged(object sender, EventArgs e)
    {
        int count = ddlstream.GetSelectedIndices().Length;

        if (ddlstream.SelectedValue == "All")
        {
            ddlstream.Items.Clear();
            ddlstream.Items.Insert(0, "All");
            ddlstream.SelectedIndex = 0;
            BindPayPlan();
        }
        else if (count == 0)
        {
            BindStream();
            //BindCenter();
        }
        else
        {
            BindPayPlan();
        }
    }
    protected void ddlpayplan_SelectedIndexChanged(object sender, EventArgs e)
    {
        int count = ddlpayplan.GetSelectedIndices().Length;

        if (ddlpayplan.SelectedValue == "All")
        {
            ddlpayplan.Items.Clear();
            ddlpayplan.Items.Insert(0, "All");
            ddlpayplan.SelectedIndex = 0;
            BindStatus();
        }
        else if (count == 0)
        {
            BindPayPlan();
            //BindCenter();
        }
        else
        {
            BindStatus();
        }
    }
    protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        int count = ddlstatus.GetSelectedIndices().Length;

        if (ddlstatus.SelectedValue == "All")
        {
            ddlstatus.Items.Clear();
            ddlstatus.Items.Insert(0, "All");
            ddlstatus.SelectedIndex = 0;
            //BindStatus();
        }
        else if (count == 0)
        {
            BindStatus();
            //BindCenter();
        }
        else
        {
            //BindStatus();
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
        List<string> List5 = new List<string>();

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
        string stream = "";
        foreach (ListItem li3 in ddlstream.Items)
        {
            if (li3.Selected == true)
            {
                List3.Add(li3.Value);
                stream = string.Join(",", List3.ToArray());
            }
        }

        string payplan = "";
        foreach (ListItem lpayplan in ddlpayplan.Items)
        {
            if (lpayplan.Selected == true)
            {
                List4.Add(lpayplan.Value);
                payplan = string.Join(",", List4.ToArray());
            }
        }

        string Status = "";
        foreach (ListItem lstatus in ddlstatus.Items)
        {
            if (lstatus.Selected == true)
            {
                List5.Add(lstatus.Value);
                Status = string.Join(",", List5.ToArray());
            }
        }



        string AcadyearCode = Acadyear;
        string Reporttype = "01";
        string Flag = "1";
        string Flag2 = "2";


        string fdate = "";
        string tdate = "";


        string DateRange = "";
        DateRange = id_date_range_picker_1.Value;



        DateTime fromdate, todate;

        if (DateRange.Length != 0)
        {
            fromdate = Convert.ToDateTime(DateRange.Substring(0, 10).ToString());
            todate = Convert.ToDateTime(DateRange.Substring(DateRange.Length - 10));
            string a1 = fromdate.ToString("dd MMM yyyy");
            string a2 = todate.ToString("dd MMM yyyy");
            DataSet ds1 = Reporting.GetPaymentDetails(Reporttype, Flag2, CompanyCode, DivisionCode, Zonecode, CenterCode, AcadyearCode, UserID, stream, a1, a2, payplan, Status, txtsbentrycode.Text);
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

            DataSet ds1 = Reporting.GetPaymentDetails(Reporttype, Flag2, CompanyCode, DivisionCode, Zonecode, CenterCode, AcadyearCode, UserID, stream, a1, a2, payplan, Status, txtsbentrycode.Text);
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
}