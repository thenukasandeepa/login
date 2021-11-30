Imports System.Data.OleDb

Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim myOleConn As OleDbConnection
        myOleConn = New OleDbConnection("Provider=SQLOLEDB; Data Source=SERVER\SQLEXPRESS; Database=master ; Uid=admin; Pwd=admin123;")
        Try
            myOleConn.Open()
            MessageBox.Show("Server Connected Successfully.")
            myOleConn.Close()
        Catch errex As Exception
            MessageBox.Show("Server Connection Error.")
        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim myOleConn As OleDbConnection
        'ConnectionString Setting
        myOleConn = New OleDbConnection("Provider=SQLOLEDB; Data Source=SERVER\SQLEXPRESS; Database=master ; Uid=admin; Pwd=admin123;")

        Dim dataTbl As New DataTable
        Dim dataAdapt As OleDbDataAdapter


        Try
            'OleDbCommand for Query
            Dim MyOlecmd = "Select * From products;"
            myOleConn.Open()
            dataAdapt = New OleDbDataAdapter(MyOlecmd, myOleConn)
            dataAdapt.Fill(dataTbl)
            DataGridView1.DataSource = dataTbl
            myOleConn.Close()
            dataAdapt.Dispose()

        Catch oleex As Exception
            MessageBox.Show("OleDbServer Connection Error.")
        End Try

    End Sub
End Class
