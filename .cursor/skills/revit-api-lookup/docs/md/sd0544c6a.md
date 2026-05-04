---
kind: method
id: M:Autodesk.Revit.DB.FormattedText.SetItalicStatus(Autodesk.Revit.DB.TextRange,System.Boolean)
source: html/310407e6-1244-24cb-c033-e9620068e62e.htm
---
# Autodesk.Revit.DB.FormattedText.SetItalicStatus Method

Sets the characters in a given text range to be italic or not italic.

## Syntax (C#)
```csharp
public void SetItalicStatus(
	TextRange textRange,
	bool isItalic
)
```

## Parameters
- **textRange** (`Autodesk.Revit.DB.TextRange`) - The given text range.
- **isItalic** (`System.Boolean`) - The desired italic status of characters in the given text range.
 True to set italic, false to set not italic.

## Remarks
To make the numbers or letters in a list italic, apply the italic status to
 the carriage return character that ends the list paragraph.
The given text range should not be empty.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This text range is empty.
 -or-
 This start index of this text range is not within the text range identifying the entire text.
 -or-
 The end of this text range is not within the text range identifying the entire text.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

