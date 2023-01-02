using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
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

public partial class Rpt_Lead_DetailsZone_CenterWise : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Request.Cookies["MyCookiesLoginInfo"] != null)
            {
                DivResultPanel.Visible = true;
                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");


                string Zonecode = Request.QueryString["Zone"];
                string DivisionCode = Request.QueryString["Division"];
                string Centercode = "";
                string FromDate = Request.QueryString["From"];
                string ToDate = Request.QueryString["To"];





                DataSet ds1 = Reporting.GET_LEAD_DETAILS_CENTERWISE(Zonecode, DivisionCode, Centercode, FromDate, ToDate);
                if (ds1.Tables[0].Rows.Count > 0 && ds1 != null)
                {

                    Repeater1.DataSource = ds1;
                    Repeater1.DataBind();
                    //script1.RegisterAsyncPostBackControl(Repeater1);
                    lbltotalcount.Text = ds1.Tables[0].Rows.Count.ToString();
                    int a = Convert.ToInt32(lbltotalcount.Text);
                    int b = a - 1;
                    lbltotalcount.Text = b.ToString();
                   
                    DivResultPanel.Visible = true;

                }

                else
                {

                    DivResultPanel.Visible = false;
                }


            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

    }

    protected void btnexporttoexcel_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        string filenamexls1 = "Lead Details Center Wise" + ' ' + DateTime.Now + ".xls";
        Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        //sets font
        HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");
        HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='10'>Lead Details Center Wise</TD></TR>");
        Response.Charset = "";
        this.EnableViewState = false;
        System.IO.StringWriter oStringWriter1 = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter oHtmlTextWriter1 = new System.Web.UI.HtmlTextWriter(oStringWriter1);
        //this.ClearControls(dladmissioncount);
        Repeater1.RenderControl(oHtmlTextWriter1);
        Response.Write(oStringWriter1.ToString());
        Response.Flush();
        Response.End();
    }
}