Public Class frmSearchUsers
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load, MyBase.Load, MyClass.Load
        dgvSearch_UserData.DataSourceID = ""
        dgvSearch_UserData.DataSourceID = "DSUsersMobile"
    End Sub

    Protected Sub Search_UserData_PreRender(sender As Object, e As EventArgs) Handles dgvSearch_UserData.PreRender
        If dgvSearch_UserData.Rows.Count > 0 Then
            dgvSearch_UserData.UseAccessibleHeader = False
            dgvSearch_UserData.HeaderRow.TableSection = TableRowSection.TableHeader
            dgvSearch_UserData.FooterRow.TableSection = TableRowSection.TableFooter
            Dim CellCount As Integer = dgvSearch_UserData.FooterRow.Cells.Count
            dgvSearch_UserData.FooterRow.Cells.Clear()
            dgvSearch_UserData.FooterRow.Cells.Add(New TableCell())
            dgvSearch_UserData.FooterRow.Cells(0).ColumnSpan = CellCount - 1
            dgvSearch_UserData.FooterRow.Cells(0).HorizontalAlign = HorizontalAlign.Right
            dgvSearch_UserData.FooterRow.Cells.Add(New TableCell())
            Dim tfr As New TableFooterRow()
            For i As Integer = 0 To CellCount - 1
                'tfr.Cells[i].Width = Search_UserData.HeaderRow.Cells[i].Width;
                'tfr.Cells[i].ColumnSpan = CellCount;
                'tfr.Cells[0].Text = "Footer 2";
                tfr.Cells.Add(New TableCell())
            Next
            dgvSearch_UserData.FooterRow.Controls(1).Controls.Add(tfr)
        End If
    End Sub
End Class