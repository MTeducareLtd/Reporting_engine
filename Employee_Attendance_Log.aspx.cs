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
public partial class Employee_Attendance_Log : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DivResultPanel.Visible = false;
        
        if (!IsPostBack)
        {
           
            if (Request.Cookies["MyCookiesLoginInfo"] != null)
            {

                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID = cookie.Values["UserID"];
                string UserName = cookie.Values["UserName"];
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }
    }


    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        if (txtperiodCalendr.Value == "")
        {
            Show_Error_Success_Box("E", "Select Date Range");
            txtperiodCalendr.Focus();
            return;
            
        }
         if (txtrfid.Text=="")
        {
            Show_Error_Success_Box("E", "Select Employee Code");
            txtperiodCalendr.Focus();
            return;
 
        }
     
        DivResultPanel.Visible = true;
        DivSearchPanel.Visible = false;
    
        UpdatePanel1.Update();
        UpdatePanel2.Update();
        
        FillGrid();
    }
    private void Clear_Error_Success_Box()
    {
        Msg_Error.Visible = false;
        Msg_Success.Visible = false;
        lblSuccess.Text = "";
        lblerror.Text = "";
        UpdatePanelMsgBox.Update();
    }
    protected void BtnClearSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("Employee_Attendance_Log.aspx");
        UpdatePanel2.Update();
        UpdatePanel1.Update();
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
    private void FillGrid()
    {
        lblperiod.Text = txtperiodCalendr.Value.ToString();
        lblEmployeeNM1.Text = txtEmployeeNm.Text;
        lblrfid2.Text = txtrfid.Text;
        string EmployeeName = txtEmployeeNm.Text;
        if (EmployeeName == "")
        {
            EmployeeName = "%";
        }
        else
        {
            EmployeeName = txtEmployeeNm.Text;
        }
        string Rfid = txtrfid.Text;
        if (Rfid == "")
        {
            Rfid = "%";
        }
        else
        {
            Rfid = txtrfid.Text;
        }

        //converted date dd/mm/yyy to mm/dd/yyy
        string currDT = DateTime.Now.ToString("dd/MM/yyyy");
        string NewCurrentDate = DateTime.ParseExact(currDT, "dd/MM/yyyy", null).ToString("MM/dd/yyyy");
        //DateTime date = DateTime.ParseExact(currDT, "dd/MM/YYYY", null);
        DateTime CurrentDate = DateTime.ParseExact(NewCurrentDate, "MM/dd/yyyy", null);


        string DateRange = txtperiodCalendr.Value;
        string FromDate = DateRange.Substring(0, 10);
        string Todate = (DateRange.Length > 9) ? DateRange.Substring(DateRange.Length - 10, 10) : DateRange;
        DateTime UserToDate = DateTime.ParseExact(Todate, "MM/dd/yyyy", null);


        if (CurrentDate < UserToDate)
        {
            Show_Error_Success_Box("E", "Date Should not greater than current date");
            txtperiodCalendr.Focus();
            DivResultPanel.Visible = false;
            DivSearchPanel.Visible = true;
            return;
        }
        else
        {

            DataSet dsGrid = ProductController.GetEmployeeAttendanceDetails(EmployeeName, FromDate, Todate, Rfid);
            DataTable dtGrid = null;
            dtGrid = dsGrid.Tables[0];

            DivSearchPanel.Visible = false;
            DivResult.Visible = true;

            Teacherattendance.DataSource = dtGrid;
            Teacherattendance.DataBind();
            lbltotalcount.Text = dsGrid.Tables[0].Rows.Count.ToString();
            DivResultPanel.Visible = true;

        }
    }
    public int Currentpage
    {
        get
        {
            object s1 = this.ViewState["Currentpage"];
            if (s1 == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(s1);
            }
        }
        set { this.ViewState["Currentpage"] = value; }
    }
    protected void btnexporttoexcel_Click(object sender, EventArgs e)
    {
          
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        string filenamexls1 = "EmployeeAttendanceLog" + DateTime.Now + ".xls";
        Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        //sets font
        HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");
        HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='7'>Employee Attendance Log </TD></TR>");
        Response.Charset = "";
        this.EnableViewState = false;
        System.IO.StringWriter oStringWriter1 = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter oHtmlTextWriter1 = new System.Web.UI.HtmlTextWriter(oStringWriter1);
        //this.ClearControls(dladmissioncount);
        Teacherattendance.RenderControl(oHtmlTextWriter1);
        Response.Write(oStringWriter1.ToString());
        Response.Flush();
        Response.End();
    }
    protected void Back_Click(object sender, EventArgs e)
    {
        //Response.Redirect("RptAdmissionCount.aspx");
        //DivSearchPanel.Visible = true;
        DivSearchPanel.Visible = true;
        DivResultPanel.Visible = false;
        UpdatePanel1.Update();
        UpdatePanel2.Update();
    }
    protected void Btnnext_Click(object sender, EventArgs e)
    {
        Currentpage += 1;
        FillGrid();
    }
    protected void btnprevious_Click(object sender, EventArgs e)
    {
        Currentpage -= 1;
        FillGrid();
    }
}
