Public Class UpdateClass
    Private SqlCon2 As New SQLserver
    Private Cmd2 As New Data.SqlClient.SqlCommand

    Public Sub UpdateDatabase(ByVal ID As String, ByVal Message As String, ByVal SendOK As Integer)
        If Not ID Is Nothing Then
            Cmd2.Connection = SqlCon2.SqlCon
            SqlCon2.SqlCon.Open()
            Cmd2.CommandText = "Update SMSSendMessages set Sent=N'" & Message & "' , SendOK='" & SendOK & "' where ID='" & ID & "'"
            Cmd2.ExecuteNonQuery()
            SqlCon2.SqlCon.Close()
        End If
    End Sub
End Class
