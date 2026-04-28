---
kind: method
id: M:Autodesk.Revit.DB.ReferencePoint.GetCoordinateSystem
source: html/809b7a59-5911-a62d-4144-3e0d498d81a0.htm
---
# Autodesk.Revit.DB.ReferencePoint.GetCoordinateSystem Method

The position and orientation of the ReferencePoint.

## Syntax (C#)
```csharp
public Transform GetCoordinateSystem()
```

## Remarks
The position of the point is given by
CoordinateSystem.Origin, and the orientation is specified
by the three unit vectors CoordinateSystem.BasisX, BasisY,
BasisZ.

