---
kind: method
id: M:Autodesk.Revit.DB.Electrical.ElectricalEquipment.IsValidDistributionSystem(Autodesk.Revit.DB.Electrical.DistributionSysType)
source: html/49bf9971-5e28-bd42-9d22-aee4007b798a.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalEquipment.IsValidDistributionSystem Method

Verifies that the Distribution System can be assigned to the Electrical Equipment.

## Syntax (C#)
```csharp
public bool IsValidDistributionSystem(
	DistributionSysType distributionSystem
)
```

## Parameters
- **distributionSystem** (`Autodesk.Revit.DB.Electrical.DistributionSysType`) - The Distribution System to be checked.

## Returns
True if the Distribution System can be assigned to the Electrical Equipment.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

