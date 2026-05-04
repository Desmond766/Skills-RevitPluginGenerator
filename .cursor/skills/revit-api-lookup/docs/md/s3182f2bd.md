---
kind: property
id: P:Autodesk.Revit.DB.Architecture.StairsRun.BaseElevation
source: html/9ba0ccee-9ac2-0c0a-12de-11a14f3ae5f0.htm
---
# Autodesk.Revit.DB.Architecture.StairsRun.BaseElevation Property

The base elevation of the stairs run.

## Syntax (C#)
```csharp
public double BaseElevation { get; set; }
```

## Remarks
The base elevation has following restrictions:
 The base elevation is relative to the base elevation of the stairs to which the
 stairs run belongs. When setting this property the value will be rounded automatically to a multiple of
 the riser height. When setting this property for common run, the run's height will change according to
 the new base/top elevation. So the value must be less than the top elevation to keep run valid. When setting this property for sketched run, whose height is fixed, the run's top
 elevation will be adjusted to keep the same run height.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for baseElevation must be no more than 30000 feet in absolute value.
 -or-
 When setting this property: The baseElevation doesn't meet the restriction that bottom of run should not be lower than bottom of stairs.
 -or-
 When setting this property: The baseElevation doesn't meet the minimal height restriction of the stairs run.
 -or-
 When setting this property: The baseElevation impacts the top elevation which is less than extension below base.

