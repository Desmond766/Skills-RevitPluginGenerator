---
kind: method
id: M:Autodesk.Revit.DB.FormattedText.GetUnderlineStatus(Autodesk.Revit.DB.TextRange)
source: html/0ece8fda-443b-7247-9b1c-4eb493850344.htm
---
# Autodesk.Revit.DB.FormattedText.GetUnderlineStatus Method

Returns whether All , None or a Mixed set of characters in a given text range are underlined.

## Syntax (C#)
```csharp
public FormatStatus GetUnderlineStatus(
	TextRange textRange
)
```

## Parameters
- **textRange** (`Autodesk.Revit.DB.TextRange`) - The given text range.

## Returns
The format status of underline on characters FormatStatus .

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

