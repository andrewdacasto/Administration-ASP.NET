Public Class DeleteProject
    Inherits System.Web.UI.Page
    Dim cls As New Connection_Component
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cls.ConnectSQL()
        If DDProjectNo.Items.Count = 0 Then
            GetOpenProjectNo()
        End If
    End Sub
    Public Sub GetOpenProjectNo()
        If cls.Connected = "0" Then
            cls.ConnectSQL()
        End If
        Dim DT As New DataTable
        Dim SQLstr As String = "SELECT [Project_Name] ,[Project_Num],[Project_Order_num],[Project_Schedule_Num] ,[Project_Packing_List],[Status] FROM [Telling].[dbo].[wpProjectHeader] where Status = 'OPEN' and [Project_Name] LIKE '%' order by [Project_Num] asc"
        Dim cmd As New SqlClient.SqlCommand(SQLstr, cls.con)
        Dim da As SqlClient.SqlDataAdapter = New SqlClient.SqlDataAdapter(cmd)
        da.Fill(DT)
        DDProjectNo.Items.Clear()
        DDProjectNo.Items.Add("")
        If DT.Rows.Count > 0 Then
            For Each line As DataRow In DT.Rows
                DDProjectNo.Items.Add(line.Item(0).ToString)
            Next
        End If
    End Sub

    Protected Sub dgvProject_PreRender(sender As Object, e As EventArgs) Handles dgvProject.PreRender
        If dgvProject.Rows.Count > 0 Then
            dgvProject.UseAccessibleHeader = False
            dgvProject.HeaderRow.TableSection = TableRowSection.TableHeader
            dgvProject.FooterRow.TableSection = TableRowSection.TableFooter
            Dim CellCount As Integer = dgvProject.FooterRow.Cells.Count
            dgvProject.FooterRow.Cells.Clear()
            dgvProject.FooterRow.Cells.Add(New TableCell())
            dgvProject.FooterRow.Cells(0).ColumnSpan = CellCount - 1
            dgvProject.FooterRow.Cells(0).HorizontalAlign = HorizontalAlign.Right
            dgvProject.FooterRow.Cells.Add(New TableCell())
            Dim tfr As New TableFooterRow()
            For i As Integer = 0 To CellCount - 1
                'tfr.Cells[i].Width = dgvProject.HeaderRow.Cells[i].Width;
                'tfr.Cells[i].ColumnSpan = CellCount;
                'tfr.Cells[0].Text = "Footer 2";
                tfr.Cells.Add(New TableCell())
            Next
            dgvProject.FooterRow.Controls(1).Controls.Add(tfr)
        End If
    End Sub
End Class