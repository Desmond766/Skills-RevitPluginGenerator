---
kind: property
id: P:Autodesk.Revit.DB.Analysis.MassSurfaceData.PercentageGlazing
source: html/c6d03198-1d30-f0d8-e2b9-d4b94128b984.htm
---
# Autodesk.Revit.DB.Analysis.MassSurfaceData.PercentageGlazing Property

The target percentage of the reference wall surface that is to
 be covered with automatically generated windows. Revit will use this number when
 determining the size, shape, and location of automatically generated windows.

## Syntax (C#)
```csharp
public double PercentageGlazing { get; set; }
```

## Remarks
The resulting coverage of the wall with windows is not guaranteed to
 match this value. It is a target.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The percentage glazing value is not between 0.00 and 0.95.

