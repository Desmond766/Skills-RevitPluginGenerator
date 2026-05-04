---
kind: property
id: P:Autodesk.Revit.DB.Structure.BoundaryConditions.Point
zh: 点
source: html/081e145b-8e09-a6bd-b77b-1e7a7fe8a4cd.htm
---
# Autodesk.Revit.DB.Structure.BoundaryConditions.Point Property

**中文**: 点

Returns the position of point boundary conditions.

## Syntax (C#)
```csharp
public XYZ Point { get; }
```

## Remarks
Boundary conditions should be BoundaryConditionsType::Point type. Otherwise exception is thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidObjectException** - Thrown when BoundaryConditions is not a BoundaryConditionsType::Point type.

