Imports System.Data.SqlClient

Public Class frmSearchserial
    Inherits System.Web.UI.Page
    Dim cls As New Connection_Component
    Public con As SqlConnection = cls.con
    Public cmd As New SqlCommand
    Public ELog As New EventLog
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cls.ConnectSQL()
        dgvSearchJobsData.DataSourceID = ""
        dgvSearchJobsData.DataSourceID = "SqlDataSource"
    End Sub

    Protected Sub dgvSearchJobsData_PreRender(sender As Object, e As EventArgs) Handles dgvSearchJobsData.PreRender
        If dgvSearchJobsData.Rows.Count > 0 Then
            dgvSearchJobsData.UseAccessibleHeader = False
            dgvSearchJobsData.HeaderRow.TableSection = TableRowSection.TableHeader
            dgvSearchJobsData.FooterRow.TableSection = TableRowSection.TableFooter
            Dim CellCount As Integer = dgvSearchJobsData.FooterRow.Cells.Count
            dgvSearchJobsData.FooterRow.Cells.Clear()
            dgvSearchJobsData.FooterRow.Cells.Add(New TableCell())
            dgvSearchJobsData.FooterRow.Cells(0).ColumnSpan = CellCount - 1
            dgvSearchJobsData.FooterRow.Cells(0).HorizontalAlign = HorizontalAlign.Right
            dgvSearchJobsData.FooterRow.Cells.Add(New TableCell())
            Dim tfr As New TableFooterRow()
            For i As Integer = 0 To CellCount - 1
                'tfr.Cells[i].Width = dgvSearch_JobsData.HeaderRow.Cells[i].Width;
                'tfr.Cells[i].ColumnSpan = CellCount;
                'tfr.Cells[0].Text = "Footer 2";
                tfr.Cells.Add(New TableCell())
            Next
            dgvSearchJobsData.FooterRow.Controls(1).Controls.Add(tfr)
        End If
    End Sub
End Class