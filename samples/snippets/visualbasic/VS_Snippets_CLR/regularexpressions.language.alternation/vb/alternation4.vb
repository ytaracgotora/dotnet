' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.Text.RegularExpressions

Module Example
    Public Sub Main()
        Dim pattern As String = "\b(?<n2>\d{2}-)?(?(n2)\d{7}|\d{3}-\d{2}-\d{4})\b"
        Dim input As String = "01-9999999 020-333333 777-88-9999"
        Console.WriteLine("Matches for {0}:", pattern)
        For Each match As Match In Regex.Matches(input, pattern)
            Console.WriteLine("   {0} at position {1}", match.Value, match.Index)
        Next
    End Sub
End Module
' </Snippet4>
