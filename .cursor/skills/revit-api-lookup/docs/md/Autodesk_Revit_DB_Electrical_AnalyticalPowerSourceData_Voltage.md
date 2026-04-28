---
kind: property
id: P:Autodesk.Revit.DB.Electrical.AnalyticalPowerSourceData.Voltage
source: html/fc7a9c1a-6a5d-3103-fbe0-87f7f4888c6e.htm
---
# Autodesk.Revit.DB.Electrical.AnalyticalPowerSourceData.Voltage Property

The voltage value of the analytical power source.

## Syntax (C#)
```csharp
public double Voltage { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The given value for voltage is not a number
 -or-
 When setting this property: The given value for voltage is not finite
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for voltage must be positive.

