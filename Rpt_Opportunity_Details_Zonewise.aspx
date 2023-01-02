<%@ Page Title="" Language="C#" MasterPageFile="~/Reports.master" AutoEventWireup="true"
    CodeFile="Rpt_Opportunity_Details_Zonewise.aspx.cs" Inherits="Rpt_Opportunity_Details_Zonewise" %>

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
                    Opportunity Details Zone Wise</h5>
            </li>
            <li>
                <p class="blue">
                    &nbsp;</p>
            </li>
        </ul>
        <div id="nav-search">
            <!-- /btn-group -->
            <asp:Button class="btn  btn-app btn-primary btn-mini radius-4  " Visible="false"
                runat="server" ID="BtnShowSearchPanel" Text="Search" />
        </div>
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
                                <asp:UpdatePanel ID="UpdatePanelSearch" runat="server">
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
                                                                <asp:DropDownList ID="ddlcompany" runat="server" data-placeholder="Select" CssClass="chzn-select"
                                                                    ValidationGroup="Grplead12" AutoPostBack="true" OnSelectedIndexChanged="ddlcompany_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlcompany"
                                                                    InitialValue="Select" ForeColor="red" runat="server" ErrorMessage="Please select company"
                                                                    Text="*"></asp:RequiredFieldValidator>
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
                                                                <asp:DropDownList ID="ddldivision" runat="server" data-placeholder="Select" CssClass="chzn-select"
                                                                    AutoPostBack="true" OnSelectedIndexChanged="ddldivision_SelectedIndexChanged">
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
                                                                <asp:Label runat="server" ID="Label3">Zone / Area</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:ListBox runat="server" ID="ddlzone" data-placeholder="Select Zone" CssClass="chzn-select"
                                                                    SelectionMode="Multiple" AutoPostBack="True" />
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
                                                                <asp:Label runat="server" ID="Label9">Date</asp:Label>
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
                                            </tr>
                                            <tr>
                                                <td id="Td1" class="span4" style="text-align: center" colspan="3" runat="server"
                                                    visible="false">
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
                                    Text="Get" ToolTip="Search" OnClick="BtnSearch_Click" />
                                <asp:Button class="btn btn-app btn-grey btn-mini radius-4" ID="BtnClearSearch" Visible="true"
                                    runat="server" Text="Clear" OnClick="BtnClearSearch_Click" />
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
                                    <asp:LinkButton runat="server" ID="Back" ToolTip="Back" class="btn btn-danger btn-small"
                                        Height="20px" OnClick="Back_Click">
                                    <i class="icon-reply icon-2x icon-only"></i></asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="btnexporttoexcel" ToolTip="Export to Excel" class="btn-small btn-warning icon-2x icon-angle-down"
                                        Height="25px" OnClick="btnexporttoexcel_Click" />
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
                        <div class="tab-content" style="border: 1px solid #DDDDDD; overflow: hidden">
                            <div id="ACountPendingandConfirm" class="tab-pane in active">
                                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                    <HeaderTemplate>
                                        <table class="table table-striped table-bordered table-hover" border="1" style="border-collapse: collapse;
                                            overflow: scroll">
                                            <thead>
                                                <tr>
                                                    <th style="width: 10%; text-align: center;">
                                                        Division
                                                    </th>
                                                    <th style="width: 10%; text-align: center;">
                                                        Zone
                                                    </th>
                                                    <th style="width: 10%; text-align: center;">
                                                        Total Opportunity
                                                    </th>
                                                    <th style="width: 10%; text-align: center;">
                                                        Converted to Account
                                                    </th>
                                                    <th style="width: 10%; text-align: center;">
                                                        Pending Opportunity
                                                    </th>
                                                    </th>
                                                    <th style="width: 10%; text-align: center;">
                                                        Pending Opportunity followup
                                                    </th>
                                                    </th>
                                                    <th style="width: 10%; text-align: center;">
                                                        Overdue Followups
                                                    </th>
                                                    <th style="width: 10%; text-align: center;">
                                                        MT Opportunity
                                                    </th>
                                                    <th style="width: 10%; text-align: center;">
                                                        Non MT Opportunity
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr class="odd gradeX">
                                            <td style="text-align: left;">
                                                <asp:Label ID="lbldivision1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Division")%>' />
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:LinkButton ID="lblzone1" runat="server" ForeColor="black" OnClientClick="window.document.forms[0].target='_blank';"  CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Zone_Code")%>'
                                                    Text='<%#DataBinder.Eval(Container.DataItem,"Zone")%>' CommandName="com_edit" />
                                            </td>
                                            <td style="text-align: center;">
                                                <asp:Label ID="lbladmncountc" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Total Opportunity")%>' />
                                            </td>
                                            <td style="text-align: center;">
                                                <asp:Label ID="Label4" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Converted to Account")%>' />
                                            </td>
                                            <td style="text-align: center;">
                                                <asp:Label ID="Label6" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Pending Opportunity")%>' />
                                            </td>
                                            <td style="text-align: center;">
                                                <asp:Label ID="Label7" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Pending Opportunity followup")%>' />
                                            </td>
                                            <td style="text-align: center;">
                                                <asp:Label ID="Label8" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Overdue Followups")%>' />
                                            </td>
                                            <td style="text-align: center;">
                                                <asp:Label ID="Label10" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"MT Opportunity")%>' />
                                            </td>
                                            <td style="text-align: center;">
                                                <asp:Label ID="Label11" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Non MT Opportunity")%>' />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <%--<tr class="odd gradeX"> 
                                       <td colspan="7" style="text-align: center; color: #fff; background: ;"><font color="black"><b>Total</b></font></td>
                                       <td style="text-align: center; color: #fff; background: ;"><asp:Label ID="Label5" ForeColor="DarkBlue" runat="server"/></td>
                                        <td style="text-align: center; color: #fff; background: ;"><b><asp:Label ID="lable10" ForeColor="DarkBlue" runat="server"/></b></td>                                        
                                        <td style="text-align: center; color: #fff; background:;"><asp:Label ID="Label12" ForeColor="DarkBlue" runat="server"/></td></tr>--%>
                                        </tbody></table></FooterTemplate>
                                </asp:Repeater>
                                <asp:Repeater ID="Repeater2" runat="server" Visible="false" >
                                    <HeaderTemplate>
                                        <table class="table table-striped table-bordered table-hover" border="1" style="border-collapse: collapse;
                                            overflow: scroll">
                                            <thead>
                                                <tr>
                                                    <th style="width: 10%; text-align: center;">
                                                        Division
                                                    </th>
                                                    <th style="width: 10%; text-align: center;">
                                                        Zone
                                                    </th>
                                                    <th style="width: 10%; text-align: center;">
                                                        Total Opportunity
                                                    </th>
                                                    <th style="width: 10%; text-align: center;">
                                                        Converted to Account
                                                    </th>
                                                    <th style="width: 10%; text-align: center;">
                                                        Pending Opportunity
                                                    </th>
                                                    </th>
                                                    <th style="width: 10%; text-align: center;">
                                                        Pending Opportunity followup
                                                    </th>
                                                    </th>
                                                    <th style="width: 10%; text-align: center;">
                                                        Overdue Followups
                                                    </th>
                                                    <th style="width: 10%; text-align: center;">
                                                        MT Opportunity
                                                    </th>
                                                    <th style="width: 10%; text-align: center;">
                                                        Non MT Opportunity
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr class="odd gradeX">
                                            <td style="text-align: left;">
                                                <asp:Label ID="lbldivision1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Division")%>' />
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:Label ID="lblzone1" runat="server" ForeColor="black" 
                                                    Text='<%#DataBinder.Eval(Container.DataItem,"Zone")%>'  />
                                            </td>
                                            <td style="text-align: center;">
                                                <asp:Label ID="lbladmncountc" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Total Opportunity")%>' />
                                            </td>
                                            <td style="text-align: center;">
                                                <asp:Label ID="Label4" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Converted to Account")%>' />
                                            </td>
                                            <td style="text-align: center;">
                                                <asp:Label ID="Label6" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Pending Opportunity")%>' />
                                            </td>
                                            <td style="text-align: center;">
                                                <asp:Label ID="Label7" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Pending Opportunity followup")%>' />
                                            </td>
                                            <td style="text-align: center;">
                                                <asp:Label ID="Label8" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Overdue Followups")%>' />
                                            </td>
                                            <td style="text-align: center;">
                                                <asp:Label ID="Label10" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"MT Opportunity")%>' />
                                            </td>
                                            <td style="text-align: center;">
                                                <asp:Label ID="Label11" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Non MT Opportunity")%>' />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <%--<tr class="odd gradeX"> 
                                       <td colspan="7" style="text-align: center; color: #fff; background: ;"><font color="black"><b>Total</b></font></td>
                                       <td style="text-align: center; color: #fff; background: ;"><asp:Label ID="Label5" ForeColor="DarkBlue" runat="server"/></td>
                                        <td style="text-align: center; color: #fff; background: ;"><b><asp:Label ID="lable10" ForeColor="DarkBlue" runat="server"/></b></td>                                        
                                        <td style="text-align: center; color: #fff; background:;"><asp:Label ID="Label12" ForeColor="DarkBlue" runat="server"/></td></tr>--%>
                                        </tbody></table></FooterTemplate>
                                </asp:Repeater>
                                <%--<asp:DataList ID="Repeater2" CssClass="table table-striped table-bordered table-hover"
                                    runat="server" Width="100%" Visible="false">
                                    <HeaderTemplate>
                                      
                                           
                                                    <b>Division </b> 
                                                        
                                                    </th>
                                                    <th style="width: 10%; text-align: center;">
                                                        Zone
                                                    </th>
                                                    <th style="width: 10%; text-align: center;">
                                                        Total Opportunity
                                                    </th>
                                                    <th style="width: 10%; text-align: center;">
                                                        Converted to Account
                                                    </th>
                                                    <th style="width: 10%; text-align: center;">
                                                        Pending Opportunity
                                                    </th>
                                                    </th>
                                                    <th style="width: 10%; text-align: center;">
                                                        Pending Opportunity followup
                                                    </th>
                                                    </th>
                                                    <th style="width: 10%; text-align: center;">
                                                        Overdue Followups
                                                    </th>
                                                    <th style="width: 10%; text-align: center;">
                                                        MT Leads
                                                    </th>
                                                    <th style="width: 10%; text-align: center;">
                                                        Non MT Leads
                                                    
                                               
                                            
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                               <asp:Label ID="lbldivision1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Division")%>' />
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:Label ID="lblzone1" runat="server" ForeColor="black" Text='<%#DataBinder.Eval(Container.DataItem,"Zone")%>' />
                                            </td>
                                            <td style="text-align: center;">
                                                <asp:Label ID="lbladmncountc" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Total Opportunity")%>' />
                                            </td>
                                            <td style="text-align: center;">
                                                <asp:Label ID="Label4" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Converted to Account")%>' />
                                            </td>
                                            <td style="text-align: center;">
                                                <asp:Label ID="Label6" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Pending Opportunity")%>' />
                                            </td>
                                            <td style="text-align: center;">
                                                <asp:Label ID="Label7" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Pending Opportunity followup")%>' />
                                            </td>
                                            <td style="text-align: center;">
                                                <asp:Label ID="Label8" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Overdue Followups")%>' />
                                            </td>
                                            <td style="text-align: center;">
                                                <asp:Label ID="Label10" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"MT Leads")%>' />
                                            </td>
                                            <td style="text-align: center;">
                                                <asp:Label ID="Label11" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Non MT Leads")%>' />
                                            </td>
                                        
                                    </ItemTemplate>
                                    
                                </asp:DataList>--%>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="DivPrint" runat="server" visible="true" style="height: 0px; overflow: hidden;">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
