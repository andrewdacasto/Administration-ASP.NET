Imports System.Data.SqlClient
Public Class frmCreatePart
    Inherits System.Web.UI.Page
    Dim cls As New Connection_Component
    Public cmd As New SqlCommand
    Public ELog As New EventLog
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cls.ConnectSQL()
        cmdRemove.Enabled = False
        cmdRemove.Visible = False
        If IsPostBack = True Then
            If txtPartNum.Text <> "" Then
                If CheckPart(txtPartNum.Text) = True Then
                    lblError0.Text = "Part Number Found"
                    cmdRemove.Enabled = True
                    cmdRemove.Visible = True
                Else
                    cmdRemove.Enabled = False
                    cmdRemove.Visible = False
                End If
            End If
        End If
    End Sub
    Public Sub Create_Part(ByVal partNum As String, ByVal description As String)
        Dim connn As String = cls.Connected
        If cls.Connected = "0" Then
            cls.ConnectSQL()
        End If
        If partNum = "" Then
            lblError.Text = "Please fill in part number"
            'ElseIf description = "" Then
            '    lblError.Text = "Please fill part description"
        ElseIf CheckPart(partNum) = True Then
            lblError.Text = "Part number already in database"
            ClearAll()
        Else
            Dim sql As String = "INSERT INTO [Telling].[dbo].[wpParts] ([Part_Number],[Part_Description],[Part_Phase] ,[Part_Elevation]) VALUES ('" & partNum & "','" & description & "','" & txtPhase.Text & "','" & txtElevation.Text & "')"
            Dim cmd As New SqlCommand(sql, cls.con)
            ' Dim cmd As New SqlCommand(sql, con.objConn)
            Try
                cmd.ExecuteNonQuery()
                lblError.Text = "Part Created Successfully"
                ClearAll()
            Catch ex As Exception
                lblError.Text = "INSERT INTO wpPart FAILED"
            End Try
        End If
    End Sub
    Public Function CheckPart(partNum As String)
        Dim sql As String = "Select [Part_Number],[Part_Description],[Part_Phase] ,[Part_Elevation] From [Telling].[dbo].[wpParts] where Part_Number = '" & partNum & "'"
        Dim cmd As SqlCommand = New SqlCommand(sql, cls.con)
        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim DT As New DataTable
        da.Fill(DT)
        If DT.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Sub ClearAll()
        ' txtElevation.Text = ""
        txtPartNum.Text = ""
        ' txtPhase.Text = ""
    End Sub
    Protected Sub Create_Part_btn_Click(sender As Object, e As EventArgs) Handles Create_Part_btn.Click
        Create_Part(txtPartNum.Text, txtPartDesc.Text)
    End Sub
    Protected Sub cmdRemove_Click(sender As Object, e As EventArgs) Handles cmdRemove.Click
        Dim SqlStr As String = "DELETE FROM [Telling].[dbo].[wpParts] WHERE [Part_Number] = '" & txtPartNum.Text & "'"
        Dim cmd As SqlCommand = New SqlCommand(SqlStr, cls.con)
        Try
            cmd.ExecuteNonQuery()
            ClearAll()
        Catch ex As Exception
            lblError.Text = "Failed to delete"
        End Try
    End Sub

End Class