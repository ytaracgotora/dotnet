' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Threading
Imports System.Threading.Tasks

Module Example
    Public Sub Main()
        Dim parent = Task.Factory.StartNew(Sub()
                                               Console.WriteLine("Parent task executing")
                                               Dim child = Task.Factory.StartNew(Sub()
                                                                                     Console.WriteLine("Attached child starting.")
                                                                                     Thread.SpinWait(5000000)
                                                                                     Console.WriteLine("Attached child completing.")
                                                                                 End Sub, TaskCreationOptions.AttachedToParent)
                                           End Sub)
        parent.Wait()
        Console.WriteLine("Parent has completed.")
    End Sub
End Module
' The example displays the following output:
'       Parent task executing.
'       Attached child starting.
'       Attached child completing.
'       Parent has completed.
' </Snippet2>

