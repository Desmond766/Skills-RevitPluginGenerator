---
kind: method
id: M:Autodesk.Revit.DB.FormattedText.SetSuperscriptStatus(Autodesk.Revit.DB.TextRange,System.Boolean)
source: html/357540c0-f99c-94da-f3f3-585308c6543f.htm
---
# Autodesk.Revit.DB.FormattedText.SetSuperscriptStatus Method

Sets the characters in a given text range to be superscript or not superscript.

## Syntax (C#)
```csharp
public void SetSuperscriptStatus(
	TextRange textRange,
	bool isSuperscript
)
```

## Parameters
- **textRange** (`Autodesk.Revit.DB.TextRange`) - The given text range.
- **isSuperscript** (`System.Boolean`) - The desired superscript status of characters in the given text range.
 True to set superscript, false to set not superscript.

## Remarks
Superscript and subscript are mutually exclusive.
 Applying the superscript status will automatically remove the subscript status.
The given text range should not be empty.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This text range is empty.
 -or-
 This start index of this text range is not within the text range identifying the entire text.
 -or-
 The end of this text range is not within the text range identifying the entire text.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

