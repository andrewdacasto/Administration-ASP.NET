<%@ Page Title="Search Jobs Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmSearchRejectSN.aspx.vb" Inherits="Telling___Administration__ASP.NET_.FrmSearchRejectSN" %>

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

            $('#dgvSearch_JobsData').dataTable({
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



            $("table#dgvSearch_JobsData").dataTable().columnFilter(
                {
                    //sPlaceHolder: "foot:before",
                    "aoColumns": [
                                    { "type": "text", width: "20px", height: "20px" },//////{ "type": "number-range" },
                                    { "type": "select", width: "20px", height: "20px" },
                                    { "type": "select", width: "20px", height: "20px" },
                                    { "type": "select", width: "20px", height: "20px" },
                                    { "type": "date-range", width: "20px", height: "20px" },
                                    { "type": "select", width: "20px", height: "20px" },
                                    { "type": "select", width: "20px", height: "20px" },
                                    { "type": "select", width: "20px", height: "20px" },
                    ]
                });

            // -------------  Fixed Header   -------------
            //            oTable = $('#dgvSearch_JobsData').dataTable();
            //            new FixedHeader(oTable);

            //$('#dgvSearch_JobsData div.title').text("This is a table title");

            /* Add a click handler to the rows - this could be used as a callback */
            $("#dgvSearch_JobsData tbody tr").click(function (e) {
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
                        $("#dgvSearch_JobsData tbody tr").removeClass('row_selected');
                        $('#btnDelete').hide();
                    }
                }
            });

            $.fn.dataTableExt.oStdClasses["filterColumn"] = "my-style-class";

            $('#dgvSearch_JobsData tbody td').click(function () {
                /* Get the position of the current data from the node */
                var aPos = oTable.fnGetPosition(this);
                var aData = oTable.fnGetData(aPos[0]);
                //alert(aData[0]);
            });

            /* Init the table */
            oTable = $('#dgvSearch_JobsData').dataTable();
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
        <section class="featured">
                  <div class="search-jobs-content">                       
                      <h2 id="browse-jobs-header">Search Jobs</h2>
                      <p>&nbsp;</p>
                      <asp:GridView ID="dgvSearch_JobsData" runat="server" OnPreRender="dgvSearch_JobsData_PreRender" ShowFooter="True" ShowHeaderWhenEmpty="True" Height="50px" Width="560px" AutoGenerateColumns="False" DataSourceID="SDSSearch" ClientIDMode="Static">
                          <Columns>
                              <asp:BoundField DataField="Serial" HeaderText="Serial" SortExpression="Serial" />
                              <asp:BoundField DataField="Panel No." HeaderText="Panel No." SortExpression="Panel No." />
                              <asp:BoundField DataField="Last Process" HeaderText="Last Process" SortExpression="Last Process" />
                              <asp:BoundField DataField="Last User" HeaderText="Last User" SortExpression="Last User" />
                              <asp:BoundField DataField="Last Update" HeaderText="Last Update" SortExpression="Last Update" />
                              <asp:BoundField DataField="Project No." HeaderText="Project No." SortExpression="Project No." />
                              <asp:BoundField DataField="Pallet ID" HeaderText="Pallet ID" SortExpression="Pallet ID" />
                              <asp:BoundField DataField="Reject User" HeaderText="Reject User" SortExpression="Reject User" />
                          </Columns>
                       </asp:GridView>                      
                      <asp:SqlDataSource ID="SDSSearch" runat="server" ConnectionString="<%$ ConnectionStrings:conTelling %>" SelectCommand="SELECT idwpSN AS Serial, PN AS [Panel No.], Last_process AS [Last Process], Last_User AS [Last User], Last_Update AS [Last Update], Project_Num AS [Project No.], PalletID AS [Pallet ID], Reject_User AS [Reject User] FROM wpRejectSN">
                      </asp:SqlDataSource>
                   </section>    
</asp:Content>