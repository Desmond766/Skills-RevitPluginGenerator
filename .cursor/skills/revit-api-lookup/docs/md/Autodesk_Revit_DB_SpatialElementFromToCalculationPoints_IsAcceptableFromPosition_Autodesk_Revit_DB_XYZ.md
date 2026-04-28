---
kind: method
id: M:Autodesk.Revit.DB.SpatialElementFromToCalculationPoints.IsAcceptableFromPosition(Autodesk.Revit.DB.XYZ)
source: html/4ab4d035-f4cc-1a33-4bd6-77709007c8ff.htm
---
# Autodesk.Revit.DB.SpatialElementFromToCalculationPoints.IsAcceptableFromPosition Method

Checks whether a given "from" position is valid.

## Syntax (C#)
```csharp
public bool IsAcceptableFromPosition(
	XYZ fromPosition
)
```

## Parameters
- **fromPosition** (`Autodesk.Revit.DB.XYZ`)

## Returns
True if the input is an acceptable "from" position and False otherwise.

## Remarks
The "from" position and the "to" position must be on opposite sides of the family's host. Flipping the calculation
 point will reverse the direction.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

