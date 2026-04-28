---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeDefinitionByArc.#ctor(Autodesk.Revit.DB.Document,System.Double,System.Double,System.Int32,System.Int32)
source: html/5a80585c-198b-040e-f889-481214cceb8f.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDefinitionByArc.#ctor Method

Create a spiral shape definition.

## Syntax (C#)
```csharp
public RebarShapeDefinitionByArc(
	Document doc,
	double height,
	double pitch,
	int baseFinishingTurns,
	int topFinishingTurns
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`)
- **height** (`System.Double`) - The height of the spiral (assuming the spiral is vertical).
- **pitch** (`System.Double`) - The pitch, or vertical distance traveled in one rotation.
- **baseFinishingTurns** (`System.Int32`) - The number of finishing turns at the lower end of the spiral.
- **topFinishingTurns** (`System.Int32`) - The number of finishing turns at the upper end of the spiral.

## Remarks
In order to create a spiral definition, you must provide default values for the spiral-specific parameters.
 Replaces RebarShape.NewDefinitionByArc() from prior versions.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - baseFinishingTurns is not between 0 and 100.
 -or-
 topFinishingTurns is not between 0 and 100.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for height must be greater than 0 and no more than 30000 feet.
 -or-
 The given value for pitch must be greater than 0 and no more than 30000 feet.

