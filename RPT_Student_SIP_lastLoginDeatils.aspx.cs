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

public partial class RPT_Student_SIP_lastLoginDeatils : System.Web.UI.Page
{

    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                ControlVisibility("Search");
                BindDivision();
                FillDDL_Course();
                BindAcademicYear();
                //BindCampaignDetail();


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
    #endregion

    #region Methods

    private void BindDivision()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = Reporting.GetUser_Company_Division_Zone_Center(2, UserID, "", "", "MT");
        BindDDL(ddlDivision, ds, "Division_Name", "Division_Code");
        ddlDivision.Items.Insert(0, "Select");
        ddlDivision.SelectedIndex = 0;
        ddlCenter.Items.Insert(0, "Select");
        ddlCenter.SelectedIndex = 0;
        //ddlLMSProduct.Items.Insert(0, "Select");
        //ddlLMSProduct.SelectedIndex = 0;
    }


    /// <summary>
    /// Fill Course dropdownlist 
    /// </summary>
    private void FillDDL_Course()
    {

        try
        {

            Clear_Error_Success_Box();

            DataSet dsAllStandard = ProductController.GetAllActive_AllStandard("");
            BindDDL(ddlStandard, dsAllStandard, "Standard_Name", "Standard_Code");
            ddlStandard.Items.Insert(0, "Select");
            ddlStandard.SelectedIndex = 0;

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


    private void BindAcademicYear()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = Reporting.GetAllAcadyear();
        BindDDL(ddlAcadYear, ds, "Acad_Year", "Acad_Year");
        ddlAcadYear.Items.Insert(0, "Select");
        ddlAcadYear.SelectedIndex = 0;
    }
    private void FillDDL_FRSearch_Centre()
    {
        string Company_Code = "MT";
        string DBname = "CDB";

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        DataSet dsCentre = ProductController.GetAllActiveUser_Company_Division_Zone_Center(UserID, Company_Code, ddlDivision.SelectedValue, "", "5", DBname);

        BindListBox(ddlCenter, dsCentre, "Center_Name", "Center_Code");
        ddlCenter.Items.Insert(0, "Select");
        //ddlCenter.Items.Insert(1, "All");
        ddlCenter.SelectedIndex = 0;
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







    //private void Clear_TempChallan()
    //{
    //    string ResultId;
    //    ResultId = ProductController.usp_ClearIncInward(13);
    //}

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
            //DivAddPanel.Visible = false;
            DivSearchPanel.Visible = true;
            //BtnAdd.Visible = true;
            //BtnSaveAdd.Visible = true;
            // BtnSaveEdit.Visible = false;
            DivResultPanel.Visible = false;
            //DivAddBarcode.Visible = false;
            //DivAuthorise.Visible = false;
            //RadioButton1.Checked = false;
            //RadioButton2.Checked = false;

        }
        else if (Mode == "Result")
        {
            //DivAddBarcode.Visible = false;
            //DivAddPanel.Visible = false;
            DivSearchPanel.Visible = false;
            //BtnAdd.Visible = false;
            DivResultPanel.Visible = true;
            //DivAuthorise.Visible = false;
            //lblPkey.Text = "";

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


    /// <summary>
    /// Clear Add Panel 
    /// </summary>
    //private void ClearAddPanel()
    //{
    //txtEntryDate_Add.Text = "";
    //ddlPOStatus_Add.SelectedIndex = 0;
    //ddlPONo_Add.Items.Clear();
    //ddlSupplier_Add.Items.Clear();
    //txtDCNO.Text = "";
    //lblSuppName.Text = "";
    //lblsuppliercode.Text = "";
    //txtDCDate.Value = "";
    //txtInvoiceNo_Add.Text = "";
    //txtInvoiceDT.Value = "";
    //txtInvoiceValue_Add.Text = "";

    ////

    //txtEntryDate_Add.Text = System.DateTime.Now.ToString("dd-MM-yyyy");

    //}




    private void ClearSearchPanel()
    {
        ddlDivision.SelectedIndex = 0;
        ddlAcadYear.SelectedIndex = 0;
        ddlStandard.SelectedIndex = 0;
        ddlCenter.Items.Clear();
        ddlCenter.Items.Insert(0, "Select");
        ddlCenter.SelectedIndex = 0;
      
        //ddlBatch.Items.Clear();
    }


    private void FillGrid()
    {
        try
        {
            if (ddlDivision.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Division");
                return;
            }
            if (ddlAcadYear.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Acad Year");
                return;
            }
            if (ddlStandard.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Standard");
                return;
            }
            if (ddlCenter.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Center");
                return;
            }
            

            string CenterCode = "";
            for (int cnt = 0; cnt <= ddlCenter.Items.Count - 1; cnt++)
            {
                if (ddlCenter.Items[cnt].Selected == true)
                {
                    CenterCode = CenterCode + ddlCenter.Items[cnt].Value + ",";
                }
            }



            string CreatedBy = null;
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            CreatedBy = cookie.Values["UserID"];

            DataSet ds = null;
            try
            {
                ds = Report.Get_lastsiplogin_Report(ddlDivision.SelectedValue, CenterCode, ddlStandard.SelectedValue, ddlAcadYear.SelectedValue, "");
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




    #endregion

    #region Event's


    protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDDL_FRSearch_Centre();
       
    }

  
 


    protected void ddlLMSProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        //FillDDL_Batch();
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
        Clear_Error_Success_Box();
        ClearSearchPanel();
    }




    protected void HLExport_Click(object sender, EventArgs e)
    {

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        string filenamexls1 = "Replication_Report_" + DateTime.Now + ".xls";
        Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        //sets font
        HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");
        HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'>");
        Response.Charset = "";
        this.EnableViewState = false;
        System.IO.StringWriter oStringWriter1 = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter oHtmlTextWriter1 = new System.Web.UI.HtmlTextWriter(oStringWriter1);
        //this.ClearControls(dladmissioncount)
        dlGridDisplay.RenderControl(oHtmlTextWriter1);
        Response.Write(oStringWriter1.ToString());
        Response.Flush();
        Response.End();
    }







    #endregion



    protected void dlItemListAuthorise_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}