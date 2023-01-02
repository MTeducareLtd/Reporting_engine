<%@ Page Title="" Language="C#" MasterPageFile="~/Reports.master" AutoEventWireup="true" CodeFile="Rpt_Contact_center_calling.aspx.cs" Inherits="Rpt_Contact_center_calling" %>

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
                <h5 class="smaller">
                  Calling Summary<span class="divider"></span></h5>
            </li>
        </ul>
        <div id="nav-search">
            <!-- /btn-group -->
            <asp:Button class="btn  btn-app btn-primary btn-mini radius-4  " Visible="false"
                runat="server" ID="BtnShowSearchPanel" Text="Search" 
                 />
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
                                                                <asp:Label runat="server" ID="Label2">Campaign</asp:Label>                                                                
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlCampaign" runat="server" data-placeholder="Select" CssClass="chzn-select" ValidationGroup="Grplead12"
                                                                    AutoPostBack="true" >
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlCampaign" InitialValue="Select" ForeColor="red" runat="server" ErrorMessage="Please select Campaign" Text="Please select Campaign"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <i class="icon-calendar"></i>
                                                                <asp:Label runat="server" ID="Label29">Period</asp:Label>                                                                
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <input readonly="readonly" runat="server" class="id_date_range_picker_1 span8" name="date-range-picker" id="id_date_range_picker_1"
                                                                        placeholder="Date Search" data-placement="bottom" data-original-title="Date Range"/>
                                                                
                                                        
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                              <td class="span4" style="text-align: left">
                                                     <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">                                                                
                                                                <asp:Label runat="server" ID="Label38"> User Name</asp:Label>                                                                
                                                            </td>
                                                             <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtuser" runat="server" Width="90%"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                

                                               
                                            </tr>
                                            
                                             <%--   <tr>
                                                    <td class="span4" style="text-align: left">
                                                    
                                                </td>
                                              
                                                    <td class="span4" style="text-align: left">
                                                    
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    
                                                </td>
                                                </tr>
                                                <tr>
                                                    
                                              
                                                <td class="span4" style="text-align: left">
                                                    
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                   
                                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Following error occurs:" ShowMessageBox="true" DisplayMode="BulletList" ShowSummary="False" />  
                                                   
                                                </td>
                                                </tr>--%>
                                             </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="well" style="text-align: center; background-color: #F0F0F0">
                                <!--Button Area -->
                                <asp:Button class="btn btn-app btn-primary  btn-mini radius-4" runat="server" ID="BtnSearch" OnClick="BtnSearch_Click"
                                    Text="Get" ToolTip="Search" />
                                <asp:Button class="btn btn-app btn-grey btn-mini radius-4" ID="BtnClearSearch" Visible="true" 
                                    runat="server" Text="Clear" onclick="BtnClearSearch_Click" />
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
                                    <asp:LinkButton runat="server" ID="Back" ToolTip="Back" class="btn btn-danger btn-small" Height="20px" OnClick="Back_Click"><i class="icon-reply icon-2x icon-only"></i></asp:LinkButton>

                                    <asp:LinkButton runat="server" ID="btnexporttoexcel" ToolTip="Export to Excel" class="btn-small btn-warning icon-2x icon-angle-down" OnClick ="btnexporttoexcel_Click"
                                        Height="25px" />
                                    <asp:LinkButton runat="server" Visible ="false" ID="btnEmail" ToolTip="Email" class="btn-small btn-danger icon-2x icon-envelope-alt"
                                        Height="25px"  />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <%--<li class ="active"><a data-toggle="tab" href="#ACountPendingandConfirm">Admission Count (Pending & Confirm) </a> </li>--%>
                <div id="DivResult" runat="server">
                    <div class="tabbable">
                        
                        <div class="tab-content" style="border: 1px solid #DDDDDD; overflow: hidden">
                            <div id="AdmissionCount" class="tab-pane in active">
                                <%--<img id ="imgPrint_Logo" runat ="server" src="../images/LEPL-LOGO.jpg" alt ="LEPL" />--%>
                                <asp:DataList ID="dladmissioncount" CssClass="table table-striped table-bordered table-hover"
                                    runat="server" Width="100%" border="1" style="border-collapse:collapse">
                                    <HeaderTemplate>
                                        <b>Company</b> </th>
                                        <th style="width: 25%; text-align: center">
                                            Division
                                        </th>
                                        <th style="width: 20%; text-align: center">
                                            Zone Name
                                        </th>
                                        <th style="width: 20%; text-align: center">
                                            Center Name
                                        </th>
                                        <th style="width: 15%; text-align: center">
                                            Academic Year
                                        </th>
                                        <th style="width: 10%; text-align: center">
                                        Admission Count
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblcompany" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Company")%>' />
                                        </td>
                                        <td style="text-align: left">
                                            <asp:Label ID="lbldivision" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Division")%>' />
                                        </td>
                                        <td style="text-align: left">
                                            <asp:Label ID="lblZone" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Zone")%>' />
                                        </td>
                                        <td style="text-align: left">
                                            <asp:Label ID="lblcenter" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CenterName")%>' />
                                        </td>
                                        <td style="text-align: left">
                                            <asp:Label ID="Label9" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Acadyear")%>' />
                                        </td>
                                        <td style="text-align: center">
                                            <asp:Label ID="lbladmissionCount" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Count")%>' />
                                    </ItemTemplate>
                                </asp:DataList>
                                
                            </div>
                                <div id="ACountPendingandConfirm" class="tab-pane in active" >
                                
                                <asp:Repeater ID="Repeater1" runat="server"  >
                                <HeaderTemplate>                                                             
                                        <table class="table table-striped table-bordered table-hover Table3" border="1" style="border-collapse:collapse; overflow:scroll" >

                                    <thead>
                                    <tr>
                                        <th style="width: 10%; text-align: center;">
                                           <b>Calling Date</b
                                        </th>
                                       
                                        <th style="width: 10%; text-align: center;">
                                            Campaign
                                        </th>
                                         <th style="width: 10%; text-align: center;">
                                            Call Type
                                        </th>

                                        <th style="width: 10%; text-align: center;">
                                            User Name
                                        </th>
                                        <th style="width: 15%; text-align: center;">
                                            Contact Name
                                        </th>
                                        <th style="width: 10%; text-align: center;">
                                            Mobile No
                                        </th>
                                        <th style="width: 10%; text-align: center;">
                                            Contact History 
                                        </th>
                                        <th style="width: 10%; text-align: center;">
                                            Lead Centre Name
                                        </th>
                                        <th style="width: 10%; text-align: center;">
                                        Division
                                         </th>
                                        <th style="width: 10%; text-align: center;">
                                        Feedback
                                         </th>

                                        <th style="width: 10%; text-align: center;">
                                            Calling Status
                                        </th>
                                         <th style="width: 10%; text-align: center;">
                                            Call Recording
                                        </th>
                                         <%--  <th style="width: 10%; text-align: center;">
                                       Student Count
                                         </th>--%>
                                    </tr>
                                </thead>
                                <tbody>
                                </HeaderTemplate>
                                <ItemTemplate>
                                  <tr class="odd gradeX">
                                        <td>
                                        <asp:Label ID="lbldate1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CallingDate")%>' />
                                        </td>
                                        
                                        <td style="text-align: left;">
                                            <asp:Label ID="lblCampaign" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Campaign")%>' />
                                        </td>
                                          <td style="text-align: left;">
                                            <asp:Label ID="Label4" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"mode_name")%>' />
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:Label ID="lblUserName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"UserName")%>' />
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:Label ID="lblStudentName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"StudentName")%>' />
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:Label ID="LblMobileNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"MobileNo")%>' />
                                        </td>
                                      <td style="text-align: center;">
                                            <asp:Label ID="lblCont" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"[Contact History]")%>' />
                                        </td>
                                        <td style="text-align: center;">
                                            <asp:Label ID="lblCenterName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CenterName")%>' />
                                        </td> 
                                         <td style="text-align: center;">
                                            <asp:Label ID="Label3" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Division")%>' />
                                        </td>                                       
                                        <td style="text-align: center;">
                                            <asp:Label ID="lblFeedBack" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"FeedBack")%>' />
                                       </td>
                                        <td style="text-align: left;">
                                            <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"callstatus")%>' />
                                        </td>
                                          <td style="text-align: left;">
                                           <a href='<%#DataBinder.Eval(Container.DataItem,"CallRecording") %>' target="_blank" class="btn btn-danger btn-small">URL
                                           <!--<asp:Label ID="lblurl" Text='<%#DataBinder.Eval(Container.DataItem,"CallRecording")%>'></asp:Label>-->
                                           
                                           </a>
                                        </td>

                                      <%-- <td style="text-align: center;">
                                            <asp:Label ID="lblNoOfStudent" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"NoOfStudent")%>' />
                                        </td> --%>
                                    </tr>
                                </ItemTemplate>
                                </asp:Repeater></div></div></div></div><div id="DivPrint" runat="server" visible="true" style="height: 0px; overflow: hidden;">
                    
                                        
                </div>
            </div>
        </div>
    </div>   

</asp:Content>

