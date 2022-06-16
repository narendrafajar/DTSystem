Imports System.Data.Odbc
Public Class Dashboard
    Sub loadAwal()
        KontakToolStripMenuItem.Visible = False
        TransaksiToolStripMenuItem.Visible = False
        KasBankToolStripMenuItem.Visible = False
        LaporanToolStripMenuItem.Visible = False
        SettingToolStripMenuItem.Visible = False
        LogOutToolStripMenuItem.Visible = False
        StatusStrip1.Visible = False
    End Sub

    Private Sub LoginToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoginToolStripMenuItem.Click
        Call login.ShowDialog()
    End Sub

    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call loadAwal()

    End Sub

    Private Sub LogOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOutToolStripMenuItem.Click
        Call Conn()
        Dc = New OdbcCommand("UPDATE login SET status = 'OFFLINE' WHERE username= '" & login.TextBox1.Text & "'", dts_connect)
        Dr = Dc.ExecuteReader
        MsgBox("Anda Berhasil Logout")
        Call loadAwal()
        LoginToolStripMenuItem.Enabled = True
        ExitToolStripMenuItem.Enabled = True
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub PelangganToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PelangganToolStripMenuItem.Click
        Pelanggan.MdiParent = Me
        Pelanggan.Show()

        Me.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal)
    End Sub
End Class
