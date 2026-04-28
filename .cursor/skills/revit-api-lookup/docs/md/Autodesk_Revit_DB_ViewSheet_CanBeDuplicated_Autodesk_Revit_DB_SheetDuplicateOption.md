---
kind: method
id: M:Autodesk.Revit.DB.ViewSheet.CanBeDuplicated(Autodesk.Revit.DB.SheetDuplicateOption)
zh: 图纸
source: html/3a45e2af-d541-9fc6-fe33-e314f8712558.htm
---
# Autodesk.Revit.DB.ViewSheet.CanBeDuplicated Method

**中文**: 图纸

Identifies if this sheet can be duplicated.

## Syntax (C#)
```csharp
public bool CanBeDuplicated(
	SheetDuplicateOption duplicateOption
)
```

## Parameters
- **duplicateOption** (`Autodesk.Revit.DB.SheetDuplicateOption`) - The option to use when duplicating the sheet.

## Returns
True if the sheet can be duplicated, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

