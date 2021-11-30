Imports System.Data.OleDb
Public Class login

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim myOleConn As OleDbConnection
        'ConnectionString Setting
        myOleConn = New OleDbConnection("Provider=SQLOLEDB; Data Source=SERVER\SQLEXPRESS; Database=master ; Uid=admin; Pwd=admin123;")
        Dim cmd As New OleDb.OleDbCommand

        Try
            Dim MyOlecmd = "SELECT * FROM [products] where [username]='" & TextBox1.Text & "' AND [password]='" & TextBox2.Text & "';"
            myOleConn.Open()
            cmd.Connection = myOleConn
            cmd.CommandText = MyOlecmd

            Dim dr As OleDbDataReader = cmd.ExecuteReader
            Dim userfound As Boolean = False
            Dim firstname As String = ""
            Dim lastname As String = ""

            While dr.Read
                userfound = True
                firstname = dr("firstName").ToString
                lastname = dr("lastName").ToString
            End While

            If userfound = True Then
                MsgBox("login successs user: " + firstname + "  " + lastname, MsgBoxStyle.OkOnly, "valid")

            Else
                MsgBox("Incorrect password or username  ", MsgBoxStyle.OkOnly, "invalid login")
            End If



        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
End Class