Imports System.Data.SqlClient
Public Class frmSearchParts
    Inherits System.Web.UI.Page
    Dim cls As New Connection_Component
    Public con As SqlConnection = cls.con
    Public cmd As New SqlCommand
    Public ELog As New EventLog
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load, MyBase.Load, MyClass.Load
        cls.ConnectSQL()
        dgvSearch_PartData.DataSourceID = ""
        dgvSearch_PartData.DataSourceID = "SqlDS"
    End Sub



    Protected Sub Search_PartData_PreRender(sender As Object, e As EventArgs) Handles dgvSearch_PartData.PreRender
        If dgvSearch_PartData.Rows.Count > 0 Then
            dgvSearch_PartData.UseAccessibleHeader = False
            dgvSearch_PartData.HeaderRow.TableSection = TableRowSection.TableHeader
            dgvSearch_PartData.FooterRow.TableSection = TableRowSection.TableFooter
            Dim CellCount As Integer = dgvSearch_PartData.FooterRow.Cells.Count
            dgvSearch_PartData.FooterRow.Cells.Clear()
            dgvSearch_PartData.FooterRow.Cells.Add(New TableCell())
            dgvSearch_PartData.FooterRow.Cells(0).ColumnSpan = CellCount - 1
            dgvSearch_PartData.FooterRow.Cells(0).HorizontalAlign = HorizontalAlign.Right
            dgvSearch_PartData.FooterRow.Cells.Add(New TableCell())
            Dim tfr As New TableFooterRow()
            For i As Integer = 0 To CellCount - 1
                'tfr.Cells[i].Width = dgvSearch_JobsData.HeaderRow.Cells[i].Width;
                'tfr.Cells[i].ColumnSpan = CellCount;
                'tfr.Cells[0].Text = "Footer 2";
                tfr.Cells.Add(New TableCell())
            Next
            dgvSearch_PartData.FooterRow.Controls(1).Controls.Add(tfr)
        End If
    End Sub

    Protected Sub sqlDS_Updating(sender As Object, e As SqlDataSourceCommandEventArgs) Handles sqlDS.Updating

    End Sub

    Protected Sub dgvSearch_PartData_Init(sender As Object, e As EventArgs) Handles dgvSearch_PartData.Init

    End Sub
End Class