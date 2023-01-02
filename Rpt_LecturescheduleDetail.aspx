<%@ Page Title="" Language="C#" MasterPageFile="~/Reports.Master" AutoEventWireup="true"
    CodeFile="Rpt_LecturescheduleDetail.aspx.cs" Inherits="Rpt_LecturescheduleDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="breadcrumbs" class="position-relative">
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Report_Dashboard.aspx">Home</a><span class="divider"><i
                class="icon-angle-right"></i></span></li>
            <li>
                <h5 class="smaller">
                    Lecture schedule Detail<span class="divider"></span></h5>
            </li>
        </ul>
        <div id="nav-search">
            <!-- /btn-group -->
            <asp:Button class="btn  btn-app btn-primary btn-mini radius-4  " Visible="true"
                runat="server" ID="BtnShowSearchPanel" Text="Search" OnClick="BtnShowSearchPanel_Click" />
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
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5>
                            Search Options
                        </h5>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <asp:UpdatePanel ID="UpdatePanelSearch" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label6" CssClass="red">Division</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList runat="server" ID="ddlDivision" Width="215px" data-placeholder="Select Division"
                                                                    CssClass="chzn-select" AutoPostBack="True" 
                                                                    onselectedindexchanged="ddlDivision_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label7" CssClass="red">Academic Year</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList runat="server" ID="ddlAcademicYear" Width="215px" data-placeholder="Select Academic Year"
                                                                    CssClass="chzn-select" AutoPostBack="True" 
                                                                    onselectedindexchanged="ddlAcademicYear_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                 <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label42" CssClass="red">Course</asp:Label>                                                                
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList runat="server" ID="ddlCourse" Width="215px" data-placeholder="Select Course"
                                                                    CssClass="chzn-select"  AutoPostBack="True" 
                                                                    onselectedindexchanged="ddlCourse_SelectedIndexChanged" />                                                                
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
                                                                <asp:Label runat="server" ID="Label3" CssClass="red">LMS/Non LMS Product</asp:Label>
                                                             </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">    
                                                                <asp:DropDownList runat="server" ID="ddlLMSnonLMSProdct" Width="215px" data-placeholder="Select Product"
                                                                    CssClass="chzn-select"  AutoPostBack="True" 
                                                                    onselectedindexchanged="ddlLMSnonLMSProdct_SelectedIndexChanged" />                                           
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label18" CssClass="red">Center</asp:Label>                                                                
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList runat="server" ID="ddlCentre" Width="215px" data-placeholder="Select Center"
                                                                    CssClass="chzn-select"  AutoPostBack="True" 
                                                                    onselectedindexchanged="ddlCentre_SelectedIndexChanged" />
                                                                
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label34" CssClass="red">Lecture Status</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList runat="server" ID="ddlLectStatus" Width="215px" data-placeholder="Select Lecture Status"
                                                                    CssClass="chzn-select"  AutoPostBack="True" 
                                                                    onselectedindexchanged="ddlLectStatus_SelectedIndexChanged" >
                                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                                    <asp:ListItem Value="1">Available Lectures</asp:ListItem>
                                                                    <asp:ListItem Value="2">Pending Cancellation</asp:ListItem>
                                                                    <asp:ListItem Value="3">Cancelled Lectures</asp:ListItem>
                                                                    <asp:ListItem Value="4">Replacement Lectures</asp:ListItem>
                                                                </asp:DropDownList>
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
                                                                <i class="icon-calendar"></i>                                                                
                                                                <asp:Label runat="server" ID="Label29" CssClass="red">Period</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                               <input readonly="readonly" runat="server" class="id_date_range_picker_1 span12" name="date-range-picker"
                                                                    id="id_date_range_picker_1" placeholder="Date Search" data-placement="bottom"
                                                                    data-original-title="Date Range" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                 <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr id="trLectType" runat="server" visible="false">
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label56" CssClass="red">Lecture Entry Status</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList runat="server" ID="ddlLectureEntryStatus" Width="215px" data-placeholder="Select Lecture Status"
                                                                    CssClass="chzn-select"  AutoPostBack="True" >
                                                                    <asp:ListItem Value="0">All Lectures</asp:ListItem>
                                                                    <asp:ListItem Value="1">Lectures Entered By Center</asp:ListItem>
                                                                    <asp:ListItem Value="2">Lectures Entered By MTT</asp:ListItem>
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
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="well" style="text-align: center; background-color: #F0F0F0">
                                <!--Button Area -->
                                <asp:Button class="btn btn-app btn-primary  btn-mini radius-4" runat="server" ID="BtnSearch"
                                    Text="Get" ToolTip="Search" ValidationGroup="UcValidateSearch" OnClick="BtnSearch_Click" />
                                <asp:Button class="btn btn-app btn-grey btn-mini radius-4" ID="BtnClearSearch" Visible="true"
                                    runat="server" Text="Clear" onclick="BtnClearSearch_Click" />
                                <asp:ValidationSummary ID="ValidationSummary2" ShowSummary="false" DisplayMode="List"
                                    ShowMessageBox="true" ValidationGroup="UcValidateSearch" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="DivResultPanel" runat="server" class="dataTables_wrapper" visible="false">
                <div class="widget-box">
                    <div class="table-header">
                        <table width="100%">
                            <tr>
                                <td class="span10">
                                    Total No of Records:
                                    <asp:Label runat="server" ID="lbltotalcount" Text="0" />
                                </td>
                                <td style="text-align: right" class="span2">
                                    <asp:LinkButton runat="server" ID="HLExport" ToolTip="Export" class="btn-small btn-danger icon-2x icon-download-alt"
                                        Height="25px" onclick="HLExport_Click" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                    <tr>
                        <td class="span4" style="text-align: left">
                            <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                <tr>
                                    <td style="border-style: none; text-align: left; width: 40%;">
                                        
                                        <asp:Label runat="server" ID="Label9">Division</asp:Label>
                                    </td>
                                    <td style="border-style: none; text-align: left; width: 60%;">
                                        
                                        <asp:Label runat="server" ID="lblDivision_Result" Text="MUM-SCI-ENG" CssClass="blue" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="span4" style="text-align: left">
                            <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                <tr>
                                    <td style="border-style: none; text-align: left; width: 40%;">
                                        
                                        <asp:Label runat="server" ID="Label10">Academic Year</asp:Label>
                                    </td>
                                    <td style="border-style: none; text-align: left; width: 60%;">
                                        
                                        <asp:Label runat="server" ID="lblAcademicYear_Result" Text="2014-2015" CssClass="blue" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="span4" style="text-align: left">
                            <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                <tr>
                                    <td style="border-style: none; text-align: left; width: 40%;">
                                        <asp:Label runat="server" ID="Label11">Course</asp:Label>    
                                        
                                    </td>
                                    <td style="border-style: none; text-align: left; width: 60%;">
                                           <asp:Label runat="server" ID="lblCourse_Result" class="blue"></asp:Label>
                                                                                     
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
                                        <asp:Label runat="server" ID="Label8">LMS/Non LMS Product</asp:Label>
                                    </td>
                                    <td style="border-style: none; text-align: left; width: 60%;">
                                        <asp:Label runat="server" ID="lblLMSProduct_Result" Text="" CssClass="blue"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>                        
                        <td class="span4" style="text-align: left">
                            <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                <tr>
                                    <td style="border-style: none; text-align: left; width: 40%;">
                                        <asp:Label runat="server" ID="Label45">Center</asp:Label> 
                                    </td>
                                    <td style="border-style: none; text-align: left; width: 60%;">
                                        <asp:Label runat="server" ID="lblCenter_Result" class="blue">Mulund-W</asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="span4" style="text-align: left">
                            <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                <tr>
                                    <td style="border-style: none; text-align: left; width: 40%;">
                                        <i class="icon-calendar"></i>
                                        <asp:Label runat="server" ID="Label1">Date</asp:Label>
                                    </td>
                                    <td style="border-style: none; text-align: left; width: 60%;">

                                        <asp:Label runat="server" ID="lblDate_result" class="blue">20 Feb 2015</asp:Label>                                                                                
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>                    
                </table>
                

                <asp:DataList ID="dlGridDisplay" CssClass="table table-striped table-bordered table-hover"
                    runat="server" Width="100%" >
                    <HeaderTemplate>
                        <b>Date</b> </th>
                        <th align="left" style="width : 6%">
                            From
                        </th>
                        <th align="left" style="width : 6%">
                            To
                        </th>
                        <th align="left" style="width : 6%">
                            Faculty Code
                        </th>
                        <th align="left" style="width : 6%">
                            Faculty Short Name
                        </th>
                        <th align="left" style="width : 7%">
                            Faculty Name
                        </th>
                        <th align="left" style="width : 6%">
                            Batch Short Name
                        </th>
                        <th align="left" style="width : 7%">
                            Batch Name
                        </th>
                        <th align="left" style="width : 7%">
                            Subject
                        </th>
                        <th align="left" style="width : 7%">
                            Chapter
                        </th>                        
                        <th align="left" style="width : 7%">
                            Lesson Plan
                        </th>
                        <th align="left" style="width : 7%">
                            Created On
                        </th>
                        <th align="left" style="width : 7%" >
                            Modified On
                        </th>
                       <%-- <th align="left" style="width : 7%">
                            LMSDB
                        </th>--%>
                        <th align="left" style="width : 7%">
                            AZURE
                        </th>
                        <th align="left" style="width : 7%">
                           Service AZURE
                    </HeaderTemplate>
                    <ItemTemplate>
                            <asp:Label ID="lblSession_Date" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Session_Date")%>' />
                            <span id="iconDL_Authorise" runat="server" visible='<%# Convert.ToString(DataBinder.Eval(Container.DataItem,"AttendClosureStatus_Flag")) == "1" ? true : false%>'
                                    class="btn btn-danger btn-mini tooltip-error" data-rel="tooltip" data-placement="right"
                                    title="Lecture Closed"><i class="icon-lock"></i></span>
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblFromTime" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"FromTIME")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblToTIME" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ToTIME")%>' />
                        </td>
                            <td style="text-align: left;">
                            <asp:Label ID="lblFacultyCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"FacultyCode")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblFacultyShortName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"FacultyShortName")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblFacultyName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"FacultyName")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblBatchName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"BatchName")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblBatchFullName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"BatchFullName")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblSubject" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Subject_Name")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblChapter" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Chapter_Name")%>' />
                        </td>                        
                        <td style="text-align: left;">
                            <asp:Label ID="lblLessonPlan" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"LessonPlanName")%>' />
                        </td>                         
                        <td style="text-align: left;">
                            <asp:Label ID="lblCreatedOn" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CreatedOn")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblLastModifiedOn" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"LastModifiedOn")%>' />
                        </td>
<%--
                        <td style="text-align: left;">
                            <asp:Label ID="lblLMSDBFlag" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"LMSDBFlag")%>' />
                        </td>--%>
                        <td style="text-align: left;">
                            <asp:Label ID="lblAZUREFlag" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"AZUREFlag")%>' />
                             </td>
                        <td style="text-align: left;">
                            <asp:Label ID="Label2" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ServicesynFlag")%>' />
                        </td>
                    </ItemTemplate>
                </asp:DataList>
                
              
            </div>
           

        </div>
    </div>
     <!--/row-->     
</asp:Content>
