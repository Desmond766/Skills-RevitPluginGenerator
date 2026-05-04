---
kind: property
id: P:Autodesk.Revit.DB.Electrical.ElectricalEquipment.DistributionSystem
source: html/007c2efd-757f-dda3-c875-50622e546406.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalEquipment.DistributionSystem Property

get or set the Distribution System for the Electrical Equipment.

## Syntax (C#)
```csharp
public DistributionSysType DistributionSystem { get; set; }
```

## Remarks
This property returns a Distribution System which is assigned to the Electrical Equipment.
 If there are no Distribution System assigned to this Electrical Equipment,
 this property will be Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The Distribution System can not be assigned to the Electrical Equipment.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

