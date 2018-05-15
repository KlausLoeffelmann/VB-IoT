Imports System.Collections.Specialized
Imports System.Threading
Imports Windows.Devices.Gpio

Public Class DHT11

    Private myInputDriveMode As GpioPinDriveMode
    Private myInputPin As GpioPin
    Private myOutputPin As GpioPin
    Private myChangeReader As GpioChangeReader

    Sub New(inputPin As GpioPin, outputPin As GpioPin)

        inputPin.SetDriveMode(myInputDriveMode)

        myChangeReader = New GpioChangeReader(inputPin)

        outputPin.Write(GpioPinValue.High)
        outputPin.SetDriveMode(GpioPinDriveMode.Output)

        myInputPin = inputPin
        myOutputPin = outputPin
    End Sub

    Public Async Function Sample() As Task(Of (hRes As GpioResult, reading As DhtSensorReading))
        Await Task.Delay(0)
        'Return (GpioResult.OK, Nothing)

        Dim qpf = Stopwatch.StartNew

        Dim inputDriveMode = If(myInputPin.IsDriveModeSupported(GpioPinDriveMode.InputPullUp),
                                                          GpioPinDriveMode.InputPullUp,
                                                          GpioPinDriveMode.Input)

        Dim reading = New DhtSensorReading()

        Dim oneThreshold = New TimeSpan(1100L * 10000000L \ 1000000L)
        Dim startTime = qpf.ElapsedMilliseconds
        Dim deadline = startTime + 18

        myInputPin.Write(GpioPinValue.Low)
        myInputPin.SetDriveMode(GpioPinDriveMode.Output)

        'Wait 18 ms.
        Do While qpf.ElapsedMilliseconds < deadline
        Loop

        myInputPin.Write(GpioPinValue.High)

        myInputPin.SetDriveMode(inputDriveMode)
        Dim previousValue = myInputPin.Read

        Dim stime = qpf.Elapsed
        Do
            If qpf.Elapsed > stime + oneThreshold Then
                If Debugger.IsAttached Then
                    Debugger.Break()
                End If
                Return (GpioResult.Error, Nothing)
            End If

            Dim value = myInputPin.Read
            If (value <> previousValue) Then
                If value = GpioPinValue.High Then
                    Exit Do
                End If
            End If

            previousValue = value
        Loop

        Return (GpioResult.OK, Nothing)

    End Function

    Public Async Function SampleInterrupts() As Task(Of (hRes As GpioResult, reading As DhtSensorReading))

        Dim qpf = Stopwatch.StartNew

        Dim ctAfter100ms = New CancellationTokenSource(1000)
        Dim ctToken = ctAfter100ms.Token


        Try
            Dim retVal = SendInitialPulse()

            Dim inputDriveMode = If(myInputPin.IsDriveModeSupported(GpioPinDriveMode.InputPullUp),
                               GpioPinDriveMode.InputPullUp,
                               GpioPinDriveMode.Input)

            myInputPin.SetDriveMode(myInputDriveMode)

            myChangeReader.Polarity = GpioChangePolarity.Falling
            myChangeReader.Clear()
            myChangeReader.Start()

            If Not retVal = GpioResult.OK Then
                Return (retVal, Nothing)
            End If

            Try
                'We wait for 43 falling edges to show up, but not more than 100 ms.
                Await myChangeReader.WaitForItemsAsync(43).AsTask(ctToken)
            Catch ex As TaskCanceledException
                Return (GpioResult.Error, Nothing)
            End Try

            'Discard the first two falling edges.
            myChangeReader.GetNextItem()
            myChangeReader.GetNextItem()

            Dim oneThreshold = New TimeSpan(110L * 10000000L \ 1000000L)
            Dim first = myChangeReader.GetNextItem.RelativeTime

            Dim reading = New DhtSensorReading()

            For i = 0 To 39
                Dim second = myChangeReader.GetNextItem.RelativeTime
                Dim pulseWidth = second.Duration - first.Duration
                If pulseWidth.Duration > oneThreshold.Duration Then
                    reading.Bits(39 - i) = True
                End If

                first = second
            Next

            If reading.IsValid Then
                Return (GpioResult.OK, reading)
            Else
                Return (GpioResult.Error, reading)
            End If
        Catch ex2 As Exception
            Return (GpioResult.Error, Nothing)
        Finally
            myChangeReader.Stop()
        End Try

    End Function

    Public Function SendInitialPulse() As GpioResult

        Dim qpf = Stopwatch.StartNew
        Dim startTime = qpf.ElapsedMilliseconds
        Dim deadline = startTime + 18

        myOutputPin.Write(GpioPinValue.High)
        myOutputPin.SetDriveMode(GpioPinDriveMode.Output)

        'Wait 18 ms.
        Do While qpf.ElapsedMilliseconds < deadline
        Loop

        myOutputPin.Write(GpioPinValue.Low)
        Dim endTime = qpf.ElapsedMilliseconds
        If (endTime - startTime) > 30 Then
            Debug.Print((endTime - startTime).ToString)
            Return GpioResult.ErrorRetry
        End If

        Return GpioResult.OK

    End Function

End Class

Public Class DhtSensorReading

    Private myBitSet As BitArray

    Sub New()
        myBitSet = New BitArray(40)
    End Sub

    Private Function ToUnsignedLong() As ULong
        Dim tmpArray = New ULong(0) {}
        myBitSet.CopyTo(tmpArray, 0)
        Return tmpArray(0)
    End Function

    Public ReadOnly Property Bits As BitArray
        Get
            Return myBitSet
        End Get
    End Property

    Public ReadOnly Property IsValid As Boolean
        Get
            Dim ulValue = ToUnsignedLong()

            Dim checkSum = ((ulValue >> 32UL) And &HFFUL) +
                ((ulValue >> 24UL) And &HFFUL) +
                ((ulValue >> 16UL) And &HFFUL) +
                ((ulValue >> 8UL) And &HFFUL)

            Return (checkSum And &HFFUL) = (ulValue And &HFFUL)
        End Get
    End Property

    Public ReadOnly Property Humidity As Double
        Get
            Dim value = ToUnsignedLong()
            Return ((value >> 24UL) And &HFFFFUL) * 0.1
        End Get
    End Property

    Public ReadOnly Property Temperature As Double
        Get
            Dim value = ToUnsignedLong()
            Dim temp = ((value >> 8) And &H7FFFUL) * 0.1
            If CBool((value >> 8UL) And &H8000UL) Then
                temp = -temp
            End If
            Return temp
        End Get
    End Property

End Class

Public Enum GpioResult
    OK = 0
    [Error] = 1
    ErrorRetry = 2
    Error_Timeout = 3
End Enum
