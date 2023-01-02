using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ShoppingCart.BL;
using System.IO;
using System.Web.UI.HtmlControls;

public partial class rpt_Campaign_Summary_Agentwise : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                ddlReportType.SelectedIndex = 2;
                ControlVisibility("Search");
                BindCampaignAcadyear();

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
    }

    private void BindCampaignAcadyear()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GET_CAMPAIGN_ACADYEAR();
        BindDDL(ddlcampaignacadyear, ds, "Acadyear", "Acadyearvalue");
        ddlcampaignacadyear.Items.Insert(0, "Select");
        ddlcampaignacadyear.SelectedIndex = 0;
    }

    protected void ddlReportType_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        if (ddlReportType.SelectedValue == "OverAll")
        {
            Response.Redirect("Campaign_Summary.aspx");
        }
        else if (ddlReportType.SelectedValue == "Institutewise")
        {
            Response.Redirect("Campaign_Summary_Institutewise.aspx");
        }
        else if (ddlReportType.SelectedValue == "Agentwise")
        {
            Response.Redirect("rpt_Campaign_Summary_Agentwise.aspx");
        }
    }

    protected void ddlcampaignacadyear_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindCampaignDetail();

        if (ddlcampaignacadyear.SelectedIndex != 0)
        {
            FillDDL_Agent();
        }
        else
        {
            ddlAgent.Items.Clear();
        }
    }

    private void BindCampaignDetail()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = Report.GetUser_Role_Campaign(14, UserID, "", "", ddlcampaignacadyear.SelectedValue);
        ddlCampaignname.DataSource = ds.Tables[0];
        ddlCampaignname.DataTextField = "Campaign_Name";
        ddlCampaignname.DataValueField = "Campaign_Id";
        ddlCampaignname.DataBind();
        ddlCampaignname.Items.Insert(0, "");
        ddlCampaignname.Items.Insert(1, "All");
        //ddlCampaignname.SelectedIndex = 0;
    }


    private void FillDDL_FRSearch_Centre()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
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

    /// <summary>
    /// Clear Error Success Box
    /// </summary>
    private void Clear_Error_Success_Box()
    {
        Msg_Error.Visible = false;
        Msg_Success.Visible = false;
        lblSuccess.Text = "";
        lblerror.Text = "";
        UpdatePanelMsgBox.Update();
    }

    private void ControlVisibility(string Mode)
    {
        if (Mode == "Search")
        {
            DivSearchPanel.Visible = true;
            DivResultPanel.Visible = false;
            BtnShowSearchPanel.Visible = false;
        }
        else if (Mode == "Result")
        {
            DivSearchPanel.Visible = false;
            DivResultPanel.Visible = true;
            btnCampaignDetail_Back.Visible = false;
            lblTotalName.Visible = true;
            lbltotalcount.Visible = true;
            dlGridDisplay.Visible = true;
            BtnShowSearchPanel.Visible = true;
        }
        
    }


    private void Show_Error_Success_Box(string BoxType, string Error_Code)
    {
        if (BoxType == "E")
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ProductController.Raise_Error(Error_Code);
            UpdatePanelMsgBox.Update();
        }
        else
        {
            Msg_Success.Visible = true;
            Msg_Error.Visible = false;
            lblSuccess.Text = ProductController.Raise_Error(Error_Code);
            UpdatePanelMsgBox.Update();
        }
    }

    private void ClearSearchPanel()
    {
        ddlcampaignacadyear.SelectedIndex = 0;
        ddlCampaignname.Items.Clear();
        ddlAgent.Items.Clear();
    }

    private void FillDDL_Agent()
    {
        try
        {
            Clear_Error_Success_Box();
            string UserID = null;
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            UserID = cookie.Values["UserID"];
            List<string> list = new List<string>();

            string Camapign_id = "";
            foreach (ListItem li in ddlCampaignname.Items)
            {
                if (li.Selected == true)
                {
                    list.Add(li.Value);
                    Camapign_id = string.Join(",", list.ToArray());
                }
            }

            DataSet ds = null;

            ds = ProductController.GET_CAMPAIGN_User_List(1, UserID, ddlcampaignacadyear.SelectedValue, Camapign_id);
            ddlAgent.DataSource = ds.Tables[0];
            ddlAgent.DataTextField = "UserName";
            ddlAgent.DataValueField = "UserCode";
            ddlAgent.DataBind();
            //ddlAgent.Items.Insert(0, "");
            ddlAgent.Items.Insert(0, "All");
        }
        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblSuccess.Text = "";
            lblerror.Text = ex.ToString();
            UpdatePanelMsgBox.Update();
        }
    }


    

    private void FillGrid()
    {
        try
        {
            Clear_Error_Success_Box();
            string UserID = null;
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            UserID = cookie.Values["UserID"];
            List<string> list = new List<string>();
            List<string> list1 = new List<string>();

            string Camapign_id = "", AgentId = "";
            foreach (ListItem li in ddlCampaignname.Items)
            {
                if (li.Selected == true)
                {
                    list.Add(li.Value);
                    Camapign_id = string.Join(",", list.ToArray());
                }
            }


            foreach (ListItem li in ddlAgent.Items)
            {
                if (li.Selected == true)
                {
                    list1.Add(li.Value);
                    AgentId = string.Join(",", list1.ToArray());
                }
            }
            
            DataSet ds = null;
            try
            {
                ds = ProductController.GET_CAMPAIGN_SUMMARY_Agentwise(1, UserID, ddlcampaignacadyear.SelectedValue, Camapign_id, AgentId);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dlGridDisplay.DataSource = ds;
                    dlGridDisplay.DataBind();                   
                    ControlVisibility("Result");
                }
                else
                {
                    Msg_Error.Visible = true;
                    Msg_Success.Visible = false;
                    lblSuccess.Text = "";
                    lblerror.Text = "Records not found...!";
                    UpdatePanelMsgBox.Update();
                }
            }
            catch (Exception ex)
            {
                Msg_Error.Visible = true;
                Msg_Success.Visible = false;
                lblSuccess.Text = "";
                lblerror.Text = ex.ToString();
                UpdatePanelMsgBox.Update();
            }
            if (ds != null)
            {
                if (ds.Tables.Count != 0)
                {
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        lbltotalcount.Text = (ds.Tables[0].Rows.Count).ToString();
                    }
                    else
                    {
                        lbltotalcount.Text = "0";
                    }
                }
                else
                {
                    lbltotalcount.Text = "0";
                }
            }
            else
            {
                lbltotalcount.Text = "0";
            }

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

    protected void btnCampaignDetail_Back_ServerClick(object sender, System.EventArgs e)
    {
        Clear_Error_Success_Box();
        ControlVisibility("Result");
    }

    protected void ddlCampaignname_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        if (ddlcampaignacadyear.SelectedIndex != 0)
        {
            FillDDL_Agent();
        }
        else
        {
            ddlAgent.Items.Clear();
        }
    }


    protected void BtnShowSearchPanel_Click(object sender, EventArgs e)
    {
        ControlVisibility("Search");
        Clear_Error_Success_Box();
    }

    protected void BtnCloseAdd_Click(object sender, EventArgs e)
    {
        ControlVisibility("Search");
        Clear_Error_Success_Box();
    }




    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();
            if (ddlcampaignacadyear.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Campaign Academic year");
                return;
            }
            

            FillGrid();
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

    protected void BtnClearSearch_Click(object sender, EventArgs e)
    {
        ClearSearchPanel();
    }




    protected void HLExport_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        string filenamexls1 = "Campaign_Summary_Agentwise_" + DateTime.Now + ".xls";
        
        Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        //sets font
        HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");
        HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='9'>Campaign Summary Agentwise</TD></TR>");
        Response.Charset = "";
        this.EnableViewState = false;
        System.IO.StringWriter oStringWriter1 = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter oHtmlTextWriter1 = new System.Web.UI.HtmlTextWriter(oStringWriter1);
       
        dlGridDisplay.RenderControl(oHtmlTextWriter1);

        Response.Write(oStringWriter1.ToString());
        Response.Flush();
        Response.End();
    }

    

}