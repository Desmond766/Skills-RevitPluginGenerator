---
kind: property
id: P:Autodesk.Revit.DB.PointLocationOnCurve.MeasureFrom
source: html/4d7600d5-4abf-7932-0b8c-5e1fdfd0f1ee.htm
---
# Autodesk.Revit.DB.PointLocationOnCurve.MeasureFrom Property

The location on the curve from which the measurement is taken.

## Syntax (C#)
```csharp
public PointOnCurveMeasureFrom MeasureFrom { get; set; }
```

## Remarks
The measure-from is not checked until this class is assigned for a particular reference point on a particular curve.
 At that time, the measure-from must be valid for the curve.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

