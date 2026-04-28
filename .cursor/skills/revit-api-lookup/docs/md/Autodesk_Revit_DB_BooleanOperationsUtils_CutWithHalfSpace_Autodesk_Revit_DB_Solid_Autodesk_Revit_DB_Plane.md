---
kind: method
id: M:Autodesk.Revit.DB.BooleanOperationsUtils.CutWithHalfSpace(Autodesk.Revit.DB.Solid,Autodesk.Revit.DB.Plane)
source: html/cbde1739-3680-4f2a-8215-a48fd08dcb5c.htm
---
# Autodesk.Revit.DB.BooleanOperationsUtils.CutWithHalfSpace Method

Creates a new Solid which is the intersection of the input Solid with the half-space on the positive side of the given Plane. The positive side of the plane is the side to which Plane.Normal points.

## Syntax (C#)
```csharp
public static Solid CutWithHalfSpace(
	Solid solid,
	Plane plane
)
```

## Parameters
- **solid** (`Autodesk.Revit.DB.Solid`) - The input Solid to be cut.
- **plane** (`Autodesk.Revit.DB.Plane`) - The cut plane. The space on the positive side of the normal of the plane will be intersected with the input Solid.

## Returns
The newly created Solid.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

