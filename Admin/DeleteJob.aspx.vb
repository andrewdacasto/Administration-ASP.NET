Imports System.Data.SqlClient
Imports System.Text.Encoding.ASCII
Imports System.Net.Sockets
Imports System.Data
Public Class DeleteJob
    Inherits System.Web.UI.Page
    Dim cls As New Connection_Component
    Dim SqlDelete As String
    Dim selectedCell As String
    Dim serail As String
    'Andy Editted
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load, MyBase.Load, MyClass.Load
        cls.ConnectSQL()
        If DDProjectNo.Items.Count = 0 Then
            GetOpenProjectNo()
        End If
        dgvJobs.DataSourceID = ""
        dgvJobs.DataSourceID = "SqlDataSource"
        If cls.Connected = "0" Then
            cls.ConnectSQL()
        End If
        If IsPostBack = False Then
            DDUser1.Text = ""
        End If
        Try
            Dim SQL As String = "SELECT [User] FROM wpSnop GROUP BY [User] ORDER BY [User]"
            Dim DT As New DataTable
            Dim cmd As SqlCommand = New SqlCommand(SQL, cls.con)
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            da.Fill(DT)
            If DDUser1.Text = "" Then
                DDUser1.Items.Clear()
                DDUser1.Items.Add("")
                For Each line As Data.DataRow In DT.Rows
                    DDUser1.Items.Add(line.Item(0))
                Next
            End If
        Catch ex As Exception
            lblError.Text = "Failed to Search" & ex.Message
        End Try
        If Page.IsPostBack = False Then
            CalTo.SelectedDate = Date.Now
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
    Private Sub DeleteJob()
        Dim cmd As New SqlCommand(lblSqlDelete.Text, cls.con)
        Try
            cmd.ExecuteNonQuery()
            Dim Sqlstr As String = "DELETE FROM [Telling].[dbo].[wpSnop] WHERE idwpSN = '" & lblSelectCell.Text & "'"
            cmd = New SqlCommand(Sqlstr, cls.con)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            lblError.Text = ex.Message
        End Try
    End Sub
    Private Sub RejectJob()
        Dim DT As New DataTable
        Dim SQLstr As String = "SELECT * FROM wpSN where idwpSN = '" & lblSelectCell.Text & "'"
        Dim cmd As New SqlClient.SqlCommand(SQLstr, cls.con)
        Dim da As SqlClient.SqlDataAdapter = New SqlClient.SqlDataAdapter(cmd)
        da.Fill(DT)
        Dim item As DataRow = Jobdata(lblSelectCell.Text)

        Dim item0, item1, item2, item3, item4, item5, item6, item7, item8, item9, item10 As String
        item0 = item.ItemArray(0).ToString
        item1 = item.ItemArray(1).ToString
        item2 = item.ItemArray(2).ToString
        item3 = item.ItemArray(3).ToString
        item5 = item.ItemArray(5).ToString
        item6 = item.ItemArray(6).ToString
        item7 = item.ItemArray(7).ToString
        item8 = item.ItemArray(8).ToString
        item9 = item.ItemArray(9).ToString
        item10 = item.ItemArray(10).ToString

        Dim sqlstr1 As String = "INSERT INTO [Telling].[dbo].[wpRejectSN] VALUES ('" & item0 & "','" & item1 & "','" & item2 & "','" & item3 & "',Getdate(),'" & item5 & "','" & item6 & "','" & item7 & "','" & item8 & "','" & item9 & "','" & item10 & "','" & User.Identity.Name.ToString & "')"

        cmd = New SqlCommand(sqlstr1, cls.con)
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            lblError0.Text = ex.Message.ToString
            Exit Sub
        End Try
        Create_Jobs(item)
        DeleteJob()

    End Sub
    Private Sub ReworkJob()
        Dim item As DataRow = Jobdata(lblSelectCell.Text)
        Dim Laststage As String = item.ItemArray(2).ToString
        Dim LastStageNo As Integer = item.ItemArray(6).ToString - 1


        Laststage = "Stage: " & LastStageNo

        If LastStageNo = 0 Then
            Laststage = "Job Created"
            LastStageNo = 1
        End If

        Dim Sql As String = "Update wpSN SET Last_Process = '" & Laststage & "', Last_Process_Stage = '" & LastStageNo & "', Last_Update = GetDate() WHERE [idwpSN] = '" & lblSelectCell.Text & "'"
        Dim cmd As SqlCommand = New SqlCommand(Sql, cls.con)
        Try
            cmd.ExecuteNonQuery()
            Sql = "INSERT INTO [Telling].[dbo].[wpSNop] VALUES ('" & item.Item(0) & "','Rework" & Laststage & "','" & User.Identity.Name.ToString & "',GetDate(),'" & item.Item(1) & "')"
            cmd = New SqlCommand(Sql, cls.con)
            cmd.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub
    Public Function Jobdata(PN As String)
        Dim DT As New DataTable
        Dim SQLstr As String = "SELECT * FROM [Telling].[dbo].[wpSN] where idwpSN = '" & lblSelectCell.Text & "'"
        Dim cmd As New SqlClient.SqlCommand(SQLstr, cls.con)
        Dim da As SqlClient.SqlDataAdapter = New SqlClient.SqlDataAdapter(cmd)
        da.Fill(DT)
        Dim item As DataRow = DT.Rows.Item(0)
        Return item
    End Function

    Public Sub Create_Jobs(JobData As DataRow)
        Dim x As Integer = 0
        If cls.Connected = "0" Then
            cls.ConnectSQL()
        End If
        Dim PartNo As String = JobData.Item(1)
        Dim Sn As String = generateSerial()
        Dim projectNum As String = JobData.Item(7)
        Dim dateTime As Date = Date.Now

        Dim sql As String = "INSERT INTO [Telling].[dbo].[wpSN] VALUES ('" & Sn & "','" & PartNo & "','Job Created','" & User.Identity.Name.ToString & "',GetDate(),'1','1','" & projectNum & "','" & JobData.Item(8) & "','" & JobData.Item(9) & "','')"
        Dim cmd As New SqlCommand(sql, cls.con)
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try
        sql = "INSERT INTO [Telling].[dbo].[wpSNop] VALUES ('" & Sn & "','Job Created','" & User.Identity.Name.ToString & "',GetDate(),'" & PartNo & "')"
        cmd = New SqlCommand(sql, cls.con)
        Try
            cmd.ExecuteNonQuery()
            Print("Job Created", 1, PartNo, Sn, projectNum)
            x = x + 1
            Sn = generateSerial()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ClearConformation()
        chkDelete.Visible = False
        chkReject.Visible = False
        chkRework.Visible = False
        cmdConfirm.Visible = False
        cmdCancel.Visible = False
        chkDelete.Checked = False
        chkReject.Checked = False
        chkRework.Checked = False
        lblDelete.Text = ""
        lblError.Text = ""
    End Sub
    Private Sub ShowConformation()
        chkDelete.Visible = True
        chkReject.Visible = True
        chkRework.Visible = True
        cmdConfirm.Visible = True
        cmdCancel.Visible = True
    End Sub
    Protected Sub dgvJobs_PreRender(sender As Object, e As EventArgs) Handles dgvJobs.PreRender
        If dgvJobs.Rows.Count > 0 Then
            dgvJobs.UseAccessibleHeader = False
            dgvJobs.HeaderRow.TableSection = TableRowSection.TableHeader
            dgvJobs.FooterRow.TableSection = TableRowSection.TableFooter
            Dim CellCount As Integer = dgvJobs.FooterRow.Cells.Count
            dgvJobs.FooterRow.Cells.Clear()
            dgvJobs.FooterRow.Cells.Add(New TableCell())
            dgvJobs.FooterRow.Cells(0).ColumnSpan = CellCount - 1
            dgvJobs.FooterRow.Cells(0).HorizontalAlign = HorizontalAlign.Right
            dgvJobs.FooterRow.Cells.Add(New TableCell())
            Dim tfr As New TableFooterRow()
            For i As Integer = 0 To CellCount - 1
                'tfr.Cells[i].Width = dgvJobs.HeaderRow.Cells[i].Width;
                'tfr.Cells[i].ColumnSpan = CellCount;
                'tfr.Cells[0].Text = "Footer 2";
                tfr.Cells.Add(New TableCell())
            Next
            dgvJobs.FooterRow.Controls(1).Controls.Add(tfr)
        End If
    End Sub
    Protected Sub cmdConfirm_Click(sender As Object, e As EventArgs) Handles cmdConfirm.Click
        If chkDelete.Checked = True And chkReject.Checked = False And chkRework.Checked = False Then
            DeleteJob()
            ClearConformation()
        ElseIf chkReject.Checked = True And chkDelete.Checked = False And chkRework.Checked = False Then
            RejectJob()
            ClearConformation()
        ElseIf chkRework.Checked = True And chkReject.Checked = False And chkDelete.Checked = False Then
            ReworkJob()
            ClearConformation()
        ElseIf chkRework.Checked = False And chkReject.Checked = False And chkDelete.Checked = False Then
            'select 1
            lblError.Text = "Please Select 1 option"
        Else
            'multiply selected
            lblError.Text = "Only 1 option can be selected"
        End If
    End Sub
    Protected Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        ClearConformation()
    End Sub
    Public Function generateSerial()
        Dim x As Integer = 0
        If cls.Connected = "0" Then
            cls.ConnectSQL()
        End If
        Dim sql As String = "SELECT TOP 1 idwpSN FROM [Telling].[dbo].[wpSN] ORDER BY idwpSN DESC"
        Dim cmd As New SqlCommand(sql, cls.con)
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        da.Fill(dt)
        serail = dt.Rows.Item(0).Item(0).ToString
        serail += 1
        Return serail
    End Function

    Protected Sub dgvJobs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dgvJobs.SelectedIndexChanged
        selectedCell = dgvJobs.SelectedRow.ToString
        Dim Y As String = dgvJobs.SelectedIndex.ToString
        lblSelectCell.Text = dgvJobs.Rows.Item(Y).Cells(1).Text
        lblSqlDelete.Text = "DELETE FROM wpSN where idwpSN = '" & dgvJobs.SelectedRow.Cells(1).Text & "'"
        chkDelete.Visible = True
        chkReject.Visible = True
        chkRework.Visible = True
        cmdConfirm.Visible = True
        cmdCancel.Visible = True
        chkDelete.Checked = False
        chkReject.Checked = False
        chkRework.Checked = False
        lblDelete.Text = "Please select 1 option below for SN: " & lblSelectCell.Text

    End Sub
    Private Sub Print(ByVal st, ByVal stno, ByVal Pn, ByVal SN, ProjectNum)
        Dim stag As String = st
        Dim stagNo As String = stno
        Dim BC As String = Pn & "," & SN
        Dim part As String = Pn
        Dim ser As String = SN
        Dim DT As New DataTable
        Dim sql As String = "SELECT * FROM [Telling].[dbo].[wpProjectHeader] where [Project_Num] = '" & ProjectNum & "'"
        Dim cmd As New SqlClient.SqlCommand(sql, cls.con)
        Dim da As SqlClient.SqlDataAdapter = New SqlClient.SqlDataAdapter(cmd)
        da.Fill(DT)
        Dim ProjectName As String = DT.Rows.Item(0).Item(0).ToString
        Try
            Dim TcpClient As New TcpClient
            Dim A As MsgBoxResult
            Do
                Try
                    Dim Printer As String = GetIP("PIL")
                    TcpClient.Connect(Printer, 9100)
                Catch ex As Exception
                    lblError.Text = "ERROR - UNABLE TO CONNECT TO PRINTER"
                End Try

            Loop Until TcpClient.Client.Connected = True ' Or A = MsgBoxResult.Cancel

            Dim networkStream As NetworkStream = TcpClient.GetStream()

            If TcpClient.Client.Connected Then
                Dim sendBytes As [Byte]() = System.Text.Encoding.ASCII.GetBytes("^XA" & vbCrLf & _
             "^TA080" & vbCrLf & _
             "^MMT" & vbCrLf & _
             "^PW400" & vbCrLf & _
             "^LL2200" & vbCrLf & _
             "^SD28" & vbCrLf & _
             "^LS0" & vbCrLf & _
             "^FT150,1850^BXN,8,200,0,0,1" & vbCrLf & _
             "^FD" & BC & "^FS" & vbCrLf & _
             "^FT325,1000^A0R,50,50^FH\^FDTelling Architectural^FS" & vbCrLf & _
             "^FT200,600^A0R,50,50^FH\^FDPart Number:^FS" & vbCrLf & _
             "^FT125,600^A0R,50,50^FH\^FDSerial:^FS" & vbCrLf & _
             "^FT200,940^A0R,50,50^FH\^FD" & part & "^FS" & vbCrLf & _
             "^FT125,780^A0R,50,50^FH\^FD" & ser & "^FS" & vbCrLf & _
             "^FT50,600^A0R,50,50^FH\^FDProject Name:^FS" & vbCrLf & _
             "^FT50,980^A0R,50,50^FH\^FD" & ProjectName & "^FS" & vbCrLf & _
             "^PQ1,0,1,Y" & vbCrLf & _
             "^XZ")
                '"^FT50,1200^A0R,50,50^FH\^FD Date: " & CastDate & "^FS" & vbCrLf & _

                networkStream.Write(sendBytes, 0, sendBytes.Length)
                networkStream.Close()
                TcpClient.Close()
            Else
                If Not networkStream.CanRead Then
                    lblError.Text = "Error Printing (Read) Part1"
                    TcpClient.Close()
                Else
                    If Not networkStream.CanWrite Then
                        lblError.Text = "Error Printing (Read) Part1"
                        TcpClient.Close()
                    End If
                End If
            End If
        Catch ex As Exception
            lblError.Text = "Unable to Print"
        End Try
    End Sub
    Private Function GetIP(ByVal Printer)
        Dim dt As New DataTable
        Dim sql = "SELECT * FROM [Telling].[dbo].[wpSetting]"
        Dim cmd As New SqlClient.SqlCommand(sql, cls.con)
        Dim da As New SqlClient.SqlDataAdapter(cmd)
        da.Fill(dt)
        If Printer = "PIL" Then
            Return dt.Rows.Item(0).Item(0).ToString
        Else
            Return dt.Rows.Item(0).Item(1).ToString
        End If
    End Function

    Protected Sub txtSearch_Click(sender As Object, e As EventArgs) Handles txtSearch.Click
        ClearConformation()
    End Sub
End Class