---
kind: method
id: M:Autodesk.Revit.DB.FormattedText.SetBoldStatus(Autodesk.Revit.DB.TextRange,System.Boolean)
source: html/fd0eab6d-0808-63ff-3cb0-a014f2adbbd7.htm
---
# Autodesk.Revit.DB.FormattedText.SetBoldStatus Method

Sets the characters in a given text range to be bold or not bold.

## Syntax (C#)
```csharp
public void SetBoldStatus(
	TextRange textRange,
	bool isBold
)
```

## Parameters
- **textRange** (`Autodesk.Revit.DB.TextRange`) - The given text range.
- **isBold** (`System.Boolean`) - The desired bold status of characters in the given text range.
 True to set bold, false to set not bold.

## Remarks
To make the numbers or letters in a list bold, apply the bold status to
 the carriage return character that ends the list paragraph.
The given text range should not be empty.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This text range is empty.
 -or-
 This start index of this text range is not within the text range identifying the entire text.
 -or-
 The end of this text range is not within the text range identifying the entire text.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

