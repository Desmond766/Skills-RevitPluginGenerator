---
kind: method
id: M:Autodesk.Revit.DB.Curve.SetGraphicsStyleId(Autodesk.Revit.DB.ElementId)
zh: 曲线
source: html/bd71365d-d2f2-2758-c220-a2a5c71cc6e4.htm
---
# Autodesk.Revit.DB.Curve.SetGraphicsStyleId Method

**中文**: 曲线

Sets the graphics style id for this curve.

## Syntax (C#)
```csharp
public void SetGraphicsStyleId(
	ElementId id
)
```

## Parameters
- **id** (`Autodesk.Revit.DB.ElementId`) - The id of the GraphicsStyle element from which to apply the curve properties.

## Remarks
If the curve is marked as read-only (because it was extracted directly from
a Revit element or collection/aggregation object), calling this method
causes the object to be changed to carry a disconnected copy of the original curve. The
modification will not affect the original curve or the object that supplied it. Many methods in the Revit API will not use the graphics style associated to this curve. For
example, curves used as portions of the sketch of an element will not read this property. 
Newly created curve elements
will not use this value either, as they inherit their graphical properties from their associated category.

