---
kind: method
id: M:Autodesk.Revit.DB.View.CanCategoryBeHidden(Autodesk.Revit.DB.ElementId)
zh: 视图
source: html/238a1789-90e1-2527-66e3-867db66a9b3b.htm
---
# Autodesk.Revit.DB.View.CanCategoryBeHidden Method

**中文**: 视图

Checks whether the category can be hidden in the view.

## Syntax (C#)
```csharp
public bool CanCategoryBeHidden(
	ElementId elementId
)
```

## Parameters
- **elementId** (`Autodesk.Revit.DB.ElementId`) - ElementId of the category.

## Returns
True if the category can be hidden, false otherwise.

## Remarks
Categories can be allowed to be hidden in some view types and prohibited from being hidden in others.
 E.g., categories cannot be hidden in ProjectBrowser

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

