using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ShoppingCart.BL;

public partial class Rpt_Student_WiseCount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
           
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
        private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }
    protected void ddldivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindCenter();
    }
    private void BindCenter()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];


        DataSet ds = Reporting.Get_Center_ByDivision(3, UserID, ddldivision.SelectedValue);
        BindListBox(ddlcenter, ds, "Center_name", "Center_Code");
        ddlcenter.Items.Insert(0, "");
    }
    
    private void BindDivision()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = Reporting.GetUser_Company_Division_Zone_Center(2, UserID, "", "","MT");
        BindDDL(ddldivision, ds, "Division_Name", "Division_Code");
        ddldivision.Items.Insert(0, "Select");
        ddldivision.SelectedIndex = 0;
    }
    private void BindListBox(ListBox ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }
     
    protected void BtnSearch_Click(object sender, System.EventArgs e)
    {


        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
       
        string DivisionCode = ddldivision.SelectedValue;
      


        //Zone Comma Separated
        List<string> list = new List<string>();
        List<string> List1 = new List<string>();
        List<string> List2 = new List<string>();
        List<string> List3 = new List<string>();

        string CenterCode = "";
        foreach (ListItem li in ddlcenter.Items)
        {
            if (li.Selected == true)
            {
                list.Add(li.Value);
                CenterCode = string.Join(",", list.ToArray());
            }
        }
        string Center_Code = CenterCode;
        
        string DateRange = "";
        string FromDate, ToDate;
        DateRange = id_date_range_picker_1.Value;

     

            if (id_date_range_picker_1.Value == "")
            {
                FromDate = "";
                ToDate = "";
            }
            else
            {
            

                FromDate = DateRange.Substring(0, 10);
                ToDate = (DateRange.Length > 9) ? DateRange.Substring(DateRange.Length - 10, 10) : DateRange;
            }



            DataSet ds1 = Reporting.GetStudentWise_Count_Details(DivisionCode, Center_Code, FromDate, ToDate);

            if (ds1.Tables[0].Rows.Count > 1 && ds1 != null)
            {
                
                dlStudentStatus.DataSource = ds1;
                dlStudentStatus.DataBind();
                //script1.RegisterAsyncPostBackControl(Repeater1);
                lbltotalcount.Text = ds1.Tables[0].Rows.Count.ToString();
                Msg_Error.Visible = false;
                DivSearchPanel.Visible = false;
                DivResultPanel.Visible = true;
                BtnShowSearchPanel.Visible = true;

            }

            else
            {
                Msg_Error.Visible = true;
                lblerror.Visible = true;
                lblerror.Text = "No Record Found. Kindly Re-Select your search criteria";

            }
       
   
    }
    protected void BtnClearSearch_Click(object sender, EventArgs e)
    {
        ClearSearchPanel();
    }

    private void ClearSearchPanel()
    {
        ddldivision.SelectedIndex = 0;

        ddlcenter.Items.Clear();
        ddlcenter.Items.Insert(0, "");
        ddlcenter.SelectedIndex = 0;
       
        id_date_range_picker_1.Value = "";
        //ddlBatch.Items.Clear();
    }
    protected void BtnShowSearchPanel_Click(object sender, EventArgs e)
    {
        Msg_Error.Visible = false;
        DivResultPanel.Visible = false;
        BtnShowSearchPanel.Visible = false;
        DivSearchPanel.Visible = true;
    }
    protected void HLExport_Click(object sender, EventArgs e)
    {


        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        string filenamexls1 = "Cheque_StudentWiseCount" + DateTime.Now + ".xls";
        Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        //sets font
        HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");
        HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='4'>Report Cheque and StudentWise Count </b></TD></TR>");
        Response.Charset = "";
        this.EnableViewState = false;
        System.IO.StringWriter oStringWriter1 = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter oHtmlTextWriter1 = new System.Web.UI.HtmlTextWriter(oStringWriter1);
        //this.ClearControls(dladmissioncount)
        dlStudentStatus.RenderControl(oHtmlTextWriter1);
        Response.Write(oStringWriter1.ToString());
        Response.Flush();
        Response.End();


    }
}