---
kind: method
id: M:Autodesk.Revit.DB.DatumPlane.GetPropagationViews(Autodesk.Revit.DB.View)
source: html/ecfed956-7434-0c33-6ab0-0bc80bd2a157.htm
---
# Autodesk.Revit.DB.DatumPlane.GetPropagationViews Method

Gets a list of candidate views which are parallel to the current view and to which the extents of the datum may be propagated.

## Syntax (C#)
```csharp
public ISet<ElementId> GetPropagationViews(
	View view
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view on which the DatumPlane shows.

## Returns
A set of ElementIds of the parallel views for extent propagation.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The datum plane cannot be visible in the view.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

