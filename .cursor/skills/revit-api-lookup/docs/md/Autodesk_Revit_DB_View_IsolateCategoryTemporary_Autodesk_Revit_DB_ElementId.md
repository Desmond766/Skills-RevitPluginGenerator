---
kind: method
id: M:Autodesk.Revit.DB.View.IsolateCategoryTemporary(Autodesk.Revit.DB.ElementId)
zh: 视图
source: html/8bbe17bd-c0f3-d5c5-d94e-a2e04fc42b51.htm
---
# Autodesk.Revit.DB.View.IsolateCategoryTemporary Method

**中文**: 视图

Set one category to be temporarily isolated in the view.

## Syntax (C#)
```csharp
public void IsolateCategoryTemporary(
	ElementId elementId
)
```

## Parameters
- **elementId** (`Autodesk.Revit.DB.ElementId`) - Id of category to be isolated.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - elementId does not correspond to a Category.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

