' The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

Imports Windows.Devices.Gpio
Imports Windows.UI
''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Public NotInheritable Class MainPage
    Inherits Page

    Private Const LED_PIN = 5

    Private mypin As GpioPin
    Private myPinValue As GpioPinValue
    Private myRedBrush As New SolidColorBrush(Colors.Red)
    Private myGrayBrush As New SolidColorBrush(Colors.LightGray)

    Private myTimer As New DispatcherTimer() With
        {.Interval = New TimeSpan(0, 0, 1)}

    Private Async Sub MainPage_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Await InitGPIO()

        ' Add any initialization after the InitializeComponent() call.
        AddHandler myTimer.Tick,
            (Sub(timerSender, eventArgs)
                 If myPinValue = GpioPinValue.High Then
                     myPinValue = GpioPinValue.Low
                     LED.Fill = myRedBrush
                 Else
                     myPinValue = GpioPinValue.High
                     LED.Fill = myGrayBrush
                 End If
                 mypin.Write(myPinValue)
             End Sub)

        myTimer.Start()

    End Sub

    Private Async Function InitGPIO() As Task

        Dim gpio = Await GpioController.GetDefaultAsync

        If gpio Is Nothing Then
            mypin = Nothing
            'English
            GpioStatusText.Text = "No GPIO-Controller could be found on this device!"
            'German
            GpioStatusText.Text = "Auf diesem Gerät konnte kein GPIO-Controller gefunden werden!"
            Return
        End If

        mypin = gpio.OpenPin(LED_PIN)
        myPinValue = GpioPinValue.High
        mypin.Write(myPinValue)
        mypin.SetDriveMode(GpioPinDriveMode.Output)

        'English
        GpioStatusText.Text = "GPIO-Controller found and initialized!"
        'German
        GpioStatusText.Text = "GPIO-Controller gefunden und erfolgreich initialisiert!"
    End Function

End Class
