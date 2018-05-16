Public Class ColorTextBox
    Inherits TextBox
    Implements ISender

    Private myPreviousBackgroundColor As Color

    Protected Overrides Sub OnGotFocus(e As EventArgs)
        MyBase.OnGotFocus(e)
        myPreviousBackgroundColor = BackColor
        BackColor = FocusColor
    End Sub

    Protected Overrides Sub OnLostFocus(e As EventArgs)
        MyBase.OnLostFocus(e)
        BackColor = myPreviousBackgroundColor
    End Sub

    Protected Overrides Sub OnKeyPress(e As KeyPressEventArgs)
        MyBase.OnKeyPress(e)
        If e.KeyChar = "t"c Then
            Receiver.Action(Me)
        End If
    End Sub

    Public Property FocusColor As Color = Color.Yellow

    Public Property Receiver As IReceiver Implements ISender.Receiver

End Class
