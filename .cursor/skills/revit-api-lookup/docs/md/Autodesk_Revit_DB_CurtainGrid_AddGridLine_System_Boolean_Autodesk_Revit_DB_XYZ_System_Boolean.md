---
kind: method
id: M:Autodesk.Revit.DB.CurtainGrid.AddGridLine(System.Boolean,Autodesk.Revit.DB.XYZ,System.Boolean)
source: html/8886680c-2075-f542-9fcd-140b8bd87d12.htm
---
# Autodesk.Revit.DB.CurtainGrid.AddGridLine Method

Add a grid line to the curtain grid.

## Syntax (C#)
```csharp
public CurtainGridLine AddGridLine(
	bool isUGridLine,
	XYZ position,
	bool oneSegmentOnly
)
```

## Parameters
- **isUGridLine** (`System.Boolean`) - If true, a U-direction grid line will be added. Otherwise, a V-direction grid line will be added.
- **position** (`Autodesk.Revit.DB.XYZ`) - The position of the grid line.
- **oneSegmentOnly** (`System.Boolean`) - If it is true, only one segment is added. Otherwise, all segments will be added for the grid line.

## Returns
The created grid line is returned if the operation is successful. Otherwise, Nothing nullptr a null reference ( Nothing in Visual Basic) is returned.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if the position for the grid line is out of range.

