Imports Microsoft.VisualBasic

Public Class CurrentDate
    Private DC As New DateConvertor
    Public Function GetDate(Optional ByVal AddDay = 0)
        Dim DT As String = String.Empty
        If AddDay > 0 Then
            DT = Now.Date.AddDays(AddDay)
        Else
            DT = Now.Date.ToString
        End If
        Dim DTT() As String = DT.Split("/")
        DC.Convertor(Mid(DTT(2), 1, 4), DTT(0), DTT(1))
        Return (DC.Hyear & "/" & DC.Hmonth & "/" & DC.Hday)
    End Function
    Public Function GetDay(Optional ByVal AddDay = 0)
        Dim DT As String = String.Empty
        If AddDay > 0 Then
            DT = Now.Date.AddDays(AddDay)
        Else
            DT = Now.Date.ToString
        End If
        Dim DTT() As String = DT.Split("/")
        DC.Convertor(Mid(DTT(2), 1, 4), DTT(0), DTT(1))
        Return DC.HweekDay
    End Function
    Public Function GetDateAndDay(Optional ByVal AddDay = 0)
        Dim DT As String = String.Empty
        If AddDay > 0 Then
            DT = Now.Date.AddDays(AddDay)
        Else
            DT = Now.Date.ToString
        End If
        Dim DTT() As String = DT.Split("/")
        DC.Convertor(Mid(DTT(2), 1, 4), DTT(0), DTT(1))
        Return (DC.HweekDay & "  " & DC.Hday & "/" & DC.Hmonth & "/" & DC.Hyear)
    End Function
End Class
