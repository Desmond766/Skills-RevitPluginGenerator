---
kind: method
id: M:Autodesk.Revit.DB.FormattedText.GetListType(Autodesk.Revit.DB.TextRange)
source: html/36f7629b-c347-20c8-eb28-925ae4392d87.htm
---
# Autodesk.Revit.DB.FormattedText.GetListType Method

Returns the ListType of a paragraph.

## Syntax (C#)
```csharp
public ListType GetListType(
	TextRange textRange
)
```

## Parameters
- **textRange** (`Autodesk.Revit.DB.TextRange`) - The given text range.

## Returns
The ListType of the paragraph.

## Remarks
This function returns the list type of all paragraphs contained in the given range.
 Returns None if the paragraph is not in a list.
 Returns Mixed if the list types don't match between the paragraphs.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This text range is empty.
 -or-
 This start index of this text range is not within the text range identifying the entire text.
 -or-
 The end of this text range is not within the text range identifying the entire text.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

