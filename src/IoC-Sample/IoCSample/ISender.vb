'Binding to the ColorTextBox, to make it a concrete Sender,
'through this abstract Interface...
Public Interface ISender
    '...which communicates with the Receiver.
    Property Receiver As IReceiver
End Interface
