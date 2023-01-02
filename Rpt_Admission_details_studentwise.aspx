<%@ Page Title="" Language="C#" MasterPageFile="~/Reports.master" AutoEventWireup="true" CodeFile="Rpt_Admission_details_studentwise.aspx.cs" Inherits="Rpt_Admission_details_studentwise" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="breadcrumbs" class="position-relative">
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Report_Dashboard.aspx">Home</a><span class="divider"><i
                class="icon-angle-right"></i></span></li>
            <li>
                <h5 class="smaller">
                    Admission Detail<span class="divider"></span></h5>
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
                                                                <asp:Label runat="server" ID="Label18" CssClass="red">Center</asp:Label>                                                                
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:ListBox runat="server" ID="ddlCentre" Width="215px" data-placeholder="Select Center"
                                                                    CssClass="chzn-select"  AutoPostBack="True" />
                                                                
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
                                        <asp:Label runat="server" ID="Label45">Center</asp:Label> 
                                    </td>
                                    <td style="border-style: none; text-align: left; width: 60%;">
                                        <asp:Label runat="server" ID="lblCenter_Result" class="blue">Mulund-W</asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    </table>
                

                <asp:DataList ID="dlGridDisplay" CssClass="table table-striped table-bordered table-hover"
                    runat="server" Width="100%" >
                    <HeaderTemplate>
                        <b>Division</b> </th>
                    
                        <th align="left" style="width : 8%">
                            Center
                        </th>
                        <th align="left" style="width : 8%">
                            Stream
                        </th>
                         <th align="left" style="width : 6%">
                            Acad Year
                        </th>
                         <th align="left" style="width : 6%">
                            Opportunity Date
                        </th>
                          <th align="left" style="width : 8%">
                            Admission Date
                        </th>
                        <th align="left" style="width : 8%">
                            Student Name
                        </th>
                        <th align="left" style="width : 5%">
                            Gender
                        </th>
                        <th align="left" style="width : 4%">
                            Agg %
                        </th>
                        <th align="left" style="width : 4%">
                            M + S %
                        </th>
                        <th align="left" style="width : 8%">
                            School Name
                        </th>
                        <th align="left" style="width : 8%">
                            Board
                        </th>                        
                        <th align="left" style="width : 7%">
                            Account Type
                        </th>
                        <th align="left" style="width : 8%">
                            Location
                        </th>
                        <th align="left" style="width : 6%" >
                            Admission Status
                      
                    </HeaderTemplate>
                    <ItemTemplate>
                            <asp:Label ID="lblDivision" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"DIVISIONNAME")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblcenter" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CENTERNAME")%>' />
                        </td>
                            <td style="text-align: left;">
                            <asp:Label ID="lblstream" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Stream_LDesc")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblacadyear" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Acad_Year")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lbloppdate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"OPPDATE")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lbladmdate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ADMISSIONDATE")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"STUDENTNAME")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblGender" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Gender")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lbltmarks" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Total_MS_Marks")%>' />
                        </td>                        
                        <td style="text-align: left;">
                            <asp:Label ID="lblmsmark" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Total_MS_Marks_Obt")%>' />
                        </td>                         
          
                        <td style="text-align: left;">
                            <asp:Label ID="lblschname" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SCHOOLNAME")%>' />
                        </td>

                        <td style="text-align: left;">
                            <asp:Label ID="lblbors" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Board_Desc")%>' />
                             </td>
                             <td style="text-align: left;">
                            <asp:Label ID="Lblcategory" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Category_Type")%>' />
                             </td>
                             <td style="text-align: left;">
                            <asp:Label ID="Lbllocation" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"LOCATION")%>' />
                             </td>
                        <td style="text-align: left;">
                            <asp:Label ID="Lblstsus" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Account_Status_Name")%>' />
                        </td>
                    </ItemTemplate>
                </asp:DataList>
                
              
            </div>
           

        </div>
    </div>
</asp:Content>

