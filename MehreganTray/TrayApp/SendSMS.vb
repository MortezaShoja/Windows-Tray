Public Class SendSMS
    Private SendSMS As New WebService.Send
    Private Message As Integer = 0
    Private TS As TimeSpleater
    Private Opcode() As Byte
    Private RecCode() As Long
    Private IC As InternetChecker
    Private FD As FillData
    Private CD As CurrentDate

    Public Sub Send(ByVal UserID As String, ByVal MobileNumbers As String, ByVal SenderNummber As String, ByVal MessageText As String, ByVal UserName As String, ByVal Password As String, ByVal SendType As String)
        FD = New FillData
        Dim nu() As String = MobileNumbers.Split(",")
        Dim sms As New WebService.Send()
        Dim rec As Long() = Nothing
        Dim status As Byte() = Nothing
        Dim Up As New UpdateClass
        CD = New CurrentDate
        Dim ID As String = Guid.NewGuid.ToString

        FD.SaveData(ID, SenderNummber, MessageText, MobileNumbers, CD.GetDate, Now.TimeOfDay.ToString, UserID, SendType)
        IC = New InternetChecker

        If Not IC.IsConnectionAvailable() = False Then

            Try

                Message = sms.SendSms(UserName, Password, nu, SenderNummber, MessageText, False, "", rec, status)

                'Message :
                ' InvalidUserPass=0,
                ' Successfull = 1,
                ' NoCredit = 2,
                ' DailyLimit = 3,
                ' SendLimit = 4,
                ' InvalidNumber = 5

                'Status :
                ' Sent=0,
                ' Failed=1
            Catch ex As Exception
                Message = 6
            End Try

            Select Case Message

                Case Is = 0
                    Up.UpdateDatabase(ID, "نام کاربری یا کلمه عبور اشتباه می باشد." & " -- " & Now.TimeOfDay.ToString, 0)
                Case Is = 1
                    Up.UpdateDatabase(ID, "ارسال پیامک با موفقیت انجام شد." & " -- " & Now.TimeOfDay.ToString, 1)
                Case Is = 2
                    Up.UpdateDatabase(ID, "اعتبار شما برای ارسال کافی نمی باشد." & " -- " & Now.TimeOfDay.ToString, 0)
                Case Is = 3
                    Up.UpdateDatabase(ID, ".محدودیت زمان ارسال" & " -- " & Now.TimeOfDay.ToString, 0)
                Case Is = 4
                    Up.UpdateDatabase(ID, "محدودیت در ارسال." & " -- " & Now.TimeOfDay.ToString, 0)
                Case Is = 5
                    Up.UpdateDatabase(ID, "شماره مرکز ارسال پیامک اشتباه می باشد." & " -- " & Now.TimeOfDay.ToString, 0)
                Case Is = 6
                    Up.UpdateDatabase(ID, Message.ToString & ".ارسال پیامک با موفقیت انجام شد" & " -- " & Now.TimeOfDay.ToString, 1)

            End Select

            If Message > 6 Then
                Up.UpdateDatabase(ID, Message.ToString & ".خطای نا معلوم ---- کد خطا " & " -- " & Now.TimeOfDay.ToString, 0)
            End If
        Else
            Up.UpdateDatabase(ID, "7" & "خطای در برقراری ارتباط با شبکه اینترنت. " & " -- " & Now.TimeOfDay.ToString, 0)
        End If
        Message = 0
        MessageText = String.Empty
        MobileNumbers = String.Empty
    End Sub

End Class
