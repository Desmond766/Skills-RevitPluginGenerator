---
kind: method
id: M:Autodesk.Revit.DB.View.IsolateCategoriesTemporary(System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
zh: 视图
source: html/f2da8240-d8bd-f45e-e597-13c05b8fcaf0.htm
---
# Autodesk.Revit.DB.View.IsolateCategoriesTemporary Method

**中文**: 视图

Set categories to be temporarily isolated in the view.

## Syntax (C#)
```csharp
public void IsolateCategoriesTemporary(
	ICollection<ElementId> elementIds
)
```

## Parameters
- **elementIds** (`System.Collections.Generic.ICollection < ElementId >`) - Ids of categories to be isolated.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Some elements in elementIds do not correspond to a Category.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

