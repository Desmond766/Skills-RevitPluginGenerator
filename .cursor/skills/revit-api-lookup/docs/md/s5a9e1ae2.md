---
kind: method
id: M:Autodesk.Revit.DB.Architecture.TopographySurface.ContainsPoint(Autodesk.Revit.DB.XYZ)
source: html/d0e5a2f0-eb77-4efb-91f2-ce5428b53ab1.htm
---
# Autodesk.Revit.DB.Architecture.TopographySurface.ContainsPoint Method

Identifies whether the given point exists in the topography surface.

## Syntax (C#)
```csharp
public bool ContainsPoint(
	XYZ point
)
```

## Parameters
- **point** (`Autodesk.Revit.DB.XYZ`) - The point to be checked.

## Returns
True if the input point exists in the topography surface, otherwise false.

## Remarks
The given point will be evaluated in XYZ. If a point matches the XY location, but not the elevation, this function still returns false.
 This applies to TopographySurface and SiteSubRegion elements.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

