Imports System.Text.Encoding.ASCII
Imports System.Net.Sockets
Imports System.Data.SqlClient
Imports System.Data
Public Class frmCreateJob
    Inherits System.Web.UI.Page
    Dim cls As New Connection_Component
    Public con As SqlConnection = cls.con
    Public cmd As New SqlCommand
    Public ELog As New EventLog
    Dim Serial As Integer
    Dim username As String = User.Identity.Name.ToString
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cls.ConnectSQL()

        If Page.IsPostBack And txtPartNum.SelectedValue <> "" And txtPhase.Text <> "" And txtQuantity.Text <> "" Then
            Create_Jobs()
        ElseIf Page.IsPostBack Then
            GetPhaseandLevel(txtPartNum.SelectedValue)
            generateSerial()
            If DDProjectNo.Text <> "" Then
                PopulateProjectData()
            Else
                ClearProjectData()
            End If
            If txtProjectName.Text <> "" And DDProjectNo.Text = "" Then
                GetOpenProjectNo()
            End If
            If txtPartNo.Text <> "" And txtPartNum.Text = "" Then
                getParts()
            End If
        Else
            GetOpenProjectNo()
            getParts()
        End If
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
        Serial = dt.Rows.Item(0).Item(0).ToString
        Serial += 1
        txtSn.Text = Serial
        Return Serial
    End Function
    Public Function getParts()
        If cls.Connected = "0" Then
            cls.ConnectSQL()
        End If
        Dim sql As String = "SELECT Part_Number FROM [Telling].[dbo].[wpParts] where Part_Number like '%" & txtPartNo.Text & "%'"
        Dim cmd As New SqlCommand(sql, cls.con)
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        Dim parts As New List(Of String)
        da.Fill(dt)
        txtPartNum.Items.Clear()
        txtPartNum.Items.Add("")
        If dt.Rows.Count > 0 Then
            For Each line As DataRow In dt.Rows
                If line.Item(0).ToString.Contains(txtPartNo.Text) = True Then
                    txtPartNum.Items.Add(line.Item(0).ToString)
                End If
            Next
        End If
        txtPartNum.DataSource = parts
    End Function
    Public Sub Create_Jobs()
        Dim x As Integer = 0
        If cls.Connected = "0" Then
            cls.ConnectSQL()
        End If
        Dim y As Integer = CInt(txtQuantity.Text)
        Dim PartNo As String = txtPartNum.SelectedValue
        Dim Sn As String = generateSerial()
        Dim projectNum As String = GetProjectNo(DDProjectNo.SelectedValue)
        Dim dateTime As Date = Date.Now

        Do Until x = y
            If PartNo = "" Then
                lblError.Text = "Please fill in part number"
                Exit Sub
            ElseIf projectNum = "" Then
                lblError.Text = "Please Select Project Number"
                Exit Sub
            Else
                Dim sql As String = "INSERT INTO [Telling].[dbo].[wpSN] VALUES ('" & Sn & "','" & PartNo & "','Job Created','" & username & "',GetDate(),'1','1','" & projectNum & "','" & txtPhase.Text & "','" & txtLevel.Text & "','')"
                Dim cmd As New SqlCommand(sql, cls.con)
                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    lblError.Text = ex.Message
                End Try
                sql = "INSERT INTO [Telling].[dbo].[wpSNop] VALUES ('" & Sn & "','Job Created','" & username & "',GetDate(),'" & PartNo & "')"
                cmd = New SqlCommand(sql, cls.con)
                Try
                    cmd.ExecuteNonQuery()
                    Print("Job Created", 1, txtPartNum.Text, Sn)
                    x = x + 1
                    Sn = generateSerial()
                Catch ex As Exception
                    lblError.Text = ex.Message
                End Try
            End If
        Loop
        PrintPallet(txtPalletQty.Text, projectNum)
        ClearAll()
        lblError.Text = "Job Created Successfully"
    End Sub
    Public Sub GetOpenProjectNo()
        If cls.Connected = "0" Then
            cls.ConnectSQL()
        End If
        Dim DT As New DataTable
        Dim SQLstr As String = "SELECT [Project_Name] ,[Project_Num],[Project_Order_num],[Project_Schedule_Num] ,[Project_Packing_List],[Status] FROM [Telling].[dbo].[wpProjectHeader] where Status = 'OPEN' and [Project_Name] LIKE '%" & txtProjectName.Text & "%' order by [Project_Num] asc"
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
    Public Sub PopulateProjectData()
        Dim Index As Integer = DDProjectNo.SelectedIndex - 1
        Dim DT As New DataTable
        Dim SQLstr As String = "SELECT [Project_Name] ,[Project_Num],[Project_Order_num],[Project_Schedule_Num] ,[Project_Packing_List],[Status] FROM [Telling].[dbo].[wpProjectHeader] where Status = 'OPEN' and [Project_Name] LIKE '%" & txtProjectName.Text & "%' order by [Project_Num] asc"
        Dim cmd As New SqlClient.SqlCommand(SQLstr, cls.con)
        Dim da As SqlClient.SqlDataAdapter = New SqlClient.SqlDataAdapter(cmd)
        da.Fill(DT)
        lblProjectNo.Text = DT.Rows.Item(Index).Item(1).ToString
        lblOrderNo.Text = DT.Rows.Item(Index).Item(2).ToString
        lblScheduleNo.Text = DT.Rows.Item(Index).Item(3).ToString
        lblPackingList.Text = DT.Rows.Item(Index).Item(4).ToString
    End Sub
    Public Sub ClearProjectData()
        lblProjectNo.Text = ""
        lblOrderNo.Text = ""
        lblScheduleNo.Text = ""
        lblPackingList.Text = ""
    End Sub
    Public Sub ClearAll()
        'clear all text boxes needed
        txtLevel.Text = ""
        txtPhase.Text = ""
        txtQuantity.Text = ""
        getParts()
        GetOpenProjectNo()
        generateSerial()
        txtPalletQty.Text = ""
        txtPartNo.Text = ""
        txtPalletQty.Text = "0"
        ClearProjectData()
    End Sub
    Private Sub Print(ByVal st, ByVal stno, ByVal Pn, ByVal SN)
        Dim stag As String = st
        Dim stagNo As String = stno
        Dim BC As String = Pn & "," & SN
        Dim part As String = Pn
        Dim ser As String = SN
        Dim DT As New DataTable
        'Dim sql As String = "SELECT * FROM [Telling].[dbo].[wpSNop] where [PartNo] = '" & Pn & "'"
        'Dim cmd As New SqlClient.SqlCommand(sql, cls.con)
        'Dim da As SqlClient.SqlDataAdapter = New SqlClient.SqlDataAdapter(cmd)
        'da.Fill(DT)
        'Dim CastDate As String = DT.Rows.Item(0).Item(3).ToString
        'Print Label
        ' If cls.con.State = ConnectionState.Closed Then
        'cls.con.Open()
        'End If
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
             "^FT50,980^A0R,50,50^FH\^FD" & DDProjectNo.SelectedValue & "^FS" & vbCrLf & _
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
    Public Function GetProjectNo(Name As String)
        If cls.Connected = "0" Then
            cls.ConnectSQL()
        End If
        Dim DT As New DataTable
        Dim SQLstr As String = "SELECT [Project_Num] FROM [Telling].[dbo].[wpProjectHeader] where [Project_Name] = '" & DDProjectNo.SelectedValue & "'"
        Dim cmd As New SqlClient.SqlCommand(SQLstr, cls.con)
        Dim da As SqlClient.SqlDataAdapter = New SqlClient.SqlDataAdapter(cmd)
        da.Fill(DT)
        If DT.Rows.Count > 0 Then
            GetProjectNo = DT.Rows(0).Item(0).ToString
        Else
            GetProjectNo = ""
        End If
        Return GetProjectNo
    End Function
    Public Function getProjectName()
        If cls.Connected = "0" Then
            cls.ConnectSQL()
        End If
        Dim DT As New DataTable
        Dim SQLstr As String = "SELECT [Project_Name] FROM [Telling].[dbo].[wpProjectHeader] where [Project_Name] = '" & DDProjectNo.SelectedValue & "'"
        Dim cmd As New SqlClient.SqlCommand(SQLstr, cls.con)
        Dim da As SqlClient.SqlDataAdapter = New SqlClient.SqlDataAdapter(cmd)
        da.Fill(DT)
        If DT.Rows.Count > 0 Then
            Return DT.Rows(0).Item(0).ToString
        Else
            Return ""
        End If

    End Function
    Public Sub PrintPallet(Qty, projectNo)
        'Print Label
        Dim pallet As String = ""
        Dim projectName As String = getProjectName()
        If cls.Connected = "0" Then
            cls.ConnectSQL()
        End If

        Do Until Qty = 0
            Try
                Dim TcpClient As New TcpClient
                Dim A As MsgBoxResult
                Do
                    Try
                        Dim Printer As String = GetIP("STILL")
                        TcpClient.Connect(Printer, 9100)
                        'TcpClient.Connect(GetIP(), 9100)
                    Catch ex As Exception
                        A = lblError.Text = "ERROR - UNABLE TO CONNECT TO PRINTER"
                    End Try
                Loop Until TcpClient.Client.Connected = True 'Or A = MsgBoxResult.Cancel

                Dim networkStream As NetworkStream = TcpClient.GetStream()
                pallet = GetPallet() + 1
                If TcpClient.Client.Connected Then
                    Dim OrderNo As String = ""
                    Dim schedule As String = ""
                    Dim packList As String = ""
                    Dim sendBytes As [Byte]() = System.Text.Encoding.ASCII.GetBytes("CT~~CD,~CC^~CT~" & _
                    "^XA~TA000~JSN^LT0^MNM^MTT^PON^PMN^LH0,0^JMA^PR2,2~SD20" & _
                    "^JUS^LRN^CI0^XZ" & _
                    "^XA" & _
                    "^MMT" & _
                    "^PW1218" & _
                    "^LL0812" & _
                    "^LS0" & _
                    "^BY276,276^FT470,438^BXN,23,200,0,0,1,_" & _
                    "^FH\^FDI" & pallet & "^FS" & _
                    "^FT237,703^A0N,209,204^FH\^FDI" & pallet & "^FS" & _
                    "^FT491,86^A0N,58,67^FH\^FDPallet ID^FS" & _
                    "^PQ1,0,1,Y^XZ")

                    Dim Sql As String = "Update [Telling].[dbo].[wpSetting] SET [Last_Pallet_Num] = '" & pallet & "'"
                    cmd = New SqlCommand(Sql, cls.con)
                    cmd.ExecuteNonQuery()

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
            Qty -= 1
        Loop
    End Sub
    Private Function GetPallet()
        Dim dt As New DataTable
        Dim sql = "SELECT * FROM [Telling].[dbo].[wpSetting]"
        Dim cmd As New SqlClient.SqlCommand(sql, cls.con)
        Dim da As New SqlClient.SqlDataAdapter(cmd)
        da.Fill(dt)
        Return dt.Rows.Item(0).Item(2).ToString
    End Function
    Public Sub GetPhaseandLevel(Part As String)
        Try
            txtPhase.Text = Part.Substring(0, Part.IndexOf("-"))
            'txtLevel.Text = Part.Substring(Part.IndexOf("-") + 1, Part.IndexOf("-", Part.IndexOf("-") - Part.IndexOf("-")))
            Dim x As String = Part.IndexOf("-") - Part.IndexOf("-", Part.IndexOf("-") + 1)
            Dim y As String = Part.Substring(Part.IndexOf("-") + 1)
            y = y.Substring(0, y.IndexOf("-"))
            txtLevel.Text = y
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub DDProjectNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDProjectNo.SelectedIndexChanged

    End Sub
End Class