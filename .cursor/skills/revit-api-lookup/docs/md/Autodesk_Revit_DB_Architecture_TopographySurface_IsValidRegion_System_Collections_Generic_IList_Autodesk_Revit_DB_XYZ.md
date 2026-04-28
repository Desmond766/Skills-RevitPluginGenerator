---
kind: method
id: M:Autodesk.Revit.DB.Architecture.TopographySurface.IsValidRegion(System.Collections.Generic.IList{Autodesk.Revit.DB.XYZ})
source: html/a0aa044c-9935-6a6b-1d59-a4a380685920.htm
---
# Autodesk.Revit.DB.Architecture.TopographySurface.IsValidRegion Method

Identify whether the points can construct a valid region for a topography surface.

## Syntax (C#)
```csharp
public static bool IsValidRegion(
	IList<XYZ> points
)
```

## Parameters
- **points** (`System.Collections.Generic.IList < XYZ >`) - The points set to be checked.

## Returns
True if the size of points is not less than 3 and the points are not collinear after projecting to XY plane, that is, ignoring the elevation.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - There are no points in the input points set.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

