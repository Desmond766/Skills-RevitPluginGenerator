---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeDefinitionByArc.SetArcTypeSpiral(System.Double,System.Double,System.Int32,System.Int32)
source: html/cd7dbab8-c8de-f4ad-2cbe-2d24eb11341f.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDefinitionByArc.SetArcTypeSpiral Method

Set the RebarShapeDefinitionByArc.Type property to Spiral.

## Syntax (C#)
```csharp
public void SetArcTypeSpiral(
	double height,
	double pitch,
	int baseFinishingTurns,
	int topFinishingTurns
)
```

## Parameters
- **height** (`System.Double`) - The height of the spiral (assuming the spiral is vertical).
- **pitch** (`System.Double`) - The pitch, or vertical distance traveled in one rotation.
- **baseFinishingTurns** (`System.Int32`) - The number of finishing turns at the lower end of the spiral.
- **topFinishingTurns** (`System.Int32`) - The number of finishing turns at the upper end of the spiral.

## Remarks
In order to create a spiral definition, you must provide default values for
 height, pitch, and finishing turns.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - baseFinishingTurns is not between 0 and 100.
 -or-
 topFinishingTurns is not between 0 and 100.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for height must be greater than 0 and no more than 30000 feet.
 -or-
 The given value for pitch must be greater than 0 and no more than 30000 feet.

