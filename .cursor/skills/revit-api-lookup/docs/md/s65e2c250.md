---
kind: method
id: M:Autodesk.Revit.DB.Architecture.StairsLanding.SetSketchedLandingBoundaryAndPath(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.CurveLoop,Autodesk.Revit.DB.CurveLoop)
source: html/06a069c8-d944-b723-5b7d-90ec9a896fae.htm
---
# Autodesk.Revit.DB.Architecture.StairsLanding.SetSketchedLandingBoundaryAndPath Method

Sets the boundary and path curves of the sketched landing.

## Syntax (C#)
```csharp
public void SetSketchedLandingBoundaryAndPath(
	Document document,
	CurveLoop boundaryCurveLoop,
	CurveLoop pathCurveLoop
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document that owns the landing.
- **boundaryCurveLoop** (`Autodesk.Revit.DB.CurveLoop`) - The closed boundary curves of the landing.
- **pathCurveLoop** (`Autodesk.Revit.DB.CurveLoop`) - The path curves of the landing, can be an empty CurveLoop.

## Remarks
This should be run from within an open transaction.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The boundaryCurveLoop is not closed.
 -or-
 The input boundaryCurveLoop contains at least one curve which is not a bound Line or bound Arc
 and is not supported for this operation.
 -or-
 The input pathCurveLoop contains at least one curve which is not a bound Line or bound Arc
 and is not supported for this operation.
 -or-
 Failed to create curve element by the boundaryCurveLoop or pathCurveLoop.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

