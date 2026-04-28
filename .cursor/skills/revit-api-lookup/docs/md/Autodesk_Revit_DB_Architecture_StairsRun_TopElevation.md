---
kind: property
id: P:Autodesk.Revit.DB.Architecture.StairsRun.TopElevation
source: html/d4292003-1fe1-1eeb-20f9-a5b25acaa1eb.htm
---
# Autodesk.Revit.DB.Architecture.StairsRun.TopElevation Property

The top elevation of the stairs run.

## Syntax (C#)
```csharp
public double TopElevation { get; set; }
```

## Remarks
The top elevation has following restrictions:
 The top elevation is relative to the base elevation of the stairs to which the
 stairs run belongs. When setting this property the value will be rounded automatically to a multiple of
 the riser height. When setting this property for common run, the run's height will change according to
 the new base/top elevation. So the value must be greater than base elevation to keep run valid. When setting this property for sketched run, whose height is fixed, the run's base
 elevation will be adjusted to keep the same run height.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for topElevation must be no more than 30000 feet in absolute value.
 -or-
 When setting this property: The topElevation doesn't meet the minimal height restriction of the stairs run.
 -or-
 When setting this property: The topElevation is less than the extension below base of the stairs run.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The stairs run is sketched so the data being set is not applicable.

