---
kind: method
id: M:Autodesk.Revit.DB.Architecture.TopographySurface.ArePointsDistinct(System.Collections.Generic.IList{Autodesk.Revit.DB.XYZ})
source: html/e1a09c30-06c8-dc1f-da89-e98657e11edf.htm
---
# Autodesk.Revit.DB.Architecture.TopographySurface.ArePointsDistinct Method

Identify whether the input points are distinct in XY location.

## Syntax (C#)
```csharp
public static bool ArePointsDistinct(
	IList<XYZ> points
)
```

## Parameters
- **points** (`System.Collections.Generic.IList < XYZ >`) - The points set to be checked.

## Returns
True if all points are distinct after ignoring the elevations, otherwise false.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - There are no points in the input points set.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

