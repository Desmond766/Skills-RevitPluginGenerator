---
kind: method
id: M:Autodesk.Revit.DB.FormattedText.SetSuperscriptStatus(System.Boolean)
source: html/9f4fc913-e71a-d57b-29ac-e1b8ea650737.htm
---
# Autodesk.Revit.DB.FormattedText.SetSuperscriptStatus Method

Sets the characters in the entire text to be superscript or not superscript.

## Syntax (C#)
```csharp
public void SetSuperscriptStatus(
	bool isSuperscript
)
```

## Parameters
- **isSuperscript** (`System.Boolean`) - The desired superscript status of characters in the entire text.
 True to set superscript, false to set not superscript.

## Remarks
If the characters are set to be superscript, they cannot be subscript.
 This sets the subscript status to false.

