---
kind: method
id: M:Autodesk.Revit.DB.DatumPlane.PropagateToViews(Autodesk.Revit.DB.View,System.Collections.Generic.ISet{Autodesk.Revit.DB.ElementId})
source: html/4512810a-93c3-d127-6197-94da427d54a2.htm
---
# Autodesk.Revit.DB.DatumPlane.PropagateToViews Method

Propagates the extents applied to this datum in the view to the specified parallel views.

## Syntax (C#)
```csharp
public void PropagateToViews(
	View view,
	ISet<ElementId> parallelViews
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view on which the DatumPlane shows.
- **parallelViews** (`System.Collections.Generic.ISet < ElementId >`) - The ids of the specified parallel views.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The datum plane cannot be visible in the view.
 -or-
 One ElementId in parallelViews is not valid for extent propagation.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

