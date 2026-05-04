---
kind: method
id: M:Autodesk.Revit.DB.FormattedText.GetListStartNumber(Autodesk.Revit.DB.TextRange)
source: html/52b2530b-0a0a-1873-e38d-726680a09f06.htm
---
# Autodesk.Revit.DB.FormattedText.GetListStartNumber Method

Returns the list start number of the paragraphs in a given text range.

## Syntax (C#)
```csharp
public int GetListStartNumber(
	TextRange textRange
)
```

## Parameters
- **textRange** (`Autodesk.Revit.DB.TextRange`) - The given text range.

## Returns
The list start number of the text range.

## Remarks
Returns -1 if there is a mix of list start values in the range or
 if there are paragraphs in different lists or sub-lists in the range or
 if there are paragraphs of type None or Bullet in the range.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This start index of this text range is not within the text range identifying the entire text.
 -or-
 The end of this text range is not within the text range identifying the entire text.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

