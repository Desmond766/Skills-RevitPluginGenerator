---
kind: method
id: M:Autodesk.Revit.DB.Structure.BoundaryConditions.GetLoops
source: html/caf2fb5e-e3dd-f284-320c-178d93d66b55.htm
---
# Autodesk.Revit.DB.Structure.BoundaryConditions.GetLoops Method

Returns curve loops that define geometry of the area boundary conditions.

## Syntax (C#)
```csharp
public IList<CurveLoop> GetLoops()
```

## Returns
The curve loop collection.

## Remarks
Boundary conditions should be BoundaryConditionsType::Area type. Otherwise exception is thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidObjectException** - Thrown when BoundaryConditions is not a BoundaryConditionsType::Area type.

