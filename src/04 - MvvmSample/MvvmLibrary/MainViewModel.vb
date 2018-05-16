Imports System.Collections.ObjectModel

Public Class MainViewModel
    Inherits BindableBase

    Private myKontakte As ObservableCollection(Of KontaktViewModel)
    Private myAddCommand As RelayCommand

    Public Sub New()
        myAddCommand = New RelayCommand(
            Async Sub(value As Object)
                Await ModalDialogAdapter.ShowDialogAsync(New KontaktViewModel)
            End Sub)
    End Sub

    Public Property Kontakte As ObservableCollection(Of KontaktViewModel)
        Get
            Return myKontakte
        End Get
        Set(value As ObservableCollection(Of KontaktViewModel))
            SetProperty(myKontakte, value)
        End Set
    End Property

    Public Property AddCommand As RelayCommand
        Get
            Return myAddCommand
        End Get
        Set(value As RelayCommand)
            SetProperty(myAddCommand, value)
        End Set
    End Property

    Public Function DemoKontakte() As ObservableCollection(Of KontaktViewModel)

        Dim retValue = New ObservableCollection(Of KontaktViewModel)
        retValue.Add(New KontaktViewModel With
                     {.Lastname = "Ardelean", .Firstname = "Adriana",
                      .Address = "Bremer Str. 4", .Zip = "59555", .City = "Lippstadt"})
        retValue.Add(New KontaktViewModel With
                     {.Lastname = "Mustermann", .Firstname = "Peter",
                      .Address = "Bremer Str. 14", .Zip = "59557", .City = "Hamburg"})
        retValue.Add(New KontaktViewModel With
                     {.Lastname = "Loeffelmann", .Firstname = "Klaus",
                      .Address = "Bremer Str. 4", .Zip = "59555", .City = "Lippstadt"})
        Return retValue
    End Function

    Public Property ModalDialogAdapter As IModalDialog

End Class
