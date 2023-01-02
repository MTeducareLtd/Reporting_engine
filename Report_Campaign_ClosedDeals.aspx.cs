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



public partial class Report_Campaign_ClosedDeals : System.Web.UI.Page
{

    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                ControlVisibility("Search");
                BindCampaignDetail();
               
                
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

    private void BindCampaignDetail()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        DataSet ds = Report.GetUser_Role_Campaign(1, UserID, "", "","");

        ddlCampaignTypeSearch.DataSource = ds.Tables[0];
        ddlCampaignTypeSearch.DataTextField = "Desc";
        ddlCampaignTypeSearch.DataValueField = "ID";
        ddlCampaignTypeSearch.DataBind();
        ddlCampaignTypeSearch.Items.Insert(0, "");
        ddlCampaignTypeSearch.Items.Insert(1, "All");
        ddlCampaignTypeSearch.SelectedIndex = 0;

    }


    private void FillDDL_FRSearch_Centre()
    {
        string Company_Code = "MT";
        string DBname = "CDB";

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        //string Div_Code = null;
        //Div_Code = ddlDivisionFR_SR.SelectedValue;

        //DataSet dsCentre = ProductController.GetAllActiveUser_Company_Division_Zone_Center(UserID, Company_Code, Div_Code, "", "5", DBname);

        //BindDDL(ddlCenterFR_SR, dsCentre, "Center_Name", "Center_Code");
        //ddlCenterFR_SR.Items.Insert(0, "Select");
        //ddlCenterFR_SR.SelectedIndex = 0;
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

        //To Content

        //date_range_SR.Value = "";
        //txtChallan_SR.Text = "";

        
    }


    private void FillGrid()
    {
        try
        {
            Clear_Error_Success_Box();
                      
          

            string CreatedBy = null;
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            CreatedBy = cookie.Values["UserID"];

            DataSet ds = null;
            try
            {
                ds = Report.GetUser_Role_Campaign(10, CreatedBy, ddlCampaignTypeSearch.SelectedValue, txtCampaignNameSearch.Text.Trim(),"");
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

            if (ddlCampaignTypeSearch.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Campaign Type");
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
        string filenamexls1 = "Campaign_Closed_Deals_" + DateTime.Now + ".xls";
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
    protected void ddlPOStatus_Add_SelectedIndexChanged(object sender, EventArgs e)
    {
        //try
        //{
    //        if (ddlPOStatus_Add.SelectedValue == "Yes")
    //        {
    //            FillDDL_PONumber();
    //            PONOID.Visible = true;
    //            SuppID.Visible = false;
    //            //DivAddItem.Visible = true;
    //            tbl_poNo.Visible = false;
    //            tbl_poYes.Visible = true;

    //            lblsup.Visible = true;
    //            lblSuppName.Visible = true;
    //            //txtItemRate.Enabled = false;
    //            txtItemRate.ReadOnly = true;
    //            ClearItemAdd();
    //        }
    //        else if (ddlPOStatus_Add.SelectedValue == "No")
    //        {
    //            PONOID.Visible = false;
    //            SuppID.Visible = true;
    //            //DivAddItem.Visible = true;
    //            tbl_poNo.Visible = true;
    //            tbl_poYes.Visible = false;
    //            //txtItemRate.Enabled = true;
    //            txtItemRate.ReadOnly = false;
    //            lblsup.Visible = false;
    //            lblSuppName.Visible = false;
    //            FillDDL_Supplier();
    //            ClearItemAdd();
    //        }
    //        else if (ddlPOStatus_Add.SelectedValue == "Select")
    //        {
    //            PONOID.Visible = false;
    //            SuppID.Visible = false;
    //            //DivAddItem.Visible = false;
    //            lblsup.Visible = false;
    //            lblSuppName.Visible = false;
    //            ClearItemAdd();
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        Msg_Error.Visible = true;
    //        Msg_Success.Visible = false;
    //        lblerror.Text = ex.ToString();
    //        UpdatePanelMsgBox.Update();
    //        return;
    //    }
        
    }





    

    #endregion



    protected void dlItemListAuthorise_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}


