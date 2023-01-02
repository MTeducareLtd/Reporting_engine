using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;
using ShoppingCart.DAL;
using System.Data.SqlClient;
using ShoppingCart.BL;
using System.Configuration;
////using Encryption.BL;
namespace ShoppingCart.BL
{
    public class Report
    {
        //All Functions for MT College Project

        //'Function to get Menu
        public static DataSet Get_Report_OpeningStock(int Flag, string Inward_Code, string Location_Type, string Div_Code,string Location, string Created_By)
        {
            SqlParameter p1 = new SqlParameter("@flag", Flag);
            SqlParameter p2 = new SqlParameter("@InwardCode", Inward_Code);
            SqlParameter p3 = new SqlParameter("@Location_Type", Location_Type);
            SqlParameter p4 = new SqlParameter("@Div_Code", Div_Code);
            SqlParameter p5 = new SqlParameter("@Location", Location);
            SqlParameter p6 = new SqlParameter("@Created_By", Created_By);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Report_Opening_Stock", p1, p2, p3, p4, p5,p6));
        }

        public static DataSet GetUser_Role_Campaign(int Flag, string Userid, string Campaign_Type, string Campaign_Name, string CampaignAcadyear)
        {
            SqlParameter p = new SqlParameter("@flag", SqlDbType.Int);
            p.Value = Flag;
            SqlParameter p1 = new SqlParameter("@user_id", SqlDbType.VarChar);
            p1.Value = Userid;
            SqlParameter p2 = new SqlParameter("@Campaign_Type", SqlDbType.VarChar);
            p2.Value = Campaign_Type;
            SqlParameter p3 = new SqlParameter("@Campaign_Name", SqlDbType.VarChar);
            p3.Value = Campaign_Name;
            SqlParameter p4 = new SqlParameter("@CampaignAcadyear", SqlDbType.VarChar);
            p4.Value = CampaignAcadyear;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_CampaignDetail", p, p1, p2, p3,p4));
        }

        public static DataSet GetUser_Role_Campaign_Detail(int Flag, string Userid, string Campaign_ID, string Campaign_Type, string Campaign_Name)
        {
            SqlParameter p = new SqlParameter("@flag", SqlDbType.Int);
            p.Value = Flag;
            SqlParameter p1 = new SqlParameter("@user_id", SqlDbType.VarChar);
            p1.Value = Userid;
            SqlParameter p2 = new SqlParameter("@Campaign_Type", SqlDbType.VarChar);
            p2.Value = Campaign_Type;
            SqlParameter p3 = new SqlParameter("@Campaign_Name", SqlDbType.VarChar);
            p3.Value = Campaign_Name;
            SqlParameter p4 = new SqlParameter("@Campaign_Id", SqlDbType.VarChar);
            p4.Value = Campaign_ID;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_CampaignDetail", p, p1, p2, p3, p4));
        }

       
        //14 April 2016
        public static DataSet Get_Replication_Report(int Flag, string Userid, string Division, string Center, string Course, string AcadYear, string LMSProduct, string BatchCode)
        {
            SqlParameter p = new SqlParameter("@flag", SqlDbType.Int);
            p.Value = Flag;
            SqlParameter p1 = new SqlParameter("@user_id", SqlDbType.VarChar);
            p1.Value = Userid;
            SqlParameter p2 = new SqlParameter("@Division", SqlDbType.VarChar);
            p2.Value = Division;
            SqlParameter p3 = new SqlParameter("@Center", SqlDbType.VarChar);
            p3.Value = Center;
            SqlParameter p4 = new SqlParameter("@Course", SqlDbType.VarChar);
            p4.Value = Course;
            SqlParameter p5 = new SqlParameter("@AcadYear", SqlDbType.VarChar);
            p5.Value = AcadYear;
            SqlParameter p6 = new SqlParameter("@LMSProduct", SqlDbType.VarChar);
            p6.Value = LMSProduct;
            SqlParameter p7 = new SqlParameter("@BatchCode", SqlDbType.VarChar);
            p7.Value = BatchCode;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_RPT_Replication_Report", p, p1, p2, p3, p4, p5, p6, p7));
        }

