---
kind: method
id: M:Autodesk.Revit.DB.FormattedText.GetAllCapsStatus(Autodesk.Revit.DB.TextRange)
source: html/0e9f9439-eb01-6844-992a-2128ffddedef.htm
---
# Autodesk.Revit.DB.FormattedText.GetAllCapsStatus Method

Returns whether All , None or a Mixed set of characters in a given text range are in all caps.

## Syntax (C#)
```csharp
public FormatStatus GetAllCapsStatus(
	TextRange textRange
)
```

## Parameters
- **textRange** (`Autodesk.Revit.DB.TextRange`) - The given text range.

## Returns
The format status of all caps on characters FormatStatus .

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

