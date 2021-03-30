Imports System.Data.SqlClient

Module Module1
    Public con As New SqlConnection
    Public Sub conectar()
        con.ConnectionString = "Data Source=DESKTOP-6SFNLF9;Initial Catalog=alumno;Integrated Security=True"
        con.Open()
    End Sub
End Module

