Public Class frmSearchProjects
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load, MyBase.Load, MyClass.Load
        dgvSearch_ProjectData.DataSourceID = ""
        dgvSearch_ProjectData.DataSourceID = "DSProject"
    End Sub

    Protected Sub dgvSearch_ProjectData_PreRender(sender As Object, e As EventArgs) Handles dgvSearch_ProjectData.PreRender
        If dgvSearch_ProjectData.Rows.Count > 0 Then
            dgvSearch_ProjectData.UseAccessibleHeader = False
            dgvSearch_ProjectData.HeaderRow.TableSection = TableRowSection.TableHeader
            dgvSearch_ProjectData.FooterRow.TableSection = TableRowSection.TableFooter
            Dim CellCount As Integer = dgvSearch_ProjectData.FooterRow.Cells.Count
            dgvSearch_ProjectData.FooterRow.Cells.Clear()
            dgvSearch_ProjectData.FooterRow.Cells.Add(New TableCell())
            dgvSearch_ProjectData.FooterRow.Cells(0).ColumnSpan = CellCount - 1
            dgvSearch_ProjectData.FooterRow.Cells(0).HorizontalAlign = HorizontalAlign.Right
            dgvSearch_ProjectData.FooterRow.Cells.Add(New TableCell())
            Dim tfr As New TableFooterRow()
            For i As Integer = 0 To CellCount - 1
                'tfr.Cells[i].Width = dgvSearch_JobsData.HeaderRow.Cells[i].Width;
                'tfr.Cells[i].ColumnSpan = CellCount;
                'tfr.Cells[0].Text = "Footer 2";
                tfr.Cells.Add(New TableCell())
            Next
            dgvSearch_ProjectData.FooterRow.Controls(1).Controls.Add(tfr)
        End If
    End Sub
End Class