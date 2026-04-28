---
kind: method
id: M:Autodesk.Revit.DB.FormattedText.SetPlainText(System.String)
source: html/b2efd1c2-7e1f-2def-f72b-a22066a8b415.htm
---
# Autodesk.Revit.DB.FormattedText.SetPlainText Method

Sets the entire text with the given text in a plain text form.

## Syntax (C#)
```csharp
public void SetPlainText(
	string plainText
)
```

## Parameters
- **plainText** (`System.String`) - The given text in a plain text form.

## Remarks
Any individual formatting present before will be lost after applying this function
 and the text will have uniform formatting.
 If the text does not end with a carriage return character ('\r') one will be added.
 An empty string is allowed.
 The given text should have no more than 30,000 characters, not counting a terminating carriage return character ('\r').
 Newline characters ('\n') are not allowed.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - plainText (excluding a carriage return character ('\r') at the end) has more than 30,000 characters.
 -or-
 plainText contains invalid characters such as a newline character.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

