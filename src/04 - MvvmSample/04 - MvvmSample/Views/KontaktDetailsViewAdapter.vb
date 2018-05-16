Imports MvvmLibrary

Public Class KontaktDetailsViewAdapter
    Implements IModalDialog

    Public Async Function ShowDialogAsync(viewModel As BindableBase) As Task Implements IModalDialog.ShowDialogAsync
        'We have to find out, which View we need to display based on the type of the passed ViewModel.
        Dim requestedContent As Page = Nothing
        'So, if method got passed a KontaktViewModel...
        If GetType(KontaktViewModel).IsAssignableFrom(viewModel.GetType) Then
            '...then this means we need to show the related KontaktDetailsView.
            requestedContent = New KontaktDetailsView
        End If

        Dim dialog = New ContentDialog() With {
            .Width = 700,
            .Title = "Titel",
            .Content = requestedContent
        }

        dialog.PrimaryButtonText = "OK"
        dialog.SecondaryButtonText = "Abbrechen"
        dialog.IsPrimaryButtonEnabled = True
        dialog.IsSecondaryButtonEnabled = True
        AddHandler dialog.PrimaryButtonClick,
            Sub()

            End Sub

        Dim result = Await dialog.ShowAsync()

    End Function
End Class
