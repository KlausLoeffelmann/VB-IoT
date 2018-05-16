Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports System.Windows.Input

Public Class BindableBase
    Implements INotifyPropertyChanged

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Function SetProperty(Of t)(ByRef backingField As t, value As t,
                                <CallerMemberNameAttribute> Optional PropertyName As String = Nothing) As Boolean
        If Not Object.Equals(backingField, value) Then
            backingField = value
            RaiseEvent PropertyChanged(Me,
                            New PropertyChangedEventArgs(PropertyName))
            Return True
        End If

        Return False
    End Function
End Class

Public Class RelayCommand
    Implements ICommand

    Private myExecuteAction As Action(Of Object)
    Private myCanExecuteFunc As Func(Of Object, Boolean)

    Public Sub New(executeAction As Action(Of Object))
        myExecuteAction = executeAction

        'Statement Lambda
        myCanExecuteFunc = Function(obj As Object) As Boolean
                               Return True
                           End Function

        'Expression Lambda: Nur ein EINZELNER Ausdruck.
        myCanExecuteFunc = Function(obj As Object) True


    End Sub

    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged

    Public Sub Execute(parameter As Object) Implements ICommand.Execute
        Throw New NotImplementedException()
    End Sub

    Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
        Throw New NotImplementedException()
    End Function
End Class


