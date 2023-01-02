<%@ Page Title="" Language="C#" MasterPageFile="~/Reports.master" AutoEventWireup="true" CodeFile="Rpt_Discount_Concession_Request.aspx.cs" Inherits="Rpt_Discount_Concession_Request" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <div id="breadcrumbs" class="position-relative" >
        <ul class="breadcrumb" >
            <li><i class="icon-home"></i><a href="Report_Dashboard.aspx">Home</a><span class="divider"><i
                class="icon-angle-right"></i></span></li>
            <li>Report<span class="divider"> <i class="icon-angle-right"></i></span></li>
            <li>
                <h5 class="smaller">
                    Concession/Discount Request<span class="divider"></span></h5>
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
                                                                <asp:Label runat="server" CssClass="red" ID="Label2">Company</asp:Label>                                                                
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlcompany" runat="server" data-placeholder="Select" CssClass="chzn-select" ValidationGroup="Grplead12"
                                                                    AutoPostBack="true" OnSelectedIndexChanged ="ddlcompany_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlcompany" InitialValue="Select" ForeColor="red" runat="server" ErrorMessage="Please select company" Text="Please select company"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" CssClass="red" ID="Label1">Division</asp:Label>                                                                
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                              <asp:DropDownList ID="ddldivision" runat="server" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged ="ddldivision_SelectedIndexChanged">
                                                              </asp:DropDownList>
                                                               <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ControlToValidate="ddldivision" Text="Please select Division" InitialValue="Select" ForeColor="Red" runat="server" ErrorMessage="Please select Division"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" CssClass="red" ID="Label3">Zone / Area</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:ListBox runat="server" ID="ddlzone" data-placeholder="Select Zone"
                                                                    CssClass="chzn-select" SelectionMode="Multiple" AutoPostBack="True" OnSelectedIndexChanged ="ddlzone_SelectedIndexChanged" />
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
                                                                <asp:Label runat="server" CssClass="red" ID="Label4">Center</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:ListBox runat="server" ID="ddlcenter"  data-placeholder="Select Center"
                                                                    CssClass="chzn-select" SelectionMode="Multiple" AutoPostBack="True" OnSelectedIndexChanged ="ddlcenter_SelectedIndexChanged" />
                                                                    
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                        <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                 <asp:Label runat="server" ID="Labela">Acad Year</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                 <asp:DropDownList runat="server" ID="ddlacademicyear"  data-placeholder="Select Acad Year"
                                                                    CssClass="chzn-select"  AutoPostBack="True" OnSelectedIndexChanged="ddlacademicyear_SelectedIndexChanged" />
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddlacademicyear" Text="Please select Acad Year" InitialValue="Select" ForeColor="Red" runat="server" ErrorMessage="Please select Acad Year"></asp:RequiredFieldValidator>
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
                                                                <asp:ListBox runat="server" ID="ddlstream"  data-placeholder="Select Stream"
                                                                    CssClass="chzn-select" SelectionMode="Multiple" AutoPostBack="True" OnSelectedIndexChanged="ddlstream_SelectedIndexChanged "/>
                                                            </td>
                                                        </tr>
                                                    </table>                                                    
                                                </td>
                                                    
                                                    
                                            </tr>
                                          <tr>
                                              <%--<td class="span4" style="text-align: left">
                                                        <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                 <asp:Label runat="server" ID="Label13">Request Type</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:ListBox runat="server" ID="ddlrequesttype"  data-placeholder="Select Request Type"
                                                                    CssClass="chzn-select" SelectionMode="Multiple" AutoPostBack="True" />
                                                            </td>
                                                        </tr>
                                                    </table>                                                    
                                                </td>--%>
                                              <td class="span4" style="text-align: left">
                                                        <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                 <asp:Label runat="server" ID="Label19">Request Type</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:ListBox runat="server" ID="ddlrequesttype"  data-placeholder="Select Request Type"
                                                                    CssClass="chzn-select" SelectionMode="Multiple" AutoPostBack="True" />
                                                            </td>
                                                        </tr>
                                                    </table>                                                    
                                                </td>
                                              <td class="span4" style="text-align: left">
                                                        <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                 <asp:Label runat="server" ID="Label16">Request Status</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:ListBox runat="server" ID="ddlRequeststatus"  data-placeholder="Select Request Status"
                                                                    CssClass="chzn-select" SelectionMode="Multiple" AutoPostBack="True" />
                                                            </td>
                                                        </tr>
                                                    </table>                                                    
                                                </td>
                                              <td class="span4" style="text-align: left">
                                                    
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                 <asp:Label runat="server" ID="Label18">SBentry Code</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtSbentrycode" runat="server"></asp:TextBox>
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
                                                                <asp:Label runat="server" ID="Label29">  Requested Date</asp:Label>                                                                
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <input readonly="readonly" runat="server" class="id_date_range_picker_1 span8" name="date-range-picker" id="id_date_range_picker_1"
                                                                        placeholder="Date Search" data-placement="bottom" data-original-title="Date Range"/>
                                                                
                                                        
                                                            </td>
                                                        </tr>
                                                    </table>                                                       
                                                </td>  
                                               <td class="span4" style="text-align: left">
                                                      <%--  <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                 <asp:Label runat="server" ID="Label20">SBentry Code</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>--%>                                                    
                                                </td> 
                                               <td class="span4" style="text-align: left">
                                                      <%--  <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                 <asp:Label runat="server" ID="Label20">SBentry Code</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>--%>                                                    
                                                </td>                                             
                                            </tr>

                                             </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="well" style="text-align: center; background-color: #F0F0F0">
                            
                                <!--Button Area -->
                                <asp:Button class="btn btn-app btn-primary  btn-mini radius-4" runat="server" ID="BtnSearch" OnClick ="BtnSearch_Click" 
                                    Text="Get" ToolTip="Search" />
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
                                <td class="table-header">
                                    Total No of Records:
                                    <asp:Label runat="server" ID="lbltotalcount" Text="0" />
                                </td>
                                <td style="text-align: right" class="span2">
                                   <asp:LinkButton runat="server" ID="Back" ToolTip="Back" class="btn btn-danger btn-small" Height="20px"  OnClick="Back_Click"><i class="icon-reply icon-2x icon-only"></i></asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="btnexporttoexcel" ToolTip="Export to Excel" class="btn-small btn-warning icon-2x icon-angle-down" 
                                        Height="25px" OnClick="btnexporttoexcel_Click" />
                                    <asp:LinkButton runat="server" Visible ="False" ID="btnEmail" ToolTip="Email" class="btn-small btn-danger icon-2x icon-envelope-alt"
                                        Height="25px" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>                
                <div id="DivResult" runat="server">
                    <div class="tabbable">                       
                        <div class="tab-content" style="border: 1px solid #DDDDDD; ">                            
                                <div id="ACountPendingandConfirm" class="tab-pane in active" >                                
                              <asp:Repeater ID="Repeater1" runat="server">
                                <HeaderTemplate>
                                <table id="simple-table"  class="table table-striped table-bordered table-hover  Table1" border="1" style="border-collapse:collapse" width="100%">                                    
                                    <thead>
                                    <tr>                                       
                                        <th style="width:75px; text-align: center;">
                                            Request Date
                                        </th>
                                        <th style="width: 50px; text-align: center;">
                                            Center Name
                                        </th>
                                           
                                        <th style="width: 150px; text-align: center;">
                                            Stream Name
                                        </th>  
                                           
                                        <th style="width: 150px; text-align: center;">
                                            Acad Year
                                        </th>                                       
                                        <th style="width: 100px; text-align: center;">
                                          Student Name
                                         </th> 
                                         <th style="width: 100px; text-align: center;">
                                        SBentry Code
                                         </th> 
                                        <th style="width: 100px; text-align: left;">
                                          Requested Amt
                                        </th>
                                        <th style="width: 120px; text-align: center;">
                                            Request Type
                                        </th>
                                        <th style="width: 120px; text-align: center;">
                                            Level No
                                        </th>
                                        <th style="width: 100px; text-align: center;">
                                            Request Status
                                        </th>
                                        <th style="width: 30px; text-align: center;">
                                         Approved By
                                        </th>
                                       
                                       <th style="width: 60px; text-align: center;">
                                         Amount Approved
                                        </th>   
                                        <th style="width: 60px; text-align: center;" >
                                           Center Remark
                                        </th>
                                        <th style="width: 60px; text-align: center;" >
                                           Approval Remark
                                        </th>
                                        <th style="width: 100px; text-align: center;">
                                           Date of Approved
                                        </th> 
                                         <th style="width: 50px; text-align: center;">
                                           TAT
                                        </th>
                                       
                                    </tr>
                                </thead>
                                <tbody>
                                </HeaderTemplate>
                                <ItemTemplate>
                                  <tr class="odd gradeX">                                       
                                        <td style="font-size:10.0pt; font-family:Calibri; text-align:center;">
                                            <asp:Label ID="lblzone1" runat="server"  Text='<%#DataBinder.Eval(Container.DataItem,"Request date")%>' />
                                        </td>
                                        <td style="text-align: left; font-size:10.0pt; font-family:Calibri; text-align:center;">
                                            <asp:Label ID="lblCenter1" runat="server"  Text='<%#DataBinder.Eval(Container.DataItem,"center Name")%>' />
                                        </td>
                                      
                                        <td style="font-size:10.0pt; font-family:Calibri;">
                                            <asp:Label ID="Label10" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"stream Name")%>' />
                                        </td> 
                                        
                                        <td style="font-size:10.0pt; font-family:Calibri;">
                                            <asp:Label ID="Label20" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"acadyear")%>' />
                                        </td>
                                         
                                      <td style="text-align: left; font-size:10.0pt; font-family:Calibri; text-align:center;">
                                            <asp:Label ID="Label14" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"studentname")%>' />
                                        </td>                                     
                                      <td style="text-align: left; font-size:10.0pt; font-family:Calibri; text-align:center;">
                                            <asp:Label ID="Label7" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"sbentry code")%>' />
                                        </td>
                                      <td style="text-align: left; font-size:10.0pt; font-family:Calibri; text-align:left;">
                                            <asp:Label ID="Label35" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Requested Amt")%>' />
                                        </td>
                                      <td style="text-align: left; font-size:10.0pt; font-family:Calibri; text-align:center;">
                                            <asp:Label ID="Label5" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"request type")%>' />
                                        </td>  
                                      <td style="text-align: left; font-size:10.0pt; font-family:Calibri; text-align:center;">
                                            <asp:Label ID="Label13" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"LevelNo")%>' />
                                        </td>   
                                      <td style="text-align: left; font-size:10.0pt; font-family:Calibri; text-align:center;">
                                            <asp:Label ID="Label8" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request Status")%>' />
                                        </td>  
                                      <td style="text-align: left; font-size:10.0pt; font-family:Calibri; text-align:center;">
                                            <asp:Label ID="Label9" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Approved By")%>' />
                                        </td> 
                                                                          
                                      <td style="font-size:10.0pt; font-family:Calibri; text-align:justify;">
                                            <asp:Label ID="Label15" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Amount Approved")%>' />
                                        </td> 
                                      
                                      <td style="font-size:10.0pt; font-family:Calibri; text-align:justify;">
                                            <asp:Label ID="Label76" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"centre remark")%>' />
                                        </td> 
                                      <td style="font-size:10.0pt; font-family:Calibri; text-align:justify;">
                                            <asp:Label ID="Label17" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Approval remark")%>' />
                                        </td> 
                                         <td style="text-align: left; font-size:10.0pt; font-family:Calibri; text-align:center;">
                                           <asp:Label ID="Label6" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Date of Approved")%>' />                                            
                                        </td>
                                        <td style="text-align: left; font-size:10.0pt; font-family:Calibri; text-align:center;">
                                            <asp:Label ID="Label12" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"TAT")%>' />
                                        </td>  
                                    </tr>                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                    </tbody> </table>
                                </FooterTemplate>
                            </asp:Repeater>        
                                
                        </div>                            
                        </div>
                    </div>
                </div>                
            </div>
        </div>
    </div>
</asp:Content>
