<%@ Page Title="" Language="C#" MasterPageFile="~/Reports.master" AutoEventWireup="true"
    CodeFile="Rpt_Opportunity_DetailsZone_Centerwise.aspx.cs" Inherits="Rpt_Opportunity_DetailsZone_Centerwise" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="breadcrumbs" class="position-relative" style="height: 53px">
        <ul class="breadcrumb" style="height: 15px">
            <li><i class="icon-home"></i><a href="Report_Dashboard.aspx">Home</a><span class="divider"><i
                class="icon-angle-right"></i></span></li>
            <li>Report<span class="divider"> <i class="icon-angle-right"></i></span></li>
            <li>
                <h4 class="blue">
                    Opportunity Details Center Wise</h4>
            </li>
            <li>
                <p class="blue">
                    &nbsp;</p>
            </li>
        </ul>
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
                            <asp:LinkButton runat="server" ID="Back" ToolTip="Back" Visible="false" class="btn btn-danger btn-small"
                                Height="20px">
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
                        <asp:Repeater ID="Repeater1" runat="server">
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
                                                Center
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
                                        <asp:Label ID="lblzone1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Zone")%>' />
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:Label ID="Label5" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Center")%>' />
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
                    </div>
                </div>
            </div>
        </div>
        <div id="DivPrint" runat="server" visible="true" style="height: 0px; overflow: hidden;">
        </div>
    </div>
</asp:Content>
