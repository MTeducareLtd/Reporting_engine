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

public partial class Rpt_CRM_Centre_FollowUp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DivSearchPanel.Visible = true;
            DivResultPanel.Visible = false;
            BindCampaignDetail();
        }
    }
    private void BindCampaignDetail()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        DataSet ds = Report.GetUser_Role_Campaign(12, UserID, "", "","");

        ddlCampaign.DataSource = ds.Tables[0];
        ddlCampaign.DataTextField = "Campaign_Name";
        ddlCampaign.DataValueField = "Campaign_Id";
        ddlCampaign.DataBind();
        //ddlCampaignNameSearch.Items.Insert(0, "Select");
        ddlCampaign.Items.Insert(0, "Select");
        ddlCampaign.SelectedIndex = 0;

    }
    private void Page_Validation()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        string Path = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
        System.IO.FileInfo Info = new System.IO.FileInfo(Path);
        string pageName = Info.Name;

        int ResultId = 0;

        //ResultId = ProductController.Chk_Page_Validation(pageName, UserID, "DB00");

        //if (ResultId >= 1)
        //{
        //    //Allow
        //}
        //else
        //{
        //    Response.Redirect("~/Homepage.aspx", false);
        //}

    }
    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }
    private void BindListBox(ListBox ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }
    protected void btnexporttoexcel_Click(object sender, EventArgs e)
    {

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        string filenamexls1 = "Centre Follow Up Report" + DateTime.Now + ".xls";
        Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        //sets font
        HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");
        HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='8'>Centre Follow Up Report</TD></TR>");
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
    //protected void BtnSearch_Click(object sender, System.EventArgs e)
    //{



    //    string a1 = null;
    //    string a2 = null;
    //    string DateRange = null;
    //    if (string.IsNullOrEmpty(id_date_range_picker_1.Value))
    //    {
    //        DateRange = "%";
    //    }
    //    else
    //    {
    //        DateTime fromdate, todate;
    //        fromdate = Convert.ToDateTime(DateRange.Substring(0, 10));
    //        todate = Convert.ToDateTime(DateRange.Substring(DateRange.Length - 10));

    //        a1 = fromdate.ToString("dd MMM yyyy");
    //        a2 = todate.ToString("dd MMM yyyy");
    //    }



    //    DataSet ds1 = Reporting.GetCentreCallingReport(2, ddlCampaign.SelectedValue, a1, a2);
    //    if (ds1.Tables[0].Rows.Count > 0 && ds1 != null)
    //    {
    //        Repeater1.DataSource = ds1;
    //        Repeater1.DataBind();
    //        //script1.RegisterAsyncPostBackControl(Repeater1);
    //        lbltotalcount.Text = ds1.Tables[0].Rows.Count.ToString();
    //        Msg_Error.Visible = false;
    //        DivSearchPanel.Visible = false;
    //        DivResultPanel.Visible = true;

    //        //Session["DivisionCode"] = DivisionCode;
    //        //Session["Zonecode"] = Zonecode;
    //        //Session["CenterCode"] = CenterCode;
    //        //Session["Acadyear"] = Acadyear;

    //    }


    //    else
    //    {
    //        Msg_Error.Visible = true;
    //        lblerror.Visible = true;
    //        lblerror.Text = " Record Not Found.";
    //    }
    //}
    protected void BtnSearch_Click(object sender, System.EventArgs e)
    {

        string DateRange = "";
        DateRange = id_date_range_picker_1.Value;

        if (DateRange.Length != 0)
        {

            DateTime fromdate, todate;
            fromdate = Convert.ToDateTime(DateRange.Substring(0, 10));
            todate = Convert.ToDateTime(DateRange.Substring(DateRange.Length - 10));

            string a1 = fromdate.ToString("dd MMM yyyy");
            string a2 = todate.ToString("dd MMM yyyy");




            DataSet ds1 = Reporting.GetCentreCallingReport(2, ddlCampaign.SelectedValue, a1, a2);
            if (ds1.Tables[0].Rows.Count > 0 && ds1 != null)
            {
                Repeater1.DataSource = ds1;
                Repeater1.DataBind();
                //script1.RegisterAsyncPostBackControl(Repeater1);
                lbltotalcount.Text = ds1.Tables[0].Rows.Count.ToString();
                Msg_Error.Visible = false;
                DivSearchPanel.Visible = false;
                DivResultPanel.Visible = true;

                //Session["DivisionCode"] = DivisionCode;
                //Session["Zonecode"] = Zonecode;
                //Session["CenterCode"] = CenterCode;
                //Session["Acadyear"] = Acadyear;

            }


            else
            {
                Msg_Error.Visible = true;
                lblerror.Visible = true;
                lblerror.Text = " Record Not Found.";
            }

        }
        else
        {
            string a1 = "";
            string a2 = "";

            DataSet ds1 = Reporting.GetCentreCallingReport(2, ddlCampaign.SelectedValue, a1, a2);
            if (ds1.Tables[0].Rows.Count > 0 && ds1 != null)
            {
                Repeater1.DataSource = ds1;
                Repeater1.DataBind();
                //script1.RegisterAsyncPostBackControl(Repeater1);
                lbltotalcount.Text = ds1.Tables[0].Rows.Count.ToString();
                Msg_Error.Visible = false;
                DivSearchPanel.Visible = false;
                DivResultPanel.Visible = true;

                //Session["DivisionCode"] = DivisionCode;
                //Session["Zonecode"] = Zonecode;
                //Session["CenterCode"] = CenterCode;
                //Session["Acadyear"] = Acadyear;

            }


            else
            {
                Msg_Error.Visible = true;
                lblerror.Visible = true;
                lblerror.Text = " Record Not Found.";
            }

        }

    }
    protected void Back_Click(object sender, EventArgs e)
    {
        //Response.Redirect("RptAdmissionCount.aspx");
        //DivSearchPanel.Visible = true;
        DivSearchPanel.Visible = true;
        DivResultPanel.Visible = false;
    }
    protected void BtnClearSearch_Click(object sender, EventArgs e)
    {
        ClearSearchPanel();
    }
    private void ClearSearchPanel()
    {
        ddlCampaign.SelectedValue = null;
        id_date_range_picker_1.Value = null;

    }
}