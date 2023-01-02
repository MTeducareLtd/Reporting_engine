using System;
using ShoppingCart.BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RFID_Detail : System.Web.UI.Page
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
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

    }


    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
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

    protected void ddlcompany_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindDivision();
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
        //DataSet ds = Reporting.GetStreamby_Center_AcademicYear_All(ddlcenter.SelectedValue, ddlacademicyear.SelectedValue, ddlcompany .SelectedValue , ddldivision .SelectedValue );
        DataSet ds = Reporting.GetStreamby_Center_AcademicYear_All(centers, AcadYears, ddlcompany.SelectedValue, ddldivision.SelectedValue, Zones);
        //  BindDDL(ddlstream, ds, "Stream_Sdesc", "Stream_Code");     
        BindListBox(ddlstream, ds, "Stream_Sdesc", "Stream_Code");
        ddlstream.Items.Insert(0, "All");
        ddlstream.SelectedIndex = 0;
    }

    private void BindListBox(ListBox ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }
    protected void BtnClear_Click(object sender, System.EventArgs e)
    {
        ddlacademicyear.Items.Clear();
        //ddlcenter.SelectedIndex = 0;
        ddldivision.SelectedIndex = 0;
        ddlcenter.Items.Clear();
        ddlstream.Items.Clear();
        ddlzone.Items.Clear();
        //ddlCenter.Items.Insert(0, "Select");
        //ddlCenter.SelectedIndex = 0;

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

        string Stream = "";
        foreach (ListItem li3 in ddlstream.Items)
        {
            if (li3.Selected == true)
            {
                List3.Add(li3.Value);
                Stream = string.Join(",", List3.ToArray());
            }
        }


        string AcadyearCode = Acadyear;

        DataSet ds1 = Reporting.GetStudentRFIDDetails("1", DivisionCode, Zonecode, CenterCode, Acadyear, Stream, UserID);

        if (ds1.Tables[0].Rows.Count > 0)
        {
            lbltotalcount.Text = ds1.Tables[0].Rows.Count.ToString();
            Msg_Error.Visible = false;
            DivSearchPanel.Visible = false;
            DivResultPanel.Visible = true;
            dlstudentdata.DataSource = ds1.Tables[0];
            dlstudentdata.DataBind();
        }
    }

    protected void ddlstream_SelectedIndexChanged(object sender, EventArgs e)
    {


    }
    protected void btnexporttoexcel_Click(object sender, EventArgs e)
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

        string Stream = "";
        foreach (ListItem li3 in ddlstream.Items)
        {
            if (li3.Selected == true)
            {
                List3.Add(li3.Value);
                Stream = string.Join(",", List3.ToArray());
            }
        }


        DataSet ds1 = Reporting.GetStudentRFIDDetails("1", DivisionCode, Zonecode, CenterCode, Acadyear, Stream, UserID);


        if (ds1.Tables[0].Rows.Count > 0)
        {
            GridView GridView1 = new GridView();
            GridView1.DataSource = ds1.Tables[0];
            GridView1.DataBind();

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=Student_RFID_Data" + DateTime.Now + ".xls");
            Response.ContentType = "application/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            GridView1.RenderControl(htw);
            string style = @"<style> td { mso-number-format:\@;} </style>";
            Response.Write(style);
            Response.Write(sw.ToString());
            Response.End();


        }

        //Response.Clear();
        //Response.Buffer = true;
        //Response.ContentType = "application/vnd.ms-excel";
        //string filenamexls1 = "AdmissionCountRpt_" + DateTime.Now + ".xls";
        //Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
        //HttpContext.Current.Response.Charset = "utf-8";
        //HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        ////sets font
        //HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
        //HttpContext.Current.Response.Write("<BR><BR><BR>");
        //HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='8'>Admission Count Report (Pending V/s Confirm)</TD></TR>");
        //Response.Charset = "";
        //this.EnableViewState = false;
        //System.IO.StringWriter oStringWriter1 = new System.IO.StringWriter();
        //System.Web.UI.HtmlTextWriter oHtmlTextWriter1 = new System.Web.UI.HtmlTextWriter(oStringWriter1);
        ////this.ClearControls(dladmissioncount);
        //string style = @"<style> .textmode { mso-number-format:\@; } </style>";
        //Response.ContentType = "application/text";
        //dlstudentdata.RenderControl(oHtmlTextWriter1);
        //Response.Write(oStringWriter1.ToString());
        //Response.Flush();
        //Response.End();


    }
    protected void Back_Click(object sender, EventArgs e)
    {
        DivSearchPanel.Visible = true;
        DivResultPanel.Visible = false;
    }
}