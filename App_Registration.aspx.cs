using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
using Encryption.BL;

public partial class App_Registration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Request.Cookies["MyCookiesLoginInfo"] != null)
            {
                DivResultPanel.Visible = false;

                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID = cookie.Values["UserID"];
                string UserName = cookie.Values["UserName"];
                BindCourse();
                BindCity();
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
    private void BindListBox(ListBox ddl, DataSet ds, string txtField, string valField)
    {

        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }


    private void BindCourse()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        //List<string> list = new List<string>();
        //List<string> List1 = new List<string>();
        //string Sgrcode = "";
        //foreach (ListItem li in ddlcourse.Items)
        //{
        //    if (li.Selected == true)
        //    {
        //        list.Add(li.Value);
        //        Sgrcode = string.Join(",", list.ToArray());
        //        if (Sgrcode == "All")
        //        {
        //            int remove = Math.Min(list.Count, 1);
        //            list.RemoveRange(0, remove);
        //        }
        //    }

        //}

        DataSet ds = Reporting.GetAllCourses();
        BindListBox(ddlcourse, ds, "course_name", "course_id");
        ddlcourse.Items.Insert(0, "All");

    }


    private void BindCity()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        //List<string> list = new List<string>();
        //List<string> List1 = new List<string>();
        //string Sgrcode = "";
        //foreach (ListItem li in ddlRegion.Items)
        //{
        //    if (li.Selected == true)
        //    {
        //        list.Add(li.Value);
        //        Sgrcode = string.Join(",", list.ToArray());
        //        if (Sgrcode == "All")
        //        {
        //            int remove = Math.Min(list.Count, 1);
        //            list.RemoveRange(0, remove);
        //        }
        //    }

        //}
        DataSet ds = Reporting.GetAllCity();
        BindListBox(ddlRegion, ds, "city_name", "city_id");
        ddlRegion.Items.Insert(0, "All");

    }
    private void Search()
    {
        try
        {
            if (ddlcourse.SelectedValue == "")
            {
                Show_Error_Success_Box("E", "Select Course");
                ddlcourse.Focus();
                return;

            }
            if (ddlcourse.SelectedValue == "All")
            {
                ddlcourse.Items.Clear();
                ddlcourse.Items.Insert(0, "All");
                ddlcourse.SelectedIndex = 0;

            }
      
            string NewFromDate;
            string NewToDate;
            if (txtperiodCalendr.Value == "")
            {
                NewFromDate = "";
                NewToDate = "";
            }
            else
            {
                string currDT = DateTime.Now.ToString("dd/MM/yyyy");
                string NewCurrentDate = DateTime.ParseExact(currDT, "dd/MM/yyyy", null).ToString("MM/dd/yyyy");

                DateTime CurrentDate = DateTime.ParseExact(NewCurrentDate, "MM/dd/yyyy", null);


                string DateRange = txtperiodCalendr.Value;
                string FromDate = DateRange.Substring(0, 10);
                string Todate = (DateRange.Length > 9) ? DateRange.Substring(DateRange.Length - 10, 10) : DateRange;
                DateTime UserFromDate = DateTime.ParseExact(FromDate, "MM/dd/yyyy", null);
                DateTime UserToDate = DateTime.ParseExact(Todate, "MM/dd/yyyy", null);

                NewFromDate = UserFromDate.ToString("yyyy-MM-dd");
                NewToDate = UserToDate.ToString("yyyy-MM-dd");


                if (CurrentDate < UserToDate)
                {
                    Show_Error_Success_Box("E", "Date Should not greater than current date");
                    txtperiodCalendr.Focus();
                    DivResultPanel.Visible = false;
                    DivSearchPanel.Visible = true;
                    return;
                }

            }

            Msg_Error.Visible = false;

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];

            //Course Comma Separated
            List<string> list = new List<string>();
            List<string> List1 = new List<string>();
            List<string> List2 = new List<string>();

            string Course = "";
            foreach (ListItem li in ddlcourse.Items)
            {
                if (li.Selected == true)
                {
                    list.Add(li.Value);
                    Course = string.Join(",", list.ToArray());
                    if (Course == "All")
                    {
                        int remove = Math.Min(list.Count, 1);
                        list.RemoveRange(0, remove);
                    }
                }
            }
            //string Coursecode = Course;
            //if (Coursecode == "")
            //{
            //    Coursecode = "All";
            //}




            //Region Comma Separated
            List<string> list_R = new List<string>();
            List<string> List_R1 = new List<string>();
            List<string> List_R2 = new List<string>();

            string Region = "";
            foreach (ListItem li in ddlRegion.Items)
            {
                if (li.Selected == true)
                {
                    list.Add(li.Value);
                    Region = string.Join(",", list.ToArray());
                    if (Region == "All")
                    {
                        int remove = Math.Min(list.Count, 1);
                        list.RemoveRange(0, remove);
                    }
                }
            }
            //string Regioncode = Region;
            //if (Regioncode == "")
            //{
            //    Regioncode = "All";
            //}


            string PromoCode = txtpromocode.Text;
            if (PromoCode == "")
            {
                PromoCode = "%";
            }
            string StudentName = txtSudentName.Text;
            if (StudentName == "")
            {
                StudentName = "%";
            }
            string PhoneNumber = TxtPhoneNumber.Text;
            if (PhoneNumber == "")
            {
                PhoneNumber = "%";
            }
            string Email = TxtEmail.Text;
            if (Email == "")
            {
                Email = "%";
            }




            DataSet dsGrid = Reporting.GetAppRegistration_Details(Course, Region, PromoCode, StudentName, PhoneNumber, Email, NewFromDate, NewToDate);
            PagedDataSource Pds1 = new PagedDataSource();
            Pds1.DataSource = dsGrid.Tables[0].DefaultView;
            Pds1.AllowPaging = true;
            Pds1.PageSize = 30;
            Pds1.CurrentPageIndex = Currentpage;
            lbl1.Text = "Showing " + (Currentpage + 1).ToString() + " of " + Pds1.PageCount.ToString();
            btnprevious.Enabled = !Pds1.IsFirstPage;
            Btnnext.Enabled = !Pds1.IsLastPage;
            if (dsGrid.Tables[0].Rows.Count > 0)
            {



             
                DataTable dtGrid = null;
                dtGrid = dsGrid.Tables[0];

                DivSearchPanel.Visible = false;
                DivResult.Visible = true;

                ////rptr_Regidata.DataSource = dtGrid;
                ////rptr_Regidata.DataBind();
                lbltotalcount.Text = dsGrid.Tables[0].Rows.Count.ToString();
                rptr_Regidata.DataSource = Pds1;
                rptr_Regidata.DataBind();
                
                ScriptManager1.RegisterPostBackControl(rptr_Regidata);
                DivResultPanel.Visible = true;
            }
            else
            
                {
                    Msg_Error.Visible = true;
                    lblerror.Visible = true;
                    lblerror.Text = "No Record Found. Kindly Re-Select your search criteria";

                }
            

        }
        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            lblerror.Visible = true;
            lblerror.Text = ex.Message;
        }

    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        Search();

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
    protected void Back_Click(object sender, EventArgs e)
    {
        DivSearchPanel.Visible = true;
        DivResultPanel.Visible = false;

    }
    protected void BtnClearSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("App_Registration.aspx");
    }
    protected void ddlcourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        int count = ddlcourse.GetSelectedIndices().Length;
        if (ddlcourse.SelectedValue == "All")
        {
            ddlcourse.Items.Clear();
            ddlcourse.Items.Insert(0, "All");
            ddlcourse.SelectedIndex = 0;

        }
        else if (count == 0)
        {
            //BindCourse();

        }
        else
        {
            //BindCourse();
        }
    }
    protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
    {

        int count = ddlRegion.GetSelectedIndices().Length;
        if (ddlRegion.SelectedValue == "All")
        {
            ddlRegion.Items.Clear();
            ddlRegion.Items.Insert(0, "All");
            ddlRegion.SelectedIndex = 0;

        }
        else if (count == 0)
        {
            //BindCity();

        }
        else
        {
            //BindCity();
        }
    }
    protected void btnexporttoexcel_Click(object sender, EventArgs e)
    {

        try
        {
            if (ddlcourse.SelectedValue == "")
            {
                Show_Error_Success_Box("E", "Select Course");
                ddlcourse.Focus();
                return;

            }
            if (ddlcourse.SelectedValue == "All")
            {
                ddlcourse.Items.Clear();
                ddlcourse.Items.Insert(0, "All");
                ddlcourse.SelectedIndex = 0;

            }
            //if (ddlRegion.SelectedValue == "All")
            //{
            //    ddlRegion.Items.Clear();
            //    ddlRegion.Items.Insert(0, "All");
            //    ddlRegion.SelectedIndex = 0;

            //}
            string NewFromDate;
            string NewToDate;
            if (txtperiodCalendr.Value == "")
            {
                NewFromDate = "";
                NewToDate = "";
            }
            else
            {
                string currDT = DateTime.Now.ToString("dd/MM/yyyy");
                string NewCurrentDate = DateTime.ParseExact(currDT, "dd/MM/yyyy", null).ToString("MM/dd/yyyy");

                DateTime CurrentDate = DateTime.ParseExact(NewCurrentDate, "MM/dd/yyyy", null);


                string DateRange = txtperiodCalendr.Value;
                string FromDate = DateRange.Substring(0, 10);
                string Todate = (DateRange.Length > 9) ? DateRange.Substring(DateRange.Length - 10, 10) : DateRange;
                DateTime UserFromDate = DateTime.ParseExact(FromDate, "MM/dd/yyyy", null);
                DateTime UserToDate = DateTime.ParseExact(Todate, "MM/dd/yyyy", null);

                NewFromDate = UserFromDate.ToString("yyyy-MM-dd");
                NewToDate = UserToDate.ToString("yyyy-MM-dd");


                if (CurrentDate < UserToDate)
                {
                    Show_Error_Success_Box("E", "Date Should not greater than current date");
                    txtperiodCalendr.Focus();
                    DivResultPanel.Visible = false;
                    DivSearchPanel.Visible = true;
                    return;
                }

            }

            Msg_Error.Visible = false;

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];

            //Course Comma Separated
            List<string> list = new List<string>();
            List<string> List1 = new List<string>();
            List<string> List2 = new List<string>();

            string Course = "";
            foreach (ListItem li in ddlcourse.Items)
            {
                if (li.Selected == true)
                {
                    list.Add(li.Value);
                    Course = string.Join(",", list.ToArray());
                    if (Course == "All")
                    {
                        int remove = Math.Min(list.Count, 1);
                        list.RemoveRange(0, remove);
                    }
                }
            }
            //string Coursecode = Course;
            //if (Coursecode == "")
            //{
            //    Coursecode = "All";
            //}




            //Region Comma Separated
            List<string> list_R = new List<string>();
            List<string> List_R1 = new List<string>();
            List<string> List_R2 = new List<string>();

            string Region = "";
            foreach (ListItem li in ddlRegion.Items)
            {
                if (li.Selected == true)
                {
                    list.Add(li.Value);
                    Region = string.Join(",", list.ToArray());
                    if (Region == "All")
                    {
                        int remove = Math.Min(list.Count, 1);
                        list.RemoveRange(0, remove);
                    }
                }
            }
            //string Regioncode = Region;
            //if (Regioncode == "")
            //{
            //    Regioncode = "All";
            //}


            string PromoCode = txtpromocode.Text;
            if (PromoCode == "")
            {
                PromoCode = "%";
            }
            string StudentName = txtSudentName.Text;
            if (StudentName == "")
            {
                StudentName = "%";
            }
            string PhoneNumber = TxtPhoneNumber.Text;
            if (PhoneNumber == "")
            {
                PhoneNumber = "%";
            }
            string Email = TxtEmail.Text;
            if (Email == "")
            {
                Email = "%";
            }




            DataSet dsGrid = Reporting.GetAppRegistration_Details(Course, Region, PromoCode, StudentName, PhoneNumber, Email, NewFromDate, NewToDate);
            if (dsGrid.Tables[0].Rows.Count > 0)
            {
                ExportToExcel(dsGrid);
            }
            else
            {
                Msg_Error.Visible = true;
                lblerror.Visible = true;
                lblerror.Text = "No Record Found. Kindly Re-Select your search criteria";

            }




        }
        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            lblerror.Visible = true;
            lblerror.Text = ex.Message;
        }



    }

    public void ExportToExcel(DataSet dsGrid)
    {
        string CurTimeFrame = null;
        CurTimeFrame = System.DateTime.Now.ToString("ddMMyyyyhhmmss");
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "App_Registration"+CurTimeFrame+".xls"));
        Response.ContentType = "application/ms-excel";


        DataTable dt = dsGrid.Tables[0];
        string str = string.Empty;
        int count = 0;
        foreach (DataColumn dtcol in dt.Columns)
        {


            if (dtcol.ColumnName == "StudentName")
            {

                Response.Write("App Registration");
            }
            else
            {
                string str11 = "\t";
                Response.Write(str11);
            }

        }
        string str1 = "\n";
        Response.Write(str1);
        foreach (DataColumn dtcol in dt.Columns)
        {
            Response.Write(str + dtcol.ColumnName);
            str = "\t";
        }
        Response.Write("\n");
        foreach (DataRow dr in dt.Rows)
        {
            str = "";
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                Response.Write(str + Convert.ToString(dr[j]).Trim());
                str = "\t";
            }
            Response.Write("\n");
        }
        Response.End();

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

    protected void btnprevious_Click(object sender, EventArgs e)
    {
        Currentpage -= 1;
        Search();
    }
    protected void Btnnext_Click(object sender, EventArgs e)
    {
        Currentpage += 1;
        Search();
    }



      
}