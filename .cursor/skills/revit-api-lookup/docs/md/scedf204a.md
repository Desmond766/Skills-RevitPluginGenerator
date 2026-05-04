---
kind: method
id: M:Autodesk.Revit.DB.View.Duplicate(Autodesk.Revit.DB.ViewDuplicateOption)
zh: 视图
source: html/0cb1793f-1df0-d5b4-3b72-8d468b80199e.htm
---
# Autodesk.Revit.DB.View.Duplicate Method

**中文**: 视图

Duplicates this view.

## Syntax (C#)
```csharp
public ElementId Duplicate(
	ViewDuplicateOption duplicateOption
)
```

## Parameters
- **duplicateOption** (`Autodesk.Revit.DB.ViewDuplicateOption`) - The option to use when duplicating the view.

## Returns
The id of the newly created view.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - View cannot be duplicated

