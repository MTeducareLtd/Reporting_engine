using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Microsoft.VisualBasic;
using ShoppingCart.BL;
using System.Web;

public partial class Reports : System.Web.UI.MasterPage
{


    protected void Page_Init(object sender, System.EventArgs e)
    {
        if (!IsPostBack)
        {
            Generate_Menu();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        lblHeader_User_Name.Text = Request.Cookies["MyCookiesLoginInfo"]["UserName"];

    }
    protected void BtnLogOut_Click(object sender, EventArgs e)
    {
        Response.Redirect("logout.aspx");
    }



    private void Generate_Menu()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        if (Request.Cookies["MyCookiesLoginInfo"] != null)
        {
            string defaultpage = cookie.Values["Default_page"];
            DataSet dtApplicatUrl = ProductController.GetApplication_Url();

            string Userid = cookie.Values["UserID"];
            string lstr = "";
            lstr = Convert.ToString(("<ul class='nav nav-list'>"));
            DataSet ds = ProductController.GetMenuList("1", Userid, "");
            lstr += Convert.ToString(("<li>"));
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                string Application_no = Convert.ToString(ds.Tables[0].Rows[i]["Application_No"]);
                if (Application_no == "10")
                {
                    lstr += Convert.ToString(("<li> <a href=' " + ds.Tables[0].Rows[i]["Menu_link"] + "' class='" + ds.Tables[0].Rows[i]["Toggle"] + "'><i class='" + ds.Tables[0].Rows[i]["Menu_CSS"] + "'></i><span>"));
                    lstr += (Convert.ToString(ds.Tables[0].Rows[i]["Menu_Name"]));
                    DataSet ds1 = ProductController.GetMenuList("2", Userid, ds.Tables[0].Rows[i]["Menu_Code"].ToString());
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        lstr += Convert.ToString(("</span><b class='arrow icon-angle-down'></b>"));
                        lstr += Convert.ToString(("</a><ul class='submenu'>"));
                        for (int j = 0; j <= ds1.Tables[0].Rows.Count - 1; j++)
                        {
                            lstr += Convert.ToString((((" <li><a href='") + ds1.Tables[0].Rows[j]["Menu_Link"] + "'><i></i>") + ds1.Tables[0].Rows[j]["Menu_Name"] + "</a>"));
                        }
                        lstr += Convert.ToString(("</ul></li>"));
                    }
                    lstr += Convert.ToString(("</span></a></li>"));
                    lblHeaderMenu.Text = lstr;
                }
            }
            lstr += Convert.ToString(("</ul>"));

        }

    }


    private void FindUserCompany()
    {
        try
        {
            string UserId = null;
            string UserName = null;
            string DBName = null;
            string UserTypeCode = null;

            if (Request.Cookies["MyCookiesLoginInfo"] != null)
            {
                UserId = Request.Cookies["MyCookiesLoginInfo"]["UserID"];
                UserName = Request.Cookies["MyCookiesLoginInfo"]["UserName"];
                DBName = Request.Cookies["MyCookiesLoginInfo"]["DBName"];
                UserTypeCode = Request.Cookies["MyCookiesLoginInfo"]["UserTypeCode"];
                string role = Request.Cookies["MyCookiesLoginInfo"]["Role"];
                lblHeader_User_Name.Text = UserName;
                lblHeader_User_Code.Text = UserId;
                DataSet dsUserCompany = ProductController.GetAllActiveUser_Company_Division_Zone_Center(UserId, "", "", "", "1", DBName);
                if (dsUserCompany.Tables[0].Rows.Count == 1)
                {
                }
                else
                {
                }

                if (dsUserCompany.Tables[0].Rows.Count > 0)
                {
                }
                else
                {
                }

               
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
        catch (Exception ex)
        {

        }
    }


    private void FindUserMessages()
    {
        lnk_Message.Visible = false;
    }
}
