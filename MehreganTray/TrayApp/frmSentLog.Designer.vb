<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSentLog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboDate = New System.Windows.Forms.ComboBox()
        Me.cboReportType = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboSendType = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dbgReport = New System.Windows.Forms.DataGridView()
        CType(Me.dbgReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 26)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "تاریخ گزارش :"
        '
        'cboDate
        '
        Me.cboDate.FormattingEnabled = True
        Me.cboDate.Location = New System.Drawing.Point(99, 12)
        Me.cboDate.Name = "cboDate"
        Me.cboDate.Size = New System.Drawing.Size(128, 34)
        Me.cboDate.TabIndex = 4
        '
        'cboReportType
        '
        Me.cboReportType.FormattingEnabled = True
        Me.cboReportType.Items.AddRange(New Object() {"ارسال نشده ها", "ارسال شده ها"})
        Me.cboReportType.Location = New System.Drawing.Point(538, 12)
        Me.cboReportType.Name = "cboReportType"
        Me.cboReportType.Size = New System.Drawing.Size(98, 34)
        Me.cboReportType.TabIndex = 6
        Me.cboReportType.Text = "ارسال شده ها"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(437, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 26)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "وضعیت ارسال :"
        '
        'cboSendType
        '
        Me.cboSendType.FormattingEnabled = True
        Me.cboSendType.Items.AddRange(New Object() {"یادآوری اقساط", "سررسید اقساط", "دیرکرد اقساط"})
        Me.cboSendType.Location = New System.Drawing.Point(315, 12)
        Me.cboSendType.Name = "cboSendType"
        Me.cboSendType.Size = New System.Drawing.Size(116, 34)
        Me.cboSendType.TabIndex = 8
        Me.cboSendType.Text = "یادآوری اقساط"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(236, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 26)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "نوع ارسال :"
        '
        'dbgReport
        '
        Me.dbgReport.AllowUserToAddRows = False
        Me.dbgReport.AllowUserToDeleteRows = False
        Me.dbgReport.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dbgReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dbgReport.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dbgReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dbgReport.Location = New System.Drawing.Point(10, 52)
        Me.dbgReport.Name = "dbgReport"
        Me.dbgReport.ReadOnly = True
        Me.dbgReport.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dbgReport.Size = New System.Drawing.Size(626, 304)
        Me.dbgReport.TabIndex = 9
        '
        'frmSentLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 26.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(646, 369)
        Me.Controls.Add(Me.dbgReport)
        Me.Controls.Add(Me.cboSendType)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboReportType)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboDate)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("B Nazanin", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "frmSentLog"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.Text = "گزارش پیامک های ارسال شده"
        CType(Me.dbgReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboDate As System.Windows.Forms.ComboBox
    Friend WithEvents cboReportType As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboSendType As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dbgReport As System.Windows.Forms.DataGridView
End Class
