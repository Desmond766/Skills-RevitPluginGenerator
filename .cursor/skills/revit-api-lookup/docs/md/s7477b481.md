---
kind: method
id: M:Autodesk.Revit.DB.SpatialElementGeometryCalculator.CalculateSpatialElementGeometry(Autodesk.Revit.DB.SpatialElement)
source: html/6dbe1057-76ed-c8e4-1d05-95cf65aa18e7.htm
---
# Autodesk.Revit.DB.SpatialElementGeometryCalculator.CalculateSpatialElementGeometry Method

Compute the spatial element geometry and returns the boundary face information.

## Syntax (C#)
```csharp
public SpatialElementGeometryResults CalculateSpatialElementGeometry(
	SpatialElement spatialElement
)
```

## Parameters
- **spatialElement** (`Autodesk.Revit.DB.SpatialElement`) - Specifies the spatial element needs to be computed, should be Room or Space.

## Returns
Requested boundary face information.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - spatialElement is not a room or a space, and thus has no 3D geometry to calculate.
 -or-
 spatialElement is not enclosed in 2d or has no location, or the height is too small, and thus has no 3D geometry to calculate.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Failed to compute the given spatial element's geometry.

