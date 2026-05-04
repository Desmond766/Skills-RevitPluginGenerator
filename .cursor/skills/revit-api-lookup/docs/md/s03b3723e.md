---
kind: method
id: M:Autodesk.Revit.DB.FormattedText.GetBoldStatus(Autodesk.Revit.DB.TextRange)
source: html/654707e3-5575-a8a5-8eaf-e83425f5c50d.htm
---
# Autodesk.Revit.DB.FormattedText.GetBoldStatus Method

Returns whether All , None or a Mixed set of characters in a given text range are bold.

## Syntax (C#)
```csharp
public FormatStatus GetBoldStatus(
	TextRange textRange
)
```

## Parameters
- **textRange** (`Autodesk.Revit.DB.TextRange`) - The given text range.

## Returns
The format status of bold on characters FormatStatus .

## Remarks
This function only returns All or None if the text contains one character.
 The given text range should not be empty.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This text range is empty.
 -or-
 This start index of this text range is not within the text range identifying the entire text.
 -or-
 The end of this text range is not within the text range identifying the entire text.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

