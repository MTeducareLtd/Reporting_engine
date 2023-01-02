using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ShoppingCart.BL;
using System.IO;



public partial class Rpt_LecturescheduleDetail : System.Web.UI.Page
    {

        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ControlVisibility("Search");
                FillDDL_Division();
                FillDDL_AcadYear();   
            }
        }
        #endregion

        #region Methods


        /// <summary>
        /// Fill Division drop down list
        /// </summary>
        private void FillDDL_Division()
        {

            try
            {

                Clear_Error_Success_Box();
                string CreatedBy = null;
                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                CreatedBy = cookie.Values["UserID"];

                if (string.IsNullOrEmpty(CreatedBy))
                    Response.Redirect("Login.aspx");

                DataSet dsDivision = ProductController.GetAllActiveUser_Company_Division_Zone_Center(CreatedBy, "MT", "", "", "2", "CDB");
                BindDDL(ddlDivision, dsDivision, "Division_Name", "Division_Code");
                ddlDivision.Items.Insert(0, "Select");
                ddlDivision.SelectedIndex = 0;
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

        /// <summary>
        /// Fill Academic Year dropdown
        /// </summary>
        private void FillDDL_AcadYear()
        {
            try
            {
                DataSet dsAcadYear = ProductController.GetAllActiveUser_AcadYear();
                BindDDL(ddlAcademicYear, dsAcadYear, "Description", "Id");
                ddlAcademicYear.Items.Insert(0, "Select");
                ddlAcademicYear.SelectedIndex = 0;
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

        /// <summary>
        /// Fill Course dropdownlist 
        /// </summary>
        private void FillDDL_Course()
        {

            try
            {

                Clear_Error_Success_Box();
                ddlCourse.Items.Clear();
                if (ddlDivision.SelectedItem.ToString() == "Select")
                {
                    ddlDivision.Focus();
                    return;
                }
                string Div_Code = null;
                Div_Code = ddlDivision.SelectedValue;

                DataSet dsAllStandard = ProductController.GetAllActive_AllStandard(Div_Code);
                BindDDL(ddlCourse, dsAllStandard, "Standard_Name", "Standard_Code");
                ddlCourse.Items.Insert(0, "Select");
                ddlCourse.SelectedIndex = 0;

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
        
        
        /// <summary>
        /// Fill Centers Based on login user 
        /// </summary>
        private void FillDDL_Centre()
        {
            try
            {
                string CreatedBy = null;
                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                CreatedBy = cookie.Values["UserID"];

                string Div_Code = null;
                Div_Code = ddlDivision.SelectedValue;

                DataSet dsCentre = ProductController.GetAllActiveUser_Company_Division_Zone_Center(CreatedBy, "MT", Div_Code, "", "5", "CDB");
                BindDDL(ddlCentre, dsCentre, "Center_Name", "Center_Code");
                ddlCentre.Items.Insert(0, "Select");
                ddlCentre.SelectedIndex = 0;
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

        private void FillDDL_LMSNONLMSProduct()
        {
            try
            {
                ddlLMSnonLMSProdct.Items.Clear();

                string Div_Code = null;
                Div_Code = ddlDivision.SelectedValue;

                string YearName = null;
                YearName = ddlAcademicYear.SelectedItem.ToString();

                string CourseCode = null;
                CourseCode = ddlCourse.SelectedValue;

                DataSet dsLMS = ProductController.Get_LMSProduct_ByDivision_Year_Course(Div_Code, YearName, CourseCode);
                BindDDL(ddlLMSnonLMSProdct, dsLMS, "ProductName", "ProductCode");
                ddlLMSnonLMSProdct.Items.Insert(0, "Select");
                ddlLMSnonLMSProdct.SelectedIndex = 0;
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



        
  
        /// <summary>
        /// Fill drop down list and assign value and Text
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="ds"></param>
        /// <param name="txtField"></param>
        /// <param name="valField"></param>
        private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
        {
            ddl.DataSource = ds;
            ddl.DataTextField = txtField;
            ddl.DataValueField = valField;
            ddl.DataBind();
        }

        /// <summary>
        /// Fill List box and assign value and Text
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="ds"></param>
        /// <param name="txtField"></param>
        /// <param name="valField"></param>
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


        /// <summary>
        /// Show Error or success box on top base on boxtype and Error code
        /// </summary>
        /// <param name="BoxType">BoxType</param>
        /// <param name="Error_Code">Error_Code</param>
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
        /// Bind search  Datalist
        /// </summary>
        private void FillGrid()
        {
            try
            {
                Clear_Error_Success_Box();

                if (ddlDivision.SelectedItem.ToString() == "Select")
                {
                    Show_Error_Success_Box("E", "Select Division");
                    ddlDivision.Focus();
                    return;
                }
                if (ddlAcademicYear.SelectedItem.ToString() == "Select")
                {
                    Show_Error_Success_Box("E", "Select Academic Year");
                    ddlAcademicYear.Focus();
                    return;
                }
                if (ddlCourse.SelectedItem.ToString() == "Select")
                {
                    Show_Error_Success_Box("E", "Select Course");
                    ddlCourse.Focus();
                    return;
                }
                if (ddlLMSnonLMSProdct.SelectedItem.ToString() == "Select")
                {
                    Show_Error_Success_Box("E", "Select LMS Non LMS Product");
                    ddlLMSnonLMSProdct.Focus();
                    return;
                }
                if (ddlCentre.SelectedItem.ToString() == "Select")
                {
                    Show_Error_Success_Box("E", "Select Center");
                    ddlCentre.Focus();
                    return;
                }
                if (ddlLectStatus.SelectedItem.ToString() == "Select")
                {
                    Show_Error_Success_Box("E", "Select Lecture Status");
                    ddlLectStatus.Focus();
                    return;
                }
                if (id_date_range_picker_1.Value == "")
                {
                    Show_Error_Success_Box("E", "Select Date Range");
                    id_date_range_picker_1.Focus();
                    return;
                }
                         
                

                ControlVisibility("Result");
                string DivisionCode = null;
                DivisionCode = ddlDivision.SelectedValue;

                string YearName = null;
                YearName = ddlAcademicYear.SelectedItem.Text;

                string CourseCode = null;
                CourseCode = ddlCourse.SelectedValue;


                string ProductCode = "";
                ProductCode = ddlLMSnonLMSProdct.SelectedValue;

                string CenterCode = "";
                CenterCode = ddlCentre.SelectedValue;

                string DateRange = "";
                DateRange = id_date_range_picker_1.Value;

                string FromDate, ToDate;
                FromDate = DateRange.Substring(0, 10);
                ToDate = (DateRange.Length > 9) ? DateRange.Substring(DateRange.Length - 10, 10) : DateRange;

                DataSet dsGrid = ProductController.Get_Lecture_Schedule_Decentralized(DivisionCode, YearName, ProductCode, CenterCode, FromDate, ToDate, ddlLectStatus.SelectedValue, CourseCode, ddlLectureEntryStatus.SelectedValue);
                dlGridDisplay.DataSource = dsGrid.Tables[0];
                dlGridDisplay.DataBind();               
                      
                
                lblDivision_Result.Text = ddlDivision.SelectedItem.ToString();
                lblAcademicYear_Result.Text = ddlAcademicYear.SelectedItem.ToString();
                lblCourse_Result.Text = ddlCourse.SelectedItem.ToString(); ;
                lblLMSProduct_Result.Text = ddlLMSnonLMSProdct.SelectedItem.ToString();
                lblCenter_Result.Text = ddlCentre.SelectedItem.ToString();
                lblDate_result.Text = id_date_range_picker_1.Value;

                if (dsGrid != null)
                {
                    if (dsGrid.Tables.Count != 0)
                    {
                        if (dsGrid.Tables[0].Rows.Count != 0)
                        {
                            lbltotalcount.Text = (dsGrid.Tables[0].Rows.Count).ToString();                            
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
      

        protected void BtnClearSearch_Click(object sender, EventArgs e)
        {
            ddlDivision.SelectedIndex = 0;
            ddlAcademicYear.SelectedIndex = 0;
            id_date_range_picker_1.Value = "";
            ddlLectStatus.SelectedIndex = 0;
            ddlDivision_SelectedIndexChanged(sender, e);
        }

       

        protected void BtnShowSearchPanel_Click(object sender, EventArgs e)
        {
            ControlVisibility("Search");
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

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            //string Date = Text1.Value;
            FillGrid();
        }



        protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            Clear_Error_Success_Box();           
           
            if (ddlDivision.SelectedItem.ToString() == "Select")
            {
                ddlCentre.Items.Clear();
                ddlLMSnonLMSProdct.Items.Clear();
                ddlCourse.Items.Clear();
                ddlDivision.Focus();
                return;
            }
            FillDDL_Centre();
            FillDDL_Course();
            if (ddlAcademicYear.SelectedItem.ToString() == "Select")
            {                
                ddlLMSnonLMSProdct.Items.Clear();
                ddlAcademicYear.Focus();
                return;
            }
            if (ddlCourse.SelectedItem.ToString() == "Select")
            {
                ddlLMSnonLMSProdct.Items.Clear();
                ddlCourse.Focus();
                return;
            }             
            FillDDL_LMSNONLMSProduct();
        }
        protected void ddlCentre_SelectedIndexChanged(object sender, EventArgs e)
        {
            Clear_Error_Success_Box();

            //if (ddlAcademicYear.SelectedItem.ToString() == "Select")
            //{
            //    Show_Error_Success_Box("E", "Select Academic Year");
            //    ddlAcademicYear.Focus();
            //    return;
            //}
            //if (ddlCourse.SelectedItem.ToString() == "Select")
            //{
            //    Show_Error_Success_Box("E", "Select Course");
            //    ddlCourse.Focus();
            //    return;
            //}
            //if (ddlCentre.SelectedItem.ToString() == "Select")
            //{
            //    Show_Error_Success_Box("E", "Select Center");
            //    ddlCentre.Focus();
            //    return;
            //}
            //FillDDL_Batch();
        }
        protected void ddlAcademicYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            Clear_Error_Success_Box();
            if (ddlDivision.SelectedItem.ToString() == "Select")
            {
                ddlLMSnonLMSProdct.Items.Clear();
                ddlDivision.Focus();
                return;
            }
            if (ddlAcademicYear.SelectedItem.ToString() == "Select")
            {
                ddlLMSnonLMSProdct.Items.Clear();
                ddlAcademicYear.Focus();
                return;
            }
            if (ddlCourse.SelectedItem.ToString() == "Select")
            {
                ddlLMSnonLMSProdct.Items.Clear();
                ddlCourse.Focus();
                return;
            }
            FillDDL_LMSNONLMSProduct();
        }


        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            Clear_Error_Success_Box();
            if (ddlDivision.SelectedItem.ToString() == "Select")
            {
                ddlLMSnonLMSProdct.Items.Clear();
                ddlDivision.Focus();
                return;
            }
            if (ddlAcademicYear.SelectedItem.ToString() == "Select")
            {
                ddlLMSnonLMSProdct.Items.Clear();
                ddlAcademicYear.Focus();
                return;
            }
            if (ddlCourse.SelectedItem.ToString() == "Select")
            {
                ddlLMSnonLMSProdct.Items.Clear();
                ddlCourse.Focus();
                return;
            }
            FillDDL_LMSNONLMSProduct();

        }
        

        protected void ddlLMSnonLMSProdct_SelectedIndexChanged(object sender, EventArgs e)
        {
            Clear_Error_Success_Box();
        }

    
        protected void HLExport_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            string filenamexls1 = "Report_LectureSchedule_Detail_" + DateTime.Now + ".xls";
            Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
            HttpContext.Current.Response.Charset = "utf-8";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
            //sets font
            HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
            HttpContext.Current.Response.Write("<BR><BR><BR>");
            HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='7'>Lecture Schedule - " + ddlLectStatus.SelectedItem.ToString() + "</b></TD></TR><TR style='color: #fff; background: black;text-align:center;'><TD Colspan='1' style='text-align:right;'>Division - </b></TD><TD Colspan='1' style='text-align:left;'>" + lblDivision_Result.Text + "</b></TD><TD Colspan='1' style='text-align:right;'>Acad Year - </b></TD><TD Colspan='1' style='text-align:left;'>" + lblAcademicYear_Result.Text + "</b></TD><TD Colspan='1' style='text-align:right;'>Course - </b></TD><TD Colspan='1' style='text-align:left;'>" + lblCourse_Result.Text + "</b></TD><TD Colspan='1' style='text-align:right;'></b></TD></TR><TR style='color: #fff; background: black;'><TD Colspan='1' style='text-align:right;'>LMS/NONLMS Product - </b></TD><TD Colspan='1' style='text-align:left;'>" + lblLMSProduct_Result.Text + "</b></TD><TD Colspan='1' style='text-align:right;'>Center - </b></TD><TD Colspan='1' style='text-align:left;'>" + lblCenter_Result.Text + "</b></TD><TD Colspan='1' style='text-align:right;'>Period - </b></TD><TD Colspan='1' style='text-align:left;'>" + lblDate_result.Text + "</b></TD><TD Colspan='1' style='text-align:right;'></b></TD></TR>");
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
          
    


        protected void ddlLectStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLectStatus.SelectedValue == "1")
            {
                trLectType.Visible = true;
            }
            else
                trLectType.Visible = false;
        }
       
}
