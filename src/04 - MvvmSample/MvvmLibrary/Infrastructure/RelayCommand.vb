Imports System.Windows.Input

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

    Public Sub New(executeAction As Action(Of Object),
                   canExecuteFunc As Func(Of Object, Boolean))
        myExecuteAction = executeAction
        myCanExecuteFunc = canExecuteFunc
    End Sub

    Public Sub NotifyCanExecuteChanged()
        RaiseEvent CanExecuteChanged(Me, EventArgs.Empty)
    End Sub

    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged

    Public Sub Execute(parameter As Object) Implements ICommand.Execute
        myExecuteAction(parameter)
    End Sub

    Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
        Return myCanExecuteFunc(parameter)
    End Function
End Class


