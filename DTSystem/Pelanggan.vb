Imports System.Data.Odbc
Public Class Pelanggan
    Sub tampilkanpelanggan()
        Call Conn()
        Dc = New OdbcCommand("SELECT * FROM konsumen", dts_connect)
        Da = New OdbcDataAdapter(Dc)
        Ds = New DataSet
        Da.Fill(Ds, "konsumen")
        DataGridView1.DataSource = Ds.Tables("konsumen")
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill

        DataGridView1.Columns(0).Visible = False

        DataGridView1.Columns("kode").HeaderText = "Kode Pelanggan"
        DataGridView1.Columns("nama_konsumen").HeaderText = "Nama Pelanggan"
        DataGridView1.Columns("alamat").HeaderText = "Alamat Pelanggan"
        DataGridView1.Columns("kontak").HeaderText = "Kontak/PIC Pelanggan"
    End Sub
    Sub TampilanAwal()
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        Button1.Visible = False
        Call tampilkanpelanggan()

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()

    End Sub

    Private Sub Pelanggan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call TampilanAwal()

    End Sub
End Class