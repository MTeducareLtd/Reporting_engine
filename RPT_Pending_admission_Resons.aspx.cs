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

public partial class RPT_Pending_admission_Resons : System.Web.UI.Page
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
                BindDivision();



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

    //private void FillDDL_Company()
    //{
    //    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
    //    string UserID = cookie.Values["UserID"];
    //    string UserName = cookie.Values["UserName"];
    //    DataSet dscompany = Reporting.GetUser_Company_Division_Zone_Center(1, UserID, "", "", "");
    //    BindDDL(ddlcompany, dscompany, "Company_Name", "Company_Code");
    //    ddlcompany.Items.Insert(0, "Select");
    //    ddlcompany.SelectedIndex = 0;
    //    MT
    //}

    //protected void ddlcompany_SelectedIndexChanged(object sender, System.EventArgs e)
    //{
    //    BindDivision();
    //}

    private void BindDivision()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = Reporting.GetUser_Company_Division_Zone_Center(2, UserID, "", "", "MT");
        BindDDL(ddldivision, ds, "Division_Name", "Division_Code");
        ddldivision.Items.Insert(0, "Select");
        ddldivision.SelectedIndex = 0;
    }

    protected void ddldivision_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        Clear_Error_Success_Box();
        if (ddldivision.SelectedItem.ToString() == "Select")
        {
            ddlcenter.Items.Clear();
            ddldivision.Focus();
            return;
        }
        BindCenter();
    }
    private void Clear_Error_Success_Box()
    {
        Msg_Error.Visible = false;
        Msg_Success.Visible = false;
        lblSuccess.Text = "";
        lblerror.Text = "";
        UpdatePanelMsgBox.Update();
    }

    //private void BindZone()
    //{
    //    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
    //    string UserID = cookie.Values["UserID"];
    //    string UserName = cookie.Values["UserName"];
    //    DataSet ds = Reporting.GetUser_Company_Division_Zone_Center(3, UserID, ddldivision.SelectedValue, "", "MT");
    //    BindListBox(ddlzone, ds, "Zone_Name", "Zone_Code");
    //    ddlzone.Items.Insert(0, "All");
    //}

    //protected void ddlzone_SelectedIndexChanged(object sender, System.EventArgs e)
    //{

    //    int count = ddlzone.GetSelectedIndices().Length;

    //    if (ddlzone.SelectedValue == "All")
    //    {
    //        ddlzone.Items.Clear();
    //        ddlzone.Items.Insert(0, "All");
    //        ddlzone.SelectedIndex = 0;
    //        BindCenter();
    //    }
    //    else if (count == 0)
    //    {
    //        BindZone();
    //        //BindCenter();
    //    }
    //    else
    //    {

    //        BindCenter();
    //    }

    //}

    private void BindCenter()
    {
        try
        {
            string CreatedBy = null;
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            CreatedBy = cookie.Values["UserID"];

            string Div_Code = null;
            Div_Code = ddldivision.SelectedValue;

            DataSet dsCentre = ProductController.GetAllActiveUser_Company_Division_Zone_Center(CreatedBy, "MT", Div_Code, "", "5", "CDB");
            BindListBox(ddlcenter, dsCentre, "Center_Name", "Center_Code");
            ddlcenter.Items.Insert(0, "Select");
            ddlcenter.Items.Insert(1, "All");
            ddlcenter.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
            UpdatePanelMsgBox.Update();
            return;
        }
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
        ddlacademicyear.Items.Insert(0, "Select");
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
            //BindStream();
        }
        else if (count == 0)
        {

            BindAcademicYear();
            //BindCenter();
        }
        else
        {
            //BindStream();
        }



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

    //    string AcadYear = "";
    //    foreach (ListItem li in ddlacademicyear.Items)
    //    {
    //        if (li.Selected == true)
    //        {
    //            List2.Add(li.Value);
    //            AcadYear = string.Join(",", List2.ToArray());
    //        }
    //    }
    //    string AcadYears = AcadYear;


    //    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
    //    string UserID = cookie.Values["UserID"];
    //    string UserName = cookie.Values["UserName"];
    //    //DataSet ds = Reporting.GetStreamby_Center_AcademicYear_All(ddlcenter.SelectedValue, ddlacademicyear.SelectedValue, ddlcompany.SelectedValue, ddldivision.SelectedValue);
    //    DataSet ds = Reporting.GetStreamby_Center_AcademicYear_All(centers, AcadYears, ddlcompany.SelectedValue, ddldivision.SelectedValue, Zones);

    //    //  BindDDL(ddlstream, ds, "Stream_Sdesc", "Stream_Code");     
    //    BindListBox(ddlstream, ds, "Stream_Sdesc", "Stream_Code");
    //    ddlstream.Items.Insert(0, "All");
    //    //ddlstream.SelectedIndex = 0;
    //}

    protected void BtnSearch_Click(object sender, System.EventArgs e)
    {
        Msg_Error.Visible = false;

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string CompanyCode = "MT";
        string DivisionCode = ddldivision.SelectedValue;

        if (ddlacademicyear.SelectedValue == "Select")
        {
            Msg_Error.Visible = true;
            lblerror.Visible = true;
            lblerror.Text = "Kindly Select Acad Year";
            return;
        }


        //Zone Comma Separated
        List<string> list = new List<string>();
        List<string> List1 = new List<string>();
        List<string> List2 = new List<string>();
        List<string> List3 = new List<string>();
        List<string> List4 = new List<string>();
        List<string> List5 = new List<string>();

        //string Zone = "";
        //foreach (ListItem li in ddlzone.Items)
        //{
        //    if (li.Selected == true)
        //    {
        //        list.Add(li.Value);
        //        Zone = string.Join(",", list.ToArray());
        //    }
        //}
        //string Zonecode = Zone;
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
        //string Reporttype = "01";
        //string Flag = "1";
        //string Flag2 = "2";
        //ECSStatusID = ddlAcknowledgementstatus.SelectedValue;

        // DataSet ds1 = Reporting.GetCollectionCount(Reporttype, Flag2, CompanyCode, DivisionCode, Zonecode, CenterCode, AcadyearCode, UserID, stream);
        DataSet ds1 = Reporting.Getpendingadmission_Detail(UserID, CompanyCode, DivisionCode, "", Center, AcadyearCode);


        if (ds1.Tables[0].Rows.Count > 0)
        {
            Repeater1.DataSource = ds1;
            Repeater1.DataBind();
            //script1.RegisterAsyncPostBackControl(Repeater1);
            lbltotalcount.Text = ds1.Tables[0].Rows.Count.ToString();
            Msg_Error.Visible = false;
            DivSearchPanel.Visible = false;
            DivResultPanel.Visible = true;
            //Session["s_paymentdetails"] = ds1;

        }

        else
        {
            Msg_Error.Visible = true;
            lblerror.Visible = true;
            lblerror.Text = "No Record Found. Kindly Re-Select your search criteria";


        }

    }

    protected void btnexporttoexcel_Click(object sender, System.EventArgs e)
    {

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        string filenamexls1 = "PendingAdmission_" + DateTime.Now + ".xls";
        Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        //sets font
        HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");
        HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri;text-decoration-color: White; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='10'>Pending Admission Report </TD></TR>");
        Response.Charset = "";
        this.EnableViewState = false;
        System.IO.StringWriter oStringWriter1 = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter oHtmlTextWriter1 = new System.Web.UI.HtmlTextWriter(oStringWriter1);
        //this.ClearControls(dladmissioncount);
        Repeater1.RenderControl(oHtmlTextWriter1);
        Response.Write(oStringWriter1.ToString());
        Response.Flush();
        Response.End();


    }




    public override void VerifyRenderingInServerForm(Control control)
    {
    }

    protected void BtnClearSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("RPT_Pending_admission_Resons.aspx");
    }
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

    }

    protected void Back_Click(object sender, EventArgs e)
    {
        //Response.Redirect("Rpt_PaymentDetails1.aspx");
        DivSearchPanel.Visible = true;
        DivResultPanel.Visible = false;
    }
    
    
}