Public Class InternetChecker
    Public Function IsConnectionAvailable() As Boolean


        If My.Computer.Network.IsAvailable = True Then

            Return My.Computer.Network.Ping("8.8.8.8")

        Else

            Return False
        End If

    End Function
End Class
