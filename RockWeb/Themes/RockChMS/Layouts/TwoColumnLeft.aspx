﻿<%@ Page Title="" ValidateRequest="false" Language="C#" MasterPageFile="~/Themes/RockChMS/Layouts/Site.Master"
    AutoEventWireup="true" Inherits="Rock.Web.UI.RockPage" %>

<asp:Content ID="ctMain" ContentPlaceHolderID="main" runat="server">
    
    <div id="page-frame">
        <header id="page-header" class="navbar navbar-fixed-top">
            <div class="container-fluid">
                <div class="row-fluid">
                    <div class="span3">
                        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="brand" NavigateUrl="~" Text="Rock ChMS" />
                    </div>
                    <div class="span9">
                        <div class="content pull-right">
                            <Rock:Zone ID="zHeader" Name="Header" runat="server" />
                            <Rock:SearchField ID="searchField" runat="server" />
                        </div>
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span12">
                        <Rock:Zone ID="Menu" runat="server" />
                        <a href="" id="header-lock">Lock</a>
                    </div>
                </div>
            </div>
        </header>


        <div id="page-title" class="navbar">
            <div class="container-fluid">
                <div class="row-fluid">
                    <div class="span3">
                        <h1><Rock:PageTitle ID="PageTitle" runat="server" /></h1>
                    </div>
                    <div class="span9">
                        <Rock:Zone ID="PageTitleBar" runat="server" />
                    </div>
                </div>
            </div>
        </div>

        <div class="container-fluid">
            <div class="row-fluid">
                <div class="span12">

                    <%-- Content Area --%>
                    
                    <div id="group-viewer" class="row-fluid">
                        <a href="#" onclick="javascript: $('#leftContentDiv').toggle(500);" >hide/show</a>
                        <div id="vertical">
                            <div id="leftContentDiv" class="span3" style="border-right: 1px solid #808080">
                                <Rock:Zone ID="LeftContent" runat="server" />
                            </div>
                            <div class="span9">
                                <Rock:Zone ID="RightContent" runat="server" />
                            </div>
                        </div>
                    </div>

                    <%-- End Content Area --%>
                </div>
            </div>
        </div>

        <div id="page-footer" class="navbar">
            <div class="container-fluid">
                <div class="row-fluid">
                    <div class="span12">
                        <Rock:Zone ID="Footer" runat="server" />
                    </div>
                </div>
            </div>
        </div>


    </div>

    <script>
        /*  kendoSplitter (not ready)
        $(document).ready(function () {

            
            var splitter = $("#vertical");

            splitter.kendoSplitter({
                panes: [
                    { size: "300px", collapsible: true, scrollable: false },
                    { scrollable: false }
                ]
            });
            
        });
        */

        /* script to manage header lock */
        $(document).ready(function () {
            var headerIsLocked = localStorage.getItem("rock-header-lock");

            if (headerIsLocked == "true") {
                $('#page-header').addClass('navbar-fixed-top');
            }
            else {
                $('#page-header').removeClass('navbar-fixed-top');
            }

            setHeaderLock();
        });

        $('#header-lock').click(function (e) {
            $('#page-header').toggleClass('navbar-fixed-top');

            setHeaderLock();

            e.preventDefault();
        });

        function setHeaderLock() {
            if ($('#page-header').hasClass('navbar-fixed-top')) {
                localStorage.setItem('rock-header-lock', 'true');
                // set location of page title
                var headerHeight = $('#page-header').height();
                $('#page-title').css('margin-top', '98px');
            }
            else {
                localStorage.setItem('rock-header-lock', 'false');
                $('#page-title').css('margin-top', 0);
            }
        }
    </script>

</asp:Content>

