---
kind: method
id: M:Autodesk.Revit.DB.FormattedText.GetSuperscriptStatus(Autodesk.Revit.DB.TextRange)
source: html/3ad2a7db-b1c9-ba0e-661e-bb4117e3a538.htm
---
# Autodesk.Revit.DB.FormattedText.GetSuperscriptStatus Method

Returns whether All , None or a Mixed set of characters in a given text range are superscripted.

## Syntax (C#)
```csharp
public FormatStatus GetSuperscriptStatus(
	TextRange textRange
)
```

## Parameters
- **textRange** (`Autodesk.Revit.DB.TextRange`) - The given text range.

## Returns
The format status of superscript on characters FormatStatus .

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

