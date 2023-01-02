<%@ Page Title="" Language="C#" MasterPageFile="~/Reports.master" AutoEventWireup="true"
    CodeFile="Rpt_Student_ChequeStatus.aspx.cs" Inherits="Rpt_Student_ChequeStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="breadcrumbs" class="position-relative">
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Report_Dashboard.aspx">Home</a><span class="divider"><i
                class="icon-angle-right"></i></span></li>
            <li>Report<span class="divider"> <i class="icon-angle-right"></i></span></li>
            <li>
                <h5 class="smaller">
                    Student Cheque Status<span class="divider"></span></h5>
            </li>
        </ul>
        <div id="nav-search">
            <!-- /btn-group -->
            <asp:Button class="btn  btn-app btn-primary btn-mini radius-4  " Visible="false"
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
                    <div class="table-header">
                        <h5>
                            Search Options
                        </h5>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <asp:UpdatePanel ID="UpdatePanelSearch" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table cellpadding="6" class="table table-striped table-bordered table-condensed">
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label1">Division</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddldivision" runat="server" AutoPostBack="true" data-placeholder="Select"
                                                                    CssClass="chzn-select" OnSelectedIndexChanged="ddldivision_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ControlToValidate="ddldivision"
                                                                    Text="*" InitialValue="Select" ForeColor="Red" runat="server" ErrorMessage="Please select Division"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label4">Center</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:ListBox runat="server" ID="ddlcenter" data-placeholder="Select Center" CssClass="chzn-select"
                                                                    SelectionMode="Multiple" AutoPostBack="True" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <td class="span4" style="text-align: left">
                                                        <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                            <tr>
                                                                <td style="border-style: none; text-align: left; width: 40%;">
                                                                    <asp:Label runat="server" ID="Label2">Status</asp:Label>
                                                                </td>
                                                                <td style="border-style: none; text-align: left; width: 60%;">
                                                                    <asp:DropDownList ID="ddlStatus" runat="server" data-placeholder="Select" CssClass="chzn-select">
                                                                        <asp:ListItem>Select</asp:ListItem>
                                                                        <asp:ListItem>All</asp:ListItem>
                                                                        <asp:ListItem>Cleared</asp:ListItem>
                                                                        <asp:ListItem>Bounced</asp:ListItem>
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
                                                                <asp:Label runat="server" ID="Label29">Period</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <input readonly="readonly" runat="server" class="id_date_range_picker_1 span8" name="date-range-picker"
                                                                    id="id_date_range_picker_1" style="width: 220px;" placeholder="Date Search" data-placement="bottom"
                                                                    data-original-title="Date Range" />
                                                               <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="id_date_range_picker_1"
                                                                    Text="*" InitialValue="" ForeColor="Red" runat="server" ErrorMessage="Please select Period"></asp:RequiredFieldValidator>--%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Following error occurs:"
                                                        ShowMessageBox="true" DisplayMode="BulletList" ShowSummary="False" />
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="well" style="text-align: center; background-color: #F0F0F0">
                                <!--Button Area -->
                                <asp:Button class="btn btn-app btn-primary  btn-mini radius-4" runat="server" ID="BtnSearch"
                                    OnClick="BtnSearch_Click" Text="Get" ToolTip="Search" />
                                <asp:Button class="btn btn-app btn-grey btn-mini radius-4" ID="BtnClearSearch" Visible="true"
                                    runat="server" Text="Clear" OnClick="BtnClearSearch_Click" />
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
                                <td class="span10">
                                    Total No of Records:
                                    <asp:Label runat="server" ID="lbltotalcount" Text="0" />
                                </td>
                                <td style="text-align: right" class="span2">
                                    <asp:LinkButton runat="server" ID="HLExport" ToolTip="Export" class="btn-small btn-danger icon-2x icon-download-alt"
                                        Height="25px" OnClick="HLExport_Click" Visible="true" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div id="DivResult" runat="server">
                    <div class="tabbable">
                        <ul class="nav nav-tabs" id="Ul1">
                        </ul>
                        <asp:DataList ID="dlStudentStatus" CssClass="table table-striped table-bordered table-hover"
                            runat="server" Width="100%" border="1" Style="border-collapse: collapse">
                            <HeaderTemplate>
                                <b>Center Name</b> </th>
                                <th style="width: 20%; text-align: center">
                                    Course Name
                                </th>
                                <th style="width: 20%; text-align: center">
                                    Sbentry Code
                                </th>
                                <th style="width: 20%; text-align: center">
                                    Student Name
                                </th>
                                <th style="width: 12%; text-align: center">
                                    Cheque No
                                </th>
                                <th style="width: 12%; text-align: center">
                                    Cheque Date
                                </th>
                                <th style="width: 12%; text-align: center">
                                    Amount
                                </th>
                                 <th style="width: 12%; text-align: center">
                                    Reason For Bounced
                                </th>
                                <th style="width: 12%; text-align: center">
                                    FEEDBACK FROM PARENT
                                </th>
                                <th style="width: 12%; text-align: center">
                                    New Cheque No
                                </th>
                                <th style="width: 12%; text-align: center">
                                    New Cheque Date
                                </th>
                                <th style="width: 12%; text-align: center">
                                    New Cheque Amount
                                </th>
                                 <th style="width: 12%; text-align: center">
                                    Recovery Status
                                </th>
                                <th style="width: 15%; text-align: center">
                                   Cheque Status
                                 </th>
                                 <th style="width: 12%; text-align: center">
                                    Aging Days
                                
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblcompany" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CENTER")%>' />
                                </td>
                                <td style="text-align: left">
                                    <asp:Label ID="lbldivision" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"STREAM_NAME")%>' />
                                </td>
                                <td style="text-align: left">
                                    <asp:Label ID="lbladmissionCount" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SBEntrycode")%>' />
                                </td>
                                <td style="text-align: left">
                                    <asp:Label ID="Label9" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"[STUDENT FULL NAME]")%>' />
                                </td>
                                <td style="text-align: center">
                                    <asp:Label ID="Label3" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Pay_InsNum")%>' />
                                </td>
                                <td style="text-align: left">
                                    <asp:Label ID="Label5" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Cheque_Date")%>' />
                                </td>
                                <td style="text-align: left">
                                    <asp:Label ID="Label6" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"instr_amt")%>' />
                                </td>
                              
                                <td style="text-align: left">
                                    <asp:Label ID="Label10" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"[RTN REASON]")%>' />
                                </td>
                                <td style="text-align: left">
                                    <asp:Label ID="Label11" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Followup_Remark")%>' />
                                </td>
                                <td style="text-align: left">
                                    <asp:Label ID="Label12" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"NewCheque_No")%>' />
                                </td>
                                <td style="text-align: left">
                                    <asp:Label ID="Label14" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"pay_InstrDate")%>' />
                                </td>
                                <td style="text-align: left">
                                    <asp:Label ID="Label15" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"New_ChequeAmount")%>' />
                                </td>
                                 <td style="text-align: left">
                                    <asp:Label ID="Label17" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Recovery_Status")%>' />
                                </td>
                                <td style="text-align: left">
                                    <asp:Label ID="Label16" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Cheque_Status")%>' />
                                </td>
                                  <td style="text-align: left">
                                    <asp:Label ID="Label8" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Ageing")%>' />
                                
                            </ItemTemplate>
                        </asp:DataList></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
