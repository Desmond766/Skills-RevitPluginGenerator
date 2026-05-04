---
kind: method
id: M:Autodesk.Revit.DB.FormattedText.SetSubscriptStatus(System.Boolean)
source: html/a08a6223-938b-43cc-f78f-f5743378614b.htm
---
# Autodesk.Revit.DB.FormattedText.SetSubscriptStatus Method

Sets the characters in the entire text to be subscript or not subscript.

## Syntax (C#)
```csharp
public void SetSubscriptStatus(
	bool isSubscript
)
```

## Parameters
- **isSubscript** (`System.Boolean`) - The desired subscript status of characters in the entire text.
 True to set subscript, false to set not subscript.

## Remarks
If the characters are set to be subscript, they cannot be superscript.
 This sets the superscript status to false.

