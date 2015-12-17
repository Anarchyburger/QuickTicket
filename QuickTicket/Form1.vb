Imports System.Net.Mail

Public Class Form1
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Me.TopMost = True
        Else
            Me.TopMost = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim mail As New MailMessage()

        mail.From = New MailAddress("nschneider@mhgi.net")
        mail.[To].Add("ithelpdesk@mhgi.net")

        TextBox1.Text = mail.Subject
        mail.Body = RichTextBox1.Text + Environment.NewLine + "#assign to Nate Schneider #set Store Number=" + ComboBox1.SelectedValue

        Dim smtp As New SmtpClient("email.mhgi.net")

        Try
            smtp.Send(mail)
            MsgBox("Your Email has been sent sucessfully - Thank You")
        Catch exc As Exception
            MsgBox("Send failure: " & exc.ToString())
        End Try
    End Sub
End Class
