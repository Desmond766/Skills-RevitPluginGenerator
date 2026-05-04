---
kind: property
id: P:Autodesk.Revit.DB.Electrical.AnalyticalTransferSwitchData.Voltage
source: html/85f3cc07-2cdd-a26e-04e0-6b2a87871d14.htm
---
# Autodesk.Revit.DB.Electrical.AnalyticalTransferSwitchData.Voltage Property

The voltage value of the electrical analytical transfer switch.

## Syntax (C#)
```csharp
public double Voltage { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The given value for voltage is not a number
 -or-
 When setting this property: The given value for voltage is not finite
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for voltage must be positive.

