'Public Class GlobalVariables
'Public Shared Port As Integer = 2
'Public Shared Baudrate As Integer = 115200
'End Class

Public Class frm_login

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub btn_login_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_login.Click
        Log_In()

    End Sub

    Sub Log_In()
        If tb_user.Text = "" Or tb_passwd.Text = "" Then
            MsgBox("User and password cannot be blank.")
        End If
        If (tb_user.Text = "admin") And (tb_passwd.Text = "admin") Then
            frm_mainapp.Show()

        End If


    End Sub
    Private Sub tb_passwd_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_passwd.KeyDown
        If e.KeyCode = Keys.Enter Then
            Log_In()

        End If
    End Sub
End Class