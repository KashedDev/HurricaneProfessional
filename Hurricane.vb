Imports System.Net.Mail
Imports System.Windows.Forms
Imports System.Threading
Public Class Hurricane
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "smtp.gmail.com (TLS)" Then
            TextBox3.Text = "smtp.gmail.com"
            TextBox4.Text = "587"
        End If
        If ComboBox1.Text = "smtp.gmail.com (SSL)" Then
            TextBox3.Text = "smtp.gmail.com"
            TextBox4.Text = "465"
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox("Information about using of SMTP-Server" & vbNewLine & "[1] Google only allow 80-90 Emails per 1-5 Minutes, please make sure you use a own or other server for mass-spamming.")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MsgBox("We don't steal any password! This program is open-source on github! Don't Worry! Be Happy!")
    End Sub



    Private Sub LinkLabel1_LinkClicked(sender As Object, e As Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Clipboard.SetText("bc1q9yrgmzvcsvaj5wn99xtqdvk7607elqyg7g5336")
        MsgBox("Successfully copied to Clipboard!")
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Clipboard.SetText("Kashed#1247")
        MsgBox("Successfully copied to Clipboard!")
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Clipboard.SetText("https://discord.gg/6RZXaYR9ma")
        MsgBox("Successfully copied to Clipboard!")
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Clipboard.SetText("@UkrainAnonym")
        MsgBox("Successfully copied to Clipboard!")
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            TextBox2.PasswordChar = ""
        Else
            TextBox2.PasswordChar = "*"
        End If
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        Label17.Text = TrackBar1.Value.ToString
    End Sub

    Private Sub Hurricane_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckBox3.Checked = True

    End Sub

    Private Async Sub SendEmails()
        Dim MM As New MailMessage()
        Dim SMTP As New SmtpClient(TextBox3.Text)
        Try
            MM.From = New MailAddress(TextBox1.Text)
            MM.To.Add(TextBox5.Text)
            MM.Subject = (TextBox6.Text)
            MM.Body = (TextBox7.Text)
            If CheckBox4.Checked = True Then
                MM.IsBodyHtml = True
            Else
                MM.IsBodyHtml = False
            End If
            SMTP.Port = TextBox4.Text
            SMTP.Credentials = New Net.NetworkCredential(TextBox1.Text, TextBox2.Text)
            If CheckBox1.Checked = True Then
                SMTP.EnableSsl = True
            Else
                SMTP.EnableSsl = False
            End If
            If Not TextBox8.Text = "" Then
                Dim a As New Attachment(OpenFileDialog1.FileName)
                MM.Attachments.Add(a)
            End If
            Await SMTP.SendMailAsync(MM)
            Label27.Text = Label27.Text + 1
            ListBox1.Items.Add("Hurricane> Mails sent: " & Label27.Text)
        Catch ex As Exception
            ListBox1.Items.Add("Hurricane> Failed sent E-Mail, maybe you get temporary banned.")
            Label29.Text = Label29.Text + 1
            TextBox9.AppendText(ex.ToString & Environment.NewLine)
        End Try
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = True Then
            Timer1.Start()

        Else
            Timer1.Stop()
        End If

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Dim r As New Random

        TextBox6.Text = "HURRICANE-" & r.Next(1, 999999999) & "-KASHED#1247-" & r.Next(1, 9999999) & "FLOODER"


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        OpenFileDialog1.Title = "Hurricane"
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        TextBox8.Text$ = OpenFileDialog1.FileName
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        SendEmails()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Timer2.Start()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Timer2.Stop()
    End Sub
End Class