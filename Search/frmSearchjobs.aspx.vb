Imports System.Data.SqlClient

Public Class frmSearchJobs
    Inherits System.Web.UI.Page
    Dim cls As New Connection_Component
    Public con As SqlConnection = cls.con
    Public cmd As New SqlCommand
    Public ELog As New EventLog
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load, MyBase.Load, MyClass.Load
        cls.ConnectSQL()
        If cls.Connected = "0" Then
            cls.ConnectSQL()
        End If
        If IsPostBack = False Then
            DDUser.Text = ""
        End If
        dgvSearch_JobsData.DataSourceID = ""
        dgvSearch_JobsData.DataSourceID = "SDSSearch"
        Try
            Dim SQL As String = "SELECT [User] FROM wpSnop GROUP BY [User] ORDER BY [User]"
            Dim DT As New DataTable
            Dim cmd As SqlCommand = New SqlCommand(SQL, cls.con)
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            da.Fill(DT)
            If DDUser.Text = "" Then
                DDUser.Items.Clear()
                DDUser.Items.Add("")
                For Each line As Data.DataRow In DT.Rows
                    DDUser.Items.Add(line.Item(0))
                Next
            End If
        Catch ex As Exception
            lblError.Text = "Failed to Search" & ex.Message
        End Try

        'Dim DT As New DataTable
        'Dim SQL As String = "SELECT TOP 10000 [idwpSN] AS Serial, [process] AS Stage, [PartNo] AS [Panel Ref], [User] AS [User ID], datetime AS 'Date' FROM [Telling].[dbo].[wpSnop] WHERE" & _
        '   " ([idwpSN] LIKE '%" & txtSerial.Text & "%') AND ([process] LIKE '%" & txtStage.Text & "%') AND (PartNo LIKE '%" & txtPanel.Text & "%') AND ([User] LIKE '%" & DDUser.Text & "%')"
        'Dim cmd As SqlCommand = New SqlCommand(SQL, cls.con)
        ' Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
        ' Try
        'da.Fill(DT)
        ' dgvSearch_JobsData.DataSource = DT
        '    dgvSearch_JobsData.
        ' Catch ex As Exception
        ' lblError.Text = "Failed to Search" & ex.Message
        ' End Try

    End Sub

    Protected Sub dgvSearch_JobsData_PreRender(sender As Object, e As EventArgs) Handles dgvSearch_JobsData.PreRender
        If dgvSearch_JobsData.Rows.Count > 0 Then
            dgvSearch_JobsData.UseAccessibleHeader = False
            dgvSearch_JobsData.HeaderRow.TableSection = TableRowSection.TableHeader
            dgvSearch_JobsData.FooterRow.TableSection = TableRowSection.TableFooter
            Dim CellCount As Integer = dgvSearch_JobsData.FooterRow.Cells.Count
            dgvSearch_JobsData.FooterRow.Cells.Clear()
            dgvSearch_JobsData.FooterRow.Cells.Add(New TableCell())
            dgvSearch_JobsData.FooterRow.Cells(0).ColumnSpan = CellCount - 1
            dgvSearch_JobsData.FooterRow.Cells(0).HorizontalAlign = HorizontalAlign.Right
            dgvSearch_JobsData.FooterRow.Cells.Add(New TableCell())
            Dim tfr As New TableFooterRow()
            For i As Integer = 0 To CellCount - 1
                'tfr.Cells[i].Width = dgvSearch_JobsData.HeaderRow.Cells[i].Width;
                'tfr.Cells[i].ColumnSpan = CellCount;
                'tfr.Cells[0].Text = "Footer 2";
                tfr.Cells.Add(New TableCell())
            Next
            dgvSearch_JobsData.FooterRow.Controls(1).Controls.Add(tfr)
        End If
    End Sub

    Protected Sub SqlDataSource_Selecting(sender As Object, e As SqlDataSourceSelectingEventArgs) Handles SDSSearch.Selecting

    End Sub
End Class