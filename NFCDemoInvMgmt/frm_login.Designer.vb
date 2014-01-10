<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_login
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tb_user = New System.Windows.Forms.TextBox()
        Me.tb_passwd = New System.Windows.Forms.TextBox()
        Me.btn_login = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(129, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(193, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Inventory System"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(74, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(290, 25)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Fixed Assets - Varistha Hotel"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(106, 145)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "User"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(106, 182)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 20)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Password"
        '
        'tb_user
        '
        Me.tb_user.Location = New System.Drawing.Point(197, 145)
        Me.tb_user.Name = "tb_user"
        Me.tb_user.Size = New System.Drawing.Size(125, 20)
        Me.tb_user.TabIndex = 4
        '
        'tb_passwd
        '
        Me.tb_passwd.Location = New System.Drawing.Point(197, 184)
        Me.tb_passwd.Name = "tb_passwd"
        Me.tb_passwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tb_passwd.Size = New System.Drawing.Size(125, 20)
        Me.tb_passwd.TabIndex = 5
        '
        'btn_login
        '
        Me.btn_login.Location = New System.Drawing.Point(247, 224)
        Me.btn_login.Name = "btn_login"
        Me.btn_login.Size = New System.Drawing.Size(74, 22)
        Me.btn_login.TabIndex = 6
        Me.btn_login.Text = "Log In"
        Me.btn_login.UseVisualStyleBackColor = True
        '
        'frm_login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(452, 296)
        Me.Controls.Add(Me.btn_login)
        Me.Controls.Add(Me.tb_passwd)
        Me.Controls.Add(Me.tb_user)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frm_login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frm_login"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tb_user As System.Windows.Forms.TextBox
    Friend WithEvents tb_passwd As System.Windows.Forms.TextBox
    Friend WithEvents btn_login As System.Windows.Forms.Button
End Class
