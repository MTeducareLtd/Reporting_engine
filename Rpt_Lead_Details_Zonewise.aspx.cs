using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
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

public partial class Rpt_Lead_Details_Zonewise : System.Web.UI.Page
{

    string FromDate = "", ToDate = "";
    protected void Page_Load(object sender, EventArgs e)
    {
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
    private void BindListBox(ListBox ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }
    protected void ddlcompany_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        ddldivision.Items.Clear();
        ddlzone.Items.Clear();
        BindDivision();
        ddldivision.ClearSelection();
        ddlzone.ClearSelection();
        id_date_range_picker_1.Value = "";

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

    protected void ddldivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindZone();
        id_date_range_picker_1.Value = "";
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
    protected void BtnSearch_Click(object sender, EventArgs e)
    {

        DivResultPanel.Visible = true;
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



        if (id_date_range_picker_1.Value == "")
        {
            FromDate = "";
            ToDate = "";
        }
        else
        {
            string DateRange = "";
            DateRange = id_date_range_picker_1.Value;
            FromDate = DateRange.Substring(0, 10);
            ToDate = (DateRange.Length > 9) ? DateRange.Substring(DateRange.Length - 10, 10) : DateRange;
        }
        DataSet ds1 = Reporting.GET_LEAD_DETAILS_ZONEWISE(Zonecode, DivisionCode, FromDate, ToDate);
        if (ds1.Tables[0].Rows.Count > 0 && ds1 != null)
        {

            Repeater1.DataSource = ds1;
            Repeater1.DataBind();
            Repeater2.DataSource = ds1;
            Repeater2.DataBind();
            //script1.RegisterAsyncPostBackControl(Repeater1);
            lbltotalcount.Text = ds1.Tables[0].Rows.Count.ToString();
            int a = Convert.ToInt32(lbltotalcount.Text);
            int b = a - 1;
            lbltotalcount.Text = b.ToString();
            Msg_Error.Visible = false;
            DivSearchPanel.Visible = false;
            DivResultPanel.Visible = true;

        }

        else
        {
            Msg_Error.Visible = true;
            lblerror.Visible = true;
            lblerror.Text = "No Record Found. Kindly Re-Select your search criteria";
            DivResultPanel.Visible = false;
        }

    }

    protected void BtnClearSearch_Click(object sender, EventArgs e)
    {
        ddlcompany.ClearSelection();
        ddldivision.Items.Clear();
        ddlzone.Items.Clear();
        id_date_range_picker_1.Value = "";
    }
    protected void ddlzone_SelectedIndexChanged(object sender, EventArgs e)
    {
        id_date_range_picker_1.Value = "";
    }
    protected void btnEmail_Click(object sender, EventArgs e)
    {

    }
    protected void Back_Click(object sender, EventArgs e)
    {

        DivResultPanel.Visible = false;
        DivSearchPanel.Visible = true;
    }
    protected void btnexporttoexcel_Click(object sender, EventArgs e)
    {
        Repeater2.Visible = true;
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        string filenamexls1 = "Lead Details Zone Wise" + ' ' + DateTime.Now + ".xls";
        Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        //sets font
        HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");
        HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='9'>Lead Details Zone Wise</TD></TR>");
        Response.Charset = "";
        this.EnableViewState = false;
        System.IO.StringWriter oStringWriter1 = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter oHtmlTextWriter1 = new System.Web.UI.HtmlTextWriter(oStringWriter1);
        //this.ClearControls(dladmissioncount);
        Repeater2.RenderControl(oHtmlTextWriter1);
        Response.Write(oStringWriter1.ToString());
        Response.Flush();
        Response.End();
        Repeater2.Visible = false;
    }


    protected void Repeater1_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "com_edit")
        {
            string a = e.CommandArgument.ToString();
            string[] tmp = a.Split('%');

            string Zone_code1 = tmp[0];
            string Division_code1 = tmp[1];
            if (id_date_range_picker_1.Value == "")
            {
                FromDate = "";
                ToDate = "";
            }
            else
            {
                string DateRange = "";
                DateRange = id_date_range_picker_1.Value;
                FromDate = DateRange.Substring(0, 10);
                ToDate = (DateRange.Length > 9) ? DateRange.Substring(DateRange.Length - 10, 10) : DateRange;
            }

            var Url = "Rpt_Lead_DetailsZone_Centerwise.aspx?Zone=" + Server.UrlEncode(Zone_code1) + "&Division=" + Server.UrlEncode(Division_code1) + "&From=" + Server.UrlEncode(FromDate) + "&To=" + Server.UrlEncode(ToDate);
            Response.Redirect(Url);
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "open_window",
            //string.Format("void(window.open('{0}', 'child_window'));", "Rpt_Lead_DetailsZone_Centerwise.aspx?Zone=" + Server.UrlEncode(Zone_code1) + "&Division=" + Server.UrlEncode(Division_code1) + "&From=" + Server.UrlEncode(FromDate) + "&To=" + Server.UrlEncode(ToDate)), true);



        }
    }
}
  
