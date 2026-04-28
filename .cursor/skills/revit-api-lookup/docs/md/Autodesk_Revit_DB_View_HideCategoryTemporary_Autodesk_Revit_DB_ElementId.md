---
kind: method
id: M:Autodesk.Revit.DB.View.HideCategoryTemporary(Autodesk.Revit.DB.ElementId)
zh: 视图
source: html/26684015-0635-cb13-d5a9-f6a6f9b0780a.htm
---
# Autodesk.Revit.DB.View.HideCategoryTemporary Method

**中文**: 视图

Set one category to be temporarily hidden in the view.

## Syntax (C#)
```csharp
public void HideCategoryTemporary(
	ElementId elementId
)
```

## Parameters
- **elementId** (`Autodesk.Revit.DB.ElementId`) - Id of the category to be hidden

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - elementId does not correspond to a Category.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

