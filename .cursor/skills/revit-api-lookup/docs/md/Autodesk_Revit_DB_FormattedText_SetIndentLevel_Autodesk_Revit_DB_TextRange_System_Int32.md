---
kind: method
id: M:Autodesk.Revit.DB.FormattedText.SetIndentLevel(Autodesk.Revit.DB.TextRange,System.Int32)
source: html/a2e6561d-da40-b701-967f-aadbe6b153f5.htm
---
# Autodesk.Revit.DB.FormattedText.SetIndentLevel Method

Sets the number of tab stops that the paragraph should be indented.

## Syntax (C#)
```csharp
public void SetIndentLevel(
	TextRange textRange,
	int level
)
```

## Parameters
- **textRange** (`Autodesk.Revit.DB.TextRange`) - The given text range.
- **level** (`System.Int32`) - The level set on the paragraph.

## Remarks
The indent level is the number of tab stops by which each paragraph will be indented.
Note that adjoining paragraphs that have the same indent level
 and have a list type other than None 
 are considered part of a numbered list.
 Changing the indent level of paragraphs that are bulleted or numbered
 (i.e. paragraphs that have a list type other than None )
 may cause other changes to the document as the changed paragraphs
 may join or leave a list. Which will cause the other paragraphs in those lists
 to be renumbered.
This function applies the nesting level to all paragraphs contained in the given range.
 The level set on the paragraph cannot be negative and cannot be larger than the value returned by
 GetMaximumIndentLevel () () () .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This start index of this text range is not within the text range identifying the entire text.
 -or-
 The end of this text range is not within the text range identifying the entire text.
 -or-
 This level is too large to set on a paragraph.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for level is negative.

