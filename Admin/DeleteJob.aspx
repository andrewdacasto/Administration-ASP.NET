<%@ Page Title="Administration" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DeleteJob.aspx.vb" Inherits="Telling___Administration__ASP.NET_.DeleteJob" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
        <head>
            <%--<link href="media_ColVis/css/ColVisAlt.css" rel="stylesheet" type="text/css" />--%>
    <link href="media_ColVis/css/ColVis.css" rel="stylesheet" type="text/css" />
    <link href="media/css/TableTools.css" rel="stylesheet" type="text/css" />
    <link href="media/css/TableTools_JUI.css" rel="stylesheet" type="text/css" />

    <link href="Scripts/css/themes/smoothness/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="Scripts/css/themes/smoothness/jquery.ui.theme.css" rel="stylesheet" type="text/css" />
    

    <link href="Scripts/css/jquery.dataTables_themeroller.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/js/jquery.js" type="text/javascript"></script>
    <script src="Scripts/js/jquery.dataTables.min.js" type="text/javascript"></script>
    <script src="media/js/ZeroClipboard.js" type="text/javascript"></script>
            <%--<script src="media/js/TableTools.min.js" type="text/javascript"></script>--%>
    <script src="media/js/TableTools.js" type="text/javascript"></script>
    <script src="Scripts/js/jquery.dataTables.columnFilter.js" type="text/javascript"></script>
    <script src="Scripts/js/jquery-ui-1.9.2.custom.min.js" type="text/javascript"></script>
    <script src="Scripts/js/FixedHeader.js" type="text/javascript"></script>
    <script src="media_ColVis/js/ColVis.js" type="text/javascript"></script>
    <style type="text/css">
        .ui-datepicker-calendar tr, .ui-datepicker-calendar td, .ui-datepicker-calendar td a, .ui-datepicker-calendar th
        {
            font-size: inherit;
        }
        div.ui-datepicker
        {
            font-size: 10px;
        }
        .ui-datepicker-title span
        {
            font-size: 10px;
        }
        
        .my-style-class input[type=text]
        {
            color: green;
        }
    </style>
    <script type="text/javascript">
        var oTable;
        $(document).ready(function () {
            $.datepicker.regional[""].dateFormat = 'dd/mm/yy';
            $.datepicker.setDefaults($.datepicker.regional['']);

            TableTools.DEFAULTS.aButtons = [
							"copy", "csv", "xls", "pdf", "print",
							{
							    "sExtends": "collection",
							    "sButtonText": "Save",
							    "aButtons": [
                                                "csv",
                                                "xls",
							                    //"pdf",
                                                {
                                                    "sExtends": "pdf",
                                                    //"sPdfOrientation": "landscape",
                                                    "sPdfMessage": "Your custom message would go here."
                                                },
                                                "print"
							    ]
							}]

            //TableTools.DEFAULTS.aButtons = [ "copy", "csv", "xls",  "pdf" ];



            /*          Main Functionality       */

            $('#dgvJobs').dataTable({
                //"oLanguage": { "sSearch": "Search the nominees:" },
                "aLengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
                "iDisplayLength": 10,
                "aaSorting": [[0, "asc"]],
                "bJQueryUI": true,
                "bAutoWidth": true,
                "bProcessing": true,
                "sDom": '<"top"i><"title">lt<"bottom"pf>',
                "sPaginationType": "full_numbers",
                "bRetrieve": true,

                //Scrolling--------------
                "sScrollY": "250px",
                "sScrollX": "100%",
                "sScrollXInner": "100%",
                "bScrollCollapse": true,

                // ----  Print_Export_Copy  ----                
                "sDom": 'T<"clear"><"H"lfr>t<"F"ip>',
                //"sDom": '<"top"iflp<"clear">>rt<"bottom"iflp<"clear">>',                            

                // ----- Column Visiblity ------                
                //"sDom": '<"H"Cfr>t<"F"ip>',                
                //                "oColVis":
                //                {
                //                    //"sDom": 'C<"clear">lfrtip',
                //                    "activate": "mouseover"                    
                //		            //"bJQueryUI": true
                //                },



                //--- Dynamic Language---------
                "oLanguage": {
                    "sZeroRecords": "There are no Records that match your search critera",
                    "sLengthMenu": "Display _MENU_ records per page&nbsp;&nbsp;",
                    "sInfo": "Displaying _START_ to _END_ of _TOTAL_ records",
                    "sInfoEmpty": "Showing 0 to 0 of 0 records",
                    "sInfoFiltered": "(filtered from _MAX_ total records)",
                    "sEmptyTable": 'No Rows to Display.....!',
                    "sSearch": "Search all columns:"
                },

                /* Column Sorting And Searching */
                //                "aoColumns": [
                //								{ "bSearchable": false }, //Disable search on this column 1
                //								{"bSortable": false }, //Disable sorting on this column 2               
                //								{"asSorting": ["asc"] }, //Allow only "asc" sorting on column 2
                //								null,
                //								{ "sSortDataType": "dom-text", "sType": "numeric" },
                //								{ "iDataSort": 4 }, //Use column 4 to perform sorting
                //								null,
                //								null
                //							 ],


                /*  Column Visibilities */
                //				"aoColumns": [
                //				            /* Sno */{"bSearchable": false, "bVisible": false},
                //							/* Engine */   null,
                //							/* Browser */  null,
                //							/* Platform */ { "bSearchable": false, "bVisible":    false },
                //							/* Version */  { "bSearchable": false, "bVisible":    false },
                //				            /* Grade */     null,
                //                            /* Share */    null,
                //                            /* Date */    null
                //						],

                "oSearch": {
                    "sSearch": "",
                    "bRegex": false,
                    "bSmart": true
                },

                //------------------------Total in footer                

            });

            // ------- Header Buttons -----------
            $('<a id="btnDelete" style="padding: 0px; display:none;" class="ui-button ui-widget ui-state-default ui-corner-all'
            + 'ui-button-text-only" href="javascript:void(0)"><span style="font-size: small; padding: 2px 5px;"'
            + 'class="ui-button-text"> Delete selected Row</span></a>&nbsp;&nbsp;<button id="refresh">Refresh</button>').appendTo('div.dataTables_length');
            //$('<button id="refresh">Refresh</button>').appendTo('div.dataTables_length'); //ReFresh Button



            $("table#dgvJobs").dataTable().columnFilter(
                {
                    //sPlaceHolder: "foot:before",
                    "aoColumns": [
                                    { "type": "text" },//////{ "type": "number-range" },
                                    { "type": "text" },
                                    { "type": "select" },
                                    { "type": "select" },
                                    { "type": "date-range" },
                                    { "type": "select" },
                                    { "type": "text" },
                                    { "type": "select" },
                    ]
                });

            // -------------  Fixed Header   -------------
            //            oTable = $('#dgvJobs').dataTable();
            //            new FixedHeader(oTable);

            //$('#dgvJobs div.title').text("This is a table title");

            /* Add a click handler to the rows - this could be used as a callback */
            $("#dgvJobs tbody tr").click(function (e) {
                if ($(this).hasClass('row_selected')) {
                    $(this).removeClass('row_selected');
                    $('#btnDelete').hide();
                }
                else {
                    oTable.$('tr.row_selected').removeClass('row_selected');
                    $(this).addClass('row_selected');
                    $('#btnDelete').show();
                }
            });

            /* Add a click handler for the delete row */
            $('#btnDelete').click(function () {
                var anSelected = fnGetSelected(oTable);
                if (anSelected.length !== 0) {
                    /* Nedd Ajax Call To perform in serverSide*/
                    if (confirm('Are you sure you wish to delete this row?')) {
                        /* do the delete */
                        oTable.fnDeleteRow(anSelected[0]);
                    }
                    else {
                        $("#dgvJobs tbody tr").removeClass('row_selected');
                        $('#btnDelete').hide();
                    }
                }
            });

            $.fn.dataTableExt.oStdClasses["filterColumn"] = "my-style-class";

            $('#dgvJobs tbody td').click(function () {
                /* Get the position of the current data from the node */
                var aPos = oTable.fnGetPosition(this);
                var aData = oTable.fnGetData(aPos[0]);
                //alert(aData[0]);
            });

            /* Init the table */
            oTable = $('#dgvJobs').dataTable();
        });

        function fnGetSelected(oTableLocal) {
            return oTableLocal.$('tr.row_selected');
        }
        //$("div.tools").html('Organize by: <select id="booking_status"><option value="">All Bookings</option><option value="confirmed">Upcoming</option><option value="arrived">Arrived</option><option value="rejected">Rejected</option></select>');
    </script>
        </head>
