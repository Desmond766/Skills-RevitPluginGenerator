---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarShapeConstraintAngleFromFixedDir.Direction
source: html/7a09e048-90d7-2193-c068-e930bd96009b.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeConstraintAngleFromFixedDir.Direction Property

A fixed direction in UV-space. The parameter will drive
 the segment's angle relative to this direction.

## Syntax (C#)
```csharp
public UV Direction { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: direction has zero length.

