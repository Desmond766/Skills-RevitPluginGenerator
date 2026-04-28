---
kind: method
id: M:Autodesk.Revit.DB.CurveByPointsUtils.GetProjectionType(Autodesk.Revit.DB.CurveElement)
source: html/deae9675-cffb-a240-27b5-f21e2fb7384d.htm
---
# Autodesk.Revit.DB.CurveByPointsUtils.GetProjectionType Method

Gets the projection type of the CurveElement.

## Syntax (C#)
```csharp
public static CurveProjectionType GetProjectionType(
	CurveElement curveElem
)
```

## Parameters
- **curveElem** (`Autodesk.Revit.DB.CurveElement`) - The CurveElement.

## Returns
The projection type.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input CurveElement is not a CurveByPoints.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

