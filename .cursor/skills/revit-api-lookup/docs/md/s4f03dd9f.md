---
kind: method
id: M:Autodesk.Revit.DB.FormattedText.SetUnderlineStatus(Autodesk.Revit.DB.TextRange,System.Boolean)
source: html/d5f9ca3c-4631-ad4a-5a40-b7103611e254.htm
---
# Autodesk.Revit.DB.FormattedText.SetUnderlineStatus Method

Sets the characters in a given text range to be underlined or not underlined.

## Syntax (C#)
```csharp
public void SetUnderlineStatus(
	TextRange textRange,
	bool isUnderlined
)
```

## Parameters
- **textRange** (`Autodesk.Revit.DB.TextRange`) - The given text range.
- **isUnderlined** (`System.Boolean`) - The desired underline status of characters in the given text range.
 True to set underlined, false to set not underlined.

## Remarks
Bullets, numbers, or letters of a list can not be underlined.
The given text range should not be empty.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This text range is empty.
 -or-
 This start index of this text range is not within the text range identifying the entire text.
 -or-
 The end of this text range is not within the text range identifying the entire text.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

