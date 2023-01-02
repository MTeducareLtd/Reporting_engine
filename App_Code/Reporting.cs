using System.Linq;
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
/// <summary>
/// Summary description for Reporting
/// </summary>
/// 
namespace ShoppingCart.BL
{
    public class Reporting
    {
        public static DataSet GetUser_Company_Division_Zone_Center(int Flag, string Userid, string Divisioncode, string Zonecode, string Companycode)
        {
            SqlParameter p = new SqlParameter("@flag", SqlDbType.Int);
            p.Value = Flag;
            SqlParameter p1 = new SqlParameter("@user_id", SqlDbType.VarChar);
            p1.Value = Userid;
            SqlParameter p2 = new SqlParameter("@division_code", SqlDbType.VarChar);
            p2.Value = Divisioncode;
            SqlParameter p3 = new SqlParameter("@Zone_code", SqlDbType.VarChar);
            p3.Value = Zonecode;
            SqlParameter p4 = new SqlParameter("@Company_Code", SqlDbType.VarChar);
            p4.Value = Companycode;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Rpt_GetUser_Company_Division_Zone_Center", p, p1, p2, p3, p4));
        }
        public static DataSet GetRequestType()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Rpt_GetAllRequesttype"));
        }
        public static DataSet GetAllAcadyear()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetAcadyear"));
        }



        //for course vinod
        public static DataSet GetAllCourses()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "[Usp_GetCourseName]"));
        }

        //

        //for Region Vinod

        public static DataSet GetAllCity()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "[Usp_GetCityName]"));
        }

        //


        // for app registration data  vinod
        public static DataSet GetAppRegistration_Details(string CourseCode, string RegiCode, string PromoCode, string StudentName, string PhoneNumber, string EmailId, string Fromdate, string Todate)
        {
            SqlParameter p = new SqlParameter("@CourseCode", SqlDbType.VarChar);
            p.Value = CourseCode;
            SqlParameter p1 = new SqlParameter("@RegionCode", SqlDbType.VarChar);
            p1.Value = RegiCode;

            SqlParameter p2 = new SqlParameter("@PromoCode", SqlDbType.VarChar);
            p2.Value = PromoCode;

            SqlParameter p3 = new SqlParameter("@StudentName", SqlDbType.VarChar);
            p3.Value = StudentName;

            SqlParameter p4 = new SqlParameter("@PhoneNumber", SqlDbType.VarChar);
            p4.Value = PhoneNumber;

            SqlParameter p5 = new SqlParameter("@EmailId", SqlDbType.VarChar);
            p5.Value = EmailId;

            SqlParameter p6 = new SqlParameter("@Fromdate", SqlDbType.VarChar);
            p6.Value = Fromdate;

            SqlParameter p7 = new SqlParameter("@Todate", SqlDbType.VarChar);
            p7.Value = Todate;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "[Usp_GetAppRegistration_Data]", p, p1, p2, p3, p4, p5, p6, p7));
        }


        //






















        public static DataSet GetAllPayPlan()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllPay_Plan"));
        }
        public static DataSet GetStatus()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Rpt_GetAccountStatus"));
        }
        public static DataSet GetChequeStatus()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Rpt_Get_Cheque_Status"));
        }
        public static DataSet GetStreamby_Center_AcademicYear_All(string CenterCode, string AcademicYear, string CompanyCode, string DivisionCode, string Zonecode)
        {
            SqlParameter p = new SqlParameter("@Center_Code", SqlDbType.VarChar);
            p.Value = CenterCode;
            SqlParameter p1 = new SqlParameter("@AcadYear", SqlDbType.VarChar);
            p1.Value = AcademicYear;
            SqlParameter p2 = new SqlParameter("@CompanyCode", SqlDbType.VarChar);
            p2.Value = CompanyCode;
            SqlParameter p3 = new SqlParameter("@DivisionCode", SqlDbType.VarChar);
            p3.Value = DivisionCode;
            SqlParameter p4 = new SqlParameter("@ZoneCode", SqlDbType.VarChar);
            p4.Value = Zonecode;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_rpt_getstream_byCenter_Acadyear_All", p, p1, p2, p3, p4));
        }
        public static DataSet GetAdmissionCount(string Reporttype, string Flag, string CompanyCode, string DivisionCode,
            string ZoneCode, string centerCode, string Acadyear, string fdate, string tdate, string userid, string stream)
        {
            SqlParameter p = new SqlParameter("@Reporttype", SqlDbType.VarChar);
            p.Value = Reporttype;
            SqlParameter p1 = new SqlParameter("@flag", SqlDbType.VarChar);
            p1.Value = Flag;
            SqlParameter p2 = new SqlParameter("@CompanyCode", SqlDbType.VarChar);
            p2.Value = CompanyCode;
            SqlParameter p3 = new SqlParameter("@DivisionCode", SqlDbType.VarChar);
            p3.Value = DivisionCode;
            SqlParameter p4 = new SqlParameter("@ZoneCode", SqlDbType.VarChar);
            p4.Value = ZoneCode;
            SqlParameter p5 = new SqlParameter("@CentreCode", SqlDbType.VarChar);
            p5.Value = centerCode;
            SqlParameter p6 = new SqlParameter("@Acadyear", SqlDbType.VarChar);
            p6.Value = Acadyear;
            SqlParameter p7 = new SqlParameter("@fdate", SqlDbType.VarChar);
            p7.Value = fdate;
            SqlParameter p8 = new SqlParameter("@tdate", SqlDbType.VarChar);
            p8.Value = tdate;
            SqlParameter p9 = new SqlParameter("@userid", SqlDbType.VarChar);
            p9.Value = userid;
            SqlParameter p10 = new SqlParameter("@StreamCode", SqlDbType.VarChar);
            p10.Value = stream;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Rpt_AdmissionCount_Annual", p, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10));

        }

        public static DataSet GetPaymentDetails(string Reporttype, string Flag, string CompanyCode, string DivisionCode,
          string ZoneCode, string centerCode, string Acadyear, string userid, string stream, string fdate, string tdate, string payplan, string status, string sbentrycode)
        {
            SqlParameter p = new SqlParameter("@Reporttype", SqlDbType.VarChar);
            p.Value = Reporttype;
            SqlParameter p1 = new SqlParameter("@flag", SqlDbType.VarChar);
            p1.Value = Flag;
            SqlParameter p2 = new SqlParameter("@CompanyCode", SqlDbType.VarChar);
            p2.Value = CompanyCode;
            SqlParameter p3 = new SqlParameter("@DivisionCode", SqlDbType.VarChar);
            p3.Value = DivisionCode;
            SqlParameter p4 = new SqlParameter("@ZoneCode", SqlDbType.VarChar);
            p4.Value = ZoneCode;
            SqlParameter p5 = new SqlParameter("@CentreCode", SqlDbType.VarChar);
            p5.Value = centerCode;
            SqlParameter p6 = new SqlParameter("@Acadyear", SqlDbType.VarChar);
            p6.Value = Acadyear;
            SqlParameter p7 = new SqlParameter("@userid", SqlDbType.VarChar);
            p7.Value = userid;
            SqlParameter p8 = new SqlParameter("@StreamCode", SqlDbType.VarChar);
            p8.Value = stream;
            SqlParameter p9 = new SqlParameter("@fdate", SqlDbType.VarChar);
            p9.Value = fdate;
            SqlParameter p10 = new SqlParameter("@tdate", SqlDbType.VarChar);
            p10.Value = tdate;
            SqlParameter p11 = new SqlParameter("@payplan", SqlDbType.VarChar);
            p11.Value = payplan;
            SqlParameter p12 = new SqlParameter("@status", SqlDbType.VarChar);
            p12.Value = status;
            SqlParameter p13 = new SqlParameter("@SBEntrycode", SqlDbType.VarChar);
            p13.Value = sbentrycode;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Rpt_PaymentDetails", p, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13));

        }

        public static DataSet GetChequeDetails(string CompanyCode, string DivisionCode,
     string ZoneCode, string centerCode, string Acadyear, string fdate, string tdate, string userid, string stream, string chequestatus, string sbentrycode, string chequeno, string flag)
        {

            SqlParameter p1 = new SqlParameter("@CompanyCode", SqlDbType.VarChar);
            p1.Value = CompanyCode;
            SqlParameter p2 = new SqlParameter("@DivisionCode", SqlDbType.VarChar);
            p2.Value = DivisionCode;
            SqlParameter p3 = new SqlParameter("@ZoneCode", SqlDbType.VarChar);
            p3.Value = ZoneCode;
            SqlParameter p4 = new SqlParameter("@CentreCode", SqlDbType.VarChar);
            p4.Value = centerCode;
            SqlParameter p5 = new SqlParameter("@Acadyear", SqlDbType.VarChar);
            p5.Value = Acadyear;
            SqlParameter p6 = new SqlParameter("@fdate", SqlDbType.VarChar);
            p6.Value = fdate;
            SqlParameter p7 = new SqlParameter("@tdate", SqlDbType.VarChar);
            p7.Value = tdate;
            SqlParameter p8 = new SqlParameter("@userid", SqlDbType.VarChar);
            p8.Value = userid;
            SqlParameter p9 = new SqlParameter("@StreamCode", SqlDbType.VarChar);
            p9.Value = stream;
            SqlParameter p10 = new SqlParameter("@chequestatus", SqlDbType.VarChar);
            p10.Value = chequestatus;
            SqlParameter p11 = new SqlParameter("@sbentrycode", SqlDbType.VarChar);
            p11.Value = sbentrycode;
            SqlParameter p12 = new SqlParameter("@chequeno", SqlDbType.VarChar);
            p12.Value = chequeno;
            SqlParameter p13 = new SqlParameter("@flag", SqlDbType.VarChar);
            p13.Value = flag;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Rpt_Chequedetails", p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13));

        }

        public static DataSet GetChequeOverDue(string CompanyCode, string DivisionCode,
   string ZoneCode, string centerCode, string Acadyear, string fdate, string tdate, string userid, string stream)
        {

            SqlParameter p1 = new SqlParameter("@CompanyCode", SqlDbType.VarChar);
            p1.Value = CompanyCode;
            SqlParameter p2 = new SqlParameter("@DivisionCode", SqlDbType.VarChar);
            p2.Value = DivisionCode;
            SqlParameter p3 = new SqlParameter("@ZoneCode", SqlDbType.VarChar);
            p3.Value = ZoneCode;
            SqlParameter p4 = new SqlParameter("@CentreCode", SqlDbType.VarChar);
            p4.Value = centerCode;
            SqlParameter p5 = new SqlParameter("@Acadyear", SqlDbType.VarChar);
            p5.Value = Acadyear;
            SqlParameter p6 = new SqlParameter("@fdate", SqlDbType.VarChar);
            p6.Value = fdate;
            SqlParameter p7 = new SqlParameter("@tdate", SqlDbType.VarChar);
            p7.Value = tdate;
            SqlParameter p8 = new SqlParameter("@userid", SqlDbType.VarChar);
            p8.Value = userid;
            SqlParameter p9 = new SqlParameter("@StreamCode", SqlDbType.VarChar);
            p9.Value = stream;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_Rpt_Cheque_Overdue", p1, p2, p3, p4, p5, p6, p7, p8, p9));

        }
        public static DataSet GetChequeOverdueCourseDuration(string CompanyCode, string DivisionCode, string ZoneCode, string centerCode, string Acadyear, string userid, string stream, string condition)
        {

            SqlParameter p1 = new SqlParameter("@CompanyCode", SqlDbType.VarChar);
            p1.Value = CompanyCode;
            SqlParameter p2 = new SqlParameter("@DivisionCode", SqlDbType.VarChar);
            p2.Value = DivisionCode;
            SqlParameter p3 = new SqlParameter("@ZoneCode", SqlDbType.VarChar);
            p3.Value = ZoneCode;
            SqlParameter p4 = new SqlParameter("@CentreCode", SqlDbType.VarChar);
            p4.Value = centerCode;
            SqlParameter p5 = new SqlParameter("@Acadyear", SqlDbType.VarChar);
            p5.Value = Acadyear;
            SqlParameter p6 = new SqlParameter("@userid", SqlDbType.VarChar);
            p6.Value = userid;
            SqlParameter p7 = new SqlParameter("@StreamCode", SqlDbType.VarChar);
            p7.Value = stream;
            SqlParameter p8 = new SqlParameter("@Condition", SqlDbType.VarChar);
            p8.Value = condition;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_rpt_cheque_overdue_course_duration", p1, p2, p3, p4, p5, p6, p7, p8));

        }
        public static DataSet GetStreamWiseCount(string Reporttype, string Flag, string CompanyCode, string DivisionCode,
          string ZoneCode, string centerCode, string Acadyear, string fdate, string tdate, string userid, string stream)
        {
            SqlParameter p = new SqlParameter("@Reporttype", SqlDbType.VarChar);
            p.Value = Reporttype;
            SqlParameter p1 = new SqlParameter("@flag", SqlDbType.VarChar);
            p1.Value = Flag;
            SqlParameter p2 = new SqlParameter("@CompanyCode", SqlDbType.VarChar);
            p2.Value = CompanyCode;
            SqlParameter p3 = new SqlParameter("@DivisionCode", SqlDbType.VarChar);
            p3.Value = DivisionCode;
            SqlParameter p4 = new SqlParameter("@ZoneCode", SqlDbType.VarChar);
            p4.Value = ZoneCode;
            SqlParameter p5 = new SqlParameter("@CentreCode", SqlDbType.VarChar);
            p5.Value = centerCode;
            SqlParameter p6 = new SqlParameter("@Acadyear", SqlDbType.VarChar);
            p6.Value = Acadyear;
            SqlParameter p7 = new SqlParameter("@fdate", SqlDbType.VarChar);
            p7.Value = fdate;
            SqlParameter p8 = new SqlParameter("@tdate", SqlDbType.VarChar);
            p8.Value = tdate;
            SqlParameter p9 = new SqlParameter("@userid", SqlDbType.VarChar);
            p9.Value = userid;
            SqlParameter p10 = new SqlParameter("@StreamCode", SqlDbType.VarChar);
            p10.Value = stream;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_rpt_admission_stream_count", p, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10));

        }

        public static DataSet GetSubjectWiseCount(string Reporttype, string Flag, string CompanyCode, string DivisionCode,
              string ZoneCode, string centerCode, string Acadyear, string userid, string stream, string EventFrom_Date, string EventTo_Date)
        {
            SqlParameter p = new SqlParameter("@Reporttype", SqlDbType.VarChar);
            p.Value = Reporttype;
            SqlParameter p1 = new SqlParameter("@flag", SqlDbType.VarChar);
            p1.Value = Flag;
            SqlParameter p2 = new SqlParameter("@CompanyCode", SqlDbType.VarChar);
            p2.Value = CompanyCode;
            SqlParameter p3 = new SqlParameter("@DivisionCode", SqlDbType.VarChar);
            p3.Value = DivisionCode;
            SqlParameter p4 = new SqlParameter("@ZoneCode", SqlDbType.VarChar);
            p4.Value = ZoneCode;
            SqlParameter p5 = new SqlParameter("@CentreCode", SqlDbType.VarChar);
            p5.Value = centerCode;
            SqlParameter p6 = new SqlParameter("@Acadyear", SqlDbType.VarChar);
            p6.Value = Acadyear;
            SqlParameter p7 = new SqlParameter("@userid", SqlDbType.VarChar);
            p7.Value = userid;
            SqlParameter p8 = new SqlParameter("@StreamCode", SqlDbType.VarChar);
            p8.Value = stream;
            SqlParameter p9 = new SqlParameter("@EventFrom_Date", SqlDbType.VarChar);
            p9.Value = EventFrom_Date;
            SqlParameter p10 = new SqlParameter("@EventTo_Date", SqlDbType.VarChar);
            p10.Value = EventTo_Date;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_rpt_Subject_Wise", p, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10));

        }

        public static DataSet GET_LEAD_DETAILS_ZONEWISE(string Zonecode, string Divisioncode, string Fromdate, string Todate)
        {
            SqlParameter p = new SqlParameter("@Zone_Code", SqlDbType.VarChar);
            p.Value = Zonecode;
            SqlParameter p1 = new SqlParameter("@Division_Code", SqlDbType.VarChar);
            p1.Value = Divisioncode;
            SqlParameter p2 = new SqlParameter("@From_Date", SqlDbType.VarChar);
            p2.Value = Fromdate;
            SqlParameter p3 = new SqlParameter("@To_Date", SqlDbType.VarChar);
            p3.Value = Todate;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GET_LEAD_DETAILS_ZONEWISE", p, p1, p2, p3));
        }

        public static DataSet GET_OPPORTUNITY_DETAILS_ZONEWISE(string Zonecode, string Divisioncode, string Fromdate, string Todate)
        {
            SqlParameter p = new SqlParameter("@Zone_Code", SqlDbType.VarChar);
            p.Value = Zonecode;
            SqlParameter p1 = new SqlParameter("@Division_Code", SqlDbType.VarChar);
            p1.Value = Divisioncode;
            SqlParameter p2 = new SqlParameter("@From_Date", SqlDbType.VarChar);
            p2.Value = Fromdate;
            SqlParameter p3 = new SqlParameter("@To_Date", SqlDbType.VarChar);
            p3.Value = Todate;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GET_OPPORTUNITY_DETAILS_ZONEWISE", p, p1, p2, p3));
        }

        public static DataSet GET_LEAD_DETAILS_CENTERWISE(string Zonecode, string Divisioncode, string Centercode, string Fromdate, string Todate)
        {
            SqlParameter p = new SqlParameter("@Zone_Code", SqlDbType.VarChar);
            p.Value = Zonecode;
            SqlParameter p1 = new SqlParameter("@Division_Code", SqlDbType.VarChar);
            p1.Value = Divisioncode;
            SqlParameter p2 = new SqlParameter("@Center_Code", SqlDbType.VarChar);
            p2.Value = Centercode;
            SqlParameter p3 = new SqlParameter("@From_Date", SqlDbType.VarChar);
            p3.Value = Fromdate;
            SqlParameter p4 = new SqlParameter("@To_Date", SqlDbType.VarChar);
            p4.Value = Todate;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GET_LEAD_DETAILS_CENTERWISE", p, p1, p2, p3, p4));
        }

        public static DataSet GET_OPPORTUNITY_DETAILS_CENTERWISE(string Zonecode, string Divisioncode, string Centercode, string Fromdate, string Todate)
        {
            SqlParameter p = new SqlParameter("@Zone_Code", SqlDbType.VarChar);
            p.Value = Zonecode;
            SqlParameter p1 = new SqlParameter("@Division_Code", SqlDbType.VarChar);
            p1.Value = Divisioncode;
            SqlParameter p2 = new SqlParameter("@Center_Code", SqlDbType.VarChar);
            p2.Value = Centercode;
            SqlParameter p3 = new SqlParameter("@From_Date", SqlDbType.VarChar);
            p3.Value = Fromdate;
            SqlParameter p4 = new SqlParameter("@To_Date", SqlDbType.VarChar);
            p4.Value = Todate;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GET_OPPORTUNITY_DETAILS_CENTERWISE", p, p1, p2, p3, p4));
        }
        public static DataSet GetCollectionCount(string Reporttype, string Flag, string CompanyCode, string DivisionCode,
          string ZoneCode, string centerCode, string Acadyear, string userid, string stream)
        {
            SqlParameter p = new SqlParameter("@Reporttype", SqlDbType.VarChar);
            p.Value = Reporttype;
            SqlParameter p1 = new SqlParameter("@flag", SqlDbType.VarChar);
            p1.Value = Flag;
            SqlParameter p2 = new SqlParameter("@CompanyCode", SqlDbType.VarChar);
            p2.Value = CompanyCode;
            SqlParameter p3 = new SqlParameter("@DivisionCode", SqlDbType.VarChar);
            p3.Value = DivisionCode;
            SqlParameter p4 = new SqlParameter("@ZoneCode", SqlDbType.VarChar);
            p4.Value = ZoneCode;
            SqlParameter p5 = new SqlParameter("@CentreCode", SqlDbType.VarChar);
            p5.Value = centerCode;
            SqlParameter p6 = new SqlParameter("@Acadyear", SqlDbType.VarChar);
            p6.Value = Acadyear;
            SqlParameter p7 = new SqlParameter("@userid", SqlDbType.VarChar);
            p7.Value = userid;
            SqlParameter p8 = new SqlParameter("@StreamCode", SqlDbType.VarChar);
            p8.Value = stream;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Rpt_CollectionCount", p, p1, p2, p3, p4, p5, p6, p7, p8));

        }


        public static DataSet GetCollectionCountCenter(string Reporttype, string Flag, string CompanyCode, string DivisionCode,
          string ZoneCode, string centerCode, string Acadyear, string userid)
        {
            SqlParameter p = new SqlParameter("@Reporttype", SqlDbType.VarChar);
            p.Value = Reporttype;
            SqlParameter p1 = new SqlParameter("@flag", SqlDbType.VarChar);
            p1.Value = Flag;
            SqlParameter p2 = new SqlParameter("@CompanyCode", SqlDbType.VarChar);
            p2.Value = CompanyCode;
            SqlParameter p3 = new SqlParameter("@DivisionCode", SqlDbType.VarChar);
            p3.Value = DivisionCode;
            SqlParameter p4 = new SqlParameter("@ZoneCode", SqlDbType.VarChar);
            p4.Value = ZoneCode;
            SqlParameter p5 = new SqlParameter("@CentreCode", SqlDbType.VarChar);
            p5.Value = centerCode;
            SqlParameter p6 = new SqlParameter("@Acadyear", SqlDbType.VarChar);
            p6.Value = Acadyear;
            SqlParameter p7 = new SqlParameter("@userid", SqlDbType.VarChar);
            p7.Value = userid;


            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Rpt_CollectionCount_CenterWise", p, p1, p2, p3, p4, p5, p6, p7));

        }
        
        public static DataSet GetDiscountConcessionRequest(string division, string zone, string stream, string center, string acadyear, string requesttype, string requeststatus, string sbentrycode, string fdate, string tdate)
        {
            SqlParameter p = new SqlParameter("@DivisionCode", SqlDbType.VarChar);p.Value = division;
            SqlParameter p1 = new SqlParameter("@ZoneCode", SqlDbType.VarChar);p1.Value = zone;
            SqlParameter p2 = new SqlParameter("@StreamCode", SqlDbType.VarChar); p2.Value = stream;
            SqlParameter p3 = new SqlParameter("@CentreCode", SqlDbType.VarChar); p3.Value = center;
            SqlParameter p4 = new SqlParameter("@acadyear", SqlDbType.VarChar); p4.Value = acadyear;
            SqlParameter p5 = new SqlParameter("@RequestType", SqlDbType.VarChar); p5.Value = requesttype;
            SqlParameter p6 = new SqlParameter("@RequestStatus", SqlDbType.VarChar); p6.Value = requeststatus;
            SqlParameter p7 = new SqlParameter("@sbentrycode", SqlDbType.VarChar); p7.Value = sbentrycode;
            SqlParameter p8= new SqlParameter("@fdate", SqlDbType.VarChar); p8.Value = fdate;
            SqlParameter p9 = new SqlParameter("@tdate", SqlDbType.VarChar);p9.Value = tdate;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Rpt_Get_Discount_Concession_Request", p, p1, p2, p3, p4, p5, p6, p7, p8, p9));

        }

        public static DataSet GetStudentDetails(string reporttype, string flag, string companycode, string division, string zone, string center, string acadyear, string userid, string streamcode)
        {
            SqlParameter p = new SqlParameter("@Reporttype", SqlDbType.VarChar);
            p.Value = reporttype;
            SqlParameter p1 = new SqlParameter("@flag", SqlDbType.VarChar);
            p1.Value = flag;
            SqlParameter p2 = new SqlParameter("@CompanyCode", SqlDbType.VarChar);
            p2.Value = companycode;
            SqlParameter p3 = new SqlParameter("@DivisionCode", SqlDbType.VarChar);
            p3.Value = division;
            SqlParameter p4 = new SqlParameter("@ZoneCode", SqlDbType.VarChar);
            p4.Value = zone;
            SqlParameter p5 = new SqlParameter("@CentreCode", SqlDbType.VarChar);
            p5.Value = center;
            SqlParameter p6 = new SqlParameter("@Acadyear", SqlDbType.VarChar);
            p6.Value = acadyear;
            SqlParameter p7 = new SqlParameter("@userid", SqlDbType.VarChar);
            p7.Value = userid;
            SqlParameter p8 = new SqlParameter("@StreamCode", SqlDbType.VarChar);
            p8.Value = streamcode;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Rpt_GetStudentDetails", p, p1, p2, p3, p4, p5, p6, p7, p8));


        }
        public static DataSet GetStudentLMSData(string reporttype, string flag, string companycode, string division, string zone, string center, string acadyear, string userid, string streamcode, string fromdate, string todate)
        {
            SqlParameter p = new SqlParameter("@Reporttype", SqlDbType.VarChar);
            p.Value = reporttype;
            SqlParameter p1 = new SqlParameter("@flag", SqlDbType.VarChar);
            p1.Value = flag;
            SqlParameter p2 = new SqlParameter("@CompanyCode", SqlDbType.VarChar);
            p2.Value = companycode;
            SqlParameter p3 = new SqlParameter("@DivisionCode", SqlDbType.VarChar);
            p3.Value = division;
            SqlParameter p4 = new SqlParameter("@ZoneCode", SqlDbType.VarChar);
            p4.Value = zone;
            SqlParameter p5 = new SqlParameter("@CentreCode", SqlDbType.VarChar);
            p5.Value = center;
            SqlParameter p6 = new SqlParameter("@Acadyear", SqlDbType.VarChar);
            p6.Value = acadyear;
            SqlParameter p7 = new SqlParameter("@userid", SqlDbType.VarChar);
            p7.Value = userid;
            SqlParameter p8 = new SqlParameter("@StreamCode", SqlDbType.VarChar);
            p8.Value = streamcode;
            SqlParameter p9 = new SqlParameter("@fdate", SqlDbType.VarChar);
            p9.Value = fromdate;
            SqlParameter p10 = new SqlParameter("@tdate", SqlDbType.VarChar);
            p10.Value = todate;


            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "[Usp_Rpt_Get_Lms_Data]", p, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10));


        }

        public static DataSet GetLeadSummary(string Flag, string CompanyCode, string DivisionCode, string ZoneCode, string centerCode, string Acadyear, string userid)
        {

            SqlParameter p1 = new SqlParameter("@Flag", SqlDbType.VarChar);
            p1.Value = Flag;
            SqlParameter p2 = new SqlParameter("@company", SqlDbType.VarChar);
            p2.Value = CompanyCode;
            SqlParameter p3 = new SqlParameter("@Division", SqlDbType.VarChar);
            p3.Value = DivisionCode;
            SqlParameter p4 = new SqlParameter("@Zone", SqlDbType.VarChar);
            p4.Value = ZoneCode;
            SqlParameter p5 = new SqlParameter("@Center", SqlDbType.VarChar);
            p5.Value = centerCode;
            SqlParameter p6 = new SqlParameter("@Acad_Year", SqlDbType.VarChar);
            p6.Value = Acadyear;
            SqlParameter p7 = new SqlParameter("@userid", SqlDbType.VarChar);
            p7.Value = userid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Rpt_LeadSummary", p1, p2, p3, p4, p5, p6, p7));

        }

        public static DataSet GetPendingLeadFollowUp(string Flag, string CompanyCode, string DivisionCode, string ZoneCode, string centerCode, string Acadyear, string userid)
        {

            SqlParameter p1 = new SqlParameter("@Flag", SqlDbType.VarChar);
            p1.Value = Flag;
            SqlParameter p2 = new SqlParameter("@company", SqlDbType.VarChar);
            p2.Value = CompanyCode;
            SqlParameter p3 = new SqlParameter("@Division", SqlDbType.VarChar);
            p3.Value = DivisionCode;
            SqlParameter p4 = new SqlParameter("@Zone", SqlDbType.VarChar);
            p4.Value = ZoneCode;
            SqlParameter p5 = new SqlParameter("@Center", SqlDbType.VarChar);
            p5.Value = centerCode;
            SqlParameter p6 = new SqlParameter("@Acad_Year", SqlDbType.VarChar);
            p6.Value = Acadyear;
            SqlParameter p7 = new SqlParameter("@userid", SqlDbType.VarChar);
            p7.Value = userid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Rpt_PendingLeadFollowupDetail", p1, p2, p3, p4, p5, p6, p7));

        }


        public static DataSet GetOpportunitySummary(string Flag, string CompanyCode, string DivisionCode, string ZoneCode, string centerCode, string Acadyear, string userid)
        {

            SqlParameter p1 = new SqlParameter("@Flag", SqlDbType.VarChar);
            p1.Value = Flag;
            SqlParameter p2 = new SqlParameter("@company", SqlDbType.VarChar);
            p2.Value = CompanyCode;
            SqlParameter p3 = new SqlParameter("@Division", SqlDbType.VarChar);
            p3.Value = DivisionCode;
            SqlParameter p4 = new SqlParameter("@Zone", SqlDbType.VarChar);
            p4.Value = ZoneCode;
            SqlParameter p5 = new SqlParameter("@Center", SqlDbType.VarChar);
            p5.Value = centerCode;
            SqlParameter p6 = new SqlParameter("@Acad_Year", SqlDbType.VarChar);
            p6.Value = Acadyear;
            SqlParameter p7 = new SqlParameter("@userid", SqlDbType.VarChar);
            p7.Value = userid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Rpt_OpportunitySummary", p1, p2, p3, p4, p5, p6, p7));

        }

        public static DataSet GetOpportunityVsAdmissionSummary(string Flag, string CompanyCode, string DivisionCode, string ZoneCode, string centerCode, string Acadyear, string userid)
        {
            SqlParameter p1 = new SqlParameter("@Flag", SqlDbType.VarChar);
            p1.Value = Flag;
            SqlParameter p2 = new SqlParameter("@company", SqlDbType.VarChar);
            p2.Value = CompanyCode;
            SqlParameter p3 = new SqlParameter("@Division", SqlDbType.VarChar);
            p3.Value = DivisionCode;
            SqlParameter p4 = new SqlParameter("@Zone", SqlDbType.VarChar);
            p4.Value = ZoneCode;
            SqlParameter p5 = new SqlParameter("@Center", SqlDbType.VarChar);
            p5.Value = centerCode;
            SqlParameter p6 = new SqlParameter("@Acad_Year", SqlDbType.VarChar);
            p6.Value = Acadyear;
            SqlParameter p7 = new SqlParameter("@userid", SqlDbType.VarChar);
            p7.Value = userid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Rpt_OpportunityVsAdmission", p1, p2, p3, p4, p5, p6, p7));

        }

        public static DataSet GetDayWiseOpportunity(string Flag, string CompanyCode, string DivisionCode, string ZoneCode, string centerCode, string Acadyear, string userid, string OppDate)
        {
            SqlParameter p1 = new SqlParameter("@Flag", SqlDbType.VarChar);
            p1.Value = Flag;
            SqlParameter p2 = new SqlParameter("@company", SqlDbType.VarChar);
            p2.Value = CompanyCode;
            SqlParameter p3 = new SqlParameter("@Division", SqlDbType.VarChar);
            p3.Value = DivisionCode;
            SqlParameter p4 = new SqlParameter("@Zone", SqlDbType.VarChar);
            p4.Value = ZoneCode;
            SqlParameter p5 = new SqlParameter("@Center", SqlDbType.VarChar);
            p5.Value = centerCode;
            SqlParameter p6 = new SqlParameter("@Acad_Year", SqlDbType.VarChar);
            p6.Value = Acadyear;
            SqlParameter p7 = new SqlParameter("@userid", SqlDbType.VarChar);
            p7.Value = userid;
            SqlParameter p8 = new SqlParameter("@OppDate", SqlDbType.VarChar);
            p8.Value = OppDate;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Rpt_DaywiseOpportunityCount", p1, p2, p3, p4, p5, p6, p7, p8));

        }

        public static DataSet GetDayWiseAdmission(string Flag, string CompanyCode, string DivisionCode, string ZoneCode, string centerCode, string Acadyear, string userid, string AdmissionDate)
        {
            SqlParameter p1 = new SqlParameter("@Flag", SqlDbType.VarChar);
            p1.Value = Flag;
            SqlParameter p2 = new SqlParameter("@company", SqlDbType.VarChar);
            p2.Value = CompanyCode;
            SqlParameter p3 = new SqlParameter("@Division", SqlDbType.VarChar);
            p3.Value = DivisionCode;
            SqlParameter p4 = new SqlParameter("@Zone", SqlDbType.VarChar);
            p4.Value = ZoneCode;
            SqlParameter p5 = new SqlParameter("@Center", SqlDbType.VarChar);
            p5.Value = centerCode;
            SqlParameter p6 = new SqlParameter("@Acad_Year", SqlDbType.VarChar);
            p6.Value = Acadyear;
            SqlParameter p7 = new SqlParameter("@userid", SqlDbType.VarChar);
            p7.Value = userid;
            SqlParameter p8 = new SqlParameter("@AdmissionDate", SqlDbType.VarChar);
            p8.Value = AdmissionDate;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Rpt_DaywiseAdmissionCount", p1, p2, p3, p4, p5, p6, p7, p8));

        }

        public static DataSet GetLecturedetails(string CompanyCode, string DivisionCode,
                   string ZoneCode, string centerCode, string Acadyear, string fdate, string tdate)
        {

            SqlParameter p1 = new SqlParameter("@CompanyCode", SqlDbType.VarChar);
            p1.Value = CompanyCode;
            SqlParameter p2 = new SqlParameter("@DivisionCode", SqlDbType.VarChar);
            p2.Value = DivisionCode;
            SqlParameter p3 = new SqlParameter("@ZoneCode", SqlDbType.VarChar);
            p3.Value = ZoneCode;
            SqlParameter p4 = new SqlParameter("@CentreCode", SqlDbType.VarChar);
            p4.Value = centerCode;
            SqlParameter p5 = new SqlParameter("@Acadyear", SqlDbType.VarChar);
            p5.Value = Acadyear;
            SqlParameter p6 = new SqlParameter("@fdate", SqlDbType.VarChar);
            p6.Value = fdate;
            SqlParameter p7 = new SqlParameter("@tdate", SqlDbType.VarChar);
            p7.Value = tdate;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Rpt_lecturewise_batch_Details", p1, p2, p3, p4, p5, p6, p7));

        }


        public static DataSet GetCentreCallingReport(int Flag, string campaign, 
                 string fromdate, string todate)
        {

            SqlParameter p1 = new SqlParameter("@Flag", SqlDbType.VarChar);
            p1.Value = Flag;
            SqlParameter p2 = new SqlParameter("@Campaign_Id", SqlDbType.VarChar);
            p2.Value = campaign;
           
            SqlParameter p4 = new SqlParameter("@FromDate", SqlDbType.VarChar);
            p4.Value = fromdate;
            SqlParameter p5 = new SqlParameter("@ToDate", SqlDbType.VarChar);
            p5.Value = todate;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_RPT_CAMPAIGN_CONTACT_CENTER_CALLING_REPORT", p1, p2,  p4,p5));

        }






        public static DataSet insertstreamdetails(string CompanyCode, string DivisionCode,
                  string centerCode, string StreamCode, string USERID)
        {

            SqlParameter p1 = new SqlParameter("@CompanyCode", SqlDbType.VarChar);
            p1.Value = CompanyCode;
            SqlParameter p2 = new SqlParameter("@DivisionCode", SqlDbType.VarChar);
            p2.Value = DivisionCode;
            SqlParameter p3 = new SqlParameter("@CentreCode", SqlDbType.VarChar);
            p3.Value = centerCode;
            SqlParameter p4 = new SqlParameter("@StreamCode", SqlDbType.VarChar);
            p4.Value = StreamCode;
            SqlParameter p5 = new SqlParameter("@USERID", SqlDbType.VarChar);
            p5.Value = USERID;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_POPULATE_PRODUCT_MASTER_FROM_SAP_TABLES", p1, p2, p3, p4, p5));

        }

        public static DataSet LeadreportSourcewise(string CompanyCode, string DivisionCode,
                   string ZoneCode, string centerCode, string Acadyear, string fdate, string tdate)
        {

            SqlParameter p1 = new SqlParameter("@CompanyCode", SqlDbType.VarChar);
            p1.Value = CompanyCode;
            SqlParameter p2 = new SqlParameter("@DivisionCode", SqlDbType.VarChar);
            p2.Value = DivisionCode;
            SqlParameter p3 = new SqlParameter("@ZoneCode", SqlDbType.VarChar);
            p3.Value = ZoneCode;
            SqlParameter p4 = new SqlParameter("@CentreCode", SqlDbType.VarChar);
            p4.Value = centerCode;
            SqlParameter p5 = new SqlParameter("@Acadyear", SqlDbType.VarChar);
            p5.Value = Acadyear;
            SqlParameter p6 = new SqlParameter("@fdate", SqlDbType.VarChar);
            p6.Value = fdate;
            SqlParameter p7 = new SqlParameter("@tdate", SqlDbType.VarChar);
            p7.Value = tdate;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Rpt_Leadreport_Sourcewise", p1, p2, p3, p4, p5, p6, p7));
        }

        public static DataSet GetLeaddetails(string CompanyCode, string DivisionCode,
                   string ZoneCode, string centerCode, string Acadyear, string fdate, string tdate)
        {

            SqlParameter p1 = new SqlParameter("@CompanyCode", SqlDbType.VarChar);
            p1.Value = CompanyCode;
            SqlParameter p2 = new SqlParameter("@DivisionCode", SqlDbType.VarChar);
            p2.Value = DivisionCode;
            SqlParameter p3 = new SqlParameter("@ZoneCode", SqlDbType.VarChar);
            p3.Value = ZoneCode;
            SqlParameter p4 = new SqlParameter("@CentreCode", SqlDbType.VarChar);
            p4.Value = centerCode;
            SqlParameter p5 = new SqlParameter("@Acadyear", SqlDbType.VarChar);
            p5.Value = Acadyear;
            SqlParameter p6 = new SqlParameter("@fdate", SqlDbType.VarChar);
            p6.Value = fdate;
            SqlParameter p7 = new SqlParameter("@tdate", SqlDbType.VarChar);
            p7.Value = tdate;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Rpt_Leadreport_Sourcewise_Deatiled", p1, p2, p3, p4, p5, p6, p7));

        }

        public static DataSet GetCentreCallingReport1(int Flag, string campaign, string user,
             string fromdate, string todate)
        {

            SqlParameter p1 = new SqlParameter("@Flag", SqlDbType.VarChar);
            p1.Value = Flag;
            SqlParameter p2 = new SqlParameter("@Campaign_Id", SqlDbType.VarChar);
            p2.Value = campaign;
            SqlParameter p3 = new SqlParameter("@user", SqlDbType.VarChar);
            p3.Value = user;
            SqlParameter p4 = new SqlParameter("@FromDate", SqlDbType.VarChar);
            p4.Value = fromdate;
            SqlParameter p5 = new SqlParameter("@ToDate", SqlDbType.VarChar);
            p5.Value = todate;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_RPT_CAMPAIGN_CONTACT_CENTER_CALLING_REPORT", p1, p2, p3, p4, p5));

        }

        //sagar code

        public static DataSet GetStudentData(string Company, string DivisionCode, string Center, string AcadYear,
           string Stream, string Flag, string UserCode)
        {
            SqlParameter p = new SqlParameter("@Company", SqlDbType.VarChar);
            p.Value = Company;
            SqlParameter p1 = new SqlParameter("@DivisionCode", SqlDbType.VarChar);
            p1.Value = DivisionCode;
            SqlParameter p2 = new SqlParameter("@Center", SqlDbType.VarChar);
            p2.Value = Center;
            SqlParameter p3 = new SqlParameter("@AcadYear", SqlDbType.VarChar);
            p3.Value = AcadYear;
            SqlParameter p4 = new SqlParameter("@Stream", SqlDbType.VarChar);
            p4.Value = Stream;
            SqlParameter p5 = new SqlParameter("@Flag", SqlDbType.VarChar);
            p5.Value = Flag;
            SqlParameter p6 = new SqlParameter("@UserCode", SqlDbType.VarChar);
            p6.Value = UserCode;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Student_Info_Account", p, p1, p2, p3, p4, p5, p6));

        }


        // Archana (15-03-2016)
        public static DataSet GetStudentCheque_Details(string DivisionCode, string Center, string ChequeStatus, string FromDate, string Todate)
        {
            SqlParameter p = new SqlParameter("@Division_Code", SqlDbType.VarChar);
            p.Value = DivisionCode;
            SqlParameter p1 = new SqlParameter("@Center_Code", SqlDbType.VarChar);
            p1.Value = Center;
            SqlParameter p2 = new SqlParameter("@Cheque_Status", SqlDbType.VarChar);
            p2.Value = ChequeStatus;
            SqlParameter p3 = new SqlParameter("@FromDate", SqlDbType.VarChar);
            p3.Value = FromDate;
            SqlParameter p4 = new SqlParameter("@Todate", SqlDbType.VarChar);
            p4.Value = Todate;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Rpt_Student_ChequeStatus", p, p1, p2, p3, p4));

        }
        public static DataSet Get_Center_ByDivision(int Flag, string Userid, string Divisioncode)
        {
            SqlParameter p = new SqlParameter("@flag", SqlDbType.Int);
            p.Value = Flag;
            SqlParameter p1 = new SqlParameter("@UserId", SqlDbType.VarChar);
            p1.Value = Userid;
            SqlParameter p2 = new SqlParameter("@DivisionCode", SqlDbType.VarChar);
            p2.Value = Divisioncode;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetCenterByDivision_TabStagging", p, p1, p2));
        }

        //added by sagar 15 mar 2017
        public static DataSet GetStudentdata_SubjectWise(string Company, string DivisionCode, string Center, string AcadYear,
        string Stream, string Flag, string UserCode)
        {
            SqlParameter p = new SqlParameter("@Company", SqlDbType.VarChar);
            p.Value = Company;
            SqlParameter p1 = new SqlParameter("@DivisionCode", SqlDbType.VarChar);
            p1.Value = DivisionCode;
            SqlParameter p2 = new SqlParameter("@Center", SqlDbType.VarChar);
            p2.Value = Center;
            SqlParameter p3 = new SqlParameter("@AcadYear", SqlDbType.VarChar);
            p3.Value = AcadYear;
            SqlParameter p4 = new SqlParameter("@Stream", SqlDbType.VarChar);
            p4.Value = Stream;
            SqlParameter p5 = new SqlParameter("@Flag", SqlDbType.VarChar);
            p5.Value = Flag;
            SqlParameter p6 = new SqlParameter("@UserCode", SqlDbType.VarChar);
            p6.Value = UserCode;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Rpt_Student_Subject_Group", p, p1, p2, p3, p4, p5, p6));

        }

        //added by Archana 19042017
        
        public static DataSet GetStudentCheque_Details1(string DivisionCode, string Center, string FromDate, string Todate)
        {
            SqlParameter p = new SqlParameter("@Division_Code", SqlDbType.VarChar);
            p.Value = DivisionCode;
            SqlParameter p1 = new SqlParameter("@Center_Code", SqlDbType.VarChar);
            p1.Value = Center;
            SqlParameter p2 = new SqlParameter("@FromDate", SqlDbType.VarChar);
            p2.Value = FromDate;
            SqlParameter p3 = new SqlParameter("@Todate", SqlDbType.VarChar);
            p3.Value = Todate;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Report_AGINGWISE_CONCISE", p, p1, p2, p3));

        }
      
        public static DataSet GetStudentWise_Count_Details(string DivisionCode, string Center, string FromDate, string Todate)
        {
            SqlParameter p = new SqlParameter("@Division_Code", SqlDbType.VarChar);
            p.Value = DivisionCode;
            SqlParameter p1 = new SqlParameter("@Center_Code", SqlDbType.VarChar);
            p1.Value = Center;
            SqlParameter p2 = new SqlParameter("@FromDate", SqlDbType.VarChar);
            p2.Value = FromDate;
            SqlParameter p3 = new SqlParameter("@Todate", SqlDbType.VarChar);
            p3.Value = Todate;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Report_StudentWise_Count", p, p1, p2, p3));

        }

        public static DataSet GetStudentRFIDDetails(string Flag, string DivisionCode, string ZoneCode, string CenterCode,
        string AcadYear, string Stream, string UserId)
        {
            SqlParameter p = new SqlParameter("@Flag", SqlDbType.VarChar);
            p.Value = Flag;
            SqlParameter p1 = new SqlParameter("@DivisionCode", SqlDbType.VarChar);
            p1.Value = DivisionCode;
            SqlParameter p2 = new SqlParameter("@ZoneCode", SqlDbType.VarChar);
            p2.Value = ZoneCode;
            SqlParameter p3 = new SqlParameter("@CenterCode", SqlDbType.VarChar);
            p3.Value = CenterCode;
            SqlParameter p4 = new SqlParameter("@AcadYear", SqlDbType.VarChar);
            p4.Value = AcadYear;
            SqlParameter p5 = new SqlParameter("@Stream", SqlDbType.VarChar);
            p5.Value = Stream;
            SqlParameter p6 = new SqlParameter("@UserId", SqlDbType.VarChar);
            p6.Value = UserId;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_RPT_GET_RFID_DETAILS", p, p1, p2, p3, p4, p5, p6));

        }
        //added by sujeer-22082017
        public static DataSet Get_stream_by_division(string Divisioncode)
        {
             SqlParameter p = new SqlParameter("@DivisionCode", SqlDbType.VarChar);
            p.Value = Divisioncode;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "GET_STREAM_DETAILS_BY_DIVISION", p));
        }
        public static DataSet GetStudentstudent_Details1(string DivisionCode, string streamcode, string datatype)
        {
            SqlParameter p = new SqlParameter("@Division_Code", SqlDbType.VarChar);
            p.Value = DivisionCode;
            SqlParameter p1 = new SqlParameter("@Stream", SqlDbType.VarChar);
            p1.Value = streamcode;
            SqlParameter p2 = new SqlParameter("@Datatype", SqlDbType.VarChar);
            p2.Value = datatype;
             return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "[USP_Get_Student Personal_Info]", p, p1, p2));

        }
        public static DataSet Inserlog(string DivisionCode, string streamcode, string datatype, string IP, string systemname, string userid, string flag)
        {
            SqlParameter p = new SqlParameter("@Division_Code", SqlDbType.VarChar);
            p.Value = DivisionCode;
            SqlParameter p1 = new SqlParameter("@Stream", SqlDbType.VarChar);
            p1.Value = streamcode;
            SqlParameter p2 = new SqlParameter("@Datatype", SqlDbType.VarChar);
            p2.Value = datatype;
            SqlParameter p3 = new SqlParameter("@ipaddress", SqlDbType.VarChar);
            p3.Value = IP;
            SqlParameter p4 = new SqlParameter("@Devicename", SqlDbType.VarChar);
            p4.Value = systemname;
            SqlParameter p5 = new SqlParameter("@userid", SqlDbType.VarChar);
            p5.Value = userid;
            SqlParameter p6 = new SqlParameter("@falg", SqlDbType.VarChar);
            p6.Value = flag;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "INSERT_LOG_OF_STUDENT_DATA_EXPORT", p, p1, p2, p3, p4, p5, p6));

        }

        //added by sujeer-11092017
        public static DataSet GetECSDetails(string DivisionCode, string Centercode, string datatype)
        {
            SqlParameter p = new SqlParameter("@divisioncode", SqlDbType.VarChar);
            p.Value = DivisionCode;
            SqlParameter p1 = new SqlParameter("@centercode", SqlDbType.VarChar);
            p1.Value = Centercode;
            SqlParameter p2 = new SqlParameter("@ecsstatus", SqlDbType.VarChar);
            p2.Value = datatype;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "[RPT_GET_ECS_STATUS]", p, p1, p2));

        }

        //ADDED BY SUJEER -20042017
        public static DataSet GetECS_Detail(string User_Code, string Company_Code, string Division_Code, string Zone_Code, string Center_Code, string AcadYear, string ProductID,
          string ECS_Status_ID, string SBEntryCode, string Flag, string ECSID)
        {
            SqlParameter p1 = new SqlParameter("@UserID", User_Code);
            SqlParameter p2 = new SqlParameter("@Company_Code", Company_Code);
            SqlParameter p3 = new SqlParameter("@Division_Code", Division_Code);
            SqlParameter p4 = new SqlParameter("@Zone_Code", Zone_Code);
            SqlParameter p5 = new SqlParameter("@Center_Code", Center_Code);
            SqlParameter p6 = new SqlParameter("@AcadYear", AcadYear);
            SqlParameter p7 = new SqlParameter("@ProductID", ProductID);
            SqlParameter p8 = new SqlParameter("@ECS_Status_ID", ECS_Status_ID);
            SqlParameter p9 = new SqlParameter("@SBEntryCode", SBEntryCode);
            SqlParameter p10 = new SqlParameter("@Flag", Flag);
            SqlParameter p11 = new SqlParameter("@ECSID", ECSID);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_ECS_Detail", p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11));

        }


        //ADDED BY SUJEER -02052018
        public static DataSet Getpendingadmission_Detail(string User_Code, string Company_Code, string Division_Code, string Zone_Code, string Center_Code, string AcadYear)
        {
            SqlParameter p1 = new SqlParameter("@UserID", User_Code);
            SqlParameter p2 = new SqlParameter("@Company_Code", Company_Code);
            SqlParameter p3 = new SqlParameter("@DIVISIONCODE", Division_Code);
            SqlParameter p4 = new SqlParameter("@Zone_Code", Zone_Code);
            SqlParameter p5 = new SqlParameter("@CENTERCODE", Center_Code);
            SqlParameter p6 = new SqlParameter("@ACADYEAR", AcadYear);
        
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "[GET_ADMISSION_PENDING_DETAILED_REPORT]", p1, p2, p3, p4, p5, p6));

        }


    }
}
