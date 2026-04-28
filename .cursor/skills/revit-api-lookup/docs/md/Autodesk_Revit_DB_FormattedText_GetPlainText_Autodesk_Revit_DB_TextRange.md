---
kind: method
id: M:Autodesk.Revit.DB.FormattedText.GetPlainText(Autodesk.Revit.DB.TextRange)
source: html/3a6f5412-1efd-c4c0-b35b-621c9a29a1a5.htm
---
# Autodesk.Revit.DB.FormattedText.GetPlainText Method

Returns a substring of the text in a plain text form. The start and end of the substring is identified
 by a given TextRange .

## Syntax (C#)
```csharp
public string GetPlainText(
	TextRange textRange
)
```

## Parameters
- **textRange** (`Autodesk.Revit.DB.TextRange`) - The given TextRange .

## Returns
The substring of the text in a plain text form.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This start index of this text range is not within the text range identifying the entire text.
 -or-
 The end of this text range is not within the text range identifying the entire text.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

