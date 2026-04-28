---
kind: method
id: M:Autodesk.Revit.DB.View.CanViewBeDuplicated(Autodesk.Revit.DB.ViewDuplicateOption)
zh: 视图
source: html/91a3b412-b96a-a754-45c7-0864e7c75c06.htm
---
# Autodesk.Revit.DB.View.CanViewBeDuplicated Method

**中文**: 视图

Identifies if this view can be duplicated.

## Syntax (C#)
```csharp
public bool CanViewBeDuplicated(
	ViewDuplicateOption duplicateOption
)
```

## Parameters
- **duplicateOption** (`Autodesk.Revit.DB.ViewDuplicateOption`) - The option to use when duplicating the view.

## Returns
True if the view can be duplicated, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

