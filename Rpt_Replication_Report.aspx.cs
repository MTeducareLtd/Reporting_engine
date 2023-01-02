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
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;



public partial class Rpt_Replication_Report : System.Web.UI.Page
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
        ddlLMSProduct.Items.Insert(0, "Select");
        ddlLMSProduct.SelectedIndex = 0;
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

        BindDDL(ddlCenter, dsCentre, "Center_Name", "Center_Code");
        ddlCenter.Items.Insert(0, "Select");
        ddlCenter.Items.Insert(1, "All");
        ddlCenter.SelectedIndex = 0;
    }

    private void FillDDL_LMSNONLMSProduct()
    {
        try
        {
            ddlLMSProduct.Items.Clear();
            ddlBatch.Items.Clear();

            DataSet dsLMS = ProductController.Get_LMSProduct_ByDivision_Year_Course(ddlDivision.SelectedValue, ddlAcadYear.SelectedValue, ddlStandard.SelectedValue);
            BindDDL(ddlLMSProduct, dsLMS, "ProductName", "ProductCode");
            ddlLMSProduct.Items.Insert(0, "Select");
            ddlLMSProduct.SelectedIndex = 0;
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

    private void FillDDL_Batch()
    {
        try
        {
            ddlBatch.Items.Clear();

            string Div_Code = null;
            Div_Code = ddlDivision.SelectedValue;

            string YearName = null;
            YearName = ddlAcadYear.SelectedItem.ToString();

            string ProductCode = null;
            ProductCode = ddlLMSProduct.SelectedValue;

            string CenterCode = "";
            if (ddlCenter.SelectedValue == "All")
            {
                for (int cnt = 0; cnt <= ddlCenter.Items.Count - 1; cnt++)
                {
                    if (ddlCenter.Items[cnt].Selected == false)
                    {
                        CenterCode = CenterCode + ddlCenter.Items[cnt].Value + ",";
                    }
                }
            }
            else
            {
                CenterCode = ddlCenter.SelectedValue;
            }


            DataSet dsBatch = ProductController.GetAllActive_Batch_ForDivYearProductCenter(Div_Code, YearName, ProductCode, CenterCode, "1");
            BindListBox(ddlBatch, dsBatch, "Batch_Name", "Batch_Code");
            ddlBatch.Items.Insert(0, "All");
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


    private void Page_Validation()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        string Path = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
        System.IO.FileInfo Info = new System.IO.FileInfo(Path);
        string pageName = Info.Name;
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


    private void ClearSearchPanel()
    {
        ddlDivision.SelectedIndex = 0;
        ddlAcadYear.SelectedIndex = 0;
        ddlStandard.SelectedIndex = 0;
        ddlCenter.Items.Clear();
        ddlCenter.Items.Insert(0, "Select");
        ddlCenter.SelectedIndex = 0;
        ddlLMSProduct.Items.Clear();
        ddlLMSProduct.Items.Insert(0, "Select");
        ddlLMSProduct.SelectedIndex = 0;
        ddlBatch.Items.Clear();
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
            if (ddlCenter.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Center");
                return;
            }
            if (ddlLMSProduct.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select LMS Product");
                return;
            }

            if (ddlDivision.SelectedValue == "T0")
            {
                lnkpdfprint2.Visible = true;
            }
            else
            {
                lnkpdfprint2.Visible = false;
            }
            string BatchCode = "";
            for (int cnt = 0; cnt <= ddlBatch.Items.Count - 1; cnt++)
            {
                if (ddlBatch.Items[cnt].Selected == true)
                {
                    BatchCode = BatchCode + ddlBatch.Items[cnt].Value + ",";
                }
            }
            if (BatchCode == "")
            {
                Show_Error_Success_Box("E", "Atleast one Batch should be selected");
                ddlBatch.Focus();
                return;
            }
            string CenterCode = "";
            if (ddlCenter.SelectedValue == "All")
            {
                for (int cnt = 0; cnt <= ddlCenter.Items.Count - 1; cnt++)
                {
                    if (ddlCenter.Items[cnt].Selected == false)
                    {
                        CenterCode = CenterCode + ddlCenter.Items[cnt].Value + ",";
                    }
                }
            }
            else
            {
                CenterCode = ddlCenter.SelectedValue;
            }

            string CreatedBy = null;
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            CreatedBy = cookie.Values["UserID"];

            DataSet ds = null;
            try
            {
                ds = Report.Get_Replication_Report(1, CreatedBy, ddlDivision.SelectedValue, CenterCode, ddlStandard.SelectedValue, ddlAcadYear.SelectedValue, ddlLMSProduct.SelectedValue, BatchCode);
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
        FillDDL_LMSNONLMSProduct();
    }

    protected void ddlAcadYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDDL_LMSNONLMSProduct();
    }
    protected void ddlStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDDL_LMSNONLMSProduct();
    }


    protected void ddlLMSProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDDL_Batch();
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

    protected void PDF_Click(object sender, EventArgs e)
    {
        PrintPDF();
    }
    protected void PDF2_Click(object sender, EventArgs e)
    {
        PrintPDF2();
    }

    private void PrintPDF()
    {
        using (MemoryStream ms = new MemoryStream())
        {
            Document document = new Document(PageSize.A4, 25, 25, 30, 30);
            PdfWriter writer = PdfWriter.GetInstance(document, ms);
            // Open the document to enable you to write to the document
            document.Open();
            foreach (DataListItem li in dlGridDisplay.Items)
            {
                Label lbl = null;
                lbl = li.FindControl("lblSBEntryCode") as Label;
                string SBEntrycode = lbl.Text;
                BaseFont f_cb = BaseFont.CreateFont("c:\\windows\\fonts\\calibrib.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                BaseFont f_cn = BaseFont.CreateFont("c:\\windows\\fonts\\calibri.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                Font times = new Font(f_cn, 12, Font.ITALIC, Color.RED);

                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID = cookie.Values["UserID"];
                string UserName = cookie.Values["UserName"];
                DataSet Result = ProductController_Report.GetStudentDetailsforPDF(SBEntrycode);
                if (Result != null)
                {
                    if (Result.Tables[0].Rows.Count > 0)
                    {
                        string CompanyName = Result.Tables[0].Rows[0]["Division"].ToString();
                        string Admission_id = Result.Tables[0].Rows[0]["Division"].ToString();
                        
                        DataRow drstudentdetails = Result.Tables[0].Rows[0];
                        DataRow drinstitutedetails = null;
                        DataRow drfatherdetails = null;
                        DataRow drmotherdetailsdetails = null;
                        if (Result.Tables[1].Rows.Count > 0)
                        {
                            drinstitutedetails = Result.Tables[1].Rows[0];
                        }
                       
                        if (Result.Tables[2].Rows.Count > 0)
                        {
                            drfatherdetails = Result.Tables[2].Rows[0];
                        }
                        if (Result.Tables[3].Rows.Count > 0)
                        {
                            drmotherdetailsdetails = Result.Tables[3].Rows[0];
                        }
                        
                        try
                        {
                            // Add meta information to the document
                            document.AddAuthor(drstudentdetails["Name"].ToString());
                            document.AddCreator(drstudentdetails["Name"].ToString());
                            document.AddKeywords("");
                            document.AddSubject("Student Details");
                            document.AddTitle("Student Details");

                            // Makes it possible to add text to a specific place in the document using 
                            // a X & Y placement syntax.
                            PdfContentByte cb = writer.DirectContent;
                            cb.SetFontAndSize(f_cb, 16);
                            // First we must activate writing
                            cb.BeginText();
                            cb.Rectangle(10, 10, 575, 820);
                            cb.Stroke();
                            // Add an image to a fixed position from a URL
                            //iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("https://OE.MTeducare.com/Order_Engine/" + drstudentdetails["ImagePath"].ToString());
                            //img.SetAbsolutePosition(470, 760);
                          //  img.ScaleAbsolute(110, 65); //LXB
                            //cb.AddImage(img);
                            iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.TIMES_BOLD, 22);
                            iTextSharp.text.Font font6 = iTextSharp.text.FontFactory.GetFont(FontFactory.TIMES, 9);
                            iTextSharp.text.Font font7 = iTextSharp.text.FontFactory.GetFont(FontFactory.TIMES_BOLD, 11);
                            iTextSharp.text.Font font8 = iTextSharp.text.FontFactory.GetFont(FontFactory.TIMES_BOLD, 9, Color.RED);

                            PdfPTable table1 = new PdfPTable(1);
                            table1.DefaultCell.Border = Rectangle.NO_BORDER;
                            table1.HorizontalAlignment = 1;
                            table1.TotalWidth = 450;

                            PdfPCell cell = new PdfPCell(new Phrase(("Student Name: "+drstudentdetails["Name"].ToString()), font7));
                            cell.Colspan = 1;
                            cell.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right
                            cell.BorderWidthBottom = 0f;
                            cell.BorderWidthLeft = 0f;
                            cell.BorderWidthTop = 0f;
                            cell.BorderWidthRight = 0f;
                            table1.AddCell(cell);
                            PdfPCell cell1 = new PdfPCell(new Phrase(("Center Name: " + drstudentdetails["Source_Center_Name"].ToString()), font7));
                            cell1.Colspan = 1;
                            cell1.HorizontalAlignment = 0;
                            cell1.BorderWidthBottom = 0f;
                            cell1.BorderWidthLeft = 0f;
                            cell1.BorderWidthTop = 0f;
                            cell1.BorderWidthRight = 0f;
                            table1.AddCell(cell1);
                            PdfPCell cell2 = new PdfPCell(new Phrase(("Stream: " + drstudentdetails["Stream"].ToString()), font7));
                            cell2.Colspan = 1;
                            cell2.HorizontalAlignment =0;
                            cell2.BorderWidthBottom = 0f;
                            cell2.BorderWidthLeft = 0f;
                            cell2.BorderWidthTop = 0f;
                            cell2.BorderWidthRight = 0f;
                            table1.AddCell(cell2);
                            table1.WriteSelectedRows(0, -1, 10, 830, cb);

                            // Draw a line by setting the line width and position
                            cb.SetLineWidth(0f);
                            cb.MoveTo(10, 768);
                            cb.LineTo(470, 768);
                            cb.SetCMYKColorFill(200, 0, 0, 200);
                            cb.Stroke();

                            PdfPTable table2 = new PdfPTable(1);
                            table2.DefaultCell.Border = Rectangle.NO_BORDER;
                            table2.HorizontalAlignment = 1;
                            table2.TotalWidth = 625;

                            PdfPCell cell5 = new PdfPCell(new Phrase(("Contact Information:"), font7));
                            cell5.Colspan = 1;
                            cell5.HorizontalAlignment = 0;
                            cell5.BorderWidthBottom = 0f;
                            cell5.BorderWidthLeft = 0f;
                            cell5.BorderWidthTop = 0f;
                            cell5.BorderWidthRight = 0f;
                            table2.AddCell(cell5);
                            table2.WriteSelectedRows(0, -1, 10, 770, cb);
                            cb.EndText();

                            // Draw a line by setting the line width and position
                            cb.SetLineWidth(0f);
                            cb.MoveTo(10, 750);
                            cb.LineTo(585, 750);
                            cb.Stroke();

                            cb.BeginText();
                            cb.SetFontAndSize(f_cn, 11);
                            cb.SetTextMatrix(15, 738); // Left, Top
                            cb.ShowText("First Name:");
                            cb.EndText();

                            cb.BeginText();
                            cb.SetFontAndSize(f_cn, 11);
                            cb.SetTextMatrix(80, 738); // Left, Top
                            cb.ShowText(drstudentdetails["Firstname"].ToString());
                            cb.EndText();

                            cb.BeginText();
                            cb.SetFontAndSize(f_cn, 11);
                            cb.SetTextMatrix(200, 738); // Left, Top
                            cb.ShowText("Middle Name:");

                            cb.SetFontAndSize(f_cn, 11);
                            cb.SetTextMatrix(280, 738); // Left, Top
                            cb.ShowText(drstudentdetails["MiddleName"].ToString());
                            cb.EndText();
                            
                            cb.BeginText();
                            cb.SetFontAndSize(f_cn, 11);
                            cb.SetTextMatrix(360, 738); // Left, Top
                            cb.ShowText("Last Name:");

                            cb.SetFontAndSize(f_cn, 11);
                            cb.SetTextMatrix(420, 738); // Left, Top
                            cb.ShowText(drstudentdetails["Lastname"].ToString());
                            cb.EndText();
                            // Draw a line by setting the line width and position
                            cb.SetLineWidth(0f);
                            cb.MoveTo(10, 730);
                            cb.LineTo(585, 730);
                            cb.Stroke();
                            cb.EndText();

                            cb.BeginText();
                            cb.SetFontAndSize(f_cn, 11);
                            cb.SetTextMatrix(15, 718); // Left, Top
                            cb.ShowText("Gender:");

                            cb.SetFontAndSize(f_cn, 11);
                            cb.SetTextMatrix(80, 718); // Left, Top
                            cb.ShowText(drstudentdetails["Gender"].ToString());
                            cb.EndText();

                            cb.BeginText();
                            cb.SetFontAndSize(f_cn, 11);
                            cb.SetTextMatrix(200, 718); // Left, Top
                            cb.ShowText("DOB:");

                            cb.SetFontAndSize(f_cn, 11);
                            cb.SetTextMatrix(280, 718); // Left, Top
                            cb.ShowText(drstudentdetails["DOB"].ToString());
                            cb.EndText();

                            cb.BeginText();
                            cb.SetFontAndSize(f_cn, 11);
                            cb.SetTextMatrix(360, 718); // Left, Top
                            cb.ShowText("Email ID:");

                            cb.SetFontAndSize(f_cn, 11);
                            cb.SetTextMatrix(420, 718); // Left, Top
                            cb.ShowText(drstudentdetails["Emailid"].ToString());
                            cb.EndText();

                            // Draw a line by setting the line width and position
                            cb.SetLineWidth(0f);
                            cb.MoveTo(10, 710);
                            cb.LineTo(585, 710);
                            cb.Stroke();
                            cb.EndText();

                            cb.BeginText();
                            cb.SetFontAndSize(f_cn, 11);
                            cb.SetTextMatrix(15, 698); // Left, Top
                            cb.ShowText("HandPhone 1:");

                            cb.SetFontAndSize(f_cn, 11);
                            cb.SetTextMatrix(80, 698); // Left, Top
                            cb.ShowText(drstudentdetails["Handphone1"].ToString());
                            cb.EndText();

                            cb.BeginText();
                            cb.SetFontAndSize(f_cn, 11);
                            cb.SetTextMatrix(200, 698); // Left, Top
                            cb.ShowText("HandPhone 2:");

                            cb.SetFontAndSize(f_cn, 11);
                            cb.SetTextMatrix(280, 698); // Left, Top
                            cb.ShowText(drstudentdetails["Handphone2"].ToString());
                            cb.EndText();

                            cb.BeginText();
                            cb.SetFontAndSize(f_cn, 11);
                            cb.SetTextMatrix(360, 698); // Left, Top
                            cb.ShowText("LandLine:");

                            cb.SetFontAndSize(f_cn, 11);
                            cb.SetTextMatrix(420, 698); // Left, Top
                            cb.ShowText(drstudentdetails["Landline"].ToString());
                            cb.EndText();
                            // Draw a line by setting the line width and position
                            cb.SetLineWidth(0f);
                            cb.MoveTo(10, 690);
                            cb.LineTo(585, 690);
                            cb.Stroke();
                            cb.EndText();

                            cb.BeginText();
                            cb.SetFontAndSize(f_cn, 11);
                            cb.SetTextMatrix(15, 678); // Left, Top
                            cb.ShowText("Address 1:");

                            cb.SetFontAndSize(f_cn, 11);
                            cb.SetTextMatrix(80, 678); // Left, Top
                            cb.ShowText(drstudentdetails["Address1"].ToString());
                            cb.EndText();

                            // Draw a line by setting the line width and position
                            cb.SetLineWidth(0f);
                            cb.MoveTo(10, 670);
                            cb.LineTo(585, 670);
                            cb.Stroke();
                            cb.EndText();

                            cb.BeginText();
                            cb.SetFontAndSize(f_cn, 11);
                            cb.SetTextMatrix(15, 658); // Left, Top
                            cb.ShowText("Address 2:");

                            cb.SetFontAndSize(f_cn, 11);
                            cb.SetTextMatrix(80, 658); // Left, Top
                            cb.ShowText(drstudentdetails["Address2"].ToString());
                            cb.EndText();

                            // Draw a line by setting the line width and position
                            cb.SetLineWidth(0f);
                            cb.MoveTo(10, 650);
                            cb.LineTo(585, 650);
                            cb.Stroke();
                            cb.EndText();

                            cb.BeginText();
                            cb.SetFontAndSize(f_cn, 11);
                            cb.SetTextMatrix(15, 638); // Left, Top
                            cb.ShowText("Street:");

                            cb.SetFontAndSize(f_cn, 11);
                            cb.SetTextMatrix(80, 638); // Left, Top
                            cb.ShowText(drstudentdetails["StreetName"].ToString());
                            cb.EndText();

                            

                            // Draw a line by setting the line width and position
                            cb.SetLineWidth(0f);
                            cb.MoveTo(10, 630);
                            cb.LineTo(585, 630);
                            cb.Stroke();
                            cb.EndText();

                            cb.BeginText();
                            cb.SetFontAndSize(f_cn, 11);
                            cb.SetTextMatrix(15, 618); // Left, Top
                            cb.ShowText("Country:");

                            cb.SetFontAndSize(f_cn, 11);
                            cb.SetTextMatrix(80, 618); // Left, Top
                            cb.ShowText(drstudentdetails["Country"].ToString());
                            cb.EndText();

                            cb.BeginText();
                            cb.SetFontAndSize(f_cn, 11);
                            cb.SetTextMatrix(200, 618); // Left, Top
                            cb.ShowText("State:");

                            cb.SetFontAndSize(f_cn, 11);
                            cb.SetTextMatrix(280, 618); // Left, Top
                            cb.ShowText(drstudentdetails["State"].ToString());
                            cb.EndText();

                            cb.BeginText();
                            cb.SetFontAndSize(f_cn, 11);
                            cb.SetTextMatrix(360, 618); // Left, Top
                            cb.ShowText("City:");

                            cb.SetFontAndSize(f_cn, 11);
                            cb.SetTextMatrix(420, 618); // Left, Top
                            cb.ShowText(drstudentdetails["City"].ToString());
                            cb.EndText();

                            // Draw a line by setting the line width and position
                            cb.SetLineWidth(0f);
                            cb.MoveTo(10, 610);
                            cb.LineTo(585, 610);
                            cb.Stroke();
                            cb.EndText();

                            cb.BeginText();
                            cb.SetFontAndSize(f_cn, 11);
                            cb.SetTextMatrix(15, 598); // Left, Top
                            cb.ShowText("Location:");

                            cb.SetFontAndSize(f_cn, 11);
                            cb.SetTextMatrix(80, 598); // Left, Top
                            cb.ShowText("");
                            cb.EndText();

                            cb.BeginText();
                            cb.SetFontAndSize(f_cn, 11);
                            cb.SetTextMatrix(200, 598); // Left, Top
                            cb.ShowText("Pin:");

                            cb.SetFontAndSize(f_cn, 11);
                            cb.SetTextMatrix(260, 598); // Left, Top
                            cb.ShowText(drstudentdetails["Pincode"].ToString());
                            cb.EndText();

                            // Draw a line by setting the line width and position
                            cb.SetLineWidth(0f);
                            cb.MoveTo(10, 590);
                            cb.LineTo(585, 590);
                            cb.Stroke();
                            cb.EndText();

                            // Draw a line by setting the line width and position
                            cb.SetLineWidth(0f);
                            cb.MoveTo(10, 575);
                            cb.LineTo(585, 575);
                            cb.Stroke();

                            PdfPTable table3 = new PdfPTable(1);
                            table3.DefaultCell.Border = Rectangle.NO_BORDER;
                            table3.HorizontalAlignment = 1;
                            table3.TotalWidth = 625;

                            PdfPCell c6 = new PdfPCell(new Phrase(("Contact Academic Information:"), font7));
                            c6.Colspan = 1;
                            c6.HorizontalAlignment = 0;
                            c6.BorderWidthBottom = 0f;
                            c6.BorderWidthLeft = 0f;
                            c6.BorderWidthTop = 0f;
                            c6.BorderWidthRight = 0f;
                            table3.AddCell(c6);
                            table3.WriteSelectedRows(0, -1, 10, 575, cb);
                            cb.EndText();

                            // Draw a line by setting the line width and position
                            cb.SetLineWidth(0f);
                            cb.MoveTo(10, 555);
                            cb.LineTo(585, 555);
                            cb.Stroke();

                            cb.BeginText();
                            cb.SetFontAndSize(f_cn, 11);
                            cb.SetTextMatrix(15, 543); // Left, Top
                            cb.ShowText("Institute Type: ");

                            cb.SetFontAndSize(f_cn, 11);
                            cb.SetTextMatrix(105, 543); // Left, Top
                            cb.ShowText(drinstitutedetails["Institution_Type_Desc"].ToString());
                            cb.EndText();

                            cb.BeginText();
                            cb.SetFontAndSize(f_cn, 11);
                            cb.SetTextMatrix(250, 543); // Left, Top
                            cb.ShowText("Institution Name: ");

                            cb.SetFontAndSize(f_cn, 11);
                            cb.SetTextMatrix(330, 543); // Left, Top
                            cb.ShowText(drinstitutedetails["School_College_Name"].ToString());
                            cb.EndText();

                            // Draw a line by setting the line width and position
                            cb.SetLineWidth(0f);
                            cb.MoveTo(10, 535);
                            cb.LineTo(585, 535);
                            cb.Stroke();
                            cb.EndText();

                            cb.BeginText();
                            cb.SetFontAndSize(f_cn, 11);
                            cb.SetTextMatrix(15, 523); // Left, Top
                            cb.ShowText("Board/University: ");

                            cb.SetFontAndSize(f_cn, 11);
                            cb.SetTextMatrix(105, 523); // Left, Top
                            cb.ShowText(drinstitutedetails["Board_Desc"].ToString());
                            cb.EndText();

                            // Draw a line by setting the line width and position
                            cb.SetLineWidth(0f);
                            cb.MoveTo(10, 515);
                            cb.LineTo(585, 515);
                            cb.Stroke();
                            cb.EndText();

                            cb.BeginText();
                            cb.SetFontAndSize(f_cn, 11);
                            cb.SetTextMatrix(15, 503); // Left, Top
                            cb.ShowText("Currently Studying:");

                            cb.SetFontAndSize(f_cn, 11);
                            cb.SetTextMatrix(105, 503); // Left, Top
                            cb.ShowText(drinstitutedetails["Current_Standard_Desc"].ToString());
                            cb.EndText();

                            cb.BeginText();
                            cb.SetFontAndSize(f_cn, 11);
                            cb.SetTextMatrix(200, 503); // Left, Top
                            cb.ShowText("Div. / Section:");

                            cb.SetFontAndSize(f_cn, 11);
                            cb.SetTextMatrix(265, 503); // Left, Top
                            cb.ShowText(drinstitutedetails["Section_Desc"].ToString());
                            cb.EndText();

                            cb.BeginText();
                            cb.SetFontAndSize(f_cn, 11);
                            cb.SetTextMatrix(360, 503); // Left, Top
                            cb.ShowText("Year of Passing:");

                            cb.SetFontAndSize(f_cn, 11);
                            cb.SetTextMatrix(435, 503); // Left, Top
                            cb.ShowText(drinstitutedetails["Year_of_Passing_Desc"].ToString());
                            cb.EndText();

                            // Draw a line by setting the line width and position
                            cb.SetLineWidth(0f);
                            cb.MoveTo(10, 495);
                            cb.LineTo(585, 495);
                            cb.Stroke();
                            cb.EndText();

                            // Draw a line by setting the line width and position
                            cb.SetLineWidth(0f);
                            cb.MoveTo(10, 480);
                            cb.LineTo(585, 480);
                            cb.Stroke();
                            cb.EndText();

                            PdfPTable table4 = new PdfPTable(1);
                            table4.DefaultCell.Border = Rectangle.NO_BORDER;
                            table4.HorizontalAlignment = 1;
                            table4.TotalWidth = 625;

                            PdfPCell c7 = new PdfPCell(new Phrase(("Seconday Contact Information 1:"), font7));
                            c7.Colspan = 1;
                            c7.HorizontalAlignment = 0;
                            c7.BorderWidthBottom = 0f;
                            c7.BorderWidthLeft = 0f;
                            c7.BorderWidthTop = 0f;
                            c7.BorderWidthRight = 0f;
                            table4.AddCell(c7);
                            table4.WriteSelectedRows(0, -1, 10, 480, cb);
                            cb.EndText();

                            // Draw a line by setting the line width and position
                            cb.SetLineWidth(0f);
                            cb.MoveTo(10, 460);
                            cb.LineTo(585, 460);
                            cb.Stroke();
                            cb.EndText();
                            if (Result.Tables[2].Rows.Count > 0)
                            {
                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(15, 448); // Left, Top
                                cb.ShowText("Contact Type:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(80, 448); // Left, Top
                                cb.ShowText(drfatherdetails["Con_Type_Desc"].ToString());
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(200, 448); // Left, Top
                                cb.ShowText("Title:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(280, 448); // Left, Top
                                cb.ShowText(drfatherdetails["Con_Title"].ToString());
                                cb.EndText();

                                // Draw a line by setting the line width and position
                                cb.SetLineWidth(0f);
                                cb.MoveTo(10, 440);
                                cb.LineTo(585, 440);
                                cb.Stroke();
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(15, 428); // Left, Top
                                cb.ShowText("First Name:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(80, 428); // Left, Top
                                cb.ShowText(drfatherdetails["Con_Firstname"].ToString());
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(200, 428); // Left, Top
                                cb.ShowText("Middle Name:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(280, 428); // Left, Top
                                cb.ShowText(drfatherdetails["Con_midname"].ToString());
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(360, 428); // Left, Top
                                cb.ShowText("Last Name:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(420, 428); // Left, Top
                                cb.ShowText(drfatherdetails["Con_lastname"].ToString());
                                cb.EndText();
                                // Draw a line by setting the line width and position
                                cb.SetLineWidth(0f);
                                cb.MoveTo(10, 420);
                                cb.LineTo(585, 420);
                                cb.Stroke();
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(15, 408); // Left, Top
                                cb.ShowText("HandPhone 1:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(80, 408); // Left, Top
                                cb.ShowText(drfatherdetails["Handphone1"].ToString());
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(200, 408); // Left, Top
                                cb.ShowText("HandPhone 2:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(280, 408); // Left, Top
                                cb.ShowText(drfatherdetails["Handphone2"].ToString());
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(360, 408); // Left, Top
                                cb.ShowText("LandLine:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(420, 408); // Left, Top
                                cb.ShowText(drfatherdetails["Landline"].ToString());
                                cb.EndText();
                                // Draw a line by setting the line width and position
                                cb.SetLineWidth(0f);
                                cb.MoveTo(10, 400);
                                cb.LineTo(585, 400);
                                cb.Stroke();
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(15, 388); // Left, Top
                                cb.ShowText("Gender:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(80, 388); // Left, Top
                                cb.ShowText(drfatherdetails["Gender"].ToString());
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(200, 388); // Left, Top
                                cb.ShowText("Email ID:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(280, 388); // Left, Top
                                cb.ShowText(drfatherdetails["Emailid"].ToString());
                                cb.EndText();

                                // Draw a line by setting the line width and position
                                cb.SetLineWidth(0f);
                                cb.MoveTo(10, 380);
                                cb.LineTo(585, 380);
                                cb.Stroke();
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(15, 368); // Left, Top
                                cb.ShowText("Occupation:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(80, 368); // Left, Top
                                cb.ShowText(drfatherdetails["occupation"].ToString());
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(200, 368); // Left, Top
                                cb.ShowText("Organisation:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(280, 368); // Left, Top
                                cb.ShowText(drfatherdetails["organization"].ToString());
                                cb.EndText();

                                // Draw a line by setting the line width and position
                                cb.SetLineWidth(0f);
                                cb.MoveTo(10, 360);
                                cb.LineTo(585, 360);
                                cb.Stroke();
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(15, 348); // Left, Top
                                cb.ShowText("Designation:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(80, 348); // Left, Top
                                cb.ShowText(drfatherdetails["Designation"].ToString());
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(200, 348); // Left, Top
                                cb.ShowText("Office Phone:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(280, 348); // Left, Top
                                cb.ShowText(drfatherdetails["Office_phone"].ToString());
                                cb.EndText();
                            }
                            else
                            {
                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(15, 448); // Left, Top
                                cb.ShowText("Contact Type:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(80, 448); // Left, Top
                                cb.ShowText("Father");
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(200, 448); // Left, Top
                                cb.ShowText("Title:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(280, 448); // Left, Top
                                cb.ShowText("");
                                cb.EndText();

                                // Draw a line by setting the line width and position
                                cb.SetLineWidth(0f);
                                cb.MoveTo(10, 440);
                                cb.LineTo(585, 440);
                                cb.Stroke();
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(15, 428); // Left, Top
                                cb.ShowText("First Name:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(80, 428); // Left, Top
                                cb.ShowText("");
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(200, 428); // Left, Top
                                cb.ShowText("Middle Name:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(280, 428); // Left, Top
                                cb.ShowText("");
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(360, 428); // Left, Top
                                cb.ShowText("Last Name:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(420, 428); // Left, Top
                                cb.ShowText("");
                                cb.EndText();
                                // Draw a line by setting the line width and position
                                cb.SetLineWidth(0f);
                                cb.MoveTo(10, 420);
                                cb.LineTo(585, 420);
                                cb.Stroke();
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(15, 408); // Left, Top
                                cb.ShowText("HandPhone 1:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(80, 408); // Left, Top
                                cb.ShowText("");
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(200, 408); // Left, Top
                                cb.ShowText("HandPhone 2:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(280, 408); // Left, Top
                                cb.ShowText("");
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(260, 408); // Left, Top
                                cb.ShowText("LandLine:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(420, 408); // Left, Top
                                cb.ShowText("");
                                cb.EndText();
                                // Draw a line by setting the line width and position
                                cb.SetLineWidth(0f);
                                cb.MoveTo(10, 400);
                                cb.LineTo(585, 400);
                                cb.Stroke();
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(15, 388); // Left, Top
                                cb.ShowText("Gender:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(80, 388); // Left, Top
                                cb.ShowText("Male");
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(200, 388); // Left, Top
                                cb.ShowText("Email ID:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(280, 388); // Left, Top
                                cb.ShowText("");
                                cb.EndText();

                                // Draw a line by setting the line width and position
                                cb.SetLineWidth(0f);
                                cb.MoveTo(10, 380);
                                cb.LineTo(585, 380);
                                cb.Stroke();
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(15, 368); // Left, Top
                                cb.ShowText("Occupation:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(80, 368); // Left, Top
                                cb.ShowText("");
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(200, 368); // Left, Top
                                cb.ShowText("Organisation:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(280, 368); // Left, Top
                                cb.ShowText("");
                                cb.EndText();

                                // Draw a line by setting the line width and position
                                cb.SetLineWidth(0f);
                                cb.MoveTo(10, 360);
                                cb.LineTo(585, 360);
                                cb.Stroke();
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(15, 348); // Left, Top
                                cb.ShowText("Designation:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(80, 348); // Left, Top
                                cb.ShowText("");
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(200, 348); // Left, Top
                                cb.ShowText("Office Phone:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(280, 348); // Left, Top
                                cb.ShowText("");
                                cb.EndText();
                            }

                            // Draw a line by setting the line width and position
                            cb.SetLineWidth(0f);
                            cb.MoveTo(10, 340);
                            cb.LineTo(585, 340);
                            cb.Stroke();
                            cb.EndText();

                            // Draw a line by setting the line width and position
                            cb.SetLineWidth(0f);
                            cb.MoveTo(10, 325);
                            cb.LineTo(585, 325);
                            cb.Stroke();
                            cb.EndText();

                            PdfPTable table5 = new PdfPTable(1);
                            table5.DefaultCell.Border = Rectangle.NO_BORDER;
                            table5.HorizontalAlignment = 1;
                            table5.TotalWidth = 625;

                            PdfPCell c8 = new PdfPCell(new Phrase(("Seconday Contact Information 2:"), font7));
                            c8.Colspan = 1;
                            c8.HorizontalAlignment = 0;
                            c8.BorderWidthBottom = 0f;
                            c8.BorderWidthLeft = 0f;
                            c8.BorderWidthTop = 0f;
                            c8.BorderWidthRight = 0f;
                            table5.AddCell(c8);
                            table5.WriteSelectedRows(0, -1, 10, 325, cb);
                            cb.EndText();

                            // Draw a line by setting the line width and position
                            cb.SetLineWidth(0f);
                            cb.MoveTo(10, 305);
                            cb.LineTo(585, 305);
                            cb.Stroke();
                            cb.EndText();

                            if (Result.Tables[3].Rows.Count > 0)
                            {
                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(15, 293); // Left, Top
                                cb.ShowText("Contact Type:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(80, 293); // Left, Top
                                cb.ShowText(drmotherdetailsdetails["Con_Type_Desc"].ToString());
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(200, 293); // Left, Top
                                cb.ShowText("Title:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(280, 293); // Left, Top
                                cb.ShowText(drmotherdetailsdetails["Con_Title"].ToString());
                                cb.EndText();

                                // Draw a line by setting the line width and position
                                cb.SetLineWidth(0f);
                                cb.MoveTo(10, 285);
                                cb.LineTo(585, 285);
                                cb.Stroke();
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(15, 273); // Left, Top
                                cb.ShowText("First Name:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(80, 273); // Left, Top
                                cb.ShowText(drmotherdetailsdetails["Con_Firstname"].ToString());
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(200, 273); // Left, Top
                                cb.ShowText("Middle Name:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(280, 273); // Left, Top
                                cb.ShowText(drmotherdetailsdetails["Con_midname"].ToString());
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(360, 273); // Left, Top
                                cb.ShowText("Last Name:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(420, 273); // Left, Top
                                cb.ShowText(drmotherdetailsdetails["Con_lastname"].ToString());
                                cb.EndText();
                                // Draw a line by setting the line width and position
                                cb.SetLineWidth(0f);
                                cb.MoveTo(10, 265);
                                cb.LineTo(585, 265);
                                cb.Stroke();
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(15, 253); // Left, Top
                                cb.ShowText("HandPhone 1:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(80, 253); // Left, Top
                                cb.ShowText(drmotherdetailsdetails["Handphone1"].ToString());
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(200, 253); // Left, Top
                                cb.ShowText("HandPhone 2:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(280, 253); // Left, Top
                                cb.ShowText(drmotherdetailsdetails["Handphone2"].ToString());
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(360, 253); // Left, Top
                                cb.ShowText("LandLine:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(420, 253); // Left, Top
                                cb.ShowText(drmotherdetailsdetails["Landline"].ToString());
                                cb.EndText();
                                // Draw a line by setting the line width and position
                                cb.SetLineWidth(0f);
                                cb.MoveTo(10, 245);
                                cb.LineTo(585, 245);
                                cb.Stroke();
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(15, 233); // Left, Top
                                cb.ShowText("Gender:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(80, 233); // Left, Top
                                cb.ShowText(drmotherdetailsdetails["Gender"].ToString());
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(200, 223343); // Left, Top
                                cb.ShowText("Email ID:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(280, 233); // Left, Top
                                cb.ShowText(drmotherdetailsdetails["Emailid"].ToString());
                                cb.EndText();

                                // Draw a line by setting the line width and position
                                cb.SetLineWidth(0f);
                                cb.MoveTo(10, 225);
                                cb.LineTo(585, 225);
                                cb.Stroke();
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(15, 213); // Left, Top
                                cb.ShowText("Occupation:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(80, 213); // Left, Top
                                cb.ShowText(drmotherdetailsdetails["occupation"].ToString());
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(200, 213); // Left, Top
                                cb.ShowText("Organisation:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(280, 213); // Left, Top
                                cb.ShowText(drmotherdetailsdetails["organization"].ToString());
                                cb.EndText();

                                // Draw a line by setting the line width and position
                                cb.SetLineWidth(0f);
                                cb.MoveTo(10, 205);
                                cb.LineTo(585, 205);
                                cb.Stroke();
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(15, 193); // Left, Top
                                cb.ShowText("Designation:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(80, 193); // Left, Top
                                cb.ShowText(drmotherdetailsdetails["Designation"].ToString());
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(200, 193); // Left, Top
                                cb.ShowText("Office Phone:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(280, 193); // Left, Top
                                cb.ShowText(drmotherdetailsdetails["Office_phone"].ToString());
                                cb.EndText();
                            }
                            else
                            {
                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(15, 293); // Left, Top
                                cb.ShowText("Contact Type:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(80, 293); // Left, Top
                                cb.ShowText("Mother");
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(200, 293); // Left, Top
                                cb.ShowText("Title:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(280, 293); // Left, Top
                                cb.ShowText("");
                                cb.EndText();

                                // Draw a line by setting the line width and position
                                cb.SetLineWidth(0f);
                                cb.MoveTo(10, 285);
                                cb.LineTo(585, 285);
                                cb.Stroke();
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(15, 273); // Left, Top
                                cb.ShowText("First Name:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(80, 273); // Left, Top
                                cb.ShowText("");
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(200, 273); // Left, Top
                                cb.ShowText("Middle Name:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(280, 273); // Left, Top
                                cb.ShowText("");
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(360, 273); // Left, Top
                                cb.ShowText("Last Name:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(420, 273); // Left, Top
                                cb.ShowText("");
                                cb.EndText();
                                // Draw a line by setting the line width and position
                                cb.SetLineWidth(0f);
                                cb.MoveTo(10, 265);
                                cb.LineTo(585, 265);
                                cb.Stroke();
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(15, 253); // Left, Top
                                cb.ShowText("HandPhone 1:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(80, 253); // Left, Top
                                cb.ShowText("");
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(200, 253); // Left, Top
                                cb.ShowText("HandPhone 2:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(280, 253); // Left, Top
                                cb.ShowText("");
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(360, 253); // Left, Top
                                cb.ShowText("LandLine:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(420, 253); // Left, Top
                                cb.ShowText("");
                                cb.EndText();
                                // Draw a line by setting the line width and position
                                cb.SetLineWidth(0f);
                                cb.MoveTo(10, 245);
                                cb.LineTo(585, 245);
                                cb.Stroke();
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(15, 233); // Left, Top
                                cb.ShowText("Gender:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(80, 233); // Left, Top
                                cb.ShowText("Female");
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(200, 223343); // Left, Top
                                cb.ShowText("Email ID:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(280, 233); // Left, Top
                                cb.ShowText("");
                                cb.EndText();

                                // Draw a line by setting the line width and position
                                cb.SetLineWidth(0f);
                                cb.MoveTo(10, 225);
                                cb.LineTo(585, 225);
                                cb.Stroke();
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(15, 213); // Left, Top
                                cb.ShowText("Occupation:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(80, 213); // Left, Top
                                cb.ShowText("");
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(200, 213); // Left, Top
                                cb.ShowText("Organisation:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(280, 213); // Left, Top
                                cb.ShowText("");
                                cb.EndText();

                                // Draw a line by setting the line width and position
                                cb.SetLineWidth(0f);
                                cb.MoveTo(10, 205);
                                cb.LineTo(585, 205);
                                cb.Stroke();
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(15, 193); // Left, Top
                                cb.ShowText("Designation:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(80, 193); // Left, Top
                                cb.ShowText("");
                                cb.EndText();

                                cb.BeginText();
                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(200, 193); // Left, Top
                                cb.ShowText("Office Phone:");

                                cb.SetFontAndSize(f_cn, 11);
                                cb.SetTextMatrix(280, 193); // Left, Top
                                cb.ShowText("");
                                cb.EndText();
                            }

                            

                            // Draw a line by setting the line width and position
                            cb.SetLineWidth(0f);
                            cb.MoveTo(10, 185);
                            cb.LineTo(585, 185);
                            cb.Stroke();
                            cb.EndText();

                            document.NewPage();

                        }
                        catch (Exception ex)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $.gritter.add({title: 'Error', text: 'Something went wrong! Contact Administrator  ',class_name: 'gritter-item-wrapper gritter-error'});});</script>", false);
                        }

                    }
                }
            }
            //// Close the document
            document.Close();
            writer.Close();
            ms.Close();
            string CurTimeFrame = null;
            CurTimeFrame = System.DateTime.Now.ToString("ddMMyyyyhhmmss");
            Response.ContentType = "pdf/application";
            Response.AddHeader("content-disposition", "attachment;filename=Student_Details" + '_' + CurTimeFrame + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
            writer.Flush();
            ms.Flush();
        }
    }

    private void PrintPDF2()
    {
        using (MemoryStream ms = new MemoryStream())
        {
            int i = 0;
            Document document = new Document(PageSize.A4, 25, 25, 30, 30);
            PdfWriter writer = PdfWriter.GetInstance(document, ms);            
            // Open the document to enable you to write to the document
            document.Open();

            PdfContentByte cb = writer.DirectContent;
            BaseFont f_cn = BaseFont.CreateFont("c:\\windows\\fonts\\calibri.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

            foreach (DataListItem li in dlGridDisplay.Items)
            {
                Label lblBatchShortName = li.FindControl("lblBatchShortName") as Label;
                Label Lblrollno = li.FindControl("Lblrollno") as Label;
                Label lblCenter = li.FindControl("lblCenter") as Label;
                Label lblStudentName = li.FindControl("lblStudentName") as Label;                
                Label lblImagePath = li.FindControl("lblImagePath") as Label;
                // Add an image to a fixed position from a URL
                iTextSharp.text.Image img ;//= iTextSharp.text.Image.GetInstance("https://OE.MTeducare.com/Order_Engine/" + lblImagePath.Text);
                try
                {
                    img = iTextSharp.text.Image.GetInstance("https://OE.MTeducare.com/Order_Engine/" + lblImagePath.Text);
                }
                catch
                {
                    img = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/no_photo.jpg")); 
                }

               
                if (i == 0)
                {

                    iTextSharp.text.Image BackgroundImage;
                    BackgroundImage = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/Student_Info.jpg"));

                    BackgroundImage.ScaleToFit(1200, 800);
                    BackgroundImage.Alignment = iTextSharp.text.Image.UNDERLYING;
                    BackgroundImage.SetAbsolutePosition(10, 10);
                    document.Add(BackgroundImage);

                    img.SetAbsolutePosition(188, 715);
                    img.ScaleAbsolute(80, 75); //LXB
                    cb.AddImage(img);

                    cb.BeginText();

                    cb.SetFontAndSize(f_cn, 11);
                    cb.SetTextMatrix(100, 755); // Left, Top
                    cb.ShowText(lblBatchShortName.Text);

                    cb.SetTextMatrix(100, 737); // Left, Top
                    cb.ShowText(Lblrollno.Text);

                    cb.SetTextMatrix(100, 720); // Left, Top
                    cb.ShowText(lblCenter.Text);

                    cb.SetTextMatrix(20, 691); // Left, Top
                    cb.ShowText(lblStudentName.Text);

                    cb.EndText();
                }
                else if (i == 1)
                {
                    img.SetAbsolutePosition(477, 715);//188
                    img.ScaleAbsolute(80, 75); //LXB
                    cb.AddImage(img);

                    cb.BeginText();

                    cb.SetFontAndSize(f_cn, 11);
                    cb.SetTextMatrix(389, 755); // Left, Top 100
                    cb.ShowText(lblBatchShortName.Text);

                    cb.SetTextMatrix(389, 737); // Left, Top 100
                    cb.ShowText(Lblrollno.Text);

                    cb.SetTextMatrix(389, 720); // Left, Top 100
                    cb.ShowText(lblCenter.Text);

                    cb.SetTextMatrix(309, 691); // Left, Top
                    cb.ShowText(lblStudentName.Text);

                    cb.EndText();
                }
                else if (i == 2)
                {
                    img.SetAbsolutePosition(188, 550);//715
                    img.ScaleAbsolute(80, 75); //LXB
                    cb.AddImage(img);

                    cb.BeginText();

                    cb.SetFontAndSize(f_cn, 11);
                    cb.SetTextMatrix(100, 590); // Left, Top 755
                    cb.ShowText(lblBatchShortName.Text);

                    cb.SetTextMatrix(100, 572); // Left, Top 737
                    cb.ShowText(Lblrollno.Text);

                    cb.SetTextMatrix(100, 555); // Left, Top 720
                    cb.ShowText(lblCenter.Text);

                    cb.SetTextMatrix(20, 526); // Left, Top
                    cb.ShowText(lblStudentName.Text);

                    cb.EndText();
                }
                else if (i == 3)
                {
                    img.SetAbsolutePosition(477, 550);//188
                    img.ScaleAbsolute(80, 75); //LXB
                    cb.AddImage(img);

                    cb.BeginText();

                    cb.SetFontAndSize(f_cn, 11);
                    cb.SetTextMatrix(389, 590); // Left, Top 100
                    cb.ShowText(lblBatchShortName.Text);

                    cb.SetTextMatrix(389, 572); // Left, Top 100
                    cb.ShowText(Lblrollno.Text);

                    cb.SetTextMatrix(389, 555); // Left, Top 100
                    cb.ShowText(lblCenter.Text);

                    cb.SetTextMatrix(309, 526); // Left, Top
                    cb.ShowText(lblStudentName.Text);

                    cb.EndText();
                }
                else if (i == 4)
                {
                    img.SetAbsolutePosition(188, 385);//550
                    img.ScaleAbsolute(80, 75); //LXB
                    cb.AddImage(img);

                    cb.BeginText();

                    cb.SetFontAndSize(f_cn, 11);
                    cb.SetTextMatrix(100, 425); // Left, Top 590
                    cb.ShowText(lblBatchShortName.Text);

                    cb.SetTextMatrix(100, 407); // Left, Top 572
                    cb.ShowText(Lblrollno.Text);

                    cb.SetTextMatrix(100, 390); // Left, Top 555
                    cb.ShowText(lblCenter.Text);

                    cb.SetTextMatrix(20, 361); // Left, Top
                    cb.ShowText(lblStudentName.Text);

                    cb.EndText();
                }
                else if (i == 5)
                {
                    img.SetAbsolutePosition(477, 385);//188
                    img.ScaleAbsolute(80, 75); //LXB
                    cb.AddImage(img);

                    cb.BeginText();

                    cb.SetFontAndSize(f_cn, 11);
                    cb.SetTextMatrix(389, 425); // Left, Top 100
                    cb.ShowText(lblBatchShortName.Text);

                    cb.SetTextMatrix(389, 407); // Left, Top 100
                    cb.ShowText(Lblrollno.Text);

                    cb.SetTextMatrix(389, 390); // Left, Top 100
                    cb.ShowText(lblCenter.Text);

                    cb.SetTextMatrix(309, 361); // Left, Top
                    cb.ShowText(lblStudentName.Text);

                    cb.EndText();
                }
                else if (i == 6)
                {
                    img.SetAbsolutePosition(188, 220);//385
                    img.ScaleAbsolute(80, 75); //LXB
                    cb.AddImage(img);

                    cb.BeginText();

                    cb.SetFontAndSize(f_cn, 11);
                    cb.SetTextMatrix(100, 260); // Left, Top 425
                    cb.ShowText(lblBatchShortName.Text);

                    cb.SetTextMatrix(100, 242); // Left, Top 407
                    cb.ShowText(Lblrollno.Text);

                    cb.SetTextMatrix(100, 225); // Left, Top 390
                    cb.ShowText(lblCenter.Text);

                    cb.SetTextMatrix(20, 196); // Left, Top
                    cb.ShowText(lblStudentName.Text);

                    cb.EndText();
                }
                else if (i == 7)
                {
                    img.SetAbsolutePosition(477, 220);//188
                    img.ScaleAbsolute(80, 75); //LXB
                    cb.AddImage(img);

                    cb.BeginText();

                    cb.SetFontAndSize(f_cn, 11);
                    cb.SetTextMatrix(389, 260); // Left, Top 100
                    cb.ShowText(lblBatchShortName.Text);

                    cb.SetTextMatrix(389, 242); // Left, Top 100
                    cb.ShowText(Lblrollno.Text);

                    cb.SetTextMatrix(389, 225); // Left, Top 100
                    cb.ShowText(lblCenter.Text);

                    cb.SetTextMatrix(309, 196); // Left, Top
                    cb.ShowText(lblStudentName.Text);

                    cb.EndText();
                }
                else if (i == 8)
                {
                    img.SetAbsolutePosition(188, 55);//220
                    img.ScaleAbsolute(80, 75); //LXB
                    cb.AddImage(img);

                    cb.BeginText();

                    cb.SetFontAndSize(f_cn, 11);
                    cb.SetTextMatrix(100, 95); // Left, Top 260
                    cb.ShowText(lblBatchShortName.Text);

                    cb.SetTextMatrix(100, 77); // Left, Top 242
                    cb.ShowText(Lblrollno.Text);

                    cb.SetTextMatrix(100, 60); // Left, Top 225
                    cb.ShowText(lblCenter.Text);

                    cb.SetTextMatrix(20, 31); // Left, Top
                    cb.ShowText(lblStudentName.Text);

                    cb.EndText();
                }
                else if (i == 9)
                {
                    img.SetAbsolutePosition(477, 55);//188
                    img.ScaleAbsolute(80, 75); //LXB
                    cb.AddImage(img);

                    cb.BeginText();

                    cb.SetFontAndSize(f_cn, 11);
                    cb.SetTextMatrix(389, 95); // Left, Top 100
                    cb.ShowText(lblBatchShortName.Text);

                    cb.SetTextMatrix(389, 77); // Left, Top 100
                    cb.ShowText(Lblrollno.Text);

                    cb.SetTextMatrix(389, 60); // Left, Top 100
                    cb.ShowText(lblCenter.Text);

                    cb.SetTextMatrix(309, 31); // Left, Top
                    cb.ShowText(lblStudentName.Text);

                    cb.EndText();

                    i = -1;
                    document.NewPage();
                }
                i++;
            }
            //// Close the document
            document.Close();
            writer.Close();
            ms.Close();
            string CurTimeFrame = null;
            CurTimeFrame = System.DateTime.Now.ToString("ddMMyyyyhhmmss");
            Response.ContentType = "pdf/application";
            Response.AddHeader("content-disposition", "attachment;filename=Student_ICard_" + CurTimeFrame + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
            writer.Flush();
            ms.Flush();
        }
    }

    private void writeText(PdfContentByte cb, string Text, int X, int Y, BaseFont font, int Size)
    {
        cb.SetFontAndSize(font, Size);
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Text, X, Y, 0);
    }



}