        //15 April 2016
        public static DataSet Get_Contact_LocationStandardWise_Report(int Flag, string Year_of_Passing_ID, string Current_Standard_Id, string User_Id)
        {
            SqlParameter p = new SqlParameter("@flag", SqlDbType.Int);
            p.Value = Flag;
            SqlParameter p1 = new SqlParameter("@Year_of_Passing_ID", SqlDbType.VarChar);
            p1.Value = Year_of_Passing_ID;
            SqlParameter p2 = new SqlParameter("@Current_Standard_Id", SqlDbType.VarChar);
            p2.Value = Current_Standard_Id;
            SqlParameter p3 = new SqlParameter("@User_Id", SqlDbType.VarChar);
            p3.Value = User_Id;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GET_Contacts_LocationStandardwise", p, p1, p2, p3));
        }
        //16 April 2016
        public static DataSet Get_Contact_LocationStandardBoardWise_Report(int Flag, string Year_of_Passing_ID, string Current_Standard_Id,string BoardId, string User_Id)
        {
            SqlParameter p = new SqlParameter("@flag", SqlDbType.Int);
            p.Value = Flag;
            SqlParameter p1 = new SqlParameter("@Year_of_Passing_ID", SqlDbType.VarChar);
            p1.Value = Year_of_Passing_ID;
            SqlParameter p2 = new SqlParameter("@Current_Standard_Id", SqlDbType.VarChar);
            p2.Value = Current_Standard_Id;
            SqlParameter p3 = new SqlParameter("@User_Id", SqlDbType.VarChar);
            p3.Value = User_Id;
            SqlParameter p4 = new SqlParameter("@Board_Id", SqlDbType.VarChar);
            p4.Value = BoardId;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GET_Contacts_LocationStandardBoardwise", p, p1, p2, p3, p4));
        }
        //18 April 2016
        public static DataSet Get_Contact_LocationStandardBoardWiseOpenContacts_Report(int Flag, string Year_of_Passing_ID, string Current_Standard_Id, string BoardId, string User_Id)
        {
            SqlParameter p = new SqlParameter("@flag", SqlDbType.Int);
            p.Value = Flag;
            SqlParameter p1 = new SqlParameter("@Year_of_Passing_ID", SqlDbType.VarChar);
            p1.Value = Year_of_Passing_ID;
            SqlParameter p2 = new SqlParameter("@Current_Standard_Id", SqlDbType.VarChar);
            p2.Value = Current_Standard_Id;
            SqlParameter p3 = new SqlParameter("@User_Id", SqlDbType.VarChar);
            p3.Value = User_Id;
            SqlParameter p4 = new SqlParameter("@Board_Id", SqlDbType.VarChar);
            p4.Value = BoardId;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GET_Contacts_YearLocationStandardBoardwise", p, p1, p2, p3, p4));
        }

        public static DataSet Get_Conversion_Contacts_To_Lead_Locationwise_Report(int Flag, string Year_of_Passing_ID, string Current_Standard_Id,  string User_Id)
        {
            SqlParameter p = new SqlParameter("@flag", SqlDbType.Int);
            p.Value = Flag;
            SqlParameter p1 = new SqlParameter("@Year_of_Passing_ID", SqlDbType.VarChar);
            p1.Value = Year_of_Passing_ID;
            SqlParameter p2 = new SqlParameter("@Current_Standard_Id", SqlDbType.VarChar);
            p2.Value = Current_Standard_Id;
            SqlParameter p3 = new SqlParameter("@User_Id", SqlDbType.VarChar);
            p3.Value = User_Id;
            //SqlParameter p4 = new SqlParameter("@Board_Id", SqlDbType.VarChar);
            //p4.Value = BoardId;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GET_Contacts_ConversionContactsToLead", p, p1, p2, p3));
        }

