Imports System.Data.SqlClient

Public Class Form1

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
      
    End Sub

    Sub mostrardatos()
        Dim da As New SqlDataAdapter("select * from Alumno", con)
        Dim ds As New DataSet
        da.Fill(ds, "Alumno")
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.Columns("expediente").HeaderText = "expediente"
        DataGridView1.Columns("nombre").HeaderText = "Nombre"
        DataGridView1.Columns("apellido").HeaderText = "Apellido"
        DataGridView1.Columns("expedientedelegado").HeaderText = "Delegado"
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conectar()
        mostrardatos()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmdInsertar_Click(sender As Object, e As EventArgs) Handles cmdInsertar.Click
        Try
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "insert into Alumno(expediente, nombre, apellido,expedientedelegado) values('" & txtExpediente.Text & "','" & txtNombre.Text & "','" & txtApellido.Text & "','" & txtDelegado.Text & "')"
            cmd.ExecuteNonQuery()
            MessageBox.Show("datos guardados")
            mostrardatos()

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub cmdActualizar_Click(sender As Object, e As EventArgs) Handles cmdActualizar.Click
        Try
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "Update Alumno set expediente = '" & txtExpediente.Text & "',nombre = '" & txtNombre.Text & "',apellido = '" & txtApellido.Text & "',expedientedelegado = '" & txtDelegado.Text & "' where expediente = '" & txtExpediente.Text & "' "
            cmd.ExecuteNonQuery()
            MessageBox.Show("datos guardados")
            mostrardatos()

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub



    Private Sub cmdLimpiar_Click(sender As Object, e As EventArgs) Handles cmdLimpiar.Click
        limpiar()
    End Sub
    Sub limpiar()
        txtExpediente.Clear()
        txtNombre.Clear()
        txtApellido.Clear()
        txtDelegado.Clear()
    End Sub

    Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

    Private Sub cmdBorrar_Click(sender As Object, e As EventArgs) Handles cmdBorrar.Click
        Dim cmd As New SqlCommand
        cmd.Connection = con
        cmd.CommandText = "delete from Alumno where expediente = '" & txtExpediente.Text & "'"
        cmd.ExecuteNonQuery()
        MessageBox.Show("Datos eliminados")
        mostrardatos()
    End Sub

End Class
