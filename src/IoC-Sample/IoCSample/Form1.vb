Imports WinFormsApp

Public Class Form1
    Implements IReceiver

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim alleColorTextBoxen = (From control In Me.Controls
                                  Where GetType(ColorTextBox).
                                      IsAssignableFrom(control.GetType)).OfType(Of ColorTextBox)

        For Each item In alleColorTextBoxen
            item.Receiver = Me
        Next

    End Sub

    Public Sub Action(sender As ISender) Implements IReceiver.Action
        Dim nameDesSender As String = DirectCast(sender, ColorTextBox).Name
        ListBox1.Items.Add($"Die ColorTextBox {nameDesSender} hat ein 'T' verarbeitet.")
    End Sub

End Class
