---
kind: property
id: P:Autodesk.Revit.DB.Electrical.AreaBasedLoadData.Voltage
source: html/8709fbe4-24ac-79b1-cd15-f3a96d511b6c.htm
---
# Autodesk.Revit.DB.Electrical.AreaBasedLoadData.Voltage Property

The voltage of the area based load.

## Syntax (C#)
```csharp
public double Voltage { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The given value for voltage is not a number
 -or-
 When setting this property: The given value for voltage is not finite
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for voltage must be positive.

