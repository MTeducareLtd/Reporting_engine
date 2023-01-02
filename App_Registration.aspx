<%@ Page Title="" Language="C#" MasterPageFile="~/Reports.master" AutoEventWireup="true" CodeFile="App_Registration.aspx.cs" Inherits="App_Registration" %>

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
                    App Registration<span class="divider"></span></h5>
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
    <div class="page-content">
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
                                                                <asp:Label runat="server" ID="Label2" ForeColor="Red" >Course</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                           
                                                                <asp:ListBox runat="server" ID="ddlcourse" data-placeholder="Select Course" CssClass="chzn-select"
                                                                    SelectionMode="Multiple" AutoPostBack="true" 
                                                                    onselectedindexchanged="ddlcourse_SelectedIndexChanged" />
                                                               
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label1">Region</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:ListBox runat="server" ID="ddlRegion" data-placeholder="Select Region" AutoPostBack="true" CssClass="chzn-select"
                                                                    SelectionMode="Multiple"  
                                                                    onselectedindexchanged="ddlRegion_SelectedIndexChanged" />
                                                              
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label11">Promo Code</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                              <asp:TextBox ID="txtpromocode" runat="server"></asp:TextBox>
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
                                                                <asp:Label runat="server" ID="Label4">Student Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtSudentName" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label6">Phone Number</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                               <asp:TextBox ID="TxtPhoneNumber" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label3">Email</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                             <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>
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
                                                                <asp:Label runat="server" ID="Label13">Date</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <input readonly="readonly" runat="server" class="id_date_range_picker_1 span8" name="date-range-picker"
                                                                    id="txtperiodCalendr" placeholder="Date Search" data-placement="bottom"
                                                                    data-original-title="Date Range" />
                                                             
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    
                                                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" HeaderText="Following error occurs:"
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
                                    Text="Search" ToolTip="Search" onclick="BtnSearch_Click"  />
                                <asp:Button class="btn btn-app btn-grey btn-mini radius-4" ID="BtnClearSearch" Visible="true"
                                    runat="server" Text="Clear" onclick="BtnClearSearch_Click"  />
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
                                    <asp:LinkButton runat="server" ID="Back" ToolTip="Back" class="btn btn-danger btn-small"
                                        Height="20px"  OnClick="Back_Click"><i class="icon-reply icon-2x icon-only"></i></asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="btnexporttoexcel" ToolTip="Export to Excel" class="btn-small btn-warning icon-2x icon-angle-down"
                                         Height="25px" onclick="btnexporttoexcel_Click" />
                                    <asp:LinkButton runat="server" Visible="false" ID="btnEmail" ToolTip="Email" class="btn-small btn-danger icon-2x icon-envelope-alt"
                                        Height="25px" />
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
                        <div class="tab-content" style="border: 1px solid #DDDDDD; overflow: auto">
                            <div id="AdmissionCount" class="tab-pane in active">
                            </div>
                            <div id="ACountPendingandConfirm" class="container-fluid">
                                <%--<asp:Repeater ID="rptr_Regidata" runat="server">
                                    <HeaderTemplate>
                                        <table id="simple-table" class="table table-striped table-bordered table-hover  Table1"
                                            border="1" style="border-collapse: collapse" width="100%">
                                            <thead>
                                                <tr>
                                                    <th style="width: 50px; text-align: center;">
                                                     Course
                                                    </th>
                                                    <th style="width: 50px; text-align: center;">
                                                      Date
                                                    </th>
                                                    <th style="width: 50px; text-align: center;">
                                                        Student Name
                                                    </th>
                                                    <th style="width: 30px; text-align: center;">
                                                        Email ID
                                                    </th>
                                                    <th style="width: 100px; text-align: center;">
                                                        Region
                                                    </th>
                                                    <th style="width: 100px; text-align: center;">
                                                        Contact No 1
                                                    </th>
                                                    <th style="width: 100px; text-align: center;">
                                                        Contact No 2
                                                    </th>
                                                    <th style="width: 100px; text-align: center;">
                                                        Promo Code
                                                    </th>
                                                    
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr class="odd gradeX">
                                            <td style="text-align: left; font-size: 10.0pt; font-family: Calibri; text-align: center;">
                                                <asp:Label ID="lblzone1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"COURSE")%>' />
                                            </td>
                                            <td style="text-align: left; font-size: 10.0pt; font-family: Calibri; text-align: center;">
                                                <asp:Label ID="lblCenter1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"DATE")%>' />
                                            </td>
                                            <td style="text-align: left; font-size: 10.0pt; font-family: Calibri; text-align: center;">
                                                <asp:Label ID="Label5" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Student Name")%>' />
                                            </td>
                                            <td style="text-align: left; font-size: 10.0pt; font-family: Calibri; text-align: center;">
                                                <asp:Label ID="Label10" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"E-Mail")%>' />
                                            </td>
                                            <td style="text-align: left; font-size: 10.0pt; font-family: Calibri; text-align: center;">
                                                <asp:Label ID="Label14" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CITY")%>' />
                                            </td>
                                            <td style="text-align: left; font-size: 10.0pt; font-family: Calibri; text-align: center;">
                                                <asp:Label ID="Label7" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CONTACT 1")%>' />
                                            </td>
                                              <td style="text-align: left; font-size: 10.0pt; font-family: Calibri; text-align: center;">
                                                <asp:Label ID="Label8" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CONTACT 2")%>' />
                                            </td>
                                            <td style="text-align: left; font-size: 10.0pt; font-family: Calibri; text-align: center;">
                                                <asp:Label ID="Label35" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"PROMO CODE")%>' />
                                            </td>
                                          
                                            
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </tbody> </table>
                                    </FooterTemplate>
                                </asp:Repeater>--%>
                                <asp:DataList ID="rptr_Regidata" runat="server" Width="100%" >
                                    <HeaderTemplate>
                                        <table id="simple-table" class="table table-striped table-bordered table-hover  Table1"
                                            border="0" style="border-collapse: collapse" width="100%">
                                            <thead>
                                                <tr>
                                                    <th style="width: 50px; text-align: center;">
                                                     Course
                                                    </th>
                                                    <th style="width: 50px; text-align: center;">
                                                      Date
                                                    </th>
                                                    <th style="width: 50px; text-align: center;">
                                                        Student Name
                                                    </th>
                                                    <th style="width: 30px; text-align: center;">
                                                        Email ID
                                                    </th>
                                                    <th style="width: 100px; text-align: center;">
                                                        Region
                                                    </th>
                                                    <th style="width: 100px; text-align: center;">
                                                        Contact No 1
                                                    </th>
                                                    <th style="width: 100px; text-align: center;">
                                                        Contact No 2
                                                    </th>
                                                    <th style="width: 100px; text-align: center;">
                                                        Promo Code
                                                    </th>
                                                    
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr class="odd gradeX">
                                            <td style="text-align: left; font-size: 10.0pt; font-family: Calibri; text-align: center;">
                                                <asp:Label ID="lblzone1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"COURSE")%>' />
                                            </td>
                                            <td style="text-align: left; font-size: 10.0pt; font-family: Calibri; text-align: center;">
                                                <asp:Label ID="lblCenter1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"DATE")%>' />
                                            </td>
                                            <td style="text-align: left; font-size: 10.0pt; font-family: Calibri; text-align: center;">
                                                <asp:Label ID="Label5" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Student Name")%>' />
                                            </td>
                                            <td style="text-align: left; font-size: 10.0pt; font-family: Calibri; text-align: center;">
                                                <asp:Label ID="Label10" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"E-Mail")%>' />
                                            </td>
                                            <td style="text-align: left; font-size: 10.0pt; font-family: Calibri; text-align: center;">
                                                <asp:Label ID="Label14" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CITY")%>' />
                                            </td>
                                            <td style="text-align: left; font-size: 10.0pt; font-family: Calibri; text-align: center;">
                                                <asp:Label ID="Label7" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CONTACT 1")%>' />
                                            </td>
                                              <td style="text-align: left; font-size: 10.0pt; font-family: Calibri; text-align: center;">
                                                <asp:Label ID="Label8" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CONTACT 2")%>' />
                                            </td>
                                            <td style="text-align: left; font-size: 10.0pt; font-family: Calibri; text-align: center;">
                                                <asp:Label ID="Label35" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"PROMO CODE")%>' />
                                            </td>
                                          
                                            
                                        </tr>
                                    </ItemTemplate>
                               </asp:DataList>
                                <div class="pagination">
                                        <div class="results">
                                            <asp:Label ID="lbl1" runat="server"></asp:Label>
                                            <asp:Button ID="btnprevious" runat="server" Text="Prev" class="button" OnClick="btnprevious_Click" />&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="Btnnext" runat="server" Text="Next" class="button" OnClick="Btnnext_Click" />
                                        </div>
                                    </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>

