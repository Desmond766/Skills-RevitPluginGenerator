---
kind: property
id: P:Autodesk.Revit.DB.Mechanical.MechanicalEquipmentSet.OnDuty
source: html/a27d7f63-59f3-8efc-3185-00c4dc92be72.htm
---
# Autodesk.Revit.DB.Mechanical.MechanicalEquipmentSet.OnDuty Property

The number of pieces of mechanical equipment operating in parallel at any given time.

## Syntax (C#)
```csharp
public int OnDuty { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The number of on duty (number) must be less than or equal to the number of available equipments or there should be at least one equipment on duty.