</html>
</asp:Content>
<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <h2>Administration - Delete</h2>
    <p></p>
    <asp:Panel ID="panDelete" runat="server" style="margin-bottom: 0px; margin-right: 0px;" BackColor="#FF9900" BorderStyle="Double" Height="556px" Width="605px" GroupingText="Filter Serial Numbers">
    
        <p>
            <asp:Label ID="Lbl" runat="server" Text="Project Name :" Width="160px"></asp:Label>
            <asp:DropDownList ID="DDProjectNo" runat="server" Height="26px" Width="158px">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;
        </p>
        
        <p>
            &nbsp;</p>
        <p style="margin-top:-25px;top: 0px;">
            <asp:Label ID="label8" runat="server" Text="Serial:" Width="160px"></asp:Label>
            <asp:TextBox ID="txtSerial" runat="server" Width="120px"></asp:TextBox>
        </p>
        <p style="margin-top:-5px;">
            <asp:Label ID="Label9" runat="server" Text="Stage:" Width="160px"></asp:Label>
            <asp:TextBox ID="txtStage" runat="server" Width="120px"></asp:TextBox>
        </p>
        <p style="margin-top:-5px;">
            <asp:Label ID="Label10" runat="server" Text="Panel Ref:" Width="160px"></asp:Label>
            <asp:TextBox ID="txtPanel" runat="server" Width="120px"></asp:TextBox>
        </p>
        <p style="margin-top:-5px;">
            <asp:Label ID="Label11" runat="server" Text="User ID:" Width="160px"></asp:Label>
            <asp:DropDownList ID="DDUser1" runat="server" DataValueField="User" Height="16px" Width="120px">
            </asp:DropDownList>
        </p>
        <asp:Label ID="Label12" runat="server" Text="Date Range:" Width="120px"></asp:Label>
        <p>
            &nbsp;</p>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Always">
            <ContentTemplate>
                <div id="Cal1" style="width:40%">
                    &nbsp;&nbsp;<asp:Label ID="Label7" runat="server" Text="From:" Width="30px"></asp:Label>
                    <asp:Calendar ID="CalFrom" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" Width="220px" SelectedDate="2013-01-01">
                        <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                        <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                        <OtherMonthDayStyle ForeColor="#CC9966" />
                        <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                        <SelectorStyle BackColor="#FFCC66" />
                        <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                        <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                    </asp:Calendar>
                </div>
                <div id="Cal2" style="width:45%; position:relative; margin-top:-216px;left:300px; top: 0px;">
                    <asp:Label ID="Label6" runat="server" Text="To:" Width="30px"></asp:Label>
                    <asp:Calendar ID="CalTo" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" Width="220px">
                        <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                        <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                        <OtherMonthDayStyle ForeColor="#CC9966" />
                        <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                        <SelectorStyle BackColor="#FFCC66" />
                        <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                        <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                    </asp:Calendar>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <p>
        </p>
        <p style="margin-top:-10px;">
            <asp:Button ID="txtSearch" runat="server" Text="Search" />
            <asp:Label ID="lblError0" runat="server"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        
    </asp:Panel>
    <br />
     <asp:GridView ID="dgvJobs" runat="server" ShowFooter="True" ShowHeaderWhenEmpty="True" Height="50px" Width="605px" AutoGenerateColumns="False" DataSourceID="SqlDataSource" ClientIDMode="Static">
         <Columns>
             <asp:CommandField SelectText="Delete" ShowSelectButton="True" />
             <asp:BoundField DataField="Serial" HeaderText="Serial" SortExpression="Serial" />
             <asp:BoundField DataField="Panel Ref" HeaderText="Panel Ref" SortExpression="Panel Ref" />
             <asp:BoundField DataField="Last Process" HeaderText="Last Process" SortExpression="Last Process" />
             <asp:BoundField DataField="Last Update" HeaderText="Last Update" SortExpression="Last Update" />
             <asp:BoundField DataField="Project Name" HeaderText="Project Name" SortExpression="Project Name" />
             <asp:BoundField DataField="Last_User" HeaderText="Last_User" SortExpression="Last_User" />
             <asp:BoundField DataField="PalletID" HeaderText="PalletID" SortExpression="PalletID" />
         </Columns>
        </asp:GridView>
    <p>
            &nbsp;</p>
    <p>
            <asp:Label ID="lblDelete" runat="server" Width="475px"></asp:Label>
        </p>
    <p>
            <asp:Label ID="Label3" runat="server" Width="80px"></asp:Label>
            <asp:CheckBox ID="chkDelete" runat="server" Text="Delete" Visible="False" />
            <asp:Label ID="Label4" runat="server" Width="100px"></asp:Label>
            <asp:CheckBox ID="chkRework" runat="server" Text="Rework" Visible="False" />
            <asp:Label ID="Label5" runat="server" Width="100px"></asp:Label>
            <asp:CheckBox ID="chkReject" runat="server" Text="Reject" Visible="False" />
        </p>
    <p>
            <asp:Label ID="Label1" runat="server" Width="160px"></asp:Label>
            <asp:Button ID="cmdConfirm" runat="server" Text="Confirm" Visible="False" />
            <asp:Label ID="Label2" runat="server" Width="100px"></asp:Label>
            <asp:Button ID="cmdCancel" runat="server" Text="Cancel" Visible="False" />
        </p>
    <p>
            <asp:Label ID="lblError" runat="server" Width="519px"></asp:Label>
            </p>
    <p>
            &nbsp;</p>
    <p>
            <asp:Label ID="lblSqlDelete" runat="server" Width="160px" Visible="False"></asp:Label>
            <asp:Label ID="lblSelectCell" runat="server" Width="160px" Visible="False"></asp:Label>
            </p>
                      <asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:conTelling %>" SelectCommand="SELECT TOP (2000) wpSN.idwpSN AS Serial, wpSN.PN AS [Panel Ref], wpSN.Last_process AS [Last Process], wpSN.Last_Update AS [Last Update], wpProjectHeader.Project_Name AS [Project Name], wpSN.Last_User, wpSN.PalletID FROM wpSN INNER JOIN wpProjectHeader ON wpSN.Project_Num = wpProjectHeader.Project_Num WHERE (wpProjectHeader.Project_Name LIKE @Project) AND (wpSN.idwpSN LIKE @Serial) AND (wpSN.Last_process LIKE @Stage) AND (wpSN.PN LIKE @Panel) AND (wpSN.Last_Update &gt;= CONVERT (DATETIME, @DateFrom + ' 23:59:59.000', 102)) AND (wpSN.Last_Update &lt;= CONVERT (DATETIME, @DateTo, 102)) AND (wpSN.Last_User LIKE @User )" DeleteCommand="DELETE FROM wpSN WHERE idwpSN = @Serial">
                          <DeleteParameters>
                              <asp:Parameter Name="Serial" />
                          </DeleteParameters>
                          <SelectParameters>
                              <asp:ControlParameter ControlID="DDProjectNo" DefaultValue="%" Name="Project" PropertyName="SelectedValue" />
                              <asp:ControlParameter ControlID="txtSerial" DefaultValue="%" Name="Serial" PropertyName="Text" />
                              <asp:ControlParameter ControlID="txtPanel" DefaultValue="%" Name="Panel" PropertyName="Text" />
                              <asp:ControlParameter ControlID="txtStage" DefaultValue="%" Name="Stage" PropertyName="Text" />
                              <asp:ControlParameter ControlID="CalTo" DefaultValue="" Name="DateTo" PropertyName="SelectedDate" />
                              <asp:ControlParameter ControlID="CalFrom" DefaultValue="" Name="DateFrom" PropertyName="SelectedDate" />
                              <asp:ControlParameter ControlID="DDUser1" DefaultValue="%" Name="User" PropertyName="SelectedValue" />
                          </SelectParameters>
    </asp:SqlDataSource>
     <br />
     </asp:Content>

