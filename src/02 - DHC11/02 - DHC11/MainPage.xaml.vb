' The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

Imports Windows.Devices.Gpio
''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Public NotInheritable Class MainPage
    Inherits Page

    Private Const DHT_INPUT_PIN = 4
    Private Const DHT_OUTPUT_PIN = 4

    Private myOutputPin As GpioPin
    Private myInputPin As GpioPin
    Private mypin As GpioPin

    Private Async Sub PerformOperation_Click(sender As Object, e As RoutedEventArgs) Handles PerformOperation.Click
        Dim gpio = Await GpioController.GetDefaultAsync
        Try
            If gpio Is Nothing Then
                mypin = Nothing
                'English
                GpioStatusText.Text = "No GPIO-Controller could be found on this device!"
                'German
                GpioStatusText.Text = "Auf diesem Gerät konnte kein GPIO-Controller gefunden werden!"
                Return
            End If

            myInputPin = gpio.OpenPin(DHT_INPUT_PIN)
            myOutputPin = gpio.OpenPin(DHT_OUTPUT_PIN)

            Dim dht = New DHT11(myInputPin, myInputPin)

            Dim retValue = Await dht.SampleInterrupts()
            If retValue.hRes = GpioResult.OK Then
                GpioStatusText.Text = "Data could be read."
            Else
                GpioStatusText.Text = "Reading data failed."
            End If

            Debug.Print(retValue.ToString)
        Catch ex As Exception
            If Debugger.IsAttached Then
                Debugger.Break()
            End If
        End Try
    End Sub
End Class
