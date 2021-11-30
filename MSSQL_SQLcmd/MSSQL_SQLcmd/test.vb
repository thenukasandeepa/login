Imports System.Data.SqlClient
Imports System.Data

Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim mySqlConn As SqlConnection
        mySqlConn = New SqlConnection("Data Source=SERVER\SQLEXPRESS; Initial Catalog=master; User ID=admin; Password=admin123;")

        Try
            mySqlConn.Open()
            MessageBox.Show("My Database Connection Successfully Connected")
            mySqlConn.Close()
        Catch errex As Exception
            MessageBox.Show("My Database Connection Problem")
        End Try
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim myDBCnn As SqlConnection
        Dim dataTbl As New DataTable
        Dim dataAdapt As SqlDataAdapter

        myDBCnn = New SqlConnection("Data Source=SERVER\SQLEXPRESS; Initial Catalog=master; User ID=admin; Password=admin123;")

        Try
            myDBCnn.Open()

            Dim MystrQ As String
            MystrQ = ""
            'Write Query String
            MystrQ = "Select * From products;"
            dataAdapt = New SqlDataAdapter(MystrQ, myDBCnn)
            dataAdapt.Fill(dataTbl)
            DataGridView1.DataSource = dataTbl
            myDBCnn.Close()
            dataAdapt.Dispose()

        Catch ex As Exception
            MessageBox.Show("My Database Connection Problem")

        End Try

    End Sub

End Class
