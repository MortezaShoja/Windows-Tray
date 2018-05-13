Public Class FillData
    Private SqlCon As New SQLserver
    Private Cmd As New Data.SqlClient.SqlCommand
    Private Sdr As Data.SqlClient.SqlDataReader
    Private CD As CurrentDate
    Private Tarikh As String
    Private Numbers() As String
    Public Sub SaveData(ByVal ID As String, ByVal Sender As String, ByVal MessageText As String, ByVal MobileNumbers As String, ByVal Tarikh As String, ByVal SendTime As String, ByVal User As String, ByVal SendType As String)

        Dim T() As String = Tarikh.Split("/")

        CD = New CurrentDate
        Numbers = MobileNumbers.ToString.Split(",")
        Try
            Cmd.CommandText = "insert into SMSSendMessages (ID,Sender,MessageText,MobileNumbers,Parent,PhoneCount,Date,WeekDay,Time,UserID) values ('" & ID & "',N'" & Sender & "',N'" & MessageText & "',N'" & MobileNumbers & "',N'" & SendType & "'," & Integer.Parse(Numbers.Length) & ",N'" & CD.GetDate.ToString & "',N'" & CD.GetDay.ToString & "',N'" & SendTime & "','" & User & "')"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, " خطا در ذخیره سازی اطلاعات:::...", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
        Finally
            SqlCon.SqlCon.Close()
        End Try
    End Sub
End Class
