---
kind: method
id: M:Autodesk.Revit.DB.FormattedText.GetItalicStatus(Autodesk.Revit.DB.TextRange)
source: html/a4df0e88-31d5-4e75-fb17-d68ad22bf89d.htm
---
# Autodesk.Revit.DB.FormattedText.GetItalicStatus Method

Returns whether All , None or a Mixed set of characters in a given text range are italic.

## Syntax (C#)
```csharp
public FormatStatus GetItalicStatus(
	TextRange textRange
)
```

## Parameters
- **textRange** (`Autodesk.Revit.DB.TextRange`) - The given text range.

## Returns
The format status of italic on characters FormatStatus .

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

