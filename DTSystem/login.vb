Imports System.Data.Odbc
Public Class login
    Sub buka()
        Dashboard.KontakToolStripMenuItem.Visible = True
        Dashboard.TransaksiToolStripMenuItem.Visible = True
        Dashboard.KasBankToolStripMenuItem.Visible = True
        Dashboard.LaporanToolStripMenuItem.Visible = True
        Dashboard.SettingToolStripMenuItem.Visible = True
        Dashboard.LoginToolStripMenuItem.Visible = False
        Dashboard.ExitToolStripMenuItem.Enabled = False
        Dashboard.StatusStrip1.Visible = True
        Dashboard.LogOutToolStripMenuItem.Visible = True
    End Sub

    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox2.PasswordChar = "*"
    End Sub
    Sub stsStrip()
        Call Conn()
        Dc = New OdbcCommand("SELECT * FROM login WHERE username ='" & TextBox1.Text & "'", dts_connect)
        Dr = Dc.ExecuteReader
        Dr.Read()
        Dashboard.ToolStripStatusLabel2.Text = Dr.Item("nama_user")
        Dashboard.ToolStripStatusLabel4.Text = Dr.Item("status")
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Password dan Username anda Kosong, Mohon diisi Terlebih dahulu")
        Else
            Call Conn()
            Dc = New OdbcCommand("SELECT * FROM login where username='" & TextBox1.Text & "' and password = '" & TextBox2.Text & "'", dts_connect)
            Dr = Dc.ExecuteReader
            Dr.Read()
            If Not Dr.HasRows Then
                MsgBox("Username dan Password anda tidak sesuai")
            Else
                Call buka()
                Dc = New OdbcCommand("UPDATE login SET status ='ONLINE' WHERE username='" & TextBox1.Text & "'", dts_connect)
                Dr = Dc.ExecuteReader
                MsgBox(" Anda Berhasil Login !")
                Me.Close()
                Call stsStrip()

            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox2.PasswordChar = ""
        Else
            TextBox2.PasswordChar = "*"
        End If
    End Sub
End Class