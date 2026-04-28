---
kind: method
id: M:Autodesk.Revit.DB.CurveByPointsUtils.GetSketchOnSurface(Autodesk.Revit.DB.CurveElement)
source: html/fe242e1f-cd4b-bcbb-c8b9-024006e0a84d.htm
---
# Autodesk.Revit.DB.CurveByPointsUtils.GetSketchOnSurface Method

Gets the relationship between the CurveElement and face.

## Syntax (C#)
```csharp
public static bool GetSketchOnSurface(
	CurveElement curveElem
)
```

## Parameters
- **curveElem** (`Autodesk.Revit.DB.CurveElement`) - The CurveElement.

## Returns
Whether or not the CurveElement should lie on the face and be able to be added to the face.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input CurveElement is not a CurveByPoints.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

