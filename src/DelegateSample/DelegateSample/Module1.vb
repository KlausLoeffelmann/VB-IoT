Module Module1

    Public Delegate Function BooleanResultDelegate() As Boolean

    Sub Main()
        'We need an array of delegates to store the pointers to our two functions.
        Dim meineAdresseAufIsAlwaysTrue(1) As BooleanResultDelegate

        meineAdresseAufIsAlwaysTrue(0) = AddressOf IsAlwayTrue
        meineAdresseAufIsAlwaysTrue(1) = AddressOf IsAlwaysFalse

        Dim val1 = 10
        Dim val2 = 10

        Dim index = Math.Abs(Math.Sign(val1 - val2))

        Console.WriteLine($"Die Aussage {val1} und {val2} sind gleich ist {meineAdresseAufIsAlwaysTrue(index).Invoke()}")
        Console.ReadLine()
    End Sub

    Public Function IsAlwayTrue() As Boolean
        Return True
    End Function

    Public Function IsAlwaysFalse() As Boolean
        Return False
    End Function

End Module
