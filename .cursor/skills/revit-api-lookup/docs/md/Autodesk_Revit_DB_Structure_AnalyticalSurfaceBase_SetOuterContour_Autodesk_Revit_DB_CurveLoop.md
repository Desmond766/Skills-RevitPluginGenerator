---
kind: method
id: M:Autodesk.Revit.DB.Structure.AnalyticalSurfaceBase.SetOuterContour(Autodesk.Revit.DB.CurveLoop)
source: html/800767fc-e58e-1992-3505-ee1ca45717f0.htm
---
# Autodesk.Revit.DB.Structure.AnalyticalSurfaceBase.SetOuterContour Method

Sets the Curve Loop that defines the geometry of the Analytical Surface element.

## Syntax (C#)
```csharp
public void SetOuterContour(
	CurveLoop outerContour
)
```

## Parameters
- **outerContour** (`Autodesk.Revit.DB.CurveLoop`) - New Curve Loop for the Analytical Surface element.

## Remarks
Curve Loop must be planar and not self-intersecting.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - One of the following requirements is not satisfied :
 - curve loop outerContour is not planar
 - curve loop outerContour is self-intersecting
 - curve loop outerContour contains zero length curves
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Only planar surfaces can be edited.

