---
kind: property
id: P:Autodesk.Revit.DB.Electrical.AnalyticalBusData.Voltage
source: html/563253e4-637d-ef44-3461-1fa3d53ee217.htm
---
# Autodesk.Revit.DB.Electrical.AnalyticalBusData.Voltage Property

The voltage value of the analytical bus.

## Syntax (C#)
```csharp
public double Voltage { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The given value for voltage is not a number
 -or-
 When setting this property: The given value for voltage is not finite
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for voltage must be positive.

