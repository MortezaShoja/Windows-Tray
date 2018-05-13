
Public Class AppContext
    Inherits ApplicationContext
    Dim SSG As SendSMSGhest
#Region " Storage "

    Private WithEvents Tray As NotifyIcon
    Private WithEvents MainMenu As ContextMenuStrip
    Private WithEvents mnuDisplayForm As ToolStripMenuItem
    Private WithEvents mnuSep1 As ToolStripSeparator
    Private WithEvents mnuExit As ToolStripMenuItem

#End Region

#Region " Constructor "

    Public Sub New()
        'Initialize the menus
        SSG = New SendSMSGhest
        SSG.SendGhestMessage()

        mnuDisplayForm = New ToolStripMenuItem("نمایش اقساط")
        mnuSep1 = New ToolStripSeparator()
        mnuExit = New ToolStripMenuItem("خروج")
        MainMenu = New ContextMenuStrip
        MainMenu.Items.AddRange(New ToolStripItem() {mnuDisplayForm, mnuSep1, mnuExit})

        'Initialize the tray
        Tray = New NotifyIcon
        Tray.Icon = My.Resources.TrayIcon
        Tray.ContextMenuStrip = MainMenu
        Tray.Text = "نرم افزار مدیریت اعلام اقساط"

        'Display
        Tray.Visible = True
    End Sub

#End Region

#Region " Event handlers "

    Private Sub AppContext_ThreadExit(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles Me.ThreadExit
        'Guarantees that the icon will not linger.
        Tray.Visible = False
    End Sub

    Private Sub mnuDisplayForm_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles mnuDisplayForm.Click
        ShowDialog()
    End Sub

    Private Sub mnuExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles mnuExit.Click
        ExitApplication()
    End Sub

    Private Sub Tray_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles Tray.DoubleClick
        ShowDialog()
    End Sub

#End Region

End Class
