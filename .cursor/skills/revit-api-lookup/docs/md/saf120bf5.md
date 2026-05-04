---
kind: method
id: M:Autodesk.Revit.DB.FormattedText.SetSubscriptStatus(Autodesk.Revit.DB.TextRange,System.Boolean)
source: html/bc2efdbe-7706-0e4d-82ce-39ab7d039c7c.htm
---
# Autodesk.Revit.DB.FormattedText.SetSubscriptStatus Method

Sets the characters in a given text range to be subscript or not subscript.

## Syntax (C#)
```csharp
public void SetSubscriptStatus(
	TextRange textRange,
	bool isSubscript
)
```

## Parameters
- **textRange** (`Autodesk.Revit.DB.TextRange`) - The given text range.
- **isSubscript** (`System.Boolean`) - The desired subscript status of characters in the given text range.
 True to set subscript, false to set not subscript.

## Remarks
Superscript and subscript are mutually exclusive.
 Applying the subscript status will automatically remove the superscript status.
The given text range should not be empty.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This text range is empty.
 -or-
 This start index of this text range is not within the text range identifying the entire text.
 -or-
 The end of this text range is not within the text range identifying the entire text.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

