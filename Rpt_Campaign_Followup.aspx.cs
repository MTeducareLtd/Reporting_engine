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
using System.Drawing;


public partial class Rpt_Campaign_Followup : System.Web.UI.Page
{

    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                ControlVisibility("Search");
                BindAcademicYear();                              
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


    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
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

    

   

    private void ControlVisibility(string Mode)
    {
        if (Mode == "Search")
        {
            DivSearchPanel.Visible = true;
            DivResultPanel.Visible = false;

        }
        else if (Mode == "Result")
        {
            DivSearchPanel.Visible = false;
            DivResultPanel.Visible = true;

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
       // ddlStandard.Items.Clear();       
        ddlAcadYear.SelectedIndex = 0;
    }


    private void FillGrid()
    {
        try
        {
            if (ddlAcadYear.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Acad Year");
                return;
            }

            
            

            string CreatedBy = null;
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            CreatedBy = cookie.Values["UserID"];

            DataSet ds = null;
            try
            {
                lblAcadYear_Result.Text = ddlAcadYear.SelectedItem.ToString();
                 ds = Report.Get_Campaign_Followup_Report(1, ddlAcadYear.SelectedValue, CreatedBy);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dlGridDisplay.DataSource = ds.Tables[0];
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
                        lbltotalcount.Text = (ds.Tables[0].Rows.Count-1).ToString();
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
        string filenamexls1 = "Report_Campaign_Followup_" + DateTime.Now + ".xls";
        Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        //sets font
        HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");
        HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'><TR style='color: #fff; background: black;text-align:center;'><TD>Acad Year-" + ddlAcadYear.SelectedItem.ToString() + "</TD></TR>");
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


