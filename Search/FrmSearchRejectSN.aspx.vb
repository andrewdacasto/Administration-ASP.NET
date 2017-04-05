Imports System.Data.SqlClient

Public Class FrmSearchRejectSN
    Inherits System.Web.UI.Page

    Dim cls As New Connection_Component
    Public con As SqlConnection = cls.con
    Public cmd As New SqlCommand
    Public ELog As New EventLog
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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
End Class