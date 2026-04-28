---
kind: method
id: M:Autodesk.Revit.DB.Structure.BoundaryConditions.GetCurve
source: html/59a7f80e-394b-56ec-7df8-79b4a0217163.htm
---
# Autodesk.Revit.DB.Structure.BoundaryConditions.GetCurve Method

Returns curve that define geometry of the line boundary conditions.

## Syntax (C#)
```csharp
public Curve GetCurve()
```

## Remarks
Boundary conditions should be BoundaryConditionsType::Line type. Otherwise exception is thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidObjectException** - Thrown when BoundaryConditions is not a BoundaryConditionsType::Line type.

