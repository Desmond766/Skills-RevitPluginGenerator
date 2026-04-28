---
kind: method
id: M:Autodesk.Revit.DB.FormattedText.GetIndentLevel(Autodesk.Revit.DB.TextRange)
source: html/2bb008be-f3b5-f0cd-bc1b-6879101ef84a.htm
---
# Autodesk.Revit.DB.FormattedText.GetIndentLevel Method

Returns the indent level of the paragraphs in the text range.

## Syntax (C#)
```csharp
public int GetIndentLevel(
	TextRange textRange
)
```

## Parameters
- **textRange** (`Autodesk.Revit.DB.TextRange`) - The given text range.

## Returns
The indentation level of the paragraphs in the range.

## Remarks
Returns -1 if the range contains multiple paragraphs with different indent levels.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This start index of this text range is not within the text range identifying the entire text.
 -or-
 The end of this text range is not within the text range identifying the entire text.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

