﻿' The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

Imports MvvmLibrary
''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Public NotInheritable Class MainPage
    Inherits Page

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Dim mainViewModel = New MainViewModel
        mainViewModel.ModalDialogAdapter = New KontaktDetailsViewAdapter
        mainViewModel.Kontakte = mainViewModel.DemoKontakte
        Me.DataContext = mainViewModel

    End Sub

    Private Async Sub Button_Click(sender As Object, e As RoutedEventArgs)

        Dim addPage = New KontaktDetailsView
        Math.Abs(-20)
        Dim dialog = New ContentDialog() With {
            .Width = 700,
            .Title = "Kontakt hinzufügen",
            .Content = addPage
        }

        dialog.PrimaryButtonText = "OK"
        dialog.SecondaryButtonText = "Abbrechen"
        dialog.IsPrimaryButtonEnabled = True
        dialog.IsSecondaryButtonEnabled = True
        AddHandler dialog.PrimaryButtonClick,
            Sub()

            End Sub

        Dim result = Await dialog.ShowAsync()
    End Sub
End Class
