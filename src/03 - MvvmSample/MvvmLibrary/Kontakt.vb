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

Public Class Kontakt2
    Inherits BindableBase

    Private myLastname As String

    Public Property Lastname As String
        Get
            Return myLastname
        End Get
        Set(value As String)
            MyBase.SetProperty(myLastname, value)
        End Set
    End Property

End Class

Public Class Kontakt
    Implements INotifyPropertyChanged

    Private myLastname As String
    Private myFirstname As String

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Property Lastname As String
        Get
            Return myLastname
        End Get
        Set(value As String)
            If Not Object.Equals(myLastname, value) Then
                RaiseEvent PropertyChanged(Me,
                            New PropertyChangedEventArgs(NameOf(Lastname)))
            End If
        End Set
    End Property



End Class
