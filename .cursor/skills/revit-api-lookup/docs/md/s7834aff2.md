---
kind: method
id: M:Autodesk.Revit.DB.ViewSheet.Duplicate(Autodesk.Revit.DB.SheetDuplicateOption)
zh: 图纸
source: html/2466b896-0ce9-2d6e-e136-202d77ed7b79.htm
---
# Autodesk.Revit.DB.ViewSheet.Duplicate Method

**中文**: 图纸

Duplicates this sheet to generate a new one.

## Syntax (C#)
```csharp
public ElementId Duplicate(
	SheetDuplicateOption duplicateOption
)
```

## Parameters
- **duplicateOption** (`Autodesk.Revit.DB.SheetDuplicateOption`) - The option to use when duplicating the sheet.

## Returns
The id of the newly created sheet.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Sheet cannot be duplicated

