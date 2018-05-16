Public Interface IModalDialog
    Function ShowDialogAsync(viewModel As BindableBase) As Task(Of ModalDialogResult)

End Interface

Public Enum ModalDialogResult
    OK
    Cancel
End Enum
