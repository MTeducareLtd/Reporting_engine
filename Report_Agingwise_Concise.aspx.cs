using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ShoppingCart.BL;
public partial class Report_Agingwise_Concise : System.Web.UI.Page
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
      public override void VerifyRenderingInServerForm(Control control)
      {
          //base.VerifyRenderingInServerForm(control);
      } 
    private void BindListBox(ListBox ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
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
    protected void ddldivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindCenter();
    }
    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }
    private void BindDivision()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = Reporting.GetUser_Company_Division_Zone_Center(2, UserID, "", "", "MT");
        BindDDL(ddldivision, ds, "Division_Name", "Division_Code");
        ddldivision.Items.Insert(0, "Select");
        ddldivision.SelectedIndex = 0;
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
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        string DivisionCode = ddldivision.SelectedValue;

        if (ddldivision.SelectedIndex.ToString() == "0")
        {
            Show_Error_Success_Box("E", "Select Division");
            return;
        }
        //if (ddlcenter.SelectedValue = "")
        //{
        //}

        //Zone Comma Separated
        //List<string> list = new List<string>();
        //List<string> List1 = new List<string>();
        //List<string> List2 = new List<string>();
        //List<string> List3 = new List<string>();

        //string CenterCode = "";
        ////string CenterName = "";
        //foreach (ListItem li in ddlcenter.Items)
        //{
        //    if (li.Selected == true)
        //    {
        //        list.Add(li.Value);
        //        CenterCode = string.Join(",", list.ToArray());
        //       

        //    }
        //}
        //string  = CenterCode;
        
        //if (Center_Code == "")
        //{
        //    Show_Error_Success_Box("E", "Select Center");
        //    return;
        //}


        string Center_Code = "", Center_Name = "";
        for (int cnt = 0; cnt <= ddlcenter.Items.Count - 1; cnt++)
        {
            if (ddlcenter.Items[cnt].Selected == true)
            {
                Center_Code = Center_Code + ddlcenter.Items[cnt].Value + ",";
                Center_Name = Center_Name + ddlcenter.Items[cnt].ToString() + ",";
            }
        }

        if (Center_Code != "")
        {
            Center_Code = Center_Code.Substring(0, Center_Code.Length - 1);
            Center_Name = Center_Name.Substring(0, Center_Name.Length - 1);
        }
        else
        {
            Show_Error_Success_Box("E", "Select atleast one Center");
            ddlcenter.Focus();
            return;
        }

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



        DataSet ds1 = Reporting.GetStudentCheque_Details1(DivisionCode, Center_Code, FromDate, ToDate);
        if (ds1.Tables[0].Rows.Count > 0 && ds1 != null)
        {
            dlStudentStatus.DataSource = ds1;
            dlStudentStatus.DataBind();

            GridView1.DataSource = ds1;
            GridView1.DataBind();
            //lblDivision_Result.Text = ddldivision.SelectedItem.ToString();
            //lblCenter_Result.Text = Center_Name;
            //lblStatus_Result.Text = ddlStatus.SelectedItem.ToString();
            //lblPeriod_Result.Text = FromDate + '-' + ToDate;
         
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

    protected void dlStudentStatus_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow gvRow = e.Row;
        if (gvRow.RowType == DataControlRowType.Header)
        {
            if (gvRow.Cells[0].Text == "Center")
            {
                gvRow.Cells.Remove(gvRow.Cells[0]);
                gvRow.Cells.Remove(gvRow.Cells[14]);
                gvRow.Cells.Remove(gvRow.Cells[14]);
                GridViewRow gvHeader = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);


                TableCell headerCell0 = new TableCell()
                {
                    Text = "<b>Center</b>",
                    HorizontalAlign = HorizontalAlign.Center,
                    RowSpan = 2
                };
                TableCell headerCell1 = new TableCell()
                 {
                     Text = "<b>0-30</b>",
                     HorizontalAlign = HorizontalAlign.Center,
                     ColumnSpan = 2
                 };
                TableCell headerCell2 = new TableCell()
                {
                    Text = "<b>31-60</b>",
                    HorizontalAlign = HorizontalAlign.Center,
                    ColumnSpan = 2
                };
                TableCell headerCell3 = new TableCell()
                {
                    Text = "<b>61-90</b>",
                    HorizontalAlign = HorizontalAlign.Center,
                    ColumnSpan = 2
                };
                TableCell headerCell4 = new TableCell()
                {
                    Text = "<b>91-120</b>",
                    HorizontalAlign = HorizontalAlign.Center,
                    ColumnSpan = 2
                };
                TableCell headerCell5 = new TableCell()
                {
                    Text = "<b>121-150</b>",
                    HorizontalAlign = HorizontalAlign.Center,
                    ColumnSpan = 2
                };
                TableCell headerCell6 = new TableCell()
                {
                    Text = "<b>151-180</b>",
                    HorizontalAlign = HorizontalAlign.Center,
                    ColumnSpan = 2
                };
                TableCell headerCell7 = new TableCell()
                {
                    Text = "<b>180 Above</b>",
                    HorizontalAlign = HorizontalAlign.Center,
                    ColumnSpan = 2
                };

                TableCell headerCell8 = new TableCell()
                {
                    Text = "<b>Total TOTAL Count</b>",
                    HorizontalAlign = HorizontalAlign.Center,
                    RowSpan = 2
                };

                //TableCell headerCell8 = new TableCell()
                //{
                //    Text = "",
                //    HorizontalAlign = HorizontalAlign.Center,
                //    RowSpan = 1
                //};
                TableCell headerCell9 = new TableCell()
                {
                    Text = "<b>Total Total Amount</b>",
                    HorizontalAlign = HorizontalAlign.Center,
                    RowSpan = 2
                };



                gvHeader.Cells.Add(headerCell0);
                //gvHeader.Cells.Add(headerCell11);
                gvHeader.Cells.Add(headerCell1);
                gvHeader.Cells.Add(headerCell2);
                gvHeader.Cells.Add(headerCell3);
                gvHeader.Cells.Add(headerCell4); gvHeader.Cells.Add(headerCell5); gvHeader.Cells.Add(headerCell6); gvHeader.Cells.Add(headerCell7);
                gvHeader.Cells.Add(headerCell8); gvHeader.Cells.Add(headerCell9);

                dlStudentStatus.Controls[0].Controls.AddAt(0, gvHeader);
            }
        }
    }

    protected void BtnShowSearchPanel_Click(object sender, EventArgs e)
    {
        Msg_Error.Visible = false;
        DivResultPanel.Visible = false;
        BtnShowSearchPanel.Visible = false;
        DivSearchPanel.Visible = true;
    }
    protected void BtnClearSearch_Click(object sender, EventArgs e)
    {
        ddldivision.SelectedIndex = 0;

        ddlcenter.Items.Clear();
        ddlcenter.Items.Insert(0, "");
        ddlcenter.SelectedIndex = 0;
        //ddlStatus.SelectedIndex = 0;
        id_date_range_picker_1.Value = "";
    }
    protected void HLExport_Click(object sender, EventArgs e)
    {

        GridView1.Visible = true;
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        string filenamexls1 = "Agingwise_Concise" + DateTime.Now + ".xls";
        Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        //sets font
        HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");
      //  HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='6'>Batchwise Absenteeism Summary</b></TD></TR><TR style='color: #fff; background: black;text-align:center;'><TD Colspan='1'>Division</b></TD><TD Colspan='1'>" + lblDivision_Result.Text + "</b></TD><TD Colspan='1'>Acad Year</b></TD><TD Colspan='1'>" + lblAcademicYear_Result.Text + "</b></TD><TD Colspan='1'>Course</b></TD><TD Colspan='1'>" + lblCourse_Result.Text + "</b></TD></TR><TR style='color: #fff; background: black;text-align:center;'><TD Colspan='1'>Center</b></TD><TD Colspan='1'>" + lblCenter_Result.Text + "</b></TD><TD Colspan='1'>Period</b></TD><TD Colspan='1'>" + lblPeriod_Result.Text + "</b></TD><TD Colspan='1'>Batch</b></TD><TD Colspan='1'>" + lblBatch_Result.Text + "</b></TD></TR><TR></TR>");
       HttpContext.Current.Response.Write("<Table border='1' cellSpacing='0' cellPadding='0' style='font-size:12.0pt; font-family:Calibri; text-align:center;'> <TR  borderColor='#000000' style='color: #fff; background: black;text-align:center;'><TD Colspan='17'>Report AgingWise Concise</b></TD></TR></TR><TR></TR>");
       
        Response.Charset = "";
        this.EnableViewState = false;
        System.IO.StringWriter oStringWriter1 = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter oHtmlTextWriter1 = new System.Web.UI.HtmlTextWriter(oStringWriter1);
        //this.ClearControls(dladmissioncount)      
        
        GridView1.RenderControl(oHtmlTextWriter1);
        HttpContext.Current.Response.Write("<Table border='1' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'><TR style=' style='color: #fff; background: black; text-align:center;'><TD Colspan='1' borderColor='#000000'></b></TD><TD Colspan='2' style='text-align:center;'>" + "<b>0-30</b>" + "</b></TD><TD Colspan='2'  style='text-align:center;'>" + "<b>31-60</b>" + "</b></TD><TD Colspan='2'  style='text-align:center;'>" + "<b>61-90</b>" + "</b></TD><TD Colspan='2'  style='text-align:center;' >" + "<b>91-120</b>" + "</b></TD><TD Colspan='2'  style='text-align:center;'>" + "<b>121-150</b>" + "</b></TD><TD Colspan='2'  style='text-align:center;'>" + "<b>151-180</b>" + "</b></TD><TD Colspan='2'  style='text-align:center;'>" + "<b>Above 180</b>" + "</b></TD><TD Colspan='1'  style='text-align:center;'>" + "" + "</b></TD><TD Colspan='1'  style='text-align:center;'>" + "" + "</b></TD></TR>");
        Response.Write(oStringWriter1.ToString());
        Response.Flush();
        Response.End();
        GridView1.Visible = false;


    }


} 
 
