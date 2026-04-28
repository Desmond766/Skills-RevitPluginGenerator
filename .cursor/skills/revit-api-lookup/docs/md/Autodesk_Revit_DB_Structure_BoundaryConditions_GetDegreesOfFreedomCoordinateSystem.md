---
kind: method
id: M:Autodesk.Revit.DB.Structure.BoundaryConditions.GetDegreesOfFreedomCoordinateSystem
source: html/7528eafa-4031-a508-1a9f-5a0f3488cad8.htm
---
# Autodesk.Revit.DB.Structure.BoundaryConditions.GetDegreesOfFreedomCoordinateSystem Method

Gets the origin and rotation of coordinate system that is used by translation and rotation parameters, like X Translation or Z Rotation.

## Syntax (C#)
```csharp
public Transform GetDegreesOfFreedomCoordinateSystem()
```

## Returns
The coordinate system. Origin contains the position of the start of the boundary conditions. BasisX, BasisY and BasisZ contain the directions of the axes in the global coordinate system.

