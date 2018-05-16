Imports System.ComponentModel
Imports System.Runtime.CompilerServices

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


