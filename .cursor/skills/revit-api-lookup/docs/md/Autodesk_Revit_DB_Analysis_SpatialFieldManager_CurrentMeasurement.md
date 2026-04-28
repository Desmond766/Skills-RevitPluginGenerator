---
kind: property
id: P:Autodesk.Revit.DB.Analysis.SpatialFieldManager.CurrentMeasurement
source: html/f47736a5-d94a-8fb1-6c85-7e7ca9e32fe1.htm
---
# Autodesk.Revit.DB.Analysis.SpatialFieldManager.CurrentMeasurement Property

Stores the currently displayed measurement

## Syntax (C#)
```csharp
public int CurrentMeasurement { get; set; }
```

## Remarks
Must be in the range from 0 to (numberOfMeasurements - 1)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: measurement is not in the range from 0 to (number of measurements - 1)

