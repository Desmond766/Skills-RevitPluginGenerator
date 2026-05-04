---
kind: property
id: P:Autodesk.Revit.DB.FootPrintRoof.SlopeAngle(Autodesk.Revit.DB.ModelCurve)
source: html/4d58f862-472b-0cc1-a250-5ed1100911d9.htm
---
# Autodesk.Revit.DB.FootPrintRoof.SlopeAngle Property

Retrieve or set the SlopeAngle of the curve.

## Syntax (C#)
```csharp
public double this[
	ModelCurve pCurve
] { get; set; }
```

## Parameters
- **pCurve** (`Autodesk.Revit.DB.ModelCurve`)

## Remarks
The value is a "slope" measurement. For example, 0.5 is one unit of rise for each 2 units of run. This creates 
a slope of 26.57 degrees (the arctangent of 0.5).

