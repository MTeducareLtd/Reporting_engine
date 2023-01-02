<%@ Page Title="" Language="C#" MasterPageFile="~/Reports.Master" AutoEventWireup="true"
    CodeFile="RPT_CRM_Index.aspx.cs" Inherits="RPT_CRM_Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        function NumberOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 48 && AsciiValue <= 57))
                event.returnValue = true;
            else
                event.returnValue = false;
        }

        function CharacterOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 33 && AsciiValue <= 64) || (AsciiValue == 8 || AsciiValue == 127) || (AsciiValue >= 91 && AsciiValue <= 96) || (AsciiValue >= 123 && AsciiValue <= 126))
                event.returnValue = false;
            else
                event.returnValue = true;
        }

        function openModalDivOverride() {
            $('#DivOverrid').modal({
                backdrop: 'static'
            })

            $('#DivOverrid').modal('show');
        }

        function openModalDivConfirmation() {
            $('#DivConfirmation').modal({
                backdrop: 'static'
            })

            $('#DivConfirmation').modal('show');
        }

        function ValidateEnterKey(evt) {
            if (evt.keyCode == 13) //detect Enter key
            {
                return false;
            }
            else {
                return true;
            }
        }

        function autoTab(input, len, e) {
            var keyCode = (isNN) ? e.which : e.keyCode;
            var filter = (isNN) ? [0, 8, 9] : [0, 8, 9, 16, 17, 18, 37, 38, 39, 40, 46];
            if (input.value.length >= len) {
                input.value = input.value.slice(0, len);
                input.form[(getIndex(input) + 1)].focus();
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="breadcrumbs" class="position-relative" style="height: 53px">
        <ul class="breadcrumb" style="height: 15px">
            <li><i class="icon-home"></i><a href="Report_Dashboard.aspx">Home</a><span class="divider"><i
                class="icon-angle-right"></i></span></li>
            <li>
                <h4 class="blue">
                    CRM Index Report<span class="divider"></span></h4>
            </li>
        </ul>
        <div id="nav-search">
            <!-- /btn-group -->
            <%--<asp:Button class="btn  btn-app btn-primary btn-mini radius-4  " Visible="true" runat="server"
                ID="BtnShowSearchPanel" Text="Search" OnClick="BtnShowSearchPanel_Click" />--%>
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
                                        Height="25px" OnClick="HLExport_Click" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>                     
                <div class="row-fluid">                       

                        <asp:DataList ID="dlGridDisplay" CssClass="table table-striped table-bordered table-hover"
                                    runat="server" Width="100%" border="1" Style="border-collapse: collapse">
                                    <HeaderTemplate>
                                        <b>Class</b> </th>
                                        <th style="text-align: center">
                                            Board
                                        </th>
                                        <th style=" text-align: center">
                                            Year Of Passing
                                        </th>
                                        <th style=" text-align: center">
                                            Country
                                        </th>
                                        <th style=" text-align: center">
                                            State
                                        </th>
                                        <th style=" text-align: center">
                                            City
                                        </th>
                                        <th style=" text-align: center">
                                            Location
                                        </th>
                                        <th style=" text-align: center">
                                            Total
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblClass" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Class")%>' />
                                        </td>
                                        <td style="text-align: left">
                                            <asp:Label ID="lblBoard" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Board")%>' />
                                        </td>
                                        <td style="text-align: center">
                                            <asp:Label ID="lblYearOfPassing" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"YearOfPassing")%>' />
                                        </td>
                                         <td style="text-align: left">
                                            <asp:Label ID="lblCountry" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Country")%>' />
                                        </td>
                                        <td style="text-align: left">
                                            <asp:Label ID="lblState" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"State")%>' />
                                        </td>
                                        <td style="text-align: left">
                                            <asp:Label ID="lblCity" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"City")%>' />
                                        </td>
                                        <td style="text-align: left">
                                            <asp:Label ID="lblLocation" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Location")%>' />
                                        </td>
                                        <td style="text-align: center">
                                            <asp:Label ID="lblTotal" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Total")%>' />
                                            
                                    </ItemTemplate>
                                </asp:DataList>                       
                </div>
               

            </div>            
        </div>
    </div>
</asp:Content>
