'Binding to the Form, making it an concrete Receiver 
'through an abstract Interface...
Public Interface IReceiver
    'to be called from an ISender.
    Sub Action(sender As ISender)
End Interface
