---
kind: method
id: M:Autodesk.Revit.DB.FormattedText.SetAllCapsStatus(Autodesk.Revit.DB.TextRange,System.Boolean)
source: html/03a3a6c3-9195-25a1-abaa-641f00cbc930.htm
---
# Autodesk.Revit.DB.FormattedText.SetAllCapsStatus Method

Sets the characters in a given text range to be in all caps or not.

## Syntax (C#)
```csharp
public void SetAllCapsStatus(
	TextRange textRange,
	bool isAllCaps
)
```

## Parameters
- **textRange** (`Autodesk.Revit.DB.TextRange`) - The given text range.
- **isAllCaps** (`System.Boolean`) - The desired all caps status of characters in the given text range.
 True will render all characters in all caps.
 False will revert the characters back to their original mixed case.

## Remarks
Removing the all caps status will revert the characters back to their
 original case. It will not make them lower case.
The given text range should not be empty.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This text range is empty.
 -or-
 This start index of this text range is not within the text range identifying the entire text.
 -or-
 The end of this text range is not within the text range identifying the entire text.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

