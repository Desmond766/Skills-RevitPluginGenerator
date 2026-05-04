---
kind: property
id: P:Autodesk.Revit.DB.PointLocationOnCurve.MeasurementValue
source: html/7e7d4945-4e0d-41e6-6ec9-8864644d309b.htm
---
# Autodesk.Revit.DB.PointLocationOnCurve.MeasurementValue Property

The measurement value.

## Syntax (C#)
```csharp
public double MeasurementValue { get; set; }
```

## Remarks
The measurement value is not checked until this class is assigned for a particular reference point on a particular curve.
 At that time, the measurement value must match the expected range for the curve for the given measurement type and measure-from.

