<%@ Page Title="" Language="C#" MasterPageFile="~/Reports.master" AutoEventWireup="true"
    CodeFile="rpt_Campaign_Followup_Closure_Detailed.aspx.cs" Inherits="rpt_Campaign_Followup_Closure_Detailed" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="breadcrumbs" class="position-relative">
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Report_Dashboard.aspx">Home</a><span class="divider"><i
                class="icon-angle-right"></i></span></li>
            <li>
                <h5 class="smaller">
                    Campaign Followup Closure remark - Detailed<span class="divider"></span>
                </h5>
            </li>
        </ul>
        <div id="nav-search">
            <!-- /btn-group -->
            <asp:Button class="btn  btn-app btn-primary btn-mini radius-4  " Visible="true" runat="server"
                ID="BtnShowSearchPanel" Text="Search" OnClick="BtnShowSearchPanel_Click" />
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
                                        <table cellpadding="2" class="table table-striped table-bordered table-condensed">
                                            <tr>
                                                <td class="span6" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label3" CssClass="red">Report Type</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList runat="server" ID="ddlReportType" Width="215px" data-placeholder="Select Report Type"
                                                                    CssClass="chzn-select" OnSelectedIndexChanged="ddlReportType_SelectedIndexChanged" AutoPostBack="true" >
                                                                    <asp:ListItem>Summary</asp:ListItem>
                                                                    <asp:ListItem>Detailed</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">                                                    
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="span6" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="lblcampaignacadyear" CssClass="red">Campaign Acad. Year</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList runat="server" ID="ddlcampaignacadyear" Width="215px" data-placeholder="Select Campaign Acad Year"
                                                                    CssClass="chzn-select" OnSelectedIndexChanged="ddlcampaignacadyear_SelectedIndexChanged"
                                                                    AutoPostBack="true" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label14">Campaign</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                        
                                                                <asp:ListBox runat="server" ID="ddlCampaignname" data-placeholder="Select Campaign Name"
                                                                    CssClass="chzn-select" SelectionMode="Multiple" AutoPostBack="True" />
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
                                    Text="Search" ToolTip="Search" ValidationGroup="UcValidateSearch" OnClick="BtnSearch_Click" />
                                <asp:Button class="btn btn-app btn-grey btn-mini radius-4" ID="BtnClearSearch" Visible="true"
                                    runat="server" Text="Clear" OnClick="BtnClearSearch_Click" />
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
                                    <asp:Label runat="server" ID="lblTotalName" Text="0">Total No of Records:</asp:Label>
                                    <asp:Label runat="server" ID="lbltotalcount" Text="0" />
                                    <button id="btnCampaignDetail_Back" runat="server" class="btn btn-small btn-inverse radius-4"
                                        visible="false" data-rel="tooltip" data-placement="right" title="Back" onserverclick="btnCampaignDetail_Back_ServerClick">
                                        <i class="icon-reply"></i>
                                    </button>
                                </td>
                                <td style="text-align: right" class="span2">
                                    <asp:LinkButton runat="server" ID="HLExport" ToolTip="Export" class="btn-small btn-danger icon-2x icon-download-alt"
                                        Height="25px" OnClick="HLExport_Click" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <asp:DataList ID="dlGridDisplay" CssClass="table table-striped table-bordered table-hover"
                    runat="server" Width="100%">
                    <HeaderTemplate>
                        <b style="width: 15%;">Camapign Name</b> </th>                        
                        <th style="width: 20%; text-align: center;">
                            Student Name
                        </th>
                        <th style="width: 20%; text-align: center;">
                            Previous X Center
                        </th>
                        <th style="width: 20%; text-align: center;">
                            Institute
                        </th>
                        <%--<th style="width: 10%; text-align: center;">
                            RCO Score
                        </th>--%>
                        <th style="width: 15%; text-align: center;">
                            Latest Followup Closure Remark
                        </th>
                        <th style="width: 10%; text-align: center;">
                            Contacts Status
                        </th>
                        <th style="width: 10%; text-align: center;">
                            Last Updated On
                        </th>
                        <th style="width: 10%; text-align: center;">
                            Last Caller Name                                        
                    </HeaderTemplate>
                    <ItemTemplate>
                            <asp:Label ID="lblCampaignName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CampaignName")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblStudentName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"StudentName")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblPreviousXCenter" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"PreviousXCenter")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblInstitution" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Institution")%>' />
                        </td>
                        <%--<td style="text-align: left;">
                            <asp:Label ID="lblRCO_Score" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"RCO_Score")%>' />
                        </td>--%>
                        <td style="text-align: left;">
                            <asp:Label ID="lblLatestFollowupClosureRemark" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"LatestFollowupClosureRemark")%>' />
                        </td>
                        <td style="text-align: center;">
                            <asp:Label ID="lblContactStatus" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ContactStatus")%>' />
                        </td>
                        <td style="text-align: center;">
                            <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Interacted_On")%>' />
                        </td> 
                        <td style="text-align: center;">
                            <asp:Label ID="Label2" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"User_Display_Name")%>' />
                        </td>                         
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
    </div>
</asp:Content>
