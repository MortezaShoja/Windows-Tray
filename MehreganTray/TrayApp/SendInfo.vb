Public Class SendInfo
    Private SqlCon As SQLserver
    Private CD As CurrentDate

    Public Sub SaveSentDay(ByVal Group As String) '------- Save Sent Group
        SqlCon = New SQLserver
        CD = New CurrentDate
        Dim cmds As New Data.SqlClient.SqlCommand("Insert Into SMSSentDay (Tarikh,Saat,Gorooh) Values (N'" & CD.GetDate.ToString & "',N'" & Now.Hour.ToString & ":" & Now.Minute.ToString & "',N'" & Group & "')", SqlCon.SqlCon)
        SqlCon.SqlCon.Open()
        cmds.ExecuteNonQuery()
        SqlCon.SqlCon.Close()
    End Sub


    Public Function CheckSentDay(ByVal Group As String) '------- Check If sent or not
        Dim Value As String = String.Empty
        SqlCon = New SQLserver
        CD = New CurrentDate
        Dim cmdc As New Data.SqlClient.SqlCommand("Select Saat From SMSSentDay Where Tarikh=N'" & CD.GetDate.ToString & "' AND Gorooh=N'" & Group & "'", SqlCon.SqlCon)
        SqlCon.SqlCon.Open()
        Dim sdrc As Data.SqlClient.SqlDataReader = cmdc.ExecuteReader
        If sdrc.Read Then
            Value = sdrc(0).ToString
        End If
        SqlCon.SqlCon.Close()
        sdrc.Close()
        Return Value
    End Function
End Class
