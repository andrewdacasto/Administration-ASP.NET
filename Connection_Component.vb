Imports System.Data.SqlClient

Public Class Connection_Component
    'Dim all type of string queries
    ''Search Queries
    Dim SearchJobs As String = "SELECT * FROM wpSN WHERE idwpSN = '"
    Dim SearchUsers As String
    Dim SearchParts As String
    Dim SearchProjects As String
    ''Create Queries
    Dim CreateJobs As String
    Dim CreateUsers As String
    Dim CreateParts As String
    Dim CreateProjects As String
    'dim function needs
    Dim result As String = ""
    'functions
    Public con As New SqlConnection
    Public cmd As New SqlCommand
    Public ELog As New EventLog
    Public objConn As New SqlConnection
    Public objCmd As New System.Data.SqlClient.SqlCommand
    Public strSQL As String
    Public Sub ConnectSQL()
        'con = New SqlConnection("Data Source=10.0.0.4,1433;Initial Catalog=Telling;User Id=M3Mobile;Password=m0b1le;Connect timeout=20")
        'con = New SqlConnection("Data Source=10.0.0.220,1433;Initial Catalog=Telling;User Id=Tesseract;Password=sc41;Connect timeout=20")
        con = New SqlConnection("Data Source=10.0.0.220,1433;Initial Catalog=Telling;User Id=Tesseract;Password=sc41;Connect timeout=20")

        Try
            con.Open()
        Catch ex As Exception

        End Try
    End Sub
    Public Function Connected()
        Return con.State
    End Function
    Public Sub DisconnectSQL()
        con.Close()
    End Sub
    Public Sub WriteInfo(ByVal ErrorReport As String)
        ELog.Source = "Telling"
        ELog.Log = "Administration"
        ELog.WriteEntry(ErrorReport, EventLogEntryType.Information)
    End Sub
    Public Sub WriteError(ByVal ErrorReport As String)
        ELog.Source = "Telling"
        ELog.Log = "Administration"
        ELog.WriteEntry(ErrorReport, EventLogEntryType.Error)
    End Sub
    Public Function Search_Jobs(ByVal jobNum As Integer)
        
        Return result
    End Function
    Public Function Search_Users(ByVal user As String)

        Return result
    End Function
    Public Function Search_Parts(ByVal partNum As String)

        Return result
    End Function
    Public Function Search_Projects(ByVal projectNum As Integer)

        Return result
    End Function
    Public Function Create_Users(ByVal user As String, ByVal accessLevel As String, ByVal department As String)

        Return result
    End Function
    Public Function Create_Parts(ByVal partNum As Integer, ByVal partDesc As String)

        Return result
    End Function
    Public Function Create_Projects(ByVal orderNum As Integer, ByVal scheduleNum As Integer, ByVal packingList As String, ByVal status As String)

        Return result
    End Function
End Class