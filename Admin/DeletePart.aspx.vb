Public Class DeletePart
    Inherits System.Web.UI.Page
    Dim cls As New Connection_Component
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub dgvPart_PreRender(sender As Object, e As EventArgs) Handles dgvPart.PreRender
        If dgvPart.Rows.Count > 0 Then
            dgvPart.UseAccessibleHeader = False
            dgvPart.HeaderRow.TableSection = TableRowSection.TableHeader
            dgvPart.FooterRow.TableSection = TableRowSection.TableFooter
            Dim CellCount As Integer = dgvPart.FooterRow.Cells.Count
            dgvPart.FooterRow.Cells.Clear()
            dgvPart.FooterRow.Cells.Add(New TableCell())
            dgvPart.FooterRow.Cells(0).ColumnSpan = CellCount - 1
            dgvPart.FooterRow.Cells(0).HorizontalAlign = HorizontalAlign.Right
            dgvPart.FooterRow.Cells.Add(New TableCell())
            Dim tfr As New TableFooterRow()
            For i As Integer = 0 To CellCount - 1
                'tfr.Cells[i].Width = dgvPart.HeaderRow.Cells[i].Width;
                'tfr.Cells[i].ColumnSpan = CellCount;
                'tfr.Cells[0].Text = "Footer 2";
                tfr.Cells.Add(New TableCell())
            Next
            dgvPart.FooterRow.Controls(1).Controls.Add(tfr)
        End If
    End Sub
End Class