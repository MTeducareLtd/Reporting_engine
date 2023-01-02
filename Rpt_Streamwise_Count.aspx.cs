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


public partial class Rpt_Streamwise_Count : System.Web.UI.Page
{
    int runningTotal = 0;
    protected void Page_Load(object sender, EventArgs e)
    {      

        
        if (!IsPostBack)
        {
            if (Request.Cookies["MyCookiesLoginInfo"] != null)
            {
                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID = cookie.Values["UserID"];
                string UserName = cookie.Values["UserName"];
                DataSet ds1 = Reporting.GetStreamWiseCount("01", "2", "MT", Session["DivisionCode"].ToString(), Session["Zonecode"].ToString(), Session["CenterCode"].ToString(), Session["Acadyear"].ToString(), Session["a1"].ToString(), Session["a2"].ToString(), Session["userid"].ToString(), Session["Stream"].ToString());
                if (ds1.Tables[0].Rows.Count > 0 && ds1 != null)
                {
                    Repeater1.DataSource = ds1;
                    Repeater1.DataBind();
                    //script1.RegisterAsyncPostBackControl(Repeater1);
                    lbltotalcount.Text = ds1.Tables[0].Rows.Count.ToString();
                    Msg_Error.Visible = false;
                    Session.Remove("DivisionCode");
                    Session.Remove("Zonecode");
                    Session.Remove("CenterCode");
                    Session.Remove("Acadyear");
                    Session.Remove("a1");
                    Session.Remove("a2");
                    Session.Remove("userid");
                    Session.Remove("Stream");
                }

                else
                {
                    Msg_Error.Visible = true;
                    lblerror.Visible = true;
                    lblerror.Text = "No Record Found. Kindly Re-Select your search criteria";

                }
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
    protected void BtnSearch_Click(object sender, System.EventArgs e)
    {
        string division = Request.Form["hdnDivision"].ToString();

      


        //DataSet ds1 = Reporting.GetStreamWiseCount(Reporttype, Flag2, CompanyCode, DivisionCode, Zonecode, CenterCode, AcadyearCode, a1, a2, UserID, Stream);
        //if (ds1.Tables[0].Rows.Count > 0)
        //{
        //    Repeater1.DataSource = ds1;
        //    Repeater1.DataBind();
        //    //script1.RegisterAsyncPostBackControl(Repeater1);
        //    lbltotalcount.Text = ds1.Tables[0].Rows.Count.ToString();
        //    Msg_Error.Visible = false;
            
        //}

        //else
        //{
        //    Msg_Error.Visible = true;
        //    lblerror.Visible = true;
        //    lblerror.Text = "No Record Found. Kindly Re-Select your search criteria";

        //}
    }

    private double Sumofpending = 0;
    private double SumofConfirm = 0;
    private double Grandtotal = 0;
    protected void Repeater1_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
        Label Pending = e.Item.FindControl("lbladmncountP") as Label;
        Label Confirm = e.Item.FindControl("lbladmncountc") as Label;
        Label Grandtotal1 = e.Item.FindControl("lbltotal") as Label;
        if (Pending != null)
        {
            Sumofpending += Convert.ToDouble(Pending.Text);
            SumofConfirm += Convert.ToDouble(Confirm.Text);
            Grandtotal += Convert.ToDouble(Grandtotal1.Text);
        }
        Label lblsumpending = e.Item.FindControl("lable10") as Label;
        Label lblsumConfirm = e.Item.FindControl("Label5") as Label;
        Label lblsumGrandtotal = e.Item.FindControl("Label12") as Label;

        if (lblsumpending != null)
        {
            lblsumpending.Text = Sumofpending.ToString();
            lblsumConfirm.Text = SumofConfirm.ToString();
            lblsumGrandtotal.Text = Grandtotal.ToString();
        }

    }
    protected void btnexporttoexcel_Click(object sender, System.EventArgs e)
    {
       

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        string filenamexls1 = "AdmissionCount_Stream_Wise_Rpt_" + DateTime.Now + ".xls";
        Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        //sets font
        HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");
        HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='9'>Stream wise Admission Count Report (Pending V/s Confirm)</b></TD></TR>");
        Response.Charset = "";
        this.EnableViewState = false;
        System.IO.StringWriter oStringWriter1 = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter oHtmlTextWriter1 = new System.Web.UI.HtmlTextWriter(oStringWriter1);
        //this.ClearControls(dladmissioncount)
        Repeater1.RenderControl(oHtmlTextWriter1);
        Response.Write(oStringWriter1.ToString());
        Response.Flush();
        Response.End();


    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }    
    protected void Back_Click(object sender, EventArgs e)
    {
        Response.Redirect("RptAdmissionCount.aspx");
    }
}