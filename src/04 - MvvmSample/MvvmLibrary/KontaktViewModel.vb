Imports System.ComponentModel

Public Class KontaktViewModel
    Inherits BindableBase

    Private myLastname As String
    Private myFirstname As String
    Private myAddress As String
    Private myZip As String
    Private myCity As String
    Private myDateOfBirth As Date?
    Private myIDConact As Guid

    Public Sub New()
        IDContact = Guid.NewGuid()
    End Sub

    Public Property IDContact As Guid
        Get
            Return myIDConact
        End Get
        Set(value As Guid)
            SetProperty(myIDConact, value)
        End Set
    End Property

    Public Property Lastname As String
        Get
            Return myLastname
        End Get
        Set(value As String)
            MyBase.SetProperty(myLastname, value)
        End Set
    End Property

    Public Property Firstname As String
        Get
            Return myFirstname
        End Get
        Set(value As String)
            SetProperty(myFirstname, value)
        End Set
    End Property

    Public Property Address As String
        Get
            Return myAddress
        End Get
        Set(value As String)
            SetProperty(myAddress, value)
        End Set
    End Property

    Public Property Zip As String
        Get
            Return myZip
        End Get
        Set(value As String)
            SetProperty(myZip, value)
        End Set
    End Property

    Public Property City As String
        Get
            Return myCity
        End Get
        Set(value As String)
            SetProperty(myCity, value)
        End Set
    End Property

    Public Property DateOfBirth As Date?
        Get
            Return myDateOfBirth
        End Get
        Set(value As Date?)
            SetProperty(myDateOfBirth, value)
        End Set
    End Property

End Class

