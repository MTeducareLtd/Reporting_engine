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
using System.Drawing;


public partial class Rpt_DayWiseAdmissionCount : System.Web.UI.Page
{
    int runningTotal = 0;
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
                FillDDL_Company();
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }
    }
    
    private void BindListBox(ListBox ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }

    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }

    public static object traverse(ref ListBox ListBox1)
    {
        List<string> lst = new List<string>();
        foreach (ListItem li in ListBox1.Items)
        {
            if (li.Selected)
            {
                lst.Add(li.Value);
            }
        }
        string stream1 = string.Join(",", lst.ToArray());
        //string stream = string.Join(",", lst.ToArray);
        return stream1;
    }

    private void FillDDL_Company()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet dscompany = Reporting.GetUser_Company_Division_Zone_Center(1, UserID, "", "", "");
        BindDDL(ddlcompany, dscompany, "Company_Name", "Company_Code");
        ddlcompany.Items.Insert(0, "Select");
        ddlcompany.SelectedIndex = 0;
    }

    protected void ddlcompany_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindDivision();
    }

    private void BindDivision()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = Reporting.GetUser_Company_Division_Zone_Center(2, UserID, "", "", ddlcompany.SelectedValue);
        BindDDL(ddldivision, ds, "Division_Name", "Division_Code");
        ddldivision.Items.Insert(0, "Select");
        ddldivision.SelectedIndex = 0;
    }

    protected void ddldivision_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindZone();
    }

    private void BindZone()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = Reporting.GetUser_Company_Division_Zone_Center(3, UserID, ddldivision.SelectedValue, "", ddlcompany.SelectedValue);
        BindListBox(ddlzone, ds, "Zone_Name", "Zone_Code");
        ddlzone.Items.Insert(0, "All");
       
    }

    protected void ddlzone_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        int count = ddlzone.GetSelectedIndices().Length;

        if (ddlzone.SelectedValue == "All")
        {
            ddlzone.Items.Clear();
            ddlzone.Items.Insert(0, "All");
            ddlzone.SelectedIndex = 0;
            BindCenter();
        }
        else if (count == 0)
        {
            BindZone();
            //BindCenter();
        }
        else
        {
            
            BindCenter();
        }

        
    }

    private void BindCenter()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        List<string> list = new List<string>();
        List<string> List1 = new List<string>();
        string Sgrcode = "";
            foreach (ListItem li in ddlzone.Items)
            {
                if (li.Selected == true)
                {
                    list.Add(li.Value);
                    Sgrcode = string.Join(",", list.ToArray());
                    if (Sgrcode == "All")
                    {
                        int remove = Math.Min(list.Count, 1);
                        list.RemoveRange(0, remove);
                    }
                }
                
            }
            
        string Zone = Sgrcode;
        DataSet ds = Reporting.GetUser_Company_Division_Zone_Center(4, UserID, ddldivision.SelectedValue, Zone, ddlcompany.SelectedValue);
        BindListBox(ddlcenter, ds, "Center_name", "Center_Code");        
        ddlcenter.Items.Insert(0, "All");       
       
    }

   
    protected void ddlcenter_SelectedIndexChanged(object sender, System.EventArgs e)
    {

        int count = ddlcenter.GetSelectedIndices().Length;

        if (ddlcenter.SelectedValue == "All")
        {
            ddlcenter.Items.Clear();
            ddlcenter.Items.Insert(0, "All");
            ddlcenter.SelectedIndex = 0;
            BindAcademicYear();
        }
        else if (count == 0)
        {
            BindCenter();
            //BindCenter();
        }
        else
        {
            BindAcademicYear();
        }
       
    }

    private void BindAcademicYear()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = Reporting.GetAllAcadyear();
        BindListBox(ddlacademicyear, ds, "Acad_Year", "Acad_Year");
        //ddlacademicyear.SelectedIndex = 0;
    }

    private void ClearSearchPanel()
    {
        ddlcompany.SelectedIndex = 0;
        ddldivision.Items.Clear();
        ddlzone.Items.Clear();
        ddlcenter.Items.Clear();
        ddlacademicyear.Items.Clear();
        txtOPDate.Value = "";
    }

    protected void ddlAcadyear_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        int count = ddlacademicyear.GetSelectedIndices().Length;

        if (ddlacademicyear.SelectedValue == "All")
        {
            ddlacademicyear.Items.Clear();
            ddlacademicyear.Items.Insert(0, "All");
            ddlacademicyear.SelectedIndex = 0;
            //BindStream();
        }
        else if (count == 0)
        {
            BindAcademicYear();
            //BindCenter();
        }
        else
        {

           // BindStream();
        }


        
    }


    protected void BtnSearch_Click(object sender, System.EventArgs e)
    {
        Msg_Error.Visible = false;

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string CompanyCode= ddlcompany .SelectedValue ;
        string DivisionCode= ddldivision .SelectedValue ;      

        //Zone Comma Separated
        List<string> list = new List<string>();
        List<string> List1 = new List<string>();
        List<string> List2 = new List<string>();

        string Zone = "";
        foreach (ListItem li in ddlzone.Items)
        {
            if (li.Selected == true)
            {
                list.Add(li.Value);
                Zone = string.Join(",", list.ToArray());
            }
        }
        string Zonecode = Zone;
        if (Zonecode == "")
        {
            Zonecode = "All";
        }
        // Center Comma Separated
        string Center = "";
        foreach (ListItem li1 in ddlcenter.Items)
        {
            if (li1.Selected == true)
            {
                List1.Add(li1.Value);
                Center = string.Join(",", List1.ToArray());
            }
        }
        string CenterCode = Center;
        if (CenterCode == "")
        {
            CenterCode = "All";
        }
        //Acadyear Comma Separated
        string Acadyear = "";
        foreach (ListItem li2 in ddlacademicyear.Items)
        {
            if (li2.Selected == true)
            {
                List2.Add(li2.Value);
                Acadyear = string.Join(",", List2.ToArray());
            }
        }

        string AcadyearCode = Acadyear;
        if (AcadyearCode == "")
        {

            Msg_Error.Visible = true;
            lblerror.Visible = true;
            lblerror.Text = "Select Current Year...!";
            //AcadyearCode = "All";
            return;
        }

        if (txtOPDate.Value == "")
        {

            Msg_Error.Visible = true;
            lblerror.Visible = true;
            lblerror.Text = "Enter Date!";
            return;
        }

        DataSet ds1 = Reporting.GetDayWiseAdmission("1", CompanyCode, DivisionCode, Zonecode, CenterCode, AcadyearCode, UserID, txtOPDate.Value);
        if (ds1 != null)
        {
            if (ds1.Tables[0].Rows.Count > 0)
            {
                DataTable dt = null;
                dt = ds1.Tables[0];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 3; j < dt.Columns.Count; j++)
                    {
                        if (string.IsNullOrEmpty(dt.Rows[i][j].ToString()))
                        {
                            // the Data is Blank or Null then set 0
                            dt.Rows[i][j] = "0";
                        }
                    }
                }


                dlLeadSummary.DataSource = dt;
                dlLeadSummary.DataBind();


                
                DivSearchPanel.Visible = false;
                DivResultPanel.Visible = true;

                lbltotalcount.Text = Convert.ToString(ds1.Tables[0].Rows.Count);
            }
            else
            {
                lbltotalcount.Text = "0";
                Msg_Error.Visible = true;
                lblerror.Visible = true;
                lblerror.Text = "No Record Found. Kindly Re-Select your search criteria";
            }
        }
        else
        {
            lbltotalcount.Text = "0";
            Msg_Error.Visible = true;
            lblerror.Visible = true;
            lblerror.Text = "No Record Found. Kindly Re-Select your search criteria";
        }
        
    }

    protected void btnexporttoexcel_Click(object sender, System.EventArgs e)
    {
        try
        {
            Response.ClearContent();
            Response.Buffer = true;
            string filenamexls1 = "DayWiseAdmissionCountRpt_" + DateTime.Now + ".xls";   
            string str = string.Empty;

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            string CompanyCode = ddlcompany.SelectedValue;
            string DivisionCode = ddldivision.SelectedValue;  
            //Zone Comma Separated
            List<string> list = new List<string>();
            List<string> List1 = new List<string>();
            List<string> List2 = new List<string>();

            string Zone = "";
            foreach (ListItem li in ddlzone.Items)
            {
                if (li.Selected == true)
                {
                    list.Add(li.Value);
                    Zone = string.Join(",", list.ToArray());
                }
            }
            string Zonecode = Zone;
            if (Zonecode == "")
            {
                Zonecode = "All";
            }
            // Center Comma Separated
            string Center = "";
            foreach (ListItem li1 in ddlcenter.Items)
            {
                if (li1.Selected == true)
                {
                    List1.Add(li1.Value);
                    Center = string.Join(",", List1.ToArray());
                }
            }
            string CenterCode = Center;
            if (CenterCode == "")
            {
                CenterCode = "All";
            }
            //Acadyear Comma Separated
            string Acadyear = "";
            foreach (ListItem li2 in ddlacademicyear.Items)
            {
                if (li2.Selected == true)
                {
                    List2.Add(li2.Value);
                    Acadyear = string.Join(",", List2.ToArray());
                }
            }

            string AcadyearCode = Acadyear;
            DataTable dt = null;
             DataSet ds1 = Reporting.GetDayWiseAdmission("1", CompanyCode, DivisionCode, Zonecode, CenterCode, AcadyearCode, UserID, txtOPDate.Value);
             if (ds1 != null)
             {
                 if (ds1.Tables[0].Rows.Count > 0)
                 {
                     
                     dt = ds1.Tables[0];

                     for (int i = 0; i < dt.Rows.Count; i++)
                     {
                         for (int j = 3; j < dt.Columns.Count; j++)
                         {
                             if (string.IsNullOrEmpty(dt.Rows[i][j].ToString()))
                             {
                                 // Write your Custom Code
                                 dt.Rows[i][j] = "0";
                             }
                         }
                     }
                 }
             }

             DataGrid dgGrid = new DataGrid();
             dgGrid.AllowPaging = false;
             dgGrid.DataSource = dt;
             dgGrid.DataBind();

             Response.Clear();
             Response.Buffer = true;
             Response.AddHeader("content-disposition","attachment;filename=" + filenamexls1);
             Response.Charset = "";
             Response.ContentType = "application/vnd.ms-excel";
             StringWriter sw = new StringWriter();
             HtmlTextWriter hw = new HtmlTextWriter(sw);

             //for (int i = 0; i < dgGrid.Rows.Count; i++)
             //{
             //    //Apply text style to each Row
             //    dgGrid.Rows[i].Attributes.Add("class", "textmode");
             //}
             dgGrid.RenderControl(hw);

             //style to format numbers to string
             string style = @"<style> .textmode { mso-number-format:\@; } </style>";
             Response.Write(style);
             Response.Output.Write(sw.ToString());
             Response.Flush();
             Response.End();
        }
        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            lblerror.Visible = true;
            lblerror.Text = ex.ToString();
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
    protected void btnEmail_Click(object sender, EventArgs e)
    {

    }
    protected void BtnShowSearchPanel_Click(object sender, EventArgs e)
    {
        DivSearchPanel.Visible = true;
        DivResultPanel.Visible = false;

    }
}