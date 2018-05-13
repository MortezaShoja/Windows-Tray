Public Class TimeSpleater

    Public Function GetTimeOfDay()
        Dim TimeOfDay As String = Now.TimeOfDay.ToString
        If TimeOfDay.Length > 9 Then
            Return (Mid(TimeOfDay, 1, 8)).ToString
        Else
            Return TimeOfDay.ToString
        End If
    End Function
    Public Function AddSeconds(ByVal Seconds As Double)
        Dim TimeOfDay As String = String.Empty
        TimeOfDay = Now.AddSeconds(Seconds).TimeOfDay.ToString
        If TimeOfDay.Length > 9 Then
            Return (Mid(TimeOfDay, 1, 8)).ToString
        Else
            Return Now.AddSeconds(Seconds).TimeOfDay.ToString
        End If
    End Function
    Public Function AddMinutes(ByVal Minute As Double)
        Dim TimeOfDay As String = String.Empty
        TimeOfDay = Now.AddMinutes(Minute).TimeOfDay.ToString
        If TimeOfDay.Length > 9 Then
            Return (Mid(TimeOfDay, 1, 8)).ToString
        Else
            Return Now.AddMinutes(Minute).TimeOfDay.ToString
        End If
    End Function

    Public Function AddTime(ByVal Time As Date, ByVal Minute As Integer)
        Dim TimeOfDay As Date
        TimeOfDay = Time
        Return TimeOfDay.AddMinutes(Minute)
    End Function
    Public Function AddSeconds2(ByVal Time As Date, ByVal Second As Integer)
        Dim TimeOfDay As Date
        TimeOfDay = Time
        Return TimeOfDay.AddSeconds(Second)
    End Function
End Class
