---
kind: method
id: M:Autodesk.Revit.DB.View.IsolateElementsTemporary(System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
zh: 视图
source: html/ffc40d36-2092-a63c-ce8c-a72ee8430d3d.htm
---
# Autodesk.Revit.DB.View.IsolateElementsTemporary Method

**中文**: 视图

Set multiple elements to be temporarily isolated in the view.
 To isolate a group completely, you must also include all members of all groups and nested groups in your input.

## Syntax (C#)
```csharp
public void IsolateElementsTemporary(
	ICollection<ElementId> elementIds
)
```

## Parameters
- **elementIds** (`System.Collections.Generic.ICollection < ElementId >`) - Ids of elements to be isolated.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

