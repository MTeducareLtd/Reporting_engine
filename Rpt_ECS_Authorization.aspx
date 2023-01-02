<%@ Page Title="" Language="C#" MasterPageFile="~/Reports.master" AutoEventWireup="true" CodeFile="Rpt_ECS_Authorization.aspx.cs" Inherits="Rpt_ECS_Authorization" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="breadcrumbs" class="position-relative">
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Report_Dashboard.aspx">Home</a><span class="divider">
            <i class="icon-angle-right"></i></span></li>
            <li>Report<span class="divider"> <i class="icon-angle-right"></i></span></li>
            <li>
                <h5 class="smaller">
                    ECS<span class="divider"></span></h5>
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
                                            
                                         <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label2">Company</asp:Label>                                                                
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlcompany" runat="server" data-placeholder="Select" CssClass="chzn-select" ValidationGroup="Grplead12"
                                                                    AutoPostBack="true" OnSelectedIndexChanged ="ddlcompany_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlcompany" InitialValue="Select" ForeColor="Red" runat="server" ErrorMessage="Please select company" Text="*"></asp:RequiredFieldValidator>
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
                                                               <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ControlToValidate="ddldivision" Text="*" InitialValue="Select" ForeColor="Red" runat="server" ErrorMessage="Please select Division"></asp:RequiredFieldValidator>
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
                                                                <asp:Label runat="server" CssClass="red" ID="Label6">Acad Year</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:ListBox runat="server" ID="ddlacademicyear"  data-placeholder="Select Acad Year"
                                                                    CssClass="chzn-select" SelectionMode="Multiple" AutoPostBack="True" OnSelectedIndexChanged ="ddlAcadyear_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                 <asp:Label runat="server" CssClass="red" ID="Label11">Stream</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:ListBox runat="server" ID="ddlstream"  data-placeholder="Select Stream"
                                                                    CssClass="chzn-select" SelectionMode="Multiple" AutoPostBack="True" OnSelectedIndexChanged="ddlstream_SelectedIndexChanged" />
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
                                                                <asp:Label runat="server" CssClass="red" ID="Label33">Status</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlAcknowledgementstatus" runat="server" data-placeholder="Select"
                                                                        CssClass="chzn-select" Width="215px" AutoPostBack="true">
                                                                        <asp:ListItem Value="All" Selected="True">All</asp:ListItem>
                                                                        <asp:ListItem Value="0">ECS Pending</asp:ListItem>
                                                                        <asp:ListItem Value="1">ECS Completed</asp:ListItem>
                                                                    </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
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
                                                                                                     
                                                   
                                                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" DisplayMode="BulletList" HeaderText="Following error occurs:" ShowMessageBox="true" ShowSummary="False" />
                                                                                                     
                                                   
                                                </td>
                                                    <td class="span4" style="text-align: left">
                                                    
                                                  
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
                                <td class="span10">
                                    Total No of Records:
                                    <asp:Label runat="server" ID="lbltotalcount" Text="0" />
                                </td>
                                <td style="text-align: right" class="span2">
                                    <asp:LinkButton runat="server" ID="Back" ToolTip="Back" class="btn btn-danger btn-small" Height="20px" OnClick="Back_Click"><i class="icon-reply icon-2x icon-only"></i></asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="btnexporttoexcel" ToolTip="Export to Excel" class="btn-small btn-warning icon-2x icon-angle-down" OnClick ="btnexporttoexcel_Click"
                                        Height="25px" />
                                    <asp:LinkButton runat="server" Visible ="false" ID="btnEmail" ToolTip="Email" class="btn-small btn-danger icon-2x icon-envelope-alt"
                                        Height="25px" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                
                <div id="DivResult" runat="server">
                        <div class="tab-content" style="border: 1px solid #DDDDDD">                            
                                <div id="ACountPendingandConfirm" class="table-content" >                                
                                <asp:Repeater ID="Repeater1" runat="server">
                                <HeaderTemplate>
                                <table id="simple-table" class="table table-striped table-bordered table-hover  Table1" border="1" style="border-collapse:collapse" width="100%">                                    
                                    <thead>
                                    <tr>                                       
                                        <th >
                                            ECS ID
                                        </th>
                                        <th >
                                            Division
                                        </th>
                                        <th>Center Name</th>
                                        <th>Name</th>
                                           <th>
                                            Sbentrycode
                                        </th>                                                                               
                                        <th >
                                        Acad Year
                                        </th> 
                                        <th>Stream</th>
                                        <th>ECS_Date</th>
                                        <th>ECS Amount</th>
                                        <th>IsAcknowledge</th>
                                        
                                    </tr>
                                </thead>
                                <tbody>
                                </HeaderTemplate>
                                <ItemTemplate>
                                  <tr class="odd gradeX">                                       
                                        <td style="text-align: left; font-size:10.0pt; font-family:Calibri;">
                                            <asp:Label ID="lblzone1" runat="server"  Text='<%#DataBinder.Eval(Container.DataItem,"ECS_ID")%>' />
                                        </td>
                                        <td style="text-align: left; font-size:10.0pt; font-family:Calibri; ">
                                            <asp:Label ID="lblCenter1" runat="server"  Text='<%#DataBinder.Eval(Container.DataItem,"Division")%>' />
                                        </td>
                                      <td style="text-align: left; font-size:10.0pt; font-family:Calibri; ">
                                            <asp:Label ID="Label27" runat="server"  Text='<%#DataBinder.Eval(Container.DataItem,"Source_Center_Name")%>' />
                                        </td>
                                      <td style="text-align: left; font-size:10.0pt; font-family:Calibri; ">
                                            <asp:Label ID="Label26" runat="server"  Text='<%#DataBinder.Eval(Container.DataItem,"Name")%>' />
                                        </td>
                                      <td style="text-align: left; font-size:10.0pt; font-family:Calibri;">
                                            <asp:Label ID="Label5" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Cur_sb_code")%>' />
                                        </td>
                                        <td style="text-align: left; font-size:10.0pt; font-family:Calibri; ">
                                            <asp:Label ID="Label10" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Acadyear")%>' />
                                        </td> 
                                      <td style="text-align: left; font-size:10.0pt; font-family:Calibri; ">
                                            <asp:Label ID="Label30" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Stream")%>' />
                                        </td> 
                                       <td style="text-align: left; font-size:10.0pt; font-family:Calibri;">
                                            <asp:Label ID="Label7" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ECS_Date")%>' />
                                        </td> 
                                       <td style="text-align: left; font-size:10.0pt; font-family:Calibri; ">
                                            <asp:Label ID="Label8" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ECS_Amount")%>' />
                                        </td> 
                                      <td style="text-align: left; font-size:10.0pt; font-family:Calibri; ">
                                            <asp:Label ID="Label9" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"IsAcknowledge")%>' />
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
</asp:Content>

