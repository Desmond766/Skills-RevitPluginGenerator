---
kind: property
id: P:Autodesk.Revit.DB.Electrical.ElectricalEquipment.MaxNumberOfCircuits
source: html/75b8966b-3ec3-50cb-8b58-8f79b770490f.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalEquipment.MaxNumberOfCircuits Property

The maximum number of circuits for switchboard.
 The quantity of circuits can be assigned to switchboard through breaker.

## Syntax (C#)
```csharp
public int MaxNumberOfCircuits { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The input max number of circuits value is invalid for switchboard.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The electrical equipment is not a switchboard equipment.

