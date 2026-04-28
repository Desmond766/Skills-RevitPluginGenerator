---
kind: method
id: M:Autodesk.Revit.DB.SpatialElementGeometryCalculator.CanCalculateGeometry(Autodesk.Revit.DB.SpatialElement)
source: html/2503eca1-87dc-2098-6739-a4364e353f75.htm
---
# Autodesk.Revit.DB.SpatialElementGeometryCalculator.CanCalculateGeometry Method

This indicates whether the input spatial element is a valid one.

## Syntax (C#)
```csharp
public static bool CanCalculateGeometry(
	SpatialElement spatialElement
)
```

## Parameters
- **spatialElement** (`Autodesk.Revit.DB.SpatialElement`) - The spatial element to be checked if its geometry can be calculated.

## Returns
It will return false if the room/space is not enclosed in 2d or has no location, or the height is too small.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

