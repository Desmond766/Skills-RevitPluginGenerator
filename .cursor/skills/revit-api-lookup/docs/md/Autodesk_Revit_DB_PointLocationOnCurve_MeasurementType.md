---
kind: property
id: P:Autodesk.Revit.DB.PointLocationOnCurve.MeasurementType
source: html/f14034be-7012-dc94-c96f-ef204b00c917.htm
---
# Autodesk.Revit.DB.PointLocationOnCurve.MeasurementType Property

The measurement type.

## Syntax (C#)
```csharp
public PointOnCurveMeasurementType MeasurementType { get; set; }
```

## Remarks
The measurement type is not checked until this class is assigned for a particular reference point on a particular curve.
 At that time, the measurement type must be valid for the curve.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