        public static DataSet Get_Conversion_Contacts_To_Lead_Institutewise_Report(int Flag, string Year_of_Passing_ID, string Current_Standard_Id, string User_Id)
        {
            SqlParameter p = new SqlParameter("@flag", SqlDbType.Int);
            p.Value = Flag;
            SqlParameter p1 = new SqlParameter("@Year_of_Passing_ID", SqlDbType.VarChar);
            p1.Value = Year_of_Passing_ID;
            SqlParameter p2 = new SqlParameter("@Current_Standard_Id", SqlDbType.VarChar);
            p2.Value = Current_Standard_Id;
            SqlParameter p3 = new SqlParameter("@User_Id", SqlDbType.VarChar);
            p3.Value = User_Id;
            //SqlParameter p4 = new SqlParameter("@Board_Id", SqlDbType.VarChar);
            //p4.Value = BoardId;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GET_Contacts_ConversionContactsToLead_Institutewise", p, p1, p2, p3));
        }
        //19 April 2016
        public static DataSet Get_Campaign_Followup_Report(int Flag, string Acad_Year, string User_Id)
        {
            SqlParameter p = new SqlParameter("@flag", SqlDbType.Int);
            p.Value = Flag;
            SqlParameter p1 = new SqlParameter("@Acad_Year", SqlDbType.VarChar);
            p1.Value = Acad_Year;
            SqlParameter p2 = new SqlParameter("@User_Id", SqlDbType.VarChar);
            p2.Value = User_Id;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GET_Campaign_Followup_Report", p, p1, p2));
        }

        public static DataSet Get_Campaign_Followup_Detailed_Report(int Flag,  string User_Id,string CampaignId)
        {
            SqlParameter p = new SqlParameter("@flag", SqlDbType.Int);
            p.Value = Flag;
            SqlParameter p1 = new SqlParameter("@CampaignID", SqlDbType.VarChar);
            p1.Value = CampaignId;
            SqlParameter p2 = new SqlParameter("@User_Id", SqlDbType.VarChar);
            p2.Value = User_Id;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_rpt_Campaign_Followup_Detailed", p, p1, p2));
        }

        //20 April 2016
        public static DataSet Get_Lead_Summary_Report(int Flag, string Acad_Year, string User_Id)
        {
            SqlParameter p = new SqlParameter("@flag", SqlDbType.Int);
            p.Value = Flag;
            SqlParameter p1 = new SqlParameter("@Acad_Year", SqlDbType.VarChar);
            p1.Value = Acad_Year;
            SqlParameter p2 = new SqlParameter("@User_Code", SqlDbType.VarChar);
            p2.Value = User_Id;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_rpt_Lead_Summary", p, p1, p2));
        }
        //21 April 2016
        public static DataSet Get_Lead_Followup_centerwise_Report(int Flag, string Acad_Year, string User_Id)
        {
            SqlParameter p = new SqlParameter("@flag", SqlDbType.Int);
            p.Value = Flag;
            SqlParameter p1 = new SqlParameter("@Acad_Year", SqlDbType.VarChar);
            p1.Value = Acad_Year;
            SqlParameter p2 = new SqlParameter("@User_Code", SqlDbType.VarChar);
            p2.Value = User_Id;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_rpt_Lead_Followup_Centerwise", p, p1, p2));
        }

        public static DataSet Get_Lead_Followup_Agentwise_Report(int Flag, string Acad_Year, string User_Id)
        {
            SqlParameter p = new SqlParameter("@flag", SqlDbType.Int);
            p.Value = Flag;
            SqlParameter p1 = new SqlParameter("@Acad_Year", SqlDbType.VarChar);
            p1.Value = Acad_Year;
            SqlParameter p2 = new SqlParameter("@User_Code", SqlDbType.VarChar);
            p2.Value = User_Id;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_rpt_Lead_Followup_Agentwise", p, p1, p2));
        }
        //10 Jun 2016
        public static DataSet Get_CRM_Index_Report(int Flag,  string User_Id)
        {
            SqlParameter p = new SqlParameter("@flag", SqlDbType.Int);
            p.Value = Flag;
            SqlParameter p1 = new SqlParameter("@User_Id", SqlDbType.VarChar);
            p1.Value = User_Id;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GET_CRM_Index_Report", p, p1));
        }

       //added by sujeer:
        public static DataSet Get_batch_Report(string Division, string Center, string Course, string AcadYear, string LMSProduct)
        {
            SqlParameter p = new SqlParameter("@Division", SqlDbType.VarChar);
            p.Value = Division;
            SqlParameter p1 = new SqlParameter("@CenterCode", SqlDbType.VarChar);
            p1.Value = Center;
            SqlParameter p2 = new SqlParameter("@CourseCode", SqlDbType.VarChar);
            p2.Value = Course;
            SqlParameter p3 = new SqlParameter("@AcadYear", SqlDbType.VarChar);
            p3.Value = AcadYear;
            SqlParameter p4 = new SqlParameter("@LMSProductCode", SqlDbType.VarChar);
            p4.Value = LMSProduct;
            //SqlParameter p7 = new SqlParameter("@BatchCode", SqlDbType.VarChar);
            //p7.Value = BatchCode;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GET_BATCH_LIST", p, p1, p2, p3, p4));
        }

