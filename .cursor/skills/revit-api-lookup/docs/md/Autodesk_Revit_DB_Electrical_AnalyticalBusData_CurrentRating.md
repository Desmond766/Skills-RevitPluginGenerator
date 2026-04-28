---
kind: property
id: P:Autodesk.Revit.DB.Electrical.AnalyticalBusData.CurrentRating
source: html/55d21f5a-38a6-5962-74d0-5503be2845aa.htm
---
# Autodesk.Revit.DB.Electrical.AnalyticalBusData.CurrentRating Property

The current rating value of the analytical bus.

## Syntax (C#)
```csharp
public double CurrentRating { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The given value for rating is not a number
 -or-
 When setting this property: The given value for rating is not finite
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for rating must be non-negative.

