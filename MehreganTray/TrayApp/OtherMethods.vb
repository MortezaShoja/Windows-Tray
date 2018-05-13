Friend Module OtherMethods

    Private MDP As frmSentLog

    Public Sub ExitApplication()
        'Perform any clean-up here
        'Then exit the application
        Application.Exit()
    End Sub

    Public Sub ShowDialog()
        If MDP IsNot Nothing AndAlso Not MDP.IsDisposed Then Exit Sub

        Dim CloseApp As Boolean = False

        MDP = New frmSentLog
        MDP.ShowDialog()
        CloseApp = (MDP.DialogResult = DialogResult.Abort)
        MDP = Nothing

        If CloseApp Then Application.Exit()
    End Sub

End Module
