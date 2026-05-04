---
kind: method
id: M:Autodesk.Revit.DB.SketchedStairsCurveData.#ctor(Autodesk.Revit.DB.Curve,System.Double,Autodesk.Revit.DB.Architecture.SketchedCurveSlopeOption)
source: html/5ed0743c-8c3a-8ccc-e59d-ec1b8c5e67a4.htm
---
# Autodesk.Revit.DB.SketchedStairsCurveData.#ctor Method

Construct a SketchedStairsCurveData defined by a curve associated with its height and slope type.

## Syntax (C#)
```csharp
public SketchedStairsCurveData(
	Curve boundaryCurve,
	double height,
	SketchedCurveSlopeOption slopeType
)
```

## Parameters
- **boundaryCurve** (`Autodesk.Revit.DB.Curve`)
- **height** (`System.Double`)
- **slopeType** (`Autodesk.Revit.DB.Architecture.SketchedCurveSlopeOption`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

