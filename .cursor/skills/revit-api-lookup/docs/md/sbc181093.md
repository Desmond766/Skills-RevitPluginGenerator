---
kind: property
id: P:Autodesk.Revit.DB.Electrical.ElectricalSystem.VoltageDrop
source: html/2f7d179a-a6c3-375b-d184-cc796e918f5d.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalSystem.VoltageDrop Property

The VoltageDrop value of the Electrical System.

## Syntax (C#)
```csharp
public double VoltageDrop { get; }
```

## Remarks
This property is used to retrieve the VoltageDrop value of the Electrical System.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This property only available when System Type is Power!
 -or-
 Thrown when the voltage drop cannot be computed, because it is zero, or because the circuit is not connected to a panel.

