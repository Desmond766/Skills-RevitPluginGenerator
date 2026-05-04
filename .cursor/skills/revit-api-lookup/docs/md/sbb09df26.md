---
kind: method
id: M:Autodesk.Revit.DB.Electrical.ElectricalSetting.RemoveVoltageType(Autodesk.Revit.DB.Electrical.VoltageType)
source: html/657db947-8a83-86fa-da81-2451fc2026d6.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalSetting.RemoveVoltageType Method

Remove the voltage type from project.

## Syntax (C#)
```csharp
public void RemoveVoltageType(
	VoltageType voltageType
)
```

## Parameters
- **voltageType** (`Autodesk.Revit.DB.Electrical.VoltageType`) - Specify the voltage type to be removed.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Voltage type can be removed only if it isn't in service with any distribution systems.

