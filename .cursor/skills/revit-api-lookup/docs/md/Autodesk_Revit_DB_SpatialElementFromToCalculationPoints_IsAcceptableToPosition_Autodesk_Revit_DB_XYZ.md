---
kind: method
id: M:Autodesk.Revit.DB.SpatialElementFromToCalculationPoints.IsAcceptableToPosition(Autodesk.Revit.DB.XYZ)
source: html/b18e836c-0ec0-ad03-1fe5-4df43e2b6ad3.htm
---
# Autodesk.Revit.DB.SpatialElementFromToCalculationPoints.IsAcceptableToPosition Method

Checks whether a given "to" position is valid.

## Syntax (C#)
```csharp
public bool IsAcceptableToPosition(
	XYZ toPosition
)
```

## Parameters
- **toPosition** (`Autodesk.Revit.DB.XYZ`)

## Returns
True if the input is an acceptable "to" position and False otherwise.

## Remarks
The "from" position and the "to" position must be on opposite sides of the family's host. Flipping the calculation
 point will reverse the direction.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

