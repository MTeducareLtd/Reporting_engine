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

public partial class Stream_Download : System.Web.UI.Page
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
                FillDDL_Company();
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }
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
    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }

    protected void ddldivision_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindCenter();
    }

    private void BindCenter()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = Reporting.GetUser_Company_Division_Zone_Center(14, UserID, ddldivision.SelectedValue, "", ddlcompany.SelectedValue);
        BindListBox(ddlcenter, ds, "center_code", "Center_Code");
        ddlcenter.Items.Insert(0, "All");
    }

    private void BindListBox(ListBox ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }

    



     protected void BtnSearch_Click(object sender, EventArgs e)
    {
        string centercode = "";
         //coma supareted//
        for (int cnt = 0; cnt <= ddlcenter.Items.Count - 1; cnt++)
        {
            if (ddlcenter.Items[cnt].Selected == true)
            {
                centercode = centercode + ddlcenter.Items[cnt].Value + ",";
            }
        }
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");  
            string CompanyCode = ddlcompany.SelectedValue;
            string DivisionCode = ddldivision.SelectedValue;
            string StreamCode = txtStreamcode.Text;
            string centerCode = ddlcenter.SelectedValue;
            string USERID = cookie.Values["UserID"];

            DataSet ds1 = Reporting.insertstreamdetails(ddlcompany.SelectedValue, ddldivision.SelectedValue, ddlcenter.SelectedValue, txtStreamcode.Text,USERID);
            if (ds1 != null)
            {
                if (ds1.Tables.Count > 0)
                {
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        if (ds1.Tables[0].Rows[0]["errorsaveid"].ToString() == "1")
                        {
                            Msg_Success.Visible = true;
                            lblSuccess.Text = ds1.Tables[0].Rows[0]["errorsavemessage"].ToString();
                            Msg_Error.Visible = false;
                            UpdatePanelMsgBox.Update();
                        }
                    
                    }
                
                }
            }
        
    }
     
    
}

          
      
   