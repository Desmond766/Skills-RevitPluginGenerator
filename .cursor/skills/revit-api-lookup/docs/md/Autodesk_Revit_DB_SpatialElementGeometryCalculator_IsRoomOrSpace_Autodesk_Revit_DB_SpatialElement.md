---
kind: method
id: M:Autodesk.Revit.DB.SpatialElementGeometryCalculator.IsRoomOrSpace(Autodesk.Revit.DB.SpatialElement)
source: html/0393222f-7881-594f-095e-57618ea04048.htm
---
# Autodesk.Revit.DB.SpatialElementGeometryCalculator.IsRoomOrSpace Method

This indicates whether the input spatial element is a room or a space.

## Syntax (C#)
```csharp
public static bool IsRoomOrSpace(
	SpatialElement spatialElement
)
```

## Parameters
- **spatialElement** (`Autodesk.Revit.DB.SpatialElement`) - The spatial element to be checked if it is a room or a space or not.

## Returns
True if the input spatial element is a room or a space, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

