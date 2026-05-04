---
kind: property
id: P:Autodesk.Revit.DB.Analysis.MassSurfaceData.PercentageSkylights
source: html/789c7354-a904-227b-2135-95fcce25c476.htm
---
# Autodesk.Revit.DB.Analysis.MassSurfaceData.PercentageSkylights Property

The target percentage of the reference roof surface that is to
 be covered with automatically generated skylights. Revit will use this number when
 determining the size, shape, and location of automatically generated skylights.

## Syntax (C#)
```csharp
public double PercentageSkylights { get; set; }
```

## Remarks
The resulting coverage of the roof with skylights is not guaranteed to
 match this value. It is a target.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The percentage skylights value is between 0.00 and 0.95.

