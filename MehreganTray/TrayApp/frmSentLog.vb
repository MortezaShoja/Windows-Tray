Public Class frmSentLog
    Private SqlCon, SqlCon2 As New SQLserver
    Private Cmd As New Data.SqlClient.SqlCommand
    Private Sdr As Data.SqlClient.SqlDataReader
    Private tbl As New Data.DataTable
    Private dvw As Data.DataView
    Private b As Boolean
    Private CU As CurrentDate


    Private Sub frmSentLog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillCboDate()
        FillDbgReport()
    End Sub

    Private Sub FillDbgReport()
        Cmd.Connection = SqlCon.SqlCon
        tbl.Clear()

        Try
            Cmd.CommandText = "Select G.GharardadNo as 'شماره قرارداد',G.Name + ' ' + G.Lname as 'نام مشتری',S.Messagetext as 'متن پیامک',S.MobileNumbers as 'شماره همراه مشتری',S.[Time] as 'زمان ارسال',S.Sender as 'شماره فرستنده',S.Sent as 'شرح وضعیت ارسال' from GharardadNo G Inner Join SmsSendMessages S On G.VahedNoID=S.UserID where Parent=N'" & Me.cboSendType.Text & "' And SendOK='" & Me.cboReportType.SelectedIndex & "' AND date=N'" & Me.cboDate.Text & "'"
            SqlCon.SqlCon.Open()
            Sdr = Cmd.ExecuteReader
            Dim fc As Integer
            While (Sdr.Read)

                'populating columns
                If Not b Then
                    For fc = 0 To Sdr.FieldCount - 1
                        tbl.Columns.Add(Sdr.GetName(fc))
                    Next
                    b = True
                End If
                'populating rows
                Dim row As Data.DataRow = tbl.NewRow

                For fc = 0 To Sdr.FieldCount - 1
                    row(fc) = Sdr(fc)
                Next
                tbl.Rows.Add(row)
            End While
            dvw = New Data.DataView(tbl)
            Me.dbgReport.DataSource = dvw

            '-------------------------

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "خطا در خواندن اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
        Finally
            SqlCon.SqlCon.Close()
        End Try
    End Sub


    Private Sub FillCboDate()
        CU = New CurrentDate
        Me.cboDate.Items.Clear()
        SqlCon = New SQLserver
        Dim cmd4 As New Data.SqlClient.SqlCommand("select tarikh from smssentday group by tarikh order by tarikh", SqlCon.SqlCon)
        SqlCon.SqlCon.Open()
        Dim sdr4 As Data.SqlClient.SqlDataReader = cmd4.ExecuteReader
        While sdr4.Read
            Me.cboDate.Items.Add(sdr4(0).ToString)
        End While
        SqlCon.SqlCon.Close()
        sdr4.Close()
        Me.cboDate.Text = CU.GetDate
    End Sub

    Private Sub cboDate_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDate.SelectedIndexChanged
        FillDbgReport()
    End Sub

    Private Sub cboReportType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboReportType.SelectedIndexChanged
        FillDbgReport()
    End Sub

    Private Sub cboSendType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSendType.SelectedIndexChanged
        FillDbgReport()
    End Sub
End Class