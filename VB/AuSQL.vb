Imports MySql.Data.MySqlClient

Public Class AuSQL
    'Home grown class for quick and easy SQL stuff

    Public cnStr As String
    Public cn As MySqlConnection
    Public dt As New DataTable

    Public Sub New()
        'me.cnStr = "server=localhost;user id=USERNAME;password=PASSWORD;persistsecurityinfo=True;database=DATABASE;Convert Zero Datetime=True"
        MsgBox("Please pass connection data")
    End Sub

    Public Sub New(sv As String, usr As String, pwd As String, db As String)
        Me.cnStr = "server=" & sv & ";user id=" & usr & ";password=" & pwd & ";persistsecurityinfo=True;database=" & db & ";Convert Zero Datetime=True"
        Me.cn = New MySqlConnection(Me.cnStr)
    End Sub

    Public Function query(sqlCmd As String) As Integer
        Dim da As New MySqlDataAdapter
        Dim cmd As MySqlCommand

        Me.dt.Dispose()
        Me.dt = New DataTable

        Try
            Me.cn.Open()
            cmd = New MySqlCommand(sqlCmd, Me.cn)
            da.SelectCommand = cmd
            dt.Clear()
            da.Fill(dt)
            da.Dispose()
            cmd.Dispose()
            Me.cn.Close()
        Catch ex As Exception
            MsgBox(ex.Source & ": " & ex.Message)
        End Try

        Return dt.Rows.Count
    End Function

    Public Function getRowCount() As Integer
        Return Me.dt.Rows.Count
    End Function
End Class
