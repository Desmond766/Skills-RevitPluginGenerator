---
kind: method
id: M:Autodesk.Revit.DB.FormattedText.GetSubscriptStatus(Autodesk.Revit.DB.TextRange)
source: html/50803bb1-2ba6-63c5-0ddf-a0bf0f40c58c.htm
---
# Autodesk.Revit.DB.FormattedText.GetSubscriptStatus Method

Returns whether All , None or a Mixed set of characters in a given text range are subscripted.

## Syntax (C#)
```csharp
public FormatStatus GetSubscriptStatus(
	TextRange textRange
)
```

## Parameters
- **textRange** (`Autodesk.Revit.DB.TextRange`) - The given text range.

## Returns
The format status of subscript on characters FormatStatus .

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

