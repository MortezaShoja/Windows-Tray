Public Class SendSMSGhest
    Private T As New Timer
    Private SqlCon As SQLserver
    Private CD As CurrentDate
    Private SS As SendSMS
    Private CU As Currency
    Private NtoW As NumberToWord
    Private SI As SendInfo


    Public Sub SendGhestMessage()
        Timer_SendMessage()
        T.Interval = 600000
        AddHandler T.Tick, AddressOf Timer_SendMessage
        T.Start()

    End Sub

    Private Sub Timer_SendMessage()
        YadAvariSMS()
        SarResidSMS()
        DirKardSMS()
    End Sub

    '-------------------------------------------

    Private Sub YadAvariSMS()
        SI = New SendInfo
        Dim SII As String = SI.CheckSentDay("یادآوری")
        If SII = String.Empty Then
            SI.SaveSentDay("یادآوری")

            Dim Count As Integer = 0
            Dim SendTime As String = GetSMSAghsatInfo(0)
            Dim SenderNumber As String = GetSMSAghsatInfo(3)
            Dim UserName As String = GetSMSAghsatInfo(4)
            Dim Password As String = GetSMSAghsatInfo(5)
            If (Now.Hour.ToString & ":" & Now.Minute.ToString) >= SendTime Then
                CD = New CurrentDate
                CU = New Currency
                NtoW = New NumberToWord
                Dim Gender As String = String.Empty
                Try
                    SqlCon = New SQLserver
                    Dim cmd2 As New Data.SqlClient.SqlCommand("Select B.ID,M.Majmooe,Pardakhte,Row,G.Gender,G.Name + ' ' + G.LName as 'FullName',B.price as 'مبلغ-ریال',B.date as 'تاریخ سر رسید',G.Mobile as 'تلفن همراه',B.Jahate From Bank B inner join GharardadNo G On G.VahedNoID=B.ID Inner Join Majmooe M on M.ID=G.MajmooeNameID where B.date=N'" & CD.GetDate(3).ToString & "' And Passed='False' AND (FormType=N'نقدی' OR FormType=N'سفته' OR FormType=N'واریز به حساب') Order By B.Date,FormType Desc", SqlCon.SqlCon)
                    SqlCon.SqlCon.Open()
                    Dim sdr2 As Data.SqlClient.SqlDataReader = cmd2.ExecuteReader
                    While sdr2.Read
                        Count += 1
                        If sdr2(4).ToString = 1 Then
                            Gender = "سرکار خانم "
                        Else
                            Gender = "جناب آقای "
                        End If
                        SS = New SendSMS
                        SS.Send(sdr2(0).ToString, sdr2(8).ToString, SenderNumber, Gender & sdr2(5) & vbCrLf & " مشتری محترم پروژه " & sdr2(1).ToString & vbCrLf & " یادآوری قسط شماره " & GhestRow(sdr2(0).ToString, sdr2(2).ToString, sdr2(3).ToString) & " به مبلغ " & CU.CodeNumber(sdr2(6).ToString) & " معادل " & NtoW.Convert(sdr2(6).ToString) & " به تاریخ سررسید " & sdr2(7).ToString & " بابت " & sdr2(9).ToString, UserName, Password, "یادآوری اقساط")
                    End While
                    sdr2.Close()
                    MessageBox.Show("ارسال پیامک یادآوری با موفقیت انجام شد" & vbCrLf & "تعداد " & Count.ToString & " ارسال گردید ", "ارسال پیامک یادآوری", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, False)
                Catch ex As Exception
                    MessageBox.Show("خطا در ارسال پیامک", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, False)
                Finally
                    SqlCon.SqlCon.Close()
                End Try
             
            End If
        Else
            MessageBox.Show("امکان ارسال پیامک یادآوری نمی باشد" & vbCrLf & "پیامک یادآوری امروز در ساعت " & SII & " ارسال گردیده است. ", "خطا در ارسال پیامک", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, False)
        End If
    End Sub

    Private Sub SarResidSMS()
        SI = New SendInfo
        Dim SII As String = SI.CheckSentDay("سررسید اقساط")
        If SII = String.Empty Then
            SI.SaveSentDay("سررسید اقساط")

            Dim Count As Integer = 0
            Dim SendTime As String = GetSMSAghsatInfo(1)
            Dim SenderNumber As String = GetSMSAghsatInfo(3)
            Dim UserName As String = GetSMSAghsatInfo(4)
            Dim Password As String = GetSMSAghsatInfo(5)

            If (Now.Hour.ToString & ":" & Now.Minute.ToString) >= SendTime Then
                CD = New CurrentDate
                CU = New Currency
                NtoW = New NumberToWord
                Dim Gender As String = String.Empty
                Try
                    SqlCon = New SQLserver
                    Dim cmd2 As New Data.SqlClient.SqlCommand("Select B.ID,M.Majmooe,Pardakhte,Row,G.Gender,G.Name + ' ' + G.LName as 'FullName',B.price as 'مبلغ-ریال',B.date as 'تاریخ سر رسید',G.Mobile as 'تلفن همراه',B.Jahate From Bank B inner join GharardadNo G On G.VahedNoID=B.ID Inner Join Majmooe M on M.ID=G.MajmooeNameID where B.date=N'" & CD.GetDate.ToString & "' And Passed='False' AND (FormType=N'نقدی' OR FormType=N'سفته' OR FormType=N'واریز به حساب') Order By B.Date,FormType Desc", SqlCon.SqlCon)
                    SqlCon.SqlCon.Open()
                    Dim sdr2 As Data.SqlClient.SqlDataReader = cmd2.ExecuteReader
                    While sdr2.Read
                        Count += 1
                        If sdr2(4).ToString = 1 Then
                            Gender = "سرکار خانم "
                        Else
                            Gender = "جناب آقای "
                        End If
                        SS = New SendSMS
                        SS.Send(sdr2(0).ToString, sdr2(8).ToString, SenderNumber, Gender & sdr2(5) & vbCrLf & " مشتری محترم پروژه " & sdr2(1).ToString & vbCrLf & " لطفاً جهت پرداخت قسط شماره " & GhestRow(sdr2(0).ToString, sdr2(2).ToString, sdr2(3).ToString) & " به مبلغ " & CU.CodeNumber(sdr2(6).ToString) & " معادل " & NtoW.Convert(sdr2(6).ToString) & " به تاریخ سررسید امروز مورخ " & sdr2(7).ToString & " بابت " & sdr2(9).ToString & " اقدام فرمائید. ", UserName, Password, "سررسید اقساط")
                    End While
                    sdr2.Close()
                    MessageBox.Show("ارسال پیامک سررسید اقساط با موفقیت انجام شد" & vbCrLf & "تعداد " & Count.ToString & " ارسال گردید ", "ارسال پیامک سررسید اقساط", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, False)
                Catch ex As Exception
                    MessageBox.Show("خطا در ارسال پیامک" & ex.Message.ToString, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, False)
                Finally
                    SqlCon.SqlCon.Close()
                End Try
            End If
        Else
            MessageBox.Show("امکان ارسال پیامک سررسید اقساط نمی باشد" & vbCrLf & "پیامک سررسید اقساط امروز در ساعت " & SII & " ارسال گردیده است. ", "خطا در ارسال پیامک", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, False)
        End If
    End Sub

    Private Sub DirKardSMS()
        SI = New SendInfo
        Dim SII As String = SI.CheckSentDay("دیرکرد اقساط")
        If SII = String.Empty Then
            SI.SaveSentDay("دیرکرد اقساط")

            Dim Count As Integer = 0
            Dim SendTime As String = GetSMSAghsatInfo(2)
            Dim SenderNumber As String = GetSMSAghsatInfo(3)
            Dim UserName As String = GetSMSAghsatInfo(4)
            Dim Password As String = GetSMSAghsatInfo(5)

            If (Now.Hour.ToString & ":" & Now.Minute.ToString) >= SendTime Then
                CD = New CurrentDate
                CU = New Currency
                NtoW = New NumberToWord
                Dim Gender As String = String.Empty
                Try
                    SqlCon = New SQLserver
                    Dim cmd2 As New Data.SqlClient.SqlCommand("Select B.ID,M.Majmooe,Pardakhte,Row,G.Gender,G.Name + ' ' + G.LName as 'FullName',B.price as 'مبلغ-ریال',B.date as 'تاریخ سر رسید',G.Mobile as 'تلفن همراه',B.Jahate From Bank B inner join GharardadNo G On G.VahedNoID=B.ID Inner Join Majmooe M on M.ID=G.MajmooeNameID where B.date < N'" & CD.GetDate.ToString & "' And Passed='False' AND (FormType=N'نقدی' OR FormType=N'سفته' OR FormType=N'واریز به حساب') Order By B.Date,FormType Desc", SqlCon.SqlCon)
                    SqlCon.SqlCon.Open()
                    Dim sdr2 As Data.SqlClient.SqlDataReader = cmd2.ExecuteReader
                    While sdr2.Read
                        Count += 1
                        If sdr2(4).ToString = 1 Then
                            Gender = "سرکار خانم "
                        Else
                            Gender = "جناب آقای "
                        End If
                        SS = New SendSMS
                        SS.Send(sdr2(0).ToString, sdr2(8).ToString, SenderNumber, Gender & sdr2(5) & vbCrLf & " مشتری محترم پروژه " & sdr2(1).ToString & vbCrLf & " قسط شماره " & GhestRow(sdr2(0).ToString, sdr2(2).ToString, sdr2(3).ToString) & " به مبلغ " & CU.CodeNumber(sdr2(6).ToString) & " معادل " & NtoW.Convert(sdr2(6).ToString) & " به تاریخ سررسید " & sdr2(7).ToString & " بابت " & sdr2(9).ToString & " پرداخت نشده است لطفاً اقدام فرمائید. ", UserName, Password, "دیرکرد اقساط")
                    End While
                    sdr2.Close()
                    MessageBox.Show("ارسال پیامک دیرکرد اقساط با موفقیت انجام شد" & vbCrLf & "تعداد " & Count.ToString & " ارسال گردید ", "ارسال پیامک دیرکرد اقساط", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, False)
                Catch ex As Exception
                    MessageBox.Show("خطا در ارسال پیامک", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, False)
                Finally
                    SqlCon.SqlCon.Close()
                End Try
            End If
        Else
            MessageBox.Show("امکان ارسال پیامک دیرکرد اقساط نمی باشد" & vbCrLf & "پیامک دیرکرد اقساط امروز در ساعت " & SII & " ارسال گردیده است. ", "خطا در ارسال پیامک", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, False)
        End If
    End Sub

    Private Function GhestRow(ByVal VahedNameID As String, ByVal Pardakhte As String, ByVal SanadCode As String)
        Dim Value As Integer = 0
        SqlCon = New SQLserver
        Dim cmd3 As New Data.SqlClient.SqlCommand("select Row_Number() Over (Order by Date) as 'Row',Row as 'SanadCode' from bank Where Pardakhte=N'" & Pardakhte & "' And ID='" & VahedNameID & "' order by Date", SqlCon.SqlCon)
        SqlCon.SqlCon.Open()
        Dim sdr3 As Data.SqlClient.SqlDataReader = cmd3.ExecuteReader
        While sdr3.Read
            If sdr3(1).ToString = SanadCode Then
                Value = sdr3(0)
                Exit While
            End If
        End While
        SqlCon.SqlCon.Close()
        sdr3.Close()
        Return Value
    End Function

    Private Function GetSMSAghsatInfo()
        Dim Value(6) As String
        SqlCon = New SQLserver
        Dim cmd4 As New Data.SqlClient.SqlCommand("Select YadavariSendTime,SarResidSendTime,DirkardSendTime,CarierNumber,CarierUserName,CarierPassword From SMSAghsatInfo ", SqlCon.SqlCon)
        SqlCon.SqlCon.Open()
        Dim sdr4 As Data.SqlClient.SqlDataReader = cmd4.ExecuteReader
        If sdr4.Read Then
            Value(0) = sdr4(0)
            Value(1) = sdr4(1)
            Value(2) = sdr4(2)
            Value(3) = sdr4(3)
            Value(4) = sdr4(4)
            Value(5) = sdr4(5)
        End If
        SqlCon.SqlCon.Close()
        sdr4.Close()
        Return Value
    End Function

End Class