        public static DataSet Get_notinbatch_Report(string Division, string Center, string Course, string AcadYear, string LMSProduct)
        {
            SqlParameter p = new SqlParameter("@Division", SqlDbType.VarChar);
            p.Value = Division;
            SqlParameter p1 = new SqlParameter("@Center", SqlDbType.VarChar);
            p1.Value = Center;
            SqlParameter p2 = new SqlParameter("@CourseCode", SqlDbType.VarChar);
            p2.Value = Course;
            SqlParameter p3 = new SqlParameter("@Acadyear", SqlDbType.VarChar);
            p3.Value = AcadYear;
            SqlParameter p4 = new SqlParameter("@LMSProductCode", SqlDbType.VarChar);
            p4.Value = LMSProduct;
            //SqlParameter p7 = new SqlParameter("@BatchCode", SqlDbType.VarChar);
            //p7.Value = BatchCode;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GET_STUDENT_LIST_NIBATCH", p, p1, p2, p3, p4));
        }

        public static DataSet Get_lastsiplogin_Report(string Division, string Center, string Course, string AcadYear, string LMSProduct)
        {
            SqlParameter p = new SqlParameter("@divisioncode", SqlDbType.VarChar);
            p.Value = Division;
            SqlParameter p1 = new SqlParameter("@centercode", SqlDbType.VarChar);
            p1.Value = Center;
            SqlParameter p2 = new SqlParameter("@coursecode", SqlDbType.VarChar);
            p2.Value = Course;
            SqlParameter p3 = new SqlParameter("@acadyear", SqlDbType.VarChar);
            p3.Value = AcadYear;
            SqlParameter p4 = new SqlParameter("@LMSProductCode", SqlDbType.VarChar);
            p4.Value = LMSProduct;
            //SqlParameter p7 = new SqlParameter("@BatchCode", SqlDbType.VarChar);
            //p7.Value = BatchCode;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USB_STUDENT_LOGIN_LASTLOGIN", p, p1, p2, p3, p4));
        }

        //added by sujeer--08-12-2017
        public static DataSet Get_studentbypayment_Report(int Flag, string Userid, string Division, string Center, string Course, string AcadYear, string LMSProduct, string BatchCode)
        {
            SqlParameter p = new SqlParameter("@flag", SqlDbType.Int);
            p.Value = Flag;
            SqlParameter p1 = new SqlParameter("@user_id", SqlDbType.VarChar);
            p1.Value = Userid;
            SqlParameter p2 = new SqlParameter("@Division", SqlDbType.VarChar);
            p2.Value = Division;
            SqlParameter p3 = new SqlParameter("@Center", SqlDbType.VarChar);
            p3.Value = Center;
            SqlParameter p4 = new SqlParameter("@Course", SqlDbType.VarChar);
            p4.Value = Course;
            SqlParameter p5 = new SqlParameter("@AcadYear", SqlDbType.VarChar);
            p5.Value = AcadYear;
            SqlParameter p6 = new SqlParameter("@LMSProduct", SqlDbType.VarChar);
            p6.Value = LMSProduct;
            SqlParameter p7 = new SqlParameter("@BatchCode", SqlDbType.VarChar);
            p7.Value = BatchCode;

            //return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_RPT_Replication_Report_payment_Received", p, p1, p2, p3, p4, p5, p6, p7));
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_RPT_Replication_Report_payment_Received_20220113_Tan", p, p1, p2, p3, p4, p5, p6, p7));
        }

        //added 06102020
        public static DataSet Get_Online_Test_Rport(string fromdate,string todate)
        {
            SqlParameter p = new SqlParameter("@Fromdate", SqlDbType.VarChar);
            p.Value = fromdate;
            SqlParameter p1 = new SqlParameter("@Todate", SqlDbType.VarChar);
            p1.Value = todate;
            //SqlParameter p1 = new SqlParameter("@user_id", SqlDbType.VarChar);
            //p1.Value = Userid;
            //SqlParameter p2 = new SqlParameter("@Fromdate", SqlDbType.VarChar);
            //p2.Value = fromdate;



            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Get_Online_Test_Registration_Details", p,p1));
        }

    }
}
