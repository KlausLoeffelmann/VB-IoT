﻿' The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

Imports MvvmLibrary
''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Public NotInheritable Class MainPage
    Inherits Page

    Private Sub TestButton_Click(sender As Object, e As RoutedEventArgs) Handles TestButton.Click
        Dim k As New Kontakt
        k.Lastname = "Ardelean"
    End Sub
End Class
