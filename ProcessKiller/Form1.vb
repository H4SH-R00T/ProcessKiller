

Public Class Form1
    Dim key As Integer
    Public Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Int32) As Int16

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Timer1.Start()
        Button1.Enabled = False
        TextBox1.Enabled = False
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim h1, h2, h3 As Boolean
        h1 = GetAsyncKeyState(Keys.LControlKey)
        h2 = GetAsyncKeyState(Keys.LShiftKey)
        h3 = GetAsyncKeyState(Keys.K)
        If h1 And h2 And h3 Then    ' Combination CTRL + SHIFT + K
            For Each prog As Process In Process.GetProcesses
                If prog.ProcessName.ToLower.Contains(TextBox1.Text) Then
                    Try
                        prog.Kill()
                    Catch ex As Exception

                    End Try
                End If
            Next
        End If
    End Sub
End Class
