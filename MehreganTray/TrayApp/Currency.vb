Imports System.Windows.Forms
Public Class Currency

    Private Function ReturnNumber(ByVal Number As String)

        Dim Tmp As String = String.Empty
        For Q As Integer = (Number.Length) To 1 Step -1
            Tmp += Mid(Number, Q, 1)
        Next
        Return (Tmp)
    End Function


    Private Function Merger(ByVal Number As String)
        Dim MargedNumber As String = String.Empty
        Dim J As Integer = Integer.Parse(Number.Length)
        For I As Integer = 1 To J Step 3
            MargedNumber += Mid(Number, I, 3) + ","
        Next
        MargedNumber = Mid(MargedNumber, 1, MargedNumber.Length - 1)

        Return (MargedNumber)
    End Function


    Public Function CodeNumber(ByVal Number As String)
        If Not IsNumeric(Number) = True Then
            Number = DeCodeNumber(Number)
        End If


        Number = Double.Parse(Number)
        Try
            Return ReturnNumber(Merger(ReturnNumber(Number))) & " ریال"
        Catch ex As Exception
            Return 0
        End Try

    End Function

    Public Function CodeNumberNoRiyal(ByVal Number As String)
        If Not IsNumeric(Number) = True Then
            Number = DeCodeNumber(Number)
        End If

        Number = Double.Parse(Number)
        Try
            Return ReturnNumber(Merger(ReturnNumber(Number)))
        Catch ex As Exception
            Return 0
        End Try

    End Function

    Public Function CodeNumberRTL(ByVal Number As String)
        Dim S As String = String.Empty
        If IsNumeric(Number) = True Then
            Number = Double.Parse(Number)
            Try
                Dim Tmp() As String = Merger(ReturnNumber(Number)).ToString.Split(",")
                Dim Tmp2(Tmp.Length - 1) As String
                For I As Integer = 0 To Tmp.Length - 1
                    Tmp2(Tmp.Length - 1 - I) = Tmp(I)
                Next
                For K As Integer = 0 To Tmp.Length - 1
                    S += Tmp2(K) & ","
                Next
                S = Mid(S, 1, S.Length - 1)

                Return ReturnNumber(S) & " ریال"
            Catch ex As Exception
                Return ""
            End Try
        Else
            'Return "خطا در درج مبلغ عدد"
            Return 0
        End If
    End Function



    Public Function DeCodeNumber(ByVal Number As String)
        Try
            Number = Number.Replace("ریال", "")
            Return Number.Replace(",", "")
        Catch ex As Exception
            Return 0
        End Try

    End Function


End Class
