<%@ Page Title="" Language="C#" MasterPageFile="~/Reports.master" AutoEventWireup="true" CodeFile="RFID_Detail.aspx.cs" Inherits="RFID_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="breadcrumbs" class="position-relative">
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Report_Dashboard.aspx">Home</a><span class="divider"><i
                class="icon-angle-right"></i></span></li>
            <li>Report<span class="divider"> <i class="icon-angle-right"></i></span></li>
            <li>
                <h5 class="smaller">RFID Detail<span class="divider"></span></h5>
            </li>
        </ul>
        <div id="nav-search">
            <!-- /btn-group -->
            <asp:Button class="btn  btn-app btn-primary btn-mini radius-4  " Visible="false"
                runat="server" ID="BtnShowSearchPanel" Text="Search" />
        </div>
        <!--#nav-search-->
    </div>
    <div id="page-content" class="clearfix">
        <!--/page-header-->
        <div class="row-fluid">
            <!-- -->
            <!-- PAGE CONTENT BEGINS HERE -->
            <asp:UpdatePanel ID="UpdatePanelMsgBox" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="alert alert-block alert-success" id="Msg_Success" visible="false" runat="server">
                        <button type="button" class="close" data-dismiss="alert">
                            <i class="icon-remove"></i>
                        </button>
                        <p>
                            <strong><i class="icon-ok"></i></strong>
                            <asp:Label ID="lblSuccess" runat="server" Text="Label"></asp:Label>
                        </p>
                    </div>
                    <div class="alert alert-error" id="Msg_Error" visible="false" runat="server">
                        <button type="button" class="close" data-dismiss="alert">
                            <i class="icon-remove"></i>
                        </button>
                        <p>
                            <strong><i class="icon-remove"></i>Error!</strong>
                            <asp:Label ID="lblerror" runat="server" Text="Label"></asp:Label>

                        </p>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div id="DivSearchPanel" runat="server">
                <div class="widget-box">
                    <div class="table-header">
                        <h5>Search Options
                        </h5>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <asp:UpdatePanel ID="UpdatePanelSearch" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table cellpadding="6" class="table table-striped table-bordered table-condensed">
                                            <%--<tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label5">Report Type</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlreporttype" runat ="server">
                                                                <asp:ListItem Value ="00" Text ="Select"></asp:ListItem>
                                                                <asp:ListItem Value ="01" Text ="Annual"></asp:ListItem>
                                                                <asp:ListItem Value ="02" Text ="Monthly"></asp:ListItem>
                                                                <asp:ListItem Value ="03" Text ="Daily"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                               
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                               
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                
                                                 
                                           </tr>--%>
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label2">Company</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlcompany" runat="server" data-placeholder="Select" CssClass="chzn-select" ValidationGroup="Grplead12"
                                                                    AutoPostBack="true" OnSelectedIndexChanged="ddlcompany_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlcompany" InitialValue="Select" ForeColor="red" runat="server" ErrorMessage="Please select company" Text="*"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label1">Division</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddldivision" runat="server" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddldivision_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ControlToValidate="ddldivision" Text="*" InitialValue="Select" ForeColor="Red" runat="server" ErrorMessage="Please select Division"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label3">Zone / Area</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:ListBox runat="server" ID="ddlzone" data-placeholder="Select Zone"
                                                                    CssClass="chzn-select" SelectionMode="Multiple" AutoPostBack="True" OnSelectedIndexChanged="ddlzone_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>



                                            </tr>

                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label4">Center</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:ListBox runat="server" ID="ddlcenter" data-placeholder="Select Center"
                                                                    CssClass="chzn-select" SelectionMode="Multiple" AutoPostBack="True" OnSelectedIndexChanged="ddlcenter_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>

                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label6">Acad Year</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:ListBox runat="server" ID="ddlacademicyear" data-placeholder="Select Acad Year"
                                                                    CssClass="chzn-select" SelectionMode="Single" AutoPostBack="True" OnSelectedIndexChanged="ddlAcadyear_SelectedIndexChanged" />

                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label11">Stream</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:ListBox runat="server" ID="ddlstream" data-placeholder="Select Stream"
                                                                    CssClass="chzn-select" SelectionMode="Multiple" AutoPostBack="True" OnSelectedIndexChanged="ddlstream_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    
                                                </td>

                                                <td class="span4" style="text-align: left"></td>
                                                <td class="span4" style="text-align: left">

                                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Following error occurs:" ShowMessageBox="true" DisplayMode="BulletList" ShowSummary="False" />

                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="well" style="text-align: center; background-color: #F0F0F0">
                                <!--Button Area -->
                                <asp:Button class="btn btn-app btn-primary  btn-mini radius-4" runat="server" ID="BtnSearch" OnClick="BtnSearch_Click"
                                    Text="Get" ToolTip="Search" />
                                <asp:Button class="btn btn-app btn-grey btn-mini radius-4" ID="BtnClearSearch" Visible="true" OnClick="BtnClear_Click"
                                    runat="server" Text="Clear" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="DivResultPanel" runat="server" class="dataTables_wrapper">
                <div class="widget-box">
                    <div class="table-header">
                        <table width="100%">
                            <tr>
                                <td class="span10">Total No of Records:
                                    <asp:Label runat="server" ID="lbltotalcount" Text="0" />
                                </td>
                                <td style="text-align: right" class="span2">
                                    <asp:LinkButton runat="server" ID="Back" ToolTip="Back" class="btn btn-danger btn-small" Height="20px" OnClick="Back_Click"><i class="icon-reply icon-2x icon-only"></i></asp:LinkButton>

                                    <asp:LinkButton runat="server" ID="btnexporttoexcel" ToolTip="Export to Excel" class="btn-small btn-warning icon-2x icon-angle-down"
                                        Height="25px" OnClick="btnexporttoexcel_Click" />
                                    <asp:LinkButton runat="server" Visible="false" ID="btnEmail" ToolTip="Email" class="btn-small btn-danger icon-2x icon-envelope-alt"
                                        Height="25px"/>
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <%--<li class ="active"><a data-toggle="tab" href="#ACountPendingandConfirm">Admission Count (Pending & Confirm) </a> </li>--%>
                <div id="DivResult" runat="server">
                    <div class="tabbable">
                        <ul class="nav nav-tabs" id="Ul1">
                            <%--<li><a data-toggle="tab" href="#ErrorRecords">Overall Toppers </a></li>--%>                            <%--<div class="table-header">
                                    <table width="100%">
                                        <tr>
                                            <td class="span10">
                                                Total No of Records:
                                                <asp:Label runat="server" ID="lbltotalcount" Text="0" />
                                            </td>
                                            <td style="text-align: right" class="span2">
                                                <asp:LinkButton runat="server" ID="btnexporttoexcel" ToolTip="Export to Excel" class="btn-small btn-warning icon-2x icon-angle-down" OnClick ="btnexporttoexcel_Click"
                                                    Height="25px" />
                                   
                                            </td>
                                        </tr>
                                    </table>
                                </div>--%>                            <%--<div class="table-header">
                                    <table width="100%">
                                        <tr>
                                            <td class="span10">
                                                Total No of Records:
                                                <asp:Label runat="server" ID="lbladmissioncountrecords" Text="0" />
                                            </td>
                                            <td style="text-align: right" class="span2">
                                                <asp:LinkButton runat="server" ID="btnexporttoexcel1" ToolTip="Export to Excel" class="btn-small btn-warning icon-2x icon-angle-down" OnClick ="btnexporttoexcel1_Click"
                                                    Height="25px" />
                                   
                                            </td>
                                        </tr>
                                    </table>
                                </div>--%>
                        </ul>
                        <div class="tab-content" style="border: 1px solid #DDDDDD; overflow: hidden">
                            <div id="AdmissionCount" class="tab-pane in active">
                                <%--<img id ="imgPrint_Logo" runat ="server" src="../images/LEPL-LOGO.jpg" alt ="LEPL" />--%>
                                <asp:DataList ID="dlstudentdata" CssClass="table table-striped table-bordered table-hover"
                                    runat="server" Width="100%" border="1" Style="border-collapse: collapse">
                                    <HeaderTemplate>
                                        <b>Division</b>
                                        <th style="width: 10%; text-align: center">Center Name
                                        </th>
                                        <th style="width: 10%; text-align: center">SBEntryCode
                                        </th>
                                        <th style="width: 10%; text-align: center">OldSBEntryCode
                                        </th>
                                        <th style="width: 10%; text-align: center">SPID
                                        </th>
                                        <th style="width: 20%; text-align: center">Student Name
                                        </th>

                                        <th style="width: 5%; text-align: center">Academic Year
                                        </th>
                                        <th style="width: 5%; text-align: center">Stream
                                        </th>
                                        <th style="width: 10%; text-align: center">
                                        RFID
                                    </HeaderTemplate>
                                    <ItemTemplate>

                                        <asp:Label ID="lbldivision" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Division")%>' />
                                        </td>
                                        <td style="text-align: left">
                                            <asp:Label ID="lblZone" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Center")%>' />
                                        </td>
                                        <td style="text-align: left">
                                            <asp:Label ID="lblcenter" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SBEntryCode")%>' />
                                        </td>
                                        <td style="text-align: left">
                                            <asp:Label ID="Label9" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"OldSBEntryCode")%>' />
                                        </td>
                                        <td style="text-align: center">
                                            <asp:Label ID="lbladmissionCount" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SPID")%>' />
                                        </td>
                                        <td style="text-align: center">
                                            <asp:Label ID="Label5" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Student_Name")%>' />
                                        </td>
                                        <td style="text-align: center">
                                            <asp:Label ID="Label10" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Acad_Year")%>' />
                                        </td>
                                        <td style="text-align: center">
                                            <asp:Label ID="Label12" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Stream")%>' />
                                        </td>
                                        <td style="text-align: center">
                                            <asp:Label ID="Label13" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"RFID")%>' />
                                    </ItemTemplate>
                                </asp:DataList>

                            </div>
                            <div id="ACountPendingandConfirm" class="tab-pane in active">
                            </div>
                        </div>
                    </div>
                </div>
                <div id="DivPrint" runat="server" visible="true" style="height: 0px; overflow: hidden;">
                    <table style="width: 210mm" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 9pt">
                                <table style="width: 100%" border="1" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="text-align: left;" colspan="1" height="10mm">

                                            <%--<img id ="imgPrint_Logo" runat ="server" src="../images/LEPL-LOGO.jpg" alt ="LEPL" />--%>
                                            <asp:Label ID="Label7" runat="server" Text="LEPL" Font-Size="14pt"
                                                Font-Bold="True" />
                                        </td>
                                        <td style="text-align: right; vertical-align: bottom; background-color: #00FFFF;" colspan="3">
                                            <asp:Label ID="Label8" runat="server" Text="STATEMENT OF MARKS" Font-Size="14pt"
                                                Font-Bold="True" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="border-width: 1px; font-family: Arial, Helvetica, sans-serif; font-size: 9pt; border-top-style: solid;">
                                <table style="width: 210mm" border="1" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="10%" style="text-align: left; font-size: 9pt; font-family: Arial, Helvetica, sans-serif;">Student Name : </td>
                                        <td width="50%" style="text-align: left; font-size: 9pt; font-family: Arial, Helvetica, sans-serif;">
                                            <asp:Label ID="lblPrint_StudentName" runat="server" Text="" Font-Bold="True" />
                                        </td>
                                        <td width="10%" style="text-align: left; font-size: 9pt; font-family: Arial, Helvetica, sans-serif;">Roll No : </td>
                                        <td width="10%" style="text-align: left; font-size: 9pt; font-family: Arial, Helvetica, sans-serif;">
                                            <asp:Label ID="lblPrint_RollNo" runat="server" Text="" Font-Bold="True" />
                                        </td>
                                        <td width="10%" style="text-align: left; font-size: 9pt; font-family: Arial, Helvetica, sans-serif;">Center : </td>
                                        <td width="10%" style="text-align: left; font-size: 9pt; font-family: Arial, Helvetica, sans-serif;">
                                            <asp:Label ID="lblPrint_Center" runat="server" Text="" Font-Bold="True" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 9pt">
                                <asp:DataList ID="dlPrint_Summary" runat="server" Width="100%" Font-Size="9pt">
                                    <HeaderTemplate>
                                        Test Date </th><th style="width: 10%; text-align: left">Test Name </th>
                                        <th style="width: 30%; text-align: left">Subject </th>
                                        <th style="width: 10%; text-align: center">Score </th>
                                        <th style="width: 10%; text-align: center">Out of </th>
                                        <th style="width: 10%; text-align: center">Percent </th>
                                        <th style="width: 10%; text-align: center">Centre Rank </th>
                                        <th style="width: 10%; text-align: center">
                                        Overall Rank
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblDLTestDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Test_Date")%>' />
                                        </td>
                                        <td style="text-align: left">
                                            <asp:Label ID="lblDLTestName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Test_Name")%>' />
                                        </td>
                                        <td style="text-align: left">
                                            <asp:Label ID="lblDLSubject" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Subject_Name")%>' />
                                        </td>
                                        <td style="text-align: center">
                                            <asp:Label ID="lblDLMarksObtd" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Obtd_Marks")%>' />
                                        </td>
                                        <td style="text-align: center">
                                            <asp:Label ID="lblDLMarksOutOf" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"OutOf_Marks")%>' />
                                        </td>
                                        <td style="text-align: center">
                                            <asp:Label ID="lblDLPercent" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Percent_Marks")%>' />
                                        </td>
                                        <td style="text-align: center">
                                            <asp:Label ID="lblDLCentreRank" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CentreRank")%>' />
                                        </td>
                                        <td style="text-align: center">
                                            <asp:Label ID="lblDLOvarllRank" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"OverallRank")%>' />
                                    </ItemTemplate>
                                </asp:DataList>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 9pt">
                                <table style="width: 100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="border-style: solid; border-width: 1px; text-align: left; font-size: 11pt; font-weight: bold; font-family: arial, Helvetica, sans-serif; width: 100mm;">Details of Answering </td>
                                        <td style="text-align: left; font-size: 11pt; font-weight: bold; font-family: arial, Helvetica, sans-serif; width: 110mm;"></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 9pt">
                                <asp:DataList ID="dlPrint_Answering" runat="server" Width="100%" Font-Size="9pt">
                                    <HeaderTemplate>
                                        <left>Test Name</left>
                                        </th><th style="width: 20%; text-align: left;">Subject </th>
                                        <th style="width: 10%; text-align: center;">Status </th>
                                        <th style="width: 6%; text-align: center;">Count </th>
                                        <th style="width: 18%; text-align: left;">Que No - Easy </th>
                                        <th style="width: 18%; text-align: left;">Que No - Moderate </th>
                                        <th style="width: 18%; text-align: left;">
                                        Que No - Difficult
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblDLTestName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Test_Name")%>' />
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:Label ID="lblDLSubjectName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Subject_Name")%>' />
                                        </td>
                                        <td style="text-align: center;">
                                            <asp:Label ID="lblDLResultStatus" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ResultStatus")%>' />
                                        </td>
                                        <td style="text-align: center;">
                                            <asp:Label ID="lblDLResultCount" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ResultCount")%>' />
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:Label ID="lblDLEasy" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Easy")%>' />
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:Label ID="lblDLModerate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Moderate")%>' />
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:Label ID="lblDLDifficult" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Difficult")%>' />
                                    </ItemTemplate>
                                </asp:DataList>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 9pt">
                                <table style="width: 100%" border="1" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="100%" valign="middle" align="left">Overall Topper </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 9pt">
                                <asp:DataList ID="dlPrint_Topper" runat="server" Width="100%" Font-Size="9pt">
                                    <HeaderTemplate>
                                        <left>Test Name</left>
                                        </th><th style="width: 20%; text-align: left;">Subject </th>
                                        <th style="width: 35%; text-align: left;">Name of Student </th>
                                        <th style="width: 25%; text-align: left;">Centre </th>
                                        <th style="width: 10%; text-align: center;">
                                        Score
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblDLTestName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Test_Name")%>' />
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:Label ID="lblDLSubject" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Subject_Name")%>' />
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:Label ID="lblDLStudentName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"StudentName")%>' />
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:Label ID="lblDLCentre" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Centre_Name")%>' />
                                        </td>
                                        <td style="text-align: center;">
                                            <asp:Label ID="lblDLScore" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Obtd_Marks")%>' />
                                    </ItemTemplate>
                                </asp:DataList>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

