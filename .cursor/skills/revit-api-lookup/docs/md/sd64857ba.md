---
kind: method
id: M:Autodesk.Revit.DB.CurveByPointsUtils.SetSketchOnSurface(Autodesk.Revit.DB.CurveElement,System.Boolean)
source: html/acb48584-79f4-d323-8ed2-901e4d105752.htm
---
# Autodesk.Revit.DB.CurveByPointsUtils.SetSketchOnSurface Method

Sets the relationship between the CurveElement and face.

## Syntax (C#)
```csharp
public static void SetSketchOnSurface(
	CurveElement curveElem,
	bool sketchOnSurface
)
```

## Parameters
- **curveElem** (`Autodesk.Revit.DB.CurveElement`) - The CurveElement.
- **sketchOnSurface** (`System.Boolean`) - Whether or not the CurveElement should lie on the face and be able to be added to the face.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input CurveElement is not a CurveByPoints.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

