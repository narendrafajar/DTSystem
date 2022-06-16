Imports System.Data.Odbc
Module dts
    Public dts_connect As OdbcConnection
    Public Da As OdbcDataAdapter
    Public Ds As DataSet
    Public Dr As OdbcDataReader
    Public MyDB As String
    Public Dc As OdbcCommand

    Public Sub Conn()
        MyDB = "Driver={MySQL ODBC 3.51 Driver};database=dts;server=localhost;uid=root;pwd="
        dts_connect = New OdbcConnection(MyDB)
        If dts_connect.State = ConnectionState.Closed Then dts_connect.Open()
    End Sub

End Module
