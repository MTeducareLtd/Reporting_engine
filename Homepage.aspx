﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="Homepage.aspx.cs" Inherits="Homepage" %>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContainer" runat="Server">
    <div id="breadcrumbs" class="position-relative">
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Homepage.aspx">Home</a><span class="divider"><i
                class="icon-angle-right"></i></span></li>
            <li>
                <h5 class="blue">
                    Dashboard<span class="divider"></span></h5>
            </li>
        </ul>
        <div id="nav-search" class="middle">
            <asp:Label ID="lblReportPeriod" runat="server"></asp:Label>
        </div>
        <!--#nav-search-->
    </div>
    <div id="page-content" class="clearfix">
        <div class="row-fluid">
            <!-- BEGIN DASHBOARD STATS -->
            <!--START DASHBOARD STATS-->
            <div class="row-fluid">
                <div class="span12 infobox-container">
                <div class="infobox infobox-green">
                    <div class="infobox-icon">
                        <i class="icon-bullhorn"></i>
                    </div>
                    <div class="infobox-data">
                        <span class="infobox-data-number">
                            <asp:Label ID="lblleadcount" runat="server"></asp:Label></span>
                        <a class="more" href="#"><span class="infobox-content">Lead</span></a>
                    </div>
                    <div class="badge badge-success">
                        </div>
                </div>
                <div class="infobox infobox-blue">
                    <div class="infobox-icon">
                        <i class="icon-user"></i>
                    </div>
                    <div class="infobox-data">
                        <span class="infobox-data-number">
                            <asp:Label ID="lblopportunitycount" runat="server"></asp:Label></span>
                        <a class="more" href="#"><span class="infobox-content">Opportunity</span></a> 
                    </div>
                    <div class="badge badge-info">
                        </div>
                </div>
                <div class="infobox infobox-orange">
                    <div class="infobox-icon">
                        <i class="icon-book"></i>
                    </div>
                    <div class="infobox-data">
                        <span class="infobox-data-number"><asp:Label ID="lblAccountCount" runat="server"></asp:Label></span> 
                        <a class="more" href="#"><span class="infobox-content">Account</span></a>
                    </div>
                    <div class="badge badge-warning">
                        </div>
                </div>
                <div class="infobox infobox-red">
                    <div class="infobox-icon">
                        <i class="icon-check"></i>
                    </div>
                    <div class="infobox-data">
                        <span class="infobox-data-number">
                            <asp:Label ID="lblconversion" runat="server"></asp:Label></span>
                        <a class="more" href="#"><span class="infobox-content">Conversion</span></a>
                    </div>
                    <div class="badge badge-important">
                        </div>
                </div>

                </div> 

            </div>
            <!-- END DASHBOARD STATS -->
            <div class="hr hr32 hr-dotted">
            </div>
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-header widget-hea1der-small">
                        <h4 class="lighter">
                            <i class="icon-bullhorn green"></i>Lead - Summary</h4>
                        <div class="widget-toolbar">
                            <button type="button" class="btn btn-success btn-mini radius-4 icon-download-alt"
                                title="Export" id="btnexport" runat="server">
                            </button>
                            <asp:DropDownList ID="ddlcompanyselect" runat="server" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>

                    </div>
                    <div class="widget-body">
                        <div class="widget-main">
                            <div class="widget-main no-padding" style="height: 240px; overflow-y: scroll; overflow-x: none;">
                                <div class="content">
                                    <asp:GridView ID="dlleadsummary" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover">
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="hr hr12">
            </div>
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-header widget-hea1der-small">
                        <h4 class="lighter">
                            <i class="icon-user blue"></i>Opportunity - Summary</h4>
                        <div class="widget-toolbar">
                            <button type="button" class="btn btn-primary btn-mini radius-4 icon-download-alt" title="Export" id="btnexpopp" runat="server">
                                        </button>
                            <asp:DropDownList ID="ddlcompanysearchopp" runat="server" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>

                    </div>
                    <div class="widget-body">
                        <div class="widget-main">
                            <div class="widget-main no-padding" style="height: 240px; overflow-y: scroll; overflow-x: none;">
                                <div class="content">
                                    <asp:GridView ID="dloppsummary" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover">
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
