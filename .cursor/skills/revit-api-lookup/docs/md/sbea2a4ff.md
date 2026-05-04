---
kind: property
id: P:Autodesk.Revit.DB.Electrical.ElectricalAnalyticalLoadSet.QuantityOnStandBy
source: html/93cb3c22-efd8-be20-0ae7-c0733a774e9e.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalAnalyticalLoadSet.QuantityOnStandBy Property

The number of Equipment Loads that are not operational at any time.

## Syntax (C#)
```csharp
public int QuantityOnStandBy { get; set; }
```

## Remarks
The equipment loads with smaller load value within the set are considered on standby.
 Must be between 0 and (total count of the Equipment Loads in the LoadSet)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The number is greater than the total count of the Equipment Loads in the LoadSet.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for number is negative.

