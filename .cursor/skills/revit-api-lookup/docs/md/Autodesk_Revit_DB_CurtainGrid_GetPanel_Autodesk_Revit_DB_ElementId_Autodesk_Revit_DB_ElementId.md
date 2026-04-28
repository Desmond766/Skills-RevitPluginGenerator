---
kind: method
id: M:Autodesk.Revit.DB.CurtainGrid.GetPanel(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/cbb3dc60-04a8-2e95-d6c8-f6294ce7b6f6.htm
---
# Autodesk.Revit.DB.CurtainGrid.GetPanel Method

Get the specified panel located by the intersection of the grid lines.

## Syntax (C#)
```csharp
public Panel GetPanel(
	ElementId uGridLineId,
	ElementId vGridLineId
)
```

## Parameters
- **uGridLineId** (`Autodesk.Revit.DB.ElementId`) - The id of a grid line in the U-direction used to locate the panel.
- **vGridLineId** (`Autodesk.Revit.DB.ElementId`) - The id of a grid line in the V-direction used to locate the panel.

## Returns
The panel, or Nothing nullptr a null reference ( Nothing in Visual Basic) if the panel cannot be found at this intersection.

