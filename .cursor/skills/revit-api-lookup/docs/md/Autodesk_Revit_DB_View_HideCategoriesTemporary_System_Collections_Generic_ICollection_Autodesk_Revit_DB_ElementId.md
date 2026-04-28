---
kind: method
id: M:Autodesk.Revit.DB.View.HideCategoriesTemporary(System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
zh: 视图
source: html/2f59330d-a69d-a78b-e364-f22b087960ef.htm
---
# Autodesk.Revit.DB.View.HideCategoriesTemporary Method

**中文**: 视图

Set multiple categories to be temporarily hidden in the view.

## Syntax (C#)
```csharp
public void HideCategoriesTemporary(
	ICollection<ElementId> elementIds
)
```

## Parameters
- **elementIds** (`System.Collections.Generic.ICollection < ElementId >`) - Ids of the categories to be hidden

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Some elements in elementIds do not correspond to a Category.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

