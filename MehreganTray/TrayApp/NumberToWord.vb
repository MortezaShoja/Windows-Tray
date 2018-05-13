Public Class NumberToWord
    Private CU As New Currency

    Public Function Convert(ByVal Number As String)
        Dim Ashar As Integer = 0

        Dim Manfi As String = ""
        If IsNumeric(Number) = True Then
            If Number < 0 Then
                Manfi = " منفی "
                Number = Mid(Number, 2, Number.Length)
            End If
        Else
            Manfi = ""
        End If

        Try
            Ashar = Mid(Number, Number.Length, 1)
        Catch ex As Exception
        End Try

        If Number = "" Then
            Return ""
            Exit Function
        ElseIf Number = 0 Then
            Return "صفر تومان"
            Exit Function
        End If

        Number = Mid(Number, 1, Number.ToString.Length - 1)

        Number = CU.CodeNumberNoRiyal(Number)

        Dim Word As String = String.Empty
        Dim Temp() As String = Number.ToString.Split(",")
        For I As Integer = Temp.Length To 1 Step -1

            Select Case I

                Case Is = 1
                    If Temp(Temp.Length - 1) = "000" Then Exit Select
                    Word += ReturnNumber(Temp(Temp.Length - 1))
                    Word += " "
                    Word += "و "
                Case Is = 2
                    If Temp(Temp.Length - 2) = "000" Then Exit Select
                    Word += ReturnNumber(Temp(Temp.Length - 2))
                    Word += " هزار "
                    Word += "و "
                Case Is = 3
                    If Temp(Temp.Length - 3) = "000" Then Exit Select
                    Word += ReturnNumber(Temp(Temp.Length - 3))
                    Word += " میلیون "
                    Word += "و "
                Case Is = 4
                    If Temp(Temp.Length - 4) = "000" Then Exit Select
                    Word += ReturnNumber(Temp(Temp.Length - 4))
                    Word += " میلیارد "
                    Word += "و "
                Case Is = 5
                    If Temp(Temp.Length - 5) = "000" Then Exit Select
                    Word += ReturnNumber(Temp(Temp.Length - 5))
                    Word += " تریلیارد "
                    Word += "و "

            End Select

        Next

        Word = Mid(Word, 1, Word.Length - 2)
        Word += "تومان"
        If Integer.Parse(ashar) > 0 Then
            Word += " و " & ReturnNumber(ashar) & " ریال "
        End If

        Return Manfi & Word


    End Function

    Public Function ConvertNoTooman(ByVal Number As String)
        If Number = "" Then
            Return ""
            Exit Function
        ElseIf Number = 0 Then
            Return "صفر"
            Exit Function
        End If

        Number = Mid(Number, 1, Number.ToString.Length - 2)

        Number = CU.CodeNumberNoRiyal(Number)

        Dim Word As String = String.Empty
        Dim Temp() As String = Number.ToString.Split(",")
        For I As Integer = Temp.Length To 1 Step -1

            Select Case I

                Case Is = 1
                    If Temp(Temp.Length - 1) = "000" Then Exit Select
                    Word += ReturnNumber(Temp(Temp.Length - 1))
                    Word += " "
                    Word += "و "
                Case Is = 2
                    If Temp(Temp.Length - 2) = "000" Then Exit Select
                    Word += ReturnNumber(Temp(Temp.Length - 2))
                    Word += " هزار "
                    Word += "و "
                Case Is = 3
                    If Temp(Temp.Length - 3) = "000" Then Exit Select
                    Word += ReturnNumber(Temp(Temp.Length - 3))
                    Word += " میلیون "
                    Word += "و "
                Case Is = 4
                    If Temp(Temp.Length - 4) = "000" Then Exit Select
                    Word += ReturnNumber(Temp(Temp.Length - 4))
                    Word += " میلیارد "
                    Word += "و "
                Case Is = 5
                    If Temp(Temp.Length - 5) = "000" Then Exit Select
                    Word += ReturnNumber(Temp(Temp.Length - 5))
                    Word += " تریلیارد "
                    Word += "و "

            End Select

        Next

        Word = Mid(Word, 1, Word.Length - 2)
        Return Word


    End Function


    Private Function ReturnNumber(ByVal Number As String)
        Dim S As String = String.Empty
        If IsNumeric(Number) = True Then
            Select Case Number.Length
                Case Is = 1
                    Number = "00" & Number
                Case Is = 2
                    Number = "0" & Number
            End Select


            If Number.Length = 3 Then
                Select Case Mid(Number, 1, 1)

                    Case Is = "1"
                        S = "صد"
                    Case Is = "2"
                        S = "دویست"
                    Case Is = "3"
                        S = "سیصد"
                    Case Is = "4"
                        S = "چهارصد"
                    Case Is = "5"
                        S = "پانصد"
                    Case Is = "6"
                        S = "ششصد"
                    Case Is = "7"
                        S = "هفتصد"
                    Case Is = "8"
                        S = "هشتصد"
                    Case Is = "9"
                        S = "نه صد"
                End Select
            End If
            '------------------------------------
            If Number.Length >= 2 Then

                If S <> String.Empty And Mid(Number, 2, 1) <> "0" Then
                    S += " و "
                End If

                '-----------------------------------
                If Integer.Parse(Mid(Number, 2, 2)) >= 11 And Integer.Parse(Mid(Number, 2, 2)) <= 19 Then

                    Select Case Mid(Number, 2, 2)

                        Case Is = "11"
                            S += "یازده"
                        Case Is = "12"
                            S += "دوازده"
                        Case Is = "13"
                            S += "سیزده"
                        Case Is = "14"
                            S += "چهارده"
                        Case Is = "15"
                            S += "پانزده"
                        Case Is = "16"
                            S += "شانزده"
                        Case Is = "17"
                            S += "هفده"
                        Case Is = "18"
                            S += "هجده"
                        Case Is = "19"
                            S += "نوزده"
                    End Select
                    Return S
                    Exit Function

                End If
                '-------------------------------------------------------

                Select Case Mid(Number, 2, 1)

                    Case Is = "1"
                        S += "ده"
                    Case Is = "2"
                        S += "بیست"
                    Case Is = "3"
                        S += "سی"
                    Case Is = "4"
                        S += "چهل"
                    Case Is = "5"
                        S += "پنجاه"
                    Case Is = "6"
                        S += "شصت"
                    Case Is = "7"
                        S += "هفتاد"
                    Case Is = "8"
                        S += "هشتاد"
                    Case Is = "9"
                        S += "نود"
                End Select
            End If
            '------------------------------------
            If Number.Length >= 1 Then
                If S <> String.Empty And Mid(Number, 3, 1) <> "0" Then
                    S += " و "
                End If
                Select Case Mid(Number, 3, 1)

                    Case Is = "1"
                        S += "یک"
                    Case Is = "2"
                        S += "دو"
                    Case Is = "3"
                        S += "سه"
                    Case Is = "4"
                        S += "چهار"
                    Case Is = "5"
                        S += "پنج"
                    Case Is = "6"
                        S += "شش"
                    Case Is = "7"
                        S += "هفت"
                    Case Is = "8"
                        S += "هشت"
                    Case Is = "9"
                        S += "نه"
                End Select
            End If
        End If

        Return S
    End Function


End Class
