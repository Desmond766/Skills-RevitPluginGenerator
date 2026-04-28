---
kind: method
id: M:Autodesk.Revit.DB.CurtainGrid.GetCell(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/6fa6e433-953c-35e4-ded6-f578c28e42ff.htm
---
# Autodesk.Revit.DB.CurtainGrid.GetCell Method

Get the specified cell located by the intersection of the grid lines.

## Syntax (C#)
```csharp
public CurtainCell GetCell(
	ElementId uGridLineId,
	ElementId vGridLineId
)
```

## Parameters
- **uGridLineId** (`Autodesk.Revit.DB.ElementId`) - The id of a grid line in the U-direction used to locate the cell.
- **vGridLineId** (`Autodesk.Revit.DB.ElementId`) - The id of a grid line in the V-direction used to locate the cell.

## Returns
The cell.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the grid line ids are not part of this curtain grid.

