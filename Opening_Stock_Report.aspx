﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Reports.Master" AutoEventWireup="true"
    CodeFile="Opening_Stock_Report.aspx.cs" Inherits="Opening_Stock_Report" %>

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
    <div id="breadcrumbs" class="position-relative">
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Report_Dashboard.aspx">Home</a><span class="divider"><i
                class="icon-angle-right"></i></span></li>
            <li>
                <h5 class="smaller">
                    Opening Stock Report<span class="divider"></span></h5>
            </li>
        </ul>
        <div id="nav-search">
            <!-- /btn-group -->
            <%--<asp:Button class="btn  btn-app btn-success btn-mini radius-4" runat="server" ID="BtnAdd"
                Text="Add" OnClick="BtnAdd_Click" />--%>
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
                                         <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label13" runat="server" CssClass="red">Location Type</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlLocationType" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Location Type" Width="215px" OnSelectedIndexChanged="ddlLocationType_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="tblFr_GodownSearch" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label22" runat="server" CssClass="red">Godown Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlgodownFR_SRSearch" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Godown" Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="tblFr_DivisionSearch" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label23" runat="server" CssClass="red">Division Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlDivisionFR_SRSearch" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Division" Width="215px" OnSelectedIndexChanged="ddlDivisionFR_SRSearch_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="tblFr_FunctionSearch" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label24" runat="server" CssClass="red">Function Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlFunctionFR_SRSearch" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Function" Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%"
                                                        runat="server" id="tblFr_CenterSearch" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label25" runat="server" CssClass="red">Center Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlCenterFR_SRSearch" runat="server" CssClass="chzn-select" data-placeholder="Select Center"
                                                                    Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <%--<tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label8" runat="server">Transfer To</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlTransferTO_SR" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Transfer To" Width="215px" 
                                                                    onselectedindexchanged="ddlTransferTO_SR_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover" runat="server" id="tblTO_Godown" visible ="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label9" runat="server">Godown</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlgodownTO_SR" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Godown" Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover" runat="server" id="tblTO_Division" visible ="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label16" runat="server">Division</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlDivisionTO_SR" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Division" Width="215px" 
                                                                    onselectedindexchanged="ddlDivisionTO_SR_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                     <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="tblTO_Function" visible ="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label19" runat="server">Function</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlFunctionTO_SR" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Function" Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%" runat="server" id="tblTO_Center" visible ="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label17" runat="server">Center</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlCenterTO_SR" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Center" Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>--%>
                                            
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
                    <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                    <tr>
                        <td class="span6" style="text-align: left">
                            <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                <tr>
                                    <td style="border-style: none; text-align: left; width: 40%;">
                                        <asp:Label runat="server" ID="Label7">Location Type</asp:Label>
                                    </td>
                                    <td style="border-style: none; text-align: left; width: 60%;">
                                        <asp:Label runat="server" ID="lblLocationType_Result" Text="" CssClass="blue" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="span6" style="text-align: left">
                            <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                <tr>
                                    <td style="border-style: none; text-align: left; width: 40%;">
                                        <asp:Label runat="server" ID="Label17">Location</asp:Label>
                                    </td>
                                    <td style="border-style: none; text-align: left; width: 60%;">
                                        <asp:Label runat="server" ID="lblLocationResult" class="blue"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                </div>
