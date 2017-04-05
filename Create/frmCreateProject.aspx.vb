Imports System.Data.SqlClient
Imports System.Text.Encoding.ASCII
Imports Symbol.printing
Imports System.Net.Sockets
Imports System.Data
Public Class frmCreateProject
    Inherits System.Web.UI.Page
    Dim cls As New Connection_Component
    Public cmd As New SqlCommand
    Public ELog As New EventLog
    Dim projectNum As Integer
    Public Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cls.ConnectSQL()
    End Sub
    Private Function ProjectExsists(Name As String, num As String, search As String)
        If cls.Connected = "0" Then
            cls.ConnectSQL()
        End If
        lblError.Text = ""
        Dim SQLstr As String
        If Name = "" And num = "" Then
            lblError.Text = "Please enter project number or name to use the search function"
        ElseIf Name <> "" And num = "" Then
            'search name
            SQLstr = "SELECT * FROM [telling].[dbo].[wpProjectHeader] WHERE [Project_Name] = '" & Name & "'"
        ElseIf Name = "" And num <> "" Then
            'search num
            SQLstr = "SELECT * FROM [telling].[dbo].[wpProjectHeader] WHERE [Project_Num] = '" & num & "'"
        ElseIf Name <> "" And num <> "" Then
            'search both
            SQLstr = "SELECT * FROM [telling].[dbo].[wpProjectHeader] WHERE [Project_Name] = '" & Name & "' AND Project_Num = '" & num & "'"
        End If
        Dim cmd As SqlCommand = New SqlCommand(SQLstr, cls.con)
        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        da.Fill(dt)
        gvProject.Visible = False
        gvProject.Enabled = False
        If dt.Rows.Count <= 0 Then
            Return False
        ElseIf dt.Rows.Count = 1 Then
            If search = True Then
                txtName.Text = dt.Rows.Item(0).Item(0).ToString
                txtProjectNo.Text = dt.Rows.Item(0).Item(1).ToString
                txtOrderNo.Text = dt.Rows.Item(0).Item(2).ToString
                txtScheduleNumber.Text = dt.Rows.Item(0).Item(3).ToString
                txtPackList.Text = dt.Rows.Item(0).Item(4).ToString
                lblStatus.Text = dt.Rows.Item(0).Item(5).ToString
                txtProjectNo.Enabled = False
            End If

            Return True
        ElseIf dt.Rows.Count > 1 Then
            If search = True Then
                gvProject.DataSource = dt.DataSet
                lblError.Text = "There is more than one job found, please search again"
                txtProjectNo.Enabled = True
                'gvProject.Visible = True
                'gvProject.Enabled = True
                Clearall()
                Return Nothing
            End If
        End If

    End Function
    Public Function generateProjectNum()
        Dim sql As String = "SELECT TOP 1 Project_Num FROM [Telling].[dbo].[wpProjectHeader] ORDER BY Project_Num DESC"
        Dim cmd As SqlCommand = New SqlCommand(sql, cls.con)
        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        da.Fill(dt)
        projectNum = dt.Rows.Item(0).Item(0).ToString
        projectNum += 1
        Return projectNum
    End Function
    Public Sub Create_Projects(ByVal orderNum As String, ByVal scheduleNum As String, ByVal packingList As String, ByVal status As String, ByVal projectName As String)
        Dim pn As String = generateProjectNum()

        If projectNum = 0 Then
            lblError.Text = "Project cannot be created. Please contact software administration"
        ElseIf orderNum = "0" Then
            lblError.Text = "Please input correct project order number"
        ElseIf projectName = "" Then
            lblError.Text = "Please input project name"
        ElseIf scheduleNum = "" Then
            lblError.Text = "Please input correct schedule number"
        ElseIf status = "COMP" Then
            lblError.Text = "Status is already marked as complete"
        Else
            If status = "" Then
                status = "OPEN"
            End If
            Dim cmd As New SqlCommand
            Dim sql As String

            If ProjectExsists(projectName, projectNum, False) = True Then
                'update
                sql = "Update wpProjectHeader SET [Project_Name] = '" & projectName & "',[Project_Order_num] = '" & orderNum & "',[Project_Schedule_Num] = '" & scheduleNum & "',[Project_Packing_List] = '" & packingList & "' WHERE [Project_Num] = '" & pn & "'"

            ElseIf ProjectExsists(projectName, projectNum, False) = False Then
                'create
                sql = "INSERT INTO [Telling].[dbo].[wpProjectHeader] VALUES ('" & projectName & "','" & pn & "','" & orderNum & "','" & scheduleNum & "','" & packingList & "','" & status & "')"

            End If
            cmd = New SqlCommand(sql, cls.con)
            Try
                cmd.ExecuteNonQuery()
                If ProjectExsists(projectName, projectNum, False) = True Then
                    'update
                    lblError.Text = "Project Updated"
                ElseIf ProjectExsists(projectName, projectNum, False) = False Then
                    'create
                    lblError.Text = "Project Created"
                End If
                Clearall()
            Catch ex As Exception
                lblError.Text = "Failed to Update " & ex.Message.ToString
            End Try
        End If
    End Sub
    Public Sub Clearall()
        txtName.Text = ""
        txtOrderNo.Text = ""
        txtProjectNo.Text = ""
        txtScheduleNumber.Text = ""
        txtPackList.Text = ""
        txtProjectNo.Enabled = True
    End Sub
    Protected Sub Create_Project_btn_Click(sender As Object, e As EventArgs) Handles Create_Project_btn.Click
        Create_Projects(txtOrderNo.Text, txtScheduleNumber.Text, txtPackList.Text, lblStatus.Text, txtName.Text)
    End Sub
    Protected Sub cmdSearch_Click(sender As Object, e As EventArgs) Handles cmdSearch.Click
        ProjectExsists(txtName.Text, txtProjectNo.Text, True)
    End Sub
    Protected Sub Create_Project_btn0_Click(sender As Object, e As EventArgs) Handles Create_Project_btn0.Click
        Clearall()
    End Sub
End Class