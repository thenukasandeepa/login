Imports System.Data.OleDb


Public Class Form1


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            con.Open()

            If con.State = ConnectionState.Open Then
                MsgBox("Connected")
            Else
                MsgBox("Not Connected!")

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()

        End Try
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim sql As String
            Dim cmd As New OleDb.OleDbCommand
            Dim dt As New DataTable
            Dim da As New OleDb.OleDbDataAdapter
            con.Open()
            sql = "Select * from [User]"
            cmd.Connection = con
            cmd.CommandText = sql
            da.SelectCommand = cmd

            da.Fill(dt)

            DataGridView1.DataSource = dt
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()

        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Try
            Dim sql As String
            Dim cmd As New OleDb.OleDbCommand
            Dim da As New OleDb.OleDbDataAdapter
            con.Open()
            sql = "SELECT * FROM [User] where [username]='" & TextBox1.Text & "' AND [password]='" & TextBox2.Text & "'"
            cmd.Connection = con
            cmd.CommandText = sql
            Dim dr As OleDbDataReader = cmd.ExecuteReader
            Dim userfound As Boolean = False
            Dim firstname As String = ""
            Dim lastname As String = ""

            While dr.Read
                userfound = True
                firstname = dr("firstname").ToString
                lastname = dr("lastname").ToString
            End While

            If userfound = True Then
                MsgBox("login  ", MsgBoxStyle.OkOnly, "valid")

            Else
                MsgBox("can't log in  ", MsgBoxStyle.OkOnly, "invalid")
            End If

            con.Close()


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()

        End Try


    End Sub

End Class