<%--
                <asp:Repeater ID="dlGridDisplay" runat="server" OnItemCommand="dlGridDisplay_ItemCommand">
                    <HeaderTemplate>
                        <table class="table table-striped table-bordered table-hover Table2">
                            <thead>
                                <tr>
                                    <th>
                                        
                                    </th>
                                    <th style="width: 10%; text-align: center;">
                                        Inward Entry Code
                                    </th>                                    
                                    <th style="width: 10%; text-align: center;">
                                        Item Code
                                    </th>
                                    <th style="width: 30%; text-align: center;">
                                        Item Name
                                    </th>
                                    <th style="width: 15%; text-align: center;">
                                        Chalan Quantity
                                    </th>
                                    <th style="width: 20%; text-align: center;">
                                        EAN Number
                                    </th>
                                    <th style="width: 10%; text-align: center;">
                                        
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="odd gradeX">
                            <td>
                                <asp:CheckBox ID="chkCheck" runat="server" 
                                    AutoPostBack="true" Checked="false" Visible='<%#(string)DataBinder.Eval(Container.DataItem,"Is_Authorised") == "1" ? false : true%>' />
                                <span class="lbl"></span> 
                            </td>
                            <td>
                                <asp:Label ID="lblInwardEntryCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"InwardEntry_Code")%>' />
                            </td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblItemCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"lblMaterialCode_DT")%>' />
                            </td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblItemName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"lblMaterialName_DT")%>' />
                            </td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblChalanQty" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"lblChallanQty_DT")%>' />
                            </td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblBarcode_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"lblBarcode_DT")%>' />
                                <asp:Label ID="lblAssetType" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"AssetType")%>' />
                            </td>
                            <td style="text-align: center;">
                                <div class="inline position-relative">
                                    <asp:LinkButton ID="lnkEdit" ToolTip="Edit" class="btn-small btn-primary icon-info-sign"
                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"InwardEntry_Code")%>' runat="server"
                                        CommandName="comEdit" Height="25px" />
                                    <asp:LinkButton ID="lnkAuthorise" ToolTip="Authorise" class="btn-small btn-warning  icon-lock"
                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"InwardEntry_Code")%>' runat="server"
                                        CommandName="comAuthorise12" Height="25px" Visible='<%#(string)DataBinder.Eval(Container.DataItem,"Is_Authorised") == "1" ? true : false%>' />
                                </div>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody> </table>
                    </FooterTemplate>
                </asp:Repeater>--%>

                

                <asp:DataList ID="dlGridDisplay" CssClass="table table-striped table-bordered table-hover"
                    runat="server" Width="100%" >
                    <HeaderTemplate>
                        <b> Location Type</b> </th>
                        <th style="width: 10%; text-align: center;">
                            Division
                        </th> 
                        <th style="width: 10%; text-align: center;">
                            Location
                        </th>
                         <th style="width: 10%; text-align: center;">
                            Inward Entry Code
                        </th>                                                           
                        <th style="width: 10%; text-align: center;">
                            Item Code
                        </th>
                        <th style="width: 20%; text-align: center;">
                            Item Name
                        </th>
                        <th style="width: 10%; text-align: center;">
                            Chalan Quantity
                        </th>
                        <th style="width: 10%; text-align: center;">
                            EAN Number
                         </th>
                        <th style="width: 10%; text-align: center;">
                            SAP Asset No
                        </th>
                         <th style="width: 10%; text-align: center;">
                            ATMS Asset No
                    </HeaderTemplate>
                    <ItemTemplate>
                                <asp:Label ID="lblLocationType" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"LocationType")%>' />
                            </td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblDivision" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Division")%>' />
                            </td>
                             <td style="text-align: left;">
                                <asp:Label ID="lblLocation" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Location")%>' />
                            </td>
                             <td style="text-align: left;">
                                <asp:Label ID="lblInwardEntryCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"InwardEntry_Code")%>' />
                            </td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblItemCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"lblMaterialCode_DT")%>' />
                            </td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblItemName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"lblMaterialName_DT")%>' />
                            </td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblChalanQty" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"lblChallanQty_DT")%>' />
                            </td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblBarcode_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"lblBarcode_DT")%>' />
                                <asp:Label ID="lblAssetType" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"AssetType")%>' />
                            </td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblSAPAssetNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Sap_Asset_No")%>' />
                            </td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblATMSAssetNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Asset_No")%>' />
                            </td>
                    </ItemTemplate>
                </asp:DataList>
<%--
                <div class="widget-main alert-block alert-success  alert- " style="text-align: center;">
                    <!--Button Area -->
                    <asp:Label runat="server" ID="Label19" Text="" ForeColor="Red" />
                    <asp:Button class="btn btn-app btn-success btn-mini radius-4" 
                        ID="btnAllAuthorise" runat="server"
                        Text="Authorise" ValidationGroup="UcValidate" width="80px" 
                        onclick="btnAllAuthorise_Click"  />                    
                    <asp:ValidationSummary ID="ValidationSummary4" ShowSummary="false" DisplayMode="List"
                        ShowMessageBox="true" ValidationGroup="UcValidate" runat="server" />
                </div>--%>
            </div>            
        </div>
    </div>
</asp:Content>
